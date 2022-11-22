using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct CommandClass
    {
        public static readonly IntPtr ArrayPointer = new IntPtr(0x87F658);

        public static YRPP.GLOBAL_DVC_ARRAY<CommandClass> ABSTRACTTYPE_ARRAY = new YRPP.GLOBAL_DVC_ARRAY<CommandClass>(ArrayPointer);

    }
}
