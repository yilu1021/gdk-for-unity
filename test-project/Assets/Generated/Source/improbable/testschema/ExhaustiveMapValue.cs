// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Improbable.Gdk.Core;
using Improbable.Worker.CInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Entities;

namespace Improbable.TestSchema
{
    public partial class ExhaustiveMapValue
    {
        public const uint ComponentId = 197718;

        public unsafe struct Component : IComponentData, ISpatialComponentData, ISnapshottable<Snapshot>
        {
            public uint ComponentId => 197718;

            // Bit masks for tracking which component properties were changed locally and need to be synced.
            private fixed UInt32 dirtyBits[1];

            public bool IsDataDirty()
            {
                var isDataDirty = false;

                isDataDirty |= (dirtyBits[0] != 0x0);

                return isDataDirty;
            }

            /*
            The propertyIndex argument counts up from 0 in the order defined in your schema component.
            It is not the schema field number itself. For example:
            component MyComponent
            {
                id = 1337;
                bool val_a = 1;
                bool val_b = 3;
            }
            In that case, val_a corresponds to propertyIndex 0 and val_b corresponds to propertyIndex 1 in this method.
            This method throws an InvalidOperationException in case your component doesn't contain properties.
            */

            public bool IsDataDirty(int propertyIndex)
            {
                ValidateFieldIndex(propertyIndex);

                // Retrieve the dirtyBits[0-n] field that tracks this property.
                var dirtyBitsByteIndex = propertyIndex >> 4;
                return (dirtyBits[dirtyBitsByteIndex] & (0x1 << (propertyIndex & 31))) != 0x0;
            }

            // Like the IsDataDirty() method above, the propertyIndex arguments starts counting from 0.
            // This method throws an InvalidOperationException in case your component doesn't contain properties.
            public void MarkDataDirty(int propertyIndex)
            {
                ValidateFieldIndex(propertyIndex);

                // Retrieve the dirtyBits[0-n] field that tracks this property.
                var dirtyBitsByteIndex = propertyIndex >> 4;
                dirtyBits[dirtyBitsByteIndex] |= (UInt32) (0x1 << (propertyIndex & 31));
            }

            public void MarkDataClean()
            {
                dirtyBits[0] = 0x0;
            }

            [Conditional("DEBUG")]
            private void ValidateFieldIndex(int propertyIndex)
            {
                if (propertyIndex < 0 || propertyIndex >= 18)
                {
                    throw new ArgumentException("\"propertyIndex\" argument out of range. Valid range is [0, 17]. " +
                        "Unless you are using custom component replication code, this is most likely caused by a code generation bug. " +
                        "Please contact SpatialOS support if you encounter this issue.");
                }
            }

            public Snapshot ToComponentSnapshot(global::Unity.Entities.World world)
            {
                var componentDataSchema = new ComponentData(197718, SchemaComponentData.Create());
                Serialization.SerializeComponent(this, componentDataSchema.SchemaData.Value.GetFields(), world);
                var snapshot = Serialization.DeserializeSnapshot(componentDataSchema.SchemaData.Value.GetFields());

                componentDataSchema.SchemaData?.Destroy();
                componentDataSchema.SchemaData = null;

                return snapshot;
            }

            internal uint field1Handle;

            public global::System.Collections.Generic.Dictionary<string, bool> Field1
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field1Provider.Get(field1Handle);
                set
                {
                    MarkDataDirty(0);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field1Provider.Set(field1Handle, value);
                }
            }

            internal uint field2Handle;

            public global::System.Collections.Generic.Dictionary<string, float> Field2
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field2Provider.Get(field2Handle);
                set
                {
                    MarkDataDirty(1);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field2Provider.Set(field2Handle, value);
                }
            }

            internal uint field3Handle;

