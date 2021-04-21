using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
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

        [FieldOffset(0)]  public ObjectClass Base;

        [FieldOffset(540)] private IntPtr owner;
        public Pointer<HouseClass> Owner { get => owner; set => owner = value; }

        [FieldOffset(664)] public Bool Berzerk;

        [FieldOffset(692)] public Pointer<AbstractClass> Target; //if attacking
        [FieldOffset(696)] public Pointer<AbstractClass> LastTarget;
    }
}
