using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    public static class Cast
    {
        public static bool CastToTechno(this Pointer<AbstractClass> pAbstract, out Pointer<TechnoClass> pTechno)
        {
            if (pAbstract.Ref.AbstractFlags.HasFlag(AbstractFlags.Techno))
            {
                pTechno = pAbstract.Convert<TechnoClass>();
                return true;
            }
            pTechno = Pointer<TechnoClass>.Zero;
            return false;
        }
        public static bool CastToTechno(this Pointer<ObjectClass> pObject, out Pointer<TechnoClass> pTechno)
        {
            return pObject.Convert<AbstractClass>().CastToTechno(out pTechno);
        }

        public static bool CastToObject(this Pointer<AbstractClass> pAbstract, out Pointer<ObjectClass> pObject)
        {
            if (pAbstract.Ref.AbstractFlags.HasFlag(AbstractFlags.Object))
            {
                pObject = pAbstract.Convert<ObjectClass>();
                return true;
            }
            pObject = Pointer<ObjectClass>.Zero;
            return false;
        }

        public static bool CastToFoot(this Pointer<AbstractClass> pAbstract, out Pointer<FootClass> pFoot)
        {
            if (pAbstract.Ref.AbstractFlags.HasFlag(AbstractFlags.Foot))
            {
                pFoot = pAbstract.Convert<FootClass>();
                return true;
            }
            pFoot = Pointer<FootClass>.Zero;
            return false;
        }
        public static bool CastToFoot(this Pointer<ObjectClass> pObject, out Pointer<FootClass> pFoot)
        {
            return pObject.Convert<AbstractClass>().CastToFoot(out pFoot);
        }
        public static bool CastToFoot(this Pointer<TechnoClass> pTechno, out Pointer<FootClass> pFoot)
        {
            return pTechno.Convert<AbstractClass>().CastToFoot(out pFoot);
        }

        public static bool CastIf<To>(this Pointer<AbstractClass> pAbstract, AbstractType type, out Pointer<To> ptr)
        {
            if (pAbstract.Ref.WhatAmI() == type)
            {
                ptr = pAbstract.Convert<To>();
                return true;
            }

            ptr = Pointer<To>.Zero;
            return false;
        }
        public static bool CastIf<To>(this Pointer<ObjectClass> pObject, AbstractType type, out Pointer<To> ptr)
        {
            return CastIf(pObject.Convert<AbstractClass>(), type, out ptr);
        }
        public static bool CastIf<To>(this Pointer<TechnoClass> pTechno, AbstractType type, out Pointer<To> ptr)
        {
            return CastIf(pTechno.Convert<AbstractClass>(), type, out ptr);
        }
        public static bool CastIf<To>(this Pointer<FootClass> pFoot, AbstractType type, out Pointer<To> ptr)
        {
            return CastIf(pFoot.Convert<AbstractClass>(), type, out ptr);
        }
    }
}
