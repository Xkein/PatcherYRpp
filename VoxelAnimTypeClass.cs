using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 776)]
    public struct VoxelAnimTypeClass
    {
        public static readonly IntPtr ArrayPointer = new IntPtr(0xA8EB28);

        public static YRPP.GLOBAL_DVC_ARRAY<VoxelAnimTypeClass> ABSTRACTTYPE_ARRAY = new YRPP.GLOBAL_DVC_ARRAY<VoxelAnimTypeClass>(ArrayPointer);

        [FieldOffset(0)] public ObjectTypeClass Base;

    }
}
