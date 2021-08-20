using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 48)]
    public struct ABufferClass
    {
        private static IntPtr ppABuffer = new IntPtr(0x87E8A4);
        public static Pointer<ABufferClass> ABuffer { get => ((Pointer<Pointer<ABufferClass>>)ppABuffer).Data; set => ((Pointer<Pointer<ABufferClass>>)ppABuffer).Ref = value; }

        public unsafe Pointer<short> GetBufferAt(Point2D point)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ABufferClass, int,int,IntPtr>)0x4114B0;
            return func(ref this, point.X, point.Y);
        }
        public unsafe Pointer<short> AdjustedGetBufferAt(Point2D point)
        {
            return GetBufferAt(point - new Point2D(0, Rect.Y));
        }

        [FieldOffset(0)] public RectangleStruct Rect;
        [FieldOffset(16)] public int _10;
        [FieldOffset(20)] public Pointer<Surface> BSurface;
        [FieldOffset(24)] public Pointer<byte> BufferStart;
        [FieldOffset(28)] public Pointer<byte> BufferEndpoint;
        [FieldOffset(32)] public int BufferSize;
        [FieldOffset(36)] public int _24;
        [FieldOffset(40)] public int Width;
        [FieldOffset(44)] public int Height;

    }

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct ZBufferClass
    {
        private static IntPtr ppZBuffer = new IntPtr(0x887644);
        public static Pointer<ZBufferClass> ZBuffer { get => ((Pointer<Pointer<ZBufferClass>>)ppZBuffer).Data; set => ((Pointer<Pointer<ZBufferClass>>)ppZBuffer).Ref = value; }

        public unsafe Pointer<short> GetBufferAt(Point2D point)
        {
            var func = (delegate* unmanaged[Thiscall]<ref ZBufferClass, int, int, IntPtr>)0x7BD130;
            return func(ref this, point.X, point.Y);
        }
        public unsafe Pointer<short> AdjustedGetBufferAt(Point2D point)
        {
            return GetBufferAt(point - new Point2D(0, Rect.Y));
        }

        [FieldOffset(0)] public RectangleStruct Rect;
        [FieldOffset(16)] public int CurrentOffset;
        [FieldOffset(20)] public Pointer<Surface> BSurface;
        [FieldOffset(24)] public Pointer<byte> BufferStart;
        [FieldOffset(28)] public Pointer<byte> BufferEndpoint;
        [FieldOffset(32)] public int BufferSize;
        [FieldOffset(36)] public int CurrentBaseZ;
        [FieldOffset(40)] public int Width;
        [FieldOffset(44)] public int Height;
    }
}
