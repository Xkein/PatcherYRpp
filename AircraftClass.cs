using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 1752)]
    public struct AircraftClass
    {
        [FieldOffset(0)]
        public FootClass Base;

    }
}
