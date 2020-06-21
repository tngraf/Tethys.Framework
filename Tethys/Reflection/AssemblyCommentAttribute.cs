// --------------------------------------------------------------------------
// Tethys.Framework
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="AssemblyCommentAttribute.cs" company="Tethys">
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
    /// User defined attribute for software release comment.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public sealed class AssemblyCommentAttribute : Attribute
    {
        /// <summary>
        /// The comment.
        /// </summary>
        private readonly string comment;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyCommentAttribute"/> class.
        /// </summary>
        /// <param name="comment">The comment.</param>
        public AssemblyCommentAttribute(string comment)
        {
            this.comment = comment;
        } // AssemblyCommentAttribute()

        /// <summary>
        /// Gets the software release comment.
        /// </summary>
        public string Comment
        {
            get { return this.comment; }
        } // Comment
    } // AssemblyCommentAttribute
} // Tethys.Reflection
