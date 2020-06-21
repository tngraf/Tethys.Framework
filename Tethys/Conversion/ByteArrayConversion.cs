// --------------------------------------------------------------------------
// Tethys.Framework
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="ByteArrayConversion.cs" company="Tethys">
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

namespace Tethys.Conversion
{
  using System;
  using System.Globalization;
  using System.Text;

  /// <summary>
  /// Implementation of some conversion methods.
  /// </summary>
  public static class ByteArrayConversion
  {
    /// <summary>
    /// Translates a string of characters
    /// to its binary representation.
    /// </summary>
    /// <example>
    /// <code>
    /// "ABC" => 0x41, 0x42, 0x43.
    /// </code>
    /// </example>
    /// <param name="input">The text input.</param>
    /// <returns>A byte array.</returns>
    public static byte[] StringToByteArray(string input)
    {
      var dataBin = new byte[input.Length];

      // translate string to byte array
      for (var i = 0; i < input.Length; i++)
      {
        dataBin[i] = Convert.ToByte(input[i]);
      } // for

      return dataBin;
    } // StringToByteArray()

    /// <summary>
    /// Translates a string of two digit hex numbers
    /// to its binary representation.
    /// </summary>
    /// <example>
    /// <code>
    /// "000102FF" => 0x00, 0x01, 0x02, 0xff.
    /// </code>
    /// </example>
    /// <param name="input">The input.</param>
    /// <returns>
    /// A byte array.
    /// </returns>
    /// <exception cref="System.ArgumentOutOfRangeException">
    /// input;input must have an even length.</exception>
    /// <exception cref="System.ArgumentException">
    /// Invalid input value;input.</exception>
    public static byte[] HexStringToByteArray(string input)
    {
      if ((input.Length % 2) != 0)
      {
        throw new ArgumentOutOfRangeException(
            nameof(input), "input must have an even length");
      } // if

      var len = input.Length / 2;
      var dataBin = new byte[len];

      // translate string to byte array
      try
      {
        for (var i = 0; i < len; i++)
        {
          var str = input.Substring(2 * i, 2);
          dataBin[i] = byte.Parse(
              str,
              NumberStyles.HexNumber,
              CultureInfo.InvariantCulture);
        } // for
      }
      catch (Exception)
      {
        throw new ArgumentException("Invalid input value", nameof(input));
      } // catch

      return dataBin;
    } // HexStringToByteArray()

    /// <summary>
    /// Translates a array of bytes to a hexadecimal ASCII representation.
    /// </summary>
    /// <example>
    /// <code>
    /// 0x00, 0x01, 0x05, 0xab, 0xff => "000105ABFF".
    /// </code>
    /// </example>
    /// <param name="data">The data.</param>
    /// <returns>A string.</returns>
    public static string ByteArrayToHexString(byte[] data)
    {
      return ByteArrayToHexString(data, 0, data.Length);
    } // ByteArrayToHexString()

    /// <summary>
    /// Translates a array of bytes to a hexadecimal ASCII representation.
    /// </summary>
    /// <example>
    /// <code>
    /// 0x00, 0x01, 0x05, 0xab, 0xff => "000105ABFF".
    /// </code>
    /// </example>
    /// <param name="data">The data.</param>
    /// <param name="indexStart">The index start.</param>
    /// <param name="len">The len.</param>
    /// <returns>A string.</returns>
    public static string ByteArrayToHexString(byte[] data, int indexStart, int len)
    {
      if (indexStart >= data.Length)
      {
        throw new ArgumentOutOfRangeException(nameof(indexStart));
      } // if

      if (indexStart + len > data.Length)
      {
        throw new ArgumentOutOfRangeException(nameof(len));
      } // if

      var sb = new StringBuilder(data.Length * 2);

      for (var i = 0; i < len; i++)
      {
        sb.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", data[indexStart + i]);
      } // for

      return sb.ToString();
    } // ByteArrayToHexString()
  } // ByteArrayConversion
} // Tethys.Conversion
