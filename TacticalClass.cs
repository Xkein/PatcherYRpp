using DynamicPatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 3608)]
    public struct TacticalClass
    {
        private static IntPtr ppInstance = new IntPtr(0x887324);

        public static Pointer<TacticalClass> Instance { get => ((Pointer<Pointer<TacticalClass>>)ppInstance).Data; set => ((Pointer<Pointer<TacticalClass>>)ppInstance).Ref = value; }

        public static TacticalClass Global()
        {
            return Instance.Ref;
        }

        public unsafe Point2D CoordsToScreen(CoordStruct coords)
        {
            Point2D ret = default;
            var func = (delegate* unmanaged[Thiscall]<ref TacticalClass, ref Point2D, ref CoordStruct, IntPtr>)0x6D1F10;
            func(ref this, ref ret, ref coords);
            return ret;
        }

        public unsafe Point2D CoordsToClient(CoordStruct coords)
        {
            Point2D ret = default;
            var func = (delegate* unmanaged[Thiscall]<ref TacticalClass, ref CoordStruct, ref Point2D, Bool>)0x6D2140;
            func(ref this, ref coords, ref ret);
            return ret;
        }

        public unsafe CoordStruct ClientToCoords(Point2D client)
        {
            CoordStruct ret = default;
            var func = (delegate* unmanaged[Thiscall]<ref TacticalClass, ref CoordStruct, ref Point2D, IntPtr>)0x6D2280;
            func(ref this, ref ret, ref client);
            return ret;
        }

        public unsafe Point2D AdjustForZShapeMove(Point2D client)
        {
            Point2D ret = default;
            var func = (delegate* unmanaged[Thiscall]<ref TacticalClass, ref Point2D, ref Point2D, IntPtr>)0x6D1FE0;
            func(ref this, ref ret, ref client);
            return ret;
        }

        public unsafe void DrawLine(CoordStruct pos1, CoordStruct pos2, uint color, bool unk = false)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TacticalClass, ref CoordStruct, ref CoordStruct, uint, Bool, void>)0x6DBB60;
            func(ref this, ref pos1, ref pos2, color, unk);
        }

        public unsafe int AdjustForZ(int height)
        {
            var func = (delegate* unmanaged[Thiscall]<int, ref TacticalClass, int, int>)ASM.FastCallTransferStation;
            return func(0x6D20E0, ref this, height);
        }

        // called when area needs to be marked for redrawing due to external factors
        // - alpha lights, terrain changes like cliff destruction, etc
        public unsafe void RegisterDirtyArea(RectangleStruct area, bool unk)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TacticalClass, RectangleStruct, Bool, void>)0x6D2790;
            func(ref this, area, unk);
        }

        public unsafe void RegisterCellAsVisible(Pointer<CellClass> pCell)
        {
            var func = (delegate* unmanaged[Thiscall]<ref TacticalClass, IntPtr, void>)0x6D2790;
            func(ref this, pCell);
        }

        public unsafe void DrawLineAtCoords(CoordStruct start, CoordStruct end, int color)
        {
            var func = (delegate* unmanaged[Thiscall]<int, IntPtr, IntPtr, int, void>)ASM.FastCallTransferStation;
            func(0x6F6030, start.GetThisPointer(), end.GetThisPointer(), color);

        }

        public unsafe void DrawLineOnTactical(CoordStruct start, CoordStruct end, int color)
        {
            var func = (delegate* unmanaged[Thiscall]<int, IntPtr, IntPtr, int, void>)ASM.FastCallTransferStation;
            func(0x6F5EF0, start.GetThisPointer(), end.GetThisPointer(), color);

        }

        [FieldOffset(176)] public Point2D TacticalPos;
        [FieldOffset(184)] public Point2D LastTacticalPos;
    }
}
