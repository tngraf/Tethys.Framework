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
// <copyright file="DiffEventArgs.cs" company="Tethys">
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
    using System;

    /// <summary>
    /// LCS difference algorithm event arguments.
    /// </summary>
    public class DiffEventArgs : EventArgs
    {
        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the difference type (added, subtracted, identical).
        /// </summary>
        public DiffType DiffType { get; set; }

        /// <summary>
        /// Gets or sets the difference item index.
        /// </summary>
        public int LineIndex { get; set; }

        /// <summary>
        /// Gets or sets the difference item value.
        /// </summary>
        public string LineValue { get; set; }
        #endregion // PUBLIC PROPERTIES

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="DiffEventArgs"/>
        /// class.
        /// </summary>
        /// <param name="diffType">Type of the diff.</param>
        /// <param name="lineValue">The line value.</param>
        /// <param name="index">Line index.</param>
        public DiffEventArgs(DiffType diffType, string lineValue, int index)
        {
            this.DiffType = diffType;
            this.LineValue = lineValue;
            this.LineIndex = index;
        } // DiffEventArgs()
        #endregion // CONSTRUCTION
    } // DiffEventArgs
} // Tethys.Text.Diff

// =======================
// End of DiffEventArgs.cs
// =======================