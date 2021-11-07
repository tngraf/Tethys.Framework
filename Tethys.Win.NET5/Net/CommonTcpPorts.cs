// ---------------------------------------------------------------------------
// <copyright file="CommonTcpPorts.cs" company="Tethys">
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
    /// Common TCP ports.
    /// </summary>
    public enum CommonTcpPorts
    {
        /// <summary>
        /// Dummy (zero) port.
        /// </summary>
        Zero = 0,

        /// <summary>
        /// echo port
        /// </summary>
        Echo = 7,

        /// <summary>
        /// ftp data port
        /// </summary>
        FtpData = 20,

        /// <summary>
        /// tcp ftp port
        /// </summary>
        Ftp = 21,

        /// <summary>
        /// tcp telnet port
        /// </summary>
        Telnet = 23,

        /// <summary>
        /// tcp simple mail transfer protocol
        /// </summary>
        Smtp = 25,

        /// <summary>
        /// tcp time server
        /// </summary>
        Time = 37,

        /// <summary>
        /// tcp name server
        /// </summary>
        Name = 42,

        /// <summary>
        /// tcp domain name server
        /// </summary>
        Nameserver = 53,

        /// <summary>
        /// tcp finger port
        /// </summary>
        Finger = 79,

        /// <summary>
        /// tcp http port
        /// </summary>
        Http = 80,

        /// <summary>
        /// tcp post office protocol
        /// </summary>
        Pop = 109,

        /// <summary>
        /// tcp post office protocol
        /// </summary>
        Pop2 = 109,

        /// <summary>
        /// tcp post office protocol
        /// </summary>
        Pop3 = 110,

        /// <summary>
        /// tcp network news transfer protocol
        /// </summary>
        Nntp = 119,
    } // CommonTcpPorts
} // Tethys.Net
