#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common for .Net Windows applications.
//
// ===========================================================================
//
// <copyright file="CRC16.cs" company="Tethys">
// Copyright  1998-2015 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing, 
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied. 
// </copyright>
//
// System ... Microsoft .Net Framework 4
// Tools .... Microsoft Visual Studio 2013
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Cryptography
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Cryptography;

    /// <summary>
    /// The class CRC16 implements a fast CRC-16 checksum algorithm,
    /// that uses the following polynomial:<br/>
    /// <code>
    /// x**16 + x**15 + x**2 + 1 ( = 0x8005)
    /// </code>
    /// Default initial value = 0x0000,<br/>
    /// default final XOR value = 0x0000.
    /// </summary>
    [CLSCompliant(false)]
    [SuppressMessage("Microsoft.Naming",
      "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "CRC",
      Justification = "Ok here.")]
    public sealed class CRC16 : HashAlgorithm
    {
        // ===================================================================
        // CHECKSUM RESULTS
        // ===================================================================
        // TEST1 is the three character sequence "ABC".
        // TEST2 is the three character sequence "CBA".
        // TEST3 is the eight character sequence of "12345678"
        // TEST4 is the 1024 character sequence of "12345678"
        // repeated 128 times.
        //
        //                   Value     byte[0]  byte[1]  
        //                 ---------   -------  -------  
        // CRC-16(TEST1) =    4521      0x21     0x45
        // CRC-16(TEST2) =    4401      0x01     0x44
        // CRC-16(TEST3) =    3C9D      0x9D     0x3C
        // CRC-16(TEST4) =    EBF3      0xF3     0xEB
        // ===================================================================

        /*****************************************************************************

        Note  This algorithm is specified by W. D. Schwaderer in his book
        ----  "C Programmer's Guide to NetBIOS" Howard W. Sams & Company
              First Edition 1988.

              The implementation of the minimized-table-4-bit variant was designed
              by Marcellus Buchheit after the guidelines of the CRC-16 algorithm
              in the book above.

        ==============================================================================

        Explanation of the CRC algorithm intermediate remainder register motion.
        The V(x) positions are insertion points of the polynom, x is the power.
        Please note, that the orientation of the bits in the remainder register is
        switched from left to right: The left bit is bit 0, the right bit is bit 15.
        This solves the problem that the incoming data bytes start with the lowest bit
        and not (as stored in the PC memory) with the highest bit. This diagram is
        an expansation and a correction (!) of the [Schwaderer] tables at page 190
        and 191.

        CRC-16  V(0)  V(2)                                   V(15) <- insert positions
        ------   16 15 14 13 12 11 10 09 08 07 06 05 04 03 02 01
                -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --
        Cycle 1  V1    V1                                     V1

        Cycle 2  V1 V1 V1 V1                                  V1
                V2    V2                                     V2

        Cycle 3  V1 V1 V2 V1 V1                               V1
                V2 V2 V3 V2                                  V2
                V3                                           V3

        Cycle 4  V1 V1 V3 V2 V1 V1                            V1
                V2 V2 V4 V3 V2                               V2
                V3 V3                                        V3
                V4                                           V4

        Cycle 5  V1 V1 V4 V3 V2 V1 V1                         V1
                V2 V2 V5 V4 V3 V2                            V2
                V3 V3                                        V3
                V4 V4                                        V4
                V5                                           V5

        Cycle 6  V1 V1 V5 V4 V3 V2 V1 V1                      V1
                V2 V2 V6 V5 V4 V3 V2                         V2
                V3 V3                                        V3
                V4 V4                                        V4
                V5 V5                                        V5
                V6                                           V6

        Cycle 7  V1 V1 V6 V5 V4 V3 V2 V1 V1                   V1
                V2 V2 V7 V6 V5 V4 V3 V2                      V2
                V3 V3                                        V3
                V4 V4                                        V4
                V5 V5                                        V5
                V6 V6                                        V6
                V7                                           V7

        Cycle 8  V1 V1 V7 V6 V5 V4 V3 V2 V1 V1                V1
                V2 V2 V8 V7 V6 V5 V4 V3 V2                   V2
                V3 V3                                        V3
                V4 V4                                        V4
                V5 V5                                        V5
                V6 V6                                        V6
                V7 V7                                        V7
                V8                                           V8

        *****************************************************************************/

        /// <summary>
        /// Constants used to compute the CRC-16 checksum.
        /// (Table for CCITT polynomial.)
        /// </summary>
        private static readonly uint[] Tab16 =
    {
      0x0000, 0xC0C1, 0xC181, 0x0140, 0xC301, 0x03C0, 0x0280, 0xC241,
      0xC601, 0x06C0, 0x0780, 0xC741, 0x0500, 0xC5C1, 0xC481, 0x0440,
      0xCC01, 0x0CC0, 0x0D80, 0xCD41, 0x0F00, 0xCFC1, 0xCE81, 0x0E40,
      0x0A00, 0xCAC1, 0xCB81, 0x0B40, 0xC901, 0x09C0, 0x0880, 0xC841,
      0xD801, 0x18C0, 0x1980, 0xD941, 0x1B00, 0xDBC1, 0xDA81, 0x1A40,
      0x1E00, 0xDEC1, 0xDF81, 0x1F40, 0xDD01, 0x1DC0, 0x1C80, 0xDC41,
      0x1400, 0xD4C1, 0xD581, 0x1540, 0xD701, 0x17C0, 0x1680, 0xD641,
      0xD201, 0x12C0, 0x1380, 0xD341, 0x1100, 0xD1C1, 0xD081, 0x1040,
      0xF001, 0x30C0, 0x3180, 0xF141, 0x3300, 0xF3C1, 0xF281, 0x3240,
      0x3600, 0xF6C1, 0xF781, 0x3740, 0xF501, 0x35C0, 0x3480, 0xF441,
      0x3C00, 0xFCC1, 0xFD81, 0x3D40, 0xFF01, 0x3FC0, 0x3E80, 0xFE41,
      0xFA01, 0x3AC0, 0x3B80, 0xFB41, 0x3900, 0xF9C1, 0xF881, 0x3840,
      0x2800, 0xE8C1, 0xE981, 0x2940, 0xEB01, 0x2BC0, 0x2A80, 0xEA41,
      0xEE01, 0x2EC0, 0x2F80, 0xEF41, 0x2D00, 0xEDC1, 0xEC81, 0x2C40,
      0xE401, 0x24C0, 0x2580, 0xE541, 0x2700, 0xE7C1, 0xE681, 0x2640,
      0x2200, 0xE2C1, 0xE381, 0x2340, 0xE101, 0x21C0, 0x2080, 0xE041,
      0xA001, 0x60C0, 0x6180, 0xA141, 0x6300, 0xA3C1, 0xA281, 0x6240,
      0x6600, 0xA6C1, 0xA781, 0x6740, 0xA501, 0x65C0, 0x6480, 0xA441,
      0x6C00, 0xACC1, 0xAD81, 0x6D40, 0xAF01, 0x6FC0, 0x6E80, 0xAE41,
      0xAA01, 0x6AC0, 0x6B80, 0xAB41, 0x6900, 0xA9C1, 0xA881, 0x6840,
      0x7800, 0xB8C1, 0xB981, 0x7940, 0xBB01, 0x7BC0, 0x7A80, 0xBA41,
      0xBE01, 0x7EC0, 0x7F80, 0xBF41, 0x7D00, 0xBDC1, 0xBC81, 0x7C40,
      0xB401, 0x74C0, 0x7580, 0xB541, 0x7700, 0xB7C1, 0xB681, 0x7640,
      0x7200, 0xB2C1, 0xB381, 0x7340, 0xB101, 0x71C0, 0x7080, 0xB041,
      0x5000, 0x90C1, 0x9181, 0x5140, 0x9301, 0x53C0, 0x5280, 0x9241,
      0x9601, 0x56C0, 0x5780, 0x9741, 0x5500, 0x95C1, 0x9481, 0x5440,
      0x9C01, 0x5CC0, 0x5D80, 0x9D41, 0x5F00, 0x9FC1, 0x9E81, 0x5E40,
      0x5A00, 0x9AC1, 0x9B81, 0x5B40, 0x9901, 0x59C0, 0x5880, 0x9841,
      0x8801, 0x48C0, 0x4980, 0x8941, 0x4B00, 0x8BC1, 0x8A81, 0x4A40,
      0x4E00, 0x8EC1, 0x8F81, 0x4F40, 0x8D01, 0x4DC0, 0x4C80, 0x8C41,
      0x4400, 0x84C1, 0x8581, 0x4540, 0x8701, 0x47C0, 0x4680, 0x8641,
      0x8201, 0x42C0, 0x4380, 0x8341, 0x4100, 0x81C1, 0x8081, 0x4040
    }; // Tab16[]

        /// <summary>
        /// Hash size in bits.
        /// </summary>
        private const ushort HashSizeBitsCrc16 = 16;

        /// <summary>
        /// Hash size in bytes.
        /// </summary>
        private const ushort HashSizeBytesCrc16 = 2;

        /// <summary>
        /// Default initial value.
        /// </summary>
        public const ushort DefaultInit = 0x0000;

        /// <summary>
        /// Default final XOR value.
        /// </summary>
        public const ushort DefaultXor = 0x0000;

        /// <summary>
        /// Initial value.
        /// </summary>
        private ushort initValue;

        /// <summary>
        /// Final XOR value.
        /// </summary>
        private ushort xorValue;

        /// <summary>
        /// 16 bit CRC value.
        /// </summary>
        private ushort crc;

        #region PUBLIC HASH ALGORITHM METHODS
        /// <summary>
        /// Gets or sets the initial value.
        /// </summary>
        public ushort InitValue
        {
            get
            {
                return this.initValue;
            }

            set
            {
                this.initValue = value;
                Initialize();
            }
        } // InitValue

        /// <summary>
        /// Gets or sets the final XOR value.
        /// </summary>
        public ushort XorValue
        {
            get { return this.xorValue; }
            set { this.xorValue = value; }
        } // XorValue

        /// <summary>
        /// Initializes a new instance of the <see cref="CRC16"/> class.
        /// </summary>
        public CRC16()
        {
            HashSizeValue = HashSizeBitsCrc16;
            HashValue = new byte[HashSizeBytesCrc16];
            this.initValue = DefaultInit;
            this.xorValue = DefaultXor;
            Initialize();
        } // CRC16()

        /// <summary>
        /// Initializes an implementation of HashAlgorithm.
        /// </summary>
        public override void Initialize()
        {
            this.crc = this.initValue;
            HashValue[0] = (byte)((this.crc & 0xff00) >> 8);
            HashValue[1] = (byte)(this.crc & 0x00ff);
        } // Initialize()
        #endregion // PUBLIC HASH ALGORITHM METHODS

        #region PROTECTED HASH ALGORITHM METHODS
        /// <summary>
        /// Routes data written to the object into the hash
        /// algorithm for computing the hash.<br/>
        /// This function calculates the CRC-16-checksum via the specified partial block.
        /// The CRC-16 value of the previous calculation is updated the specified block.<br/>
        /// </summary>
        /// <param name="buffer">The input for which to compute the hash code. </param>
        /// <param name="offset">The offset into the byte array from which to begin using data. </param>
        /// <param name="count">The number of bytes in the byte array to use as data.</param>
        /// <remarks>
        /// Before the CRC-16 for a complete sequence is calculated, the CRC value must
        /// be set to 0. After calculation the complete sequence, the result is stored
        /// in the little-endian form (low byte/high byte) after the sequence. To check
        /// the complete sequence including this value, the same values are used and the
        /// final result must be 0, otherwise one or more bits in the complete sequence
        /// is wrong.
        /// It uses following generator polynomial:
        /// x**16 + x**15 + x**2 + x + 1
        /// </remarks>
        protected override void HashCore(byte[] buffer, int offset, int count)
        {
            for (; count != 0; count--, offset++)
            {
                // calculate CRC for next byte
                // using table with 256 entries
                int i = (this.crc ^ buffer[offset]) & 0x00FF;
                this.crc = (ushort)(((this.crc >> 8) & 0x00FF) ^ Tab16[i]);
            } // for
        } // HashCore()

        /// <summary>
        /// Finalizes the hash computation after the last data is processed
        /// by the cryptographic stream object.
        /// </summary>
        /// <returns>The computed hash code.</returns>
        protected override byte[] HashFinal()
        {
            var crcRet = (ushort)(this.crc ^ this.xorValue);

            // save new calculated value
            HashValue[0] = (byte)((crcRet & 0xff00) >> 8);
            HashValue[1] = (byte)(crcRet & 0x00ff);

            return HashValue;
        } // HashFinal()
        #endregion // PROTECTED HASH ALGORITHM METHODS
    } // CRC16
} // Tethys.Cryptography

// =======================
// Tethys: end of crc16.cs
// =======================