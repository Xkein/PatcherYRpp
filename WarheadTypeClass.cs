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

        static public YRPP.ABSTRACTTYPE_ARRAY<WarheadTypeClass> ABSTRACTTYPE_ARRAY = new YRPP.ABSTRACTTYPE_ARRAY<WarheadTypeClass>(ArrayPointer);

        [FieldOffset(0)] public AbstractTypeClass Base;
        [FieldOffset(152)] public float Deform;

        [FieldOffset(292)] public float CellSpread;
        [FieldOffset(296)] public float CellInset;
        [FieldOffset(300)] public float PercentAtMax;

        [FieldOffset(324)] public byte Wall;
        [FieldOffset(325)] public byte WallAbsoluteDestroyer;
        [FieldOffset(326)] public byte PenetratesBunker;
        [FieldOffset(327)] public byte Wood;
        [FieldOffset(328)] public byte Tiberium;
        [FieldOffset(329)] public byte unknown_bool_149;
        [FieldOffset(330)] public byte Sparky;
        [FieldOffset(331)] public byte Sonic;
        [FieldOffset(332)] public byte Fire;
        [FieldOffset(333)] public byte Conventional;
        [FieldOffset(334)] public byte Rocker;
        [FieldOffset(335)] public byte DirectRocker;
        [FieldOffset(336)] public byte Bright;
        [FieldOffset(337)] public byte CLDisableRed;
        [FieldOffset(338)] public byte CLDisableGreen;
        [FieldOffset(339)] public byte CLDisableBlue;
        [FieldOffset(340)] public byte EMEffect;
        [FieldOffset(341)] public byte MindControl;
        [FieldOffset(342)] public byte Poison;
        [FieldOffset(343)] public byte IvanBomb;
        [FieldOffset(344)] public byte ElectricAssault;
        [FieldOffset(345)] public byte Parasite;
        [FieldOffset(346)] public byte Temporal;
        [FieldOffset(347)] public byte IsLocomotor;
        //[FieldOffset(348)] public Guid Locomotor;
        [FieldOffset(364)] public byte Airstrike;
        [FieldOffset(365)] public byte Psychedelic;
        [FieldOffset(366)] public byte BombDisarm;
        [FieldOffset(368)] public int Paralyzes;
        [FieldOffset(372)] public byte Culling;
        [FieldOffset(373)] public byte MakesDisguise;
        [FieldOffset(374)] public byte NukeMaker;
        [FieldOffset(375)] public byte Radiation;
        [FieldOffset(376)] public byte PsychicDamage;
        [FieldOffset(377)] public byte AffectsAllies;
        [FieldOffset(378)] public byte Bullets;
        [FieldOffset(379)] public byte Veinhole;
        [FieldOffset(380)] public int ShakeXlo;
        [FieldOffset(384)] public int ShakeXhi;
        [FieldOffset(388)] public int ShakeYlo;
        [FieldOffset(392)] public int ShakeYhi;

        [FieldOffset(424)] public DynamicVectorClass<int> DebrisMaximums;
        [FieldOffset(452)] public int MaxDebris;
        [FieldOffset(456)] public int MinDebris;
    }
}
