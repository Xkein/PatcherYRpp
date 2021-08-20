using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 36)]
    public struct AbstractClass
    {
        public unsafe AbstractType WhatAmI()
        {
            var func = (delegate* unmanaged[Thiscall]<ref AbstractClass, AbstractType>)this.GetVirtualFunctionPointer(11);
            return func(ref this);
        }

        public unsafe int GetArrayIndex()
        {
            var func = (delegate* unmanaged[Thiscall]<ref AbstractClass, int>)this.GetVirtualFunctionPointer(16);
            return func(ref this);
        }

        public unsafe CoordStruct GetCoords()
        {
            var func = (delegate* unmanaged[Thiscall]<ref AbstractClass, IntPtr, IntPtr>)this.GetVirtualFunctionPointer(18);

            CoordStruct ret = default;
            func(ref this, Pointer<CoordStruct>.AsPointer(ref ret));
            return ret;
        }

        [FieldOffset(0)]
        public int Vfptr;
    }
}
