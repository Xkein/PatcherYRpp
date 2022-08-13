using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 1824)]
    public struct BuildingClass : IOwnAbstractType<BuildingTypeClass>
    {
        Pointer<BuildingTypeClass> IOwnAbstractType<BuildingTypeClass>.OwnType => Type;
        Pointer<AbstractTypeClass> IOwnAbstractType.AbstractType => Type.Convert<AbstractTypeClass>();

        private static readonly IntPtr ArrayPointer = new IntPtr(0xA8EB40);
        public static ref DynamicVectorClass<Pointer<BuildingClass>> Array { get => ref DynamicVectorClass<Pointer<BuildingClass>>.GetDynamicVector(ArrayPointer); }


        public unsafe void GoOnline()
        {
            var func = (delegate* unmanaged[Thiscall]<ref BuildingClass,  void>)0x452260;
            func(ref this);
        }

        public unsafe void GoOffline()
        {
            var func = (delegate* unmanaged[Thiscall]<ref BuildingClass, void>)0x452360;
            func(ref this);
        }


        public unsafe int GetPowerOutput()
        {
            var func = (delegate* unmanaged[Thiscall]<ref BuildingClass, int>)0x44E7B0;
            return func(ref this);
        }
        public unsafe int GetPowerDrain()
        {
            var func = (delegate* unmanaged[Thiscall]<ref BuildingClass, int>)0x44E880;
            return func(ref this);
        }

        [FieldOffset(0)] public TechnoClass Base;
        [FieldOffset(0)] public RadioClass BaseRadio;
        [FieldOffset(0)] public MissionClass BaseMission;
        [FieldOffset(0)] public ObjectClass BaseObject;
        [FieldOffset(0)] public AbstractClass BaseAbstract;

        [FieldOffset(1312)] public Pointer<BuildingTypeClass> Type;

        //[FieldOffset(1316)] public Pointer<FactoryClass> Factory;

        [FieldOffset(1516)] private IntPtr upgrade0;
        [FieldOffset(1520)] private IntPtr upgrade1;
        [FieldOffset(1524)] private IntPtr upgrade2;
        public Pointer<BuildingTypeClass>[] Upgrades
        {
            get => new Pointer<BuildingTypeClass>[3]
            {
                upgrade0.Convert<BuildingTypeClass>(),upgrade1.Convert<BuildingTypeClass>(),upgrade2.Convert<BuildingTypeClass>()
            };
        }

        [FieldOffset(1632)] public Bool HasPower;

        [FieldOffset(1633)] public Bool IsOverpowered;

        [FieldOffset(1736)] public Bool WasOnline;
        [FieldOffset(1738)] public Bool BeingProduced;
        [FieldOffset(1739)] public Bool ShouldRebuild;
        [FieldOffset(1740)] public Bool HasEngineer;
        [FieldOffset(1757)] public Bool unknown_bool_6DD;
        public bool IsReadyToCommence
        {
            get => unknown_bool_6DD; 
            set => unknown_bool_6DD = value; 
        }
        [FieldOffset(1758)] public Bool NeedsRepairs;
        [FieldOffset(1759)] public Bool C4Applied;
        [FieldOffset(1760)] public Bool NoCrew;

        [FieldOffset(1763)] public Bool HasBeenCaptured;
        [FieldOffset(1764)] public Bool ActuallyPlacedOnMap;
        [FieldOffset(1766)] public Bool IsDamaged;
        [FieldOffset(1767)] public Bool IsFogged;
        [FieldOffset(1768)] public Bool IsBeingRepaired;


        public bool HasSuperWeapon(int index)
        {
            if (Type.Ref.HasSuperWeapon(index))
                return true;
            foreach(var pType in Upgrades)
            {
                if (pType.IsNotNull && pType.Ref.HasSuperWeapon(index))
                    return true;
            }
            return false;
        }
    }
}
