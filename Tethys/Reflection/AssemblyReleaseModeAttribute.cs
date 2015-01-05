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
// <copyright file="AssemblyReleaseModeAttribute.cs" company="Tethys">
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
    /// User defined attribute for software release mode.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public sealed class AssemblyReleaseModeAttribute : Attribute
    {
        /// <summary>
        /// The release mode.
        /// </summary>
        private readonly ReleaseMode releasemode;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyReleaseModeAttribute"/> class.
        /// </summary>
        /// <param name="releasemode">The release mode.</param>
        public AssemblyReleaseModeAttribute(ReleaseMode releasemode)
        {
            this.releasemode = releasemode;
        } // AssemblyReleaseModeAttribute()

        /// <summary>
        /// Gets the software release mode.
        /// </summary>
        public ReleaseMode ReleaseMode
        {
            get { return this.releasemode; }
        } // ReleaseMode
    } // AssemblyReleaseModeAttribute
} // Tethys.Reflection
