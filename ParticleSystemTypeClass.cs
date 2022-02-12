using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 784)]
    public struct ParticleSystemTypeClass
    {
        [FieldOffset(0)] public ObjectTypeClass Base;
        [FieldOffset(0)] public AbstractTypeClass BaseAbstractType;

    }
}
