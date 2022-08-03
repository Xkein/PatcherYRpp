using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    public interface IOwnAbstractType
    {
        Pointer<AbstractTypeClass> AbstractType { get; }
	}
    public interface IOwnAbstractType<T> : IOwnAbstractType
	{
        Pointer<T> OwnType { get; }
	}

	[StructLayout(LayoutKind.Explicit, Size = 152, Pack = 1)]
	public struct AbstractTypeClass
	{
		static private readonly IntPtr ArrayPointer = new IntPtr(0xA8E968);

		static public YRPP.GLOBAL_DVC_ARRAY<AbstractTypeClass> ABSTRACTTYPE_ARRAY = new YRPP.GLOBAL_DVC_ARRAY<AbstractTypeClass>(ArrayPointer);

		public unsafe bool LoadFromINI(Pointer<CCINIClass> pINI)
		{
			var func = (delegate* unmanaged[Thiscall]<ref AbstractTypeClass, IntPtr, Bool>)this.GetVirtualFunctionPointer(25);
			return func(ref this, pINI);
		}

		[FieldOffset(0)]
		public AbstractClass Base;

		[FieldOffset(36)] private byte ID_first;
		public AnsiStringPointer ID => Pointer<byte>.AsPointer(ref ID_first);

		[FieldOffset(61)] private byte UINameLabel_first;
		[FieldOffset(96)] public UniStringPointer UIName;

		[FieldOffset(100)] private byte Name_first;
	}
}
