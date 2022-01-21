using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public struct LocomotionClass
    {


        [FieldOffset(0)] public int Vfptr_IPersistStream;
        [FieldOffset(4)] public int Vfptr_ILocomotion;
        public ILocomotion ILocomotion => Marshal.GetObjectForIUnknown(Pointer<int>.AsPointer(ref Vfptr_ILocomotion)) as ILocomotion;
        [FieldOffset(8)] public Pointer<FootClass> Owner;
        [FieldOffset(12)] public Pointer<FootClass> LinkedTo;
        [FieldOffset(16)] public Bool Powered;
        [FieldOffset(17)] public Bool Dirty;
        [FieldOffset(20)] public int RefCount;
    }
}
