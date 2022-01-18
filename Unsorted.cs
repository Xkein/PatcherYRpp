using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    public static class Game
    {
        public static int CurrentFrame { get => pCurrentFrame.Convert<int>().Data; set => pCurrentFrame.Convert<int>().Ref = value; }
        private static IntPtr pCurrentFrame = new IntPtr(0xA8ED84);

        // The height in the middle of a cell with a slope of 30 degrees
        public const int LevelHeight = 104;//89DE70
        public const int BridgeHeight = LevelHeight * 4;//ABC5DC

        public static unsafe bool HasDirtyArea()
        {
            var func = (delegate* unmanaged[Stdcall]<Bool>)0x53BAE0;
            return func();
        }
    }
}
