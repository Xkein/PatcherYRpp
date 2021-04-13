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
        public unsafe bool Remove()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, byte>)Helpers.GetVirtualFunctionPointer(Pointer<ObjectClass>.AsPointer(ref this), 53);
            return Convert.ToBoolean(func(ref this));
        }
        public unsafe bool Put(CoordStruct coord, Direction faceDir)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, ref CoordStruct, Direction, byte>)Helpers.GetVirtualFunctionPointer(Pointer<ObjectClass>.AsPointer(ref this), 54);
            return Convert.ToBoolean(func(ref this, ref coord, faceDir));
        }

        public unsafe void SetLocation(CoordStruct coord)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, ref CoordStruct, void>)Helpers.GetVirtualFunctionPointer(Pointer<ObjectClass>.AsPointer(ref this), 109);
            func(ref this, ref coord);
        }

        public unsafe int GetHeight()
        {
            var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, int>)Helpers.GetVirtualFunctionPointer(Pointer<ObjectClass>.AsPointer(ref this), 114);
            return func(ref this);
        }

        [FieldOffset(0)]
        public AbstractClass Base;

        [FieldOffset(44)] public int FallRate; //how fast is it falling down? only works if FallingDown is set below, and actually positive numbers will move the thing UPWARDS
        [FieldOffset(48)] private IntPtr nextObject;    //Next Object in the same cell or transport. This is a linked list of Objects.
        public Pointer<ObjectClass> NextObject { get => nextObject; set => nextObject = value; }

        [FieldOffset(100)] public int CustomSound;
        [FieldOffset(104)] public byte BombVisible; // In range of player's bomb seeing units, so should draw it

        [FieldOffset(108)] public int Health;     //The current Health.
        [FieldOffset(112)] public int EstimatedHealth; // used for auto-targeting threat estimation
        [FieldOffset(116)] public byte IsOnMap; // has this object been placed on the map?

        [FieldOffset(128)] public byte NeedsRedraw;
        [FieldOffset(129)] public byte InLimbo; // act as if it doesn't exist - e.g., post mortem state before being deleted
        [FieldOffset(130)] public byte InOpenToppedTransport;
        [FieldOffset(131)] public byte IsSelected;    //Has the player selected this Object?
        [FieldOffset(132)] public byte HasParachute;  //Is this Object parachuting?

        [FieldOffset(136)] private IntPtr parachute;       //Current parachute Anim.
        public Pointer<AnimClass> Parachute { get => parachute; set => parachute = value; }
        [FieldOffset(140)] public byte OnBridge;
        [FieldOffset(141)] public byte IsFallingDown;
        [FieldOffset(142)] public byte WasFallingDown; // last falling state when FootClass::Update executed. used to find out whether it changed.
        [FieldOffset(143)] public byte IsABomb; // if set, will explode after FallingDown brings it to contact with the ground
        [FieldOffset(144)] public byte IsAlive;       //Self-explanatory.

        [FieldOffset(148)] public Layer LastLayer;
        [FieldOffset(152)] public byte IsInLogic; // has this object been added to the logic collection?
        [FieldOffset(153)] public byte IsVisible; // was this object in viewport when drawn?

        [FieldOffset(156)] public CoordStruct Location; //Absolute current 3D location (in leptons)
    }
}
