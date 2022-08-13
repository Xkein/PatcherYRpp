﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{

    [StructLayout(LayoutKind.Sequential)]
    public struct DynamicVectorClass<T> : IEnumerable<T>
    {
        static public ref DynamicVectorClass<T> GetDynamicVector(IntPtr ptr)
        {
            return ref Helpers.GetUnmanagedRef<DynamicVectorClass<T>>(ptr);
        }

        public ref T this[int index] { get => ref Get(index); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T Get(int index) => ref Helpers.GetUnmanagedRef<T>(Items, index);

        public Span<T> GetSpan()
        {
            return Helpers.GetSpan<T>(Items, Count);
        }

        //偷懒是不是
        public unsafe bool OperatorEqual(Pointer<DynamicVectorClass<T>> pOther)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, IntPtr, Bool>)this.GetVirtualFunctionPointer(1);
            return func(this.GetThisPointer(), pOther);
        }

        public unsafe bool SetCapacity(int capacity, Pointer<T> pMem = default)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, int, IntPtr, Bool>)this.GetVirtualFunctionPointer(2);
            return func(this.GetThisPointer(), capacity, pMem);
        }
        public unsafe void Clear()
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, void>)this.GetVirtualFunctionPointer(3);
            func(this.GetThisPointer());
        }
        public unsafe int FindItemIndex(Pointer<T> pItem)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, IntPtr, int>)this.GetVirtualFunctionPointer(4);
            return func(this.GetThisPointer(), pItem);
        }
        public unsafe int GetItemIndex(Pointer<T> pItem)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, IntPtr, int>)this.GetVirtualFunctionPointer(5);
            return func(this.GetThisPointer(), pItem);
        }

        public bool AddItem(T item)
        {
            if (Count >= Capacity)
            {
                if (!IsAllocated && Capacity != 0)
                    return false;

                if (CapacityIncrement <= 0)
                    return false;

                if (!SetCapacity(Capacity + CapacityIncrement))
                    return false;
            }

            this[Count++] = item;
            return true;
        }
        public bool AddUnique(Pointer<T> pItem)
        {
            int idx = FindItemIndex(pItem);
            return idx < 0 && AddItem(pItem.Ref);
        }

        class Enumerator : IEnumerator<T>, IEnumerator
		{
			internal Enumerator(Pointer<T> items, int count)
			{
				this.items = items;
				this.count = count;
                Reset();
			}

			public void Dispose() { }

			public bool MoveNext()
			{
				if (index < count)
				{
					current = items[index];
					index++;
					return true;
				}
				return false;
			}

			public T Current => current;

			object IEnumerator.Current => Current;

			public void Reset()
			{
				index = 0;
				current = default(T);
			}

			private Pointer<T> items;
			private int count;
			private int index;
			private T current;
		}

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(Items, Count);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private IntPtr Vfptr;
        public IntPtr Items;
        public int Capacity;
        public Bool IsInitialized;
        public Bool IsAllocated;
        public int Count;
        public int CapacityIncrement;
    }


    [StructLayout(LayoutKind.Explicit,Size =20)]
    public struct CounterClass 
    {
        [FieldOffset(0)] private IntPtr Vfptr;
        [FieldOffset(4)] private IntPtr Items;
        [FieldOffset(8)] private int capacity;
        [FieldOffset(12)] private Bool isInitialized;
        [FieldOffset(13)] private Bool isAllocated;
        [FieldOffset(16)] private int total;
        public ref int this[int index] { get => ref Get(index); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref int Get(int index) => ref Helpers.GetUnmanagedRef<int>(Items, index);
        public int GetItemCount(int index)
        {
            return index < capacity ? this[index] : 0;
        }   
    }
}
