// ---------------------------------------------------------------------------
// <copyright file="ColorUtil.cs" company="Tethys">
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
namespace Tethys.Forms
{
    using System;
    using System.Collections.ObjectModel;
    using System.Drawing;

    /// <summary>
    /// The class <see cref="ColorUtil"/> implements support functions for
    /// color conversion and color detection.
    /// </summary>
    public static class ColorUtil
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// The system color names.
        /// </summary>
        private static ReadOnlyCollection<string> systemColorNames;

        /// <summary>
        /// The known color names.
        /// </summary>
        private static ReadOnlyCollection<string> knownColorNames;
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region COLOR NAMES
        /// <summary>
        /// Gets the known color names.
        /// </summary>
        public static ReadOnlyCollection<string> KnownColorNames
        {
            get
            {
                if (knownColorNames == null)
                {
                    knownColorNames = new ReadOnlyCollection<string>(new[]
          {
            "Transparent", "Black", "DimGray", "Gray", "DarkGray", "Silver",
            "LightGray", "Gainsboro", "WhiteSmoke", "White", "RosyBrown", "IndianRed",
            "Brown", "Firebrick", "LightCoral", "Maroon", "DarkRed", "Red", "Snow",
            "MistyRose", "Salmon", "Tomato", "DarkSalmon", "Coral", "OrangeRed",
            "LightSalmon", "Sienna", "SeaShell", "Chocalate", "SaddleBrown",
            "SandyBrown", "PeachPuff", "Peru", "Linen", "Bisque", "DarkOrange",
            "BurlyWood", "Tan", "AntiqueWhite", "NavajoWhite", "BlanchedAlmond",
            "PapayaWhip", "Mocassin", "Orange", "Wheat", "OldLace", "FloralWhite",
            "DarkGoldenrod", "Cornsilk", "Gold", "Khaki", "LemonChiffon",
            "PaleGoldenrod", "DarkKhaki", "Beige", "LightGoldenrod", "Olive",
            "Yellow", "LightYellow", "Ivory", "OliveDrab", "YellowGreen",
            "DarkOliveGreen", "GreenYellow", "Chartreuse", "LawnGreen",
            "DarkSeaGreen", "ForestGreen", "LimeGreen", "PaleGreen", "DarkGreen",
            "Green", "Lime", "Honeydew", "SeaGreen", "MediumSeaGreen", "SpringGreen",
            "MintCream", "MediumSpringGreen", "MediumAquaMarine", "YellowAquaMarine",
            "Turquoise", "LightSeaGreen", "MediumTurquoise", "DarkSlateGray",
            "PaleTurquoise", "Teal", "DarkCyan", "Aqua", "Cyan", "LightCyan", "Azure",
            "DarkTurquoise", "CadetBlue", "PowderBlue", "LightBlue", "DeepSkyBlue",
            "SkyBlue", "LightSkyBlue", "SteelBlue", "AliceBlue", "DodgerBlue",
            "SlateGray", "LightSlateGray", "LightSteelBlue", "CornflowerBlue",
            "RoyalBlue", "MidnightBlue", "Lavender", "Navy", "DarkBlue", "MediumBlue",
            "Blue", "GhostWhite", "SlateBlue", "DarkSlateBlue", "MediumSlateBlue",
            "MediumPurple", "BlueViolet", "Indigo", "DarkOrchid", "DarkViolet",
            "MediumOrchid", "Thistle", "Plum", "Violet", "Purple", "DarkMagenta",
            "Magenta", "Fuchsia", "Orchid", "MediumVioletRed", "DeepPink", "HotPink",
            "LavenderBlush", "PaleVioletRed", "Crimson", "Pink", "LightPink",
          });
                } // if

                return knownColorNames;
            }
        }

