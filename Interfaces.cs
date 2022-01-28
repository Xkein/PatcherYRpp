using Microsoft.VisualStudio.OLE.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using HRESULT = System.UInt32;
using VARIANT_BOOL = System.Int16;

namespace PatcherYRpp
{
	[Guid("070F3290-9841-11D1-B709-00A024DDAFD1")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ILocomotion
	{
		HRESULT Link_To_Object(IntPtr pointer); //Links object to locomotor.
		Bool Is_Moving();   //Sees if object is moving.
		IntPtr Destination(IntPtr pcoord);  //Fetches destination coordinate.
		IntPtr Head_To_Coord(IntPtr pcoord); // Fetches immediate (next cell) destination coordinate.
		Move Can_Enter_Cell(CellStruct cell); //Determine if specific cell can be entered.
		Bool Is_To_Have_Shadow();   //Should object cast a shadow?
		IntPtr Draw_Matrix(IntPtr pMatrix, IntPtr pKey); //Fetch voxel draw matrix.
		IntPtr Shadow_Matrix(IntPtr pMatrix, IntPtr pKey);   //Fetch shadow draw matrix.
		IntPtr Draw_Point(IntPtr pPoint);   //Draw point center location.
		IntPtr Shadow_Point(IntPtr pPoint); //Shadow draw point center location.
		VisualType Visual_Character(VARIANT_BOOL unused);   //Visual character for drawing.
		int Z_Adjust(); //Z adjust control value.
		ZGradient Z_Gradient(); //Z gradient control value.
		Bool Process(); //Process movement of object.]
		void Move_To(CoordStruct to);   //Instruct to move to location specified.
		void Stop_Moving(); //Stop moving at first opportunity.
		void Do_Turn(DirStruct coord);  //Try to face direction specified.
		void Unlimbo(); //Object is appearing in the world.
		void Tilt_Pitch_AI();   //Special tilting AI function.
		Bool Power_On();    //Locomotor becomes powered.
		Bool Power_Off();   //Locomotor loses power.
		Bool Is_Powered();  //Is locomotor powered?
		Bool Is_Ion_Sensitive();    //Is locomotor sensitive to ion storms?
		Bool Push(DirStruct dir);   //Push object in direction specified.
		Bool Shove(DirStruct dir);  //Shove object (with spin) in direction specified.
		void Force_Track(int track, CoordStruct coord); //Force drive track -- special case only.
		Layer In_Which_Layer(); //What display layer is it located in.
		void Force_Immediate_Destination(CoordStruct coord);    //Don't use this function.
		void Force_New_Slope(int ramp); //Force a voxel unit to a given slope. Used in cratering.
		Bool Is_Moving_Now();   //Is it actually moving across the ground this very second?
		int Apparent_Speed();   //Actual current speed of object expressed as leptons per game frame.
		int Drawing_Code(); //Special drawing feedback code (locomotor specific meaning)
		FireError Can_Fire();   //Queries if any locomotor specific state prevents the object from firing.
		int Get_Status();   //Queries the general state of the locomotor.
		void Acquire_Hunter_Seeker_Target();    //Forces a hunter seeker droid to find a target.
		Bool Is_Surfacing();    //Is this object surfacing?
		void Mark_All_Occupation_Bits(int mark);    //Lifts all occupation bits associated with the object off the map
		Bool Is_Moving_Here(CoordStruct to);    //Is this object in the process of moving into this coord.
		Bool Will_Jump_Tracks();    //Will this object jump tracks?
		Bool Is_Really_Moving_Now();    //Infantry moving query function
		void Stop_Movement_Animation(); //Falsifies the IsReallyMoving flag in WalkLocomotionClass
		void Lock();    //Locks the locomotor from being deleted
		void Unlock();  //Unlocks the locomotor from being deleted
		void ILocomotion_B8();  //Unknown, must have been added after LOCOS.TLB was generated. -pd
		int Get_Track_Number(); //Queries internal variables
		int Get_Track_Index();  //Queries internal variables
		int Get_Speed_Accum();  //Queries internal variables
	}

	public static class ILocomotionHelpers
    {
		public static CoordStruct Destination(this ILocomotion locomotion)
        {
			CoordStruct tmp = default;
			locomotion.Destination(tmp.GetThisPointer());
			return tmp;
        }
		public static CoordStruct Head_To_Coord(this ILocomotion locomotion)
		{
			CoordStruct tmp = default;
			locomotion.Head_To_Coord(tmp.GetThisPointer());
			return tmp;
		}
	}

    [Guid("92FEA800-A184-11D1-B70A-00A024DDAFD1")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPiggyback
	{
		HRESULT Begin_Piggyback(ILocomotion locomotion);	//Piggybacks a locomotor onto this one.
		HRESULT End_Piggyback(out ILocomotion locomotion);	//End piggyback process and restore locomotor interface pointer.
		bool Is_Ok_To_End();	//Is it ok to end the piggyback process?
		HRESULT Piggyback_CLSID(out Guid classid);	//Fetches piggybacked locomotor class ID.
		bool Is_Piggybacking();	//Is it currently piggy backing another locomotor?
	}
}
