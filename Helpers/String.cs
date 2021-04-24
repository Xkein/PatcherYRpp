using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    public class AnsiString : CriticalFinalizerObject, IDisposable
    {
        IntPtr hGlobal;
        bool allocated;

        public AnsiString(string str)
        {
            hGlobal = Marshal.StringToHGlobalAnsi(str);
            allocated = true;
        }
        public AnsiString(IntPtr buffer, bool allocate = false)
        {
            if (allocate)
            {
                hGlobal = Marshal.StringToHGlobalAnsi(Marshal.PtrToStringAnsi(buffer));
            }
            else
            {
                hGlobal = buffer;
            }
            allocated = allocate;
        }

        public static implicit operator IntPtr(AnsiString ansiStr) => ansiStr.hGlobal;
        public static implicit operator string(AnsiString ansiStr) => Marshal.PtrToStringAnsi(ansiStr.hGlobal);

        public static implicit operator AnsiString(string str) => new AnsiString(str);
        public static implicit operator AnsiString(IntPtr ptr) => new AnsiString(ptr);
        public static implicit operator AnsiString(Pointer<byte> ptr) => new AnsiString(ptr);
        
        public override string ToString() => this;

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                if (hGlobal != IntPtr.Zero && allocated)
                {
                    Marshal.FreeHGlobal(hGlobal);
                }
                disposedValue = true;
            }
        }

        ~AnsiString()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
