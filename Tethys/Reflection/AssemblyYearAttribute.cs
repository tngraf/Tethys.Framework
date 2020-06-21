// --------------------------------------------------------------------------
// Tethys.Framework
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="AssemblyYearAttribute.cs" company="Tethys">
// Copyright  1998-2020 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing,
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied.
// </copyright>
//
// System ... Library netstandard2.0
// Tools .... Microsoft Visual Studio 2019
//
// ---------------------------------------------------------------------------

namespace Tethys.Reflection
{
    using System;

    /// <summary>
    /// User defined attribute for software release year.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public sealed class AssemblyYearAttribute : Attribute
    {
        /// <summary>
        /// The year.
        /// </summary>
        private readonly int year;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyYearAttribute"/> class.
        /// </summary>
        /// <param name="year">The year.</param>
        public AssemblyYearAttribute(int year)
        {
            this.year = year;
        } // AssemblyYearAttribute()

        /// <summary>
        /// Gets the software release year.
        /// </summary>
        public int Year
        {
            get { return this.year; }
        } // Year
    } // AssemblyYearAttribute
} // Tethys.Reflection
