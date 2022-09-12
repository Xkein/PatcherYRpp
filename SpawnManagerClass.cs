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
    [StructLayout(LayoutKind.Explicit, Size = 116)]
    public struct SpawnManagerClass
    {

        public unsafe void SetTarget(Pointer<AbstractClass> target)
        {
            var func = (delegate* unmanaged[Thiscall]<ref SpawnManagerClass, IntPtr, void>)0x6B7B90;
            func(ref this, target);
        }


        [FieldOffset(36)] public IntPtr owner;
        public Pointer<TechnoClass> Owner { get => owner; set => owner = value; }

        [FieldOffset(44)] public int SpawnCount;
        [FieldOffset(48)] public int RegenRate;
        [FieldOffset(52)] public int ReloadRate;
      
        [FieldOffset(104)] public IntPtr destination;
        public Pointer<AbstractClass> Destination { get => destination; set => destination = value; }
        [FieldOffset(108)] public IntPtr target;
        public Pointer<AbstractClass> Target { get => target; set => target = value; }

    }
}
