using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Improbable.Gdk.Core.Commands;
using Improbable.Worker.CInterop;
using Unity.Entities;

namespace Improbable.Gdk.Core
{
    public class EntityReservationSystem : ComponentSystem
    {
        public uint TargetEntityIdCount = 100;
        public uint MinimumReservationCount = 10;

        // Actual entities left on stack
        private long queuedReservationCount;
        private long inFlightCount;

        private readonly HashSet<long> requestIds = new HashSet<long>();

        private readonly Queue<(TaskCompletionSource<EntityId[]> taskCompletionSource, uint count)> queuedReservations =
            new Queue<(TaskCompletionSource<EntityId[]> taskCompletionSource, uint count)>();

        private readonly EntityRangeCollection entityIdQueue = new EntityRangeCollection();
        private CommandSystem commandSystem;

        protected override void OnCreate()
        {
            commandSystem = World.GetExistingSystem<CommandSystem>();
        }

        protected override void OnUpdate()
        {
            // If there are outstanding requests, receive them
            HandleReservationResponses();

            // If there are queued ranges, attempt to resolve them
            ResolveQueuedRequests();

            // Request new entity id's? (Maybe move to another system)
            RequestQueueRefill();
        }

        private void RequestQueueRefill()
        {
            var requestCount = TargetEntityIdCount + queuedReservationCount - inFlightCount - entityIdQueue.Count;
            if (requestCount > 0)
            {
                requestCount = Math.Max(requestCount, MinimumReservationCount);
                inFlightCount += requestCount;
                var reserveEntityIdsRequest = new WorldCommands.ReserveEntityIds.Request((uint) requestCount);
                commandSystem.SendCommand(reserveEntityIdsRequest);
            }
        }

        private void HandleReservationResponses()
        {
            var incomingRequests = commandSystem.GetResponses<WorldCommands.ReserveEntityIds.ReceivedResponse>();
            for (var i = 0; i < incomingRequests.Count; i++)
            {
                ref readonly var request = ref incomingRequests[i];
                if (!requestIds.Contains(request.RequestId))
                {
                    continue;
                }

                if (request.StatusCode == StatusCode.Success)
                {
                    //Add range to queue
                    var range = new EntityRangeCollection.EntityIdRange(request.FirstEntityId.Value, (uint) request.NumberOfEntityIds);
                    entityIdQueue.Add(range);
                }

                inFlightCount -= request.RequestPayload.NumberOfEntityIds;

                // Remove ID from the set as it has been handled.
                requestIds.Remove(request.RequestId);
            }
        }

        private void ResolveQueuedRequests()
        {
            // Remove canceled reservations from the queue
            while (queuedReservations.Count > 0)
            {
                var (taskCompletionSource, count) = queuedReservations.Peek();
                if (!taskCompletionSource.Task.IsCanceled)
                {
                    break;
                }

                queuedReservationCount -= count;
                queuedReservations.Dequeue();
            }

            // Loop over queued request, check if we have enough, and call them
            foreach (var (taskCompletionSource, count) in queuedReservations)
            {
                if (entityIdQueue.Count < count)
                {
                    break;
                }

                queuedReservationCount -= count;
                taskCompletionSource.SetResult(entityIdQueue.Take(count));
            }
        }

        public bool TryGet(out EntityId entityId)
        {
            if (entityIdQueue.Count > 0)
            {
                entityId = entityIdQueue.Dequeue();
                return true;
            }

            entityId = default;
            return false;
        }

        public Task<EntityId[]> Take(uint count, CancellationToken cancellationToken = default)
        {
            if (entityIdQueue.Count >= count)
            {
                return Task.FromResult(entityIdQueue.Take(count));
            }
            else
            {
                queuedReservationCount += count;

                var tcs = new TaskCompletionSource<EntityId[]>();
                cancellationToken.Register((source) =>
                {
                    ((TaskCompletionSource<EntityId[]>) source).TrySetCanceled();
                }, tcs);

                queuedReservations.Enqueue((tcs, count));
                return tcs.Task;
            }
        }
    }
}
