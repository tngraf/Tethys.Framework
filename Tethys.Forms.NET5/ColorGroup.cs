// ---------------------------------------------------------------------------
// <copyright file="ColorGroup.cs" company="Tethys">
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
    using System.Drawing;

    /// <summary>
    /// ColorGroup is a helper class to get VSNet IDE colors.
    /// </summary>
    public class ColorGroup
    {
        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets the background color.
        /// </summary>
        public Color BackgroundColor { get; }

        /// <summary>
        /// Gets the stripe color.
        /// </summary>
        public Color StripeColor { get; }

        /// <summary>
        /// Gets the selection color.
        /// </summary>
        public Color SelectionColor { get; }

        /// <summary>
        /// Gets the border color.
        /// </summary>
        public Color BorderColor { get; }

        /// <summary>
        /// Gets the dark selection color.
        /// </summary>
        public Color DarkSelectionColor { get; }

        /// <summary>
        /// Gets the 'pressed item' color.
        /// </summary>
        public Color PressedColor { get; }

        /// <summary>
        /// Gets the selection Border color.
        /// </summary>
        public Color SelectionBorderColor { get; }

        /// <summary>
        /// Gets the toggle color.
        /// </summary>
        public Color ToggleColor { get; }
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorGroup" /> class.
        /// </summary>
        /// <param name="backgroundColor">Color of the background.</param>
        /// <param name="stripeColor">Color of the stripe.</param>
        /// <param name="selectionColor">Color of the selection.</param>
        /// <param name="borderColor">Color of the border.</param>
        /// <param name="darkSelectionColor">Color of the dark selection.</param>
        /// <param name="pressedColor">Color of the pressed.</param>
        /// <param name="selectionBorderColor">Color of the selection border.
        /// </param>
        /// <param name="toggleColor">Color of the toggle.</param>
        public ColorGroup(
            Color backgroundColor,
            Color stripeColor,
            Color selectionColor,
            Color borderColor,
            Color darkSelectionColor,
            Color pressedColor,
            Color selectionBorderColor,
            Color toggleColor)
        {
            this.BackgroundColor = backgroundColor;
            this.StripeColor = stripeColor;
            this.SelectionColor = selectionColor;
            this.BorderColor = borderColor;
            this.DarkSelectionColor = darkSelectionColor;
            this.PressedColor = pressedColor;
            this.SelectionBorderColor = selectionBorderColor;
            this.ToggleColor = toggleColor;
        } // ColorGroup()

        /// <summary>
        /// Returns VSNet IDE colors.
        /// </summary>
        /// <returns>The color group.</returns>
        public static ColorGroup GetVsColorGroup()
        {
            var backgroundColor = ColorUtil.VsNetBackgroundColor;
            var selectionColor = ColorUtil.VsNetSelectionColor;
            var stripeColor = ColorUtil.VsNetStripeColor;
            var pressedColor = ColorUtil.VsNetPressedColor;
            var selectionBorderColor = SystemColors.Highlight;
            var colorGroup = new ColorGroup(
                backgroundColor,
                stripeColor,
                selectionColor,
                Color.FromArgb(255, SystemColors.Highlight),
                ColorUtil.VsNetPressedColor,
                pressedColor,
                selectionBorderColor,
                selectionBorderColor);

            return colorGroup;
        } // GetVsColorGroup()
    } // ColorGroup()
} // Tethys.Forms

// ============================
// Tethys: end of ColorGroup.cs
// ============================