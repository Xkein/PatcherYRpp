using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 700)]
    public struct OverlayTypeClass
    {
        [FieldOffset(0)] public ObjectTypeClass Base;

		[FieldOffset(660)] public int ArrayIndex;
		[FieldOffset(664)] public LandType LandType;
		[FieldOffset(668)] public Pointer<AnimTypeClass> CellAnim;
		[FieldOffset(672)] public int DamageLevels;
		[FieldOffset(676)] public int Strength;
		[FieldOffset(680)] public byte Wall;
		[FieldOffset(681)] public byte Tiberium;
		[FieldOffset(682)] public byte Crate;
		[FieldOffset(683)] public byte CrateTrigger;
		[FieldOffset(684)] public byte NoUseTileLandType;
		[FieldOffset(685)] public byte IsVeinholeMonster;
		[FieldOffset(686)] public byte IsVeins;
		[FieldOffset(687)] public byte ImageLoaded;   //not INI
		[FieldOffset(688)] public byte Explodes;
		[FieldOffset(689)] public byte ChainReaction;
		[FieldOffset(690)] public byte Overrides;
		[FieldOffset(691)] public byte DrawFlat;
		[FieldOffset(692)] public byte IsRubble;
		[FieldOffset(693)] public byte IsARock;
		[FieldOffset(694)] public ColorStruct RadarColor;
	}
}
