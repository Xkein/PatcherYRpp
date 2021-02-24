using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp.FileFormats
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SHPStruct
    {
        public short Type;
        public short Width;
        public short Height;
        public short Frames;
    }
}
