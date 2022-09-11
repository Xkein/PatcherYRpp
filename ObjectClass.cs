using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 172)]
    public struct ObjectClass
    {
        static public readonly IntPtr CurrentObjectsPointer = new IntPtr(0xA8ECB8);
        static public ref DynamicVectorClass<Pointer<ObjectClass>> CurrentObjects { get => ref DynamicVectorClass<Pointer<ObjectClass>>.GetDynamicVector(CurrentObjectsPointer); }

        static public readonly IntPtr ArrayPointer = new IntPtr(0xA8E360);
        static public ref DynamicVectorClass<Pointer<ObjectClass>> Array { get => ref DynamicVectorClass<Pointer<ObjectClass>>.GetDynamicVector(ArrayPointer); }


        static public readonly IntPtr ObjectsInLayersPointer = new IntPtr(0x8A0360);

        public unsafe Pointer<TechnoTypeClass> GetTechnoType()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, IntPtr>)this.GetVirtualFunctionPointer(33);
            return func(ref this);
        }

        public unsafe Pointer<ObjectTypeClass> GetObjectType()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, IntPtr>)this.GetVirtualFunctionPointer(34);
            return func(ref this);
        }

        public unsafe CoordStruct GetFLH(int idxWeapon, CoordStruct BaseCoords)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, out CoordStruct, int, CoordStruct, IntPtr>)this.GetVirtualFunctionPointer(44);
            func(ref this, out CoordStruct result, idxWeapon, BaseCoords);
            return result;
        }

        public unsafe bool Remove()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, Bool>)this.GetVirtualFunctionPointer(53);
            return func(ref this);
        }
        public unsafe bool Put(CoordStruct coord, Direction faceDir)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, ref CoordStruct, Direction, Bool>)this.GetVirtualFunctionPointer(54);
            return func(ref this, ref coord, faceDir);
        }
        public unsafe void Disappear(bool permanently)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, Bool, void>)this.GetVirtualFunctionPointer(55);
            func(ref this, permanently);
        }
        public unsafe void RegisterDestruction(Pointer<TechnoClass> Destroyer)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, IntPtr, void>)this.GetVirtualFunctionPointer(56);
            func(ref this, Destroyer);
        }
        public unsafe void RegisterKill(Pointer<HouseClass> Destroyer)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, IntPtr, void>)this.GetVirtualFunctionPointer(57);
            func(ref this, Destroyer);
        }
        public unsafe bool SpawnParachuted(CoordStruct coord)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, ref CoordStruct, Bool>)this.GetVirtualFunctionPointer(58);
            return func(ref this, ref coord);
        }
        public unsafe void DropAsBomb()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, void>)this.GetVirtualFunctionPointer(59);
            func(ref this);
        }
        public unsafe void MarkAllOccupationBits(CoordStruct coord)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, ref CoordStruct, void>)this.GetVirtualFunctionPointer(60);
            func(ref this, ref coord);
        }
        public unsafe void UnmarkAllOccupationBits(CoordStruct coord)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, ref CoordStruct, void>)this.GetVirtualFunctionPointer(61);
            func(ref this, ref coord);
        }
        public unsafe void UnInit()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, void>)this.GetVirtualFunctionPointer(62);
            func(ref this);
        }
        public unsafe void Reveal()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, void>)this.GetVirtualFunctionPointer(63);
            func(ref this);
        }

        public unsafe void Undiscover()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, void>)this.GetVirtualFunctionPointer(71);
            func(ref this);
        }
        public unsafe void See(uint dwUnk, uint dwUnk2)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, uint, uint, void>)this.GetVirtualFunctionPointer(72);
            func(ref this, dwUnk, dwUnk2);
        }
        public unsafe bool UpdatePlacement(PlacementType placementType)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, PlacementType, Bool>)this.GetVirtualFunctionPointer(73);
            return func(ref this, placementType);
        }

        public unsafe void DrawRadialIndicator(uint dwUnk)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, uint, void>)this.GetVirtualFunctionPointer(76);
            func(ref this, dwUnk);
        }
        public unsafe void MarkForRedraw()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, void>)this.GetVirtualFunctionPointer(77);
            func(ref this);
        }
        public unsafe bool CanBeSelected()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, Bool>)this.GetVirtualFunctionPointer(78);
            return func(ref this);
        }
        public unsafe bool CanBeSelectedNow()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, Bool>)this.GetVirtualFunctionPointer(79);
            return func(ref this);
        }

        public unsafe bool ClickedAction(Action action, Pointer<ObjectClass> pTarget, bool bUnk)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, Action, IntPtr, Bool, Bool>)this.GetVirtualFunctionPointer(81);
            return func(ref this, action, pTarget, bUnk);
        }
        public unsafe void Flash(int duration)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, int, void>)this.GetVirtualFunctionPointer(82);
            func(ref this, duration);
        }
        public unsafe bool Select()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, Bool>)this.GetVirtualFunctionPointer(83);
            return func(ref this);
        }
        public unsafe void Deselect()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, void>)this.GetVirtualFunctionPointer(84);
            func(ref this);
        }


        public unsafe Mission GetCurrentMission()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, Mission>)
                Helpers.GetVirtualFunctionPointer(Pointer<ObjectClass>.AsPointer(ref this), 97);
            return func(ref this);
        }

        public unsafe void RestoreMission(Mission mission)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, Mission, void>)
                Helpers.GetVirtualFunctionPointer(Pointer<ObjectClass>.AsPointer(ref this), 98);
            func(ref this, mission);
        }


        //from kratos
        public unsafe DamageState TakeDamage(int damage, Pointer<WarheadTypeClass> pWH, bool crewed)
        {
            return TakeDamage(damage, pWH, IntPtr.Zero, IntPtr.Zero, crewed);
        }

        public unsafe DamageState TakeDamage(int damage, Pointer<WarheadTypeClass> pWH, Pointer<ObjectClass> pAttacker, Pointer<HouseClass> pAttackingHouse, bool crewed)
        {
            return ReceiveDamage(Pointer<int>.AsPointer(ref damage), 0, pWH, pAttacker, true, !crewed, pAttackingHouse);
        }


        public unsafe DamageState ReceiveDamage(Pointer<int> pDamage, int DistanceFromEpicenter, Pointer<WarheadTypeClass> pWH,
            Pointer<ObjectClass> pAttacker, bool IgnoreDefenses, bool PreventPassengerEscape, Pointer<HouseClass> pAttackingHouse)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, IntPtr, int, IntPtr, IntPtr, Bool, Bool, IntPtr, DamageState>)this.GetVirtualFunctionPointer(91);
            return func(ref this, pDamage, DistanceFromEpicenter, pWH, pAttacker, IgnoreDefenses, PreventPassengerEscape, pAttackingHouse);
        }

        public unsafe void Scatter(CoordStruct crd, bool ignoreMission, bool ignoreDestination)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, ref CoordStruct, Bool, Bool, void>)this.GetVirtualFunctionPointer(93);
            func(ref this, ref crd, ignoreMission, ignoreDestination);
        }

        public unsafe bool DiscoveredBy(Pointer<HouseClass> pHouse)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, IntPtr, Bool>)this.GetVirtualFunctionPointer(102);
            return func(ref this, pHouse);
        }

        public unsafe void SetLocation(CoordStruct coord)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, ref CoordStruct, void>)this.GetVirtualFunctionPointer(109);
            func(ref this, ref coord);
        }

        public unsafe int GetHeight()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, int>)this.GetVirtualFunctionPointer(114);
            return func(ref this);
        }


        [FieldOffset(0)] public AbstractClass Base;

        [FieldOffset(44)] public int FallRate; //how fast is it falling down? only works if FallingDown is set below, and actually positive numbers will move the thing UPWARDS
        [FieldOffset(48)] private IntPtr nextObject;    //Next Object in the same cell or transport. This is a linked list of Objects.
        public Pointer<ObjectClass> NextObject { get => nextObject; set => nextObject = value; }

        [FieldOffset(100)] public int CustomSound;
        [FieldOffset(104)] public Bool BombVisible; // In range of player's bomb seeing units, so should draw it

        [FieldOffset(108)] public int Health;     //The current Health.
        [FieldOffset(112)] public int EstimatedHealth; // used for auto-targeting threat estimation
        [FieldOffset(116)] public Bool IsOnMap; // has this object been placed on the map?

        [FieldOffset(128)] public Bool NeedsRedraw;
        [FieldOffset(129)] public Bool InLimbo; // act as if it doesn't exist - e.g., post mortem state before being deleted
        [FieldOffset(130)] public Bool InOpenToppedTransport;
        [FieldOffset(131)] public Bool IsSelected;    //Has the player selected this Object?
        [FieldOffset(132)] public Bool HasParachute;  //Is this Object parachuting?

        [FieldOffset(136)] private IntPtr parachute;       //Current parachute Anim.
        public Pointer<AnimClass> Parachute { get => parachute; set => parachute = value; }
        [FieldOffset(140)] public Bool OnBridge;
        [FieldOffset(141)] public Bool IsFallingDown;
        [FieldOffset(142)] public Bool WasFallingDown; // last falling state when FootClass::Update executed. used to find out whether it changed.
        [FieldOffset(143)] public Bool IsABomb; // if set, will explode after FallingDown brings it to contact with the ground
        [FieldOffset(144)] public Bool IsAlive;       //Self-explanatory.

        [FieldOffset(148)] public Layer LastLayer;
        [FieldOffset(152)] public Bool IsInLogic; // has this object been added to the logic collection?
        [FieldOffset(153)] public Bool IsVisible; // was this object in viewport when drawn?

        [FieldOffset(156)] public CoordStruct Location; //Absolute current 3D location (in leptons)
    }
}
