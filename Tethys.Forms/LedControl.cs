#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="LedControl.cs" company="Tethys">
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
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Enumeration of possible LedControl LED colors.
    /// </summary>
    public enum LedColor
    {
        /// <summary>
        /// Red LED.
        /// </summary>
        Red,

        /// <summary>
        /// Green LED.
        /// </summary>
        Green,

        /// <summary>
        /// Yellow LED.
        /// </summary>
        Yellow,

        /// <summary>
        /// Blue LED.
        /// </summary>
        Blue
    } // LedColor

    /// <summary>
    /// Enumeration of possible LedControl LED states.
    /// </summary>
    public enum LedState
    {
        /// <summary>
        /// LED on.
        /// </summary>
        On,

        /// <summary>
        /// LED off.
        /// </summary>
        Off,

        /// <summary>
        /// led control disabled.
        /// </summary>
        Disabled,
    } // LedState

    /// <summary>
    /// The class LedControl implements a simple LED like control.
    /// </summary>
    [Description("LED control")]
    [ToolboxBitmap(typeof(LedControl), "LedControlToolboxBitmap")]
    public partial class LedControl : UserControl
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Enumeration of LED bitmaps.
        /// </summary>
        private enum LedBitmap
        {
            /// <summary>
            /// Led off.
            /// </summary>
            Off = 0,

            /// <summary>
            /// Led: RedLow
            /// </summary>
            RedLow = 1,

            /// <summary>
            /// Led: RedHigh
            /// </summary>
            RedHigh = 2,

            /// <summary>
            /// Led: GreenLow
            /// </summary>
            GreenLow = 3,

            /// <summary>
            /// Led: GreenHigh
            /// </summary>
            GreenHigh = 4,

            /// <summary>
            /// Led: YellowLow
            /// </summary>
            YellowLow = 5,

            /// <summary>
            /// Led: YellowHigh
            /// </summary>
            YellowHigh = 6,

            /// <summary>
            /// Led: BlueLow
            /// </summary>
            BlueLow = 7,

            /// <summary>
            /// Led: BlueHigh
            /// </summary>
            BlueHigh = 8
        } // LedBitmap

        /// <summary>
        /// Default ping interval.
        /// </summary>
        private const int DefaultPingIntervall = 1000;

        /// <summary>
        /// Current LED color.
        /// </summary>
        private LedColor color;

        /// <summary>
        /// Current index within the image list.
        /// </summary>
        private int imageIndex;

        /// <summary>
        /// Current LED state.
        /// </summary>
        private LedState state;

        /// <summary>
        /// Timer for blink mode.
        /// </summary>
        private Timer timer;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the color of the LED.
        /// </summary>
        [Category("Appearance"), Description("Color of the LED")]
        public LedColor Color
        {
            get
            {
                return this.color;
            }

            set
            {
                // disable ping mode
                this.timer.Enabled = false;
                this.color = value;
                this.imageIndex = (int)ChangeState(this.state);
                Invalidate();
            }
        } // Color

        /// <summary>
        /// Gets or sets the current state of the LED.
        /// </summary>
        [Category("Appearance"), Description("State of the LED")]
        public LedState State
        {
            get
            {
                return this.state;
            }

            set
            {
                // disable ping mode
                this.timer.Enabled = false;
                this.state = value;
                this.imageIndex = (int)ChangeState(this.state);
                Invalidate();
            }
        } // State
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="LedControl"/> class.
        /// </summary>
        public LedControl()
        {
            InitializeComponent();

            this.state = LedState.Disabled;
            this.color = LedColor.Red;
        } // LedControl()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Enables the ping mode, i.e. the LED will turn on and off
        /// in the given interval values
        /// </summary>
        /// <param name="pingInterval">ping interval</param>
        public void Ping(int pingInterval)
        {
            this.timer.Enabled = true;
            this.timer.Interval = pingInterval;
        } // Ping()

        /// <summary>
        /// Enables the ping mode, i.e. the LED will turn on and off
        /// in a one second interval.
        /// </summary>
        public void Ping()
        {
            this.timer.Enabled = true;
            this.timer.Interval = DefaultPingIntervall;
        } // Ping()
        #endregion // PUBLIC METHODS

        //// ------------------------------------------------------------------

        #region UI MANAGEMENT
        /// <summary>
        /// Function that is called when the timer is elapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance 
        /// containing the event data.</param>
        private void TimerTick(object sender, System.EventArgs e)
        {
            if (this.state == LedState.Off)
            {
                // turn LED on
                this.state = LedState.On;
                this.imageIndex = (int)ChangeState(this.state);
                Invalidate();
            }
            else
            {
                // turn LED off
                this.state = LedState.Off;
                this.imageIndex = (int)ChangeState(this.state);
                Invalidate();
            } // if
        } // TimerTick()
        #endregion // UI MANAGEMENT

        //// ------------------------------------------------------------------

        #region CORE METHODS
        /// <summary>
        /// Changes the current LED state to the specified LED state.
        /// </summary>
        /// <param name="newState">new LED state</param>
        /// <returns>returns the bitmap for the new LED state</returns>
        private LedBitmap ChangeState(LedState newState)
        {
            if (newState == LedState.Disabled)
            {
                return LedBitmap.Off;
            } // if

            switch (this.color)
            {
                case LedColor.Red:
                    if (newState == LedState.Off)
                    {
                        return LedBitmap.RedLow;
                    } // if

                    return LedBitmap.RedHigh;
                case LedColor.Green:
                    if (newState == LedState.Off)
                    {
                        return LedBitmap.GreenLow;
                    } // if

                    return LedBitmap.GreenHigh;
                case LedColor.Yellow:
                    if (newState == LedState.Off)
                    {
                        return LedBitmap.YellowLow;
                    } // if

                    return LedBitmap.YellowHigh;
                case LedColor.Blue:
                    if (newState == LedState.Off)
                    {
                        return LedBitmap.BlueLow;
                    } // if

                    return LedBitmap.BlueHigh;

                // no default case!!
            } // switch

            // implicit default case
            return LedBitmap.Off;
        } // ChangeState()

        /// <summary>
        /// The function is the paint handler.
        /// </summary>
        /// <param name="e">Paint event arguments</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // call base class paint handler.
            base.OnPaint(e);

            imageListLeds.Draw(e.Graphics, 0, 0, this.imageIndex);
        } // OnPaint()
        #endregion // CORE METHODS
    } // LedControl
} // Tethys.Forms

// =================================
// Tethys.forms: end of LedControl.cs
// =================================
