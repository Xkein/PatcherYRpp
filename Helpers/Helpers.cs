using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using DynamicPatcher;
using System.Runtime.Caching;
using System.Runtime.ConstrainedExecution;

namespace PatcherYRpp
{
    public static class Helpers
    {

        static public unsafe ref T GetUnmanagedRef<T>(IntPtr ptr, int offset = 0)
        {
            return ref ptr.Convert<T>()[offset];
        }

        static public unsafe Span<T> GetSpan<T>(IntPtr ptr, int length)
        {
            return new Span<T>(ptr.ToPointer(), length);
        }

        public static TTo ForceConvert<TFrom, TTo>(TFrom obj)
        {
            return Unsafe.As<TFrom, TTo>(ref obj);
            //    var ptr = new Pointer<TTo>(Pointer<TFrom>.AsPointer(ref obj));
            //    return ptr.Ref;
        }

        static MemoryCache VirtualFunctionCache = new MemoryCache("virtual functions");
        static public T GetVirtualFunction<T>(IntPtr pThis, int index) where T : Delegate
        {
            IntPtr address = GetVirtualFunctionPointer(pThis, index);

            string key = address.ToString();

            var ret = VirtualFunctionCache.Get(key);
            if (ret == null)
            {
                var policy = new CacheItemPolicy
                {
                    SlidingExpiration = TimeSpan.FromSeconds(60.0)
                };
                VirtualFunctionCache.Set(key, Marshal.GetDelegateForFunctionPointer<T>(address), policy);
                ret = VirtualFunctionCache.Get(key);
            }

            return ret as T;
        }

        static public IntPtr GetVirtualFunctionPointer(IntPtr pThis, int index)
        {
            Pointer<Pointer<IntPtr>> pVfptr = pThis;
            Pointer<IntPtr> vfptr = pVfptr.Data;
            IntPtr address = vfptr[index];

            return address;
        }

        public static Pointer<T> Convert<T>(this IntPtr ptr)
        {
            return new Pointer<T>(ptr);
        }

        private static MemoryHandle fastCallHandle;
        public static IntPtr FastCallTransferStation
        {
            get
            {
                if (fastCallHandle == null)
                {
                    byte[] this2fastcall = {
                        0x8B, 0x54, 0xE4, 0x08, //MOV EDX, [ESP + 8]
                        0x58, // POP EAX
                        0x89, 0x44, 0xE4, 0x04, // MOV [ESP + 4], EAX
                        0x89, 0xC8, // MOV EAX, ECX
                        0x59, // POP ECX
                        0xFF, 0xE0 // JMP EAX
                     };
                    fastCallHandle = new MemoryHandle(this2fastcall.Length);
                    MemoryHelper.Write(fastCallHandle.Memory, this2fastcall, this2fastcall.Length);
                }

                return (IntPtr)fastCallHandle.Memory;
            }
        }
    }
}