            public global::System.Collections.Generic.Dictionary<string, byte[]> Field3
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field3Provider.Get(field3Handle);
                set
                {
                    MarkDataDirty(2);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field3Provider.Set(field3Handle, value);
                }
            }

            internal uint field4Handle;

            public global::System.Collections.Generic.Dictionary<string, int> Field4
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field4Provider.Get(field4Handle);
                set
                {
                    MarkDataDirty(3);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field4Provider.Set(field4Handle, value);
                }
            }

            internal uint field5Handle;

            public global::System.Collections.Generic.Dictionary<string, long> Field5
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field5Provider.Get(field5Handle);
                set
                {
                    MarkDataDirty(4);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field5Provider.Set(field5Handle, value);
                }
            }

            internal uint field6Handle;

            public global::System.Collections.Generic.Dictionary<string, double> Field6
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field6Provider.Get(field6Handle);
                set
                {
                    MarkDataDirty(5);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field6Provider.Set(field6Handle, value);
                }
            }

            internal uint field7Handle;

            public global::System.Collections.Generic.Dictionary<string, string> Field7
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field7Provider.Get(field7Handle);
                set
                {
                    MarkDataDirty(6);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field7Provider.Set(field7Handle, value);
                }
            }

            internal uint field8Handle;

            public global::System.Collections.Generic.Dictionary<string, uint> Field8
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field8Provider.Get(field8Handle);
                set
                {
                    MarkDataDirty(7);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field8Provider.Set(field8Handle, value);
                }
            }

            internal uint field9Handle;

            public global::System.Collections.Generic.Dictionary<string, ulong> Field9
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field9Provider.Get(field9Handle);
                set
                {
                    MarkDataDirty(8);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field9Provider.Set(field9Handle, value);
                }
            }

            internal uint field10Handle;

            public global::System.Collections.Generic.Dictionary<string, int> Field10
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field10Provider.Get(field10Handle);
                set
                {
                    MarkDataDirty(9);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field10Provider.Set(field10Handle, value);
                }
            }

            internal uint field11Handle;

            public global::System.Collections.Generic.Dictionary<string, long> Field11
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field11Provider.Get(field11Handle);
                set
                {
                    MarkDataDirty(10);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field11Provider.Set(field11Handle, value);
                }
            }

            internal uint field12Handle;

            public global::System.Collections.Generic.Dictionary<string, uint> Field12
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field12Provider.Get(field12Handle);
                set
                {
                    MarkDataDirty(11);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field12Provider.Set(field12Handle, value);
                }
            }

            internal uint field13Handle;

            public global::System.Collections.Generic.Dictionary<string, ulong> Field13
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field13Provider.Get(field13Handle);
                set
                {
                    MarkDataDirty(12);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field13Provider.Set(field13Handle, value);
                }
            }

            internal uint field14Handle;

            public global::System.Collections.Generic.Dictionary<string, int> Field14
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field14Provider.Get(field14Handle);
                set
                {
                    MarkDataDirty(13);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field14Provider.Set(field14Handle, value);
                }
            }

            internal uint field15Handle;

            public global::System.Collections.Generic.Dictionary<string, long> Field15
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field15Provider.Get(field15Handle);
                set
                {
                    MarkDataDirty(14);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field15Provider.Set(field15Handle, value);
                }
            }

            internal uint field16Handle;

            public global::System.Collections.Generic.Dictionary<string, global::Improbable.Gdk.Core.EntityId> Field16
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field16Provider.Get(field16Handle);
                set
                {
                    MarkDataDirty(15);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field16Provider.Set(field16Handle, value);
                }
            }

            internal uint field17Handle;

            public global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeType> Field17
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field17Provider.Get(field17Handle);
                set
                {
                    MarkDataDirty(16);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field17Provider.Set(field17Handle, value);
                }
            }

            internal uint field18Handle;

            public global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeEnum> Field18
            {
                get => global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field18Provider.Get(field18Handle);
                set
                {
                    MarkDataDirty(17);
                    global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field18Provider.Set(field18Handle, value);
                }
            }
        }

        public struct ComponentAuthority : ISharedComponentData, IEquatable<ComponentAuthority>
        {
            public bool HasAuthority;

            public ComponentAuthority(bool hasAuthority)
            {
                HasAuthority = hasAuthority;
            }

            // todo think about whether any of this is necessary
            // Unity does a bitwise equality check so this is just for users reading the struct
            public static readonly ComponentAuthority NotAuthoritative = new ComponentAuthority(false);
            public static readonly ComponentAuthority Authoritative = new ComponentAuthority(true);

            public bool Equals(ComponentAuthority other)
            {
                return this == other;
            }

            public override bool Equals(object obj)
            {
                return obj is ComponentAuthority auth && this == auth;
            }

            public override int GetHashCode()
            {
                return HasAuthority.GetHashCode();
            }

            public static bool operator ==(ComponentAuthority a, ComponentAuthority b)
            {
                return a.HasAuthority == b.HasAuthority;
            }

            public static bool operator !=(ComponentAuthority a, ComponentAuthority b)
            {
                return !(a == b);
            }
        }

        [global::System.Serializable]
        public struct Snapshot : ISpatialComponentSnapshot
        {
            public uint ComponentId => 197718;

            public global::System.Collections.Generic.Dictionary<string, bool> Field1;
            public global::System.Collections.Generic.Dictionary<string, float> Field2;
            public global::System.Collections.Generic.Dictionary<string, byte[]> Field3;
            public global::System.Collections.Generic.Dictionary<string, int> Field4;
            public global::System.Collections.Generic.Dictionary<string, long> Field5;
            public global::System.Collections.Generic.Dictionary<string, double> Field6;
            public global::System.Collections.Generic.Dictionary<string, string> Field7;
            public global::System.Collections.Generic.Dictionary<string, uint> Field8;
            public global::System.Collections.Generic.Dictionary<string, ulong> Field9;
            public global::System.Collections.Generic.Dictionary<string, int> Field10;
            public global::System.Collections.Generic.Dictionary<string, long> Field11;
            public global::System.Collections.Generic.Dictionary<string, uint> Field12;
            public global::System.Collections.Generic.Dictionary<string, ulong> Field13;
            public global::System.Collections.Generic.Dictionary<string, int> Field14;
            public global::System.Collections.Generic.Dictionary<string, long> Field15;
            public global::System.Collections.Generic.Dictionary<string, global::Improbable.Gdk.Core.EntityId> Field16;
            public global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeType> Field17;
            public global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeEnum> Field18;

            public Snapshot(global::System.Collections.Generic.Dictionary<string, bool> field1, global::System.Collections.Generic.Dictionary<string, float> field2, global::System.Collections.Generic.Dictionary<string, byte[]> field3, global::System.Collections.Generic.Dictionary<string, int> field4, global::System.Collections.Generic.Dictionary<string, long> field5, global::System.Collections.Generic.Dictionary<string, double> field6, global::System.Collections.Generic.Dictionary<string, string> field7, global::System.Collections.Generic.Dictionary<string, uint> field8, global::System.Collections.Generic.Dictionary<string, ulong> field9, global::System.Collections.Generic.Dictionary<string, int> field10, global::System.Collections.Generic.Dictionary<string, long> field11, global::System.Collections.Generic.Dictionary<string, uint> field12, global::System.Collections.Generic.Dictionary<string, ulong> field13, global::System.Collections.Generic.Dictionary<string, int> field14, global::System.Collections.Generic.Dictionary<string, long> field15, global::System.Collections.Generic.Dictionary<string, global::Improbable.Gdk.Core.EntityId> field16, global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeType> field17, global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeEnum> field18)
            {
                Field1 = field1;
                Field2 = field2;
                Field3 = field3;
                Field4 = field4;
                Field5 = field5;
                Field6 = field6;
                Field7 = field7;
                Field8 = field8;
                Field9 = field9;
                Field10 = field10;
                Field11 = field11;
                Field12 = field12;
                Field13 = field13;
                Field14 = field14;
                Field15 = field15;
                Field16 = field16;
                Field17 = field17;
                Field18 = field18;
            }
        }

        public static class Serialization
        {
            public static void SerializeComponent(global::Improbable.TestSchema.ExhaustiveMapValue.Component component, global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                foreach (var keyValuePair in component.Field1)
                {
                    var mapObj = obj.AddObject(1);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddBool(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field2)
                {
                    var mapObj = obj.AddObject(2);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddFloat(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field3)
                {
                    var mapObj = obj.AddObject(3);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddBytes(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field4)
                {
                    var mapObj = obj.AddObject(4);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddInt32(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field5)
                {
                    var mapObj = obj.AddObject(5);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddInt64(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field6)
                {
                    var mapObj = obj.AddObject(6);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddDouble(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field7)
                {
                    var mapObj = obj.AddObject(7);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddString(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field8)
                {
                    var mapObj = obj.AddObject(8);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddUint32(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field9)
                {
                    var mapObj = obj.AddObject(9);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddUint64(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field10)
                {
                    var mapObj = obj.AddObject(10);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddSint32(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field11)
                {
                    var mapObj = obj.AddObject(11);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddSint64(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field12)
                {
                    var mapObj = obj.AddObject(12);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddFixed32(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field13)
                {
                    var mapObj = obj.AddObject(13);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddFixed64(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field14)
                {
                    var mapObj = obj.AddObject(14);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddSfixed32(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field15)
                {
                    var mapObj = obj.AddObject(15);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddSfixed64(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field16)
                {
                    var mapObj = obj.AddObject(16);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddEntityId(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in component.Field17)
                {
                    var mapObj = obj.AddObject(17);
                    mapObj.AddString(1, keyValuePair.Key);
                    global::Improbable.TestSchema.SomeType.Serialization.Serialize(keyValuePair.Value, mapObj.AddObject(2));
                }

                foreach (var keyValuePair in component.Field18)
                {
                    var mapObj = obj.AddObject(18);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddEnum(2, (uint) keyValuePair.Value);
                }
            }

            public static void SerializeUpdate(global::Improbable.TestSchema.ExhaustiveMapValue.Component component, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                if (component.IsDataDirty(0))
                {
                    foreach (var keyValuePair in component.Field1)
                    {
                        var mapObj = obj.AddObject(1);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddBool(2, keyValuePair.Value);
                    }

                    if (component.Field1.Count == 0)
                    {
                        updateObj.AddClearedField(1);
                    }
                }

                if (component.IsDataDirty(1))
                {
                    foreach (var keyValuePair in component.Field2)
                    {
                        var mapObj = obj.AddObject(2);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddFloat(2, keyValuePair.Value);
                    }

                    if (component.Field2.Count == 0)
                    {
                        updateObj.AddClearedField(2);
                    }
                }

                if (component.IsDataDirty(2))
                {
                    foreach (var keyValuePair in component.Field3)
                    {
                        var mapObj = obj.AddObject(3);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddBytes(2, keyValuePair.Value);
                    }

                    if (component.Field3.Count == 0)
                    {
                        updateObj.AddClearedField(3);
                    }
                }

                if (component.IsDataDirty(3))
                {
                    foreach (var keyValuePair in component.Field4)
                    {
                        var mapObj = obj.AddObject(4);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddInt32(2, keyValuePair.Value);
                    }

                    if (component.Field4.Count == 0)
                    {
                        updateObj.AddClearedField(4);
                    }
                }

                if (component.IsDataDirty(4))
                {
                    foreach (var keyValuePair in component.Field5)
                    {
                        var mapObj = obj.AddObject(5);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddInt64(2, keyValuePair.Value);
                    }

                    if (component.Field5.Count == 0)
                    {
                        updateObj.AddClearedField(5);
                    }
                }

                if (component.IsDataDirty(5))
                {
                    foreach (var keyValuePair in component.Field6)
                    {
                        var mapObj = obj.AddObject(6);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddDouble(2, keyValuePair.Value);
                    }

                    if (component.Field6.Count == 0)
                    {
                        updateObj.AddClearedField(6);
                    }
                }

                if (component.IsDataDirty(6))
                {
                    foreach (var keyValuePair in component.Field7)
                    {
                        var mapObj = obj.AddObject(7);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddString(2, keyValuePair.Value);
                    }

                    if (component.Field7.Count == 0)
                    {
                        updateObj.AddClearedField(7);
                    }
                }

                if (component.IsDataDirty(7))
                {
                    foreach (var keyValuePair in component.Field8)
                    {
                        var mapObj = obj.AddObject(8);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddUint32(2, keyValuePair.Value);
                    }

                    if (component.Field8.Count == 0)
                    {
                        updateObj.AddClearedField(8);
                    }
                }

                if (component.IsDataDirty(8))
                {
                    foreach (var keyValuePair in component.Field9)
                    {
                        var mapObj = obj.AddObject(9);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddUint64(2, keyValuePair.Value);
                    }

                    if (component.Field9.Count == 0)
                    {
                        updateObj.AddClearedField(9);
                    }
                }

                if (component.IsDataDirty(9))
                {
                    foreach (var keyValuePair in component.Field10)
                    {
                        var mapObj = obj.AddObject(10);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddSint32(2, keyValuePair.Value);
                    }

                    if (component.Field10.Count == 0)
                    {
                        updateObj.AddClearedField(10);
                    }
                }

                if (component.IsDataDirty(10))
                {
                    foreach (var keyValuePair in component.Field11)
                    {
                        var mapObj = obj.AddObject(11);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddSint64(2, keyValuePair.Value);
                    }

                    if (component.Field11.Count == 0)
                    {
                        updateObj.AddClearedField(11);
                    }
                }

                if (component.IsDataDirty(11))
                {
                    foreach (var keyValuePair in component.Field12)
                    {
                        var mapObj = obj.AddObject(12);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddFixed32(2, keyValuePair.Value);
                    }

                    if (component.Field12.Count == 0)
                    {
                        updateObj.AddClearedField(12);
                    }
                }

                if (component.IsDataDirty(12))
                {
                    foreach (var keyValuePair in component.Field13)
                    {
                        var mapObj = obj.AddObject(13);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddFixed64(2, keyValuePair.Value);
                    }

                    if (component.Field13.Count == 0)
                    {
                        updateObj.AddClearedField(13);
                    }
                }

                if (component.IsDataDirty(13))
                {
                    foreach (var keyValuePair in component.Field14)
                    {
                        var mapObj = obj.AddObject(14);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddSfixed32(2, keyValuePair.Value);
                    }

                    if (component.Field14.Count == 0)
                    {
                        updateObj.AddClearedField(14);
                    }
                }

                if (component.IsDataDirty(14))
                {
                    foreach (var keyValuePair in component.Field15)
                    {
                        var mapObj = obj.AddObject(15);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddSfixed64(2, keyValuePair.Value);
                    }

                    if (component.Field15.Count == 0)
                    {
                        updateObj.AddClearedField(15);
                    }
                }

                if (component.IsDataDirty(15))
                {
                    foreach (var keyValuePair in component.Field16)
                    {
                        var mapObj = obj.AddObject(16);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddEntityId(2, keyValuePair.Value);
                    }

                    if (component.Field16.Count == 0)
                    {
                        updateObj.AddClearedField(16);
                    }
                }

                if (component.IsDataDirty(16))
                {
                    foreach (var keyValuePair in component.Field17)
                    {
                        var mapObj = obj.AddObject(17);
                        mapObj.AddString(1, keyValuePair.Key);
                        global::Improbable.TestSchema.SomeType.Serialization.Serialize(keyValuePair.Value, mapObj.AddObject(2));
                    }

                    if (component.Field17.Count == 0)
                    {
                        updateObj.AddClearedField(17);
                    }
                }

                if (component.IsDataDirty(17))
                {
                    foreach (var keyValuePair in component.Field18)
                    {
                        var mapObj = obj.AddObject(18);
                        mapObj.AddString(1, keyValuePair.Key);
                        mapObj.AddEnum(2, (uint) keyValuePair.Value);
                    }

                    if (component.Field18.Count == 0)
                    {
                        updateObj.AddClearedField(18);
                    }
                }
            }

            public static void SerializeUpdate(global::Improbable.TestSchema.ExhaustiveMapValue.Update update, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                {
                    if (update.Field1.HasValue)
                    {
                        var field = update.Field1.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(1);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddBool(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(1);
                        }
                    }
                }

                {
                    if (update.Field2.HasValue)
                    {
                        var field = update.Field2.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(2);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddFloat(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(2);
                        }
                    }
                }

                {
                    if (update.Field3.HasValue)
                    {
                        var field = update.Field3.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(3);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddBytes(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(3);
                        }
                    }
                }

                {
                    if (update.Field4.HasValue)
                    {
                        var field = update.Field4.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(4);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddInt32(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(4);
                        }
                    }
                }

                {
                    if (update.Field5.HasValue)
                    {
                        var field = update.Field5.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(5);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddInt64(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(5);
                        }
                    }
                }

                {
                    if (update.Field6.HasValue)
                    {
                        var field = update.Field6.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(6);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddDouble(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(6);
                        }
                    }
                }

                {
                    if (update.Field7.HasValue)
                    {
                        var field = update.Field7.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(7);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddString(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(7);
                        }
                    }
                }

                {
                    if (update.Field8.HasValue)
                    {
                        var field = update.Field8.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(8);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddUint32(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(8);
                        }
                    }
                }

                {
                    if (update.Field9.HasValue)
                    {
                        var field = update.Field9.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(9);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddUint64(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(9);
                        }
                    }
                }

                {
                    if (update.Field10.HasValue)
                    {
                        var field = update.Field10.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(10);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddSint32(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(10);
                        }
                    }
                }

                {
                    if (update.Field11.HasValue)
                    {
                        var field = update.Field11.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(11);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddSint64(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(11);
                        }
                    }
                }

                {
                    if (update.Field12.HasValue)
                    {
                        var field = update.Field12.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(12);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddFixed32(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(12);
                        }
                    }
                }

                {
                    if (update.Field13.HasValue)
                    {
                        var field = update.Field13.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(13);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddFixed64(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(13);
                        }
                    }
                }

                {
                    if (update.Field14.HasValue)
                    {
                        var field = update.Field14.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(14);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddSfixed32(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(14);
                        }
                    }
                }

                {
                    if (update.Field15.HasValue)
                    {
                        var field = update.Field15.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(15);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddSfixed64(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(15);
                        }
                    }
                }

                {
                    if (update.Field16.HasValue)
                    {
                        var field = update.Field16.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(16);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddEntityId(2, keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(16);
                        }
                    }
                }

                {
                    if (update.Field17.HasValue)
                    {
                        var field = update.Field17.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(17);
                            mapObj.AddString(1, keyValuePair.Key);
                            global::Improbable.TestSchema.SomeType.Serialization.Serialize(keyValuePair.Value, mapObj.AddObject(2));
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(17);
                        }
                    }
                }

                {
                    if (update.Field18.HasValue)
                    {
                        var field = update.Field18.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(18);
                            mapObj.AddString(1, keyValuePair.Key);
                            mapObj.AddEnum(2, (uint) keyValuePair.Value);
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(18);
                        }
                    }
                }
            }

            public static void SerializeSnapshot(global::Improbable.TestSchema.ExhaustiveMapValue.Snapshot snapshot, global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                foreach (var keyValuePair in snapshot.Field1)
                {
                    var mapObj = obj.AddObject(1);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddBool(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field2)
                {
                    var mapObj = obj.AddObject(2);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddFloat(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field3)
                {
                    var mapObj = obj.AddObject(3);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddBytes(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field4)
                {
                    var mapObj = obj.AddObject(4);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddInt32(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field5)
                {
                    var mapObj = obj.AddObject(5);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddInt64(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field6)
                {
                    var mapObj = obj.AddObject(6);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddDouble(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field7)
                {
                    var mapObj = obj.AddObject(7);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddString(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field8)
                {
                    var mapObj = obj.AddObject(8);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddUint32(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field9)
                {
                    var mapObj = obj.AddObject(9);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddUint64(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field10)
                {
                    var mapObj = obj.AddObject(10);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddSint32(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field11)
                {
                    var mapObj = obj.AddObject(11);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddSint64(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field12)
                {
                    var mapObj = obj.AddObject(12);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddFixed32(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field13)
                {
                    var mapObj = obj.AddObject(13);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddFixed64(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field14)
                {
                    var mapObj = obj.AddObject(14);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddSfixed32(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field15)
                {
                    var mapObj = obj.AddObject(15);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddSfixed64(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field16)
                {
                    var mapObj = obj.AddObject(16);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddEntityId(2, keyValuePair.Value);
                }

                foreach (var keyValuePair in snapshot.Field17)
                {
                    var mapObj = obj.AddObject(17);
                    mapObj.AddString(1, keyValuePair.Key);
                    global::Improbable.TestSchema.SomeType.Serialization.Serialize(keyValuePair.Value, mapObj.AddObject(2));
                }

                foreach (var keyValuePair in snapshot.Field18)
                {
                    var mapObj = obj.AddObject(18);
                    mapObj.AddString(1, keyValuePair.Key);
                    mapObj.AddEnum(2, (uint) keyValuePair.Value);
                }
            }

            public static global::Improbable.TestSchema.ExhaustiveMapValue.Component Deserialize(global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                var component = new global::Improbable.TestSchema.ExhaustiveMapValue.Component();

                component.field1Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field1Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, bool>();
                    var mapSize = obj.GetObjectCount(1);
                    component.Field1 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(1, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetBool(2);
                        map.Add(key, value);
                    }
                }

                component.field2Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field2Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, float>();
                    var mapSize = obj.GetObjectCount(2);
                    component.Field2 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(2, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFloat(2);
                        map.Add(key, value);
                    }
                }

                component.field3Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field3Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, byte[]>();
                    var mapSize = obj.GetObjectCount(3);
                    component.Field3 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(3, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetBytes(2);
                        map.Add(key, value);
                    }
                }

                component.field4Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field4Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, int>();
                    var mapSize = obj.GetObjectCount(4);
                    component.Field4 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(4, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetInt32(2);
                        map.Add(key, value);
                    }
                }

                component.field5Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field5Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, long>();
                    var mapSize = obj.GetObjectCount(5);
                    component.Field5 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(5, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetInt64(2);
                        map.Add(key, value);
                    }
                }

                component.field6Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field6Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, double>();
                    var mapSize = obj.GetObjectCount(6);
                    component.Field6 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(6, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetDouble(2);
                        map.Add(key, value);
                    }
                }

                component.field7Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field7Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, string>();
                    var mapSize = obj.GetObjectCount(7);
                    component.Field7 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(7, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetString(2);
                        map.Add(key, value);
                    }
                }

                component.field8Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field8Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, uint>();
                    var mapSize = obj.GetObjectCount(8);
                    component.Field8 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(8, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetUint32(2);
                        map.Add(key, value);
                    }
                }

                component.field9Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field9Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, ulong>();
                    var mapSize = obj.GetObjectCount(9);
                    component.Field9 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(9, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetUint64(2);
                        map.Add(key, value);
                    }
                }

                component.field10Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field10Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, int>();
                    var mapSize = obj.GetObjectCount(10);
                    component.Field10 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(10, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSint32(2);
                        map.Add(key, value);
                    }
                }

                component.field11Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field11Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, long>();
                    var mapSize = obj.GetObjectCount(11);
                    component.Field11 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(11, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSint64(2);
                        map.Add(key, value);
                    }
                }

                component.field12Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field12Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, uint>();
                    var mapSize = obj.GetObjectCount(12);
                    component.Field12 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(12, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFixed32(2);
                        map.Add(key, value);
                    }
                }

                component.field13Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field13Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, ulong>();
                    var mapSize = obj.GetObjectCount(13);
                    component.Field13 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(13, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFixed64(2);
                        map.Add(key, value);
                    }
                }

                component.field14Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field14Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, int>();
                    var mapSize = obj.GetObjectCount(14);
                    component.Field14 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(14, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSfixed32(2);
                        map.Add(key, value);
                    }
                }

                component.field15Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field15Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, long>();
                    var mapSize = obj.GetObjectCount(15);
                    component.Field15 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(15, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSfixed64(2);
                        map.Add(key, value);
                    }
                }

                component.field16Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field16Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, global::Improbable.Gdk.Core.EntityId>();
                    var mapSize = obj.GetObjectCount(16);
                    component.Field16 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(16, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetEntityIdStruct(2);
                        map.Add(key, value);
                    }
                }

                component.field17Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field17Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeType>();
                    var mapSize = obj.GetObjectCount(17);
                    component.Field17 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(17, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(mapObj.GetObject(2));
                        map.Add(key, value);
                    }
                }

                component.field18Handle = global::Improbable.TestSchema.ExhaustiveMapValue.ReferenceTypeProviders.Field18Provider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeEnum>();
                    var mapSize = obj.GetObjectCount(18);
                    component.Field18 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(18, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = (global::Improbable.TestSchema.SomeEnum) mapObj.GetEnum(2);
                        map.Add(key, value);
                    }
                }

                return component;
            }

            public static global::Improbable.TestSchema.ExhaustiveMapValue.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var update = new global::Improbable.TestSchema.ExhaustiveMapValue.Update();
                var obj = updateObj.GetFields();

                {
                    var mapSize = obj.GetObjectCount(1);

                    var isCleared = updateObj.IsFieldCleared(1);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field1 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, bool>>(new global::System.Collections.Generic.Dictionary<string, bool>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(1, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetBool(2);
                        update.Field1.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(2);

                    var isCleared = updateObj.IsFieldCleared(2);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field2 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, float>>(new global::System.Collections.Generic.Dictionary<string, float>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(2, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFloat(2);
                        update.Field2.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(3);

                    var isCleared = updateObj.IsFieldCleared(3);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field3 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, byte[]>>(new global::System.Collections.Generic.Dictionary<string, byte[]>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(3, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetBytes(2);
                        update.Field3.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(4);

                    var isCleared = updateObj.IsFieldCleared(4);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field4 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, int>>(new global::System.Collections.Generic.Dictionary<string, int>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(4, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetInt32(2);
                        update.Field4.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(5);

                    var isCleared = updateObj.IsFieldCleared(5);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field5 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, long>>(new global::System.Collections.Generic.Dictionary<string, long>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(5, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetInt64(2);
                        update.Field5.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(6);

                    var isCleared = updateObj.IsFieldCleared(6);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field6 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, double>>(new global::System.Collections.Generic.Dictionary<string, double>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(6, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetDouble(2);
                        update.Field6.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(7);

                    var isCleared = updateObj.IsFieldCleared(7);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field7 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, string>>(new global::System.Collections.Generic.Dictionary<string, string>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(7, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetString(2);
                        update.Field7.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(8);

                    var isCleared = updateObj.IsFieldCleared(8);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field8 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, uint>>(new global::System.Collections.Generic.Dictionary<string, uint>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(8, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetUint32(2);
                        update.Field8.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(9);

                    var isCleared = updateObj.IsFieldCleared(9);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field9 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, ulong>>(new global::System.Collections.Generic.Dictionary<string, ulong>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(9, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetUint64(2);
                        update.Field9.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(10);

                    var isCleared = updateObj.IsFieldCleared(10);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field10 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, int>>(new global::System.Collections.Generic.Dictionary<string, int>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(10, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSint32(2);
                        update.Field10.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(11);

                    var isCleared = updateObj.IsFieldCleared(11);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field11 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, long>>(new global::System.Collections.Generic.Dictionary<string, long>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(11, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSint64(2);
                        update.Field11.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(12);

                    var isCleared = updateObj.IsFieldCleared(12);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field12 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, uint>>(new global::System.Collections.Generic.Dictionary<string, uint>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(12, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFixed32(2);
                        update.Field12.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(13);

                    var isCleared = updateObj.IsFieldCleared(13);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field13 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, ulong>>(new global::System.Collections.Generic.Dictionary<string, ulong>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(13, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFixed64(2);
                        update.Field13.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(14);

                    var isCleared = updateObj.IsFieldCleared(14);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field14 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, int>>(new global::System.Collections.Generic.Dictionary<string, int>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(14, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSfixed32(2);
                        update.Field14.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(15);

                    var isCleared = updateObj.IsFieldCleared(15);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field15 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, long>>(new global::System.Collections.Generic.Dictionary<string, long>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(15, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSfixed64(2);
                        update.Field15.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(16);

                    var isCleared = updateObj.IsFieldCleared(16);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field16 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, global::Improbable.Gdk.Core.EntityId>>(new global::System.Collections.Generic.Dictionary<string, global::Improbable.Gdk.Core.EntityId>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(16, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetEntityIdStruct(2);
                        update.Field16.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(17);

                    var isCleared = updateObj.IsFieldCleared(17);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field17 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeType>>(new global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeType>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(17, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(mapObj.GetObject(2));
                        update.Field17.Value.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(18);

                    var isCleared = updateObj.IsFieldCleared(18);

                    if (mapSize > 0 || isCleared)
                    {
                        update.Field18 = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeEnum>>(new global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeEnum>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(18, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = (global::Improbable.TestSchema.SomeEnum) mapObj.GetEnum(2);
                        update.Field18.Value.Add(key, value);
                    }
                }

                return update;
            }

            public static global::Improbable.TestSchema.ExhaustiveMapValue.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentData data)
            {
                var update = new global::Improbable.TestSchema.ExhaustiveMapValue.Update();
                var obj = data.GetFields();

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, bool>();
                    var mapSize = obj.GetObjectCount(1);
                    update.Field1 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(1, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetBool(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, float>();
                    var mapSize = obj.GetObjectCount(2);
                    update.Field2 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(2, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFloat(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, byte[]>();
                    var mapSize = obj.GetObjectCount(3);
                    update.Field3 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(3, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetBytes(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, int>();
                    var mapSize = obj.GetObjectCount(4);
                    update.Field4 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(4, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetInt32(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, long>();
                    var mapSize = obj.GetObjectCount(5);
                    update.Field5 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(5, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetInt64(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, double>();
                    var mapSize = obj.GetObjectCount(6);
                    update.Field6 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(6, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetDouble(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, string>();
                    var mapSize = obj.GetObjectCount(7);
                    update.Field7 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(7, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetString(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, uint>();
                    var mapSize = obj.GetObjectCount(8);
                    update.Field8 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(8, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetUint32(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, ulong>();
                    var mapSize = obj.GetObjectCount(9);
                    update.Field9 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(9, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetUint64(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, int>();
                    var mapSize = obj.GetObjectCount(10);
                    update.Field10 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(10, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSint32(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, long>();
                    var mapSize = obj.GetObjectCount(11);
                    update.Field11 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(11, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSint64(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, uint>();
                    var mapSize = obj.GetObjectCount(12);
                    update.Field12 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(12, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFixed32(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, ulong>();
                    var mapSize = obj.GetObjectCount(13);
                    update.Field13 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(13, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFixed64(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, int>();
                    var mapSize = obj.GetObjectCount(14);
                    update.Field14 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(14, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSfixed32(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, long>();
                    var mapSize = obj.GetObjectCount(15);
                    update.Field15 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(15, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSfixed64(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, global::Improbable.Gdk.Core.EntityId>();
                    var mapSize = obj.GetObjectCount(16);
                    update.Field16 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(16, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetEntityIdStruct(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeType>();
                    var mapSize = obj.GetObjectCount(17);
                    update.Field17 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(17, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(mapObj.GetObject(2));
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeEnum>();
                    var mapSize = obj.GetObjectCount(18);
                    update.Field18 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(18, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = (global::Improbable.TestSchema.SomeEnum) mapObj.GetEnum(2);
                        map.Add(key, value);
                    }
                }

                return update;
            }

            public static global::Improbable.TestSchema.ExhaustiveMapValue.Snapshot DeserializeSnapshot(global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                var component = new global::Improbable.TestSchema.ExhaustiveMapValue.Snapshot();

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, bool>();
                    var mapSize = obj.GetObjectCount(1);
                    component.Field1 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(1, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetBool(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, float>();
                    var mapSize = obj.GetObjectCount(2);
                    component.Field2 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(2, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFloat(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, byte[]>();
                    var mapSize = obj.GetObjectCount(3);
                    component.Field3 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(3, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetBytes(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, int>();
                    var mapSize = obj.GetObjectCount(4);
                    component.Field4 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(4, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetInt32(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, long>();
                    var mapSize = obj.GetObjectCount(5);
                    component.Field5 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(5, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetInt64(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, double>();
                    var mapSize = obj.GetObjectCount(6);
                    component.Field6 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(6, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetDouble(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, string>();
                    var mapSize = obj.GetObjectCount(7);
                    component.Field7 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(7, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetString(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, uint>();
                    var mapSize = obj.GetObjectCount(8);
                    component.Field8 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(8, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetUint32(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, ulong>();
                    var mapSize = obj.GetObjectCount(9);
                    component.Field9 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(9, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetUint64(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, int>();
                    var mapSize = obj.GetObjectCount(10);
                    component.Field10 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(10, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSint32(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, long>();
                    var mapSize = obj.GetObjectCount(11);
                    component.Field11 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(11, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSint64(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, uint>();
                    var mapSize = obj.GetObjectCount(12);
                    component.Field12 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(12, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFixed32(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, ulong>();
                    var mapSize = obj.GetObjectCount(13);
                    component.Field13 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(13, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFixed64(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, int>();
                    var mapSize = obj.GetObjectCount(14);
                    component.Field14 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(14, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSfixed32(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, long>();
                    var mapSize = obj.GetObjectCount(15);
                    component.Field15 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(15, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSfixed64(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, global::Improbable.Gdk.Core.EntityId>();
                    var mapSize = obj.GetObjectCount(16);
                    component.Field16 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(16, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetEntityIdStruct(2);
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeType>();
                    var mapSize = obj.GetObjectCount(17);
                    component.Field17 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(17, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(mapObj.GetObject(2));
                        map.Add(key, value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeEnum>();
                    var mapSize = obj.GetObjectCount(18);
                    component.Field18 = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(18, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = (global::Improbable.TestSchema.SomeEnum) mapObj.GetEnum(2);
                        map.Add(key, value);
                    }
                }

                return component;
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.TestSchema.ExhaustiveMapValue.Component component)
            {
                var obj = updateObj.GetFields();

                {
                    var mapSize = obj.GetObjectCount(1);

                    var isCleared = updateObj.IsFieldCleared(1);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field1.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(1, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetBool(2);
                        component.Field1.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(2);

                    var isCleared = updateObj.IsFieldCleared(2);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field2.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(2, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFloat(2);
                        component.Field2.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(3);

                    var isCleared = updateObj.IsFieldCleared(3);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field3.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(3, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetBytes(2);
                        component.Field3.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(4);

                    var isCleared = updateObj.IsFieldCleared(4);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field4.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(4, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetInt32(2);
                        component.Field4.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(5);

                    var isCleared = updateObj.IsFieldCleared(5);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field5.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(5, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetInt64(2);
                        component.Field5.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(6);

                    var isCleared = updateObj.IsFieldCleared(6);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field6.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(6, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetDouble(2);
                        component.Field6.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(7);

                    var isCleared = updateObj.IsFieldCleared(7);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field7.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(7, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetString(2);
                        component.Field7.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(8);

                    var isCleared = updateObj.IsFieldCleared(8);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field8.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(8, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetUint32(2);
                        component.Field8.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(9);

                    var isCleared = updateObj.IsFieldCleared(9);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field9.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(9, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetUint64(2);
                        component.Field9.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(10);

                    var isCleared = updateObj.IsFieldCleared(10);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field10.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(10, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSint32(2);
                        component.Field10.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(11);

                    var isCleared = updateObj.IsFieldCleared(11);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field11.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(11, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSint64(2);
                        component.Field11.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(12);

                    var isCleared = updateObj.IsFieldCleared(12);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field12.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(12, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFixed32(2);
                        component.Field12.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(13);

                    var isCleared = updateObj.IsFieldCleared(13);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field13.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(13, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFixed64(2);
                        component.Field13.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(14);

                    var isCleared = updateObj.IsFieldCleared(14);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field14.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(14, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSfixed32(2);
                        component.Field14.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(15);

                    var isCleared = updateObj.IsFieldCleared(15);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field15.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(15, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSfixed64(2);
                        component.Field15.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(16);

                    var isCleared = updateObj.IsFieldCleared(16);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field16.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(16, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetEntityIdStruct(2);
                        component.Field16.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(17);

                    var isCleared = updateObj.IsFieldCleared(17);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field17.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(17, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(mapObj.GetObject(2));
                        component.Field17.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(18);

                    var isCleared = updateObj.IsFieldCleared(18);

                    if (mapSize > 0 || isCleared)
                    {
                        component.Field18.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(18, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = (global::Improbable.TestSchema.SomeEnum) mapObj.GetEnum(2);
                        component.Field18.Add(key, value);
                    }
                }
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.TestSchema.ExhaustiveMapValue.Snapshot snapshot)
            {
                var obj = updateObj.GetFields();

                {
                    var mapSize = obj.GetObjectCount(1);

                    var isCleared = updateObj.IsFieldCleared(1);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field1.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(1, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetBool(2);
                        snapshot.Field1.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(2);

                    var isCleared = updateObj.IsFieldCleared(2);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field2.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(2, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFloat(2);
                        snapshot.Field2.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(3);

                    var isCleared = updateObj.IsFieldCleared(3);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field3.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(3, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetBytes(2);
                        snapshot.Field3.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(4);

                    var isCleared = updateObj.IsFieldCleared(4);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field4.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(4, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetInt32(2);
                        snapshot.Field4.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(5);

                    var isCleared = updateObj.IsFieldCleared(5);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field5.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(5, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetInt64(2);
                        snapshot.Field5.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(6);

                    var isCleared = updateObj.IsFieldCleared(6);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field6.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(6, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetDouble(2);
                        snapshot.Field6.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(7);

                    var isCleared = updateObj.IsFieldCleared(7);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field7.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(7, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetString(2);
                        snapshot.Field7.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(8);

                    var isCleared = updateObj.IsFieldCleared(8);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field8.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(8, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetUint32(2);
                        snapshot.Field8.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(9);

                    var isCleared = updateObj.IsFieldCleared(9);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field9.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(9, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetUint64(2);
                        snapshot.Field9.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(10);

                    var isCleared = updateObj.IsFieldCleared(10);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field10.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(10, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSint32(2);
                        snapshot.Field10.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(11);

                    var isCleared = updateObj.IsFieldCleared(11);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field11.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(11, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSint64(2);
                        snapshot.Field11.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(12);

                    var isCleared = updateObj.IsFieldCleared(12);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field12.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(12, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFixed32(2);
                        snapshot.Field12.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(13);

                    var isCleared = updateObj.IsFieldCleared(13);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field13.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(13, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetFixed64(2);
                        snapshot.Field13.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(14);

                    var isCleared = updateObj.IsFieldCleared(14);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field14.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(14, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSfixed32(2);
                        snapshot.Field14.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(15);

                    var isCleared = updateObj.IsFieldCleared(15);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field15.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(15, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetSfixed64(2);
                        snapshot.Field15.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(16);

                    var isCleared = updateObj.IsFieldCleared(16);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field16.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(16, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = mapObj.GetEntityIdStruct(2);
                        snapshot.Field16.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(17);

                    var isCleared = updateObj.IsFieldCleared(17);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field17.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(17, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(mapObj.GetObject(2));
                        snapshot.Field17.Add(key, value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(18);

                    var isCleared = updateObj.IsFieldCleared(18);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.Field18.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(18, (uint) i);
                        var key = mapObj.GetString(1);
                        var value = (global::Improbable.TestSchema.SomeEnum) mapObj.GetEnum(2);
                        snapshot.Field18.Add(key, value);
                    }
                }
            }
        }

        public struct Update : ISpatialComponentUpdate
        {
            public Option<global::System.Collections.Generic.Dictionary<string, bool>> Field1;
            public Option<global::System.Collections.Generic.Dictionary<string, float>> Field2;
            public Option<global::System.Collections.Generic.Dictionary<string, byte[]>> Field3;
            public Option<global::System.Collections.Generic.Dictionary<string, int>> Field4;
            public Option<global::System.Collections.Generic.Dictionary<string, long>> Field5;
            public Option<global::System.Collections.Generic.Dictionary<string, double>> Field6;
            public Option<global::System.Collections.Generic.Dictionary<string, string>> Field7;
            public Option<global::System.Collections.Generic.Dictionary<string, uint>> Field8;
            public Option<global::System.Collections.Generic.Dictionary<string, ulong>> Field9;
            public Option<global::System.Collections.Generic.Dictionary<string, int>> Field10;
            public Option<global::System.Collections.Generic.Dictionary<string, long>> Field11;
            public Option<global::System.Collections.Generic.Dictionary<string, uint>> Field12;
            public Option<global::System.Collections.Generic.Dictionary<string, ulong>> Field13;
            public Option<global::System.Collections.Generic.Dictionary<string, int>> Field14;
            public Option<global::System.Collections.Generic.Dictionary<string, long>> Field15;
            public Option<global::System.Collections.Generic.Dictionary<string, global::Improbable.Gdk.Core.EntityId>> Field16;
            public Option<global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeType>> Field17;
            public Option<global::System.Collections.Generic.Dictionary<string, global::Improbable.TestSchema.SomeEnum>> Field18;
        }

        internal class ExhaustiveMapValueDynamic : IDynamicInvokable
        {
            public uint ComponentId => ExhaustiveMapValue.ComponentId;

            internal static Dynamic.VTable<Update, Snapshot> VTable = new Dynamic.VTable<Update, Snapshot>
            {
                DeserializeSnapshot = DeserializeSnapshot,
                SerializeSnapshot = SerializeSnapshot,
                DeserializeSnapshotRaw = Serialization.DeserializeSnapshot,
                SerializeSnapshotRaw = Serialization.SerializeSnapshot,
                ConvertSnapshotToUpdate = SnapshotToUpdate
            };

            private static Snapshot DeserializeSnapshot(ComponentData snapshot)
            {
                var schemaDataOpt = snapshot.SchemaData;
                if (!schemaDataOpt.HasValue)
                {
                    throw new ArgumentException($"Can not deserialize an empty {nameof(ComponentData)}");
                }

                return Serialization.DeserializeSnapshot(schemaDataOpt.Value.GetFields());
            }

            private static void SerializeSnapshot(Snapshot snapshot, ComponentData data)
            {
                var schemaDataOpt = data.SchemaData;
                if (!schemaDataOpt.HasValue)
                {
                    throw new ArgumentException($"Can not serialise an empty {nameof(ComponentData)}");
                }

                Serialization.SerializeSnapshot(snapshot, data.SchemaData.Value.GetFields());
            }

            private static Update SnapshotToUpdate(in Snapshot snapshot)
            {
                var update = new Update
                {
                    Field1 = snapshot.Field1,
                    Field2 = snapshot.Field2,
                    Field3 = snapshot.Field3,
                    Field4 = snapshot.Field4,
                    Field5 = snapshot.Field5,
                    Field6 = snapshot.Field6,
                    Field7 = snapshot.Field7,
                    Field8 = snapshot.Field8,
                    Field9 = snapshot.Field9,
                    Field10 = snapshot.Field10,
                    Field11 = snapshot.Field11,
                    Field12 = snapshot.Field12,
                    Field13 = snapshot.Field13,
                    Field14 = snapshot.Field14,
                    Field15 = snapshot.Field15,
                    Field16 = snapshot.Field16,
                    Field17 = snapshot.Field17,
                    Field18 = snapshot.Field18
                };

                return update;
            }

            public void InvokeHandler(Dynamic.IHandler handler)
            {
                handler.Accept<Update, Snapshot>(ComponentId, VTable);
            }
        }
    }
}
