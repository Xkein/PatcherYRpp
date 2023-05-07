﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PatcherYRpp.FileFormats;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 3576)]
    public struct TechnoTypeClass
    {
        public static readonly IntPtr ArrayPointer = new IntPtr(0xA8EB00);

        public static YRPP.GLOBAL_DVC_ARRAY<TechnoTypeClass> ABSTRACTTYPE_ARRAY = new YRPP.GLOBAL_DVC_ARRAY<TechnoTypeClass>(ArrayPointer);

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

        [FieldOffset(660)] public int WalkRate;
        [FieldOffset(664)] public int IdleRate;
        [FieldOffset(668)] public AbilitiesStruct VeteranAbilities;
        [FieldOffset(686)] public AbilitiesStruct EliteAbilities;
        [FieldOffset(760)] public int SlowdownDistance;
        [FieldOffset(784)] public int CloakingSpeed;
        [FieldOffset(788)] public DynamicVectorClass<Pointer<VoxelAnimTypeClass>> DebrisTypes;
        [FieldOffset(816)] public DynamicVectorClass<int> DebrisMaximums;
        [FieldOffset(844)] public Guid Locomotor;
        [FieldOffset(880)] public double Weight;
        [FieldOffset(888)] public double PhysicalSize;
        [FieldOffset(896)] public double Size;
        [FieldOffset(904)] public double SizeLimit;
        [FieldOffset(912)] public Bool HoverAttack;
        [FieldOffset(916)] public int VHPScan;
        [FieldOffset(928)] public double RollAngle;
        [FieldOffset(936)] public double PitchSpeed;
        [FieldOffset(944)] public double PitchAngle;
        [FieldOffset(952)] public int BuildLimit;
        [FieldOffset(968)] public double DeployTime;
        [FieldOffset(976)] public double FireAngle;
        [FieldOffset(988)] public int LeptonMindControlOffset;
        [FieldOffset(992)] public int PixelSelectionBracketDelta;
        [FieldOffset(1028)] public IntPtr deploysInto;
        public Pointer<BuildingTypeClass> DeploysInto => deploysInto;
        [FieldOffset(1032)] public IntPtr undeploysInto;
        public Pointer<UnitTypeClass> UndeploysInto => undeploysInto;
        [FieldOffset(1036)] public IntPtr powersUnit;
        public Pointer<UnitTypeClass> PowersUnit => powersUnit;
        [FieldOffset(1040)] public Bool PoweredUnit;
        [FieldOffset(1376)] public int TurretRotateSound;
        [FieldOffset(1380)] public int EnterTransportSound;
        [FieldOffset(1384)] public int LeaveTransportSound;
        [FieldOffset(1388)] public int DeploySound;
        [FieldOffset(1392)] public int UndeploySound;
        [FieldOffset(1396)] public int ChronoInSound;
        [FieldOffset(1400)] public int ChronoOutSound;
        [FieldOffset(1460)] public MovementZone MovementZone;
        [FieldOffset(1464)] public int GuardRange;
        [FieldOffset(1468)] public int MaxDebris;
        [FieldOffset(1472)] public int MinDebris;
        [FieldOffset(1504)] public int Passengers;
        [FieldOffset(1508)] public Bool OpenTopped;
        [FieldOffset(1512)] public int Sight;
        [FieldOffset(1516)] public Bool ResourceGatherer;
        [FieldOffset(1517)] public Bool ResourceDestination;
        [FieldOffset(1518)] public Bool RevealToAll;
        [FieldOffset(1519)] public Bool Drainable;
        [FieldOffset(1520)] public int SensorsSight;
        [FieldOffset(1524)] public int DetectDisguiseRange;
        [FieldOffset(1528)] public int BombSight;
        [FieldOffset(1532)] public int LeadershipRating;
        [FieldOffset(1536)] public int NavalTargeting;
        [FieldOffset(1540)] public int LandTargeting;
        [FieldOffset(1544)] public float BuildTimeMultiplier;
        [FieldOffset(1548)] public int MindControlRingOffset;
        [FieldOffset(1552)] public int Cost;
        [FieldOffset(1556)] public int Soylent;
        [FieldOffset(1560)] public int FlightLevel;
        [FieldOffset(1656)] public int Speed;
        [FieldOffset(1660)] public SpeedType SpeedType;
        [FieldOffset(1664)] public int InitialAmmo;
        [FieldOffset(1668)] public int Ammo;
        [FieldOffset(1672)] public int IFVMode;
        [FieldOffset(1676)] public int AirRangeBonus;
        [FieldOffset(1688)] public int Reload;
        [FieldOffset(1692)] public int EmptyReload;
        [FieldOffset(1696)] public int ReloadIncrement;
        [FieldOffset(1700)] public int RadialFireSegments;
        [FieldOffset(1704)] public int DeployFireWeapon;
        [FieldOffset(1708)] public Bool DeployFire;
        [FieldOffset(1709)] public Bool DeployToLand;
        [FieldOffset(1710)] public Bool MobileFire;
        [FieldOffset(1711)] public Bool OpportunityFire;
        [FieldOffset(1712)] public Bool DistributedFire;
        [FieldOffset(1728)] public Bool AttackFriendlies;
        [FieldOffset(1729)] public Bool AttackCursorOnFriendlies;
        [FieldOffset(1732)] public int UndeployDelay;
        [FieldOffset(1736)] public Bool PreventAttackMove;
        [FieldOffset(1749)] public Bool AllowedToStartInMultiplayer;
        [FieldOffset(1750)] public byte CameoFile_first;
        public AnsiStringPointer CameoFile => Pointer<byte>.AsPointer(ref CameoFile_first);
        [FieldOffset(1776)] public Pointer<SHPStruct> Cameo;
        [FieldOffset(1780)] public Bool CameoAllocated;
        [FieldOffset(1801)] public byte AltCameoFile_first;
        public AnsiStringPointer AltCameoFile => Pointer<byte>.AsPointer(ref AltCameoFile_first);
        [FieldOffset(1808)] public Pointer<SHPStruct> AltCameo;
        [FieldOffset(1812)] public Bool AltCameoAllocated;
        [FieldOffset(1820)] public int ROT;
        [FieldOffset(1824)] public int TurretOffset;
        [FieldOffset(1828)] public Bool CanBeHidden;
        [FieldOffset(1836)] public DynamicVectorClass<Pointer<AnimTypeClass>> Explosion;
        [FieldOffset(1864)] public DynamicVectorClass<Pointer<AnimTypeClass>> DestroyAnim;
        [FieldOffset(2044)] public int ShadowIndex;
        [FieldOffset(2048)] public int Storage;
        [FieldOffset(2052)] public Bool TurretNotExportedOnGround;
        [FieldOffset(2053)] public Bool Gunner;
        [FieldOffset(2054)] public Bool HasTurretTooltips;
        [FieldOffset(2056)] public int TurretCount;
        [FieldOffset(2060)] public int WeaponCount;
        [FieldOffset(2064)] public Bool IsChargeTurret;
        [FieldOffset(2068)] public CoordStruct turretWeaponFLH_first; // index 6 - 10 is AlternateFLH0 - AlternateFLH4, if no data use Weapon1FLH's data.
        public Pointer<CoordStruct> TurretWeaponFLH => Pointer<CoordStruct>.AsPointer(ref turretWeaponFLH_first);
        [FieldOffset(2200)] public WeaponStruct weapon_first;
        public Pointer<WeaponStruct> Weapon => Pointer<WeaponStruct>.AsPointer(ref weapon_first);
        [FieldOffset(2704)] public Bool ClearAllWeapons;
        [FieldOffset(2708)] public WeaponStruct eliteWeapon_first;
        public Pointer<WeaponStruct> EliteWeapon => Pointer<WeaponStruct>.AsPointer(ref eliteWeapon_first);
        [FieldOffset(3212)] public Bool TypeImmune;
        [FieldOffset(3213)] public Bool MoveToShroud;
        [FieldOffset(3214)] public Bool Trainable;
        [FieldOffset(3215)] public Bool DamageSparks;
        [FieldOffset(3216)] public Bool TargetLaser;
        [FieldOffset(3231)] public Bool DontScore;
        [FieldOffset(3233)] public Bool Turret;
        [FieldOffset(3277)] public Bool Crewed;
        [FieldOffset(3280)] public Bool Cloakable;
        [FieldOffset(3284)] public Bool Teleporter;
        [FieldOffset(3285)] public Bool IsGattling;
        [FieldOffset(3288)] public int WeaponStages;
        [FieldOffset(3292)] public int weaponStage_first;
        public Pointer<int> WeaponStage => Pointer<int>.AsPointer(ref weaponStage_first);
        [FieldOffset(3316)] public int eliteStage_first;
        public Pointer<int> EliteStage => Pointer<int>.AsPointer(ref eliteStage_first);
        [FieldOffset(3348)] public Bool SelfHealing;
        [FieldOffset(3349)] public Bool Explodes;
        [FieldOffset(3361)] public Bool TurretSpins;
        [FieldOffset(3367)] public Bool HunterSeeker;
        [FieldOffset(3368)] public Bool Crusher;
        [FieldOffset(3369)] public Bool OmniCrusher;
        [FieldOffset(3370)] public Bool OmniCrushResistant;
        [FieldOffset(3371)] public Bool TiltsWhenCrushes;
        [FieldOffset(3372)] public Bool IsSubterranean;
        [FieldOffset(3373)] public Bool AutoCrush;
        [FieldOffset(3374)] public Bool Bunkerable;
        [FieldOffset(3375)] public Bool CanDisguise;
        [FieldOffset(3376)] public Bool PermaDisguise;
        [FieldOffset(3377)] public Bool DetectDisguise;
        [FieldOffset(3378)] public Bool DisguiseWhenStill;
        [FieldOffset(3379)] public Bool CanApproachTarget;
        [FieldOffset(3380)] public Bool CanRecalcApproachTarget;
        [FieldOffset(3385)] public Bool DefaultToGuardArea;
        [FieldOffset(3412)] public Bool Spawned;
        [FieldOffset(3412)] public int SpawnsNumber;
        [FieldOffset(3412)] public int SpawnRegenRate;
        [FieldOffset(3412)] public int SpawnReloadRate;
        [FieldOffset(3432)] public Bool MissileSpawn;
        [FieldOffset(3433)] public Bool Underwater;
        [FieldOffset(3434)] public Bool BalloonHover;
        [FieldOffset(3436)] public int SuppressionThreshold;
        [FieldOffset(3440)] public int JumpjetTurnRate;
        [FieldOffset(3444)] public int JumpjetSpeed;
        [FieldOffset(3448)] public float JumpjetClimb;
        [FieldOffset(3452)] public float JumpjetCrash;
        [FieldOffset(3456)] public int JumpjetHeight;
        [FieldOffset(3460)] public float JumpjetAccel;
        [FieldOffset(3464)] public float JumpjetWobbles;
        [FieldOffset(3468)] public Bool JumpjetNoWobbles;
        [FieldOffset(3472)] public int JumpjetDeviation;
        [FieldOffset(3476)] public Bool JumpJet;
        [FieldOffset(3477)] public Bool Crashable;
        [FieldOffset(3478)] public Bool ConsideredAircraft;
        [FieldOffset(3479)] public Bool Organic;
        [FieldOffset(3480)] public Bool NoShadow;
        [FieldOffset(3481)] public Bool CanPassiveAquire;
        [FieldOffset(3482)] public Bool CanRetaliate;
        [FieldOffset(3516)] public Bool IsSelectableCombatant;
        [FieldOffset(3517)] public Bool Accelerates;
        [FieldOffset(3518)] public Bool DisableVoxelCache;
        [FieldOffset(3519)] public Bool DisableShadowCache;

        public Pointer<WeaponTypeClass> get_Primary() => Weapon[0].WeaponType;
        public Pointer<WeaponTypeClass> get_Secondary() => Weapon[1].WeaponType;
        public Pointer<WeaponTypeClass> get_Weapon(int i) => Weapon[i].WeaponType;
        public CoordStruct get_WeaponFLH(int i) => Weapon[i].FLH;
        public Pointer<WeaponTypeClass> get_ElitePrimary() => EliteWeapon[0].WeaponType;
        public Pointer<WeaponTypeClass> get_EliteSecondary() => EliteWeapon[1].WeaponType;
        public Pointer<WeaponTypeClass> get_EliteWeapon(int i) => EliteWeapon[i].WeaponType;
        public CoordStruct get_EliteWeaponFLH(int i) => EliteWeapon[i].FLH;

        public static Pointer<TechnoTypeClass> Find(string id)
        {
            return ABSTRACTTYPE_ARRAY.Find(id);
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 18)]
    public struct AbilitiesStruct
    {
        public Bool FASTER; //0x00
        public Bool STRONGER; //0x01
        public Bool FIREPOWER; //0x02
        public Bool SCATTER; //0x03
        public Bool ROF; //0x04
        public Bool SIGHT; //0x05
        public Bool CLOAK; //0x06
        public Bool TIBERIUM_PROOF; //0x07
        public Bool VEIN_PROOF; //0x08
        public Bool SELF_HEAL; //0x09
        public Bool EXPLODES; //0x0A
        public Bool RADAR_INVISIBLE; //0x0B
        public Bool SENSORS; //0x0C
        public Bool FEARLESS; //0x0D
        public Bool C4; //0x0E
        public Bool TIBERIUM_HEAL; //0x0F
        public Bool GUARD_AREA; //0x10
        public Bool CRUSHER; //0x11
    }

    [StructLayout(LayoutKind.Explicit, Size = 28)]
    public struct WeaponStruct
    {
        [FieldOffset(0)] public Pointer<WeaponTypeClass> WeaponType;
        [FieldOffset(4)] public CoordStruct FLH;
        [FieldOffset(16)] public int BarrelLength;
        [FieldOffset(20)] public int BarrelThickness;
        [FieldOffset(24)] public Bool TurretLocked;
    }
}
