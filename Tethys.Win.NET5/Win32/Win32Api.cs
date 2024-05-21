// ---------------------------------------------------------------------------
// <copyright file="Win32Api.cs" company="Tethys">
//   Copyright (C) 1998-2024 T. Graf
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
namespace Tethys.Win32
{
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.InteropServices;
    using System.Text;

#pragma warning disable 1591

    /// <summary>
    /// The class Win32 Api encapsulates native Win32 constants and functions.
    /// </summary>
    [GeneratedCode("Ignore this class in FxCop", "0.0")]
    public static class Win32Api
    {
        // Win32Api()

        #region MISC CONSTANTS
        /// <summary>
        /// Scroll bar constant.
        /// </summary>
        public const int SB_VERT = 1;
        /// <summary>
        /// Win32 API message to set scroll bar position.
        /// </summary>
        public const int EM_SETSCROLLPOS = 0x0400 + 222;
        #endregion // MISC CONSTANTS

        #region MESSAGEBOX FLAGS
        // ----- MessageBox Flags -----
        public const int MB_OK = 0x00000000;
        public const int MB_OKCANCEL = 0x00000001;
        public const int MB_ABORTRETRYIGNORE = 0x00000002;
        public const int MB_YESNOCANCEL = 0x00000003;
        public const int MB_YESNO = 0x00000004;
        public const int MB_RETRYCANCEL = 0x00000005;
        public const int MB_ICONHAND = 0x00000010;
        public const int MB_ICONQUESTION = 0x00000020;
        public const int MB_ICONEXCLAMATION = 0x00000030;
        public const int MB_ICONASTERISK = 0x00000040;

        public const int MB_APPLMODAL = 0x00000000;
        public const int MB_SYSTEMMODAL = 0x00001000;
        public const int MB_TASKMODAL = 0x00002000;

        public const int MB_SETFOREGROUND = 0x00010000;
        public const int MB_TOPMOST = 0x00040000;
        public const int MB_HELP = 0x00004000;

        public const int MB_DEFBUTTON1 = 0x00000000;
        public const int MB_DEFBUTTON2 = 0x00000100;
        public const int MB_DEFBUTTON3 = 0x00000200;
        public const int MB_DEFBUTTON4 = 0x00000300;

        // Dialog Box Command IDs
        public const int IDOK = 1;
        public const int IDCANCEL = 2;
        public const int IDABORT = 3;
        public const int IDRETRY = 4;
        public const int IDIGNORE = 5;
        public const int IDYES = 6;
        public const int IDNO = 7;
        public const int IDCLOSE = 8;
        public const int IDHELP = 9;
        #endregion // MESSAGEBOX FLAGS

        #region WINDOWS MESSAGES
        // ----- Windows Messages -----
        public const int WM_CHAR = 0x0102;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int WM_NCRBUTTONDOWN = 0x00A4;
        public const int WM_NCMBUTTONDOWN = 0x00A7;
        #endregion // WINDOWS MESSAGES

        #region WINDOW STYLES
        public const int WS_OVERLAPPED = 0x00000000;
        public const uint WS_POPUP = 0x80000000;
        public const int WS_CHILD = 0x40000000;
        public const int WS_MINIMIZE = 0x20000000;
        public const int WS_VISIBLE = 0x10000000;
        public const int WS_DISABLED = 0x08000000;
        public const int WS_CLIPSIBLINGS = 0x04000000;
        public const int WS_CLIPCHILDREN = 0x02000000;
        public const int WS_MAXIMIZE = 0x01000000;
        public const int WS_CAPTION = 0x00C00000;
        public const int WS_BORDER = 0x00800000;
        public const int WS_DLGFRAME = 0x00400000;
        public const int WS_VSCROLL = 0x00200000;
        public const int WS_HSCROLL = 0x00100000;
        public const int WS_SYSMENU = 0x00080000;
        public const int WS_THICKFRAME = 0x00040000;
        public const int WS_GROUP = 0x00020000;
        public const int WS_TABSTOP = 0x00010000;

        public const int WS_MINIMIZEBOX = 0x00020000;
        public const int WS_MAXIMIZEBOX = 0x00010000;
        #endregion // WINDOW STYLES

        #region SHFILEOPERATION CONSTANTS
        // SHFileOperation operations
        public const int FO_MOVE = 0x0001;
        public const int FO_COPY = 0x0002;
        public const int FO_DELETE = 0x0003;
        public const int FO_RENAME = 0x0004;

        // SHFileOperation flags

