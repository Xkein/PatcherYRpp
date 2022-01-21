using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 6336)]
    public struct RulesClass
	{
		private static IntPtr instance = new IntPtr(0x8871E0);
		static public ref RulesClass Instance { get => ref instance.Convert<RulesClass>().Ref; }


		[FieldOffset(1640)] public double VeteranRatio;
		[FieldOffset(1648)] public double VeteranCombat;
		[FieldOffset(1656)] public double VeteranSpeed;
		[FieldOffset(1664)] public double VeteranSight;
		[FieldOffset(1672)] public double VeteranArmor;
		[FieldOffset(1680)] public double VeteranROF;
		[FieldOffset(1688)] public double VeteranCap;

	}
}
