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
            this.Add(victimCost / (ownerCost * RulesClass.Instance.VeteranRatio));
        }

        void Add(double value)
        {
            var val = this.Veterancy + value;

            if (val > RulesClass.Instance.VeteranCap)
            {
                val = RulesClass.Instance.VeteranCap;
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

        bool IsNegative()
        {
            return this.Veterancy < 0.0f;
        }

        bool IsRookie()
        {
            return this.Veterancy >= 0.0f && this.Veterancy < 1.0f;

        }

        bool IsVeteran()
        {
            return this.Veterancy >= 1.0f && this.Veterancy < 2.0f;

        }

        bool IsElite()
        {
            return this.Veterancy >= 2.0f;

        }

        void Reset()
        {
            this.Veterancy = 0.0f;
        }

        void SetRookie(bool notReally = true)
        {
            this.Veterancy = notReally ? -0.25f : 0.0f;
        }

        void SetVeteran(bool yesReally = true)
        {
            this.Veterancy = yesReally ? 1.0f : 0.0f;
        }

        void SetElite(bool yesReally = true)
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
    public struct TechnoClass
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


        public unsafe int SelectWeapon(Pointer<AbstractClass> pTarget)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int>)this.GetVirtualFunctionPointer(185);
            return func(ref this, pTarget);
        }

        public unsafe int GetROF(int idxWeapon)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int, int>)this.GetVirtualFunctionPointer(198);
            return func(ref this, idxWeapon);
        }

        public unsafe Pointer<WeaponStruct> GetWeapon(int idxWeapon)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int, IntPtr>)this.GetVirtualFunctionPointer(254);
            return func(ref this, idxWeapon);
        }

        [FieldOffset(0)] public ObjectClass Base;


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

        [FieldOffset(692)] public Pointer<AbstractClass> Target; //if attacking
        [FieldOffset(696)] public Pointer<AbstractClass> LastTarget;

        [FieldOffset(764)] public int Ammo;

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


        [FieldOffset(1304)] public Pointer<ObjectTypeClass> Disguise;
        [FieldOffset(1308)] public Pointer<HouseClass> DisguisedAsHouse;
    }
}
