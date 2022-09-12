using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PatcherYRpp.FileFormats;

namespace PatcherYRpp
{

    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponStruct
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

        static public YRPP.GLOBAL_DVC_ARRAY<TechnoTypeClass> ABSTRACTTYPE_ARRAY = new YRPP.GLOBAL_DVC_ARRAY<TechnoTypeClass>(ArrayPointer);


        public unsafe bool CanAttackMove()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, Bool>)this.GetVirtualFunctionPointer(41);
            return func(ref this);
        }
        public unsafe bool CanCreateHere(CellStruct mapCoords, Pointer<HouseClass> pOwner)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, ref CellStruct, IntPtr, Bool>)this.GetVirtualFunctionPointer(42);
            return func(ref this, ref mapCoords, pOwner);
        }
        public unsafe int GetCost()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, int>)this.GetVirtualFunctionPointer(43);
            return func(ref this);
        }
        public unsafe int GetRepairStepCost()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, int>)this.GetVirtualFunctionPointer(44);
            return func(ref this);
        }
        public unsafe int GetRepairStep()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, int>)this.GetVirtualFunctionPointer(45);
            return func(ref this);
        }
        public unsafe int GetRefund(Pointer<HouseClass> pHouse, bool bUnk)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, IntPtr, Bool, int>)this.GetVirtualFunctionPointer(46);
            return func(ref this, pHouse, bUnk);
        }
        public unsafe int GetFlightLevel()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, int>)this.GetVirtualFunctionPointer(47);
            return func(ref this);
        }

        Pointer<WeaponStruct> GetWeapon(int index, bool elite)
        {
            return elite ? this.EliteWeapon + index : this.Weapon + index;
        }


        [FieldOffset(0)] public ObjectTypeClass Base;
        [FieldOffset(0)] public AbstractTypeClass BaseAbstractType;

        [FieldOffset(844)] public Guid Locomotor;

        [FieldOffset(896)] public double Size;

        [FieldOffset(1460)] public MovementZone MovementZone;

        [FieldOffset(1516)] public int Speed;


        [FieldOffset(1552)] public int Cost;
        [FieldOffset(1556)] public int Soylent;

        [FieldOffset(1660)] public SpeedType SpeedType;

        [FieldOffset(1750)] public byte CameoFile_first;
        public AnsiStringPointer CameoFile => Pointer<byte>.AsPointer(ref CameoFile_first);

        [FieldOffset(1776)] public Pointer<SHPStruct> Cameo;
        [FieldOffset(1780)] public Bool CameoAllocated;
        [FieldOffset(1801)] public byte AltCameoFile_first;
        public AnsiStringPointer AltCameoFile => Pointer<byte>.AsPointer(ref AltCameoFile_first);

        [FieldOffset(1808)] public Pointer<SHPStruct> AltCameo;
        [FieldOffset(1812)] public Bool AltCameoAllocated;


        [FieldOffset(1820)] public int ROT;

        [FieldOffset(2200)] public WeaponStruct Weapon_first;
        public Pointer<WeaponStruct> Weapon => Pointer<WeaponStruct>.AsPointer(ref Weapon_first);
        [FieldOffset(2704)] public Bool ClearAllWeapons;
        [FieldOffset(2708)] public WeaponStruct EliteWeapon_first;
        public Pointer<WeaponStruct> EliteWeapon => Pointer<WeaponStruct>.AsPointer(ref EliteWeapon_first);

        [FieldOffset(3434)] public Bool BalloonHover;
        [FieldOffset(3476)] public Bool JumpJet;

    }
}
