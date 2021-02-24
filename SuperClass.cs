using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 128)]
    public struct SuperClass
    {
        public unsafe void Launch(CellStruct cell, bool isPlayer)
        {
            var func = (delegate* unmanaged[Thiscall]<ref SuperClass, ref CellStruct, bool, void>)0x6CC390;
            func(ref this, ref cell, isPlayer);
        }

        public unsafe bool CanFire()
        {
            var func = (delegate* unmanaged[Thiscall]<ref SuperClass, bool>)0x6CC360;
            return func(ref this);
        }

        [FieldOffset(0)] public AbstractClass Base;

        [FieldOffset(36)] public int CustomChargeTime;
        [FieldOffset(40)] public Pointer<SuperWeaponTypeClass> Type;
        [FieldOffset(44)] public IntPtr owner;
        public Pointer<HouseClass> Owner { get => owner; set => owner = value; }
        [FieldOffset(48)] public TimerStruct RechargeTimer;

        [FieldOffset(64)] public byte BlinkState;

        [FieldOffset(72)] public long BlinkTimer;
        [FieldOffset(80)] public int SpecialSoundDuration; // see 0x6CD14F
        [FieldOffset(84)] public CoordStruct SpecialSoundLocation;
        [FieldOffset(96)] public byte CanHold;          // 0x60

        [FieldOffset(98)] public CellStruct ChronoMapCoords;  // 0x62

        [FieldOffset(104)] public Pointer<AnimClass> Animation;                // 0x68
        [FieldOffset(108)] public byte AnimationGotInvalid;
        [FieldOffset(109)] public byte Granted;
        [FieldOffset(110)] public byte OneTime; // remove this SW when it has been fired once
        [FieldOffset(111)] public byte IsCharged;
        [FieldOffset(112)] public byte IsOnHold;

        [FieldOffset(116)] public int ReadinessFrame; // when did it become ready?
        [FieldOffset(120)] public int CameoChargeState;
        [FieldOffset(124)] public ChargeDrainState ChargeDrainState;
    }
}
