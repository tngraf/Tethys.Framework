// ---------------------------------------------------------------------------
// <copyright file="IcmpHeader.cs" company="Tethys">
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
namespace Tethys.Net
{
  using System;

    /// <summary>
  /// ICMP header, size is 8 bytes.
  /// </summary>
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
