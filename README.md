
# C# Style YRpp

[![license](https://www.gnu.org/graphics/gplv3-or-later.png)](https://www.gnu.org/licenses/gpl-3.0.en.html)

Pointer
============
It is suggested that use Pointer<T> to replace T*.

Use Pointer<T>.Ref to access members of T.

Use Pointer<TFrom>.Convert<TTo>() if it is need to convert the pointer type. IntPtr also has this extend function.

Use Pointer<T>.AsPointer(ref obj) to get an object address.

Use PointerHandle<T> if it is need to set the pointer later(avoid GC moving).

How to add class content I want?
--------
First, you need a classes layout of YRPP.

Every class should be writen below:
``` csharp

[StructLayout(LayoutKind.Explicit, Size = struct_size)]
public struct YourClass
{
  // your function
  public unsafe void function()
  {
      var func = (delegate* unmanaged[Thiscall]<ref YourClass, void>)function_address;
      func(ref this);
  }
  
  // your virtual function
  public unsafe void function()
  {
      var func = (delegate* unmanaged[Thiscall]<ref YourClass, void>)Helpers.GetVirtualFunctionPointer(Pointer<YourClass>.AsPointer(ref this), virtual_function_index);
      func(ref this);
  }

  // your member
  [FieldOffset(member_offset)] public TMember member;
}

```

