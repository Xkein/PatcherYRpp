using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 108)]
    public struct CCFileClass
    {
        public static unsafe void Constructor(Pointer<CCFileClass> pThis, string fileName)
        {
            var func = (delegate* unmanaged[Thiscall]<ref CCFileClass, IntPtr, void>)0x4739F0;
            IntPtr hGlobal = Marshal.StringToHGlobalAnsi(fileName);
            func(ref pThis.Ref, hGlobal);
            //Marshal.FreeHGlobal(hGlobal);
        }

        public static unsafe void Destructor(Pointer<CCFileClass> pThis)
        {
            var func = (delegate* unmanaged[Thiscall]<ref CCFileClass, void>)Helpers.GetVirtualFunctionPointer(pThis, 0);
            func(ref pThis.Ref);
        }
    }
}
