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
// <copyright file="AssemblyFirstYearAttribute.cs" company="Tethys">
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
    using System;

    /// <summary>
    /// User defined attribute for software release first year.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public sealed class AssemblyFirstYearAttribute : Attribute
    {
        /// <summary>
        /// The first year.
        /// </summary>
        private readonly int firstyear;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyFirstYearAttribute"/> class.
        /// </summary>
        /// <param name="firstyear">The first year.</param>
        public AssemblyFirstYearAttribute(int firstyear)
        {
            this.firstyear = firstyear;
        } // AssemblyFirstYearAttribute()

        /// <summary>
        /// Gets the first software release year.
        /// </summary>
        public int FirstYear
        {
            get { return this.firstyear; }
        } // FirstYear
    } // AssemblyFirstYearAttribute
} // Tethys.Reflection
