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

        private static readonly IntPtr ArrayPointer = new IntPtr(0xA83C68);

        public static YRPP.GLOBAL_DVC_ARRAY<BuildingTypeClass> ABSTRACTTYPE_ARRAY = new YRPP.GLOBAL_DVC_ARRAY<BuildingTypeClass>(ArrayPointer);

        public unsafe bool IsVehicle()
        {
            var func = (delegate* unmanaged[Thiscall]<ref BuildingTypeClass, Bool>)0x465D40;
            return func(ref this);
        }

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

        [FieldOffset(3744)] private IntPtr freeUnit;
        public Pointer<UnitTypeClass> FreeUnit => freeUnit.Convert<UnitTypeClass>();

        [FieldOffset(3764)] public int Adjacent;

        [FieldOffset(3768)] public AbstractType Factory;
        [FieldOffset(3808)] public int PowerBonus;
        [FieldOffset(3812)] public int PowerDrain;
        [FieldOffset(3816)] public int ExtraPowerBonus;
        [FieldOffset(3820)] public int ExtraPowerDrain;
        [FieldOffset(3828)] public int Height;
        [FieldOffset(3832)] public int OccupyHeight;
        [FieldOffset(5408)] public int NormalZAdjust;
        [FieldOffset(5458)] public Bool NeedsEngineer;
        [FieldOffset(5490)] public Bool Capturable;
        [FieldOffset(5491)] public Bool Powered;
        [FieldOffset(5492)] public Bool PoweredSpecial;
        [FieldOffset(5493)] public Bool Overpowerable;
        [FieldOffset(5494)] public Bool Spyable;
        [FieldOffset(5495)] public Bool CanC4;
        [FieldOffset(5497)] public Bool Unsellable;
        [FieldOffset(5825)] public Bool Hospital;
        [FieldOffset(5835)] public Bool Helipad;
        [FieldOffset(5889)] public Bool InvisibleInGame;
        [FieldOffset(5891)] public Bool PlaceAnywhere;
        [FieldOffset(6016)] public int NumberOfDocks;

    }
}
