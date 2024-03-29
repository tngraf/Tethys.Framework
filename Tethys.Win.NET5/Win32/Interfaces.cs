﻿// ---------------------------------------------------------------------------
// <copyright file="Interfaces.cs" company="Tethys">
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

#pragma warning disable 1591
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Not here!")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [ComImport]
    [Guid("0000010c-0000-0000-c000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersist
    {
        [PreserveSig]
        void GetClassID(out Guid pClassId);
    } // IPersist

    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [ComImport]
    [Guid("0000010b-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistFile : IPersist
    {
        new void GetClassID(out Guid pClassId);

        [PreserveSig]
        int IsDirty();

        [PreserveSig]
        void Load(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
            uint dwMode);

        [PreserveSig]
        void Save(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
            [In, MarshalAs(UnmanagedType.Bool)] bool fRemember);

        [PreserveSig]
        void SaveCompleted([In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName);

        [PreserveSig]
        void GetCurFile([In, MarshalAs(UnmanagedType.LPWStr)] string ppszFileName);
    } // IPersistFile

    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [ComImport]
    [Guid("00021401-0000-0000-C000-000000000046")]
    public class ShellLink
    {
    } // ShellLink
#pragma warning restore 1591
} // Tethys.Win32
