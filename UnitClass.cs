﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 2280)]
    public struct UnitClass
    {
        public static readonly IntPtr ArrayPointer = new IntPtr(0x8B4108);
        public static ref DynamicVectorClass<Pointer<UnitClass>> Array { get => ref DynamicVectorClass<Pointer<UnitClass>>.GetDynamicVector(ArrayPointer); }

        [FieldOffset(0)] public FootClass Base;
        [FieldOffset(0)] public TechnoClass BaseTechno;
        [FieldOffset(0)] public RadioClass BaseRadio;
        [FieldOffset(0)] public MissionClass BaseMission;
        [FieldOffset(0)] public ObjectClass BaseObject;
        [FieldOffset(0)] public AbstractClass BaseAbstract;

        [FieldOffset(1732)] public Pointer<UnitTypeClass> Type;
        [FieldOffset(1736)] public IntPtr FollowerCar;
        [FieldOffset(1744)] public Bool HasFollowerCar;
        [FieldOffset(1745)] public Bool Unloading;
        [FieldOffset(1752)] public int DeathFrameCounter;
        [FieldOffset(1760)] public Bool Deployed;
        [FieldOffset(1761)] public Bool Deploying;
        [FieldOffset(1762)] public Bool Undeploying;

    }
}
