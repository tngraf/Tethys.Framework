// ---------------------------------------------------------------------------
// <copyright file="TcpIp.cs" company="Tethys">
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
    /// The class TcpIp implements support functions for
    /// TCP/IP network access.
    /// </summary>
    public static class TcpIp
    {
        #region CONSTANTS
        /// <summary>
        /// Default header size.
        /// </summary>
        public const int HeaderSize = 8;

        /// <summary>
        /// Default data size.
        /// </summary>
        public const int DataPacketSize = 32;

        /// <summary>
        /// Default packet size.
        /// </summary>
        public const int PacketSize = HeaderSize + DataPacketSize;
        #endregion // CONSTANTS

        /// <summary>
        /// Create byte array from IcmpEchoRequest structure.
        /// </summary>
        /// <param name="req">The request.</param>
        /// <returns>The packet.</returns>
        public static byte[] CreatePacket(IcmpEchoRequest req)
        {
            var byteSend = new byte[PacketSize];

            // create byte array from REQUEST structure
            byteSend[0] = req.Header.HeaderType;
            byteSend[1] = req.Header.Code;
            Array.Copy(BitConverter.GetBytes(req.Header.Checksum), 0, byteSend, 2, 2);
            Array.Copy(BitConverter.GetBytes(req.Header.Id), 0, byteSend, 4, 2);
            Array.Copy(BitConverter.GetBytes(req.Header.Seq), 0, byteSend, 6, 2);
            for (int i = 0; i < req.Data.Length; i++)
            {
                byteSend[i + HeaderSize] = req.Data[i];
            } // for

            // calculate checksum
            int checkSum = 0;
            for (int i = 0; i < byteSend.Length; i += 2)
            {
                checkSum += Convert.ToInt32(BitConverter.ToUInt16(byteSend, i));
            } // for

            checkSum = (checkSum >> 16) + (checkSum & 0xffff);
            checkSum += (checkSum >> 16);

            // update byte array to reflect checksum
            Array.Copy(BitConverter.GetBytes((ushort)~checkSum), 0, byteSend, 2, 2);
            return byteSend;
        } // CreatePacket()

#if false
    /// <summary>
    /// Traces the path of an ICMP packet to the given address.
    /// </summary>
    /// <param name="address">The address.</param>
    /// <param name="timeOut">The time out.</param>
    /// <param name="txtOutput">The TXT output.</param>
    /// <remarks>
    ///   <b>ICMP Protocol</b><br />
    /// The Internet Protocol (IP) is used for host-to-host datagram service
    /// The Internet Protocol (IP) is used for host-to-host datagram service
    /// in a system of interconnected networks. Occasionally, a destination
    /// host will communicate with a source host; for example, it is used to
    /// report an error in datagram processing. For such purposes, the
    /// Internet Control Message Protocol (ICMP) is used. ICMP uses the basic
    /// support of IP as if it were a higher-level protocol; however, ICMP is
    /// actually an integral part of IP, and must be implemented by every IP
    /// module.<br />
    /// ICMP messages are sent in several situations; for example,
    /// <ul>
    /// <li>When a datagram cannot reach its destination.</li>
    /// <li>When the gateway does not have the buffering capacity to forward a datagram.</li>
    /// <li>When the gateway can direct the host to send traffic on a shorter route.</li>
    /// </ul>
    /// The Internet Protocol is not designed to be absolutely reliable. The
    /// purpose of these control messages is to provide feedback about
    /// problems in the communication environment, not to make IP reliable.
    /// There are still no guarantees that a datagram will be delivered or a
    /// control message will be returned. Some datagrams may still be
    /// undelivered without any report of their loss. The higher-level
    /// protocols that use IP must implement their own reliability procedures
    /// if reliable communication is required.
    /// <br />
    /// The ICMP messages typically report errors in the processing of
    /// datagrams. To avoid the infinite regress of messages about messages
    /// and so forth, no ICMP messages are sent about ICMP messages. Also,
    /// ICMP messages are only sent about errors in handling fragment zero
    /// of fragmented datagrams. (Fragment zero has the fragment offset
    /// equal zero.)
    /// <br />
    /// <b>Basics of the Trace Utility</b><br />
    /// Apart from other fields, each ICMP header consists of a field called
    /// Time to Live (TTL). The TTL field is decremented at each machine in
    /// which the datagram is processed. Thus, if my packet routes through
    /// Machine A-&gt; Machine B-&gt; Machine C, and if I set the initial TTL to 3,
    /// TTL at B it would be 2 and at C it would be 1. If the gateway
    /// processing a datagram finds the TTL field is zero, it discards the
    /// datagram. The gateway also notifies the source host via the time
    /// exceeded message.
    /// <br />
    /// Thus, to get our utility working, we send a packet containing an echo
    /// request to the destination machine with an increasing TTL number,
    /// starting from 1. Each time the TTL goes to zero, the machine that
    /// was currently processing the datagram returns the packet with a
    /// time-exceeded message. We remember the IP of this machine and send
    /// the packet back with an incremented TTL. We repeat this until we
    /// successfully receive an echo reply.
    /// </remarks>
    public static void Trace(IPAddress address, int timeOut, TextBox txtOutput)
    {
      try
      {
        // Create Raw ICMP Socket 
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Raw,
          ProtocolType.Icmp);
        
        // destination
        IPEndPoint ipdest = new IPEndPoint(address, 80);
        
        // source
        IPEndPoint ipsrc = new IPEndPoint(Dns.GetHostEntry(Dns.GetHostName()).AddressList[0], 80);
        EndPoint epsrc = ipsrc;

        // create header
        IcmpHeader ip = new IcmpHeader();
        ip.Type = IcmpConstants.EchoReq;
        ip.Code = 0;
        ip.Checksum = 0;
        
        // any number you feel is kinda unique :)
        ip.Id = (ushort)DateTime.Now.Millisecond;
        ip.Seq = 0;

        // create whole request
        IcmpEchoRequest req = new IcmpEchoRequest();
        req.Header = ip;
        req.Data = new byte[DataPacketSize];

        // initialize data ('ABCDEFGHIJKLMNOPQRST')
        for (int i = 0; i < req.Data.Length; i++)
        {
          req.Data[i] = (byte)i;
        } // for

        // this function gets a byte array from the IcmpEchoRequest structure
        byte[] byteSend = CreatePacket(req);

        // send requests with increasing number of TTL
        for (int ittl = 1; ittl <= IcmpConstants.MaxTtl; ittl++)
        {
          byte[] byteRecv = new byte[256];
          
          // Socket options to set TTL and Timeouts 
          s.SetSocketOption(SocketOptionLevel.IP,
            SocketOptionName.IpTimeToLive, ittl);
          s.SetSocketOption(SocketOptionLevel.Socket,
            SocketOptionName.SendTimeout, timeOut);
          s.SetSocketOption(SocketOptionLevel.Socket,
            SocketOptionName.ReceiveTimeout, timeOut);

          // Get current time
          DateTime dt = DateTime.Now;
          
          // Send Request
          int ret = s.SendTo(byteSend, byteSend.Length, SocketFlags.None, ipdest);
          
          // check for Win32 SOCKET_ERROR
          if (ret == -1)
          {
            txtOutput.AppendText("Ping: error sending data\r\n");
            return;
          } // if

          // Receive
          ret = s.ReceiveFrom(byteRecv, byteRecv.Length, SocketFlags.None, ref epsrc);

          // Calculate time required
          TimeSpan ts = DateTime.Now - dt;

          // check if response is OK
          if (ret == -1)
          {
            txtOutput.AppendText("Ping: error getting data\r\n");
            return;
          } // if

          try
          {
            IPHostEntry iphe = Dns.GetHostEntry(((IPEndPoint)epsrc).Address);
            
            ////string strDotted = iphe.AddressList[0].ToString();
            if (ts.Milliseconds < 1)
            {
              txtOutput.AppendText(string.Format("  {0,-5} Time<1ms    {1} [{2}] \r\n",
                ittl, iphe.HostName, iphe.AddressList[0]));
            }
            else
            {
              txtOutput.AppendText(string.Format("  {0,-5} Time={1,3}ms    {2} [{3}] \r\n",
                ittl, ts.Milliseconds, iphe.HostName, iphe.AddressList[0]));
            } // if
          }
          catch
          {
            if (ts.Milliseconds < 1)
            {
              txtOutput.AppendText(string.Format("  {0,-5} Time<1ms    {1,-20} \r\n",
                ittl, ((IPEndPoint)epsrc).Address));
            }
            else
            {
              txtOutput.AppendText(string.Format("  {0,-5} Time={1,3}ms    {2,-20} \r\n",
                ittl, ts.Milliseconds, ((IPEndPoint)epsrc).Address));
            } // if
          } // catch

          // reply size should be sizeof IcmpEchoRequest + 20
          // (i.e sizeof IP header), it should be an echo reply
          // and id should be same
          if ((ret == DataPacketSize + 8 + 20)
            && (BitConverter.ToInt16(byteRecv, 24) == BitConverter.ToInt16(byteSend, 4))
            && (byteRecv[20] == IcmpConstants.EchoReply))
          {
            break;
          } // if

          if (byteRecv[20] == IcmpConstants.DestUnreachable)
          {
            txtOutput.AppendText("Destination unreachable, quitting...\r\n");
          }
          else if (byteRecv[20] != IcmpConstants.TimeExceeded)
          {
            // time out
            txtOutput.AppendText("unexpected reply, quitting...\r\n");
            break;
          } // if
        } // for
        txtOutput.AppendText("\r\nTrace complete.\r\n");
      }
      catch (SocketException e)
      {
        txtOutput.AppendText("Ping: Exception: ");
        txtOutput.AppendText(e.Message + "\r\n");
      }
      catch (Exception e)
      {
        txtOutput.AppendText("Ping: Exception: ");
        txtOutput.AppendText(e.Message + "\r\n");
      } // catch
    } // Trace()

    /// <summary>
    /// Sends ICMP Ping packets with the given timeout to the
    /// given address.
    /// </summary>
    /// <param name="address">The address.</param>
    /// <param name="timeOut">The time out.</param>
    /// <param name="txtOutput">The TXT output.</param>
    /// <returns>The ping timespan.</returns>
    public static TimeSpan Ping(IPAddress address, int timeOut, TextBox txtOutput)
    {
      TimeSpan ts;

      try
      {
        // Create Raw ICMP Socket 
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Raw,
          ProtocolType.Icmp);
        
        // destination
        IPEndPoint ipdest = new IPEndPoint(address, 80);
        
        // source
        IPEndPoint ipsrc = new IPEndPoint(Dns.GetHostEntry(Dns.GetHostName()).AddressList[0], 80);
        EndPoint epsrc = ipsrc;

        // create header
        IcmpHeader ip = new IcmpHeader();
        ip.Type = IcmpConstants.EchoReq;
        ip.Code = 0;
        ip.Checksum = 0;
        
        // any number you feel is kinda unique :)
        ip.Id = (ushort)DateTime.Now.Millisecond;
        ip.Seq = 0;

        // create whole request
        IcmpEchoRequest req = new IcmpEchoRequest();
        req.Header = ip;
        req.Data = new byte[DataPacketSize];

        // initialize data ('ABCDEFGHIJKLMNOPQRST')
        for (int i = 0; i < req.Data.Length; i++)
        {
          req.Data[i] = (byte)i;
        } // for

        // this function gets a byte array from the IcmpEchoRequest structure
        byte[] byteSend = CreatePacket(req);

        // send requests
        byte[] byteRecv = new byte[256];
        
        // Socket options to set TTL and Timeouts 
        s.SetSocketOption(SocketOptionLevel.IP,
          SocketOptionName.IpTimeToLive, IcmpConstants.DefaultTtl);
        s.SetSocketOption(SocketOptionLevel.Socket,
          SocketOptionName.SendTimeout, timeOut);
        s.SetSocketOption(SocketOptionLevel.Socket,
          SocketOptionName.ReceiveTimeout, timeOut);

        // Get current time
        DateTime dt = DateTime.Now;
        
        // Send Request
        int ret = s.SendTo(byteSend, byteSend.Length, SocketFlags.None, ipdest);
        
        // check for Win32 SOCKET_ERROR
        if (ret == -1)
        {
          txtOutput.AppendText("Ping: error sending data\r\n");
          return TimeSpan.MinValue;
        } // if

        // Receive
        ret = s.ReceiveFrom(byteRecv, byteRecv.Length, SocketFlags.None, ref epsrc);

        // Calculate time required
        ts = DateTime.Now - dt;

        // check if response is OK
        if (ret == -1)
        {
          txtOutput.AppendText("Ping: error getting data\r\n");
          return TimeSpan.MinValue;
        } // if

        if (ts.Milliseconds < 1)
        {
          txtOutput.AppendText(string.Format("Reply from {0}: bytes={1} time<1ms TTL={2,-5}\r\n",
            ((IPEndPoint)epsrc).Address, DataPacketSize, IcmpConstants.DefaultTtl));
        }
        else
        {
          txtOutput.AppendText(string.Format("Reply from {0}: bytes={1} time={2,3}ms TTL={3,-5}\r\n",
            ((IPEndPoint)epsrc).Address, DataPacketSize,
            ts.Milliseconds, IcmpConstants.DefaultTtl));
        } // if

        // reply size should be sizeof IcmpEchoRequest + 20
        // (i.e sizeof IP header), it should be an echo reply
        // and id should be same
        if ((ret == DataPacketSize + 8 + 20)
          && (BitConverter.ToInt16(byteRecv, 24) == BitConverter.ToInt16(byteSend, 4))
          && (byteRecv[20] == IcmpConstants.EchoReply))
        {
        } // if
      }
      catch (SocketException e)
      {
        if (e.ErrorCode == 10065)
        {
          txtOutput.AppendText("Destination host unreachable.\r\n");
        }
        else if (e.ErrorCode == 10060)
        {
          txtOutput.AppendText("Request timed out.\r\n");
        }
        else
        {
          txtOutput.AppendText("\r\nPing: SocketException: ");
          txtOutput.AppendText(e.Message + "\r\n");
        } // if

        ts = TimeSpan.MinValue;
      }
      catch (Exception e)
      {
        txtOutput.AppendText("Request timed out.\r\n\r\n");
        txtOutput.AppendText("Ping: Exception: ");
        txtOutput.AppendText(e.Message + "\r\n");
        ts = TimeSpan.MinValue;
      } // catch

      return ts;
    } // Ping()
#endif
    } // TcpIp
} // Tethys.Net

// ======================
// Tethys: end of tcpip.cs
// ======================