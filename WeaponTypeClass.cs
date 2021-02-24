using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 352)]
    public struct WeaponTypeClass
    {

        [FieldOffset(0)] public AbstractTypeClass Base;
        [FieldOffset(152)] public int AmbientDamage;
		[FieldOffset(156)] public int Burst;
        [FieldOffset(160)] public IntPtr projectile;
		public Pointer<BulletTypeClass> Projectile { get => projectile; set => projectile = value; }
		[FieldOffset(164)] public int Damage;
		[FieldOffset(168)] public int Speed;
        [FieldOffset(172)] public Pointer<WarheadTypeClass> Warhead;
        [FieldOffset(176)] public int ROF;
		[FieldOffset(180)] public int Range; // int(256 * ini value)
		[FieldOffset(184)] public int MinimumRange; // int(256 * ini value)
		[FieldOffset(188)] public DynamicVectorClass<int> Report;       //sound indices
		[FieldOffset(216)] public DynamicVectorClass<int> DownReport;   //sound indices
        [FieldOffset(244)] public DynamicVectorClass<Pointer<AnimTypeClass>> Anim;
        [FieldOffset(272)] public Pointer<AnimTypeClass> OccupantAnim;
        [FieldOffset(276)] public Pointer<AnimTypeClass> AssaultAnim;
        [FieldOffset(280)] public Pointer<AnimTypeClass> OpenToppedAnim;
        [FieldOffset(284)] public Pointer<ParticleSystemTypeClass> AttachedParticleSystem;
        [FieldOffset(288)] public ColorStruct LaserInnerColor;
		[FieldOffset(291)] public ColorStruct LaserOuterColor;
		[FieldOffset(294)] public ColorStruct LaserOuterSpread;
		[FieldOffset(297)] public byte UseFireParticles;
		[FieldOffset(298)] public byte UseSparkParticles;
		[FieldOffset(299)] public byte OmniFire;
		[FieldOffset(300)] public byte DistributedWeaponFire;
		[FieldOffset(301)] public byte IsRailgun;
		[FieldOffset(302)] public byte Lobber;
		[FieldOffset(303)] public byte Bright;
		[FieldOffset(304)] public byte IsSonic;
		[FieldOffset(305)] public byte Spawner;
		[FieldOffset(306)] public byte LimboLaunch;
		[FieldOffset(307)] public byte DecloakToFire;
		[FieldOffset(308)] public byte CellRangefinding;
		[FieldOffset(309)] public byte FireOnce;
		[FieldOffset(310)] public byte NeverUse;
		[FieldOffset(311)] public byte RevealOnFire;
		[FieldOffset(312)] public byte TerrainFire;
		[FieldOffset(313)] public byte SabotageCursor;
		[FieldOffset(314)] public byte MigAttackCursor;
		[FieldOffset(315)] public byte DisguiseFireOnly;
		[FieldOffset(316)] public int DisguiseFakeBlinkTime;
		[FieldOffset(320)] public byte InfiniteMindControl;
		[FieldOffset(321)] public byte FireWhileMoving;
		[FieldOffset(322)] public byte DrainWeapon;
		[FieldOffset(323)] public byte FireInTransport;
		[FieldOffset(324)] public byte Suicide;
		[FieldOffset(325)] public byte TurboBoost;
		[FieldOffset(326)] public byte Supress;
		[FieldOffset(327)] public byte Camera;
		[FieldOffset(328)] public byte Charges;
		[FieldOffset(329)] public byte IsLaser;
		[FieldOffset(330)] public byte DiskLaser;
		[FieldOffset(331)] public byte IsLine;
		[FieldOffset(332)] public byte IsBigLaser;
		[FieldOffset(333)] public byte IsHouseColor;
		[FieldOffset(334)] public char LaserDuration;
		[FieldOffset(335)] public byte IonSensitive;
		[FieldOffset(336)] public byte AreaFire;
		[FieldOffset(337)] public byte IsElectricBolt;
		[FieldOffset(338)] public byte DrawBoltAsLaser;
		[FieldOffset(339)] public byte IsAlternateColor;
		[FieldOffset(340)] public byte IsRadBeam;
		[FieldOffset(341)] public byte IsRadEruption;
		[FieldOffset(344)] public int RadLevel;
		[FieldOffset(348)] public byte IsMagBeam;

	}
}