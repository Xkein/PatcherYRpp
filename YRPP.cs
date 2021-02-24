using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    public class YRPP
    {
        public class ABSTRACTTYPE_ARRAY<T>
        {
            Pointer<DynamicVectorClass<Pointer<T>>> Pointer;
            ref DynamicVectorClass<Pointer<T>> Array { get => ref Pointer.Ref; }
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
                    if (pItem.Ref.GetID() == ID)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        static YRPP()
        {
            Type type = typeof(YRPP);
            MethodInfo method = type.GetMethod("JMP");
        }

        static public void JMP(int address)
        {
            return;
        }

    }
}
