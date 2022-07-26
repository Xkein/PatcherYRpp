using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PatcherYRpp.FileFormats;
using DynamicPatcher;


namespace PatcherYRpp
{

    public enum SpawnManagerStatus
    {
        Idle = 0, // no target or out of range
        Launching = 1, // one launch in progress
        CoolDown = 2 // waiting for launch to complete
    }

    public enum SpawnNodeStatus
    {
        Idle = 0, // docked, waiting for target
        TakeOff = 1, // missile tilting and launch
        Preparing = 2, // gathering, waiting
        Attacking = 3, // attacking until no ammo
        Returning = 4, // return to carrier
                       //Unused_5, // not used
        Reloading = 6, // docked, reloading ammo and health
        Dead = 7 // respawning
    }

    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public struct SpawnNode
    {
        [FieldOffset(0)] public Pointer<TechnoClass> Unit;

        [FieldOffset(4)] public SpawnNodeStatus Status;


        [FieldOffset(20)] public Bool IsSpawnMissile;

    }


    [StructLayout(LayoutKind.Explicit, Size = 116)]
    public struct SpawnManagerClass
    {

        public unsafe void SetTarget(Pointer<AbstractClass> target)
        {
            var func = (delegate* unmanaged[Thiscall]<ref SpawnManagerClass, IntPtr, void>)0x6B7B90;
            func(ref this, target);
        }

        public unsafe void ResetTarget()
        {
            var func = (delegate* unmanaged[Thiscall]<ref SpawnManagerClass, IntPtr>)0x6B7BB0;
            func(ref this);
        }

        [FieldOffset(36)] public IntPtr owner;
        public Pointer<TechnoClass> Owner { get => owner; set => owner = value; }

        [FieldOffset(40)] public IntPtr spawnType;
        public Pointer<AircraftTypeClass> SpawnType { get => spawnType; set => spawnType = value; }

        [FieldOffset(44)] public int SpawnCount;

        [FieldOffset(48)] public int RegenRate;

        [FieldOffset(52)] public int ReloadRate;

        [FieldOffset(56)] public byte spawnedNodes;
        public ref DynamicVectorClass<Pointer<SpawnNode>> SpawnedNodes => ref Pointer<byte>.AsPointer(ref spawnedNodes).Convert<DynamicVectorClass<Pointer<SpawnNode>>>().Ref;

        [FieldOffset(104)] public IntPtr destination;
        public Pointer<AbstractClass> Destination { get => destination; set => destination = value; }

        [FieldOffset(108)] public IntPtr target;
        public Pointer<AbstractClass> Target { get => target; set => target = value; }

        [FieldOffset(112)] public SpawnManagerStatus Status;

    }
}
