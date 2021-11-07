// ---------------------------------------------------------------------------
// <copyright file="TimeoutMessageBox.cs" company="Tethys">
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
  using System.Diagnostics.CodeAnalysis;
  using System.Runtime.InteropServices;
  using System.Text;
  using System.Threading;
  using System.Windows.Forms;
  using Tethys.Win32;

  /// <summary>
  /// TimeoutMessageBox implements a message box that is closed automatically
  /// after a given timeout.
  /// </summary>
  /// <remarks>
  /// How does it work?
  /// Just before calling MessageBox.Show(...), SetWindowsHookEx(WH_CALLWNDPROCRET,)
  /// is called. The hook procedure looks for a WM_INITDIALOG on a window with text equal
  /// to the message box caption. A windows timer is started on that window with
  /// the appropriate timeout. When the timeout fires EndDialog is called with the
  /// result set to the dialog default button ID. You can get that ID by sending
  /// a dialog box a DM_GETDEFID message. Pretty simple.
  /// <br/>
  /// This implementation is based on the work of RodgerB that has been
  /// published on <a href="www.codeproject.com">Code Project</a>.
  /// </remarks>
  public static class TimeoutMessageBox
  {
    #region SHOW() FUNCTIONS
    /// <summary>
    /// Displays a message box with specified text.
    /// </summary>
    /// <param name="text">The text to display in the message box.</param>
    /// <param name="timeout">timeout value in milliseconds.</param>
    /// <returns>One of the DialogResult values.</returns>
    public static DialogResult Show(string text, int timeout)
    {
      Init(string.Empty, timeout);
      return MessageBox.Show(text);
    } // Show()

    /// <summary>
    /// Displays a message box with specified text and caption.
    /// </summary>
    /// <param name="text">The text to display in the message box. </param>
    /// <param name="caption">The text to display in the title bar of the message box. </param>
    /// <param name="timeout">timeout value in milliseconds.</param>
    /// <returns>One of the DialogResult values.</returns>
    public static DialogResult Show(string text, string caption, int timeout)
    {
      Init(caption, timeout);
      return MessageBox.Show(text, caption);
    } // Show()

    /// <summary>
    /// Displays a message box with specified text, caption, and buttons.
    /// </summary>
    /// <param name="text">The text to display in the message box. </param>
    /// <param name="caption">The text to display in the title bar of the message box. </param>
    /// <param name="buttons">One of the MessageBoxButtons that specifies which buttons to display in the message box.</param>
    /// <param name="timeout">timeout value in milliseconds.</param>
    /// <returns>One of the DialogResult values.</returns>
    public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, int timeout)
    {
      Init(caption, timeout);
      return MessageBox.Show(text, caption, buttons);
    } // Show()

    /// <summary>
    /// Displays a message box with specified text, caption, buttons, and icon.
    /// </summary>
    /// <param name="text">The text to display in the message box. </param>
    /// <param name="caption">The text to display in the title bar of the message box. </param>
    /// <param name="buttons">One of the MessageBoxButtons that specifies which buttons to display in the message box.</param>
    /// <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the message box. </param>
    /// <param name="timeout">timeout value in milliseconds.</param>
    /// <returns>One of the DialogResult values.</returns>
    public static DialogResult Show(
        string text,
        string caption,
        MessageBoxButtons buttons,
        MessageBoxIcon icon,
        int timeout)
    {
      Init(caption, timeout);
      return MessageBox.Show(text, caption, buttons, icon);
    } // Show()

    /// <summary>
    /// Displays a message box with the specified text, caption, buttons,
    /// icon, and default button.
    /// </summary>
    /// <param name="text">The text to display in the message box. </param>
    /// <param name="caption">The text to display in the title bar of the message box. </param>
    /// <param name="buttons">One of the MessageBoxButtons that specifies which buttons to display in the message box.</param>
    /// <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the message box.</param>
    /// <param name="defButton">One for the MessageBoxDefaultButton values which specifies which is the default button for the message box.</param>
    /// <param name="timeout">timeout value in milliseconds.</param>
    /// <returns>One of the DialogResult values.</returns>
    public static DialogResult Show(
        string text,
        string caption,
        MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defButton,
        int timeout)
    {
      Init(caption, timeout);
      return MessageBox.Show(text, caption, buttons, icon, defButton);
    } // Show()

    /// <summary>
    /// Displays a message box with the specified text, caption, buttons,
    /// icon, and default button.
    /// </summary>
    /// <param name="text">The text to display in the message box. </param>
    /// <param name="caption">The text to display in the title bar of the message box. </param>
    /// <param name="buttons">One of the MessageBoxButtons that specifies which buttons to display in the message box.</param>
    /// <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the message box.</param>
    /// <param name="defButton">One for the MessageBoxDefaultButton values which specifies which is the default button for the message box.</param>
    /// <param name="options">Message box Options.</param>
    /// <param name="timeout">timeout value in milliseconds.</param>
    /// <returns>One of the DialogResult values.</returns>
    public static DialogResult Show(
        string text,
        string caption,
        MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defButton,
        MessageBoxOptions options,
        int timeout)
    {
      Init(caption, timeout);
      return MessageBox.Show(text, caption, buttons, icon, defButton, options);
    } // Show()

    /// <summary>
    /// Displays a message box with specified text.
    /// </summary>
    /// <param name="owner">Window parent (owner).</param>
    /// <param name="text">The text to display in the message box.</param>
    /// <param name="timeout">timeout value in milliseconds.</param>
    /// <returns>One of the DialogResult values.</returns>
    public static DialogResult Show(IWin32Window owner, string text, int timeout)
    {
      Init(string.Empty, timeout);
      return MessageBox.Show(owner, text);
    } // Show()

    /// <summary>
    /// Displays a message box with specified text and caption.
    /// </summary>
    /// <param name="owner">Window parent (owner).</param>
    /// <param name="text">The text to display in the message box. </param>
    /// <param name="caption">The text to display in the title bar of the message box. </param>
    /// <param name="timeout">timeout value in milliseconds.</param>
    /// <returns>One of the DialogResult values.</returns>
    public static DialogResult Show(IWin32Window owner, string text, string caption, int timeout)
    {
      Init(caption, timeout);
      return MessageBox.Show(owner, text, caption);
    } // Show()

    /// <summary>
    /// Displays a message box with specified text, caption, and buttons.
    /// </summary>
    /// <param name="owner">Window parent (owner).</param>
    /// <param name="text">The text to display in the message box. </param>
    /// <param name="caption">The text to display in the title bar of the message box. </param>
    /// <param name="buttons">One of the MessageBoxButtons that specifies which buttons to display in the message box.</param>
    /// <param name="timeout">timeout value in milliseconds.</param>
    /// <returns>One of the DialogResult values.</returns>
    public static DialogResult Show(
        IWin32Window owner,
        string text,
        string caption,
        MessageBoxButtons buttons,
        int timeout)
    {
      Init(caption, timeout);
      return MessageBox.Show(owner, text, caption, buttons);
    } // Show()

    /// <summary>
    /// Displays a message box with specified text, caption, buttons, and icon.
    /// </summary>
    /// <param name="owner">Window parent (owner).</param>
    /// <param name="text">The text to display in the message box. </param>
    /// <param name="caption">The text to display in the title bar of the message box. </param>
    /// <param name="buttons">One of the MessageBoxButtons that specifies which buttons to display in the message box.</param>
    /// <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the message box. </param>
    /// <param name="timeout">timeout value in milliseconds.</param>
    /// <returns>One of the DialogResult values.</returns>
    public static DialogResult Show(
        IWin32Window owner,
        string text,
        string caption,
        MessageBoxButtons buttons,
        MessageBoxIcon icon,
        int timeout)
    {
      Init(caption, timeout);
      return MessageBox.Show(owner, text, caption, buttons, icon);
    } // Show()

    /// <summary>
    /// Displays a message box with the specified text, caption, buttons,
    /// icon, and default button.
    /// </summary>
    /// <param name="owner">Window parent (owner).</param>
    /// <param name="text">The text to display in the message box. </param>
    /// <param name="caption">The text to display in the title bar of the message box. </param>
    /// <param name="buttons">One of the MessageBoxButtons that specifies which buttons to display in the message box.</param>
    /// <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the message box.</param>
    /// <param name="defButton">One for the MessageBoxDefaultButton values which specifies which is the default button for the message box.</param>
    /// <param name="timeout">timeout value in milliseconds.</param>
    /// <returns>One of the DialogResult values.</returns>
    public static DialogResult Show(
        IWin32Window owner,
        string text,
        string caption,
        MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defButton,
        int timeout)
    {
      Init(caption, timeout);
      return MessageBox.Show(owner, text, caption, buttons, icon, defButton);
    } // Show()

    /// <summary>
    /// Displays a message box with the specified text, caption, buttons,
    /// icon, and default button.
    /// </summary>
    /// <param name="owner">Window parent (owner).</param>
    /// <param name="text">The text to display in the message box. </param>
    /// <param name="caption">The text to display in the title bar of the message box. </param>
    /// <param name="buttons">One of the MessageBoxButtons that specifies which buttons to display in the message box.</param>
    /// <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the message box.</param>
    /// <param name="defButton">One for the MessageBoxDefaultButton values which specifies which is the default button for the message box.</param>
    /// <param name="options">Message box Options.</param>
    /// <param name="timeout">timeout value in milliseconds.</param>
    /// <returns>One of the DialogResult values.</returns>
    public static DialogResult Show(
        IWin32Window owner,
        string text,
        string caption,
        MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defButton,
        MessageBoxOptions options,
        int timeout)
    {
      Init(caption, timeout);
      return MessageBox.Show(owner, text, caption, buttons, icon, defButton, options);
    } // Show()
    #endregion // SHOW() FUNCTIONS

    //// --------------------------------------------------------------------

    #region PRIVATE PROPERTIES
    /// <summary>
    /// The user message id.
    /// </summary>
    // ReSharper disable InconsistentNaming
    [SuppressMessage(
        "StyleCop.CSharp.NamingRules",
        "SA1310:FieldNamesMustNotContainUnderscore",
        Justification = "Reviewed. Suppression is OK here.")]
    private const int DM_GETDEFID = (int)Msg.WM_USER + 0;
