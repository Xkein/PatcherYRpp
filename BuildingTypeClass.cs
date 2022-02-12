using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 6040)]
    public struct BuildingTypeClass
    {


        public unsafe short GetFoundationWidth()
        {
            var func = (delegate* unmanaged[Thiscall]<ref BuildingTypeClass, short>)0x45EC90;
            return func(ref this);
        }
        public unsafe short GetFoundationHeight(bool bIncludeBib)
        {
            var func = (delegate* unmanaged[Thiscall]<ref BuildingTypeClass, Bool, short>)0x45ECA0;
            return func(ref this, bIncludeBib);
        }

        [FieldOffset(0)] public TechnoTypeClass Base;
        [FieldOffset(0)] public ObjectTypeClass BaseObjectType;
        [FieldOffset(0)] public AbstractTypeClass BaseAbstractType;

        [FieldOffset(5891)] public Bool PlaceAnywhere;

    }
}
