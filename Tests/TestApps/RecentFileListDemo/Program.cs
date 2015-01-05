#region Header
// ---------------------------------------------------------------------------
// Tethys.Forms - RecentFileListDemo
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
// <copyright file="Program.cs" company="Thomas Graf">
// Copyright  1998 - 2013 by Thomas Graf
//            Email: tngraf@gmx.de
//            See the file "License.rtf" for information on usage and 
//            redistribution of this file and for a DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 4.00.00.00 of 13Apr14
// Project .. Tethys.Forms
// Creater .. Thomas Graf (tg)
// System ... Microsoft .Net Framework 4.5
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 03Nov22 3.00.02.00 tg: initial version
//
// ---------------------------------------------------------------------------
#endregion

namespace RecentFileListDemo
{
  using System;
  using System.Windows.Forms;

  /// <summary>
  /// Main class.
  /// </summary>
  public static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    } // Main()
  } // Program
} // RecentFileListDemo
