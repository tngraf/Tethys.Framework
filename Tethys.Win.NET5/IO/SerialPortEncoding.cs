// ---------------------------------------------------------------------------
// <copyright file="SerialPortEncoding.cs" company="Tethys">
//   Copyright (C) 1998-2021 T. Graf
// </copyright>
//
// SPDX-License-Identifier: Apache-2.0
//
// Licensed under the Apache License, Version 2.0.
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied.
// ---------------------------------------------------------------------------

// ReSharper disable once CheckNamespace
namespace Tethys.IO
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents an ASCII character encoding of Unicode characters.
    /// In difference to ASCIIEncoding this encoding class supports the special
    /// characters handling that is needed for a proper XModem file transmission.
    /// </summary>
    public class SerialPortEncoding : Encoding
    {
        /// <summary>
        /// The code page.
        /// </summary>
        private const int GermanCodePage = 1252;

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets the name for this encoding that can be used with mail agent body tags.
        /// Not supported by SerialPortEncoding.
        /// </summary>
        public override string BodyName
        {
            get { return string.Empty; }
        } // BodyName

        /// <summary>
        /// Gets the code page identifier of this encoding.
        /// </summary>
        public override int CodePage
        {
            get { return 0; }
        } // CodePage

        /// <summary>
        /// Gets the human-readable description of the encoding.
        /// </summary>
        public override string EncodingName
        {
            get { return "Special Encoding for serial port"; }
        } // EncodingName

        /// <summary>
        /// Gets the name for this encoding that can be used with mail agent header tags.
        /// </summary>
        public override string HeaderName
        {
            get { return string.Empty; }
        } // HeaderName

        /// <summary>
        /// Gets a value indicating whether this encoding can be used for display by browser clients.
        /// </summary>
        public override bool IsBrowserDisplay
        {
            get { return false; }
        } // IsBrowserDisplay

        /// <summary>
        /// Gets a value indicating whether this encoding can be used for saving by browser clients.
        /// </summary>
        public override bool IsBrowserSave
        {
            get { return false; }
        } // IsBrowserSave

        /// <summary>
        /// Gets a value indicating whether this encoding can be used for display by mail and news clients.
        /// </summary>
        public override bool IsMailNewsDisplay
        {
            get { return false; }
        } // IsMailNewsDisplay

        /// <summary>
        /// Gets a value indicating whether this encoding can be used for saving by mail and news clients.
        /// </summary>
        public override bool IsMailNewsSave
        {
            get { return false; }
        } // IsMailNewsSave

        /// <summary>
        /// Gets the name registered with the Internet Assigned Numbers Authority (IANA) for this encoding.
        /// </summary>
        public override string WebName
        {
            get { return string.Empty; }
        } // WebName

        /// <summary>
        /// Gets the Windows operating system code page that most closely corresponds to this encoding.
        /// </summary>
        public override int WindowsCodePage
        {
            get { return 0; }
        } // WindowsCodePage
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region BASIC CLASS METHODS
        /// <summary>
        /// Tests whether the specified object is a SerialPortEncoding object
        /// and is equivalent to this SerialPortEncoding object.
        /// </summary>
        /// <param name="obj">operand to be compared to the object.</param>
        /// <returns>The function returns true if the two operands are identical.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            } // if

            // ALWAYS
            return false;
        } // Equals()

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <remarks>
        /// This is only a DUMMY - we don't need this method here.
        /// </remarks>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return GermanCodePage;
        } // GetHashCode()
        #endregion // BASIC CLASS METHODS

        //// ---------------------------------------------------------------------

        #region CORE FUNCTIONS
        /// <summary>
        /// Calculates the number of bytes required to store the results of
        /// encoding the characters from a specified String.
        /// </summary>
        /// <param name="s">The <see cref="T:System.String" /> containing the
        /// set of characters to encode.</param>
        /// <returns>
        /// The byte count.
        /// </returns>
        public override int GetByteCount(string s)
        {
            return GetEncoding(GermanCodePage).GetByteCount(s);
        } // GetByteCount()

        /// <summary>
        /// Calculates the number of bytes required to store the results of
        /// encoding a set of characters from a specified Unicode character array.
        /// </summary>
        /// <param name="chars">The Unicode character array to encode.</param>
        /// <param name="index">The index of the first character in chars to encode.</param>
        /// <param name="count">The number of characters to encode.</param>
        /// <returns>The byte count.</returns>
        public override int GetByteCount(char[] chars, int index, int count)
        {
            return GetEncoding(GermanCodePage).GetByteCount(chars, index, count);
        } // GetByteCount()

        /// <summary>
        /// Encodes a specified range of elements from a Unicode character array,
        /// and stores the results in a specified range of elements in a byte
        /// array.
        /// </summary>
        /// <param name="chars">The character array containing the set of characters to encode.</param>
        /// <param name="charIndex">The index of the first character to encode.</param>
        /// <param name="charCount">The number of characters to encode.</param>
        /// <param name="bytes">The byte array to contain the resulting sequence of bytes.</param>
        /// <param name="byteIndex">The index at which to start writing the resulting sequence of bytes.</param>
        /// <returns>
        /// The actual number of bytes written into <paramref name="bytes" />.
        /// </returns>
        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            return GetEncoding(GermanCodePage).GetBytes(chars, charIndex, charCount, bytes, byteIndex);
        } // GetBytes()

        /// <summary>
        /// Encodes a specified range of characters from a String and stores the
        /// results in a specified range of elements in a byte array.
        /// </summary>
        /// <param name="s">The string of characters to encode.</param>
        /// <param name="charIndex">The index of the first character in chars to
        /// encode.</param>
        /// <param name="charCount">The number of characters to encode. </param>
        /// <param name="bytes">The byte array where the encoded results are stored.</param>
        /// <param name="byteIndex">The index of the first element in bytes where
        /// the encoded results are stored.</param>
        /// <returns>The bytes.</returns>
        public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            return GetEncoding(GermanCodePage).GetBytes(s, charIndex, charCount, bytes, byteIndex);
        } // GetBytes()

        /// <summary>
        /// Encodes a specified character array into a byte array.
        /// </summary>
        /// <param name="chars">The character array to encode. </param>
        /// <returns>
        /// A byte array containing the encoded representation of the
        /// specified range of characters in chars.
        /// </returns>
        public override byte[] GetBytes(char[] chars)
        {
            return this.GetBytes(chars, 0, chars.Length);
        } // GetBytes()

        /// <summary>
        /// Encodes a specified String into an array of bytes.
        /// </summary>
        /// <param name="s">The character string to encode. </param>
        /// <returns>
        /// A byte array containing the encoded representation of the
        /// specified range of characters in chars.
        /// </returns>
        public override byte[] GetBytes(string s)
        {
            return this.GetBytes(s.ToCharArray(), 0, s.Length);
        } // GetBytes()

        /// <summary>
        /// Encodes a range of characters from a character array into a byte array.
        /// </summary>
        /// <param name="chars">The character array to encode. </param>
        /// <param name="index">The starting index of the character array to encode. </param>
        /// <param name="count">The number of characters to encode.</param>
        /// <returns>
        /// A byte array containing the encoded representation of the
        /// specified range of characters in chars.
        /// </returns>
        public override byte[] GetBytes(char[] chars, int index, int count)
        {
            return GetEncoding(GermanCodePage).GetBytes(chars, index, count);
        } // GetBytes()

        /// <summary>
        /// Calculates the number of characters that would result from decoding a
        /// specified range of elements in a byte array.
        /// </summary>
        /// <param name="bytes">The byte array to decode.</param>
        /// <param name="index">The index of the first byte in bytes to decode.</param>
        /// <param name="count">The number of bytes to decode.</param>
        /// <returns>
        /// The number of characters that would result from decoding the
        /// specified range of elements in bytes.
        /// </returns>
        public override int GetCharCount(byte[] bytes, int index, int count)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            } // if

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "index must be >= 0");
            } // if

            if (index + count > bytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "index + count must be <= length");
            } // if

            return GetEncoding(GermanCodePage).GetCharCount(bytes, index, count);
        } // GetCharCount()

        /// <summary>
        /// Decodes a specified range of elements from a byte array, and stores the
        /// result into a specified range of elements in a Unicode character array.
        /// </summary>
        /// <param name="bytes">The byte array to decode. </param>
        /// <param name="byteIndex">The index of the first element in bytes to decode. </param>
        /// <param name="byteCount">The number of elements to decode. </param>
        /// <param name="chars">The character array where the decoded results are stored. </param>
        /// <param name="charIndex">The index of the first element in chars to store decoded results. </param>
        /// <returns>
        /// The number of characters stored in chars.
        /// </returns>
        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            for (var i = 0; i < byteCount; i++)
            {
                chars[charIndex + i] = (char)bytes[byteIndex + i];
            } // for

            return byteCount;
        } // GetChars()

        /// <summary>
        /// Calculates the maximum number of bytes required to encode a
        /// specified number of characters.
        /// </summary>
        /// <param name="charCount">The number of characters to encode.</param>
        /// <returns>
        /// The maximum number of bytes required to encode charCount number of
        /// characters.
        /// </returns>
        public override int GetMaxByteCount(int charCount)
        {
            if (charCount < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(charCount),
                    charCount,
                    "charCount must be >= 0");
            } // if

            // we have a 1:1 mapping
            return charCount;
        } // GetMaxByteCount()

        /// <summary>
        /// Calculates the maximum number of characters that can result from
        /// decoding a specified number of bytes.
        /// </summary>
        /// <param name="byteCount">The number of bytes to decode. </param>
        /// <returns>The maximum number of characters that can result from
        /// decoding byteCount number of bytes.</returns>
        public override int GetMaxCharCount(int byteCount)
        {
            if (byteCount < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(byteCount),
                    byteCount,
                    "byteCount must be >= 0");
            } // if

            // we have a 1:1 mapping
            return byteCount;
        } // GetMaxCharCount()

        #endregion // CORE FUNCTIONS
    } // SerialPortEncoding
} // Tethys.IO
