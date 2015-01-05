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
// <copyright file="DiffType.cs" company="Tethys">
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

namespace Tethys.Text
{
    /// <summary>
    /// Possible difference types.
    /// </summary>
    public enum DiffType
    {
        /// <summary>
        /// Both items are identical.
        /// </summary>
        None = 0,

        /// <summary>
        /// An item has been added.
        /// </summary>
        Add = 1,

        /// <summary>
        /// An item has been removed.
        /// </summary>
        Subtract = 2
    } // DiffType
} // Tethys.Text.Diff

// ==================
// End of DiffType.cs
// ==================
