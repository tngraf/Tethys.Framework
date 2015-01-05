#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="VersionInfoTest.cs" company="Tethys">
// Copyright  1998-2015 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing, 
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied. 
// </copyright>
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Test
{
  using System.Globalization;
  using System.Threading;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  using Tethys.Reflection;

  /// <summary>
  /// Unit tests for <see cref="VersionInfo"/> class.
  /// </summary>
  [TestClass]
  public class VersionInfoTest
  {
    /// <summary>
    /// Test for GetMonth.
    /// </summary>
    [TestMethod]
    public void GetMonthTest()
    {
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
      var value = VersionInfo.GetMonth(10);
      Assert.AreEqual("Oct", value);

      Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
      value = VersionInfo.GetMonth(10);
      Assert.AreEqual("Okt", value);

      Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
      value = VersionInfo.GetMonth(2);
      Assert.AreEqual("févr.", value);

      Thread.CurrentThread.CurrentUICulture = new CultureInfo("it-IT");
      value = VersionInfo.GetMonth(5);
      Assert.AreEqual("mag", value);
    }
  } // VersionInfoTest
} // Tethys.Test
