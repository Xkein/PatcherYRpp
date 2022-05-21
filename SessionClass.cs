using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 12508)]
    public struct SessionClass
    {
        private static IntPtr instance = new IntPtr(0xA8B238);
        static public ref SessionClass Instance => ref instance.Convert<SessionClass>().Ref;

        [FieldOffset(0)] public GameMode GameMode;
        [FieldOffset(4)] public Pointer<MPGameModeClass> MPGameMode;
    }
}
