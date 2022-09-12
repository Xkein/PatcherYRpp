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

        public unsafe bool ControlledByHuman()
        {
            bool result = CurrentPlayer;
            return result;
        }
        public unsafe bool ControlledByPlayer()
        {
            bool result = CurrentPlayer || PlayerControl;
            return result;
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

        public void TransactMoney(int amount)
        {
            if (amount > 0)
            {
                GiveMoney(amount);
            }
            else
            {
                TakeMoney(-amount);
            }
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

        public unsafe int Available_Money()
        {
            var func = (delegate* unmanaged[Stdcall]<IntPtr, int>)this.GetVirtualFunctionPointer(6, tableIndex: 9);
            return func(GetThis().RawOffset(36));
        }

        [FieldOffset(48)] public int ArrayIndex;

        [FieldOffset(52)] public Pointer<HouseTypeClass> Type;


        [FieldOffset(80)] public byte conyards;
        public ref DynamicVectorClass<Pointer<BuildingClass>> ConYards => ref Pointer<byte>.AsPointer(ref conyards).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(104)] public byte buildings;
        public ref DynamicVectorClass<Pointer<BuildingClass>> Buildings => ref Pointer<byte>.AsPointer(ref buildings).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(128)] public byte unitRepairStations;
        public ref DynamicVectorClass<Pointer<BuildingClass>> UnitRepairStations => ref Pointer<byte>.AsPointer(ref unitRepairStations).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(152)] public byte grinders;
        public ref DynamicVectorClass<Pointer<BuildingClass>> Grinders => ref Pointer<byte>.AsPointer(ref grinders).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(176)] public byte absorbers;
        public ref DynamicVectorClass<Pointer<BuildingClass>> Absorbers => ref Pointer<byte>.AsPointer(ref absorbers).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(200)] public byte bunkers;
        public ref DynamicVectorClass<Pointer<BuildingClass>> Bunkers => ref Pointer<byte>.AsPointer(ref bunkers).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(224)] public byte occupiables;
        public ref DynamicVectorClass<Pointer<BuildingClass>> Occupiables => ref Pointer<byte>.AsPointer(ref occupiables).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(248)] public byte cloningVats;
        public ref DynamicVectorClass<Pointer<BuildingClass>> CloningVats => ref Pointer<byte>.AsPointer(ref cloningVats).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(272)] public byte secretLabs;
        public ref DynamicVectorClass<Pointer<BuildingClass>> SecretLabs => ref Pointer<byte>.AsPointer(ref secretLabs).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(296)] public byte psychicDetectionBuildings;
        public ref DynamicVectorClass<Pointer<BuildingClass>> PsychicDetectionBuildings => ref Pointer<byte>.AsPointer(ref psychicDetectionBuildings).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(320)] public byte factoryPlants;
        public ref DynamicVectorClass<Pointer<BuildingClass>> FactoryPlants => ref Pointer<byte>.AsPointer(ref factoryPlants).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

        [FieldOffset(392)] public double FirepowerMultiplier;
        [FieldOffset(400)] public double GroundspeedMultiplier;
        [FieldOffset(408)] public double AirspeedMultiplier;
        [FieldOffset(416)] public double ArmorMultiplier;
        [FieldOffset(424)] public double ROFMultiplier;
        [FieldOffset(432)] public double CostMultiplier;
        [FieldOffset(440)] public double BuildTimeMultiplier;
        [FieldOffset(480)] public Edge StartingEdge;
        [FieldOffset(492)] public Bool CurrentPlayer;
        [FieldOffset(493)] public Bool PlayerControl;
        [FieldOffset(501)] public Bool Defeated;
        [FieldOffset(502)] public Bool IsGameOver;
        [FieldOffset(503)] public Bool IsWinner;
        [FieldOffset(504)] public Bool IsLoser;
        [FieldOffset(508)] public Bool RecheckTechTree;
        [FieldOffset(596)] public DynamicVectorClass<Pointer<SuperClass>> Supers;


        [FieldOffset(21556)]public int TotalKilledUnits;

        [FieldOffset(21640)] public int TotalKilledBuildings;

        [FieldOffset(21736)] public int SiloMoney;

        [FieldOffset(22265)] public ColorStruct Color;

        [FieldOffset(22268)] public ColorStruct LaserColor;

        [FieldOffset(22396)] public Edge Edge;
    }
}
