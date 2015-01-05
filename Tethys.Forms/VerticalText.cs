#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="VerticalText.cs" company="Tethys">
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
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// This class implements a user control that displays text vertically.
    /// </summary>
    [ComVisible(false)]
    [ToolboxBitmap(typeof(Label))]
    public sealed partial class VerticalText : UserControl
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Text to be drawn vertically.
        /// </summary>
        private string text;

        /// <summary>
        /// Brush for drawing text
        /// </summary>
        private SolidBrush brush;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the text to be drawn vertically
        /// </summary>
        [Category("Appearance"),
        Description("Text to be drawn vertically")]
        public string VText
        {
            get
            {
                return this.text;
            }

            set
            {
                this.text = value;
                Invalidate();
            }
        } // VText
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="VerticalText"/> class.
        /// </summary>
        public VerticalText()
        {
            this.brush = new SolidBrush(this.ForeColor);

            InitializeComponent();

            this.text = this.Name;
        } // VerticalText()

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed;
        /// otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            this.brush.Dispose();

            base.Dispose(disposing);
        }
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region UI HANDLING
        /// <summary>
        /// The function is the paint handler.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawText(e.Graphics);
        } // OnPaint()

        /// <summary>
        /// Is called when the fore color has been changed.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnForeColorChanged(EventArgs e)
        {
            this.brush = new SolidBrush(this.ForeColor);
        } // OnForeColorChanged()

        /// <summary>
        /// Draws the text vertically on the form.
        /// </summary>
        /// <param name="g">graphics context</param>
        private void DrawText(Graphics g)
        {
            var format = new StringFormat(StringFormatFlags.DirectionVertical);
            format.Trimming = StringTrimming.EllipsisCharacter;
            g.DrawString(this.text, this.Font, this.brush, 0f, 0f, format);
        } // DrawText()
        #endregion // UI HANDLING
    } // VerticalText
} // Tethys.Forms

// ====================================
// Tethys.Forms: end of VerticalText.cs
// ====================================
