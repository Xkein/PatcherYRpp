using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 3600)]
    public struct AircraftTypeClass
    {

        [FieldOffset(0)] public TechnoTypeClass Base;

    }
}
