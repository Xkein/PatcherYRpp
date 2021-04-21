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

        public AnsiString(string str)
        {
            hGlobal = Marshal.StringToHGlobalAnsi(str);
        }
        public AnsiString(IntPtr buffer) : this(Marshal.PtrToStringAnsi(buffer))
        {
        }

        public static implicit operator IntPtr(AnsiString ansiStr) => ansiStr.hGlobal;
        public static implicit operator string(AnsiString ansiStr) => Marshal.PtrToStringAnsi(ansiStr.hGlobal);

        public static implicit operator AnsiString(string str) => new AnsiString(str);

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                if (hGlobal != IntPtr.Zero)
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
