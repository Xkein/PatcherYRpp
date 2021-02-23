using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 760)]
    public struct BulletTypeClass
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate IntPtr CreateBulletDelegate(IntPtr Target, /*Pointer<TechnoClass> Owner @edx, */int Damage, IntPtr WH, int Speed, bool Bright);
        static public CreateBulletDelegate CreateBulletDlg = Marshal.GetDelegateForFunctionPointer<CreateBulletDelegate>(new IntPtr(0x46B050));
        public Pointer<BulletClass> CreateBullet(Pointer<AbstractClass> Target, Pointer<TechnoClass> Owner, int Damage, Pointer<WarheadTypeClass> WH, int Speed, bool Bright)
        {
            Pointer<BulletClass> ret = CreateBulletDlg(Target, Damage, WH, Speed, Bright);
            ret.Ref.Owner = Owner;
            return ret;
        }

        [FieldOffset(0)]
        public ObjectTypeClass Base;

		[FieldOffset(660)] public byte Airburst;
		[FieldOffset(661)] public byte Floater;
		[FieldOffset(662)] public byte SubjectToCliffs;
		[FieldOffset(663)] public byte SubjectToElevation;
		[FieldOffset(664)] public byte SubjectToWalls;
		[FieldOffset(665)] public byte VeryHigh;
		[FieldOffset(666)] public byte Shadow;
		[FieldOffset(667)] public byte Arcing;
		[FieldOffset(668)] public byte Dropping;
		[FieldOffset(669)] public byte Level;
		[FieldOffset(670)] public byte Inviso;
		[FieldOffset(671)] public byte Proximity;
		[FieldOffset(672)] public byte Ranged;
		[FieldOffset(673)] public byte NoRotate; // actually has opposite meaning of Rotates. false means Rotates=yes.
		[FieldOffset(674)] public byte Inaccurate;
		[FieldOffset(675)] public byte FlakScatter;
		[FieldOffset(676)] public byte AA;
		[FieldOffset(677)] public byte AG;
		[FieldOffset(678)] public byte Degenerates;
		[FieldOffset(679)] public byte Bouncy;
		[FieldOffset(680)] public byte AnimPalette;
		[FieldOffset(681)] public byte FirersPalette;

		[FieldOffset(684)] public int Cluster;
		[FieldOffset(688)] public Pointer<WeaponTypeClass> AirburstWeapon;
		[FieldOffset(692)] public Pointer<WeaponTypeClass> ShrapnelWeapon;
		[FieldOffset(696)] public int ShrapnelCount;
		[FieldOffset(700)] public int DetonationAltitude;
		[FieldOffset(704)] public byte Vertical;

		[FieldOffset(712)] public double Elasticity;
		[FieldOffset(720)] public int Acceleration;
		[FieldOffset(724)] public Pointer<ColorScheme> Color;
		[FieldOffset(728)] public Pointer<AnimTypeClass> Trailer;
		[FieldOffset(732)] public int ROT;
		[FieldOffset(736)] public int CourseLockDuration;
		[FieldOffset(740)] public int SpawnDelay;
		[FieldOffset(744)] public int ScaledSpawnDelay;
		[FieldOffset(748)] public byte Scalable;

		[FieldOffset(752)] public int Arm;
		[FieldOffset(756)] public byte AnimLow;	 // not bool
		[FieldOffset(757)] public byte AnimHigh; // not bool
		[FieldOffset(758)] public byte AnimRate; // not bool
		[FieldOffset(759)] public byte Flat;
	}
}
