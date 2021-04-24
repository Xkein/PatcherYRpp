using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 328)]
    public struct CellClass
    {
        // get content objects
        public unsafe Pointer<TechnoClass> FindTechnoNearestTo(Point2D offsetPixel, bool alt, Pointer<TechnoClass> pExcludeThis)
        {
            var func = (delegate* unmanaged[Thiscall]<ref CellClass, ref Point2D, Bool, IntPtr, IntPtr>)0x47C3D0;
            return func(ref this, ref offsetPixel, alt, pExcludeThis);
        }

        public unsafe Pointer<ObjectClass> FindObjectOfType(AbstractType abs, bool alt)
        {
            var func = (delegate* unmanaged[Thiscall]<ref CellClass, AbstractType, Bool, IntPtr>)0x47C4D0;
            return func(ref this, abs, alt);
        }

        public unsafe Pointer<BuildingClass> GetBuilding()
        {
            var func = (delegate* unmanaged[Thiscall]<ref CellClass, IntPtr>)0x47C520;
            return func(ref this);
        }

        public unsafe Pointer<UnitClass> GetUnit(bool alt)
        {
            var func = (delegate* unmanaged[Thiscall]<ref CellClass, Bool, IntPtr>)0x47EBA0;
            return func(ref this, alt);
        }

        public unsafe Pointer<InfantryClass> GetInfantry(bool alt)
        {
            var func = (delegate* unmanaged[Thiscall]<ref CellClass, Bool, IntPtr>)0x47EC40;
            return func(ref this, alt);
        }

        public unsafe Pointer<AircraftClass> GetAircraft(bool alt)
        {
            var func = (delegate* unmanaged[Thiscall]<ref CellClass, Bool, IntPtr>)0x47EBF0;
            return func(ref this, alt);
        }

        public unsafe Pointer<TerrainClass> GetTerrain(bool alt)
        {
            var func = (delegate* unmanaged[Thiscall]<ref CellClass, Bool, IntPtr>)0x47C550;
            return func(ref this, alt);
        }

        /* craziest thing... first iterates Content looking to Aircraft,
         * failing that, calls FindTechnoNearestTo,
         * if that fails too, reiterates Content looking for Terrain
         */
        public unsafe Pointer<ObjectClass> GetSomeObject(CoordStruct coords, bool alt)
        {
            var func = (delegate* unmanaged[Thiscall]<ref CellClass, ref CoordStruct, Bool, IntPtr>)0x47C5A0;
            return func(ref this, ref coords, alt);
        }

        public unsafe Pointer<CellClass> GetNeighbourCell(Direction direction)
        {
            var func = (delegate* unmanaged[Thiscall]<ref CellClass, Direction, IntPtr>)0x481810;
            return func(ref this, direction);
        }

        public static CoordStruct Cell2Coord(CellStruct cell, int z = 0)
        {
            return new CoordStruct(cell.X * 256 + 128, cell.Y * 256 + 128, z);
        }
        public static CellStruct Coord2Cell(CoordStruct crd)
        {
            return new CellStruct(crd.X / 256, crd.Y / 256);
        }

        [FieldOffset(0)]
        public AbstractClass Base;

        [FieldOffset(36)] public CellStruct MapCoords;   //Where on the map does this Cell lie?

        [FieldOffset(44)] private IntPtr bridgeOwnerCell;
        public Pointer<CellClass> BridgeOwnerCell { get => bridgeOwnerCell; set => bridgeOwnerCell = value; }

        [FieldOffset(56)] public int IsoTileTypeIndex;   //What tile is this Cell?
                                                         //[FieldOffset(60)] public TagClass* AttachedTag;          // The cell tag
        [FieldOffset(64)] public Pointer<BuildingTypeClass> Rubble;              // The building type that provides the rubble image
        [FieldOffset(68)] public int OverlayTypeIndex;   //What Overlay lies on this Cell?
        [FieldOffset(72)] public int SmudgeTypeIndex;    //What Smudge lies on this Cell?

        [FieldOffset(80)] public int WallOwnerIndex; // Which House owns the wall placed in this Cell? // Determined by finding the nearest BuildingType and taking its owner
        [FieldOffset(84)] public int InfantryOwnerIndex;
        [FieldOffset(88)] public int AltInfantryOwnerIndex;


        [FieldOffset(224)] public Pointer<FootClass> Jumpjet; // a jumpjet occupying this cell atm
        [FieldOffset(228)] public Pointer<ObjectClass> FirstObject;   //The first Object on this Cell. NextObject functions as a linked list.
        [FieldOffset(232)] public Pointer<ObjectClass> AltObject;
        [FieldOffset(236)] public LandType LandType;  //What type of floor is this Cell?
        [FieldOffset(240)] public double RadLevel;  //The level of radiation on this Cell.

        [FieldOffset(256)] public int OccupyHeightsCoveringMe;

        [FieldOffset(282)] public byte Height;
        [FieldOffset(283)] public byte Level;
        [FieldOffset(284)] public byte SlopeIndex;  // this + 2 == cell's slope shape as reflected by PLACE.SHP

        [FieldOffset(286)] public byte Powerup; //The crate type on this cell. Also indicates some other weird properties
    }
}
