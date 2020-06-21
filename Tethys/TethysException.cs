// --------------------------------------------------------------------------
// Tethys.Framework
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="TethysException.cs" company="Tethys">
// Copyright  1998-2020 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing,
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied.
// </copyright>
//
// System ... netstandard2.0
// Tools .... Microsoft Visual Studio 2019
//
// ---------------------------------------------------------------------------

namespace Tethys
{
    using System;

    /// <summary>
    /// TgException is the base exception class for all Tethys exception.
    /// </summary>
    public class TethysException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TethysException"/>
        /// class.
        /// </summary>
        public TethysException()
        {
        } // TethysException()

        /// <summary>
        /// Initializes a new instance of the <see cref="TethysException"/>
        /// class.
        /// </summary>
        /// <param name="message">exception message.</param>
        public TethysException(string message)
            : base(message)
        {
        } // TethysException()

        /// <summary>
        /// Initializes a new instance of the <see cref="TethysException"/>
        /// class.
        /// </summary>
        /// <param name="message">exception message.</param>
        /// <param name="ex">inner exception.</param>
        public TethysException(string message, Exception ex)
            : base(message, ex)
        {
        } // TethysException()
    } // TethysException
} // Tethys

// =================================
// Tethys: end of TethysException.cs
// =================================