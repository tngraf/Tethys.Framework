#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common for .Net Windows applications.
//
// ===========================================================================
//
// <copyright file="XCRC.cs" company="Tethys">
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
  /// The class XCRC implements a fast CRC-16 checksum algorithm,
  /// that uses the following polynomial:<br/>
  /// <code>
  /// Polynom = x**16 + x**15 + x**10 + x**8 + x**7
  /// + x**5 + x**3 + 1
  /// (= 0x85A5)
  /// </code>
  /// Default initial value = 0xA695,<br/>
  /// default final XOR value = 0xFFFF.
  /// </summary>
  [CLSCompliant(false)]
  [SuppressMessage("Microsoft.Naming",
    "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "XCRC",
    Justification = "Ok here.")]
  public sealed class XCRC : HashAlgorithm
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
    //                 byte[0]  byte[1]  
    //                 -------  -------  
    // X-CRC(TEST1) =    0x10     0x7D
    // X-CRC(TEST2) =    0x44     0x3E
    // X-CRC(TEST3) =    0x8E     0x37
    // X-CRC(TEST4) =    0x75     0x75
    // ===================================================================

    /// <summary>
    /// Constants used to compute the CRC-16 checksum.
    /// </summary>
    private static ushort[] tab;

    /// <summary>
    /// Hash size in bits.
    /// </summary>
    private const ushort HashSizeBitsXcrc = 16;

    /// <summary>
    /// Hash size in bytes.
    /// </summary>
    private const ushort HashSizeBytesXcrc = 2;

    /// <summary>
    /// Default initial value.
    /// </summary>
    public const ushort DefaultInit = 0xA695;

    /// <summary>
    /// Default final XOR value.
    /// </summary>
    public const ushort DefaultXor = 0xFFFF;

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
    /// Initializes the CRC table.
    /// </summary>
    /// <returns>The CRC table.</returns>
    private static ushort[] BuildTable()
    {
      var localtab = new ushort[256];
      const ushort G = 0x85A5;
      int i;

      for (i = 0; i < 256; i++)
      {
        ushort help;
        int j;
        for (help = (ushort)(i << 8), j = 0; j < 8; j++)
        {
          if ((help & 0x8000) > 0)
          {
            help = (ushort)((help << 1) ^ G);
          }
          else
          {
            help = (ushort)(help << 1);
          } // if
        } // for (help)
        localtab[i] = help;
      } // for (i)

      return localtab;
    } // BuildTable()

    /// <summary>
    /// Initializes a new instance of the <see cref="XCRC"/> class.
    /// </summary>
    public XCRC()
    {
      if (tab == null)
      {
        tab = BuildTable();
      } // if
      HashSizeValue = HashSizeBitsXcrc;
      HashValue = new byte[HashSizeBytesXcrc];
      this.initValue = DefaultInit;
      this.xorValue = DefaultXor;
      Initialize();
    } // XCRC()

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
    protected override void HashCore(byte[] buffer, int offset, int count)
    {
      for (; count != 0; count--, offset++)
      {
        // calculate CRC for next byte
        // using table with 256 entries
        this.crc = (ushort)((this.crc << 8) ^ tab[(this.crc >> 8) ^ buffer[offset]]);
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
      HashValue[1] = (byte)((crcRet & 0xff00) >> 8);
      HashValue[0] = (byte)(crcRet & 0x00ff);

      return HashValue;
    } // HashFinal()
    #endregion // PROTECTED HASH ALGORITHM METHODS
  } // XCRC
} // Tethys.Cryptography

// ======================
// Tethys: end of xcrc.cs
// ======================