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
    public struct BounceClass
    {
        public enum Status
        {
            None = 0,
            Bounce = 1,
            Impact = 2
        };

        BounceClass(CoordStruct coords, double elasticity, double gravity,
            double maxVelocity, SingleVector3D velocity, double angularVelocity) : this()
        {
            this.Initialize(coords, elasticity, gravity, maxVelocity, velocity, angularVelocity);
        }

        unsafe void Initialize(CoordStruct coords, double elasticity, double gravity,
            double maxVelocity, SingleVector3D velocity, double angularVelocity)
        {
            var func = (delegate* unmanaged[Thiscall]<ref BounceClass, ref CoordStruct, double, double, double, ref SingleVector3D, double, void>)0x4397E0;
            func(ref this, ref coords, elasticity, gravity, maxVelocity, ref velocity, angularVelocity);
        }

        unsafe CoordStruct GetCoords()
        {
            var func = (delegate* unmanaged[Thiscall]<ref BounceClass, IntPtr, IntPtr>)0x4399A0;

            CoordStruct ret = default;
            func(ref this, Pointer<CoordStruct>.AsPointer(ref ret));
            return ret;
        }

        //Matrix3DStruct* GetDrawingMatrix(Matrix3DStruct* pBuffer)
        //{
        //    JMP_THIS(0x4399E0);
        //}

        unsafe Status Update()
        {
            var func = (delegate* unmanaged[Thiscall]<ref BounceClass, Status>)0x439B00;
            return func(ref this);
        }

        public double Elasticity; // speed multiplier when bouncing off the ground
        public double Gravity; // subtracted from the Z coords every frame
        public double MaxVelocity; // 0.0 disables check
        public SingleVector3D Coords; // position with precision
        public SingleVector3D Velocity; // speed components
        public Quaternion_ CurrentAngle; // quaternion for drawing
        public Quaternion_ AngularVelocity; // second quaternion as per-frame delta
    }
}
