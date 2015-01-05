#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common for .Net Windows applications.
//
// ===========================================================================
//
// <copyright file="IcmpEchoRequest.cs" company="Tethys">
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
  using System.Diagnostics.CodeAnalysis;

    /// <summary>
  /// ICMP Echo Request, size is 8 + 32 = 40 bytes.
  /// (PacketSize as defined) = 32 bytes 
  /// </summary>
  [CLSCompliant(false)]
  public class IcmpEchoRequest
  {
    /// <summary>
    /// Gets or sets the ICMP header.
    /// </summary>
    public IcmpHeader Header { get; set; }

    /// <summary>
    /// Gets or sets the ICMP data.
    /// </summary>
    [SuppressMessage("Microsoft.Performance",
    "CA1819:PropertiesShouldNotReturnArrays",
    Justification = "Ok here.")]
    public byte[] Data { get; set; }
  } // IcmpEchoRequest
} // Tethys.Net
