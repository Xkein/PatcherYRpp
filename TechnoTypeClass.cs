using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 3576)]
    public struct TechnoTypeClass
    {
        static public readonly IntPtr ArrayPointer = new IntPtr(0xA8EB00);

        static public YRPP.ABSTRACTTYPE_ARRAY<TechnoTypeClass> ABSTRACTTYPE_ARRAY = new YRPP.ABSTRACTTYPE_ARRAY<TechnoTypeClass>(ArrayPointer);

        [FieldOffset(0)]
        public ObjectTypeClass Base;
    }
}
