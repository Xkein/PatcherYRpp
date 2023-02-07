using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 328)]
    public struct VoxelAnimClass : IOwnAbstractType<VoxelAnimTypeClass>
    {
        public static readonly IntPtr ArrayPointer = new IntPtr(0x8175E8);
        public static ref DynamicVectorClass<Pointer<VoxelAnimClass>> Array => ref DynamicVectorClass<Pointer<VoxelAnimClass>>.GetDynamicVector(ArrayPointer);

        Pointer<VoxelAnimTypeClass> IOwnAbstractType<VoxelAnimTypeClass>.OwnType => Type;
        Pointer<AbstractTypeClass> IOwnAbstractType.AbstractType => Type.Convert<AbstractTypeClass>();

        public static unsafe void Constructor(Pointer<VoxelAnimClass> pThis, Pointer<VoxelAnimTypeClass> pAnimType, CoordStruct Location, Pointer<HouseClass> pHouse)
        {
            var func = (delegate* unmanaged[Thiscall]<ref VoxelAnimClass, IntPtr, ref CoordStruct, IntPtr, void>)0x7493B0;
            func(ref pThis.Ref, pAnimType, ref Location, pHouse);
        }

        [FieldOffset(0)] public ObjectClass Base;

        [FieldOffset(260)] public Pointer<VoxelAnimTypeClass> Type;
    }
}
