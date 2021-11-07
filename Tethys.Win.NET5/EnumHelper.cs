// ---------------------------------------------------------------------------
// <copyright file="EnumHelper.cs" company="Tethys">
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
namespace Tethys
{
  using System;
  using System.ComponentModel;
  using System.Reflection;

  /// <summary>
  /// Helper methods for enumerations.
  /// </summary>
  public static class EnumHelper
  {
    /// <summary>
    /// Convert any possible string-value of a given enumeration
    /// to its internal representation.
    /// </summary>
    /// <param name="type">enumeration (type).</param>
    /// <param name="value">string value to be translated.</param>
    /// <returns>enumeration value.</returns>
    public static object StringToEnum(Type type, string value)
    {
      foreach (FieldInfo fi in type.GetFields())
      {
        if (fi.Name == value)
        {
          // use <null> because enumeration values are static
          return fi.GetValue(null);
        } // if
      } // foreach

      throw new ArgumentException($"Can't convert {value} to {type}");
    } // StringToEnum()

    /// <summary>
    /// Gets the enumeration description.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A string.</returns>
    public static string GetEnumDescription(Enum value)
    {
      var fi = value.GetType().GetField(value.ToString());
      if (fi == null)
      {
          return string.Empty;
      } // if

      var attributes =
        (DescriptionAttribute[])fi.GetCustomAttributes(
        typeof(DescriptionAttribute), false);
      return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
    } // GetEnumDescription()

    /// <summary>
    /// Gets the name of the enumeration.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="description">The description.</param>
    /// <returns>An enumeration name.</returns>
    public static string GetEnumName(Type value, string description)
    {
      var fis = value.GetFields();
      foreach (var fi in fis)
      {
        var attributes =
          (DescriptionAttribute[])fi.GetCustomAttributes(
          typeof(DescriptionAttribute), false);
        if (attributes.Length > 0)
        {
          if (attributes[0].Description == description)
          {
            return fi.Name;
          } // if
        } // if
      } // foreach

      return description;
    } // GetEnumName()
  } // EnumHelper
} // Tethys
