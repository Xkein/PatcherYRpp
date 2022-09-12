using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VeterancyStruct
    {
        VeterancyStruct(double value) : this()
        {
            this.Add(value);
        }

        void Add(int ownerCost, int victimCost)
        {
            this.Add(victimCost / (ownerCost * RulesClass.Instance.Ref.VeteranRatio));
        }

        void Add(double value)
        {
            var val = this.Veterancy + value;

            if (val > RulesClass.Instance.Ref.VeteranCap)
            {
                val = RulesClass.Instance.Ref.VeteranCap;
            }

            this.Veterancy = (float)val;
        }

        Rank GetRemainingLevel()
        {
            if (this.Veterancy >= 2.0f)
            {
                return Rank.Elite;
            }

            if (this.Veterancy >= 1.0f)
            {
                return Rank.Veteran;
            }

            return Rank.Rookie;
        }

        public bool IsNegative()
        {
            return this.Veterancy < 0.0f;
        }

        public bool IsRookie()
        {
            return this.Veterancy >= 0.0f && this.Veterancy < 1.0f;

        }

        public bool IsVeteran()
        {
            return this.Veterancy >= 1.0f && this.Veterancy < 2.0f;

        }

        public bool IsElite()
        {
            return this.Veterancy >= 2.0f;

        }

        public void Reset()
        {
            this.Veterancy = 0.0f;
        }

        public void SetRookie(bool notReally = true)
        {
            this.Veterancy = notReally ? -0.25f : 0.0f;
        }

        public void SetVeteran(bool yesReally = true)
        {
            this.Veterancy = yesReally ? 1.0f : 0.0f;
        }

        public void SetElite(bool yesReally = true)
        {
            this.Veterancy = yesReally ? 2.0f : 0.0f;
        }

        public float Veterancy;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PassengersClass
    {
        public int NumPassengers;
        public IntPtr firstPassenger;
        public Pointer<FootClass> FirstPassenger { get => firstPassenger; set => firstPassenger = value; }

        public unsafe void AddPassenger(Pointer<FootClass> pPassenger)
        {
            var func = (delegate* unmanaged[Thiscall]<ref PassengersClass, IntPtr, void>)0x4733A0;
            func(ref this, pPassenger);
        }

        public unsafe Pointer<FootClass> GetFirstPassenger()
        {
            return this.FirstPassenger;
        }

        public unsafe Pointer<FootClass> RemoveFirstPassenger()
        {
            var func = (delegate* unmanaged[Thiscall]<ref PassengersClass, IntPtr>)0x473430;
            return func(ref this);
        }

        public unsafe int GetTotalSize()
        {
            var func = (delegate* unmanaged[Thiscall]<ref PassengersClass, int>)0x473460;
            return func(ref this);
        }

        public unsafe int IndexOf(Pointer<FootClass> candidate)
        {
            var func = (delegate* unmanaged[Thiscall]<ref PassengersClass, IntPtr, int>)0x473500;
            return func(ref this, candidate);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FlashData
    {
        public int DurationRemaining;
        public Bool FlashingNow;

        public unsafe bool Update()
        {
            var func = (delegate* unmanaged[Thiscall]<ref FlashData, Bool>)0x4CC770;
            return func(ref this);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OwnedTiberiumStruct
    {
        public unsafe float GetAmount(int index)
        {
            var func = (delegate* unmanaged[Thiscall]<ref OwnedTiberiumStruct, int, float>)0x6C9680;
            return func(ref this, index);
        }

        public unsafe float GetTotalAmount()
        {
            var func = (delegate* unmanaged[Thiscall]<ref OwnedTiberiumStruct, float>)0x6C9650;
            return func(ref this);
        }

        public unsafe float AddAmount(float amount, int index)
        {
            var func = (delegate* unmanaged[Thiscall]<ref OwnedTiberiumStruct, float, int, float>)0x6C9690;
            return func(ref this, amount, index);
        }

        public unsafe float RemoveAmount(float amount, int index)
        {
            var func = (delegate* unmanaged[Thiscall]<ref OwnedTiberiumStruct, float, int, float>)0x6C96B0;
            return func(ref this, amount, index);
        }

        public unsafe int GetTotalValue()
        {
            var func = (delegate* unmanaged[Thiscall]<ref OwnedTiberiumStruct, int>)0x6C9600;
            return func(ref this);
        }

        public float Tiberium1;
        public float Tiberium2;
        public float Tiberium3;
        public float Tiberium4;
    }

    [StructLayout(LayoutKind.Explicit, Size = 1312)]
    public struct TechnoClass : IOwnAbstractType<TechnoTypeClass>
    {
        static public readonly IntPtr ArrayPointer = new IntPtr(0xA8EC78);
        static public ref DynamicVectorClass<Pointer<TechnoClass>> Array { get => ref DynamicVectorClass<Pointer<TechnoClass>>.GetDynamicVector(ArrayPointer); }

        public unsafe Pointer<TechnoTypeClass> Type
        {
            get
            {
                var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr>)0x6F3270;
                return func(ref this);
            }
        }

        Pointer<TechnoTypeClass> IOwnAbstractType<TechnoTypeClass>.OwnType => Type;
        Pointer<AbstractTypeClass> IOwnAbstractType.AbstractType => Type.Convert<AbstractTypeClass>();

        public unsafe bool CanReachLocation(CoordStruct destCoords)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, ref CoordStruct, Bool>)this.GetVirtualFunctionPointer(179);
            return func(ref this, ref destCoords);
        }

        public unsafe int SelectWeapon(Pointer<AbstractClass> pTarget)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int>)this.GetVirtualFunctionPointer(185);
            return func(ref this, pTarget);
        }
        public unsafe int SelectNavalTargeting(Pointer<AbstractClass> pTarget)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int>)this.GetVirtualFunctionPointer(186);
            return func(ref this, pTarget);
        }

        public unsafe int GetROF(int idxWeapon)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int, int>)this.GetVirtualFunctionPointer(198);
            return func(ref this, idxWeapon);
        }
        public unsafe int GetGuardRange(int dwUnk)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int, int>)this.GetVirtualFunctionPointer(199);
            return func(ref this, dwUnk);
        }

        public unsafe int DecreaseAmmo()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int>)this.GetVirtualFunctionPointer(228);
            return func(ref this);
        }
        public unsafe void AddPassenger(Pointer<FootClass> pPassenger)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, void>)this.GetVirtualFunctionPointer(229);
            func(ref this, pPassenger);
        }

        public unsafe bool IsCloseEnough(Pointer<AbstractClass> pTarget, int idxWeapon)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int, Bool>)this.GetVirtualFunctionPointer(234);
            return func(ref this, pTarget, idxWeapon);
        }
        public unsafe bool IsCloseEnoughToAttack(Pointer<AbstractClass> pTarget)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, Bool>)this.GetVirtualFunctionPointer(235);
            return func(ref this, pTarget);
        }
        public unsafe bool IsCloseEnoughToAttackCoords(CoordStruct coords)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, ref CoordStruct, Bool>)this.GetVirtualFunctionPointer(236);
            return func(ref this, ref coords);
        }

        public unsafe bool Destroyed(Pointer<ObjectClass> pKiller)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, Bool>)this.GetVirtualFunctionPointer(238);
            return func(ref this, pKiller);
        }
        public unsafe FireError GetFireErrorWithoutRange(Pointer<AbstractClass> pTarget, int nWeaponIndex)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int, FireError>)this.GetVirtualFunctionPointer(239);
            return func(ref this, pTarget, nWeaponIndex);
        }
        public unsafe FireError GetFireError(Pointer<AbstractClass> pTarget, int nWeaponIndex, bool ignoreRange)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int, Bool, FireError>)this.GetVirtualFunctionPointer(240);
            return func(ref this, pTarget, nWeaponIndex, ignoreRange);
        }
        public unsafe Pointer<TechnoClass> SelectAutoTarget(TargetFlags TargetFlags, CoordStruct TargetCoord, bool OnlyTargetHouseEnemy)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, TargetFlags, ref CoordStruct, Bool, IntPtr>)this.GetVirtualFunctionPointer(241);
            return func(ref this, TargetFlags, ref TargetCoord, OnlyTargetHouseEnemy);
        }
        public unsafe void SetTarget(Pointer<AbstractClass> pTarget)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, void>)this.GetVirtualFunctionPointer(242);
            func(ref this, pTarget);
        }
        public unsafe Pointer<BulletClass> Fire(Pointer<AbstractClass> pTarget, int nWeaponIndex)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int, IntPtr>)this.GetVirtualFunctionPointer(243);
            return func(ref this, pTarget, nWeaponIndex);
        }

        /// <summary>
        /// Fire Directly not use virtual function   by ststl
        /// </summary>
        /// <param name="pTarget"></param>
        /// <param name="idxWeapon"></param>
        /// <returns></returns>
        public unsafe Pointer<BulletClass> Fire_NotVirtual(Pointer<AbstractClass> pTarget, int idxWeapon)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int, IntPtr>)0x6FDD50;
            return func(ref this, pTarget, idxWeapon);
        }


        public unsafe void Guard()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, void>)this.GetVirtualFunctionPointer(244);
            func(ref this);
        }
        public unsafe bool SetOwningHouse(Pointer<HouseClass> pHouse, bool announce = true)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, Bool, Bool>)this.GetVirtualFunctionPointer(245);
            return func(ref this, pHouse, announce);
        }
        public unsafe void UpdateRockingState(CoordStruct rockingCoord, float rockerValue, bool halfEffect)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, ref CoordStruct, float, Bool, void>)this.GetVirtualFunctionPointer(246);
            func(ref this, ref rockingCoord, rockerValue, halfEffect);
        }
        public unsafe bool Crash(Pointer<ObjectClass> pKiller)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, Bool>)this.GetVirtualFunctionPointer(247);
            return func(ref this, pKiller);
        }

        public unsafe Pointer<WeaponStruct> GetDeployWeapon()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr>)this.GetVirtualFunctionPointer(252);
            return func(ref this);
        }
        public unsafe Pointer<WeaponStruct> GetTurretWeapon()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr>)this.GetVirtualFunctionPointer(253);
            return func(ref this);
        }
        public unsafe Pointer<WeaponStruct> GetWeapon(int idxWeapon)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int, IntPtr>)this.GetVirtualFunctionPointer(254);
            return func(ref this, idxWeapon);
        }
        public unsafe bool HasTurret()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)this.GetVirtualFunctionPointer(255);
            return func(ref this);
        }
        public unsafe bool CanOccupyFire()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)this.GetVirtualFunctionPointer(256);
            return func(ref this);
        }
        public unsafe int GetOccupyRangeBonus()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int>)this.GetVirtualFunctionPointer(257);
            return func(ref this);
        }
        public unsafe int GetOccupantCount()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int>)this.GetVirtualFunctionPointer(258);
            return func(ref this);
        }

        public unsafe CoordStruct GetTargetCoords()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, out CoordStruct, Bool>)this.GetVirtualFunctionPointer(267);
            func(ref this, out CoordStruct tmp);
            return tmp;
        }

        public unsafe void SetDestination(Pointer<AbstractClass> pDest, bool bUnk = true)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, Bool, void>)this.GetVirtualFunctionPointer(288);
            func(ref this, pDest, bUnk);
        }

        public unsafe bool CanAttackOnTheMove()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)this.GetVirtualFunctionPointer(304);
            return func(ref this);
        }


        public unsafe bool IsMindControlled()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)0x7105E0;
            return func(ref this);
        }

        public unsafe bool CanBePermMindControlled()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)0x53C450;
            return func(ref this);
        }


        public unsafe void SetTargetForPassengers(Pointer<AbstractClass> pTarget)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, void>)0x710550;
            func(ref this, pTarget);
        }

        public unsafe Pointer<HouseClass> GetOriginalOwner()
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr>)0x70F820;
            return func(ref this);
        }

        public unsafe int GetDistanceToTarget(Pointer<AbstractClass> pTarget)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int>)0x5F6360;
            return func(ref this, pTarget);
        }

        public unsafe void EnteredOpenTopped(Pointer<TechnoClass> pWho)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, void>)0x710470;
            func(ref this, pWho);
        }


        [FieldOffset(0)] public RadioClass BaseRadio;
        [FieldOffset(0)] public MissionClass BaseMission;
        [FieldOffset(0)] public ObjectClass Base;
        [FieldOffset(0)] public AbstractClass BaseAbstract;

        [FieldOffset(240)] public FlashData Flashing;
        [FieldOffset(248)] public ProgressTimer Animation; // how the unit animates
        [FieldOffset(276)] public PassengersClass Passengers;
        [FieldOffset(284)] public IntPtr transporter; // eg Disk . PowerPlant, this points to PowerPlant
        public Pointer<TechnoClass> Transporter { get => transporter; set => transporter = value; }

        [FieldOffset(336)] public VeterancyStruct Veterancy;

        [FieldOffset(460)] public IntPtr drainTarget; // eg Disk . PowerPlant, this points to PowerPlant
        public Pointer<TechnoClass> DrainTarget { get => drainTarget; set => drainTarget = value; }

        [FieldOffset(464)] public IntPtr drainingMe; // eg Disk . PowerPlant, this points to Disk
        public Pointer<TechnoClass> DrainingMe { get => drainingMe; set => drainingMe = value; }

        [FieldOffset(468)] public IntPtr drainAnim;
        public Pointer<AnimClass> DrainAnim { get => drainAnim; set => drainAnim = value; }

        [FieldOffset(540)] public IntPtr owner;
        public Pointer<HouseClass> Owner { get => owner; set => owner = value; }

        [FieldOffset(664)] public Bool Berzerk;

        // unless source is Pushy=
        // abs_Infantry source links with abs_Unit target and vice versa - can't attack others until current target flips
        // no checking whether source is Infantry, but no update for other types either
        // old Brute hack
        [FieldOffset(680)] public IntPtr directRockerLinkedUnit;
        public Pointer<FootClass> DirectRockerLinkedUnit { get => directRockerLinkedUnit; set => directRockerLinkedUnit = value; }
        [FieldOffset(684)] public IntPtr locomotorTarget; // mag->LocoTarget = victim
        public Pointer<FootClass> LocomotorTarget { get => locomotorTarget; set => locomotorTarget = value; }
        [FieldOffset(688)] public IntPtr locomotorSource; // victim->LocoSource = mag
        public Pointer<FootClass> LocomotorSource { get => locomotorSource; set => locomotorSource = value; }

        [FieldOffset(692)] public Pointer<AbstractClass> Target; //if attacking
        [FieldOffset(696)] public Pointer<AbstractClass> LastTarget;
        [FieldOffset(700)] public IntPtr captureManager;
        public Pointer<CaptureManagerClass> CaptureManager { get => captureManager; set => captureManager = value; }
        [FieldOffset(704)] public IntPtr mindControlledBy;
        public Pointer<TechnoClass> MindControlledBy { get => mindControlledBy; set => mindControlledBy = value; }
        [FieldOffset(708)] public Bool MindControlledByAUnit;
        [FieldOffset(712)] public IntPtr mindControlRingAnim;
        public Pointer<AnimClass> MindControlRingAnim { get => mindControlRingAnim; set => mindControlRingAnim = value; }
        [FieldOffset(716)] public IntPtr mindControlledByHouse;
        public Pointer<AnimClass> MindControlledByHouse { get => mindControlledByHouse; set => mindControlledByHouse = value; }
        [FieldOffset(720)] public IntPtr spawnManager;
        public Pointer<SpawnManagerClass> SpawnManager { get => spawnManager; set => spawnManager = value; }
        [FieldOffset(724)] public IntPtr spawnOwner;
        public Pointer<TechnoClass> SpawnOwner { get => spawnOwner; set => spawnOwner = value; }

        [FieldOffset(764)] public int Ammo;

        // rocking effect
        [FieldOffset(808)] public float AngleRotatedSideways;
        [FieldOffset(812)] public float AngleRotatedForwards;

        // set these and leave the previous two alone!
        // if these are set, the unit will roll up to pi/4, by this step each frame, and balance back
        [FieldOffset(816)] public float RockingSidewaysPerFrame; // left to right - positive pushes left side up
        [FieldOffset(820)] public float RockingForwardsPerFrame; // back to front - positive pushes ass up

        [FieldOffset(824)] public int HijackerInfantryType; // mutant hijacker

        [FieldOffset(828)] public OwnedTiberiumStruct Tiberium;

        [FieldOffset(880)] public FacingStruct BarrelFacing;
        [FieldOffset(904)] public FacingStruct Facing;
        [FieldOffset(928)] public FacingStruct TurretFacing;
        [FieldOffset(952)] public int CurrentBurstIndex;

        [FieldOffset(972)] public Bool CountedAsOwned; // is this techno contained in OwningPlayer.Owned... counts?
        [FieldOffset(973)] public Bool IsSinking;
        [FieldOffset(974)] public Bool WasSinkingAlready; // if(IsSinking && !WasSinkingAlready) { play SinkingSound; WasSinkingAlready = 1; }

        [FieldOffset(977)] public Bool HasBeenAttacked; // ReceiveDamage when not HouseClass_IsAlly
        [FieldOffset(978)] public Bool Cloakable;
        [FieldOffset(979)] public Bool IsPrimaryFactory; // doubleclicking a warfac/barracks sets it as primary
        [FieldOffset(980)] public Bool Spawned;
        [FieldOffset(981)] public Bool IsInPlayfield;


        [FieldOffset(1050)] public Bool IsHumanControlled;
        [FieldOffset(1051)] public Bool DiscoveredByPlayer;
        [FieldOffset(1052)] public Bool DiscoveredByComputer;

        [FieldOffset(1056)] public byte SightIncrease;

        [FieldOffset(1059)] public Bool IsRadarTracked;
        [FieldOffset(1060)] public Bool IsOnCarryall;
        [FieldOffset(1061)] public Bool IsCrashing;
        [FieldOffset(1062)] public Bool WasCrashingAlready;
        [FieldOffset(1063)] public Bool IsBeingManipulated;

        [FieldOffset(1088)] public DynamicVectorClass<int> CurrentTargetThreatValues;
        [FieldOffset(1112)] public DynamicVectorClass<Pointer<AbstractClass>> CurrentTargets;

        // if DistributedFire=yes, this is used to determine which possible targets should be ignored in the latest threat scan
        [FieldOffset(1136)] public DynamicVectorClass<Pointer<AbstractClass>> AttackedTargets;

        [FieldOffset(1292)] public Bool ShouldLoseTargetNow;

        [FieldOffset(1304)] public Pointer<ObjectTypeClass> Disguise;
        [FieldOffset(1308)] public Pointer<HouseClass> DisguisedAsHouse;
    }
}
