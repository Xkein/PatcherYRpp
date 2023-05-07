using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 96)]
    public struct FlyLocomotionClass
    {

        [FieldOffset(0)] public LocomotionClass Base;

        [FieldOffset(24)] public Bool AirportBound;
        [FieldOffset(28)] public CoordStruct Destination;
        [FieldOffset(40)] public CoordStruct HeadToCoord; // 飞行器不需要占领格子，所以一直为空
        [FieldOffset(52)] public Bool IsMoving;
        [FieldOffset(56)] public int FlightLevel; // 飞行高度，会强制重置为设定值
        [FieldOffset(64)] public double TargetSpeed;
        [FieldOffset(72)] public double CurrentSpeed;
        [FieldOffset(80)] public Bool IsTakingOff; // 起飞的一瞬间
        [FieldOffset(81)] public Bool IsLanding; // 正在降落
        [FieldOffset(82)] public Bool WasLanding;
        [FieldOffset(83)] public Bool unknown_bool_53; // rotation_byte_53
        [FieldOffset(84)] public double unknown_54; // rotation_drword_54
        [FieldOffset(88)] public double unknown_58; // strength_drword_58
        [FieldOffset(92)] public Bool IsElevating; // land_shadow_bool 带蛋前往攻击目标，回程时为False
        [FieldOffset(93)] public Bool unknown_bool_5D;
        [FieldOffset(94)] public Bool unknown_bool_5E;
        [FieldOffset(95)] public Bool unknown_bool_5F;
    }
}
