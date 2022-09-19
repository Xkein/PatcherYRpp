using System.Numerics;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicPatcher;

namespace PatcherYRpp
{

    [StructLayout(LayoutKind.Sequential, Size = 4)]
    [Serializable]
    public struct Vector2D<T>
    {
        public Vector2D(T x, T y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("{{\"X\":{0}, \"Y\":{1}}}", X, Y);
        }

        public T X;
        public T Y;
    }

    [StructLayout(LayoutKind.Sequential, Size = 12)]
    [Serializable]
    public struct Vector3D<T>
    {
        public Vector3D(T x, T y, T z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return string.Format("{{\"X\":{0}, \"Y\":{1}, \"Z\":{2}}}", X, Y, Z);
        }

        public T X;
        public T Y;
        public T Z;

    }

}
