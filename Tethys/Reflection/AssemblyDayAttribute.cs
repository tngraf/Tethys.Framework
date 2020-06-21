// --------------------------------------------------------------------------
// Tethys.Framework
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="AssemblyDayAttribute.cs" company="Tethys">
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
    /// User defined attribute for software release day.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public sealed class AssemblyDayAttribute : Attribute
    {
        /// <summary>
        /// The day.
        /// </summary>
        private readonly int day;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyDayAttribute"/> class.
        /// </summary>
        /// <param name="day">The day.</param>
        public AssemblyDayAttribute(int day)
        {
            this.day = day;
        } // AssemblyDayAttribute()

        /// <summary>
        /// Gets the software release day.
        /// </summary>
        public int Day
        {
            get { return this.day; }
        } // Day
    } // AssemblyDayAttribute
} // Tethys.Reflection
