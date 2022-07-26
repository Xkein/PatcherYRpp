using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DynamicPatcher;

namespace PatcherYRpp
{

    [StructLayout(LayoutKind.Explicit, Size = 0x4C)]
    public struct MessageListClass
    {
        private static IntPtr instance = new IntPtr(0xA8BC60);
        public static ref MessageListClass Instance => ref instance.Convert<MessageListClass>().Ref;

        private unsafe void PrintMessage(UniStringPointer label, UInt32 dwunk1, UniStringPointer message, 
            ColorSchemeIndex colorSchemeIndex = ColorSchemeIndex.Yellow, UInt32 dwunk2 = 0x4046, int duration = 0x96, bool silent = false)
        {
            var func = (delegate* unmanaged[Thiscall]<ref MessageListClass, IntPtr, UInt32, IntPtr, ColorSchemeIndex, uint, int, Bool, void>)0x5D3BA0;
            func(ref this, label, dwunk1, message, colorSchemeIndex, dwunk2, duration, silent);
        }

        public unsafe void PrintMessage(UniString message, ColorSchemeIndex colorSchemeIndex = ColorSchemeIndex.White, int duration = 0x96, bool silent = false)
        {
            PrintMessage(IntPtr.Zero, 0, message, colorSchemeIndex, 0x4046, duration, silent);
        }


        public static unsafe Pointer<MessageListClass> SilentMessageForPlayer(UniString message, int duration = 0x96)
        {
            var func = (delegate* unmanaged[Thiscall]<int, IntPtr, int, IntPtr>)ASM.FastCallTransferStation;
            return func(0x730A90, message, duration);
        }
    }
}
