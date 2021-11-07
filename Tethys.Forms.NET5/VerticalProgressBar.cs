// ---------------------------------------------------------------------------
// <copyright file="VerticalProgressBar.cs" company="Tethys">
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
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// Vertical progress bar styles.
    /// </summary>
    public enum VerticalBarStyle
    {
        /// <summary>
        /// Classic style (same as ProgressBar).
        /// </summary>
        Classic,

        /// <summary>
        /// Solid style.
        /// </summary>
        Solid,
    } // VerticalBarStyle

    /// <summary>
    /// Vertical progress bar border styles.
    /// </summary>
    public enum VerticalBarBorderStyle
    {
        /// <summary>
        /// Classic style (same as ProgressBar).
        /// </summary>
        Classic,

        /// <summary>
        /// No border.
        /// </summary>
        None,
    } // VerticalBarBorderStyle

    /// <summary>
    /// Represents a Windows vertical progress bar control.
    /// </summary>
    [Description("Vertical Progress Bar")]
    [ToolboxBitmap(typeof(ProgressBar))]
    [ComVisible(false)]
    public partial class VerticalProgressBar : UserControl
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Default value.
        /// </summary>
        private int value = 50;

        /// <summary>
        /// Minimum value.
        /// </summary>
        private int minimum;

        /// <summary>
        /// Maximum value.
        /// </summary>
        private int maximum = 100;

        /// <summary>
        /// Step value.
        /// </summary>
        private int step = 10;

        /// <summary>
        /// Vertical bar style.
        /// </summary>
        private VerticalBarStyle style = VerticalBarStyle.Classic;

        /// <summary>
        /// Vertical border style.
        /// </summary>
        private VerticalBarBorderStyle borderStyle = VerticalBarBorderStyle.Classic;

        /// <summary>
        /// Bar color.
        /// </summary>
        private Color color = Color.Blue;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the verticalProgressBar Maximum Value.
        /// </summary>
        [Description("VerticalProgressBar Maximum Value")]
        [Category("VerticalProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public int Maximum
        {
            get
            {
                return this.maximum;
            }

            set
            {
                this.maximum = value;

                if (this.maximum < this.minimum)
                {
                    this.minimum = this.maximum;
                } // if

                if (this.maximum < this.value)
                {
                    this.value = this.maximum;
                } // if

                this.Invalidate();
            } // set
        } // Maximum

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        [Description("VerticalProgressBar Minimum Value")]
        [Category("VerticalProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public int Minimum
        {
            get
            {
                return this.minimum;
            }

            set
            {
                this.minimum = value;

                if (this.minimum > this.maximum)
                {
                    this.maximum = this.minimum;
                } // if

                if (this.minimum > this.value)
                {
                    this.value = this.minimum;
                } // if

                this.Invalidate();
            }
        } // Minimum

        /// <summary>
        /// Gets or sets the VerticalProgressBar Step.
        /// </summary>
        [Description("VerticalProgressBar Step")]
        [Category("VerticalProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public int Step
        {
            get
            {
                return this.step;
            }

            set
            {
                this.step = value;
            }
        }

        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        [Description("VerticalProgressBar Current Value")]
        [Category("VerticalProgressBar")]
        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
                if (this.value > this.maximum)
                {
                    this.value = this.maximum;
                } // if

                if (this.value < this.minimum)
                {
                    this.value = this.minimum;
                } // if

                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [Description("VerticalProgressBar Color")]
        [Category("VerticalProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public Color Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        [Description("VerticalProgressBar Border Style")]
        [Category("VerticalProgressBar")]
        public new VerticalBarBorderStyle BorderStyle
        {
            get
            {
                return this.borderStyle;
            }

            set
            {
                this.borderStyle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        [Description("VerticalProgressBar Style")]
        [Category("VerticalProgressBar")]
        public VerticalBarStyle VerticalBarStyle
        {
            get
            {
                return this.style;
            }

            set
            {
                this.style = value;
                this.Invalidate();
            }
        }
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="VerticalProgressBar"/> class.
        /// </summary>
        public VerticalProgressBar()
        {
            this.InitializeComponent();
        } // VerticalProgressBar()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Increments the progress bar by the defined step value.
        /// </summary>
        public void PerformStep()
        {
            this.value += this.step;

            if (this.value > this.maximum)
            {
                this.value = this.maximum;
            } // if

            if (this.value < this.minimum)
            {
                this.value = this.minimum;
            } // if

            this.Invalidate();
        } // PerformStep()

        /// <summary>
        /// Increments the progress bar by the specified value.
        /// </summary>
        /// <param name="increment">The increment.</param>
        public void Progress(int increment)
        {
            this.value += increment;

            if (this.value > this.maximum)
            {
                this.value = this.maximum;
            } // if

            if (this.value < this.minimum)
            {
                this.value = this.minimum;
            } // if

            this.Invalidate();
        } // Progress()
        #endregion // PUBLIC METHODS

        //// ------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Draws the border.
        /// </summary>
        /// <param name="dc">The dc.</param>
        private void DrawBorder(Graphics dc)
        {
            if (this.borderStyle == VerticalBarBorderStyle.Classic)
            {
                var darkColor = ControlPaint.Dark(this.BackColor);
                var brightColor = ControlPaint.Dark(this.BackColor);
                var p = new Pen(darkColor, 1);
                dc.DrawLine(p, this.Width, 0, 0, 0);
                dc.DrawLine(p, 0, 0, 0, this.Height);
                p = new Pen(brightColor, 1);
                dc.DrawLine(p, 0, this.Height, this.Width, this.Height);
                dc.DrawLine(p, this.Width, this.Height, this.Width, 0);
            } // if
        } // DrawBorder()

        /// <summary>
        /// Draws the bar.
        /// </summary>
        /// <param name="dc">The dc.</param>
        private void DrawBar(Graphics dc)
        {
            if (this.minimum == this.maximum || this.value == 0)
            {
                return;
            } // if

            // the bar width
            int width;

            // the bottom-left x pos of the bar
            int x;

            // the bottom-left y pos of the bar
            int y;

            if (this.borderStyle == VerticalBarBorderStyle.None)
            {
                width = this.Width;
                x = 0;
                y = this.Height;
            }
            else
            {
                if (this.Width > 4 || this.Height > 2)
                {
                    width = this.Width - 4;
                    x = 2;
                    y = this.Height - 1;
                }
                else
                {
                    return; // Cannot draw
                } // if
            } // if

            int height = this.value * this.Height / (this.maximum - this.minimum);

            if (this.style == VerticalBarStyle.Solid)
            {
                this.DrawSolidBar(dc, x, y, width, height);
            } // if

            if (this.style == VerticalBarStyle.Classic)
            {
                this.DrawClassicBar(dc, x, y, width, height);
            }
        } // DrawBar()

        /// <summary>
        /// Draws the solid bar.
        /// </summary>
        /// <param name="dc">The dc.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private void DrawSolidBar(Graphics dc, int x, int y, int width, int height)
        {
            dc.FillRectangle(new SolidBrush(this.color), x, y - height, width, height);
        } // DrawSolidBar()

        /// <summary>
        /// Draws the classic bar.
        /// </summary>
        /// <param name="dc">The dc.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private void DrawClassicBar(Graphics dc, int x, int y, int width, int height)
        {
            // The pos y of value
            var valueposY = y - height;

            // The height of the block
            var blockheight = width * 3 / 4;

            for (var currentpos = y; currentpos > valueposY; currentpos -= blockheight + 1)
            {
                dc.FillRectangle(new SolidBrush(this.color), x, currentpos - blockheight, width, blockheight);
            }
        } // DrawClassicBar()

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that
        /// contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var dc = e.Graphics;

            // Draw Bar
            this.DrawBar(dc);

            // Draw Border
            this.DrawBorder(dc);

            base.OnPaint(e);
        } // OnPaint()

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains
        /// the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Invalidate();
        } // OnSizeChanged()
        #endregion // PRIVATE METHODS
    } // VerticalProgressBar
} // Tethys.Forms

// ===========================================
// Tethys.Forms: end of VerticalProgressBar.cs
// ===========================================
