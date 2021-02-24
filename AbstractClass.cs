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
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate int GetArrayIndexDelegate(ref AbstractClass pThis);
		public int GetArrayIndex()
		{
			GetArrayIndexDelegate function = Helpers.GetVirtualFunction<GetArrayIndexDelegate>(Pointer<AbstractClass>.AsPointer(ref this), 16);
			return function(ref this);
		}

		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate IntPtr GetCoordsDelegate(ref AbstractClass pThis, IntPtr pCrd);
		public CoordStruct GetCoords()
		{
			GetCoordsDelegate function = Helpers.GetVirtualFunction<GetCoordsDelegate>(Pointer<AbstractClass>.AsPointer(ref this), 18);

			CoordStruct ret = default;
			function(ref this, Pointer<CoordStruct>.AsPointer(ref ret));
			return ret;
		}

		[FieldOffset(0)]
		public int Vfptr;
	}
}
