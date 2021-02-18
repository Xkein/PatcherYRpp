using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 760)]
    public struct BulletTypeClass
    {
        [FieldOffset(0)]
        public ObjectTypeClass Base;
    }
}
