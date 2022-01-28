using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    public static class COMHelpers
    {
        public static TInterface CreateInstance<TInterface>(Guid clsid)
        {
            Type type = Type.GetTypeFromCLSID(clsid);
            return (TInterface)Activator.CreateInstance(type);
        }

    }
}
