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
        public unsafe int GetHeight()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, int>)Helpers.GetVirtualFunctionPointer(Pointer<ObjectClass>.AsPointer(ref this), 114);
            return func(ref this);
        }

        [FieldOffset(0)]
        public AbstractClass Base;

        [FieldOffset(156)]
        public CoordStruct Location; //Absolute current 3D location (in leptons)
    }
}
