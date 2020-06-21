// --------------------------------------------------------------------------
// Tethys.Framework
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="NumberFormat.cs" company="Tethys">
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

namespace Tethys.Text
{
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// The class Number format implements function to convert number to different
    /// text representation. These function are easier to use than the default .Net
    /// functions.
    /// </summary>
    public static class NumberFormat
    {
        /// <summary>
        /// Translates an integer value to a hexadecimal string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A string.</returns>
        public static string ToHex(int value)
        {
            return string.Format(CultureInfo.CurrentCulture, "0x{0:X}", value);
        } // ToHex

        /// <summary>
        /// Translates an integer value to a hexadecimal string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="leadingZeros">The leading zeros.</param>
        /// <returns>
        /// A string.
        /// </returns>
        public static string ToHex(int value, int leadingZeros)
        {
            var sb = new StringBuilder(10);
            sb.Append(value.ToString("X", CultureInfo.CurrentCulture));

            int cmp = 0x10;
            for (int i = 1; i < leadingZeros; i++)
            {
                if (value < cmp)
                {
                    sb.Insert(0, "0");
                } // if

                cmp *= 0x10;
            } // for

            sb.Insert(0, "0x");

            return sb.ToString();
        } // ToHex

        /// <summary>
        /// Translates an integer value to a binary string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// A string.
        /// </returns>
        public static string ToBinary(byte value)
        {
            var sb = new StringBuilder(10);

            int cmp = 0x01;
            for (int i = 0; i < 8; i++)
            {
                if ((value & cmp) == 0)
                {
                    sb.Insert(0, "0");
                }
                else
                {
                    sb.Insert(0, "1");
                } // if

                cmp *= 0x02;
            } // for

            sb.Insert(0, "0b");

            return sb.ToString();
        } // ToBinary()

        /// <summary>
        /// Translates an integer value to a binary string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// A string.
        /// </returns>
        public static string ToBinary(short value)
        {
            var sb = new StringBuilder(18);

            int cmp = 0x01;
            for (int i = 0; i < 16; i++)
            {
                if ((value & cmp) == 0)
                {
                    sb.Insert(0, "0");
                }
                else
                {
                    sb.Insert(0, "1");
                } // if

                cmp *= 0x02;
            } // for

            sb.Insert(0, "0b");

            return sb.ToString();
        } // ToBinary()

        /// <summary>
        /// Translates an integer value to a binary string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A string.</returns>
        public static string ToBinary(int value)
        {
            var sb = new StringBuilder(34);

            int cmp = 0x01;
            for (int i = 0; i < 32; i++)
            {
                if ((value & cmp) == 0)
                {
                    sb.Insert(0, "0");
                }
                else
                {
                    sb.Insert(0, "1");
                } // if

                cmp *= 0x02;
            } // for

            sb.Insert(0, "0b");

            return sb.ToString();
        } // ToBinary()
    } // NumberFormat
} // Tethys.Text

// ==============================
// Tethys: end of numberformat.cs
// ==============================