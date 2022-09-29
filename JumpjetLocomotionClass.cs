using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DynamicPatcher;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 152)]
    public struct JumpjetLocomotionClass
    {
        [FieldOffset(28)] public double TurnRate;
        [FieldOffset(32)] public int Speed;
        [FieldOffset(36)] public float Climb;
        [FieldOffset(40)] public float Crash;
        [FieldOffset(44)] public int Height;
        [FieldOffset(48)] public float Accel;
        [FieldOffset(52)] public float Wobbles;
        [FieldOffset(56)] public int Deviation;
        [FieldOffset(60)] public Bool NoWobbles;
        [FieldOffset(64)] public CoordStruct HeadToCoord;
        [FieldOffset(76)] public Bool IsMoving;
        [FieldOffset(84)] public FacingStruct LocomotionFacing;

        [FieldOffset(144)] public Bool occupy90__DestinationReached; // 抵达目的地
    }
}
