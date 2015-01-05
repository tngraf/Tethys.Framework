#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="ColorGroup.cs" company="Tethys">
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

namespace Tethys.Forms
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;

    /// <summary>
    /// ColorGroup is a helper class to get VSNet IDE colors.
    /// </summary>
    public class ColorGroup
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Internal Property: Background color.
        /// </summary>
        private readonly Color backgroundColor;

        /// <summary>
        /// Internal Property: Stripe color.
        /// </summary>
        private readonly Color stripeColor;

        /// <summary>
        /// Internal Property: Selection color.
        /// </summary>
        private readonly Color selectionColor;

        /// <summary>
        /// Internal Property: Border color.
        /// </summary>
        private readonly Color borderColor;

        /// <summary>
        /// Internal Property: Dark selection color.
        /// </summary>
        private readonly Color darkSelectionColor;

        /// <summary>
        /// Internal Property: 'pressed item' color.
        /// </summary>
        private readonly Color pressedColor;

        /// <summary>
        /// Internal Property: Selection Border color.
        /// </summary>
        private readonly Color selectionBorderColor;

        /// <summary>
        /// Internal Property: toggle color.
        /// </summary>
        private readonly Color toggleColor;
        #endregion // PROTECTED PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets the background color.
        /// </summary>
        public Color BackgroundColor
        {
            get
            {
                return this.backgroundColor;
            }
        } // BackgroundColor

        /// <summary>
        /// Gets the stripe color.
        /// </summary>
        public Color StripeColor
        {
            get
            {
                return this.stripeColor;
            }
        } // StripeColor

        /// <summary>
        /// Gets the selection color.
        /// </summary>
        public Color SelectionColor
        {
            get
            {
                return this.selectionColor;
            }
        } // SelectionColor

        /// <summary>
        /// Gets the border color.
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
        } // BorderColor

        /// <summary>
        /// Gets the dark selection color.
        /// </summary>
        public Color DarkSelectionColor
        {
            get
            {
                return this.darkSelectionColor;
            }
        } // DarkSelectionColor

        /// <summary>
        /// Gets the 'pressed item' color.
        /// </summary>
        public Color PressedColor
        {
            get
            {
                return this.pressedColor;
            }
        } // PressedColor

        /// <summary>
        /// Gets the selection Border color.
        /// </summary>
        public Color SelectionBorderColor
        {
            get
            {
                return this.selectionBorderColor;
            }
        } // SelectionBorderColor

        /// <summary>
        /// Gets the toggle color.
        /// </summary>
        public Color ToggleColor
        {
            get
            {
                return this.toggleColor;
            }
        } // ToggleColor
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
        public ColorGroup(Color backgroundColor, Color stripeColor,
          Color selectionColor, Color borderColor, Color darkSelectionColor,
          Color pressedColor, Color selectionBorderColor, Color toggleColor)
        {
            this.backgroundColor = backgroundColor;
            this.stripeColor = stripeColor;
            this.selectionColor = selectionColor;
            this.borderColor = borderColor;
            this.darkSelectionColor = darkSelectionColor;
            this.pressedColor = pressedColor;
            this.selectionBorderColor = selectionBorderColor;
            this.toggleColor = toggleColor;
        } // ColorGroup()

        /// <summary>
        /// Returns VSNet IDE colors.
        /// </summary>
        /// <returns>The color group.</returns>
        [SuppressMessage("Microsoft.Design",
          "CA1024:UsePropertiesWhereAppropriate",
          Justification = "Ok here")]
        [SuppressMessage("Microsoft.Naming",
          "CA1709:IdentifiersShouldBeCasedCorrectly",
          MessageId = "Vs", Justification = "Ok here")]
        public static ColorGroup GetVsColorGroup()
        {
            var backgroundColor = ColorUtil.VsNetBackgroundColor;
            var selectionColor = ColorUtil.VsNetSelectionColor;
            var stripeColor = ColorUtil.VsNetStripeColor;
            var pressedColor = ColorUtil.VsNetPressedColor;
            var selectionBorderColor = SystemColors.Highlight;
            var colorGroup = new ColorGroup(backgroundColor, stripeColor,
              selectionColor, Color.FromArgb(255, SystemColors.Highlight), 
              ColorUtil.VsNetPressedColor,
              pressedColor, selectionBorderColor, selectionBorderColor);

            return colorGroup;
        } // GetVsColorGroup()
    } // ColorGroup()
} // Tethys.Forms

// ============================
// Tethys: end of ColorGroup.cs
// ============================