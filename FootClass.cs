using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 1728)]
    public struct FootClass
    {

        public unsafe bool MoveTo(CoordStruct where)
        {
            var func = (delegate* unmanaged[Thiscall]<ref FootClass, IntPtr, bool>)this.GetVirtualFunctionPointer(319);
            return func(ref this, Pointer<CoordStruct>.AsPointer(ref where));
        }

        public unsafe bool StopDrive()
        {
            var func = (delegate* unmanaged[Thiscall]<ref FootClass, bool>)this.GetVirtualFunctionPointer(320);
            return func(ref this);
        }

        public unsafe bool ChronoWarpTo(CoordStruct where)
        {
            var func = (delegate* unmanaged[Thiscall]<ref FootClass, IntPtr, bool>)this.GetVirtualFunctionPointer(322);
            return func(ref this, Pointer<CoordStruct>.AsPointer(ref where));
        }

        public unsafe void Panic()
        {
            var func = (delegate* unmanaged[Thiscall]<ref FootClass, void>)this.GetVirtualFunctionPointer(326);
            func(ref this);
        }

        public unsafe void UnPanic()
        {
            var func = (delegate* unmanaged[Thiscall]<ref FootClass, void>)this.GetVirtualFunctionPointer(327);
            func(ref this);
        }

        public unsafe int GetCurrentSpeed()
        {
            var func = (delegate* unmanaged[Thiscall]<ref FootClass, int>)this.GetVirtualFunctionPointer(334);
            return func(ref this);
        }

        public unsafe bool StopMoving()
        {
            var func = (delegate* unmanaged[Thiscall]<ref FootClass, bool>)this.GetVirtualFunctionPointer(338);
            return func(ref this);
        }

        public unsafe void AbortMotion()
        {
            var func = (delegate* unmanaged[Thiscall]<ref FootClass, void>)0x4DF0D0;
            func(ref this);
        }

        public unsafe bool Jumpjet_LocationClear()
        {
            var func = (delegate* unmanaged[Thiscall]<ref FootClass, Bool>)0x4135A0;
            return func(ref this);
        }

        public unsafe void Jumpjet_OccupyCell(CellStruct cell)
        {
            var func = (delegate* unmanaged[Thiscall]<ref FootClass, CellStruct, void>)0x4E00B0;
            func(ref this, cell);
        }

        [FieldOffset(0)] public TechnoClass Base;
        [FieldOffset(0)] public RadioClass BaseRadio;
        [FieldOffset(0)] public MissionClass BaseMission;
        [FieldOffset(0)] public ObjectClass BaseObject;
        [FieldOffset(0)] public AbstractClass BaseAbstract;

        [FieldOffset(1368)] public CellStruct CurrentMapCoords;
        [FieldOffset(1372)] public CellStruct LastMapCoords;
        [FieldOffset(1376)] public CellStruct LastJumpjetMapCoords;
        [FieldOffset(1384)] public CellStruct CurrentJumpjetMapCoords;
        [FieldOffset(1408)] public double SpeedMultiplier;
        [FieldOffset(1444)] public Pointer<AbstractClass> Destination;
        [FieldOffset(1448)] public Pointer<AbstractClass> LastDestination;
        [FieldOffset(1540)] public int PathDirections;
        [FieldOffset(1600)] public TimerStruct PathDelayTimer;
        [FieldOffset(1616)] public TimerStruct BaseAttackTimer;
        [FieldOffset(1628)] public TimerStruct SightTimer;
        [FieldOffset(1640)] public TimerStruct BlockagePathTimer;



        [FieldOffset(1652)] public COMPtr<ILocomotion> locomotor;

        public ILocomotion Locomotor
        {
            get => locomotor.Object;
            set
            {
                locomotor.Release();
                locomotor.Object = value;
            }
        }
    }
}
