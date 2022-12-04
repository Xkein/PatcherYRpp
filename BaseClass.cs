using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PatcherYRpp.FileFormats;
using DynamicPatcher;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 120)]
    public struct BaseClass
    {
        [FieldOffset(4)] public byte baseNodes;
        public ref DynamicVectorClass<BaseNodeClass> BaseNodes => ref Pointer<byte>.AsPointer(ref baseNodes).Convert<DynamicVectorClass<BaseNodeClass>>().Ref;

        [FieldOffset(28)] public int PercentBuilt;

        [FieldOffset(32)] public byte cells_24;
        public ref DynamicVectorClass<CellStruct> Cells_24 => ref Pointer<byte>.AsPointer(ref cells_24).Convert<DynamicVectorClass<CellStruct>>().Ref;

        [FieldOffset(56)] public byte cells_38;
        public ref DynamicVectorClass<CellStruct> Cells_38 => ref Pointer<byte>.AsPointer(ref cells_38).Convert<DynamicVectorClass<CellStruct>>().Ref;

        [FieldOffset(80)] public CellStruct Center;

        [FieldOffset(116)] public IntPtr owner;
        public Pointer<HouseClass> Owner => owner;

    }
}
