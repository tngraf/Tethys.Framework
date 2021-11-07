// ---------------------------------------------------------------------------
// <copyright file="Caret.cs" company="Tethys">
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
        public Control Control { get; }

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
                    Win32Api.ShowCaret(this.Control.Handle);
                }
                else
                {
                    Win32Api.HideCaret(this.Control.Handle);
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
            this.Control = ctrl;
            this.Position = Point.Empty;
            this.Size = new Size(1, ctrl.Font.Height);

            // set focus event handler
            this.Control.GotFocus += this.ControlOnGotFocus;
            this.Control.LostFocus += this.ControlOnLostFocus;

            // if the control already has focus, create the caret.
            if (ctrl.Focused)
            {
                this.ControlOnGotFocus(ctrl, new EventArgs());
            } // if
        } // Caret()

        /// <summary>
        /// Show caret.
        /// </summary>
        public void Show()
        {
            this.visible = true;
            Win32Api.SetCaretPos(this.Position.X, this.Position.Y);
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
            if (this.Control.Focused)
            {
                this.ControlOnLostFocus(this.Control, new EventArgs());
            } // if

            // unregister focus handler
            this.Control.GotFocus -= this.ControlOnGotFocus;
            this.Control.LostFocus -= this.ControlOnLostFocus;
        } // Dispose()

        /// <summary>
        /// Is called when the control received the focus.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="ea">The <see cref="EventArgs"/> instance
        /// containing the event data.</param>
        private void ControlOnGotFocus(object obj, EventArgs ea)
        {
            if (Win32Api.CreateCaret(
                this.Control.Handle,
                IntPtr.Zero,
                this.Size.Width,
                this.Size.Height) > 0)
            {
                Win32Api.SetCaretPos(this.Position.X, this.Position.Y);
                this.Show();
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
            this.Hide();
            Win32Api.DestroyCaret();
        } // ControlOnLostFocus()
    } // Caret
} // Tethys.Forms

// ============================
// Tethys.forms: end of Caret.cs
// ============================
