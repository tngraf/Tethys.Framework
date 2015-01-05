#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="Caret.cs" company="Tethys">
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
    using System.Drawing;
    using System.Windows.Forms;

    using Tethys.Win32;

    /// <summary>
    /// A class for Win32 caret handling.
    /// </summary>
    public class Caret
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// The control the caret is for.
        /// </summary>
        private readonly Control ctrl;

        /// <summary>
        /// Current caret position.
        /// </summary>
        private Point pos;

        /// <summary>
        /// Flag 'caret is visible'.
        /// </summary>
        private bool visible;
        #endregion // PRIVATE PROPERTIES

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets the caret control.
        /// </summary>
        public Control Control
        {
            get
            {
                return this.ctrl;
            }
        } // Control

        /// <summary>
        /// Gets or sets the caret size.
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// Gets or sets the caret position.
        /// </summary>
        public Point Position
        {
            get
            {
                return this.pos;
            }

            set
            {
                this.pos = value;
                Win32Api.SetCaretPos(this.pos.X, this.pos.Y);
            }
        } // Position

        /// <summary>
        /// Gets or sets a value indicating whether to show the caret.
        /// </summary>
        public bool Visible
        {
            get
            {
                return this.visible;
            }

            set
            {
                this.visible = value;
                if (this.visible)
                {
                    Win32Api.ShowCaret(Control.Handle);
                }
                else
                {
                    Win32Api.HideCaret(Control.Handle);
                } // if
            }
        } // Visible
        #endregion // PUBLIC PROPERTIES

        /// <summary>
        /// Initializes a new instance of the <see cref="Caret"/> class.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        public Caret(Control ctrl)
        {
            this.ctrl = ctrl;
            Position = Point.Empty;
            Size = new Size(1, ctrl.Font.Height);

            // set focus event handler
            Control.GotFocus += ControlOnGotFocus;
            Control.LostFocus += ControlOnLostFocus;

            // if the control already has focus, create the caret.
            if (ctrl.Focused)
            {
                ControlOnGotFocus(ctrl, new EventArgs());
            } // if
        } // Caret()

        /// <summary>
        /// Show caret.
        /// </summary>
        public void Show()
        {
            this.visible = true;
            Win32Api.SetCaretPos(Position.X, Position.Y);
        } // Show()

        /// <summary>
        /// Hide caret.
        /// </summary>
        public void Hide()
        {
            this.visible = false;
        } // Hide()

        /// <summary>
        /// Disposes this object.
        /// </summary>
        public void Dispose()
        {
            // If the control has focus, destroy the caret.
            if (this.ctrl.Focused)
            {
                ControlOnLostFocus(this.ctrl, new EventArgs());
            } // if

            // unregister focus handler
            Control.GotFocus -= this.ControlOnGotFocus;
            Control.LostFocus -= this.ControlOnLostFocus;
        } // Dispose()

        /// <summary>
        /// Is called when the control received the focus.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="ea">The <see cref="EventArgs"/> instance
        /// containing the event data.</param>
        private void ControlOnGotFocus(object obj, EventArgs ea)
        {
            if (Win32Api.CreateCaret(Control.Handle, IntPtr.Zero,
              Size.Width, Size.Height) > 0)
            {
                Win32Api.SetCaretPos(Position.X, Position.Y);
                Show();
            } // if
        } // ControlOnGotFocus

        /// <summary>
        /// Is called when the control lost the focus.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="ea">The <see cref="EventArgs"/> instance
        /// containing the event data.</param>
        private void ControlOnLostFocus(object obj, EventArgs ea)
        {
            Hide();
            Win32Api.DestroyCaret();
        } // ControlOnLostFocus()
    } // Caret
} // Tethys.Forms

// ============================
// Tethys.forms: end of Caret.cs
// ============================
