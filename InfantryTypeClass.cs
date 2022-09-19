using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 3792)]
    public struct InfantryTypeClass
    {

        public static readonly IntPtr ArrayPointer = new IntPtr(0xA8E348);

        public static YRPP.GLOBAL_DVC_ARRAY<InfantryTypeClass> ABSTRACTTYPE_ARRAY = new YRPP.GLOBAL_DVC_ARRAY<InfantryTypeClass>(ArrayPointer);

        [FieldOffset(0)] public TechnoTypeClass Base;
        [FieldOffset(0)] public ObjectTypeClass BaseObjectType;
        [FieldOffset(0)] public AbstractTypeClass BaseAbstractType;

        [FieldOffset(3756)] public Bool Cyborg;
        [FieldOffset(3757)] public Bool NotHuman;
        [FieldOffset(3758)] public Bool Ivan;
        [FieldOffset(3764)] public Bool Occupier;
        [FieldOffset(3765)] public Bool Assaulter;
        [FieldOffset(3772)] public Bool Fearless;
        [FieldOffset(3773)] public Bool Crawls;
        [FieldOffset(3774)] public Bool Infiltrate;
        [FieldOffset(3775)] public Bool Fraidycat;
        [FieldOffset(3776)] public Bool TiberiumProof;
        [FieldOffset(3777)] public Bool Civilian;
        [FieldOffset(3778)] public Bool C4;
        [FieldOffset(3779)] public Bool Engineer;
        [FieldOffset(3780)] public Bool Agent;
        [FieldOffset(3781)] public Bool Thief;
        [FieldOffset(3782)] public Bool VehicleThief;
        [FieldOffset(3783)] public Bool Doggie;
        [FieldOffset(3784)] public Bool Deployer;
        [FieldOffset(3785)] public Bool DeployedCrushable;
        [FieldOffset(3786)] public Bool UseOwnName;
        [FieldOffset(3787)] public Bool JumpJetTurn;

    }
}
