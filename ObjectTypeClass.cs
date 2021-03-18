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
        public unsafe bool SpawnAtMapCoords(CellStruct mapCoords, Pointer<HouseClass> pOwner)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectTypeClass, ref CellStruct, IntPtr, bool>)
                Helpers.GetVirtualFunctionPointer(Pointer<ObjectTypeClass>.AsPointer(ref this), 32);
            return func(ref this, ref mapCoords, pOwner);
        }
        public unsafe Pointer<ObjectClass> CreateObject(Pointer<HouseClass> pOwner)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectTypeClass, IntPtr, IntPtr>)
                Helpers.GetVirtualFunctionPointer(Pointer<ObjectTypeClass>.AsPointer(ref this), 35);
            return func(ref this, pOwner);
        }

        [FieldOffset(0)]
        public AbstractTypeClass Base;
    }
}
