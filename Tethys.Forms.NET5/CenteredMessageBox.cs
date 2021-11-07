// ---------------------------------------------------------------------------
// <copyright file="CenteredMessageBox.cs" company="Tethys">
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
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using Tethys.Win32;

    /// <summary>
    /// CenteredMessageBox implements a message box that is always centered over
    /// the parent window like the normal Win32 MessageBox.
    /// </summary>
    public static class CenteredMessageBox
    {
        #region SHOW() FUNCTIONS
        /// <summary>
        /// Displays a message box with specified text.
        /// </summary>
        /// <param name="owner">Window parent (owner).</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner, string text)
        {
            Init(string.Empty, owner);
            return MessageBox.Show(owner, text);
        } // Show()

        /// <summary>
        /// Displays a message box with specified text and caption.
        /// </summary>
        /// <param name="owner">Window parent (owner).</param>
        /// <param name="text">The text to display in the message box. </param>
        /// <param name="caption">The text to display in the title bar of the
        ///  message box. </param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            Init(caption, owner);
            return MessageBox.Show(owner, text, caption);
        } // Show()

        /// <summary>
        /// Displays a message box with specified text, caption, and buttons.
        /// </summary>
        /// <param name="owner">Window parent (owner).</param>
        /// <param name="text">The text to display in the message box. </param>
        /// <param name="caption">The text to display in the title bar of the
        /// message box. </param>
        /// <param name="buttons">One of the MessageBoxButtons that specifies
        /// which buttons to display in the message box.</param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            Init(caption, owner);
            return MessageBox.Show(owner, text, caption, buttons);
        } // Show()

        /// <summary>
        /// Displays a message box with specified text, caption, buttons, and
        /// icon.
        /// </summary>
        /// <param name="owner">Window parent (owner).</param>
        /// <param name="text">The text to display in the message box. </param>
        /// <param name="caption">The text to display in the title bar of the
        /// message box. </param>
        /// <param name="buttons">One of the MessageBoxButtons that specifies
        /// which buttons to display in the message box.</param>
        /// <param name="icon">One of the MessageBoxIcon values that specifies
        /// which icon to display in the message box. </param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(
            IWin32Window owner,
            string text,
            string caption,
            MessageBoxButtons buttons,
            MessageBoxIcon icon)
        {
            Init(caption, owner);
            return MessageBox.Show(owner, text, caption, buttons, icon);
        } // Show()

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons,
        /// icon, and default button.
        /// </summary>
        /// <param name="owner">Window parent (owner).</param>
        /// <param name="text">The text to display in the message box. </param>
        /// <param name="caption">The text to display in the title bar of the
        /// message box. </param>
        /// <param name="buttons">One of the MessageBoxButtons that specifies
        /// which buttons to display in the message box.</param>
        /// <param name="icon">One of the MessageBoxIcon values that specifies
        /// which icon to display in the message box.</param>
        /// <param name="defButton">One for the MessageBoxDefaultButton values
        /// which specifies which is the default button for the message box.
        /// </param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(
            IWin32Window owner,
            string text,
            string caption,
            MessageBoxButtons buttons,
            MessageBoxIcon icon,
            MessageBoxDefaultButton defButton)
        {
            Init(caption, owner);
            return MessageBox.Show(owner, text, caption, buttons, icon, defButton);
        } // Show()

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons,
        /// icon, and default button.
        /// </summary>
        /// <param name="owner">Window parent (owner).</param>
        /// <param name="text">The text to display in the message box. </param>
        /// <param name="caption">The text to display in the title bar of the
        /// message box. </param>
        /// <param name="buttons">One of the MessageBoxButtons that specifies
        /// which buttons to display in the message box.</param>
        /// <param name="icon">One of the MessageBoxIcon values that specifies
        /// which icon to display in the message box.</param>
        /// <param name="defButton">One for the MessageBoxDefaultButton values
        /// which specifies which is the default button for the message box.
        /// </param>
        /// <param name="options">Message box Options.</param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(
            IWin32Window owner,
            string text,
            string caption,
            MessageBoxButtons buttons,
            MessageBoxIcon icon,
            MessageBoxDefaultButton defButton,
            MessageBoxOptions options)
        {
            Init(caption, owner);
            return MessageBox.Show(owner, text, caption, buttons, icon, defButton, options);
        } // Show()
        #endregion // SHOW() FUNCTIONS

        //// --------------------------------------------------------------------

        #region PRIVATE PROPERTIES
        /// <summary>
        /// The hook.
        /// </summary>
        private static readonly Win32Api.HookProc HookProc = MessageBoxHookProc;

        /// <summary>
        /// Hook caption.
        /// </summary>
        private static string hookCaption = string.Empty;

        /// <summary>
        /// Hook handle.
        /// </summary>
        private static IntPtr handleHook = IntPtr.Zero;

        /// <summary>
        /// Parent window.
        /// </summary>
        private static IWin32Window parent;
        #endregion // PRIVATE PROPERTIES

        //// --------------------------------------------------------------------

        #region CONTRUCTION
        /// <summary>
        /// Initialize hook management.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="owner">The owner.</param>
        /// <exception cref="System.NotSupportedException">multiple
        /// calls are not supported.</exception>
        private static void Init(string caption, IWin32Window owner)
        {
            if (handleHook != IntPtr.Zero)
            {
                // prohibit reentrancy
                throw new NotSupportedException(
                    "multiple calls are not supported");
            } // if

            // store parent (owner)
            parent = owner;

            // create hook
            hookCaption = caption ?? string.Empty;
            handleHook = Win32Api.SetWindowsHookEx(
                (int)WindowsHookCodes.WH_CALLWNDPROCRET,
                HookProc,
                IntPtr.Zero,
                Thread.CurrentThread.ManagedThreadId);
        } // Init()
        #endregion // CONTRUCTION

        //// --------------------------------------------------------------------

        #region HOOK
        /// <summary>
        /// This is the function called by the Windows hook management.
        /// We assume, that when an WM_INITDIALOG message is sent and
        /// the window text is the same like the one of our window that
        /// the window to hook call comes from is indeed our window.
        /// We start the timer and unhook ourselves.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>The handle.</returns>
        private static IntPtr MessageBoxHookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code < 0)
            {
                return Win32Api.CallNextHookEx(handleHook, code, wParam, lParam);
            } // if

            var msg = (CWPRETSTRUCT)Marshal.PtrToStructure(lParam, typeof(CWPRETSTRUCT));
            var hook = handleHook;

            if ((hookCaption != null) && (msg.message == (uint)Msg.WM_INITDIALOG))
            {
                // get window text
                var length = Win32Api.GetWindowTextLength(msg.hwnd);
                var text = new StringBuilder(length + 1);
                var result = Win32Api.GetWindowText(msg.hwnd, text, text.Capacity);
                Debug.Assert(result > 0, "GetWindowText reports error!");

                // check whether this is the text we expect
                if (hookCaption == text.ToString())
                {
                    hookCaption = null;

                    // get size of the parent window
                    var rectParent = default(RECT);
                    var rectClient = default(RECT);
                    if (Win32Api.GetWindowRect(parent.Handle, ref rectParent))
                    {
                        // calculate center point
                        var centerParent = new Point(
                            (rectParent.left + rectParent.right) / 2,
                            (rectParent.top + rectParent.bottom) / 2);
                        if (Win32Api.GetWindowRect(msg.hwnd, ref rectClient))
                        {
                            var pt = new Point(
                                centerParent.X - ((rectClient.right - rectClient.left) / 2),
                                centerParent.Y - ((rectClient.bottom - rectClient.top) / 2));
                            if (pt.X < 0)
                            {
                                pt.X = 0;
                            } // if

                            if (pt.Y < 0)
                            {
                                pt.Y = 0;
                            } // if

                            // set new window position
                            const uint Flags = (uint)SetWindowPosFlags.SWP_NOOWNERZORDER
                                + (uint)SetWindowPosFlags.SWP_NOSIZE
                                + (uint)SetWindowPosFlags.SWP_NOZORDER;
                            Win32Api.SetWindowPos(msg.hwnd, IntPtr.Zero, pt.X, pt.Y, 0, 0, Flags);
                        } // if
                    } // if

                    // unhook
                    Win32Api.UnhookWindowsHookEx(handleHook);
                    handleHook = IntPtr.Zero;
                } // if
            } // if

            // default: call next hook
            return Win32Api.CallNextHookEx(hook, code, wParam, lParam);
        } // MessageBoxHookProc()
        #endregion // HOOK
    } // CenteredMessageBox
} // Tethys.Forms

// ==========================================
// Tethys.forms: end of centeredmessagebox.cs
// ==========================================
