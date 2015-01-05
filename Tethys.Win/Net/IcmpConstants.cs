#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common for .Net Windows applications.
//
// ===========================================================================
//
// <copyright file="IcmpConstants.cs" company="Tethys">
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// ICMP constants 
    /// </summary>
    [SuppressMessage("Microsoft.Performance",
      "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes",
      Justification = "No need for that...")]
    public struct IcmpConstants
    {
        /// <summary>
        /// Echo reply query
        /// </summary>
        public const int EchoReply = 0;

        /// <summary>
        /// Destination unreachable
        /// </summary>
        public const int DestUnreachable = 3;

        /// <summary>
        /// Source quench
        /// </summary>
        public const int SourceQuench = 4;

        /// <summary>
        /// Redirect message type
        /// </summary>
        public const int Redirect = 5;

        /// <summary>
        /// Echo request query
        /// </summary>
        public const int EchoReq = 8;

        /// <summary>
        /// TTL exceeded error
        /// </summary>
        public const int TimeExceeded = 11;

        /// <summary>
        /// Parameter Problem
        /// </summary>
        public const int ParameterProblem = 12;

        /// <summary>
        /// Timestamp message
        /// </summary>
        public const int TimestampMsg = 13;

        /// <summary>
        /// Timestamp reply
        /// </summary>
        public const int TimestampReply = 14;

        /// <summary>
        /// Information request
        /// </summary>
        public const int InfoReq = 15;

        /// <summary>
        /// Information reply
        /// </summary>
        public const int InfoReply = 16;

        /// <summary>
        /// Default TTL (time to live)
        /// </summary>
        public const int DefaultTtl = 128;

        /// <summary>
        /// Max TTL (time to live)
        /// </summary>
        ////public const int MaxTtl = 256;

        public const int MaxTtl = 30;
    } // IcmpConstants
} // Tethys.Net
