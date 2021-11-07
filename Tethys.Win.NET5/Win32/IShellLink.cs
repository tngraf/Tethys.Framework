// ---------------------------------------------------------------------------
// <copyright file="IShellLink.cs" company="Tethys">
//   Copyright (C) 1998-2021 T. Graf
// </copyright>
//
// SPDX-License-Identifier: Apache-2.0
//
// Licensed under the Apache License, Version 2.0.
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied.
// ---------------------------------------------------------------------------

// ReSharper disable once CheckNamespace
namespace Tethys.Win32
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using System.Text;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Not here")]

    /// <summary>
    /// The IShellLink interface allows Shell links to be created,
    /// modified, and resolved.
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    public interface IShellLinkW
    {
        /// <summary>
        /// Retrieves the path and file name of a Shell link object.
        /// </summary>
        /// <param name="pszFile">The PSZ file.</param>
        /// <param name="cchMaxPath">The CCH max path.</param>
        /// <param name="pfd">The PFD.</param>
        /// <param name="fFlags">The f flags.</param>
        void GetPath(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile,
            int cchMaxPath,
            out WIN32_FIND_DATAW pfd,
            SLGP_FLAGS fFlags);

        /// <summary>
        /// Retrieves the list of item identifiers for a Shell link object.
        /// </summary>
        void GetIDList(out IntPtr ppidl);

        /// <summary>Sets the pointer to an item identifier list .
        /// (PIDL) for a Shell link object.
        /// </summary>
        void SetIDList(IntPtr pidl);

        /// <summary>
        /// Retrieves the description string for a Shell link object.
        /// </summary>
        void GetDescription(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName,
            int cchMaxName);

        /// <summary>
        /// Sets the description for a Shell link object. The description
        /// can be any application-defined string.
        /// </summary>
        void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

        /// <summary>
        /// Retrieves the name of the working directory for a Shell link
        /// object.
        /// </summary>
        void GetWorkingDirectory(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir,
            int cchMaxPath);

        /// <summary>
        /// Sets the name of the working directory for a Shell link object.
        /// </summary>
        void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

        /// <summary>
        /// Retrieves the command-line arguments associated with a Shell link object.
        /// </summary>
        void GetArguments(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs,
            int cchMaxPath);

        /// <summary>
        /// Sets the command-line arguments for a Shell link object.
        /// </summary>
        void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

        /// <summary>
        /// Retrieves the hot key for a Shell link object.
        /// </summary>
        void GetHotkey(out short pwHotkey);

        /// <summary>
        /// Sets a hot key for a Shell link object.
        /// </summary>
        void SetHotkey(short wHotkey);

        /// <summary>
        /// Retrieves the show command for a Shell link object.
        /// </summary>
        void GetShowCmd(out int piShowCmd);

        /// <summary>
        /// Sets the show command for a Shell link object.
        /// The show command sets the initial show state of the window.
        /// </summary>
        void SetShowCmd(int iShowCmd);

        /// <summary>
        /// Retrieves the location (path and index) of the icon
        /// for a Shell link object.
        /// </summary>
        void GetIconLocation(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath,
            int cchIconPath,
            out int piIcon);

        /// <summary>
        /// Sets the location (path and index) of the icon for a Shell link object.
        /// </summary>
        void SetIconLocation(
            [MarshalAs(UnmanagedType.LPWStr)] string pszIconPath,
            int iIcon);

        /// <summary>
        /// Sets the relative path to the Shell link object.
        /// </summary>
        void SetRelativePath(
            [MarshalAs(UnmanagedType.LPWStr)] string pszPathRel,
            int dwReserved);

        /// <summary>
        /// Attempts to find the target of a Shell link, even if it has been
        /// moved or renamed.
        /// </summary>
        void Resolve(IntPtr hwnd, SLR_FLAGS fFlags);

        /// <summary>
        /// Sets the path and file name of a Shell link object.
        /// </summary>
        void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    } // IShellLinkW
} // Tethys.Win32