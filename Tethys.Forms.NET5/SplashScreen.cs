// ---------------------------------------------------------------------------
// <copyright file="SplashScreen.cs" company="Tethys">
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
    using System.Diagnostics;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Windows.Forms;
    using Tethys.Reflection;
    using Tethys.Win32;

    /// <summary>
    /// The class SplashScreen implements a simple splash screen window.
    /// </summary>
    [ComVisible(true)]
    [SecurityCritical]
    public partial class SplashScreen : Form, IMessageFilter
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Internal property: is splash screen visible.
        /// </summary>
        private bool isVisible;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Default timeout for the Splash Screen (5000 milliseconds).
        /// </summary>
        public const int DefaultTimeout = 5000;

        /// <summary>
        /// Hiding event.
        /// </summary>
        public event EventHandler HidingEvent;

        /// <summary>
        /// Gets a value indicating whether the splash is screen visible.
        /// </summary>
        public bool IsVisible
        {
            get { return this.isVisible; }
        } // IsVisible

        /// <summary>
        /// Gets or sets the timeout for the Splash Screen.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Gets or sets the resource path to the splash bitmap.
        /// </summary>
        public string SplashBitmapPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use Application.ProductName
        /// instead  of TextProductName property".
        /// </summary>
        public bool UseProductName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use Tethys VersionInfo for
        /// version display instead of TextProductVersion property.
        /// </summary>
        public bool UseVersionInfo { get; set; }

        /// <summary>
        /// Gets or sets the product name to be displayed.
        /// </summary>
        public string TextProductName { get; set; }

        /// <summary>
        /// Gets or sets the product description to be displayed.
        /// </summary>
        public string TextProductDescription { get; set; }

        /// <summary>
        /// Gets or sets the product version to be displayed.
        /// </summary>
        public string TextProductVersion { get; set; }

        /// <summary>
        /// Gets or sets the 'test version' text to be displayed.
        /// </summary>
        public string TextTestVersion { get; set; }

        /// <summary>
        /// Gets or sets the Assembly that should be use to retrieve information.
        /// </summary>
        public Assembly SourceAssembly { get; set; }
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="SplashScreen"/> class.
        /// </summary>
        public SplashScreen()
        {
            this.UseProductName = true;
            this.UseVersionInfo = true;
            this.InitializeComponent();

            // initialize properties
            this.Timeout = DefaultTimeout;

            // initialize timer
            this.timer.Interval = this.Timeout;

            // add message filter
            Application.AddMessageFilter(this);
        } // SplashScreen()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        public new void Show()
        {
            this.InitializeSplashBitmap();

            this.timer.Enabled = true;
            this.isVisible = true;

            base.Show();
        } // Show()

        /// <summary>
        /// This function filters out a message before it is dispatched.
        /// We use it to catch all messages that should immediately
        /// close/hide the splash screen.
        /// </summary>
        /// <param name="m">The message to be dispatched. You cannot modify
        /// this message.</param>
        /// <returns>
        /// true to filter the message and stop it from being dispatched;
        /// false to allow the message to continue to the next filter or
        /// control.
        /// </returns>
        public bool PreFilterMessage(ref Message m)
        {
            if (!this.isVisible)
            {
                // splash screen not visible
                // -> nothing to do
                return false;
            } // if

            if ((m.Msg == (int)Msg.WM_SYSKEYDOWN)
              || (m.Msg == (int)Msg.WM_LBUTTONDOWN)
              || (m.Msg == (int)Msg.WM_RBUTTONDOWN)
              || (m.Msg == (int)Msg.WM_MBUTTONDOWN)
              || (m.Msg == (int)Msg.WM_NCLBUTTONDOWN)
              || (m.Msg == (int)Msg.WM_NCRBUTTONDOWN)
              || (m.Msg == (int)Msg.WM_NCMBUTTONDOWN))
            {
                this.HideSplashScreen();
                return true;
            } // if

            return false;
        } // PreFilterMessage()
        #endregion // PUBLIC METHODS

        //// ------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Loads the splash screen bitmap and assigns it to picture control.
        /// </summary>
        private void InitializeSplashBitmap()
        {
            // load splash screen bitmap and assign to picture control
            Debug.Assert(this.SourceAssembly != null, "assembly must not be null");

            var stream = this.SourceAssembly.GetManifestResourceStream(this.SplashBitmapPath);

            Debug.Assert(stream != null, "Stream must not be null");
            this.pictureBox.Image = new Bitmap(stream, false);
            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        } // InitializeSplashBitmap()

        /// <summary>
        /// This function is called when the splash screen is loaded (and displayed).
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SplashScreenLoad(object sender, EventArgs e)
        {
            this.InitializeSplashBitmap();

            this.timer.Enabled = true;
            this.isVisible = true;
        } // SplashScreen_Load()

        /// <summary>
        /// Hides the Splash Screen and raises the notification event.
        /// </summary>
        private void HideSplashScreen()
        {
            this.isVisible = false;
            this.timer.Enabled = false;

            if (this.HidingEvent != null)
            {
                // raise Hiding event
                var ea = new EventArgs();
                this.HidingEvent(this, ea);
            } // if

            this.Hide();
        } // HideSplashScreen()

        /// <summary>
        /// Hides the Splash Screen when we got a timeout event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance
        /// containing the event data.</param>
        private void TimerTick(object sender, EventArgs e)
        {
            this.HideSplashScreen();
        } // Timer_Tick()

        /// <summary>
        /// Hides the Splash Screen when any mouse button has been pressed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing
        /// the event data.</param>
        private void HideWindowOnMouseEvent(object sender, MouseEventArgs e)
        {
            this.HideSplashScreen();
        } // HideWindowOnMouseEvent()

        /// <summary>
        /// Hides the Splash Screen when any key has been pressed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the
        /// event data.</param>
        private void HideWindowOnKeyEvent(object sender, KeyEventArgs e)
        {
            this.HideSplashScreen();
        } // HideWindowOnKeyEvent()

        /// <summary>
        /// Paint our Splash Screen.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing
        /// the event data.</param>
        private void PaintHandler(object sender, PaintEventArgs e)
        {
            var grfx = e.Graphics;

            var rightBorder = this.Size.Width - 3;
            var offset = 0;
            var posAppName = 130;
            var posDescLine1 = 168;
            var posVersion = 212;

            // small font: e.Graphics.DpiX = 96.0
            // large font: e.Graphics.DpiX = 120.0
            if (e.Graphics.DpiX > 96.0)
            {
                // large fonts
                offset = 30;
                rightBorder -= 5;
                posVersion += 5;
            } // if

            posAppName += offset;
            posDescLine1 += offset;
            posVersion += offset;
            string str;

            var fnt18B = new Font("Arial", 20, FontStyle.Bold);
            var fnt12B = new Font("Arial", 12, FontStyle.Bold);
            var fnt10B = new Font("Arial", 10, FontStyle.Bold);
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Near;

            if (this.UseProductName)
            {
                str = Application.ProductName + "\n";
            }
            else
            {
                str = this.TextProductName + "\n";
            } // if

            grfx.DrawString(str, fnt18B, Brushes.Black, rightBorder, posAppName, sf);

            str = this.TextProductDescription;
            grfx.DrawString(str, fnt12B, Brushes.Black, rightBorder, posDescLine1, sf);

            if (this.UseVersionInfo)
            {
                var version = this.SourceAssembly.GetName().Version;
                str = VersionInfo.GetLevel(this.SourceAssembly, version);
                var releaseMode = (AssemblyReleaseModeAttribute)Attribute.GetCustomAttribute(
                    this.SourceAssembly,
                    typeof(AssemblyReleaseModeAttribute));
                if ((releaseMode != null) && (releaseMode.ReleaseMode == ReleaseMode.Test))
                {
                    str += "\n";
                    str += this.TextTestVersion;
                } // if
            }
            else
            {
                str = this.TextProductVersion;
            } // if

            grfx.DrawString(str, fnt10B, Brushes.Black, rightBorder, posVersion, sf);
        } // PaintHandler()
        #endregion // PRIVATE METHODS
    } // SplashScreen
} // Tethys.Forms

// ====================================
// Tethys.forms: end of SplashScreen.cs
// ====================================
