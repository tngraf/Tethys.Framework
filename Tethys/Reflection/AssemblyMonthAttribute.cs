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
// <copyright file="AssemblyMonthAttribute.cs" company="Tethys">
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
    /// User defined attribute for software release month.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public sealed class AssemblyMonthAttribute : Attribute
    {
        /// <summary>
        /// The month.
        /// </summary>
        private readonly int month;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyMonthAttribute"/> class.
        /// </summary>
        /// <param name="month">The month.</param>
        public AssemblyMonthAttribute(int month)
        {
            this.month = month;
        } // AssemblyMonthAttribute()

        /// <summary>
        /// Gets the software release month.
        /// </summary>
        public int Month
        {
            get { return this.month; }
        } // Month
    } // AssemblyMonthAttribute
} // Tethys.Reflection
