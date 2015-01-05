#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="ReleaseMode.cs" company="Tethys">
// Copyright  1998-2015 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing, 
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied. 
// </copyright>
//
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2012
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Reflection
{
  /// <summary>
  /// Enumeration of release modes.
  /// </summary>
  public enum ReleaseMode
  {
    /// <summary>
    /// Internal test version - only for developer
    /// </summary>
    Test = 0,

    /// <summary>
    /// Version for internal test.
    /// </summary>
    Work = 1,

    /// <summary>
    /// Final version for customer.
    /// </summary>
    Final = 2
  } // ReleaseMode
} // Tethys.Reflection
