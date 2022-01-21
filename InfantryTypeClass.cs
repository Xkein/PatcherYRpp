using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 3792)]
    public struct InfantryTypeClass
    {


        [FieldOffset(0)] public TechnoTypeClass Base;

    }
}