        /// <summary>
        /// Gets the system color names.
        /// </summary>
        public static ReadOnlyCollection<string> SystemColorNames
        {
            get
            {
                if (systemColorNames == null)
                {
                    systemColorNames = new ReadOnlyCollection<string>(new[]
          {
            "ActiveBorder", "ActiveCaption", "ActiveCaptionText", "AppWorkspace",
            "Control", "ControlDark", "ControlDarkDark", "ControlLight",
            "ControlLightLight", "ControlText", "Desktop", "GrayText", "HighLight",
            "HighLightText", "HotTrack", "InactiveBorder", "InactiveCaption",
            "InactiveCaptionText", "Info", "InfoText", "Menu", "MenuText",
            "ScrollBar", "Window", "WindowFrame", "WindowText",
          });
                } // if

                return systemColorNames;
            }
        }
        #endregion // COLOR NAMES

        //// ---------------------------------------------------------------------

        #region CONVERSION FUNCTIONS
        // ------------------------------------------
        // Conversion between RGB and Hue, Saturation
        // and Luminosity function helpers
        // ------------------------------------------

        /// <summary>
        /// Conversion HSL to RGB.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <param name="s">The s.</param>
        /// <param name="l">The l.</param>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        public static void HslToRgb(
            float h,
            float s,
            float l,
            ref float r,
            ref float g,
            ref float b)
        {
            // given h,s,l,[240 and r,g,b [0-255]
            // convert h [0-360], s,l,r,g,b [0-1]
            h = (h / 240) * 360;
            s /= 240;
            l /= 240;

            // Begin Foley
            float m2;

            // Calc m2
            if (l <= 0.5f)
            {
                // m2=(l*(l+s)); seems to be typo in Foley??, replace l for 1
                m2 = (l * (1 + s));
            }
            else
            {
                m2 = (l + s - (l * s));
            } // if

            // calc m1
            float m1 = (2.0f * l) - m2;

            // calc r,g,b in [0-1]
            if (Math.Abs(s - 0.0f) < 0.01)
            {
                // Achromatic: There is no hue
                // leave out the UNDEFINED part, h will always have value
                r = g = b = l;
            }
            else
            {
                // Chromatic: There is a hue
                r = GetRgbValue(m1, m2, h + 120.0f);
                g = GetRgbValue(m1, m2, h);
                b = GetRgbValue(m1, m2, h - 120.0f);
            } // if

            // End Foley
            // convert to 0-255 ranges
            r *= 255;
            g *= 255;
            b *= 255;
        } // HslToRgb()

        /// <summary>
        /// Helper function for the HSLToRGB function above
        /// </summary>
        /// <param name="n1">The n1.</param>
        /// <param name="n2">The n2.</param>
        /// <param name="hue">The hue.</param>
        /// <returns>An RGB value.</returns>
        private static float GetRgbValue(float n1, float n2, float hue)
        {
            if (hue > 360.0f)
            {
                hue -= 360.0f;
            }
            else if (hue < 0.0f)
            {
                hue += 360.0f;
            } // if

            if (hue < 60.0)
            {
                return n1 + (((n2 - n1) * hue) / 60.0f);
            }

            if (hue < 180.0f)
            {
                return n2;
            }

            if (hue < 240.0f)
            {
                return n1 + ((n2 - n1) * (240.0f - hue) / 60.0f);
            }

            return n1;
        } // GetRgbValue()

        /// <summary>
        /// Conversion RGB to HSL.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <param name="h">The h.</param>
        /// <param name="s">The s.</param>
        /// <param name="l">The l.</param>
        public static void RgbToHsl(
            int r,
            int g,
            int b,
            ref float h,
            ref float s,
            ref float l)
        {
            // Computer Graphics - Foley p.595
            var fr = (float)r / 255;
            var fg = (float)g / 255;
            var fb = (float)b / 255;
            var max = Math.Max(fr, Math.Max(fg, fb));
            var min = Math.Min(fr, Math.Min(fg, fb));

            // calc the lightness
            l = (max + min) / 2;

            if (Math.Abs(max - min) < 0.001)
            {
                // should be undefined but this works for what we need
                s = 0;
                h = 240.0f;
            }
            else
            {
                var delta = max - min;

                // calc the Saturation
                if (l < 0.5)
                {
                    s = delta / (max + min);
                }
                else
                {
                    s = delta / (2.0f - (max + min));
                } // if

                // calc the hue
                if (Math.Abs(fr - max) < 0.001)
                {
                    h = (fg - fb) / delta;
                }
                else if (Math.Abs(fg - max) < 0.001)
                {
                    h = 2.0f + ((fb - fr) / delta);
                }
                else if (Math.Abs(fb - max) < 0.001)
                {
                    h = 4.0f + ((fr - fg) / delta);
                } // if

                // convert hue to degrees
                h *= 60.0f;
                if (h < 0.0f)
                {
                    h += 360.0f;
                } // if
            } // if

            // end foley

            // convert to 0-255 ranges
            // h [0-360], h,l [0-1]
            l *= 240;
            s *= 240;
            h = (h / 360) * 240;
        } // RgbToHsl()
        #endregion // COMVERSION FUNCTIONS

        //// ---------------------------------------------------------------------

        #region VISUAL STUDIO .NET COLORS CALCULATION HELPERS
        /// <summary>
        /// Gets a Visual Studio .Net like menu item background color.
        /// Also used as toolbar background color.
        /// </summary>
        public static Color VsNetBackgroundColor
        {
            get
            {
                return CalculateColor(SystemColors.Window, SystemColors.Control, 220);
            }
        } // VSNetBackgroundColor

        /// <summary>
        /// Gets a Visual Studio .Net like menu item selection color.
        /// Also used as toolbar background color.
        /// </summary>
        public static Color VsNetSelectionColor
        {
            get
            {
                return CalculateColor(SystemColors.Highlight, SystemColors.Window, 180/*70*/);
            }
        } // VSNetSelectionColor

        /// <summary>
        /// Gets a Visual Studio .Net like menu item stripe color.
        /// </summary>
        public static Color VsNetStripeColor
        {
            get
            {
                return CalculateColor(SystemColors.Control, VsNetBackgroundColor, 195);
            }
        } // VSNetStripeColor

        /// <summary>
        /// Gets a Visual Studio .Net like pressed menu item color.
        /// </summary>
        public static Color VsNetPressedColor
        {
            get
            {
                return CalculateColor(SystemColors.Highlight, VsNetSelectionColor, 70);
            }
        } // VSNetPressedColor

        /// <summary>
        /// Gets a Visual Studio .Net like menu item toggle color.
        /// </summary>
        public static Color VsNetToggleColor
        {
            get
            {
                return CalculateColor(SystemColors.Highlight, SystemColors.Window, 30);
            }
        } // VSNetToggleColor

        /// <summary>
        /// Gets a Visual Studio .Net like selection border color.
        /// </summary>
        public static Color VsNetSelectionBorderColor
        {
            get
            {
                return SystemColors.Highlight;
            }
        } // VSNetSelectionBorderColor

        /// <summary>
        /// Returns the color the is an alpha blending of the given front color
        /// over the given background color with the given alpha blending level.
        /// </summary>
        /// <param name="front">The front.</param>
        /// <param name="back">The back.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns>Alpha blend color.</returns>
        public static Color CalculateColor(Color front, Color back, int alpha)
        {
            if ((alpha < 0) || (alpha > 255))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(alpha),
                    "range for alpha: 0 <= alpha <= 255");
            } // if

            // Use alpha blending to brigthen the colors but don't use it
            // directly. Instead derive an opaque color that we can use.
            // -- if we use a color with alpha blending directly we won't be
            // able to paint over whatever color was in the background and there
            // would be shadows of that color showing through
            var frontColor = Color.FromArgb(255, front);
            var backColor = Color.FromArgb(255, back);

            float frontRed = frontColor.R;
            float frontGreen = frontColor.G;
            float frontBlue = frontColor.B;
            float backRed = backColor.R;
            float backGreen = backColor.G;
            float backBlue = backColor.B;

            var red = (frontRed * alpha / 255) + (backRed * ((float)(255 - alpha) / 255));
            var newRed = (byte)red;
            var green = (frontGreen * alpha / 255) + (backGreen * ((float)(255 - alpha) / 255));
            var newGreen = (byte)green;
            var blue = (frontBlue * alpha / 255) + (backBlue * ((float)(255 - alpha) / 255));
            var newBlue = (byte)blue;

            return Color.FromArgb(255, newRed, newGreen, newBlue);
        } // CalculateColor()
        #endregion // VISUAL STUDIO .NET COLORS CALCULATION HELPERS

        //// ---------------------------------------------------------------------

        #region GENERAL FUNCTIONS
        /// <summary>
        /// Verifies whether the given color is a .Net 'known' color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="knownColor">Color of the known.</param>
        /// <param name="useTransparent">if set to <c>true</c> [use transparent].</param>
        /// <returns>
        ///   <c>true</c> if [is known color] [the specified color]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsKnownColor(Color color, ref Color knownColor, bool useTransparent)
        {
            // Using the Color structure "FromKnowColor" does not work if
            // we did not create the color as a known color to begin with
            // we need to compare the rgbs of both colors.
            var badColor = false;
            for (KnownColor enumValue = 0; enumValue <= KnownColor.YellowGreen;
                enumValue++)
            {
                var currentColor = Color.FromKnownColor(enumValue);
                var colorName = currentColor.Name;
                if (!useTransparent)
                {
                    badColor = (colorName == "Transparent");
                } // if

                if (color.A == currentColor.A && color.R == currentColor.R
                    && color.G == currentColor.G
                  && color.B == currentColor.B && !currentColor.IsSystemColor
                  && !badColor)
                {
                    knownColor = currentColor;
                    return true;
                } // if
            } // for

            // unknown color
            return false;
        } // IsKnownColor()

        /// <summary>
        /// Verifies whether the given color is a system color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="knownColor">Color of the known.</param>
        /// <returns>
        /// <c>true</c> if [is system color] [the specified color];
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSystemColor(Color color, ref Color knownColor)
        {
            // Using the Color structrure "FromKnowColor" does not work if
            // we did not create the color as a known color to begin with
            // we need to compare the rgbs of both colors.
            for (KnownColor enumValue = 0; enumValue <= KnownColor.YellowGreen;
                enumValue++)
            {
                var currentColor = Color.FromKnownColor(enumValue);
                if (color.R == currentColor.R && color.G == currentColor.G
                  && color.B == currentColor.B && currentColor.IsSystemColor)
                {
                    knownColor = currentColor;
                    return true;
                } // if
            } // for

            return false;
        } // IsSystemColor()

        /// <summary>
        /// Return a 24-bit color value of the given color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Color value.</returns>
        public static uint GetColorRef(Color color)
        {
            return Rgb(color.R, color.G, color.B);
        } // GetColorRef()
        #endregion // GENERAL FUNCTIONS

        //// ------------------------------------------------------------------

        #region WINDOWS RGB RELATED MACROS
        /// <summary>
        /// Returns the red components of the given 24-bit RGB color value.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>The red value.</returns>
        public static byte GetRValue(uint color)
        {
            return (byte)color;
        } // GetRValue()

        /// <summary>
        /// Returns the green components of the given 24-bit RGB color value.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>The green value.</returns>
        public static byte GetGValue(uint color)
        {
            return ((byte)(((short)(color)) >> 8));
        } // GetGValue()

        /// <summary>
        /// Returns the blue components of the given 24-bit RGB color value.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>The blue value.</returns>
        public static byte GetBValue(uint color)
        {
            return ((byte)((color) >> 16));
        } // GetBValue()

        /// <summary>
        /// Returns a 24 bit RGB value of the specified R, G, B colors.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <returns>A value.</returns>
        public static uint Rgb(int r, int g, int b)
        {
            return ((uint)(((byte)(r) | ((byte)(g) << 8)) | ((byte)(b) << 16)));
        } // Rgb()
        #endregion // WINDOWS RGB RELATED MACROS
    } // ColorUtil
} // Tethys.Forms

// ==========================
// Tethys: end of ColorUtil.cs
// ==========================