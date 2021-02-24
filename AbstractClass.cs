using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{

	[StructLayout(LayoutKind.Explicit, Size = 36)]
	public struct AbstractClass
	{
		public unsafe int GetArrayIndex()
		{
			var func = (delegate* unmanaged[Thiscall]<ref AbstractClass, int>)Helpers.GetVirtualFunctionPointer(Pointer<AbstractClass>.AsPointer(ref this), 16);
			return func(ref this);
		}

		public unsafe CoordStruct GetCoords()
		{
			var func = (delegate* unmanaged[Thiscall]<ref AbstractClass, IntPtr, IntPtr>)Helpers.GetVirtualFunctionPointer(Pointer<AbstractClass>.AsPointer(ref this), 18);

			CoordStruct ret = default;
			func(ref this, Pointer<CoordStruct>.AsPointer(ref ret));
			return ret;
		}

		[FieldOffset(0)]
		public int Vfptr;
	}
}
