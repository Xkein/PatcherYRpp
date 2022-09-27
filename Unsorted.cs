using DynamicPatcher;
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
        public static IntPtr pCurrentFrame = new IntPtr(0xA8ED84); // you should not change it

        // The height in the middle of a cell with a slope of 30 degrees
        public const int LevelHeight = 104;//89DE70
        public const int BridgeLevels = 4;
        public const int BridgeHeight = LevelHeight * BridgeLevels;//ABC5DC

        public const int CellSize = 256;

        public static int IKnowWhatImDoing { get => iKnowWhatImDoing.Convert<int>().Data; set => iKnowWhatImDoing.Convert<int>().Ref = value; }
        private static IntPtr iKnowWhatImDoing = new IntPtr(0xA8E7AC); // you should not change it

        public static int CurrentSWType { get => currentSWType.Convert<int>().Data; set => currentSWType.Convert<int>().Ref = value; }
        private static IntPtr currentSWType = new IntPtr(0x8809A0);

        public static unsafe bool HasDirtyArea()
        {
            var func = (delegate* unmanaged[Stdcall]<Bool>)0x53BAE0;
            return func();
        }

        public static unsafe SingleVector3D MatrixMultiply(ref SingleVector3D ret, Matrix3DStruct matrix3DStruct, SingleVector3D vec)
        {
            var func = (delegate* unmanaged[Thiscall]<int, IntPtr, IntPtr, IntPtr, IntPtr>)ASM.FastCallTransferStation;
            func(0x5AFB80,
                Pointer<SingleVector3D>.AsPointer(ref ret),
                Pointer<Matrix3DStruct>.AsPointer(ref matrix3DStruct),
                Pointer<SingleVector3D>.AsPointer(ref vec));
            return ret;
        }

        public static unsafe SingleVector3D MatrixMultiply(Matrix3DStruct mtx, SingleVector3D vec = default)
        {
            SingleVector3D ret = default;
            MatrixMultiply(ref ret, mtx, vec);
            return ret;
        }
    }
}
