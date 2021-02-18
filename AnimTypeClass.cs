using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 888)]
    public struct AnimTypeClass
    {
        [FieldOffset(0)] public ObjectTypeClass Base;

    }
}