        /// <summary>
        /// The pTo member specifies multiple destination files (one for each source file) rather than one directory where all source files are to be deposited.
        /// </summary>
        public const int FOF_MULTIDESTFILES = 0x0001;

        /// <summary>
        /// Not used.
        /// </summary>
        public const int FOF_CONFIRMMOUSE = 0x0002;

        /// <summary>
        /// Do not display a progress dialog box.
        /// </summary>
        public const int FOF_SILENT = 0x0004;

        /// <summary>
        /// Give the file being operated on a new name in a move, copy, or rename operation if a file with the target name already exists.
        /// </summary>
        public const int FOF_RENAMEONCOLLISION = 0x0008;

        /// <summary>
        /// Respond with "Yes to All" for any dialog box that is displayed.
        /// </summary>
        public const int FOF_NOCONFIRMATION = 0x0010;

        /// <summary>
        /// If FOF_RENAMEONCOLLISION is specified and any files were renamed, assign a name mapping object containing their old and new names to the hNameMappings member.
        /// </summary>
        public const int FOF_WANTMAPPINGHANDLE = 0x0020;

        /// <summary>
        /// Preserve undo information, if possible. Operations can be undone only from the same process that performed the original operation. If pFrom does not contain fully qualified path and file names, this flag is ignored.
        /// </summary>
        public const int FOF_ALLOWUNDO = 0x0040;

        /// <summary>
        /// Perform the operation on files only if a wildcard file name (*.*) is specified.
        /// </summary>
        public const int FOF_FILESONLY = 0x0080;

        /// <summary>
        /// Display a progress dialog box but do not show the file names.
        /// </summary>
        public const int FOF_SIMPLEPROGRESS = 0x0100;

        /// <summary>
        /// Do not confirm the creation of a new directory if the operation requires one to be created.
        /// </summary>
        public const int FOF_NOCONFIRMMKDIR = 0x0200;

        /// <summary>
        /// Do not display a user interface if an error occurs.
        /// </summary>
        public const int FOF_NOERRORUI = 0x0400;

        /// <summary>
        /// Version 4.71. Do not copy the security attributes of the file.
        /// </summary>
        public const int FOF_NOCOPYSECURITYATTRIBS = 0x0800;

        #endregion SHFILEOPERATION CONSTANTS

        //// ------------------------------------------------------------------

        #region WIN32 API FUNCTIONS

        #region CONSTANTS
        public const string TOOLBARCLASSNAME = "ToolbarWindow32";
        public const string REBARCLASSNAME = "ReBarWindow32";
        public const string PROGRESSBARCLASSNAME = "msctls_progress32";
        #endregion // CONSTANTS

        #region CALLBACKS
        /// <summary>
        /// Hook callback delegate.
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// Time callback delegate.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="uMsg"></param>
        /// <param name="nIDEvent"></param>
        /// <param name="dwTime"></param>
        public delegate void TimerProc(IntPtr hWnd, uint uMsg, UIntPtr nIDEvent, uint dwTime);
        #endregion // CALLBACKS

        #region KERNEL32.DLL FUNCTIONS
        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetCurrentThreadId();
        #endregion // KERNEL32.DLL FUNCTIONS

        #region GDI32.DLL FUNCTIONS
        [DllImport("gdi32.dll")]
        static public extern bool StretchBlt(IntPtr hDCDest, int XOriginDest, int YOriginDest, int WidthDest, int HeightDest,
          IntPtr hDCSrc, int XOriginScr, int YOriginSrc, int WidthScr, int HeightScr, uint Rop);
        [DllImport("gdi32.dll")]
        static public extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        static public extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int Width, int Height);
        [DllImport("gdi32.dll")]
        static public extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        [DllImport("gdi32.dll")]
        static public extern bool BitBlt(IntPtr hDCDest, int XOriginDest, int YOriginDest, int WidthDest, int HeightDest,
          IntPtr hDCSrc, int XOriginScr, int YOriginSrc, uint Rop);
        [DllImport("gdi32.dll")]
        static public extern IntPtr DeleteDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        static public extern bool PatBlt(IntPtr hDC, int XLeft, int YLeft, int Width, int Height, uint Rop);
        [DllImport("gdi32.dll")]
        static public extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll")]
        static public extern uint GetPixel(IntPtr hDC, int XPos, int YPos);
        [DllImport("gdi32.dll")]
        static public extern int SetMapMode(IntPtr hDC, int fnMapMode);
        [DllImport("gdi32.dll")]
        static public extern int GetObjectType(IntPtr handle);
        [DllImport("gdi32")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO_FLAT bmi,
          int iUsage, ref int ppvBits, IntPtr hSection, int dwOffset);
        [DllImport("gdi32")]
        public static extern int GetDIBits(IntPtr hDC, IntPtr hbm, int StartScan, int ScanLines, int lpBits, BITMAPINFOHEADER bmi, int usage);
        [DllImport("gdi32")]
        public static extern int GetDIBits(IntPtr hdc, IntPtr hbm, int StartScan, int ScanLines, int lpBits, ref BITMAPINFO_FLAT bmi, int usage);
        [DllImport("gdi32")]
        public static extern IntPtr GetPaletteEntries(IntPtr hpal, int iStartIndex, int nEntries, byte[] lppe);
        [DllImport("gdi32")]
        public static extern IntPtr GetSystemPaletteEntries(IntPtr hdc, int iStartIndex, int nEntries, byte[] lppe);
        [DllImport("gdi32")]
        public static extern uint SetDCBrushColor(IntPtr hdc, uint crColor);
        [DllImport("gdi32")]
        public static extern IntPtr CreateSolidBrush(uint crColor);
        [DllImport("gdi32")]
        public static extern int SetBkMode(IntPtr hDC, BackgroundMode mode);
        #endregion // GDI32.DLL FUNCTIONS

