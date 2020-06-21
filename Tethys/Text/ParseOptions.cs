// --------------------------------------------------------------------------
// Tethys.Framework
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="ParseOptions.cs" company="Tethys">
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

namespace Tethys.Text
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Parsing operation flags for the class TextParse.
    /// </summary>
    [Flags]
    public enum ParseOptions
    {
        /// <summary>
        /// No flags set.
        /// </summary>
        None = 0x0000,

        /// <summary>
        /// Accepts whitespace before and after the parsing location.
        /// </summary>
        SkipSpace = 0x0001,

        /// <summary>
        /// String must be specified in quoted strings.
        /// </summary>
        Quoted = 0x0002,

        /// <summary>
        /// Limit end of the token to the next space area.
        /// </summary>
        ToSpace = 0x0004,

        /// <summary>
        /// Limit end of the token to the current location.
        /// </summary>
        ToLocation = 0x0008,

        /// <summary>
        /// Sets also the end of the token in dependence
        /// of the other token-end-setting flags.
        /// </summary>
        SetEnd = 0x0010,

        /// <summary>
        /// Allow '-'.
        /// </summary>
        Signed = 0x0020,

        /// <summary>
        /// Allow hex digits.
        /// </summary>
        Hex = 0x0040,

        /// <summary>
        /// GetFixName: Accept also digits 0..9 in a name.
        /// </summary>
        Digits = 0x0080,

        /// <summary>
        /// GetFixName: Accept only full names (no proper abbreviations).
        /// </summary>
        FullName = 0x0100,

        /// <summary>
        /// GetFixName: Allow also '_' and '-' within a name.
        /// </summary>
        ExtraChar = 0x0200,

        /// <summary>
        /// Accept numerical overflows and return an <c>INT32/uint</c> modulo value.
        /// </summary>
        Overflow = 0x0400,

        /// <summary>
        /// Only hexadecimal values are permitted.
        /// </summary>
        HexOnly = 0x0800,

        /// <summary>
        /// Besides '.' also ',' is allowed as decimal separator.
        /// </summary>
        Comma = 0x1000,

        /// <summary>
        /// Allow also German umlaute.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1704:IdentifiersShouldBeSpelledCorrectly",
            MessageId = "Umlaute",
            Justification = "This is the correct spelling!")]
        Umlaute = 0x2000,
    } // ParseFlags
} // Tethys.Text
