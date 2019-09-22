// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="Loader.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SqlServerTypes
{
    /// <summary>
    /// Utility methods related to CLR Types for SQL Server
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// Loads the library.
        /// </summary>
        /// <param name="libname">The libname.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadLibrary(string libname);

        /// <summary>
        /// Loads the required native assemblies for the current architecture (x86 or x64)
        /// </summary>
        /// <param name="rootApplicationPath">Root path of the current application. Use Server.MapPath(".") for ASP.NET applications
        /// and AppDomain.CurrentDomain.BaseDirectory for desktop applications.</param>
        public static void LoadNativeAssemblies(string rootApplicationPath)
        {
            var nativeBinaryPath = IntPtr.Size > 4
                ? Path.Combine(rootApplicationPath, @"SqlServerTypes\x64\")
                : Path.Combine(rootApplicationPath, @"SqlServerTypes\x86\");

            LoadNativeAssembly(nativeBinaryPath, "msvcr120.dll");
            LoadNativeAssembly(nativeBinaryPath, "SqlServerSpatial140.dll");
        }

        /// <summary>
        /// Loads the native assembly.
        /// </summary>
        /// <param name="nativeBinaryPath">The native binary path.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <exception cref="Exception"></exception>
        private static void LoadNativeAssembly(string nativeBinaryPath, string assemblyName)
        {
            var path = Path.Combine(nativeBinaryPath, assemblyName);
            var ptr = LoadLibrary(path);
            if (ptr == IntPtr.Zero)
            {
                throw new Exception(string.Format(
                    "Error loading {0} (ErrorCode: {1})",
                    assemblyName,
                    Marshal.GetLastWin32Error()));
            }
        }
    }
}