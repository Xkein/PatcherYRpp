using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 172)]
    public struct ObjectClass
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate IntPtr ThisCall_0(ref ObjectClass pThis);
        public int GetHeight()
        {
            ThisCall_0 function = Helpers.GetVirtualFunction<ThisCall_0>(Pointer<ObjectClass>.AsPointer(ref this), 114);
            return (int)function(ref this);
        }

        [FieldOffset(0)]
        public AbstractClass Base;

        [FieldOffset(156)]
        public CoordStruct Location; //Absolute current 3D location (in leptons)
    }
}
