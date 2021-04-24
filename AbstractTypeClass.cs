using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
	[StructLayout(LayoutKind.Explicit, Size = 152, Pack = 1)]
	public struct AbstractTypeClass
	{
		static public readonly IntPtr ArrayPointer = new IntPtr(0xA8E968);

		static public YRPP.ABSTRACTTYPE_ARRAY<AbstractTypeClass> ABSTRACTTYPE_ARRAY = new YRPP.ABSTRACTTYPE_ARRAY<AbstractTypeClass>(ArrayPointer);

		public unsafe bool LoadFromINI(Pointer<CCINIClass> pINI)
		{
			var func = (delegate* unmanaged[Thiscall]<ref AbstractTypeClass, IntPtr, Bool>)Helpers.GetVirtualFunctionPointer(Pointer<AbstractTypeClass>.AsPointer(ref this), 25);
			return func(ref this, pINI);
		}

		[FieldOffset(0)]
		public AbstractClass Base;

		[FieldOffset(36)] public byte ID_first;
		public AnsiString GetID() => Pointer<byte>.AsPointer(ref ID_first);

		[FieldOffset(61)] public byte UINameLabel_first;
		[FieldOffset(96)] public IntPtr UIName;
		public AnsiString GetUIName() => UIName;

		[FieldOffset(100)] public byte Name_first;
	}
}
