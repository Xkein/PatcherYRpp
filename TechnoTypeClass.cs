using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{

    [StructLayout(LayoutKind.Sequential)]
    public class WeaponStruct
    {
        public IntPtr weaponType;
		public Pointer<WeaponTypeClass> WeaponType { get => weaponType; set => weaponType = value; }
        public CoordStruct FLH;
        public int BarrelLength;
        public int BarrelThickness;
        public bool TurretLocked;
    }

    [StructLayout(LayoutKind.Explicit, Size = 3576)]
    public struct TechnoTypeClass
    {
        static public readonly IntPtr ArrayPointer = new IntPtr(0xA8EB00);

        static public YRPP.ABSTRACTTYPE_ARRAY<TechnoTypeClass> ABSTRACTTYPE_ARRAY = new YRPP.ABSTRACTTYPE_ARRAY<TechnoTypeClass>(ArrayPointer);

        [FieldOffset(0)]
        public ObjectTypeClass Base;

        [FieldOffset(2200)] public WeaponStruct Weapon_first;
        public Pointer<WeaponStruct> Weapon => Pointer<WeaponStruct>.AsPointer(ref Weapon_first);
        [FieldOffset(2704)] public Bool ClearAllWeapons;
        [FieldOffset(2708)] public WeaponStruct EliteWeapon_first;
        public Pointer<WeaponStruct> EliteWeapon => Pointer<WeaponStruct>.AsPointer(ref EliteWeapon_first);
    }
}
