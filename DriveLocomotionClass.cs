using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DynamicPatcher;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 112)]
    public struct DriveLocomotionClass
    {
        [FieldOffset(28)] public double Ramp1;
        [FieldOffset(32)] public double Ramp2;
        [FieldOffset(52)] public CoordStruct Destination; // 0x34 DriveLocomotionClass
        [FieldOffset(64)] public CoordStruct HeadToCoord; // 0x40 DriveLocomotionClass
        [FieldOffset(76)] public int Speed;
        [FieldOffset(80)] public double MovementSpeed;
        [FieldOffset(88)] public int TrackNumber;
        [FieldOffset(92)] public int TrackIndex;
        [FieldOffset(96)] public Bool IsOnShortTrack;
        [FieldOffset(97)] public Bool IsTurretLockedDown;
        [FieldOffset(98)] public Bool IsRotating; // 0x62 DriveLocomotionClass
        [FieldOffset(99)] public Bool IsDriving; // 0x63 DriveLocomotionClass
        [FieldOffset(101)] public Bool IsLocked; // 0x65 DriveLocomotionClass
    }
}
