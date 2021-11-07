// ---------------------------------------------------------------------------
// <copyright file="IcmpEchoRequest.cs" company="Tethys">
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
    /// <summary>
    /// ICMP Echo Request, size is 8 + 32 = 40 bytes.
    /// (PacketSize as defined) = 32 bytes.
    /// </summary>
    public class IcmpEchoRequest
    {
        /// <summary>
        /// Gets or sets the ICMP header.
        /// </summary>
        public IcmpHeader Header { get; set; }

        /// <summary>
        /// Gets or sets the ICMP data.
        /// </summary>
        public byte[] Data { get; set; }
    } // IcmpEchoRequest
} // Tethys.Net
