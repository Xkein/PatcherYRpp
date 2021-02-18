using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 660)]
    public struct ObjectTypeClass
    {
        [FieldOffset(0)]
        public AbstractTypeClass Base;
    }
}
