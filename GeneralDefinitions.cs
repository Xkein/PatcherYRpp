using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [Flags]
    public enum AbstractFlags
    {
        None = 0x0,
        Techno = 0x1,
        Object = 0x2,
        Foot = 0x4
    };

    public enum AbstractType
    {
        None = 0,
        Unit = 1,
        Aircraft = 2,
        AircraftType = 3,
        Anim = 4,
        AnimType = 5,
        Building = 6,
        BuildingType = 7,
        Bullet = 8,
        BulletType = 9,
        Campaign = 10,
        Cell = 11,
        Factory = 12,
        House = 13,
        HouseType = 14,
        Infantry = 15,
        InfantryType = 16,
        Isotile = 17,
        IsotileType = 18,
        BuildingLight = 19,
        Overlay = 20,
        OverlayType = 21,
        Particle = 22,
        ParticleType = 23,
        ParticleSystem = 24,
        ParticleSystemType = 25,
        Script = 26,
        ScriptType = 27,
        Side = 28,
        Smudge = 29,
        SmudgeType = 30,
        Special = 31,
        SuperWeaponType = 32,
        TaskForce = 33,
        Team = 34,
        TeamType = 35,
        Terrain = 36,
        TerrainType = 37,
        Trigger = 38,
        TriggerType = 39,
        UnitType = 40,
        VoxelAnim = 41,
        VoxelAnimType = 42,
        Wave = 43,
        Tag = 44,
        TagType = 45,
        Tiberium = 46,
        Action = 47,
        Event = 48,
        WeaponType = 49,
        WarheadType = 50,
        Waypoint = 51,
        Abstract = 52,
        Tube = 53,
        LightSource = 54,
        EMPulse = 55,
        TacticalMap = 56,
        Super = 57,
        AITrigger = 58,
        AITriggerType = 59,
        Neuron = 60,
        FoggedObject = 61,
        AlphaShape = 62,
        VeinholeMonster = 63,
        NavyType = 64,
        SpawnManager = 65,
        CaptureManager = 66,
        Parasite = 67,
        Bomb = 68,
        RadSite = 69,
        Temporal = 70,
        Airstrike = 71,
        SlaveManager = 72,
        DiskLaser = 73
    };

    public enum DamageAreaResult
    {
        Hit = 0,
        Missed = 1,
        Nullified = 2
    };

    public enum Direction
    {
        N = 0x0,
        North = 0x0,
        NE = 0x1,
        NorthEast = 0x1,
        E = 0x2,
        East = 0x2,
        SE = 0x3,
        SouthEast = 0x3,
        S = 0x4,
        South = 0x4,
        SW = 0x5,
        SouthWest = 0x5,
        W = 0x6,
        West = 0x6,
        NW = 0x7,
        NorthWest = 0x7,
    };

    public enum SpotlightFlags
    {
        None = 0x0,
        NoColor = 0x1,
        NoRed = 0x2,
        NoGreen = 0x4,
        NoBlue = 0x8
    };
    public enum LandType
    {
        Clear = 0,
        Road = 1,
        Water = 2,
        Rock = 3,
        Wall = 4,
        Tiberium = 5,
        Beach = 6,
        Rough = 7,
        Ice = 8,
        Railroad = 9,
        Tunnel = 10,
        Weeds = 11
    };

    public enum Layer
    {
        None = -1,
        Underground = 0,
        Surface = 1,
        Ground = 2,
        Air = 3,
        Top = 4
    };

    public enum ChargeDrainState
    {
        None = -1,
        Charging = 0,
        Ready = 1,
        Draining = 2
    };

    public enum SuperWeaponType
    {
        Invalid = -1,
        Nuke = 0,
        IronCurtain = 1,
        LightningStorm = 2,
        ChronoSphere = 3,
        ChronoWarp = 4,
        ParaDrop = 5,
        AmerParaDrop = 6,
        PsychicDominator = 7,
        SpyPlane = 8,
        GeneticMutator = 9,
        ForceShield = 10,
        PsychicReveal = 11
    };

    [Flags]
    public enum BlitterFlags
    {
        None = 0x0,
        Darken = 0x1,
        TransLucent25 = 0x2,
        TransLucent50 = 0x4,
        TransLucent75 = 0x6,
        Warp = 0x8,
        ZRemap = 0x10,
        Plain = 0x20,
        bf_040 = 0x40,
        bf_080 = 0x80,
        MultiPass = 0x100,
        Centered = 0x200,
        bf_400 = 0x400,
        Alpha = 0x800,
        bf_1000 = 0x1000,
        Flat = 0x2000,
        ZRead = 0x3000,
        ZReadWrite = 0x4000,
        bf_8000 = 0x8000,
        Zero = 0x10000,
        Nonzero = 0x20000
    };

    public enum VisualType
    {
        Normal = 0,
        Indistinct = 1,
        Darken = 2,
        Shadowy = 3,
        Ripple = 4,
        Hidden = 5
    };

    public enum Move
    {
        OK = 0,
        Cloak = 1,
        MovingBlock = 2,
        ClosedGate = 3,
        FriendlyDestroyable = 4,
        Destroyable = 5,
        Temp = 6,
        No = 7
    };

    public enum ZGradient
    {
        None = -1,
        Ground = 0,
        Deg45 = 1,
        Deg90 = 2,
        Deg135 = 3
    };

    // this is how game's enums are to be defined from now on
    public enum FireError
    {
        NONE = -1, // no valid value
        OK = 0, // no problem, can fire
        AMMO = 1, // no ammo
        FACING = 2, // bad facing
        REARM = 3, // still reloading
        ROTATING = 4, // busy rotating
        ILLEGAL = 5, // can't fire
        CANT = 6, // I'm sorry Dave, I can't do that
        MOVING = 7, // moving, can't fire
        RANGE = 8, // out of range
        CLOAKED = 9, // need to decloak
        BUSY = 10, // busy, please hold
        MUST_DEPLOY = 11 // deploy first!
    };
    public enum Rank
    {
        Invalid = -1,
        Elite = 0,
        Veteran = 1,
        Rookie = 2
    };

    public enum SpeedType
    {
        None = -1,
        Foot = 0,
        Track = 1,
        Wheel = 2,
        Hover = 3,
        Winged = 4,
        Float = 5,
        Amphibious = 6,
        FloatBeach = 7
    };
}
