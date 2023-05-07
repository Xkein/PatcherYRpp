using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DynamicPatcher;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 328)]
    public struct VocClass
    {
        public static readonly IntPtr ArrayPointer = new IntPtr(0xB1D378);

        public static ref DynamicVectorClass<Pointer<VocClass>> Array { get => ref DynamicVectorClass<Pointer<VocClass>>.GetDynamicVector(ArrayPointer); }

        public static unsafe int FindIndex(string soundName)
        {
            for (int i = 0; i < Array.Count; i++)
            {
                Pointer<VocClass> pVoc = Array[i];
                if (pVoc.Ref.GetName() == soundName)
                {
                    return i;
                }

            }
            return -1;
        }

        /** doesn't work
        public static unsafe int FindIndex(string soundName)
        {
            var func = (delegate* unmanaged[Thiscall]<int, string, int>)ASM.FastCallTransferStation;
            return func(0x7514D0, soundName);
        }
        */

        public static unsafe string GetSpeakName(int soundIndex)
        {
            var func = (delegate* unmanaged[Thiscall]<int, int, string>)ASM.FastCallTransferStation;
            return func(0x753330, soundIndex);
        }

        /* Play a Eva's sound.
           n = Index of VocClass in Array to be played */
        public static unsafe void Speak(int soundIndex, VoxType voxType = VoxType.INVALID, VoxPriorityType voxPriorityType = VoxPriorityType.INVALID)
        {
            var func = (delegate* unmanaged[Thiscall]<int, int, VoxType, VoxPriorityType, void>)ASM.FastCallTransferStation;
            func(0x752480, soundIndex, voxType, voxPriorityType);
        }

        /* Play a Eva's sound. */
        public static unsafe void Speak(string name, VoxType voxType = VoxType.INVALID, VoxPriorityType voxPriorityType = VoxPriorityType.INVALID)
        {
            var func = (delegate* unmanaged[Thiscall]<int, string, VoxType, VoxPriorityType, void>)ASM.FastCallTransferStation;
            func(0x752700, name, voxType, voxPriorityType);
        }

        /* Play a sound independant of the position.
           n = Index of VocClass in Array to be played
           Volume = 0.0f to 1.0f
           Panning = 0x0000 (left) to 0x4000 (right) (0x2000 is center)
           */
        public static unsafe void PlayGlobal(int soundIndex, int panning, float volume, Pointer<AudioController> ctrl = default)
        {
            var func = (delegate* unmanaged[Thiscall]<int, int, int, float, IntPtr, void>)ASM.FastCallTransferStation;
            func(0x750920, soundIndex, panning, volume, ctrl);
        }

        /* Play a sound at a certain Position.
               n = Index of VocClass in Array to be played */
        public static unsafe void PlayAt(int soundIndex, CoordStruct location, Pointer<AudioController> ctrl = default)
        {
            var func = (delegate* unmanaged[Thiscall]<int, int, ref CoordStruct, IntPtr, void>)ASM.FastCallTransferStation;
            func(0x7509E0, soundIndex, ref location, ctrl);
        }

        // calls the one above ^ - probably sanity checks and whatnot
        public static unsafe void PlayIndexAtPos(int soundIndex, CoordStruct location, int a3)
        {
            var func = (delegate* unmanaged[Thiscall]<int, int, ref CoordStruct, int, void>)ASM.FastCallTransferStation;
            func(0x750E20, soundIndex, ref location, a3);
        }

        // no idea what this does, but Super::Launch uses it on "SW Ready" events right after firing said SW
        public static unsafe void SilenceIndex(int soundIndex)
        {
            var func = (delegate* unmanaged[Thiscall]<int, int, void>)ASM.FastCallTransferStation;
            func(0x752A40, soundIndex);
        }

        public unsafe string GetName()
        {
            var func = (delegate* unmanaged[Thiscall]<ref VocClass, string>)0x751600;
            return func(ref this);
        }

        [FieldOffset(0)] public VocClassHeader Header;

    }

    public enum VoxType
    {
        STANDARD = 0,
        QUEUE = 1,
        INTERRUPT = 2,
        QUEUED_INTERRUPT = 3,
        INVALID = -1
    }

    public enum VoxPriorityType
    {
        LOW = 0,
        NORMAL = 1,
        IMPORTANT = 2,
        CRITICAL = 3,
        INVALID = -1
    }
}