// ReSharper restore InconsistentNaming

    /// <summary>
    /// Timer Id.
    /// </summary>
    private const int TimerId = 42;

    /// <summary>
    /// Hook 1.
    /// </summary>
    private static readonly Win32Api.HookProc HookProc = MessageBoxHookProc;

    /// <summary>
    /// Hook 2.
    /// </summary>
    private static readonly Win32Api.TimerProc HookTimer = MessageBoxTimerProc;

    /// <summary>
    /// Hook timeout.
    /// </summary>
    private static uint hookTimeout;

    /// <summary>
    /// Hook caption.
    /// </summary>
    private static string hookCaption;

    /// <summary>
    /// Hook handle.
    /// </summary>
    private static IntPtr handleHook = IntPtr.Zero;
    #endregion // PRIVATE PROPERTIES

    //// --------------------------------------------------------------------

    #region CONSTRUCTION
    /// <summary>
    /// Initialize hook management.
    /// </summary>
    /// <param name="caption">The caption.</param>
    /// <param name="timeout">The timeout.</param>
    /// <exception cref="System.NotSupportedException">multiple calls are not supported.</exception>
    private static void Init(string caption, int timeout)
    {
      if (handleHook != IntPtr.Zero)
      {
        // prohibit reentrancy
        throw new NotSupportedException("multiple calls are not supported");
      } // if

      // create hook
      hookTimeout = (uint)timeout;
      hookCaption = caption ?? string.Empty;
      handleHook = Win32Api.SetWindowsHookEx(
          (int)WindowsHookCodes.WH_CALLWNDPROCRET,
          HookProc,
          IntPtr.Zero,
          Thread.CurrentThread.ManagedThreadId);
    } // Init()
    #endregion // CONSTRUCTION

    //// --------------------------------------------------------------------

    #region HOOK & TIMER MANAGEMENT
    /// <summary>
    /// This is the function called by the Windows hook management.
    /// We assume, that when an WM_INITDIALOG message is sent and
    /// the window text is the same like the one of our window that
    /// the window to hook call comes from is indeed our window.
    /// We start the timer and unhook ourselves.
    /// </summary>
    /// <param name="nCode">The n code.</param>
    /// <param name="wParam">The w parameter.</param>
    /// <param name="lParam">The l parameter.</param>
    /// <returns>A handle.</returns>
    private static IntPtr MessageBoxHookProc(int nCode, IntPtr wParam, IntPtr lParam)
    {
      if (nCode < 0)
      {
        return Win32Api.CallNextHookEx(handleHook, nCode, wParam, lParam);
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

          // set timer
          Win32Api.SetTimer(msg.hwnd, (UIntPtr)TimerId, hookTimeout, HookTimer);

          // unhook
          Win32Api.UnhookWindowsHookEx(handleHook);
          handleHook = IntPtr.Zero;
        } // if
      } // if

      // default: call next hook
      return Win32Api.CallNextHookEx(hook, nCode, wParam, lParam);
    } // MessageBoxHookProc()

    /// <summary>
    /// This function is called when the timeout is reached.
    /// Then we close the dialog.
    /// </summary>
    /// <param name="hWnd">The h WND.</param>
    /// <param name="uMsg">The u MSG.</param>
    /// <param name="idEvent">The n ID event.</param>
    /// <param name="time">The dw time.</param>
    private static void MessageBoxTimerProc(IntPtr hWnd, uint uMsg, UIntPtr idEvent, uint time)
    {
      if (idEvent == (UIntPtr)TimerId)
      {
        // get dialog default button ID
        short dw = (short)Win32Api.SendMessage(hWnd, DM_GETDEFID, 0, 0);

        // end dialog with default button ID
        var result = Win32Api.EndDialog(hWnd, (IntPtr)dw);
        Debug.Assert(result != 0, "EndDialog reports error!");
      } // if
    } // MessageBoxTimerProc()
    #endregion // HOOK & TIMER MANAGEMENT
  } // TimeoutMessageBox
} // Tethys.Forms

// =========================================
// Tethys.Forms: end of TimeoutMessageBox.cs
// =========================================
