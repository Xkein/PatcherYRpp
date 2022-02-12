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
        [FieldOffset(0)] public TechnoClass Base;


        [FieldOffset(1652)] public COMPtr<ILocomotion> locomotor;
        public ILocomotion Locomotor { get => locomotor.Object; set => locomotor.Object = value; }

    }
}
