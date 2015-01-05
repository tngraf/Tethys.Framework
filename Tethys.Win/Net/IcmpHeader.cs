#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common for .Net Windows applications.
//
// ===========================================================================
//
// <copyright file="IcmpHeader.cs" company="Tethys">
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

namespace Tethys.Net
{
  using System;

    /// <summary>
  /// ICMP header, size is 8 bytes
  /// </summary>
  [CLSCompliant(false)]
  public class IcmpHeader
  {
    /// <summary>
    /// Gets or sets the header type.
    /// </summary>
    public byte HeaderType { get; set; }

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    public byte Code { get; set; }

    /// <summary>
    /// Gets or sets the checksum.
    /// </summary>
    public ushort Checksum { get; set; }

    /// <summary>
    /// Gets or sets the identification.
    /// </summary>
    public ushort Id { get; set; }

    /// <summary>
    /// Gets or sets the sequence.
    /// </summary>
    public ushort Seq { get; set; }
  } // IcmpHeader
} // Tethys.Net
