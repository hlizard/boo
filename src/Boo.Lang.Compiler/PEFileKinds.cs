#if (DNXCORE50 || NETSTANDARD1_6 || NETSTANDARD2_0 || NET5_0)
using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
    /// <summary>Specifies the type of the portable executable (PE) file.</summary>
    [ComVisible(true)]
    [Serializable]
    public enum PEFileKinds
    {
        /// <summary>The portable executable (PE) file is a DLL.</summary>
        Dll = 1,
        /// <summary>The application is a console (not a Windows-based) application.</summary>
        ConsoleApplication,
        /// <summary>The application is a Windows-based application.</summary>
        WindowApplication
    }
}
#endif
