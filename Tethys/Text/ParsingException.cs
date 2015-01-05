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
// <copyright file="ParsingException.cs" company="Tethys">
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
    /// Enumeration of parsing error codes.
    /// </summary>
    public enum ParsingError
    {
        /// <summary>
        /// No error.
        /// </summary>
        NoError = 0,

        /// <summary>
        /// Line end expected.
        /// </summary>
        EndExpected = 1,

        /// <summary>
        /// String expected.
        /// </summary>
        StringExpected = 2,

        /// <summary>
        /// Specification is ambiguous.
        /// </summary>
        SpecAmbiguous = 3,

        /// <summary>
        /// Number expected.
        /// </summary>
        NumberExpected = 4,

        /// <summary>
        /// Specification not found.
        /// </summary>
        SpecNotFound = 5,

        /// <summary>
        /// Decimal number expected.
        /// </summary>
        DecimalNumberExpected = 6,

        /// <summary>
        /// Number expected.
        /// </summary>
        FloatNumberExpected = 7,

        /// <summary>
        /// End of string expected.
        /// </summary>
        StringEndExpected = 8
    } // ParsingError

    /// <summary>
    /// Implements the ParsingException used by the TextParse class.
    /// </summary> 
    public class ParsingException : Exception
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Parsing error code.
        /// </summary>
        private readonly ParsingError error;

        /// <summary>
        /// Last token that has been successfully parsed.
        /// </summary>
        private readonly string lastToken;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets the parsing error.
        /// </summary>
        public ParsingError Error
        {
            get { return this.error; }
        }

        /// <summary>
        /// Gets the last token (= error location).
        /// </summary>
        public string LastToken
        {
            get { return this.lastToken; }
        }
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="ParsingException"/>
        /// class.
        /// </summary>
        public ParsingException()
        {
        } // ParsingException

        /// <summary>
        /// Initializes a new instance of the <see cref="ParsingException"/>
        /// class.
        /// </summary>
        /// <param name="error">The error.</param>
        public ParsingException(ParsingError error)
        {
            this.error = error;
        } // ParsingException

        /// <summary>
        /// Initializes a new instance of the <see cref="ParsingException"/> 
        /// class.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="lastToken">The last token.</param>
        public ParsingException(ParsingError error, string lastToken)
        {
            this.error = error;
            this.lastToken = lastToken;
        } // ParsingException

        /// <summary>
        /// Initializes a new instance of the <see cref="ParsingException"/> 
        /// class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ParsingException(string message)
            : base(message)
        {
        } // ParsingException()

        /// <summary>
        /// Initializes a new instance of the <see cref="ParsingException"/> 
        /// class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ParsingException(string message, Exception innerException)
            : base(message, innerException)
        {
        } // ParsingException()
        #endregion // CONSTRUCTION
    } // ParsingException()
} // Tethys.Text

// ==========================
// End of ParsingException.cs
// ==========================
