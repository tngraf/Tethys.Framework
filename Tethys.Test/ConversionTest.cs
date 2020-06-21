// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="ConversionTest.cs" company="Tethys">
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

namespace Tethys.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Tethys.Conversion;

    /// <summary>
    /// Unit tests for <see cref="Conversion"/> class.
    /// </summary>
    [TestClass]
    public class ConversionTest
    {
        /// <summary>
        /// Test for <c>StringToByteArray</c>.
        /// </summary>
        [SuppressMessage(
            "StyleCop.CSharp.ReadabilityRules",
            "SA1122:UseStringEmptyForEmptyStrings",
            Justification = "Reviewed. Suppression is OK here.")]
        [TestMethod]
        public void StringToByteArrayTest()
        {
            var actual = ByteArrayConversion.StringToByteArray("");
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Length);

            actual = ByteArrayConversion.StringToByteArray("ABC");
            Assert.IsNotNull(actual);
            Assert.AreEqual(3, actual.Length);
            Assert.AreEqual(0x41, actual[0]);
            Assert.AreEqual(0x42, actual[1]);
            Assert.AreEqual(0x43, actual[2]);

            actual = ByteArrayConversion.StringToByteArray("abc");
            Assert.IsNotNull(actual);
            Assert.AreEqual(3, actual.Length);
            Assert.AreEqual(0x61, actual[0]);
            Assert.AreEqual(0x62, actual[1]);
            Assert.AreEqual(0x63, actual[2]);
        }

        /// <summary>
        /// Test for <c>HexStringToByteArray</c>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AsciiToByteArrayTest1()
        {
            ByteArrayConversion.HexStringToByteArray("1");
        }

        /// <summary>
        /// Test for <c>HexStringToByteArray</c>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AsciiToByteArrayTest2()
        {
            ByteArrayConversion.HexStringToByteArray("xy");
        }

        /// <summary>
        /// Test for <c>HexStringToByteArray</c>.
        /// </summary>
        [TestMethod]
        public void AsciiToByteArrayTest3()
        {
            var actual = ByteArrayConversion.HexStringToByteArray("000102FF");
            Assert.IsNotNull(actual);
            Assert.AreEqual(4, actual.Length);
            Assert.AreEqual(0x00, actual[0]);
            Assert.AreEqual(0x01, actual[1]);
            Assert.AreEqual(0x02, actual[2]);
            Assert.AreEqual(0xFF, actual[3]);
        }

        /// <summary>
        /// Test for <c>ByteArrayToHexString</c>.
        /// </summary>
        [TestMethod]
        public void ByteArrayToAsciiTest1()
        {
            var data = new byte[] { 0x00, 0x01, 0x05, 0xab, 0xff };
            var actual = ByteArrayConversion.ByteArrayToHexString(data);
            Assert.AreEqual(data.Length * 2, actual.Length);
            Assert.AreEqual("000105ABFF", actual);
        }

        /// <summary>
        /// Test for <c>ByteArrayToHexString</c>.
        /// </summary>
        [TestMethod]
        public void ByteArrayToAsciiTest2()
        {
            var data = new byte[] { 0x00, 0x01, 0x05, 0xab, 0xff };
            var actual = ByteArrayConversion.ByteArrayToHexString(data, 0, 0);
            Assert.AreEqual(0, actual.Length);

            actual = ByteArrayConversion.ByteArrayToHexString(data, 0, 2);
            Assert.AreEqual(4, actual.Length);
            Assert.AreEqual("0001", actual);

            actual = ByteArrayConversion.ByteArrayToHexString(data, 2, 2);
            Assert.AreEqual(4, actual.Length);
            Assert.AreEqual("05AB", actual);
        }

        /// <summary>
        /// Test for <c>ByteArrayToHexString</c>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayToAsciiTest3()
        {
            var data = new byte[] { 0x00, 0x01, 0x05, 0xab, 0xff };
            ByteArrayConversion.ByteArrayToHexString(data, 5, 1);
        }

        /// <summary>
        /// Test for <c>ByteArrayToHexString</c>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayToAsciiTest4()
        {
            var data = new byte[] { 0x00, 0x01, 0x05, 0xab, 0xff };
            ByteArrayConversion.ByteArrayToHexString(data, 2, 10);
        }
    } // ConversionTest
} // Tethys.Test
