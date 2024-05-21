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

    /// <summary>
    /// The IShellLink interface allows Shell links to be created,
    /// modified, and resolved.
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Not here!")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
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
        /// <param name="ppidl">Point to the ID list.</param>
        void GetIDList(out IntPtr ppidl);

        /// <summary>Sets the pointer to an item identifier list .
        /// (PIDL) for a Shell link object.
        /// </summary>
        /// <param name="pidl">Pointer to the ID.</param>
        void SetIDList(IntPtr pidl);

        /// <summary>
        /// Retrieves the description string for a Shell link object.
        /// </summary>
        /// <param name="pszName">The name.</param>
        /// <param name="cchMaxName">Maximum characters of the name.</param>
        void GetDescription(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);

        /// <summary>
        /// Sets the description for a Shell link object. The description
        /// can be any application-defined string.
        /// </summary>
        /// <param name="pszName">The name.</param>
        void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

        /// <summary>
        /// Retrieves the name of the working directory for a Shell link
        /// object.
        /// </summary>
        /// <param name="pszDir">The working directory.</param>
        /// <param name="cchMaxPath">Maximum characters of the working directory.</param>
        void GetWorkingDirectory(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);

        /// <summary>
        /// Sets the name of the working directory for a Shell link object.
        /// </summary>
        /// <param name="pszDir">The working directory.</param>
        void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

        /// <summary>
        /// Retrieves the command-line arguments associated with a Shell link object.
        /// </summary>
        /// <param name="pszArgs">The command-line arguments.</param>
        /// <param name="cchMaxPath">Maximum length of the command-line arguments.</param>
        void GetArguments(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);

        /// <summary>
        /// Sets the command-line arguments for a Shell link object.
        /// </summary>
        /// <param name="pszArgs">The command-line arguments.</param>
        void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

        /// <summary>
        /// Retrieves the hot key for a Shell link object.
        /// </summary>
        /// <param name="pwHotkey">The hot key.</param>
        void GetHotkey(out short pwHotkey);

        /// <summary>
        /// Sets a hot key for a Shell link object.
        /// </summary>
        /// <param name="wHotkey">The hot key.</param>
        void SetHotkey(short wHotkey);

        /// <summary>
        /// Retrieves the show command for a Shell link object.
        /// </summary>
        /// <param name="piShowCmd">Id of the show command.</param>
        void GetShowCmd(out int piShowCmd);

        /// <summary>
        /// Sets the show command for a Shell link object.
        /// The show command sets the initial show state of the window.
        /// </summary>
        /// <param name="iShowCmd">The show command.</param>
        void SetShowCmd(int iShowCmd);

        /// <summary>
        /// Retrieves the location (path and index) of the icon
        /// for a Shell link object.
        /// </summary>
        /// <param name="pszIconPath">The path to the icon.</param>
        /// <param name="cchIconPath">Maximum characters of the path.</param>
        /// <param name="piIcon">Index of the icon.</param>
        void GetIconLocation(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);

        /// <summary>
        /// Sets the location (path and index) of the icon for a Shell link object.
        /// </summary>
        /// <param name="pszIconPath">Path to the icon.</param>
        /// <param name="iIcon">Icon index.</param>
        void SetIconLocation(
            [MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

        /// <summary>
        /// Sets the relative path to the Shell link object.
        /// </summary>
        /// <param name="pszPathRel">The path.</param>
        /// <param name="dwReserved">Reserved.</param>
        void SetRelativePath(
            [MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);

        /// <summary>
        /// Attempts to find the target of a Shell link, even if it has been
        /// moved or renamed.
        /// </summary>
        /// <param name="hwnd">The handle.</param>
        /// <param name="fFlags">The flags.</param>
        void Resolve(IntPtr hwnd, SLR_FLAGS fFlags);

        /// <summary>
        /// Sets the path and file name of a Shell link object.
        /// </summary>
        /// <param name="pszFile">The filename.</param>
        void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    } // IShellLinkW
} // Tethys.Win32