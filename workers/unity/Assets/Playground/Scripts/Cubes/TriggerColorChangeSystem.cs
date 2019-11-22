using System;
using Improbable.Gdk.Core;
using Unity.Entities;
using UnityEngine;

namespace Playground
{
    [UpdateInGroup(typeof(SpatialOSUpdateGroup))]
    public class TriggerColorChangeSystem : ComponentSystem
    {
        private EntityQuery group;
        private ComponentUpdateSystem updateSystem;

        private Array colorValues;
        private int colorIndex;
        private float nextColorChange;

        protected override void OnCreate()
        {
            base.OnCreate();

            updateSystem = World.GetExistingSystem<ComponentUpdateSystem>();

            group = GetEntityQuery(
                ComponentType.ReadOnly<CubeColor.Authoritative>(),
                ComponentType.ReadOnly<SpatialEntityId>()
            );

            colorValues = Enum.GetValues(typeof(Color));
        }

        protected override void OnUpdate()
        {
            if (Time.ElapsedTime < nextColorChange)
            {
                return;
            }

            nextColorChange = (float) Time.ElapsedTime + 2.0f;

            var colorEventData = new ColorData
            {
                Color = (Color) colorValues.GetValue(colorIndex),
            };

            Entities.With(group).ForEach((ref SpatialEntityId spatialEntityId) =>
            {
                updateSystem.SendEvent(new CubeColor.ChangeColor.Event(colorEventData), spatialEntityId.EntityId);
            });

            colorIndex = (colorIndex + 1) % colorValues.Length;
        }
    }
}
