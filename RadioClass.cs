using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 240)]
    public struct RadioClass
    {

        public unsafe RadioCommand SendToFirstLink(RadioCommand command)
        {
            var func = (delegate* unmanaged[Thiscall]<ref RadioClass, RadioCommand, RadioCommand>)this.GetVirtualFunctionPointer(157);
            return func(ref this, command);
        }
        public unsafe RadioCommand SendCommand(RadioCommand command, Pointer<TechnoClass> pRecipient)
        {
            var func = (delegate* unmanaged[Thiscall]<ref RadioClass, RadioCommand, IntPtr, RadioCommand>)this.GetVirtualFunctionPointer(158);
            return func(ref this, command, pRecipient);
        }
        public unsafe RadioCommand SendCommandWithData(RadioCommand command, ref Pointer<AbstractClass> pInOut, Pointer<TechnoClass> pRecipient)
        {
            var func = (delegate* unmanaged[Thiscall]<ref RadioClass, RadioCommand, IntPtr, IntPtr, RadioCommand>)this.GetVirtualFunctionPointer(159);
            return func(ref this, command, pInOut.GetThisPointer(), pRecipient);
        }
        public unsafe void SendToEachLink(RadioCommand command)
        {
            var func = (delegate* unmanaged[Thiscall]<ref RadioClass, RadioCommand, void>)this.GetVirtualFunctionPointer(160);
            func(ref this, command);
        }

        // 是否绑定在机场
        // 飞机调用
        public unsafe bool IsInRadioContact()
        {
            var func = (delegate* unmanaged[Thiscall]<ref RadioClass, Bool>)0x65AE30;
            return func(ref this);
        }

        // 绑定在哪个机场
        // 飞机调用
        public unsafe Pointer<BuildingClass> ContactWithWhom(int index = 0)
        {
            var func = (delegate* unmanaged[Thiscall]<ref RadioClass, int, IntPtr>)0x65AD40;
            return func(ref this, index);
        }

        // 绑定在几号停机位
        // 建筑调用
        public unsafe int GetContactIndex(Pointer<RadioClass> pAircraft)
        {
            var func = (delegate* unmanaged[Thiscall]<ref RadioClass, IntPtr, int>)0x65AD90;
            return func(ref this, pAircraft);
        }

        // 有没有空位
        // 建筑调用
        public unsafe bool HasFreeIndexes()
        {
            var func = (delegate* unmanaged[Thiscall]<ref RadioClass, Bool>)0x65ADC0;
            return func(ref this);
        }

        [FieldOffset(0)] public MissionClass Base;
        [FieldOffset(0)] public ObjectClass BaseObject;
        [FieldOffset(0)] public AbstractClass BaseAbstract;


    }
}
