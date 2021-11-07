// ---------------------------------------------------------------------------
// <copyright file="Enums.cs" company="Tethys">
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
namespace Tethys.Win32
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    // ReSharper disable IdentifierTypo
    #region
    /// <summary>
    /// Peek Message Flags.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum PeekMessageFlags
    {
        /// <summary>
        /// No remove flag.
        /// </summary>
        // ReSharper disable InconsistentNaming
        PM_NOREMOVE = 0,
        // ReSharper restore InconsistentNaming

        /// <summary>
        /// Remove flag,
        /// </summary>
        PM_REMOVE = 1,

        /// <summary>
        /// No yield flag
        /// </summary>
        PM_NOYIELD = 2,
    }
    #endregion

    #region
    /// <summary>
    /// Windows Messages.
    /// </summary>
#pragma warning disable 1591
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum Msg
    {
        // ReSharper disable InconsistentNaming
        WM_NULL = 0x0000,
        WM_CREATE = 0x0001,
        WM_DESTROY = 0x0002,
        WM_MOVE = 0x0003,
        WM_SIZE = 0x0005,
        WM_ACTIVATE = 0x0006,
        WM_SETFOCUS = 0x0007,
        WM_KILLFOCUS = 0x0008,
        WM_ENABLE = 0x000A,
        WM_SETREDRAW = 0x000B,
        WM_SETTEXT = 0x000C,
        WM_GETTEXT = 0x000D,
        WM_GETTEXTLENGTH = 0x000E,
        WM_PAINT = 0x000F,
        WM_CLOSE = 0x0010,
        WM_QUERYENDSESSION = 0x0011,
        WM_QUIT = 0x0012,
        WM_QUERYOPEN = 0x0013,
        WM_ERASEBKGND = 0x0014,
        WM_SYSCOLORCHANGE = 0x0015,
        WM_ENDSESSION = 0x0016,
        WM_SHOWWINDOW = 0x0018,
        WM_CTLCOLOR = 0x0019,
        WM_WININICHANGE = 0x001A,
        WM_SETTINGCHANGE = 0x001A,
        WM_DEVMODECHANGE = 0x001B,
        WM_ACTIVATEAPP = 0x001C,
        WM_FONTCHANGE = 0x001D,
        WM_TIMECHANGE = 0x001E,
        WM_CANCELMODE = 0x001F,
        WM_SETCURSOR = 0x0020,
        WM_MOUSEACTIVATE = 0x0021,
        WM_CHILDACTIVATE = 0x0022,
        WM_QUEUESYNC = 0x0023,
        WM_GETMINMAXINFO = 0x0024,
        WM_PAINTICON = 0x0026,
        WM_ICONERASEBKGND = 0x0027,
        WM_NEXTDLGCTL = 0x0028,
        WM_SPOOLERSTATUS = 0x002A,
        WM_DRAWITEM = 0x002B,
        WM_MEASUREITEM = 0x002C,
        WM_DELETEITEM = 0x002D,
        WM_VKEYTOITEM = 0x002E,
        WM_CHARTOITEM = 0x002F,
        WM_SETFONT = 0x0030,
        WM_GETFONT = 0x0031,
        WM_SETHOTKEY = 0x0032,
        WM_GETHOTKEY = 0x0033,
        WM_QUERYDRAGICON = 0x0037,
        WM_COMPAREITEM = 0x0039,
        WM_GETOBJECT = 0x003D,
        WM_COMPACTING = 0x0041,
        WM_COMMNOTIFY = 0x0044,
        WM_WINDOWPOSCHANGING = 0x0046,
        WM_WINDOWPOSCHANGED = 0x0047,
        WM_POWER = 0x0048,
        WM_COPYDATA = 0x004A,
        WM_CANCELJOURNAL = 0x004B,
        WM_NOTIFY = 0x004E,
        WM_INPUTLANGCHANGEREQUEST = 0x0050,
        WM_INPUTLANGCHANGE = 0x0051,
        WM_TCARD = 0x0052,
        WM_HELP = 0x0053,
        WM_USERCHANGED = 0x0054,
        WM_NOTIFYFORMAT = 0x0055,
        WM_CONTEXTMENU = 0x007B,
        WM_STYLECHANGING = 0x007C,
        WM_STYLECHANGED = 0x007D,
        WM_DISPLAYCHANGE = 0x007E,
        WM_GETICON = 0x007F,
        WM_SETICON = 0x0080,
        WM_NCCREATE = 0x0081,
        WM_NCDESTROY = 0x0082,
        WM_NCCALCSIZE = 0x0083,
        WM_NCHITTEST = 0x0084,
        WM_NCPAINT = 0x0085,
        WM_NCACTIVATE = 0x0086,
        WM_GETDLGCODE = 0x0087,
        WM_SYNCPAINT = 0x0088,
        WM_NCMOUSEMOVE = 0x00A0,
        WM_NCLBUTTONDOWN = 0x00A1,
        WM_NCLBUTTONUP = 0x00A2,
        WM_NCLBUTTONDBLCLK = 0x00A3,
        WM_NCRBUTTONDOWN = 0x00A4,
        WM_NCRBUTTONUP = 0x00A5,
        WM_NCRBUTTONDBLCLK = 0x00A6,
        WM_NCMBUTTONDOWN = 0x00A7,
        WM_NCMBUTTONUP = 0x00A8,
        WM_NCMBUTTONDBLCLK = 0x00A9,
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101,
        WM_CHAR = 0x0102,
        WM_DEADCHAR = 0x0103,
        WM_SYSKEYDOWN = 0x0104,
        WM_SYSKEYUP = 0x0105,
        WM_SYSCHAR = 0x0106,
        WM_SYSDEADCHAR = 0x0107,
        WM_KEYLAST = 0x0108,
        WM_IME_STARTCOMPOSITION = 0x010D,
        WM_IME_ENDCOMPOSITION = 0x010E,
        WM_IME_COMPOSITION = 0x010F,
        WM_IME_KEYLAST = 0x010F,
        WM_INITDIALOG = 0x0110,
        WM_COMMAND = 0x0111,
        WM_SYSCOMMAND = 0x0112,
        WM_TIMER = 0x0113,
        WM_HSCROLL = 0x0114,
        WM_VSCROLL = 0x0115,
        WM_INITMENU = 0x0116,
        WM_INITMENUPOPUP = 0x0117,
        WM_MENUSELECT = 0x011F,
        WM_MENUCHAR = 0x0120,
        WM_ENTERIDLE = 0x0121,
        WM_MENURBUTTONUP = 0x0122,
        WM_MENUDRAG = 0x0123,
        WM_MENUGETOBJECT = 0x0124,
        WM_UNINITMENUPOPUP = 0x0125,
        WM_MENUCOMMAND = 0x0126,
        WM_CTLCOLORMSGBOX = 0x0132,
        WM_CTLCOLOREDIT = 0x0133,
        WM_CTLCOLORLISTBOX = 0x0134,
        WM_CTLCOLORBTN = 0x0135,
        WM_CTLCOLORDLG = 0x0136,
        WM_CTLCOLORSCROLLBAR = 0x0137,
        WM_CTLCOLORSTATIC = 0x0138,
        WM_MOUSEMOVE = 0x0200,
        WM_LBUTTONDOWN = 0x0201,
        WM_LBUTTONUP = 0x0202,
        WM_LBUTTONDBLCLK = 0x0203,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205,
        WM_RBUTTONDBLCLK = 0x0206,
        WM_MBUTTONDOWN = 0x0207,
        WM_MBUTTONUP = 0x0208,
        WM_MBUTTONDBLCLK = 0x0209,
        WM_MOUSEWHEEL = 0x020A,
        WM_PARENTNOTIFY = 0x0210,
        WM_ENTERMENULOOP = 0x0211,
        WM_EXITMENULOOP = 0x0212,
        WM_NEXTMENU = 0x0213,
        WM_SIZING = 0x0214,
        WM_CAPTURECHANGED = 0x0215,
        WM_MOVING = 0x0216,
        WM_DEVICECHANGE = 0x0219,
        WM_MDICREATE = 0x0220,
        WM_MDIDESTROY = 0x0221,
        WM_MDIACTIVATE = 0x0222,
        WM_MDIRESTORE = 0x0223,
        WM_MDINEXT = 0x0224,
        WM_MDIMAXIMIZE = 0x0225,
        WM_MDITILE = 0x0226,
        WM_MDICASCADE = 0x0227,
        WM_MDIICONARRANGE = 0x0228,
        WM_MDIGETACTIVE = 0x0229,
        WM_MDISETMENU = 0x0230,
        WM_ENTERSIZEMOVE = 0x0231,
        WM_EXITSIZEMOVE = 0x0232,
        WM_DROPFILES = 0x0233,
        WM_MDIREFRESHMENU = 0x0234,
        WM_IME_SETCONTEXT = 0x0281,
        WM_IME_NOTIFY = 0x0282,
        WM_IME_CONTROL = 0x0283,
        WM_IME_COMPOSITIONFULL = 0x0284,
        WM_IME_SELECT = 0x0285,
        WM_IME_CHAR = 0x0286,
        WM_IME_REQUEST = 0x0288,
        WM_IME_KEYDOWN = 0x0290,
        WM_IME_KEYUP = 0x0291,
        WM_MOUSEHOVER = 0x02A1,
        WM_MOUSELEAVE = 0x02A3,
        WM_CUT = 0x0300,
        WM_COPY = 0x0301,
        WM_PASTE = 0x0302,
        WM_CLEAR = 0x0303,
        WM_UNDO = 0x0304,
        WM_RENDERFORMAT = 0x0305,
        WM_RENDERALLFORMATS = 0x0306,
        WM_DESTROYCLIPBOARD = 0x0307,
        WM_DRAWCLIPBOARD = 0x0308,
        WM_PAINTCLIPBOARD = 0x0309,
        WM_VSCROLLCLIPBOARD = 0x030A,
        WM_SIZECLIPBOARD = 0x030B,
        WM_ASKCBFORMATNAME = 0x030C,
        WM_CHANGECBCHAIN = 0x030D,
        WM_HSCROLLCLIPBOARD = 0x030E,
        WM_QUERYNEWPALETTE = 0x030F,
        WM_PALETTEISCHANGING = 0x0310,
        WM_PALETTECHANGED = 0x0311,
        WM_HOTKEY = 0x0312,
        WM_PRINT = 0x0317,
        WM_PRINTCLIENT = 0x0318,
        WM_HANDHELDFIRST = 0x0358,
        WM_HANDHELDLAST = 0x035F,
        WM_AFXFIRST = 0x0360,
        WM_AFXLAST = 0x037F,
        WM_PENWINFIRST = 0x0380,
        WM_PENWINLAST = 0x038F,
        WM_APP = 0x8000,
        WM_USER = 0x0400,
        WM_REFLECT = WM_USER + 0x1c00,
        // ReSharper restore InconsistentNaming
    }
