using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DynamicPatcher;

namespace PatcherYRpp
{
    public class YRPP
    {
        public class ABSTRACTTYPE_ARRAY<T>
        {
            public Pointer<DynamicVectorClass<Pointer<T>>> Pointer;
            public ref DynamicVectorClass<Pointer<T>> Array { get => ref Pointer.Ref; }

            public ABSTRACTTYPE_ARRAY(IntPtr pVector)
            {
                Pointer = pVector;
            }

            public Pointer<T> Find(string ID)
            {
                int idx = FindIndex(ID);
                if (idx >= 0)
                {
                    return Array.Get(idx);
                }

                return Pointer<T>.Zero;
            }

            public int FindIndex(string ID)
            {
                for (int i = 0; i < Array.Count; i++)
                {
                    Pointer<AbstractTypeClass> pItem = Array[i].Convert<AbstractTypeClass>();
                    if (pItem.Ref.ID == ID)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        static YRPP()
        {
        }
    }
}
