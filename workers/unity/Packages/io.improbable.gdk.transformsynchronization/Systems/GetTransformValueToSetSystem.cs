﻿using Improbable.Gdk.Core;
using Unity.Entities;

namespace Improbable.Gdk.TransformSynchronization
{
    [DisableAutoCreation]
    [UpdateInGroup(typeof(FixedUpdateSystemGroup))]
    public class GetTransformValueToSetSystem : ComponentSystem
    {
        private WorkerSystem worker;

        private EntityQuery transformGroup;

        protected override void OnCreate()
        {
            base.OnCreate();

            worker = World.GetExistingSystem<WorkerSystem>();

            transformGroup = GetEntityQuery(new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadWrite<BufferedTransform>(),
                    ComponentType.ReadWrite<TransformToSet>(),
                },
                None = new[]
                {
                    ComponentType.ReadOnly<TransformInternal.Authoritative>(),
                }
            });
        }

        protected override void OnUpdate()
        {
            Entities.With(transformGroup).ForEach(
                (DynamicBuffer<BufferedTransform> buffer, ref TransformToSet transformToSet) =>
                {
                    if (buffer.Length == 0)
                    {
                        return;
                    }

                    var bufferHead = buffer[0];

                    transformToSet = new TransformToSet
                    {
                        Position = bufferHead.Position + worker.Origin,
                        Orientation = bufferHead.Orientation,
                        Velocity = bufferHead.Velocity,
                        ApproximateRemoteTick = bufferHead.PhysicsTick
                    };

                    buffer.RemoveAt(0);
                });
        }
    }
}
