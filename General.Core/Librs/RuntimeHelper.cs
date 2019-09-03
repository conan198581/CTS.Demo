using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace General.Core.Librs
{
    public class RuntimeHelper
    {
        public static Assembly GetAssemblyByName(string assemblyName)
        {
            return AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(assemblyName));
        }
    }
}
