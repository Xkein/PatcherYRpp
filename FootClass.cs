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
        [FieldOffset(0)] public RadioClass BaseRadio;
        [FieldOffset(0)] public MissionClass BaseMission;
        [FieldOffset(0)] public ObjectClass BaseObject;
        [FieldOffset(0)] public AbstractClass BaseAbstract;


        [FieldOffset(1652)] public COMPtr<ILocomotion> locomotor;

        public ILocomotion Locomotor
        {
            get => locomotor.Object;
            set
            {
                locomotor.Release();
                locomotor.Object = value;
            }
        }
    }
}