#pragma warning restore 1591
    #endregion

    #region Window Styles
    /// <summary>
    /// Window Styles.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
#pragma warning disable 1591
    public enum WindowStyles : uint
    {
        WS_OVERLAPPED = 0x00000000,
        WS_POPUP = 0x80000000,
        WS_CHILD = 0x40000000,
        WS_MINIMIZE = 0x20000000,
        WS_VISIBLE = 0x10000000,
        WS_DISABLED = 0x08000000,
        WS_CLIPSIBLINGS = 0x04000000,
        WS_CLIPCHILDREN = 0x02000000,
        WS_MAXIMIZE = 0x01000000,
        WS_CAPTION = 0x00C00000,
        WS_BORDER = 0x00800000,
        WS_DLGFRAME = 0x00400000,
        WS_VSCROLL = 0x00200000,
        WS_HSCROLL = 0x00100000,
        WS_SYSMENU = 0x00080000,
        WS_THICKFRAME = 0x00040000,
        WS_GROUP = 0x00020000,
        WS_TABSTOP = 0x00010000,
        WS_MINIMIZEBOX = 0x00020000,
        WS_MAXIMIZEBOX = 0x00010000,
        WS_TILED = 0x00000000,
        WS_ICONIC = 0x20000000,
        WS_SIZEBOX = 0x00040000,
        WS_POPUPWINDOW = 0x80880000,
        WS_OVERLAPPEDWINDOW = 0x00CF0000,
        WS_TILEDWINDOW = 0x00CF0000,
        WS_CHILDWINDOW = 0x40000000,
#pragma warning restore 1591
    }
    #endregion

    #region Window Extended Styles
    /// <summary>
    /// Window Extended Styles.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum WindowExStyles
    {
#pragma warning disable 1591
        WS_EX_DLGMODALFRAME = 0x00000001,
        WS_EX_NOPARENTNOTIFY = 0x00000004,
        WS_EX_TOPMOST = 0x00000008,
        WS_EX_ACCEPTFILES = 0x00000010,
        WS_EX_TRANSPARENT = 0x00000020,
        WS_EX_MDICHILD = 0x00000040,
        WS_EX_TOOLWINDOW = 0x00000080,
        WS_EX_WINDOWEDGE = 0x00000100,
        WS_EX_CLIENTEDGE = 0x00000200,
        WS_EX_CONTEXTHELP = 0x00000400,
        WS_EX_RIGHT = 0x00001000,
        WS_EX_LEFT = 0x00000000,
        WS_EX_RTLREADING = 0x00002000,
        WS_EX_LTRREADING = 0x00000000,
        WS_EX_LEFTSCROLLBAR = 0x00004000,
        WS_EX_RIGHTSCROLLBAR = 0x00000000,
        WS_EX_CONTROLPARENT = 0x00010000,
        WS_EX_STATICEDGE = 0x00020000,
        WS_EX_APPWINDOW = 0x00040000,
        WS_EX_OVERLAPPEDWINDOW = 0x00000300,
        WS_EX_PALETTEWINDOW = 0x00000188,
        WS_EX_LAYERED = 0x00080000,
#pragma warning restore 1591
    }
    #endregion

    #region
    /// <summary>
    /// ShowWindow Styles.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum ShowWindowStyles : short
    {
#pragma warning disable 1591
        SW_HIDE = 0,
        SW_SHOWNORMAL = 1,
        SW_NORMAL = 1,
        SW_SHOWMINIMIZED = 2,
        SW_SHOWMAXIMIZED = 3,
        SW_MAXIMIZE = 3,
        SW_SHOWNOACTIVATE = 4,
        SW_SHOW = 5,
        SW_MINIMIZE = 6,
        SW_SHOWMINNOACTIVE = 7,
        SW_SHOWNA = 8,
        SW_RESTORE = 9,
        SW_SHOWDEFAULT = 10,
        SW_FORCEMINIMIZE = 11,
        SW_MAX = 11,
#pragma warning restore 1591
    }
    #endregion

    #region SetWindowPos Z Order
    /// <summary>
    /// SetWindowPos Z Order.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum SetWindowPosZOrder
    {
#pragma warning disable 1591
        HWND_TOP = 0,
        HWND_BOTTOM = 1,
        HWND_TOPMOST = -1,
        HWND_NOTOPMOST = -2,
#pragma warning restore 1591
    }
    #endregion

    #region SetWindowPosFlags
    /// <summary>
    /// SetWindowPosFlags.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum SetWindowPosFlags : uint
    {
#pragma warning disable 1591
        SWP_NOSIZE = 0x0001,
        SWP_NOMOVE = 0x0002,
        SWP_NOZORDER = 0x0004,
        SWP_NOREDRAW = 0x0008,
        SWP_NOACTIVATE = 0x0010,
        SWP_FRAMECHANGED = 0x0020,
        SWP_SHOWWINDOW = 0x0040,
        SWP_HIDEWINDOW = 0x0080,
        SWP_NOCOPYBITS = 0x0100,
        SWP_NOOWNERZORDER = 0x0200,
        SWP_NOSENDCHANGING = 0x0400,
        SWP_DRAWFRAME = 0x0020,
        SWP_NOREPOSITION = 0x0200,
        SWP_DEFERERASE = 0x2000,
        SWP_ASYNCWINDOWPOS = 0x4000,
#pragma warning restore 1591
    }
    #endregion

    #region Virtual Keys
    /// <summary>
    /// Virtual Keys.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum VirtualKeys
    {
#pragma warning disable 1591
        VK_LBUTTON = 0x01,

        /// <summary>
        /// Ctrl+C character code.
        /// </summary>
        VK_CTRLC = 0x03,
        VK_CANCEL = 0x03,
        VK_BACK = 0x08,
        VK_TAB = 0x09,
        VK_CLEAR = 0x0C,
        VK_RETURN = 0x0D,
        VK_SHIFT = 0x10,
        VK_CONTROL = 0x11,
        VK_MENU = 0x12,
        VK_CAPITAL = 0x14,
        VK_CTRLV = 0x16,
        VK_CTRLX = 0x18,
        VK_ESCAPE = 0x1B,
        VK_SPACE = 0x20,
        VK_PRIOR = 0x21,
        VK_NEXT = 0x22,
        VK_END = 0x23,
        VK_HOME = 0x24,
        VK_LEFT = 0x25,
        VK_UP = 0x26,
        VK_RIGHT = 0x27,
        VK_DOWN = 0x28,
        VK_SELECT = 0x29,
        VK_EXECUTE = 0x2B,
        VK_SNAPSHOT = 0x2C,
        VK_INSERT = 0x2D,
        VK_DELETE = 0x2E,
        VK_HELP = 0x2F,
        VK_0 = 0x30,
        VK_1 = 0x31,
        VK_2 = 0x32,
        VK_3 = 0x33,
        VK_4 = 0x34,
        VK_5 = 0x35,
        VK_6 = 0x36,
        VK_7 = 0x37,
        VK_8 = 0x38,
        VK_9 = 0x39,
        VK_A = 0x41,
        VK_B = 0x42,
        VK_C = 0x43,
        VK_D = 0x44,
        VK_E = 0x45,
        VK_F = 0x46,
        VK_G = 0x47,
        VK_H = 0x48,
        VK_I = 0x49,
        VK_J = 0x4A,
        VK_K = 0x4B,
        VK_L = 0x4C,
        VK_M = 0x4D,
        VK_N = 0x4E,
        VK_O = 0x4F,
        VK_P = 0x50,
        VK_Q = 0x51,
        VK_R = 0x52,
        VK_S = 0x53,
        VK_T = 0x54,
        VK_U = 0x55,
        VK_V = 0x56,
        VK_W = 0x57,
        VK_X = 0x58,
        VK_Y = 0x59,
        VK_Z = 0x5A,
        VK_NUMPAD0 = 0x60,
        VK_NUMPAD1 = 0x61,
        VK_NUMPAD2 = 0x62,
        VK_NUMPAD3 = 0x63,
        VK_NUMPAD4 = 0x64,
        VK_NUMPAD5 = 0x65,
        VK_NUMPAD6 = 0x66,
        VK_NUMPAD7 = 0x67,
        VK_NUMPAD8 = 0x68,
        VK_NUMPAD9 = 0x69,
        VK_MULTIPLY = 0x6A,
        VK_ADD = 0x6B,
        VK_SEPARATOR = 0x6C,
        VK_SUBTRACT = 0x6D,
        VK_DECIMAL = 0x6E,
        VK_DIVIDE = 0x6F,
        VK_ATTN = 0xF6,
        VK_CRSEL = 0xF7,
        VK_EXSEL = 0xF8,
        VK_EREOF = 0xF9,
        VK_PLAY = 0xFA,
        VK_ZOOM = 0xFB,
        VK_NONAME = 0xFC,
        VK_PA1 = 0xFD,
        VK_OEM_CLEAR = 0xFE,
        VK_LWIN = 0x5B,
        VK_RWIN = 0x5C,
        VK_APPS = 0x5D,
        VK_LSHIFT = 0xA0,
        VK_RSHIFT = 0xA1,
        VK_LCONTROL = 0xA2,
        VK_RCONTROL = 0xA3,
        VK_LMENU = 0xA4,
        VK_RMENU = 0xA5,
#pragma warning restore 1591
    }
    #endregion

    #region PatBlt Types
    /// <summary>
    /// PatBlt Types.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum PatBltTypes
    {
#pragma warning disable 1591
        SRCCOPY = 0x00CC0020,
        SRCPAINT = 0x00EE0086,
        SRCAND = 0x008800C6,
        SRCINVERT = 0x00660046,
        SRCERASE = 0x00440328,
        NOTSRCCOPY = 0x00330008,
        NOTSRCERASE = 0x001100A6,
        MERGECOPY = 0x00C000CA,
        MERGEPAINT = 0x00BB0226,
        PATCOPY = 0x00F00021,
        PATPAINT = 0x00FB0A09,
        PATINVERT = 0x005A0049,
        DSTINVERT = 0x00550009,
        BLACKNESS = 0x00000042,
        WHITENESS = 0x00FF0062,
#pragma warning restore 1591
    }
    #endregion

    #region Clipboard Formats
    /// <summary>
    /// Clipboard Formats.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum ClipboardFormats : uint
    {
#pragma warning disable 1591
        CF_TEXT = 1,
        CF_BITMAP = 2,
        CF_METAFILEPICT = 3,
        CF_SYLK = 4,
        CF_DIF = 5,
        CF_TIFF = 6,
        CF_OEMTEXT = 7,
        CF_DIB = 8,
        CF_PALETTE = 9,
        CF_PENDATA = 10,
        CF_RIFF = 11,
        CF_WAVE = 12,
        CF_UNICODETEXT = 13,
        CF_ENHMETAFILE = 14,
        CF_HDROP = 15,
        CF_LOCALE = 16,
        CF_MAX = 17,
        CF_OWNERDISPLAY = 0x0080,
        CF_DSPTEXT = 0x0081,
        CF_DSPBITMAP = 0x0082,
        CF_DSPMETAFILEPICT = 0x0083,
        CF_DSPENHMETAFILE = 0x008E,
        CF_PRIVATEFIRST = 0x0200,
        CF_PRIVATELAST = 0x02FF,
        CF_GDIOBJFIRST = 0x0300,
        CF_GDIOBJLAST = 0x03FF,
#pragma warning restore 1591
    }
    #endregion

    #region Common Controls Initialization flags
    /// <summary>
    /// Common Controls Initialization flags.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum CommonControlInitFlags
    {
#pragma warning disable 1591
        ICC_LISTVIEW_CLASSES = 0x00000001,
        ICC_TREEVIEW_CLASSES = 0x00000002,
        ICC_BAR_CLASSES = 0x00000004,
        ICC_TAB_CLASSES = 0x00000008,
        ICC_UPDOWN_CLASS = 0x00000010,
        ICC_PROGRESS_CLASS = 0x00000020,
        ICC_HOTKEY_CLASS = 0x00000040,
        ICC_ANIMATE_CLASS = 0x00000080,
        ICC_WIN95_CLASSES = 0x000000FF,
        ICC_DATE_CLASSES = 0x00000100,
        ICC_USEREX_CLASSES = 0x00000200,
        ICC_COOL_CLASSES = 0x00000400,
        ICC_INTERNET_CLASSES = 0x00000800,
        ICC_PAGESCROLLER_CLASS = 0x00001000,
        ICC_NATIVEFNTCTL_CLASS = 0x00002000,
#pragma warning restore 1591
    }
    #endregion

    #region Common Controls Styles
    /// <summary>
    /// Common Controls Styles.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum CommonControlStyles
    {
#pragma warning disable 1591
        CCS_TOP = 0x00000001,
        CCS_NOMOVEY = 0x00000002,
        CCS_BOTTOM = 0x00000003,
        CCS_NORESIZE = 0x00000004,
        CCS_NOPARENTALIGN = 0x00000008,
        CCS_ADJUSTABLE = 0x00000020,
        CCS_NODIVIDER = 0x00000040,
        CCS_VERT = 0x00000080,
        CCS_LEFT = (CCS_VERT | CCS_TOP),
        CCS_RIGHT = (CCS_VERT | CCS_BOTTOM),
        CCS_NOMOVEX = (CCS_VERT | CCS_NOMOVEY),
#pragma warning restore 1591
    }
    #endregion

    #region ToolBar Styles
    /// <summary>
    /// ToolBar Styles.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum ToolBarStyles
    {
#pragma warning disable 1591
        TBSTYLE_BUTTON = 0x0000,
        TBSTYLE_SEP = 0x0001,
        TBSTYLE_CHECK = 0x0002,
        TBSTYLE_GROUP = 0x0004,
        TBSTYLE_CHECKGROUP = (TBSTYLE_GROUP | TBSTYLE_CHECK),
        TBSTYLE_DROPDOWN = 0x0008,
        TBSTYLE_AUTOSIZE = 0x0010,
        TBSTYLE_NOPREFIX = 0x0020,
        TBSTYLE_TOOLTIPS = 0x0100,
        TBSTYLE_WRAPABLE = 0x0200,
        TBSTYLE_ALTDRAG = 0x0400,
        TBSTYLE_FLAT = 0x0800,
        TBSTYLE_LIST = 0x1000,
        TBSTYLE_CUSTOMERASE = 0x2000,
        TBSTYLE_REGISTERDROP = 0x4000,
        TBSTYLE_TRANSPARENT = 0x8000,
        TBSTYLE_EX_DRAWDDARROWS = 0x00000001,
#pragma warning restore 1591
    }
    #endregion

    #region ToolBar Ex Styles
    /// <summary>
    /// ToolBar Ex Styles.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum ToolBarExStyles
    {
#pragma warning disable 1591
        TBSTYLE_EX_DRAWDDARROWS = 0x1,
        TBSTYLE_EX_HIDECLIPPEDBUTTONS = 0x10,
        TBSTYLE_EX_DOUBLEBUFFER = 0x80,
#pragma warning restore 1591
    }
    #endregion

    // ToolBar Messages
    #region
    /// <summary>
    /// ToolBar Messages.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum ToolBarMessages
    {
#pragma warning disable 1591
        WM_USER = 0x0400,
        TB_ENABLEBUTTON = (WM_USER + 1),
        TB_CHECKBUTTON = (WM_USER + 2),
        TB_PRESSBUTTON = (WM_USER + 3),
        TB_HIDEBUTTON = (WM_USER + 4),
        TB_INDETERMINATE = (WM_USER + 5),
        TB_MARKBUTTON = (WM_USER + 6),
        TB_ISBUTTONENABLED = (WM_USER + 9),
        TB_ISBUTTONCHECKED = (WM_USER + 10),
        TB_ISBUTTONPRESSED = (WM_USER + 11),
        TB_ISBUTTONHIDDEN = (WM_USER + 12),
        TB_ISBUTTONINDETERMINATE = (WM_USER + 13),
        TB_ISBUTTONHIGHLIGHTED = (WM_USER + 14),
        TB_SETSTATE = (WM_USER + 17),
        TB_GETSTATE = (WM_USER + 18),
        TB_ADDBITMAP = (WM_USER + 19),
        TB_ADDBUTTONSA = (WM_USER + 20),
        TB_INSERTBUTTONA = (WM_USER + 21),
        TB_ADDBUTTONS = (WM_USER + 20),
        TB_INSERTBUTTON = (WM_USER + 21),
        TB_DELETEBUTTON = (WM_USER + 22),
        TB_GETBUTTON = (WM_USER + 23),
        TB_BUTTONCOUNT = (WM_USER + 24),
        TB_COMMANDTOINDEX = (WM_USER + 25),
        TB_SAVERESTOREA = (WM_USER + 26),
        TB_CUSTOMIZE = (WM_USER + 27),
        TB_ADDSTRINGA = (WM_USER + 28),
        TB_GETITEMRECT = (WM_USER + 29),
        TB_BUTTONSTRUCTSIZE = (WM_USER + 30),
        TB_SETBUTTONSIZE = (WM_USER + 31),
        TB_SETBITMAPSIZE = (WM_USER + 32),
        TB_AUTOSIZE = (WM_USER + 33),
        TB_GETTOOLTIPS = (WM_USER + 35),
        TB_SETTOOLTIPS = (WM_USER + 36),
        TB_SETPARENT = (WM_USER + 37),
        TB_SETROWS = (WM_USER + 39),
        TB_GETROWS = (WM_USER + 40),
        TB_GETBITMAPFLAGS = (WM_USER + 41),
        TB_SETCMDID = (WM_USER + 42),
        TB_CHANGEBITMAP = (WM_USER + 43),
        TB_GETBITMAP = (WM_USER + 44),
        TB_GETBUTTONTEXTA = (WM_USER + 45),
        TB_GETBUTTONTEXTW = (WM_USER + 75),
        TB_REPLACEBITMAP = (WM_USER + 46),
        TB_SETINDENT = (WM_USER + 47),
        TB_SETIMAGELIST = (WM_USER + 48),
        TB_GETIMAGELIST = (WM_USER + 49),
        TB_LOADIMAGES = (WM_USER + 50),
        TB_GETRECT = (WM_USER + 51),
        TB_SETHOTIMAGELIST = (WM_USER + 52),
        TB_GETHOTIMAGELIST = (WM_USER + 53),
        TB_SETDISABLEDIMAGELIST = (WM_USER + 54),
        TB_GETDISABLEDIMAGELIST = (WM_USER + 55),
        TB_SETSTYLE = (WM_USER + 56),
        TB_GETSTYLE = (WM_USER + 57),
        TB_GETBUTTONSIZE = (WM_USER + 58),
        TB_SETBUTTONWIDTH = (WM_USER + 59),
        TB_SETMAXTEXTROWS = (WM_USER + 60),
        TB_GETTEXTROWS = (WM_USER + 61),
        TB_GETOBJECT = (WM_USER + 62),
        TB_GETBUTTONINFOW = (WM_USER + 63),
        TB_SETBUTTONINFOW = (WM_USER + 64),
        TB_GETBUTTONINFOA = (WM_USER + 65),
        TB_SETBUTTONINFOA = (WM_USER + 66),
        TB_INSERTBUTTONW = (WM_USER + 67),
        TB_ADDBUTTONSW = (WM_USER + 68),
        TB_HITTEST = (WM_USER + 69),
        TB_SETDRAWTEXTFLAGS = (WM_USER + 70),
        TB_GETHOTITEM = (WM_USER + 71),
        TB_SETHOTITEM = (WM_USER + 72),
        TB_SETANCHORHIGHLIGHT = (WM_USER + 73),
        TB_GETANCHORHIGHLIGHT = (WM_USER + 74),
        TB_SAVERESTOREW = (WM_USER + 76),
        TB_ADDSTRINGW = (WM_USER + 77),
        TB_MAPACCELERATORA = (WM_USER + 78),
        TB_GETINSERTMARK = (WM_USER + 79),
        TB_SETINSERTMARK = (WM_USER + 80),
        TB_INSERTMARKHITTEST = (WM_USER + 81),
        TB_MOVEBUTTON = (WM_USER + 82),
        TB_GETMAXSIZE = (WM_USER + 83),
        TB_SETEXTENDEDSTYLE = (WM_USER + 84),
        TB_GETEXTENDEDSTYLE = (WM_USER + 85),
        TB_GETPADDING = (WM_USER + 86),
        TB_SETPADDING = (WM_USER + 87),
        TB_SETINSERTMARKCOLOR = (WM_USER + 88),
        TB_GETINSERTMARKCOLOR = (WM_USER + 89),
#pragma warning restore 1591
    }
    #endregion

    #region ToolBar Notifications
    /// <summary>
    /// ToolBar Notifications.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum ToolBarNotifications
    {
#pragma warning disable 1591
        TTN_NEEDTEXTA = ((0 - 520) - 0),
        TTN_NEEDTEXTW = ((0 - 520) - 10),
        TBN_QUERYINSERT = ((0 - 700) - 6),
        TBN_DROPDOWN = ((0 - 700) - 10),
        TBN_HOTITEMCHANGE = ((0 - 700) - 13),
#pragma warning restore 1591
    }
    #endregion

    #region Reflected Messages
    /// <summary>
    /// Reflected Messages.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum ReflectedMessages
    {
#pragma warning disable 1591
        OCM__BASE = (Msg.WM_USER + 0x1c00),
        OCM_COMMAND = (OCM__BASE + Msg.WM_COMMAND),
        OCM_CTLCOLORBTN = (OCM__BASE + Msg.WM_CTLCOLORBTN),
        OCM_CTLCOLOREDIT = (OCM__BASE + Msg.WM_CTLCOLOREDIT),
        OCM_CTLCOLORDLG = (OCM__BASE + Msg.WM_CTLCOLORDLG),
        OCM_CTLCOLORLISTBOX = (OCM__BASE + Msg.WM_CTLCOLORLISTBOX),
        OCM_CTLCOLORMSGBOX = (OCM__BASE + Msg.WM_CTLCOLORMSGBOX),
        OCM_CTLCOLORSCROLLBAR = (OCM__BASE + Msg.WM_CTLCOLORSCROLLBAR),
        OCM_CTLCOLORSTATIC = (OCM__BASE + Msg.WM_CTLCOLORSTATIC),
        OCM_CTLCOLOR = (OCM__BASE + Msg.WM_CTLCOLOR),
        OCM_DRAWITEM = (OCM__BASE + Msg.WM_DRAWITEM),
        OCM_MEASUREITEM = (OCM__BASE + Msg.WM_MEASUREITEM),
        OCM_DELETEITEM = (OCM__BASE + Msg.WM_DELETEITEM),
        OCM_VKEYTOITEM = (OCM__BASE + Msg.WM_VKEYTOITEM),
        OCM_CHARTOITEM = (OCM__BASE + Msg.WM_CHARTOITEM),
        OCM_COMPAREITEM = (OCM__BASE + Msg.WM_COMPAREITEM),
        OCM_HSCROLL = (OCM__BASE + Msg.WM_HSCROLL),
        OCM_VSCROLL = (OCM__BASE + Msg.WM_VSCROLL),
        OCM_PARENTNOTIFY = (OCM__BASE + Msg.WM_PARENTNOTIFY),
        OCM_NOTIFY = (OCM__BASE + Msg.WM_NOTIFY),
#pragma warning restore 1591
    }
    #endregion

    #region Notification Messages
    /// <summary>
    /// Notification Messages.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum NotificationMessages
    {
#pragma warning disable 1591
        NM_FIRST = (0 - 0),
        NM_CUSTOMDRAW = (NM_FIRST - 12),
        NM_NCHITTEST = (NM_FIRST - 14),
#pragma warning restore 1591
    }
    #endregion

    #region ToolTip Flags
    /// <summary>
    /// ToolTip Flags.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum ToolTipFlags
    {
#pragma warning disable 1591
        TTF_CENTERTIP = 0x0002,
        TTF_RTLREADING = 0x0004,
        TTF_SUBCLASS = 0x0010,
        TTF_TRACK = 0x0020,
        TTF_ABSOLUTE = 0x0080,
        TTF_TRANSPARENT = 0x0100,
        TTF_DI_SETITEM = 0x8000,
#pragma warning restore 1591
    }
    #endregion

    #region
    /// <summary>
    /// Custom Draw Return Flags.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum CustomDrawReturnFlags
    {
#pragma warning disable 1591
        CDRF_DODEFAULT = 0x00000000,
        CDRF_NEWFONT = 0x00000002,
        CDRF_SKIPDEFAULT = 0x00000004,
        CDRF_NOTIFYPOSTPAINT = 0x00000010,
        CDRF_NOTIFYITEMDRAW = 0x00000020,
        CDRF_NOTIFYSUBITEMDRAW = 0x00000020,
        CDRF_NOTIFYPOSTERASE = 0x00000040,
#pragma warning restore 1591
    }
    #endregion

    #region
    /// <summary>
    /// Custom Draw Item State Flags.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum CustomDrawItemStateFlags
    {
#pragma warning disable 1591
        CDIS_SELECTED = 0x0001,
        CDIS_GRAYED = 0x0002,
        CDIS_DISABLED = 0x0004,
        CDIS_CHECKED = 0x0008,
        CDIS_FOCUS = 0x0010,
        CDIS_DEFAULT = 0x0020,
        CDIS_HOT = 0x0040,
        CDIS_MARKED = 0x0080,
        CDIS_INDETERMINATE = 0x0100,
#pragma warning restore 1591
    }
    #endregion

    #region
    /// <summary>
    /// Custom Draw Draw State Flags.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum CustomDrawDrawStateFlags
    {
#pragma warning disable 1591
        CDDS_PREPAINT = 0x00000001,
        CDDS_POSTPAINT = 0x00000002,
        CDDS_PREERASE = 0x00000003,
        CDDS_POSTERASE = 0x00000004,
        CDDS_ITEM = 0x00010000,
        CDDS_ITEMPREPAINT = (CDDS_ITEM | CDDS_PREPAINT),
        CDDS_ITEMPOSTPAINT = (CDDS_ITEM | CDDS_POSTPAINT),
        CDDS_ITEMPREERASE = (CDDS_ITEM | CDDS_PREERASE),
        CDDS_ITEMPOSTERASE = (CDDS_ITEM | CDDS_POSTERASE),
        CDDS_SUBITEM = 0x00020000,
#pragma warning restore 1591
    }
    #endregion

    #region
    /// <summary>
    /// Toolbar button info flags.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum ToolBarButtonInfoFlags
    {
#pragma warning disable 1591
        TBIF_IMAGE = 0x00000001,
        TBIF_TEXT = 0x00000002,
        TBIF_STATE = 0x00000004,
        TBIF_STYLE = 0x00000008,
        TBIF_LPARAM = 0x00000010,
        TBIF_COMMAND = 0x00000020,
        TBIF_SIZE = 0x00000040,
        I_IMAGECALLBACK = -1,
        I_IMAGENONE = -2,
#pragma warning restore 1591
    }
    #endregion

    #region Toolbar button styles
    /// <summary>
    /// Toolbar button styles.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum ToolBarButtonStyles
    {
#pragma warning disable 1591
        TBSTYLE_BUTTON = 0x0000,
        TBSTYLE_SEP = 0x0001,
        TBSTYLE_CHECK = 0x0002,
        TBSTYLE_GROUP = 0x0004,
        TBSTYLE_CHECKGROUP = (TBSTYLE_GROUP | TBSTYLE_CHECK),
        TBSTYLE_DROPDOWN = 0x0008,
        TBSTYLE_AUTOSIZE = 0x0010,
        TBSTYLE_NOPREFIX = 0x0020,
        TBSTYLE_TOOLTIPS = 0x0100,
        TBSTYLE_WRAPABLE = 0x0200,
        TBSTYLE_ALTDRAG = 0x0400,
        TBSTYLE_FLAT = 0x0800,
        TBSTYLE_LIST = 0x1000,
        TBSTYLE_CUSTOMERASE = 0x2000,
        TBSTYLE_REGISTERDROP = 0x4000,
        TBSTYLE_TRANSPARENT = 0x8000,
        TBSTYLE_EX_DRAWDDARROWS = 0x00000001,
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Toolbar button state.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum ToolBarButtonStates
    {
#pragma warning disable 1591
        TBSTATE_CHECKED = 0x01,
        TBSTATE_PRESSED = 0x02,
        TBSTATE_ENABLED = 0x04,
        TBSTATE_HIDDEN = 0x08,
        TBSTATE_INDETERMINATE = 0x10,
        TBSTATE_WRAP = 0x20,
        TBSTATE_ELLIPSES = 0x40,
        TBSTATE_MARKED = 0x80,
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Windows Hook Codes.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum WindowsHookCodes
    {
#pragma warning disable 1591
        WH_MSGFILTER = (-1),
        WH_JOURNALRECORD = 0,
        WH_JOURNALPLAYBACK = 1,
        WH_KEYBOARD = 2,
        WH_GETMESSAGE = 3,
        WH_CALLWNDPROC = 4,
        WH_CBT = 5,
        WH_SYSMSGFILTER = 6,
        WH_MOUSE = 7,
        WH_HARDWARE = 8,
        WH_DEBUG = 9,
        WH_SHELL = 10,
        WH_FOREGROUNDIDLE = 11,
        WH_CALLWNDPROCRET = 12,
        WH_KEYBOARD_LL = 13,
        WH_MOUSE_LL = 14,
#pragma warning restore 1591
    }

    #endregion

    /// <summary>
    /// Mouse Hook Filters.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum MouseHookFilters
    {
#pragma warning disable 1591
        MSGF_DIALOGBOX = 0,
        MSGF_MESSAGEBOX = 1,
        MSGF_MENU = 2,
        MSGF_SCROLLBAR = 5,
        MSGF_NEXTWINDOW = 6,
#pragma warning restore 1591
    }

    #endregion

    /// <summary>
    /// Draw Text format flags.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum DrawTextFormatFlags
    {
#pragma warning disable 1591
        DT_TOP = 0x00000000,
        DT_LEFT = 0x00000000,
        DT_CENTER = 0x00000001,
        DT_RIGHT = 0x00000002,
        DT_VCENTER = 0x00000004,
        DT_BOTTOM = 0x00000008,
        DT_WORDBREAK = 0x00000010,
        DT_SINGLELINE = 0x00000020,
        DT_EXPANDTABS = 0x00000040,
        DT_TABSTOP = 0x00000080,
        DT_NOCLIP = 0x00000100,
        DT_EXTERNALLEADING = 0x00000200,
        DT_CALCRECT = 0x00000400,
        DT_NOPREFIX = 0x00000800,
        DT_INTERNAL = 0x00001000,
        DT_EDITCONTROL = 0x00002000,
        DT_PATH_ELLIPSIS = 0x00004000,
        DT_END_ELLIPSIS = 0x00008000,
        DT_MODIFYSTRING = 0x00010000,
        DT_RTLREADING = 0x00020000,
        DT_WORD_ELLIPSIS = 0x00040000,
#pragma warning restore 1591
    }

    #endregion

    /// <summary>
    /// Rebar Styles.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum RebarStyles
    {
#pragma warning disable 1591
        RBS_TOOLTIPS = 0x0100,
        RBS_VARHEIGHT = 0x0200,
        RBS_BANDBORDERS = 0x0400,
        RBS_FIXEDORDER = 0x0800,
        RBS_REGISTERDROP = 0x1000,
        RBS_AUTOSIZE = 0x2000,
        RBS_VERTICALGRIPPER = 0x4000,
        RBS_DBLCLKTOGGLE = 0x8000,
#pragma warning restore 1591
    }
    #endregion

    #region Rebar Notifications
    /// <summary>
    /// Rebar Notifications.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum RebarNotifications
    {
#pragma warning disable 1591
        RBN_FIRST = (0 - 831),
        RBN_HEIGHTCHANGE = (RBN_FIRST - 0),
        RBN_GETOBJECT = (RBN_FIRST - 1),
        RBN_LAYOUTCHANGED = (RBN_FIRST - 2),
        RBN_AUTOSIZE = (RBN_FIRST - 3),
        RBN_BEGINDRAG = (RBN_FIRST - 4),
        RBN_ENDDRAG = (RBN_FIRST - 5),
        RBN_DELETINGBAND = (RBN_FIRST - 6),
        RBN_DELETEDBAND = (RBN_FIRST - 7),
        RBN_CHILDSIZE = (RBN_FIRST - 8),
        RBN_CHEVRONPUSHED = (RBN_FIRST - 10),
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Rebar Messages.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum RebarMessages
    {
#pragma warning disable 1591
        CCM_FIRST = 0x2000,
        WM_USER = 0x0400,
        RB_INSERTBANDA = (WM_USER + 1),
        RB_DELETEBAND = (WM_USER + 2),
        RB_GETBARINFO = (WM_USER + 3),
        RB_SETBARINFO = (WM_USER + 4),
        RB_GETBANDINFO = (WM_USER + 5),
        RB_SETBANDINFOA = (WM_USER + 6),
        RB_SETPARENT = (WM_USER + 7),
        RB_HITTEST = (WM_USER + 8),
        RB_GETRECT = (WM_USER + 9),
        RB_INSERTBANDW = (WM_USER + 10),
        RB_SETBANDINFOW = (WM_USER + 11),
        RB_GETBANDCOUNT = (WM_USER + 12),
        RB_GETROWCOUNT = (WM_USER + 13),
        RB_GETROWHEIGHT = (WM_USER + 14),
        RB_IDTOINDEX = (WM_USER + 16),
        RB_GETTOOLTIPS = (WM_USER + 17),
        RB_SETTOOLTIPS = (WM_USER + 18),
        RB_SETBKCOLOR = (WM_USER + 19),
        RB_GETBKCOLOR = (WM_USER + 20),
        RB_SETTEXTCOLOR = (WM_USER + 21),
        RB_GETTEXTCOLOR = (WM_USER + 22),
        RB_SIZETORECT = (WM_USER + 23),
        RB_SETCOLORSCHEME = (CCM_FIRST + 2),
        RB_GETCOLORSCHEME = (CCM_FIRST + 3),
        RB_BEGINDRAG = (WM_USER + 24),
        RB_ENDDRAG = (WM_USER + 25),
        RB_DRAGMOVE = (WM_USER + 26),
        RB_GETBARHEIGHT = (WM_USER + 27),
        RB_GETBANDINFOW = (WM_USER + 28),
        RB_GETBANDINFOA = (WM_USER + 29),
        RB_MINIMIZEBAND = (WM_USER + 30),
        RB_MAXIMIZEBAND = (WM_USER + 31),
        RB_GETDROPTARGET = (CCM_FIRST + 4),
        RB_GETBANDBORDERS = (WM_USER + 34),
        RB_SHOWBAND = (WM_USER + 35),
        RB_SETPALETTE = (WM_USER + 37),
        RB_GETPALETTE = (WM_USER + 38),
        RB_MOVEBAND = (WM_USER + 39),
        RB_SETUNICODEFORMAT = (CCM_FIRST + 5),
        RB_GETUNICODEFORMAT = (CCM_FIRST + 6),
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Rebar Info Mask.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum RebarInfoMask
    {
#pragma warning disable 1591
        RBBIM_STYLE = 0x00000001,
        RBBIM_COLORS = 0x00000002,
        RBBIM_TEXT = 0x00000004,
        RBBIM_IMAGE = 0x00000008,
        RBBIM_CHILD = 0x00000010,
        RBBIM_CHILDSIZE = 0x00000020,
        RBBIM_SIZE = 0x00000040,
        RBBIM_BACKGROUND = 0x00000080,
        RBBIM_ID = 0x00000100,
        RBBIM_IDEALSIZE = 0x00000200,
        RBBIM_LPARAM = 0x00000400,
        BBIM_HEADERSIZE = 0x00000800,
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Rebar Styles.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum RebarStylesEx
    {
#pragma warning disable 1591
        RBBS_BREAK = 0x1,
        RBBS_CHILDEDGE = 0x4,
        RBBS_FIXEDBMP = 0x20,
        RBBS_GRIPPERALWAYS = 0x80,
        RBBS_USECHEVRON = 0x200,
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Object types.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum ObjectTypes
    {
#pragma warning disable 1591
        OBJ_PEN = 1,
        OBJ_BRUSH = 2,
        OBJ_DC = 3,
        OBJ_METADC = 4,
        OBJ_PAL = 5,
        OBJ_FONT = 6,
        OBJ_BITMAP = 7,
        OBJ_REGION = 8,
        OBJ_METAFILE = 9,
        OBJ_MEMDC = 10,
        OBJ_EXTPEN = 11,
        OBJ_ENHMETADC = 12,
        OBJ_ENHMETAFILE = 13,
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// WM_MENUCHAR return values.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum MenuCharReturnValues
    {
#pragma warning disable 1591
        MNC_IGNORE = 0,
        MNC_CLOSE = 1,
        MNC_EXECUTE = 2,
        MNC_SELECT = 3,
#pragma warning restore 1591
    }
    #endregion

    #region
    /// <summary>
    /// Background Mode.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum BackgroundMode
    {
        /// <summary>
        /// Trabsparent Background Mode.
        /// </summary>
        TRANSPARENT = 1,

        /// <summary>
        /// Opaque Background Mode.
        /// </summary>
        OPAQUE = 2,
    }
    #endregion

    /// <summary>
    /// ListView Messages.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum ListViewMessages
    {
#pragma warning disable 1591
        LVM_FIRST = 0x1000,
        LVM_GETSUBITEMRECT = (LVM_FIRST + 56),
        LVM_GETITEMSTATE = (LVM_FIRST + 44),
        LVM_GETITEMTEXTW = (LVM_FIRST + 115),
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Header Control Messages.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum HeaderControlMessages
    {
#pragma warning disable 1591
        HDM_FIRST = 0x1200,
        HDM_GETITEMRECT = (HDM_FIRST + 7),
        HDM_HITTEST = (HDM_FIRST + 6),
        HDM_SETIMAGELIST = (HDM_FIRST + 8),
        HDM_GETITEMW = (HDM_FIRST + 11),
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Header Control Notifications.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum HeaderControlNotifications
    {
#pragma warning disable 1591
        HDN_FIRST = (0 - 300),
        HDN_BEGINTRACKW = (HDN_FIRST - 26),
        HDN_ENDTRACKW = (HDN_FIRST - 27),
        HDN_ITEMCLICKW = (HDN_FIRST - 22),
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Header Control HitTest Flags.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum HeaderControlHitTestFlags : uint
    {
#pragma warning disable 1591
        HHT_NOWHERE = 0x0001,
        HHT_ONHEADER = 0x0002,
        HHT_ONDIVIDER = 0x0004,
        HHT_ONDIVOPEN = 0x0008,
        HHT_ABOVE = 0x0100,
        HHT_BELOW = 0x0200,
        HHT_TORIGHT = 0x0400,
        HHT_TOLEFT = 0x0800,
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// List View sub item portion.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum SubItemPortion
    {
#pragma warning disable 1591
        LVIR_BOUNDS = 0,
        LVIR_ICON = 1,
        LVIR_LABEL = 2,
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Cursor Type.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum CursorType : uint
    {
#pragma warning disable 1591
        IDC_ARROW = 32512U,
        IDC_IBEAM = 32513U,
        IDC_WAIT = 32514U,
        IDC_CROSS = 32515U,
        IDC_UPARROW = 32516U,
        IDC_SIZE = 32640U,
        IDC_ICON = 32641U,
        IDC_SIZENWSE = 32642U,
        IDC_SIZENESW = 32643U,
        IDC_SIZEWE = 32644U,
        IDC_SIZENS = 32645U,
        IDC_SIZEALL = 32646U,
        IDC_NO = 32648U,
        IDC_HAND = 32649U,
        IDC_APPSTARTING = 32650U,
        IDC_HELP = 32651U,
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Tracker Event Flags.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum TrackerEventFlags : uint
    {
#pragma warning disable 1591
        TME_HOVER = 0x00000001,
        TME_LEAVE = 0x00000002,
        TME_QUERY = 0x40000000,
        TME_CANCEL = 0x80000000,
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Mouse Activate Flags.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum MouseActivateFlags
    {
#pragma warning disable 1591
        MA_ACTIVATE = 1,
        MA_ACTIVATEANDEAT = 2,
        MA_NOACTIVATE = 3,
        MA_NOACTIVATEANDEAT = 4,
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Dialog Codes.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum DialogCodes
    {
#pragma warning disable 1591
        DLGC_WANTARROWS = 0x0001,
        DLGC_WANTTAB = 0x0002,
        DLGC_WANTALLKEYS = 0x0004,
        DLGC_WANTMESSAGE = 0x0004,
        DLGC_HASSETSEL = 0x0008,
        DLGC_DEFPUSHBUTTON = 0x0010,
        DLGC_UNDEFPUSHBUTTON = 0x0020,
        DLGC_RADIOBUTTON = 0x0040,
        DLGC_WANTCHARS = 0x0080,
        DLGC_STATIC = 0x0100,
        DLGC_BUTTON = 0x2000,
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// Update Layered Windows Flags.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum UpdateLayeredWindowsFlags
    {
#pragma warning disable 1591
        ULW_COLORKEY = 0x00000001,
        ULW_ALPHA = 0x00000002,
        ULW_OPAQUE = 0x00000004,
#pragma warning restore 1591
    }
    #endregion

    #region
    /// <summary>
    /// The Alpha Flags.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum AlphaFlags : byte
    {
        /// <summary>
        /// The Over value.
        /// </summary>
        AC_SRC_OVER = 0x00,

        /// <summary>
        /// The Alpha value.
        /// </summary>
        AC_SRC_ALPHA = 0x01,
    }
    #endregion

    /// <summary>
    /// ComboBox messages.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum ComboBoxMessages
    {
#pragma warning disable 1591
        CB_GETDROPPEDSTATE = 0x0157,
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// SetWindowLong indexes.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum SetWindowLongOffsets
    {
#pragma warning disable 1591
        GWL_WNDPROC = (-4),
        GWL_HINSTANCE = (-6),
        GWL_HWNDPARENT = (-8),
        GWL_STYLE = (-16),
        GWL_EXSTYLE = (-20),
        GWL_USERDATA = (-21),
        GWL_ID = (-12),
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// TreeView Messages.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    public enum TreeViewMessages
    {
#pragma warning disable 1591
        TV_FIRST = 0x1100,
        TVM_GETITEMRECT = (TV_FIRST + 4),
        TVM_GETITEMW = (TV_FIRST + 62),
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// TreeViewItem Flags.
    /// </summary>
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum TreeViewItemFlags
    {
#pragma warning disable 1591
        TVIF_TEXT = 0x0001,
        TVIF_IMAGE = 0x0002,
        TVIF_PARAM = 0x0004,
        TVIF_STATE = 0x0008,
        TVIF_HANDLE = 0x0010,
        TVIF_SELECTEDIMAGE = 0x0020,
        TVIF_CHILDREN = 0x0040,
        TVIF_INTEGRAL = 0x0080,
#pragma warning restore 1591
    }
    #endregion

    #region
    /// <summary>
    /// ListViewItem flags.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum ListViewItemFlags
    {
#pragma warning disable 1591
        LVIF_TEXT = 0x0001,
        LVIF_IMAGE = 0x0002,
        LVIF_PARAM = 0x0004,
        LVIF_STATE = 0x0008,
        LVIF_INDENT = 0x0010,
        LVIF_NORECOMPUTE = 0x0800,
#pragma warning restore 1591
    }
    #endregion

    #region HeaderItemFlags
    /// <summary>
    /// The HeaderItemFlags flags.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum HeaderItemFlags
    {
#pragma warning disable 1591
        HDI_WIDTH = 0x0001,
        HDI_HEIGHT = HDI_WIDTH,
        HDI_TEXT = 0x0002,
        HDI_FORMAT = 0x0004,
        HDI_LPARAM = 0x0008,
        HDI_BITMAP = 0x0010,
        HDI_IMAGE = 0x0020,
        HDI_DI_SETITEM = 0x0040,
        HDI_ORDER = 0x0080,
#pragma warning restore 1591
    }
    #endregion

    #region GetDCExFlags
    /// <summary>
    /// The GetDCExFlags flags.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:Enumeration items should be documented",
        Justification = "Not here!")]
    [Flags]
    public enum GetDCExFlags
    {
#pragma warning disable 1591
        DCX_WINDOW = 0x00000001,
        DCX_CACHE = 0x00000002,
        DCX_NORESETATTRS = 0x00000004,
        DCX_CLIPCHILDREN = 0x00000008,
        DCX_CLIPSIBLINGS = 0x00000010,
        DCX_PARENTCLIP = 0x00000020,
        DCX_EXCLUDERGN = 0x00000040,
        DCX_INTERSECTRGN = 0x00000080,
        DCX_EXCLUDEUPDATE = 0x00000100,
        DCX_INTERSECTUPDATE = 0x00000200,
        DCX_LOCKWINDOWUPDATE = 0x00000400,
        DCX_VALIDATE = 0x00200000,
#pragma warning restore 1591
    }
    #endregion

    /// <summary>
    /// The SLGP_FLAGS flags.
    /// </summary>
    [Flags]
    public enum SLGP_FLAGS
    {
        /// <summary>
        /// Retrieves the standard short (8.3 format) file name
        /// </summary>
        SLGP_SHORTPATH = 0x1,

        /// <summary>
        /// Retrieves the Universal Naming Convention (UNC) path
        /// name of the file
        /// </summary>
        SLGP_UNCPRIORITY = 0x2,

        /// <summary>Retrieves the raw path name. A raw path is
        /// something that might not exist and may include
        /// environment variables that need to be expanded
        /// </summary>
        SLGP_RAWPATH = 0x4,
    } // SLGP_FLAGS

    /// <summary>
    /// The SLR_FLAGS flags.
    /// </summary>
    [Flags]
    public enum SLR_FLAGS
    {
        /// <summary>
        /// Do not display a dialog box if the link cannot be
        /// resolved. When SLR_NO_UI is set, the high-order word
        /// of fFlags can be set to a time-out value that specifies
        /// the maximum amount of time to be spent resolving the link.
        /// The function returns if the link cannot be resolved within
        /// the time-out duration. If the high-order word is set
        /// to zero, the time-out duration will be set to the default
        /// value of 3,000 milliseconds (3 seconds). To specify a value,
        /// set the high word of fFlags to the desired time-out
        /// duration, in milliseconds.
        /// </summary>
        SLR_NO_UI = 0x1,

        /// <summary>Obsolete and no longer used</summary>
        SLR_ANY_MATCH = 0x2,

        /// <summary>
        /// If the link object has changed, update its path
        /// and list of identifiers.
        /// If SLR_UPDATE is set, you do not need to call
        /// IPersistFile::IsDirty to determine
        /// whether or not the link object has changed.
        /// </summary>
        SLR_UPDATE = 0x4,

        /// <summary>
        /// Do not update the link information
        /// </summary>
        SLR_NOUPDATE = 0x8,

        /// <summary>
        /// Do not execute the search heuristics
        /// </summary>
        SLR_NOSEARCH = 0x10,

        /// <summary>
        /// Do not use distributed link tracking
        /// </summary>
        SLR_NOTRACK = 0x20,

        /// <summary>
        /// Disable distributed link tracking. By default, distributed
        /// link tracking tracks removable media across multiple
        /// devices based on the volume name. It also uses the
        /// Universal Naming Convention (UNC) path to track remote
        /// file systems whose drive letter has changed. Setting
        /// SLR_NOLINKINFO disables both types of tracking.
        /// </summary>
        SLR_NOLINKINFO = 0x40,

        /// <summary>
        /// Call the Microsoft Windows Installer
        /// </summary>
        SLR_INVOKE_MSI = 0x80,
    } // SLR_FLAGS

    // ReSharper enable IdentifierTypo
} // Tethys.Win32

// =======================
// Tethys: end of enums.cs
// =======================