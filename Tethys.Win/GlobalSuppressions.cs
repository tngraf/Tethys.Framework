#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common for .Net Windows applications.
//
// ===========================================================================
//
// <copyright file="GlobalSuppressions.cs" company="Tethys">
// Copyright  1998-2015 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing, 
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied. 
// </copyright>
//
// System ... Microsoft .Net Framework 4
// Tools .... Microsoft Visual Studio 2013
//
// ---------------------------------------------------------------------------
#endregion

// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.
using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("Microsoft.Design",
  "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
  Target = "Tethys", Justification = "Ok here.")]

[module: SuppressMessage("Microsoft.Design",
  "CA1020:AvoidNamespacesWithFewTypes",
  Scope = "namespace", Target = "Tethys.Cryptography",
  Justification = "Ok here.")]

[module: SuppressMessage("Microsoft.Design",
  "CA1020:AvoidNamespacesWithFewTypes",
  Scope = "namespace", Target = "Tethys.Net",
  Justification = "Ok here.")]

[module: SuppressMessage("Microsoft.Design",
  "CA1020:AvoidNamespacesWithFewTypes",
  Scope = "namespace", Target = "Tethys.App",
  Justification = "Ok here.")]

[assembly: SuppressMessage("Microsoft.Naming", 
    "CA1709:IdentifiersShouldBeCasedCorrectly",
    Scope = "namespace", Target = "Tethys.Win32",
    Justification = "Ignore Win32 native support.")] 

[assembly: SuppressMessage("Microsoft.Security",
  "CA2111:PointersShouldNotBeVisible", Justification = "ok for Win32 support")]

[assembly: SuppressMessage(
  "Microsoft.Interoperability", 
  "CA1401:PInvokesShouldNotBeVisible", Scope = "member", 
  Target = "Tethys.Win32",
  Justification = "ok for Win32 support")]

[assembly: SuppressMessage("Microsoft.Design", 
  "CA1060:MovePInvokesToNativeMethodsClass", Scope = "member",
  Target = "Tethys.Win32",
  Justification = "ok for Win32 support")]

// =================================