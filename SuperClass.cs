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
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void LaunchDelegate(ref SuperClass pThis, ref CellStruct cell, bool isPlayer);
        static public LaunchDelegate LaunchDlg = Marshal.GetDelegateForFunctionPointer<LaunchDelegate>(new IntPtr(0x6CC390));
        public void Launch(CellStruct cell, bool isPlayer)
        {
            LaunchDlg(ref this, ref cell, isPlayer);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool CanFireDelegate(ref SuperClass pThis);
        static public CanFireDelegate CanFireDlg = Marshal.GetDelegateForFunctionPointer<CanFireDelegate>(new IntPtr(0x6CC360));
        public bool CanFire()
        {
            return CanFireDlg(ref this);
        }

        [FieldOffset(0)] public AbstractClass Base;

        [FieldOffset(36)] public int CustomChargeTime;
        [FieldOffset(40)] public Pointer<SuperWeaponTypeClass> Type;
        [FieldOffset(44)] public Pointer<HouseClass> Owner;
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
