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

        // 123 virtual function
        public void SetTarget(Pointer<AbstractClass> pTarget)
        {
            this.Target = pTarget;
        }

        public unsafe bool MoveTo(CoordStruct where, BulletVelocity velocity)
        {
            var func = (delegate* unmanaged[Thiscall]<ref BulletClass, ref CoordStruct, ref BulletVelocity, Bool>)
                Helpers.GetVirtualFunctionPointer(Pointer<BulletClass>.AsPointer(ref this), 124);
            return func(ref this, ref where, ref velocity);
        }

        public unsafe void Fire(bool destroy = false)
        {
            var func = (delegate* unmanaged[Thiscall]<ref BulletClass, Bool, void>)0x468D80;
            func(ref this, destroy);
        }

        public unsafe void Detonate(CoordStruct coords)
        {
            var func = (delegate* unmanaged[Thiscall]<ref BulletClass, ref CoordStruct, void>)0x4690B0;
            func(ref this, ref coords);
        }

        public unsafe void LoseTarget()
        {
            var func = (delegate* unmanaged[Thiscall]<ref BulletClass, void>)0x468430;
            func(ref this);
        }

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
        public Pointer<AbstractClass> Target;
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
