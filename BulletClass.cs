using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BulletData
    {
        public TimerStruct UnknownTimer;
        public TimerStruct ArmTimer;
        public CoordStruct Location;
        public int Distance;
    };

    [StructLayout(LayoutKind.Explicit, Size = 352)]
    public struct BulletClass
    {
        static public readonly IntPtr ArrayPointer = new IntPtr(0xA8ED40);
        static public ref DynamicVectorClass<Pointer<BulletClass>> Array { get => ref DynamicVectorClass<Pointer<BulletClass>>.GetDynamicVector(ArrayPointer); }

        [FieldOffset(0)]
        public ObjectClass Base;

        [FieldOffset(172)]
        public Pointer<BulletTypeClass> Type;
        [FieldOffset(176)]
        public Pointer<TechnoClass> Owner;

        [FieldOffset(184)]
        public BulletData Data;
        [FieldOffset(224)]
        public byte Bright;

        [FieldOffset(232)]
        public BulletVelocity Velocity;

        [FieldOffset(268)]
        Pointer<AbstractClass> Target;
        [FieldOffset(272)]
        public int Speed;

        [FieldOffset(296)]
        public Pointer<WarheadTypeClass> WH;

        [FieldOffset(308)]
        public CoordStruct SourceCoords;
        [FieldOffset(320)]
        public CoordStruct TargetCoords;
        [FieldOffset(332)]
        public CellStruct LastMapCoords;
        [FieldOffset(336)]
        public int DamageMultiplier;
    }
}
