using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 456)]
    public struct AnimClass
    {
        [FieldOffset(0)]
        public ObjectClass Base;

        [FieldOffset(200)]
        public Pointer<AnimTypeClass> Type;
        [FieldOffset(204)]
        public Pointer<ObjectClass> OwnerObject;
    }
}
