using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 392)]
    public struct ConvertClass
    {
        [FieldOffset(0)] public int Vfptr;

        [FieldOffset(4)] public int LeanAndMean;
        [FieldOffset(8)] public int Blitters;
        [FieldOffset(364)] public int Count;
        [FieldOffset(368)] public Pointer<byte> BufferA;
        [FieldOffset(372)] public Pointer<byte> Midpoint;
        [FieldOffset(376)] public Pointer<byte> BufferB;
        [FieldOffset(380)] public int f_17C;
        [FieldOffset(384)] public int f_180;
        [FieldOffset(388)] public int f_184;
    }
}
