using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct ColorStruct
    {
        public ColorStruct(int r, int g, int b)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
        }

        public byte R;
        public byte G;
        public byte B;
    }

    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct CoordStruct
    {
        public CoordStruct(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static CoordStruct operator -(CoordStruct a)
        {
            return new CoordStruct(-a.X, -a.Y, -a.Z);
        }
        public static CoordStruct operator +(CoordStruct a, CoordStruct b)
        {
            return new CoordStruct(
                 a.X + b.X,
                 a.Y + b.Y,
                 a.Z + b.Z);
        }
        public static CoordStruct operator -(CoordStruct a, CoordStruct b)
        {
            return new CoordStruct(
                 a.X - b.X,
                 a.Y - b.Y,
                 a.Z - b.Z);
        }
        public static CoordStruct operator *(CoordStruct a, double r)
        {
            return new CoordStruct(
                 (int)(a.X * r),
                 (int)(a.Y * r),
                 (int)(a.Z * r));
        }

        public static double operator *(CoordStruct a, CoordStruct b)
        {
            return a.X * b.X
                 + a.Y * b.Y
                 + a.Z * b.Z;
        }
        //magnitude
        public double Magnitude()
        {
            return Math.Sqrt(MagnitudeSquared());
        }
        //magnitude squared
        public double MagnitudeSquared()
        {
            return this * this;

        }

        public  double DistanceFrom(CoordStruct other)
        {
            return (other - this).Magnitude();
        }

        public static bool operator ==(CoordStruct a, CoordStruct b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }
        public static bool operator !=(CoordStruct a, CoordStruct b) => !(a == b);

        public override bool Equals(object obj) => this == (CoordStruct)obj;
        public override int GetHashCode() => base.GetHashCode();

        public int X;
        public int Y;
        public int Z;
    }

    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct BulletVelocity
    {
        public BulletVelocity(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static BulletVelocity operator -(BulletVelocity a)
        {
            return new BulletVelocity(-a.X, -a.Y, -a.Z);
        }
        public static BulletVelocity operator +(BulletVelocity a, BulletVelocity b)
        {
            return new BulletVelocity(
                 a.X + b.X,
                 a.Y + b.Y,
                 a.Z + b.Z);
        }
        public static BulletVelocity operator -(BulletVelocity a, BulletVelocity b)
        {
            return new BulletVelocity(
                 a.X - b.X,
                 a.Y - b.Y,
                 a.Z - b.Z);
        }
        public static BulletVelocity operator *(BulletVelocity a, double r)
        {
            return new BulletVelocity(
                 (double)(a.X * r),
                 (double)(a.Y * r),
                 (double)(a.Z * r));
        }

        public static double operator *(BulletVelocity a, BulletVelocity b)
        {
            return a.X * b.X
                 + a.Y * b.Y
                 + a.Z * b.Z;
        }
        //magnitude
        public double Magnitude()
        {
            return Math.Sqrt(MagnitudeSquared());
        }
        //magnitude squared
        public double MagnitudeSquared()
        {
            return this * this;

        }

        public double DistanceFrom(BulletVelocity other)
        {
            return (other - this).Magnitude();
        }

        public static bool operator ==(BulletVelocity a, BulletVelocity b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }
        public static bool operator !=(BulletVelocity a, BulletVelocity b) => !(a == b);

        public override bool Equals(object obj) => this == (BulletVelocity)obj;
        public override int GetHashCode() => base.GetHashCode();

        public double X;
        public double Y;
        public double Z;
    }

    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct CellStruct
    {
        public CellStruct(int x, int y)
        {
            X = (short)x;
            Y = (short)y;
        }

        public static CellStruct operator -(CellStruct a)
        {
            return new CellStruct(-a.X, -a.Y);
        }
        public static CellStruct operator +(CellStruct a, CellStruct b)
        {
            return new CellStruct(
                 a.X + b.X,
                 a.Y + b.Y);
        }
        public static CellStruct operator -(CellStruct a, CellStruct b)
        {
            return new CellStruct(
                 a.X - b.X,
                 a.Y - b.Y);
        }
        public static CellStruct operator *(CellStruct a, double r)
        {
            return new CellStruct(
                 (int)(a.X * r),
                 (int)(a.Y * r));
        }

        public static double operator *(CellStruct a, CellStruct b)
        {
            return a.X * b.X
                 + a.Y * b.Y;
        }
        //magnitude
        public double Magnitude()
        {
            return Math.Sqrt(MagnitudeSquared());
        }
        //magnitude squared
        public double MagnitudeSquared()
        {
            return this * this;

        }

        public double DistanceFrom(CellStruct other)
        {
            return (other - this).Magnitude();
        }

        public static bool operator ==(CellStruct a, CellStruct b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(CellStruct a, CellStruct b) => !(a == b);

        public override bool Equals(object obj) => this == (CellStruct)obj;
        public override int GetHashCode() => base.GetHashCode();

        public short X;
        public short Y;
    }

    //Random number range
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct RandomStruct
    {
        public int Min, Max;
    };


    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct SingleVector3D
    {
        public SingleVector3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static SingleVector3D operator -(SingleVector3D a)
        {
            return new SingleVector3D(-a.X, -a.Y, -a.Z);
        }
        public static SingleVector3D operator +(SingleVector3D a, SingleVector3D b)
        {
            return new SingleVector3D(
                 a.X + b.X,
                 a.Y + b.Y,
                 a.Z + b.Z);
        }
        public static SingleVector3D operator -(SingleVector3D a, SingleVector3D b)
        {
            return new SingleVector3D(
                 a.X - b.X,
                 a.Y - b.Y,
                 a.Z - b.Z);
        }
        public static SingleVector3D operator *(SingleVector3D a, double r)
        {
            return new SingleVector3D(
                 (float)(a.X * r),
                 (float)(a.Y * r),
                 (float)(a.Z * r));
        }

        public static double operator *(SingleVector3D a, SingleVector3D b)
        {
            return a.X * b.X
                 + a.Y * b.Y
                 + a.Z * b.Z;
        }
        //magnitude
        public double Magnitude()
        {
            return Math.Sqrt(MagnitudeSquared());
        }
        //magnitude squared
        public double MagnitudeSquared()
        {
            return this * this;
        }

        public double DistanceFrom(SingleVector3D other)
        {
            return (other - this).Magnitude();
        }

        public static bool operator ==(SingleVector3D a, SingleVector3D b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }
        public static bool operator !=(SingleVector3D a, SingleVector3D b) => !(a == b);

        public override bool Equals(object obj) => this == (SingleVector3D)obj;
        public override int GetHashCode() => base.GetHashCode();

        public float X;
        public float Y;
        public float Z;
    }

    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct Quaternion
    {
        public Quaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public float X;
        public float Y;
        public float Z;
        public float W;
    };

    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct Point2D
    {
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point2D operator -(Point2D a)
        {
            return new Point2D(-a.X, -a.Y);
        }
        public static Point2D operator +(Point2D a, Point2D b)
        {
            return new Point2D(
                 a.X + b.X,
                 a.Y + b.Y);
        }
        public static Point2D operator -(Point2D a, Point2D b)
        {
            return new Point2D(
                 a.X - b.X,
                 a.Y - b.Y);
        }
        public static Point2D operator *(Point2D a, double r)
        {
            return new Point2D(
                 (int)(a.X * r),
                 (int)(a.Y * r));
        }

        public static double operator *(Point2D a, Point2D b)
        {
            return a.X * b.X
                 + a.Y * b.Y;
        }
        //magnitude
        public double Magnitude()
        {
            return Math.Sqrt(MagnitudeSquared());
        }
        //magnitude squared
        public double MagnitudeSquared()
        {
            return this * this;

        }

        public double DistanceFrom(Point2D other)
        {
            return (other - this).Magnitude();
        }

        public static bool operator ==(Point2D a, Point2D b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(Point2D a, Point2D b) => !(a == b);

        public override bool Equals(object obj) => this == (Point2D)obj;
        public override int GetHashCode() => base.GetHashCode();

        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct RectangleStruct
    {
        public RectangleStruct(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Width = z;
            Height = w;
        }

        public static RectangleStruct operator -(RectangleStruct a)
        {
            return new RectangleStruct(-a.X, -a.Y, -a.Width, -a.Height);
        }
        public static RectangleStruct operator +(RectangleStruct a, RectangleStruct b)
        {
            return new RectangleStruct(
                 a.X + b.X,
                 a.Y + b.Y,
                 a.Width + b.Width,
                 a.Height + b.Height);
        }
        public static RectangleStruct operator -(RectangleStruct a, RectangleStruct b)
        {
            return new RectangleStruct(
                 a.X - b.X,
                 a.Y - b.Y,
                 a.Width - b.Width,
                 a.Height - b.Height);
        }
        public static RectangleStruct operator *(RectangleStruct a, double r)
        {
            return new RectangleStruct(
                 (int)(a.X * r),
                 (int)(a.Y * r),
                 (int)(a.Width * r),
                 (int)(a.Height * r));
        }
        public static RectangleStruct operator /(RectangleStruct a, double r)
        {
            return new RectangleStruct(
                 (int)(a.X / r),
                 (int)(a.Y / r),
                 (int)(a.Width / r),
                 (int)(a.Height / r));
        }

        public static double operator *(RectangleStruct a, RectangleStruct b)
        {
            return a.X * b.X
                 + a.Y * b.Y
                 + a.Width * b.Width
                 + a.Height * b.Height;
        }
        public static bool operator ==(RectangleStruct a, RectangleStruct b)
        {
            return a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height;
        }
        public static bool operator !=(RectangleStruct a, RectangleStruct b) => !(a == b);

        public override bool Equals(object obj) => this == (RectangleStruct)obj;
        public override int GetHashCode() => base.GetHashCode();

        public int X;
        public int Y;
        public int Width;
        public int Height;
    }

    [StructLayout(LayoutKind.Explicit, Size = 828)]
    public struct BytePalette
    {
        public const int EntriesCount = 256;
        [FieldOffset(0)] public ColorStruct Entries_first;
        public Pointer<ColorStruct> Entries => Pointer<ColorStruct>.AsPointer(ref Entries_first);
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct TintStruct
    {
        int Red;
        int Green;
        int Blue;
    };

}

