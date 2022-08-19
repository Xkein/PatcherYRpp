using DynamicPatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 90296)]
    public struct HouseClass : IOwnAbstractType<HouseTypeClass>
    {
        static public readonly IntPtr ArrayPointer = new IntPtr(0xA80228);
        static public ref DynamicVectorClass<Pointer<HouseClass>> Array { get => ref DynamicVectorClass<Pointer<HouseClass>>.GetDynamicVector(ArrayPointer); }

        public static Pointer<HouseClass> Player { get => player.Convert<Pointer<HouseClass>>().Data; set => player.Convert<Pointer<HouseClass>>().Ref = value; }
        private static IntPtr player = new IntPtr(0xA83D4C);
        public static Pointer<HouseClass> Observer { get => observer.Convert<Pointer<HouseClass>>().Data; set => observer.Convert<Pointer<HouseClass>>().Ref = value; }
        private static IntPtr observer = new IntPtr(0xAC1198);


        Pointer<HouseTypeClass> IOwnAbstractType<HouseTypeClass>.OwnType => Type;
        Pointer<AbstractTypeClass> IOwnAbstractType.AbstractType => Type.Convert<AbstractTypeClass>();


        // HouseClass is too large that clr could not process. so we user Pointer instead.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Pointer<HouseClass> GetThis() => this.GetThisPointer();

        public Pointer<SuperClass> FindSuperWeapon(Pointer<SuperWeaponTypeClass> pType)
        {
            for (int i = 0; i < Supers.Count; i++)
            {
                var pItem = Supers[i];
                if (pItem.Ref.Type == pType)
                {
                    return pItem;
                }
            }

            return Pointer<SuperClass>.Zero;
        }

        public unsafe bool IsAlliedWith(int idxHouse)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, int, Bool>)0x4F9A10;
            return func(GetThis(), idxHouse);
        }
        public unsafe bool IsAlliedWith(Pointer<HouseClass> pHouse)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, IntPtr, Bool>)0x4F9A50;
            return func(GetThis(), pHouse);
        }
        public unsafe bool IsAlliedWith(Pointer<ObjectClass> pObject)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, IntPtr, Bool>)0x4F9A90;
            return func(GetThis(), pObject);
        }
        public unsafe bool IsAlliedWith(Pointer<AbstractClass> pAbstract)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, IntPtr, Bool>)0x4F9AF0;
            return func(GetThis(), pAbstract);
        }

        public unsafe void TakeMoney(int amount)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, int, void>)0x4F9790;
            func(GetThis(), amount);
        }
        public unsafe void GiveMoney(int amount)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, int, void>)0x4F9950;
            func(GetThis(), amount);
        }
        public unsafe int Available_Money()
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, int>)this.GetVirtualFunctionPointer(6, 9);
            return func(GetThis().RawOffset(36));
        }
        public bool CanTransactMoney(int amount)
        {
            return amount >= 0 || Available_Money() >= -amount;
        }
        public void TransactMoney(int amount)
        {
            if (amount > 0) GiveMoney(amount);
            else TakeMoney(-amount);
        }
        public bool TryTransactMoney(int amount)
        {
            if(CanTransactMoney(amount))
            {
                TransactMoney(amount);
                return true;
            }else return false;
        }

        public unsafe void RemoveTracking(Pointer<TechnoClass> pTracked)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, IntPtr, void>)0x4FF550;
            func(GetThis(), pTracked);
        }

        public static unsafe Pointer<HouseClass> FindByCountryIndex(int houseType)
        {
            var func = (delegate* unmanaged[Thiscall]<int, IntPtr>)0x502D30;
            return func(houseType);
        }
        public static unsafe Pointer<HouseClass> FindByIndex(int idxHouse)
        {
            var func = (delegate* unmanaged[Thiscall]<int, IntPtr>)0x510ED0;
            return func(idxHouse);
        }
        public static unsafe int FindIndexByName(AnsiString name)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, int>)0x50C170;
            return func(name);
        }

        // gets the first house of a type with this name
        public static Pointer<HouseClass> FindByCountryName(AnsiString name)
        {
            var idx = HouseTypeClass.FindIndexOfName(name);
            return FindByCountryIndex(idx);
        }

        // gets the first house of a type with name Neutral
        public static Pointer<HouseClass> FindNeutral()
        {
            return FindByCountryName("Neutral");
        }

        // gets the first house of a type with name Special
        public static Pointer<HouseClass> FindSpecial()
        {
            return FindByCountryName("Special");
        }

        // gets the first house of a side with this name
        public static Pointer<HouseClass> FindBySideIndex(int index)
        {
            foreach (var pHouse in Array)
            {
                if (pHouse.Ref.Type.Ref.SideIndex == index)
                {
                    return pHouse;
                }
            }
            return Pointer<HouseClass>.Zero;
        }

        // gets the first house of a type with this name
        public static Pointer<HouseClass> FindBySideName(AnsiString name)
        {
            var idx = SideClass.ABSTRACTTYPE_ARRAY.FindIndex(name);
            return FindBySideIndex(idx);
        }

        // gets the first house of a type from the Civilian side
        public static Pointer<HouseClass> FindCivilianSide()
        {
            return FindBySideName("Civilian");
        }

        public unsafe bool ControlledByHuman()
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, Bool>)0x50B730;
            return func(GetThis());
        }

        // Target ought to be Object, I imagine, but cell doesn't work then
        public unsafe void SendSpyPlanes(int AircraftTypeIdx, int AircraftAmount, Mission SetMission, Pointer<AbstractClass> Target, Pointer<ObjectClass> Destination)
        {
            var func = (delegate* unmanaged[Thiscall]<int, IntPtr, int, int, Mission, IntPtr, IntPtr, void>)ASM.FastCallTransferStation;
            func(0x65EAB0, GetThis(), AircraftTypeIdx, AircraftAmount, SetMission, Target, Destination);
        }

        public unsafe Edge GetCurrentEdge()
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, Edge>)0x50DA80;
            return func(GetThis());
        }
        public unsafe Edge GetStartingEdge()
        {
            var edge = this.StartingEdge;
            if (edge < Edge.North || edge > Edge.West)
                edge = this.GetCurrentEdge();
            return edge;
        }

        [FieldOffset(48)] public int ArrayIndex;

        [FieldOffset(52)] public Pointer<HouseTypeClass> Type;

        [FieldOffset(80)] private byte conyards;
        public ref DynamicVectorClass<Pointer<BuildingClass>> ConYards => ref Pointer<byte>.AsPointer(ref conyards).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(104)] private byte buildings;
        public ref DynamicVectorClass<Pointer<BuildingClass>> Buildings => ref Pointer<byte>.AsPointer(ref buildings).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(128)] private byte unitRepairStations;
        public ref DynamicVectorClass<Pointer<BuildingClass>> UnitRepairStations => ref Pointer<byte>.AsPointer(ref unitRepairStations).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(152)] private byte grinders;
        public ref DynamicVectorClass<Pointer<BuildingClass>> Grinders => ref Pointer<byte>.AsPointer(ref grinders).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(176)] private byte absorbers;
        public ref DynamicVectorClass<Pointer<BuildingClass>> Absorbers => ref Pointer<byte>.AsPointer(ref absorbers).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(200)] private byte bunkers;
        public ref DynamicVectorClass<Pointer<BuildingClass>> Bunkers => ref Pointer<byte>.AsPointer(ref bunkers).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(224)] private byte occupiables;
        public ref DynamicVectorClass<Pointer<BuildingClass>> Occupiables => ref Pointer<byte>.AsPointer(ref occupiables).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(248)] private byte cloningVats;
        public ref DynamicVectorClass<Pointer<BuildingClass>> CloningVats => ref Pointer<byte>.AsPointer(ref cloningVats).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(272)] private byte secretLabs;
        public ref DynamicVectorClass<Pointer<BuildingClass>> SecretLabs => ref Pointer<byte>.AsPointer(ref secretLabs).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(296)] private byte psychicDetectionBuildings;
        public ref DynamicVectorClass<Pointer<BuildingClass>> PsychicDetectionBuildings => ref Pointer<byte>.AsPointer(ref psychicDetectionBuildings).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(320)] private byte factoryPlants;
        public ref DynamicVectorClass<Pointer<BuildingClass>> FactoryPlants => ref Pointer<byte>.AsPointer(ref factoryPlants).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(392)] public double FirepowerMultiplier;

        [FieldOffset(400)] public double GroundspeedMultiplier;

        [FieldOffset(408)] public double AirspeedMultiplier;

        [FieldOffset(416)] public double ArmorMultiplier;

        [FieldOffset(424)] public double ROFMultiplier;

        [FieldOffset(432)] public double CostMultiplier;

        [FieldOffset(440)] public double BuildTimeMultiplier;
        [FieldOffset(464)] public int IQLevel;
        [FieldOffset(468)] public int TechLevel;
        [FieldOffset(480)] public Edge StartingEdge;

        [FieldOffset(492)] public Bool CurrentPlayer;

        [FieldOffset(493)] public Bool PlayerControl;

        [FieldOffset(501)] public Bool Defeated;

        [FieldOffset(502)] public Bool IsGameOver;

        [FieldOffset(503)] public Bool IsWinner;

        [FieldOffset(504)] public Bool IsLoser;

        [FieldOffset(505)] public Bool CiviliansEvacuated;

        [FieldOffset(506)] public Bool FirestormActive;

        [FieldOffset(507)] public Bool HasThreatNode;

        [FieldOffset(508)] public Bool RecheckTechTree;

        [FieldOffset(596)] public DynamicVectorClass<Pointer<SuperClass>> Supers;

        [FieldOffset(724)] public int AirportDocks;

        [FieldOffset(744)] public int OwnedUnits;

        [FieldOffset(748)] public int OwnedNavy;

        [FieldOffset(752)] public int OwnedBuildings;

        [FieldOffset(756)] public int OwnedInfantry;

        [FieldOffset(760)] public int OwnedAircraft;

        [FieldOffset(780)] public int Balance;

        [FieldOffset(21368)] public int NumAirpads;

        [FieldOffset(21372)] public int NumBarracks;

        [FieldOffset(21376)] public int NumWarFactories;

        [FieldOffset(21380)] public int NumConYards;

        [FieldOffset(21384)] public int NumShipyards;

        [FieldOffset(21388)] public int NumOrePurifiers;

        [FieldOffset(21412)] public int PowerOutput;

        [FieldOffset(21416)] public int PowerDrain;

        [FieldOffset(21760)] public CounterClass OwnedBuildingTypes;
        [FieldOffset(21780)] public CounterClass OwnedUnitTypes;
        [FieldOffset(21800)] public CounterClass OwnedInfantryTypes;
        [FieldOffset(21820)] public CounterClass OwnedAircraftTypes;
        public int CountOwnedNow(Pointer<BuildingTypeClass> pItem)
        {
            return OwnedBuildingTypes.GetItemCount(pItem.Ref.ArrayIndex);
        }
        public int CountOwnedNow(Pointer<UnitTypeClass> pItem)
        {
            return OwnedUnitTypes.GetItemCount(pItem.Ref.ArrayIndex);
        }
        public int CountOwnedNow(Pointer<InfantryTypeClass> pItem)
        {
            return OwnedInfantryTypes.GetItemCount(pItem.Ref.ArrayIndex);
        }
        public int CountOwnedNow(Pointer<AircraftTypeClass> pItem)
        {
            return OwnedAircraftTypes.GetItemCount(pItem.Ref.ArrayIndex);
        }
        public int CountOwnedNow(Pointer<TechnoTypeClass> pItem)
        {
            switch(pItem.Ref.BaseAbstractType.Base.WhatAmI())
            {
                case AbstractType.AircraftType:
                    return CountOwnedNow(pItem.Convert<AircraftTypeClass>());
                case AbstractType.UnitType:
                    return CountOwnedNow(pItem.Convert<UnitTypeClass>());
                case AbstractType.InfantryType:
                    return CountOwnedNow(pItem.Convert<InfantryTypeClass>());
                case AbstractType.BuildingType:
                    return CountOwnedNow(pItem.Convert<BuildingTypeClass>());
            }
            return -1;
        }
        [FieldOffset(21840)] public CounterClass ActiveBuildingTypes;
        [FieldOffset(21860)] public CounterClass ActiveUnitTypes;
        [FieldOffset(21880)] public CounterClass ActiveInfantryTypes;
        [FieldOffset(21900)] public CounterClass ActiveAircraftTypes; 
        public int CountOwnedAndPresent(Pointer<BuildingTypeClass> pItem)
        {
            return ActiveBuildingTypes.GetItemCount(pItem.Ref.ArrayIndex);
        }
        public int CountOwnedAndPresent(Pointer<UnitTypeClass> pItem)
        {
            return ActiveUnitTypes.GetItemCount(pItem.Ref.ArrayIndex);
        }
        public int CountOwnedAndPresent(Pointer<InfantryTypeClass> pItem)
        {
            return ActiveInfantryTypes.GetItemCount(pItem.Ref.ArrayIndex);
        }
        public int CountOwnedAndPresent(Pointer<AircraftTypeClass> pItem)
        {
            return ActiveAircraftTypes.GetItemCount(pItem.Ref.ArrayIndex);
        }
        public int CountOwnedAndPresent(Pointer<TechnoTypeClass> pItem)
        {
            switch (pItem.Ref.BaseAbstractType.Base.WhatAmI())
            {
                case AbstractType.AircraftType:
                    return CountOwnedAndPresent(pItem.Convert<AircraftTypeClass>());
                case AbstractType.UnitType:
                    return CountOwnedAndPresent(pItem.Convert<UnitTypeClass>());
                case AbstractType.InfantryType:
                    return CountOwnedAndPresent(pItem.Convert<InfantryTypeClass>());
                case AbstractType.BuildingType:
                    return CountOwnedAndPresent(pItem.Convert<BuildingTypeClass>());
            }
            return -1;
        }

        [FieldOffset(21920)] public CounterClass FactoryProducedBuildingTypes;
        [FieldOffset(21940)] public CounterClass FactoryProducedUnitTypes;
        [FieldOffset(21960)] public CounterClass FactoryProducedInfantryTypes;
        [FieldOffset(21980)] public CounterClass FactoryProducedAircraftTypes; 
        public int CountOwnedEver(Pointer<BuildingTypeClass> pItem)
        {
            return FactoryProducedBuildingTypes.GetItemCount(pItem.Ref.ArrayIndex);
        }
        public int CountOwnedEver(Pointer<UnitTypeClass> pItem)
        {
            return FactoryProducedUnitTypes.GetItemCount(pItem.Ref.ArrayIndex);
        }
        public int CountOwnedEver(Pointer<InfantryTypeClass> pItem)
        {
            return FactoryProducedInfantryTypes.GetItemCount(pItem.Ref.ArrayIndex);
        }
        public int CountOwnedEver(Pointer<AircraftTypeClass> pItem)
        {
            return FactoryProducedAircraftTypes.GetItemCount(pItem.Ref.ArrayIndex);
        }
        public int CountOwnedEver(Pointer<TechnoTypeClass> pItem)
        {
            switch (pItem.Ref.BaseAbstractType.Base.WhatAmI())
            {
                case AbstractType.AircraftType:
                    return CountOwnedEver(pItem.Convert<AircraftTypeClass>());
                case AbstractType.UnitType:
                    return CountOwnedEver(pItem.Convert<UnitTypeClass>());
                case AbstractType.InfantryType:
                    return CountOwnedEver(pItem.Convert<InfantryTypeClass>());
                case AbstractType.BuildingType:
                    return CountOwnedEver(pItem.Convert<BuildingTypeClass>());
            }
            return -1;
        }

        [FieldOffset(22265)] public ColorStruct Color;

        [FieldOffset(22268)] public ColorStruct LaserColor;

        [FieldOffset(22392)] public Bool RecheckPower;

        [FieldOffset(22393)] public Bool RecheckRadar;

        [FieldOffset(22394)] public Bool SpySatActive;

        [FieldOffset(22396)] public Edge Edge;


        [FieldOffset(90196)] public int ColorSchemeIndex;

        public double PowerPercent => PowerOutput != 0 ? (double)PowerDrain / (double)PowerOutput : 1;

        public bool NoPower => PowerPercent >= 1;


        [FieldOffset(0x16804)] public IntPtr align_16804;
        
        [FieldOffset(90100)] private byte ID_first;
        public AnsiStringPointer ID => Pointer<byte>.AsPointer(ref ID_first);

        [FieldOffset(90154)] private char UINameLabel_first;
        public UniStringPointer UIName => Pointer<char>.AsPointer(ref UINameLabel_first); 

    }
}
