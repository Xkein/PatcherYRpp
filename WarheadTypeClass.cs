using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 464)]
    public struct WarheadTypeClass
    {
        static public readonly IntPtr ArrayPointer = new IntPtr(0x8874C0);
        static public ref DynamicVectorClass<Pointer<WarheadTypeClass>> Array { get => ref DynamicVectorClass<Pointer<WarheadTypeClass>>.GetDynamicVector(ArrayPointer); }


        static public Pointer<WarheadTypeClass> Find(string ID)
        {
            int idx = FindIndex(ID);
            if (idx >= 0)
            {
                return Array.Get(idx);
            }

            return Pointer<WarheadTypeClass>.Zero;
        }

        static public int FindIndex(string ID)
        {
            ref var warheadArray = ref Array;
            for (int i = 0; i < Array.Count; i++)
            {
                Pointer<WarheadTypeClass> pWH = warheadArray[i];
                if (pWH.Ref.Base.GetID() == ID)
                {
                    return i;
                }
            }
            return -1;
        }

        [FieldOffset(0)] public AbstractTypeClass Base;
        [FieldOffset(152)] public float Deform;

        [FieldOffset(292)] public float CellSpread;
        [FieldOffset(296)] public float CellInset;
        [FieldOffset(300)] public float PercentAtMax;

        [FieldOffset(324)] public bool Wall;
        [FieldOffset(325)] public bool WallAbsoluteDestroyer;
        [FieldOffset(326)] public bool PenetratesBunker;
        [FieldOffset(327)] public bool Wood;
        [FieldOffset(328)] public bool Tiberium;
        [FieldOffset(329)] public bool unknown_bool_149;
        [FieldOffset(330)] public bool Sparky;
        [FieldOffset(331)] public bool Sonic;
        [FieldOffset(332)] public bool Fire;
        [FieldOffset(333)] public bool Conventional;
        [FieldOffset(334)] public bool Rocker;
        [FieldOffset(335)] public bool DirectRocker;
        [FieldOffset(336)] public bool Bright;
        [FieldOffset(337)] public bool CLDisableRed;
        [FieldOffset(338)] public bool CLDisableGreen;
        [FieldOffset(339)] public bool CLDisableBlue;
        [FieldOffset(340)] public bool EMEffect;
        [FieldOffset(341)] public bool MindControl;
        [FieldOffset(342)] public bool Poison;
        [FieldOffset(343)] public bool IvanBomb;
        [FieldOffset(344)] public bool ElectricAssault;
        [FieldOffset(345)] public bool Parasite;
        [FieldOffset(346)] public bool Temporal;
        [FieldOffset(347)] public bool IsLocomotor;
        //[FieldOffset(348)] public Guid Locomotor;
        [FieldOffset(364)] public bool Airstrike;
        [FieldOffset(365)] public bool Psychedelic;
        [FieldOffset(366)] public bool BombDisarm;
        [FieldOffset(368)] public int Paralyzes;
        [FieldOffset(372)] public bool Culling;
        [FieldOffset(373)] public bool MakesDisguise;
        [FieldOffset(374)] public bool NukeMaker;
        [FieldOffset(375)] public bool Radiation;
        [FieldOffset(376)] public bool PsychicDamage;
        [FieldOffset(377)] public bool AffectsAllies;
        [FieldOffset(378)] public bool Bullets;
        [FieldOffset(379)] public bool Veinhole;
        [FieldOffset(380)] public int ShakeXlo;
        [FieldOffset(384)] public int ShakeXhi;
        [FieldOffset(388)] public int ShakeYlo;
        [FieldOffset(392)] public int ShakeYhi;

        [FieldOffset(424)] public DynamicVectorClass<int> DebrisMaximums;
        [FieldOffset(452)] public int MaxDebris;
        [FieldOffset(456)] public int MinDebris;
    }
}
