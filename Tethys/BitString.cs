// --------------------------------------------------------------------------
// Tethys.Framework
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="BitString.cs" company="Tethys">
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

namespace Tethys
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// This class represents a bit string.
    /// </summary>
    public class BitString
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Width of the bit string.
        /// </summary>
        private readonly int width;

        /// <summary>
        /// Current value of the bit string.
        /// </summary>
        private int value;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets the with of the bit string.
        /// </summary>
        public int Width
        {
            get { return this.width; }
        } // Width

        /// <summary>
        /// Gets or sets the value of the bit string.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2208:InstantiateArgumentExceptionsCorrectly",
            Justification = "Best place for exception..")]
        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value > (1 << this.width))
                {
                    // ReSharper disable NotResolvedInText
                    throw new ArgumentOutOfRangeException("Value");
                    // ReSharper restore NotResolvedInText
                } // if

                this.value = value;
            }
        } // Value
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="BitString" /> class.
        /// Creates a bit string of width 8.
        /// </summary>
        public BitString()
        {
            this.width = 8;
        } // BitString()

        /// <summary>
        /// Initializes a new instance of the <see cref="BitString"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">width;range
        /// for width = 1..32.</exception>
        public BitString(int width)
        {
            if ((width < 1) || (width > 32))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(width),
                    "range for width = 1..32");
            } // if

            this.width = width;
        } // BitString()

        /// <summary>
        /// Initializes a new instance of the <see cref="BitString"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public BitString(BitString source)
        {
            this.width = source.width;
            this.value = source.value;
        } // BitString()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region BASIC CLASS OPERATIONS
        /// <summary>
        /// Tests whether the specified object is a BitString object
        /// and is equivalent to this BitString object.
        /// </summary>
        /// <param name="obj">operand to be compared to the object.</param>
        /// <returns>The function returns true if the two operands are identical.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            } // if

            var cmp = (BitString)obj;
            if (this.value != cmp.value)
            {
                return false;
            } // if

            if (this.width != cmp.width)
            {
                return false;
            } // if

            return true;
        } // Equals()

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <remarks>
        /// This is only a DUMMY - we don't need this method here.
        /// </remarks>
        /// <returns>The hash code.</returns>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1065:DoNotRaiseExceptionsInUnexpectedLocations",
            Justification = "This is ok here.")]
        public override int GetHashCode()
        {
            throw new NotSupportedException(
                "BitString does not support GetHashCode().");
        } // GetHashCode()
        #endregion // BASIC CLASS OPERATIONS

        //// ------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Returns a string representing this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder(this.width);

            for (var i = this.width - 1; i >= 0; i--)
            {
                if ((this.value & (0x0001 << i)) > 0)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                } // if
            } // for

            return sb.ToString();
        } // ToString()

        /// <summary>
        /// Performs a bit-wise AND operation.
        /// </summary>
        /// <param name="operand">Operand for AND operation.</param>
        public void And(int operand)
        {
            this.value &= operand;
        } // And()

        /// <summary>
        /// Performs a bit-wise OR operation.
        /// </summary>
        /// <param name="operand">Operand for OR operation.</param>
        public void Or(int operand)
        {
            this.value |= operand;
        } // Or()

        /// <summary>
        /// Clears the specified bits from the value.
        /// </summary>
        /// <param name="bitsToClear">Bits to be cleared.</param>
        public void Clear(int bitsToClear)
        {
            this.value &= ~bitsToClear;
        } // Clear()
        #endregion // PUBLIC METHODS
    } // BitString
} // Tethys
