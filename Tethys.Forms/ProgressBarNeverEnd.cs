#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="ProgressBarNeverEnd.cs" company="Tethys">
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
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    #region ENUMERATIONS
    /// <summary>
    /// Progress indicator rotation styles.
    /// </summary>
    public enum ProgressStyle
    {
        /// <summary>
        /// Display progress from left to right.
        /// </summary>
        LeftToRight,

        /// <summary>
        /// Display progress from right to left and back to right.
        /// </summary>
        LeftAndRight
    } // ProgressStyle

    /// <summary>
    /// Possible types of progress bar.
    /// </summary>
    public enum ProgressType
    {
        /// <summary>
        /// Box image.
        /// </summary>
        Box,

        /// <summary>
        /// User defined image.
        /// </summary>
        Graphic
    } // ProgressType

    /// <summary>
    /// Possible Progress bar box styles.
    /// </summary>
    public enum ProgressBoxStyle
    {
        /// <summary>
        /// Solid Same Size
        /// </summary>
        SolidSameSize,

        /// <summary>
        /// Box Around
        /// </summary>
        BoxAround,

        /// <summary>
        /// Solid Bigger
        /// </summary>
        SolidBigger,

        /// <summary>
        /// Solid Smaller
        /// </summary>
        SolidSmaller,
    } // ProgressBoxStyle
    #endregion

    /// <summary>
    /// ProgressBarNeverEnd is a progress bar that never ends, i.e.
    /// the progress indicator will always move from left to right
    /// or from left to right and the back to left.
    /// </summary>
    [ToolboxBitmap(typeof(ProgressBar))]
    public partial class ProgressBarNeverEnd : UserControl
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Timer for auto progress.
        /// </summary>
        private readonly Timer timerAutoProgress;

        /// <summary>
        /// Determines the type of progress bar.
        /// </summary>
        private ProgressType progressType = ProgressType.Box;

        /// <summary>
        /// Indicates the progress indicator rotation style.
        /// </summary>
        private ProgressStyle progressStyle = ProgressStyle.LeftToRight;

        /// <summary>
        /// Progress bar box style.
        /// </summary>
        private ProgressBoxStyle progressBoxStyle = ProgressBoxStyle.SolidSameSize;

        /// <summary>
        /// Background graphic.
        /// </summary>
        private Image normalImage;

        /// <summary>
        /// Point graphic.
        /// </summary>
        private Image pointImage;

        /// <summary>
        /// Determines if the border is shown.
        /// </summary>
        private bool showBorder = true;

        /// <summary>
        /// Number of points in the Progress bar
        /// </summary>
        private int numPoints;

        /// <summary>
        /// Position of the progress indicator
        /// </summary>
        private int position;

        /// <summary>
        /// Color of the indicator.
        /// </summary>
        private Color indicatorColor = Color.Red;

        /// <summary>
        /// Indicates whether auto-progress is enabled.
        /// </summary>
        private bool autoProgress;

        /// <summary>
        /// Indicates the speed of the progress indicator (1 [slower] to 254 [faster]
        /// </summary>
        private int autoProgressSpeed = 100;

        /// <summary>
        /// Speed multiplier for indicator speed.
        /// </summary>
        private const byte SpeedMultiplier = 2;

        /// <summary>
        /// Flag that the control needs to be redrawn.
        /// </summary>
        private bool requireClear;

        /// <summary>
        /// Flag for left and right progress style for the direction.
        /// </summary>
        private bool increasing = true;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the type of progress bar.
        /// </summary>
        [Category("Appearance"),
        Description("Determines the type of progress bar")]
        public ProgressType ProgressType
        {
            get
            {
                return this.progressType;
            }

            set
            {
                this.progressType = value;
                this.Invalidate();
            } // set
        } // ProgressType

        /// <summary>
        /// Gets or sets the background graphic.
        /// </summary>
        [Category("Appearance"),
        Description("Gets/sets the background graphic")]
        public Image NormalImage
        {
            get
            {
                return this.normalImage;
            }

            set
            {
                this.normalImage = value;
                this.Invalidate();
            } // set
        } // NormalImage

        /// <summary>
        /// Gets or sets the point graphic.
        /// </summary>
        [Category("Appearance"),
        Description("Gets/sets the point graphic")]
        public Image PointImage
        {
            get
            {
                return this.pointImage;
            }

            set
            {
                this.pointImage = value;
                this.Invalidate();
            } // set
        } // PointImage

        /// <summary>
        /// Gets or sets a value indicating whether the border is shown
        /// </summary>
        [Category("Appearance"),
        Description("Determines if the border is shown"),
        DefaultValue(true)]
        public bool ShowBorder
        {
            get
            {
                return this.showBorder;
            }

            set
            {
                this.showBorder = value;
                this.Invalidate();
            } // set
        } // ShowBorder

        /// <summary>
        /// Gets the number of points in the Progress bar.
        /// </summary>
        [Category("Appearance"),
        Description("Number of points in the Progressbar"),
        Browsable(false)]
        public int PointNumber
        {
            get
            {
                return this.numPoints;
            }
        } // NumPoints

        /// <summary>
        /// Gets or sets the position of the progress indicator.
        /// </summary>
        [Category("Appearance"),
        Description("Position of the progress indicator"),
        Browsable(false)]
        public int Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
                this.Invalidate();
            } // set
        } // Position

        /// <summary>
        /// Gets or sets the color of the indicator.
        /// </summary>
        [Category("Appearance"),
        Description("Color of the indicator")]
        public Color IndicatorColor
        {
            get
            {
                return this.indicatorColor;
            }

            set
            {
                this.indicatorColor = value;
                this.Invalidate();
            } // set
        } // IndicatorColor

        /// <summary>
        /// Gets or sets the indicator rotation style.
        /// </summary>
        [Category("Appearance"),
        Description("Indicates the progress indicator rotation style")]
        public ProgressStyle ProgressStyle
        {
            get
            {
                return this.progressStyle;
            }

            set
            {
                this.progressStyle = value;
                this.Invalidate();
            } // set
        } // ProgressStyle

        /// <summary>
        /// Gets or sets a value indicating whether auto-progress is enabled.
        /// </summary>
        [Category("Appearance"),
        Description("Indicates whether auto-progress is enabled"),
        DefaultValue(false)]
        public bool AutoProgress
        {
            get
            {
                return this.autoProgress;
            }

            set
            {
                this.timerAutoProgress.Interval = (255 - this.autoProgressSpeed) * SpeedMultiplier;
                if (value)
                {
                    this.timerAutoProgress.Start();
                }
                else
                {
                    this.timerAutoProgress.Stop();
                } // if
                this.autoProgress = value;
            } // set
        } // AutoProgress

        /// <summary>
        /// Gets or sets the speed of the progress indicator (1 [slower] to 254 [faster].
        /// </summary>
        [Category("Appearance"),
        Description("Indicates the speed of the progress indicator (1 [slower] to 254 [faster]")]
        public int AutoProgressSpeed
        {
            get
            {
                return this.autoProgressSpeed;
            }

            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                else if (value > 254)
                {
                    value = 254;
                } // if
                this.timerAutoProgress.Stop();
                this.timerAutoProgress.Interval = (255 - value) * SpeedMultiplier;
                this.timerAutoProgress.Enabled = this.autoProgress;
                this.autoProgressSpeed = value;
            } // set
        } // AutoProgressSpeed

        /// <summary>
        /// Gets or sets the progress bar box style.
        /// </summary>
        [Category("Appearance"),
        Description("Progressbar box style")]
        public ProgressBoxStyle ProgressBoxStyle
        {
            get
            {
                return this.progressBoxStyle;
            }

            set
            {
                this.progressBoxStyle = value;
                this.Invalidate();
            } // set
        } // ProgressBoxStyle
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBarNeverEnd"/> class.
        /// </summary>
        public ProgressBarNeverEnd()
        {
            InitializeComponent();

            this.timerAutoProgress = new Timer(this.components);
            this.Paint += this.PaintHandler;
            this.Resize += this.ResizeHandler;
            this.timerAutoProgress.Tick += this.TimerHandler;
        } // ProgressBarNeverEnd()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region SERIALIZATION HELPER
        /// <summary>
        /// Should the type of the serialize progress.
        /// </summary>
        /// <returns>A flag.</returns>
        private bool ShouldSerializeProgressType()
        {
            return this.progressType != ProgressType.Box;
        } // ShouldSerializeProgressType

        /// <summary>
        /// Should the serialize normal image.
        /// </summary>
        /// <returns>A flag.</returns>
        private bool ShouldSerializeNormalImage()
        {
            return this.normalImage != null;
        } // ShouldSerializeNormalImage

        /// <summary>
        /// Should the serialize point image.
        /// </summary>
        /// <returns>A flag.</returns>
        private bool ShouldSerializePointImage()
        {
            return this.pointImage != null;
        } // ShouldSerializePointImage()

        /// <summary>
        /// Should the color of the serialize indicator.
        /// </summary>
        /// <returns>
        /// A flag.
        /// </returns>
        private bool ShouldSerializeIndicatorColor()
        {
            return this.indicatorColor != Color.Red;
        } // ShouldSerializeIndicatorColor

        /// <summary>
        /// Should the serialize progress style.
        /// </summary>
        /// <returns>
        /// A flag.
        /// </returns>
        private bool ShouldSerializeProgressStyle()
        {
            return this.progressStyle != ProgressStyle.LeftToRight;
        } // ShouldSerializeProgressStyle()

        /// <summary>
        /// Should the serialize auto progress speed.
        /// </summary>
        /// <returns>
        /// A flag.
        /// </returns>
        private bool ShouldSerializeAutoProgressSpeed()
        {
            return this.autoProgressSpeed != 100;
        } // ShouldSerializeAutoProgressSpeed()

        /// <summary>
        /// Should the serialize progress box style.
        /// </summary>
        /// <returns>
        /// A flag.
        /// </returns>
        private bool ShouldSerializeProgressBoxStyle()
        {
            return this.progressBoxStyle != ProgressBoxStyle.SolidSameSize;
        } // ShouldSerializeProgressBoxStyle()
        #endregion // SERIALIZATION HELPER

        //// ------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Handles the resizing of the control.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void ResizeHandler(object sender, EventArgs e)
        {
            this.requireClear = true;
            this.position = 0;
            Invalidate();
        } // ResizeHandler()

        /// <summary>
        /// Timers the handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void TimerHandler(object sender, EventArgs e)
        {
            if (this.position == this.numPoints - 1)
            {
                if (this.progressStyle == ProgressStyle.LeftToRight)
                {
                    this.position = 0;
                }
                else
                {
                    this.position -= 1;
                    this.increasing = false;
                } // if
            }
            else if ((this.position == 0) && (!this.increasing))
            {
                this.position += 1;
                this.increasing = true;
            }
            else
            {
                if (this.increasing)
                {
                    this.position += 1;
                }
                else
                {
                    this.position -= 1;
                } // if
            } // if
            this.requireClear = false;
            Invalidate();
        } // TimerHandler()

        /// <summary>
        /// Paints the handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/>
        /// instance containing the event data.</param>
        private void PaintHandler(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            if (this.requireClear)
            {
                e.Graphics.Clear(this.BackColor);
            } // if
            DrawBackground(e.Graphics);
        } // PaintHandler()

        /// <summary>
        /// Draws the background.
        /// </summary>
        /// <param name="grfx">The GRFX.</param>
        private void DrawBackground(Graphics grfx)
        {
            this.numPoints = 0;
            if (this.Width > 0 && this.Height > 0)
            {
                if (this.showBorder)
                {
                    grfx.DrawRectangle(new Pen(SystemColors.ActiveBorder),
                      new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                } // if

                var boxSize = checked((int)(this.Height * 0.75));
                var boxLeft = boxSize / 2;
                if (boxSize > 3)
                {
                    do
                    {
                        var r = new Rectangle(boxLeft, 0, this.Height - 1, this.Height - 1);
                        if (r.Left + r.Width > this.Width)
                        {
                            break;
                        } // if
                        if (this.numPoints == this.position)
                        {
                            PositionIndicator(r, grfx);
                        }
                        else
                        {
                            var r2 = new Rectangle(r.Left + 3, r.Top + 3, r.Width - 6, r.Height - 6);
                            if ((this.normalImage != null) && (this.progressType == ProgressType.Graphic))
                            {
                                grfx.DrawImage(this.normalImage, r2);
                            }
                            else
                            {
                                grfx.FillRectangle(new SolidBrush(this.ForeColor), r2);
                            } // if
                        } // if
                        boxLeft += checked((int)(boxSize * 1.5));
                        this.numPoints += 1;
                    }
                    while (true);
                } // if
            } // if
        } // DrawBackground()

        /// <summary>
        /// Positions the indicator.
        /// </summary>
        /// <param name="rect">The rectangle.</param>
        /// <param name="grfx">The GRFX.</param>
        private void PositionIndicator(Rectangle rect, Graphics grfx)
        {
            if ((this.pointImage != null) && (this.progressType == ProgressType.Graphic))
            {
                grfx.DrawImage(this.pointImage, rect);
            }
            else
            {
                Rectangle r2;
                if (this.ProgressBoxStyle == ProgressBoxStyle.SolidSameSize)
                {
                    r2 = new Rectangle(rect.Left + 3, rect.Top + 3, rect.Width - 5, rect.Height - 5);
                    grfx.FillRectangle(new SolidBrush(this.indicatorColor), r2);
                }
                else if (this.ProgressBoxStyle == ProgressBoxStyle.BoxAround)
                {
                    grfx.DrawRectangle(new Pen(this.indicatorColor), rect);
                    r2 = new Rectangle(rect.Left + 3, rect.Top + 3, rect.Width - 5, rect.Height - 5);
                    grfx.FillRectangle(new SolidBrush(this.indicatorColor), r2);
                }
                else if (this.ProgressBoxStyle == ProgressBoxStyle.SolidBigger)
                {
                    grfx.FillRectangle(new SolidBrush(this.indicatorColor), rect);
                }
                else if (this.ProgressBoxStyle == ProgressBoxStyle.SolidSmaller)
                {
                    r2 = new Rectangle(rect.Left + 5, rect.Top + 5, rect.Width - 9, rect.Height - 9);
                    grfx.FillRectangle(new SolidBrush(this.indicatorColor), r2);
                } // if
            } // if
        } // PositionIndicator()
        #endregion // PRIVATE METHODS
    } // ProgressBarNeverEnd
} // Tethys.Forms

// ===========================================
// Tethys.forms: end of ProgressBarNeverEnd.cs
// ===========================================
