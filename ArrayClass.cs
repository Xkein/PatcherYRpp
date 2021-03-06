﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{

    [StructLayout(LayoutKind.Sequential)]
    public struct DynamicVectorClass<T>
    {
        static public ref DynamicVectorClass<T> GetDynamicVector(IntPtr ptr)
        {
            return ref Helpers.GetUnmanagedRef<DynamicVectorClass<T>>(ptr);
        }

        public ref T this[int index] { get => ref Get(index); }
        public ref T Get(int index) => ref Helpers.GetUnmanagedRef<T>(Items, index);

        public Span<T> GetSpan()
        {
            return Helpers.GetSpan<T>(Items, Count);
        }

        private IntPtr Vfptr;
        public IntPtr Items;
        public int Capacity;
        public Bool IsInitialized;
        public Bool IsAllocated;
        public int Count;
        public int CapacityIncrement;
    }
}
