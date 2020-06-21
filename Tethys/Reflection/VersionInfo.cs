// --------------------------------------------------------------------------
// Tethys.Framework
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="VersionInfo.cs" company="Tethys">
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

namespace Tethys.Reflection
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;
    using System.Threading;

    /// <summary>
    /// The VersionInfo class contains static methods to generate
    /// software release version strings.
    /// </summary>
    public static class VersionInfo
  {
    /// <summary>
    /// Returns a month string for the given month and language.
    /// </summary>
    /// <param name="month">The month.</param>
    /// <returns>The month in the current UI language.</returns>
    public static string GetMonth(int month)
    {
      if (month < 1)
      {
        throw new ArgumentOutOfRangeException(nameof(month));
      } // if

      if (month > 12)
      {
        throw new ArgumentOutOfRangeException(nameof(month));
      } // if

      var date = new DateTime(2000, month, 1);
      var monthtext = date.ToString("MMM", CultureInfo.CurrentUICulture);

      return monthtext;
    } // GetMonth()

    /// <summary>
    /// This function returns the date of the build of the application.<br />
    /// Format = DD.MMM.YY (de) or DD-MMM-YY (us)<br />
    /// Sample: "24.Jan.00".
    /// </summary>
    /// <param name="assemblyTarget">The assembly target.</param>
    /// <param name="culture">The culture.</param>
    /// <returns>The build date.</returns>
    public static string GetDateBuild(
        Assembly assemblyTarget, CultureInfo culture)
    {
      if (assemblyTarget == null)
      {
        throw new ArgumentNullException(nameof(assemblyTarget));
      } // if

      if (culture == null)
      {
        throw new ArgumentNullException(nameof(culture));
      } // if

      var dayAttribute =
        (AssemblyDayAttribute)Attribute.GetCustomAttribute(
            assemblyTarget,
            typeof(AssemblyDayAttribute));
      Debug.Assert(dayAttribute != null, "day must not be null!");

      var monthAttribute =
        (AssemblyMonthAttribute)Attribute.GetCustomAttribute(
            assemblyTarget,
            typeof(AssemblyMonthAttribute));
      Debug.Assert(monthAttribute != null, "month must not be null!");

      var yearAttribute =
        (AssemblyYearAttribute)Attribute.GetCustomAttribute(
            assemblyTarget,
            typeof(AssemblyYearAttribute));
      Debug.Assert(yearAttribute != null, "year must not be null!");

      var year = yearAttribute.Year;
      if (year > 1000)
      {
        year = year % 100;
      } // if

      var strDate = string.Format(
          culture,
          "{0:00}.{1}.{2:00}",
          dayAttribute.Day,
          GetMonth(monthAttribute.Month),
          year);
      return strDate;
    } // GetDateBuild

    /// <summary>
    /// This function returns the date of the built of the application.<br />
    /// The format is the one that is valid for the current culture.<br />
    /// Sample: "24.Jan.00".
    /// </summary>
    /// <param name="assemblyTarget">The assembly target.</param>
    /// <returns>
    /// The build date.
    /// </returns>
    public static string GetDateBuild(Assembly assemblyTarget)
    {
      if (assemblyTarget == null)
      {
        throw new ArgumentNullException(nameof(assemblyTarget));
      } // if

      var dayAttribute =
        (AssemblyDayAttribute)Attribute.GetCustomAttribute(
            assemblyTarget, typeof(AssemblyDayAttribute));
      Debug.Assert(dayAttribute != null, "day must not be null!");

      var monthAttribute =
        (AssemblyMonthAttribute)Attribute.GetCustomAttribute(
            assemblyTarget, typeof(AssemblyMonthAttribute));
      Debug.Assert(monthAttribute != null, "month must not be null!");

      var yearAttribute =
        (AssemblyYearAttribute)Attribute.GetCustomAttribute(
            assemblyTarget, typeof(AssemblyYearAttribute));
      Debug.Assert(yearAttribute != null, "year must not be null!");

      var dt = new DateTime(
          yearAttribute.Year,
          monthAttribute.Month,
          dayAttribute.Day);
      return string.Format(Thread.CurrentThread.CurrentUICulture, "{0:d}", dt);
    } // GetDateBuild

    /// <summary>
    /// Returns the level text for the specified assembly.<br />
    /// Sample: "1.0.4Beta (Level 1)".
    /// </summary>
    /// <param name="assemblyTarget">The assembly target.</param>
    /// <param name="version">The version.</param>
    /// <returns>The level.</returns>
    public static string GetLevel(Assembly assemblyTarget, Version version)
    {
      if (assemblyTarget == null)
      {
        throw new ArgumentNullException(nameof(assemblyTarget));
      } // if

      if (version == null)
      {
        throw new ArgumentNullException(nameof(version));
      } // if

      var releaseMode =
        (AssemblyReleaseModeAttribute)Attribute.GetCustomAttribute(
            assemblyTarget,
            typeof(AssemblyReleaseModeAttribute));
      Debug.Assert(releaseMode != null, "release mode must not be null!");

      var strLevel = string.Format(
          CultureInfo.CurrentUICulture,
          "{0:00}.{1:00}.{2:00}.{3:00}",
          version.Major,
          version.Minor,
          version.Build,
          version.Revision);
      if (releaseMode.ReleaseMode != ReleaseMode.Final)
      {
        strLevel += " (test)";
      } // if

      return strLevel;
    } // GetLevel()

    /// <summary>
    /// Returns the version text for the specified assembly and language.<br />
    /// Sample:.
    /// <example><c>"Version 1.0.4Beta (Level 1) vom 24.Jan.00"</c></example>
    /// </summary>
    /// <param name="assemblyTarget">The assembly target.</param>
    /// <param name="version">The version.</param>
    /// <param name="uiCulture">The UI culture.</param>
    /// <returns>
    /// The version string.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">
    /// assemblyTarget
    /// or
    /// culture.
    /// </exception>
    public static string GetVersion(
        Assembly assemblyTarget,
        Version version,
        CultureInfo uiCulture)
    {
      if (assemblyTarget == null)
      {
        throw new ArgumentNullException(nameof(assemblyTarget));
      } // if

      if (uiCulture == null)
      {
        throw new ArgumentNullException(nameof(uiCulture));
      } // if

      string strVersion;

      if (uiCulture.TwoLetterISOLanguageName == "de")
      {
        strVersion = string.Format(
            uiCulture,
            "{0} vom {1}",
            GetLevel(assemblyTarget, version),
            GetDateBuild(assemblyTarget, uiCulture));
      }
      else
      {
        strVersion = string.Format(
            uiCulture,
            "{0} of {1}",
            GetLevel(assemblyTarget, version),
            GetDateBuild(assemblyTarget, uiCulture));
      } // if

      return strVersion;
    } // GetVersion()
  } // VersionInfo
} // Tethys.Reflection