        #region USER32.DLL FUNCTIONS
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool ShowWindow(IntPtr hWnd, short State);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool UpdateWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, uint flags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool CloseClipboard();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool EmptyClipboard();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr SetClipboardData(uint Format, IntPtr hData);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool GetMenuItemRect(IntPtr hWnd, IntPtr hMenu, uint Item, ref RECT rc);
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
        //[DllImport("user32.dll", CharSet=CharSet.Auto)]
        //public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref RECT lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref RECT lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref POINT lParam);
        /// <summary>
        /// Win32 API SendMessage function.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, POINT lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TBBUTTON lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TBBUTTONINFO lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref REBARBANDINFO lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TVITEM lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref LVITEM lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref HDITEM lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref HD_HITTESTINFO hti);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowsHookEx(int hookid, HookProc pfnhook, IntPtr hinst, int threadid);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhook, int code, IntPtr wparam, IntPtr lparam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetFocus(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int DrawText(IntPtr hdc, string lpString, int nCount, ref RECT lpRect, int uFormat);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SetParent(IntPtr hChild, IntPtr hParent);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr GetDlgItem(IntPtr hDlg, int nControlID);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int GetClientRect(IntPtr hWnd, ref RECT rc);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int InvalidateRect(IntPtr hWnd, IntPtr rect, int bErase);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool WaitMessage();
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool TranslateMessage(ref MSG msg);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool DispatchMessage(ref MSG msg);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetCursor(IntPtr hCursor);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetFocus();
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT pt);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern ushort GetKeyState(int virtKey);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, out STRINGBUFFER ClassName, int nMaxCount);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hRegion, uint flags);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        /// <summary>
        /// The MessageBeep function plays a waveform sound. The waveform
        /// sound for each sound type is identified by an entry in the
        /// registry.
        /// </summary>
        /// <param name="type">
        /// Sound type, as identified by an entry in the registry.
        /// This parameter can be one of the following values.<br/>
        /// <table>
        /// <tr>
        /// <td>Value</td><td>Sound</td>
        /// </tr>
        /// <tr>
        /// <td>-1</td>
        /// <td>Simple beep. If the sound card is not available, the sound is generated using the speaker.</td>
        /// </tr>
        /// <tr>
        /// <td>MB_ICONASTERISK</td>
        /// <td>SystemAsterisk</td>
        /// </tr>
        /// <tr>
        /// <td>MB_ICONEXCLAMATION</td>
        /// <td>SystemExclamation</td>
        /// </tr>
        /// <tr>
        /// <td>MB_ICONHAND</td>
        /// <td>SystemHand</td>
        /// </tr>
        /// <tr>
        /// <td>MB_ICONQUESTION</td>
        /// <td>SystemQuestion</td>
        /// </tr>
        /// <tr>
        /// <td>MB_OK</td>
        /// <td>SystemDefault</td>
        /// </tr>
        /// </table>
        /// </param>
        [DllImport("user32.dll")]
        public static extern int MessageBeep(int type);
        /// <summary>
        /// The MessageBox function creates, displays, and operates a message box.
        /// The message box contains an application-defined message and title,
        /// plus any combination of predefined icons and push buttons.
        /// <br/>
        /// See SKD Documentation for more information.
        /// </summary>
        /// <param name="hWndParent">handle to owner window</param>
        /// <param name="text">text in message box</param>
        /// <param name="caption">message box title</param>
        /// <param name="type">message box style</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWndParent,
          string text, string caption, int type);
        /// <summary>
        /// The CreateWindowEx function creates an overlapped, pop-up, or child
        /// window with an extended window style; otherwise, this function is
        /// identical to the CreateWindow function. For more information about
        /// creating a window and for full descriptions of the other parameters
        /// see the SDk documentation.
        /// </summary>
        /// <param name="dwExStyle">extended window style</param>
        /// <param name="lpClassName">registered class name</param>
        /// <param name="lpWindowName">window name</param>
        /// <param name="dwStyle">window style</param>
        /// <param name="x">horizontal position of window</param>
        /// <param name="y">vertical position of window</param>
        /// <param name="nWidth">window width</param>
        /// <param name="nHeight">window height</param>
        /// <param name="hWndParent">handle to parent or owner window</param>
        /// <param name="hMenu">menu handle or child identifier</param>
        /// <param name="hInstance">handle to application instance</param>
        /// <param name="lpParam">window-creation data</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr CreateWindowEx(uint dwExStyle,
          string lpClassName, string lpWindowName, uint dwStyle,
          int x, int y, int nWidth, int nHeight, IntPtr hWndParent,
          IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
        /// <summary>
        /// Gets the scroll range of the given window.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nBar"></param>
        /// <param name="lpMinPos"></param>
        /// <param name="lpMaxPos"></param>
        /// <returns></returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool GetScrollRange(IntPtr hWnd, int nBar,
          out int lpMinPos, out int lpMaxPos);

        [DllImport("User32.dll")]
        public static extern UIntPtr SetTimer(IntPtr hWnd, UIntPtr nIDEvent,
          uint uElapse, TimerProc lpTimerFunc);
        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxLength);
        [DllImport("user32.dll")]
        public static extern int EndDialog(IntPtr hDlg, IntPtr nResult);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void CreateCaret(IntPtr hwnd, System.Drawing.Bitmap bmp,
          int nWidth, int nHeight);
        [DllImport("user32.dll")]
        public static extern int CreateCaret(IntPtr hwnd, IntPtr hbm,
          int cx, int cy);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void CreateCaret(IntPtr hwnd, int dummy,
          int nWidth, int nHeight);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool DestroyCaret();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowCaret(IntPtr hwnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool HideCaret(IntPtr hwnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetCaretPos(int x, int y);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCaretPos(ref int pos);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetCaretBlinkTime(int nMSeconds);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetCaretBlinkTime();

        #endregion // USER32.DLL FUNCTIONS

        #region COMMON CONTROLS FUNCTIONS
        [DllImport("comctl32.dll")]
        public static extern bool InitCommonControlsEx(INITCOMMONCONTROLSEX icc);
        [DllImport("comctl32.dll", EntryPoint = "DllGetVersion")]
        public extern static int GetCommonControlDLLVersion(ref DLLVERSIONINFO dvi);
        #endregion // COMMON CONTROLS FUNCTIONS

        #region SHELL32.DLL FUNCTIONS
        /// <summary>
        /// Copies, moves, renames, or deletes a file system object.
        /// </summary>
        /// <param name="lpFileOperationData">
        /// [in] Pointer to an SHFILEOPSTRUCT structure that contains information
        /// this function needs to carry out the specified operation. This
        /// parameter must contain a valid value that is not NULL. You are
        /// responsible for validating the value. If you do not validate it,
        /// you will experience unexpected results.
        /// </param>
        /// <returns>
        /// Returns zero if successful, or nonzero otherwise.
        /// </returns>
        [DllImport("shell32.Dll", CharSet = CharSet.Auto)]
        public static extern Int32 SHFileOperation(ref SHFILEOPSTRUCT lpFileOperationData);

        [DllImport("shell32.dll", EntryPoint = "ExtractIconA",
         CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr ExtractIcon
          (int hInst, string lpszExeFileName, int nIconIndex);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern int ExtractIconEx(string stExeFileName,
          int nIconIndex, ref IntPtr phiconLarge, ref IntPtr phiconSmall, int nIcons);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static bool DestroyIcon(IntPtr handle);

        [DllImport("shfolder.dll", CharSet = CharSet.Auto)]
        internal static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder,
          IntPtr hToken, int dwFlags, StringBuilder lpszPath);
        #endregion // SHELL32.DLL FUNCTIONS

        #endregion // WIN32 API FUNCTIONS

#pragma warning restore 1591
    } // Win32Api
} // Tethys

// ==========================
// Tethys: end of win32api.cs
// ==========================