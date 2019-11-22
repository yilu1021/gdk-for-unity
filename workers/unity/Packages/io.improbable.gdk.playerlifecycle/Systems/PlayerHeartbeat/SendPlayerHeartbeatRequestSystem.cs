using Improbable.Gdk.Core;
using Unity.Entities;

namespace Improbable.Gdk.PlayerLifecycle
{
    [DisableAutoCreation]
    [UpdateBefore(typeof(SpatialOSUpdateGroup))]
    public class SendPlayerHeartbeatRequestSystem : ComponentSystem
    {
        private float timeOfNextHeartbeat;
        private EntityQuery group;
        private CommandSystem commandSystem;

        protected override void OnCreate()
        {
            base.OnCreate();

            group = GetEntityQuery(
                ComponentType.ReadOnly<PlayerHeartbeatServer.Authoritative>(),
                ComponentType.ReadWrite<HeartbeatData>(),
                ComponentType.ReadOnly<SpatialEntityId>()
            );

            commandSystem = World.GetExistingSystem<CommandSystem>();
        }

        protected override void OnUpdate()
        {
            if (Time.ElapsedTime < timeOfNextHeartbeat)
            {
                return;
            }

            timeOfNextHeartbeat = (float) Time.ElapsedTime + PlayerLifecycleConfig.PlayerHeartbeatIntervalSeconds;

            Entities.With(group).ForEach((ref SpatialEntityId spatialEntityId) =>
            {
                commandSystem.SendCommand(
                    new PlayerHeartbeatClient.PlayerHeartbeat.Request(spatialEntityId.EntityId, new Empty()));
            });
        }
    }
}
