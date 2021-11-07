// ---------------------------------------------------------------------------
// <copyright file="Structs.cs" company="Tethys">
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
    using System.Drawing;
    using System.Runtime.InteropServices;

    // Structures to interoperate with the Windows 32 API
#pragma warning disable 1591
    #region
    /// <summary>
    /// The SIZE structure specifies the width and height of a rectangle.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Not here!")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        public int cx;
        public int cy;
    }
    #endregion

    #region
    /// <summary>
    /// The RECT structure defines the coordinates of the upper-left and
    /// lower-right corners of a rectangle.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
    #endregion

    #region
    /// <summary>
    /// Carries information used to load common control classes from the
    /// dynamic-link library (DLL). This structure is used with the
    /// InitCommonControlsEx function.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1401:Field should be private",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class INITCOMMONCONTROLSEX
    {
        public int dwSize;
        public int dwICC;
    }
    #endregion

    #region
    /// <summary>
    /// Contains information about a button in a toolbar.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TBBUTTON
    {
        public int iBitmap;
        public int idCommand;
        public byte fsState;
        public byte fsStyle;
        public byte bReserved0;
        public byte bReserved1;
        public int dwData;
        public int iString;
    }
    #endregion

    #region
    /// <summary>
    /// Win32 API POINT structure.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1401:Field should be private",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1402:File may only contain a single type",
        Justification = "Not here because of Win32")]
    [StructLayout(LayoutKind.Sequential)]
    public class POINT
    {
        /// <summary>
        /// X coordinate of the point.
        /// </summary>
        public int x;

        /// <summary>
        /// Y coordinate of the point.
        /// </summary>
        public int y;

        /// <summary>
        /// Initializes a new instance of the <see cref="POINT"/> class.
        /// </summary>
        public POINT()
        {
        } // POINT()

        /// <summary>
        /// Initializes a new instance of the <see cref="POINT"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public POINT(int x, int y)
        {
            this.x = x;
            this.y = y;
        } // POINT()
    } // POINT
    #endregion

    #region
    /// <summary>
    /// Contains information about a notification message.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct NMHDR
    {
        public IntPtr hwndFrom;
        public int idFrom;
        public int code;
    }
    #endregion

    #region
    /// <summary>
    /// TOOLTIPTEXTA.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct TOOLTIPTEXTA
    {
        public NMHDR hdr;
        public IntPtr lpszText;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szText;
        public IntPtr hinst;
        public int uFlags;
    }
    #endregion

    #region
    /// <summary>
    /// TOOLTIPTEXT.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct TOOLTIPTEXT
    {
        public NMHDR hdr;
        public IntPtr lpszText;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szText;
        public IntPtr hinst;
        public int uFlags;
    }
    #endregion

    #region
    /// <summary>
    /// Contains information specific to an NM_CUSTOMDRAW notification message.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct NMCUSTOMDRAW
    {
        public NMHDR hdr;
        public int dwDrawStage;
        public IntPtr hdc;
        public RECT rc;
        public int dwItemSpec;
        public int uItemState;
        public int lItemlParam;
    }
    #endregion

    #region
    /// <summary>
    /// Contains information specific to an NM_CUSTOMDRAW notification
    /// message sent by a toolbar control.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct NMTBCUSTOMDRAW
    {
        public NMCUSTOMDRAW nmcd;
        public IntPtr hbrMonoDither;
        public IntPtr hbrLines;
        public IntPtr hpenLines;
        public int clrText;
        public int clrMark;
        public int clrTextHighlight;
        public int clrBtnFace;
        public int clrBtnHighlight;
        public int clrHighlightHotTrack;
        public RECT rcText;
        public int nStringBkMode;
        public int nHLStringBkMode;
    }
    #endregion

    #region
    /// <summary>
    /// Contains information specific to an NM_CUSTOMDRAW (list view)
    /// notification message sent by a list-view control.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct NMLVCUSTOMDRAW
    {
        public NMCUSTOMDRAW nmcd;
        public uint clrText;
        public uint clrTextBk;
        public int iSubItem;
    }
    #endregion

    #region
    /// <summary>
    /// Contains or receives information for a specific button in a toolbar.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct TBBUTTONINFO
    {
        public int cbSize;
        public int dwMask;
        public int idCommand;
        public int iImage;
        public byte fsState;
        public byte fsStyle;
        public short cx;
        public IntPtr lParam;
        public IntPtr pszText;
        public int cchText;
    }
    #endregion

    #region
    /// <summary>
    /// Contains information that defines a band in a rebar control.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct REBARBANDINFO
    {
        public int cbSize;
        public int fMask;
        public int fStyle;
        public int clrFore;
        public int clrBack;
        public IntPtr lpText;
        public int cch;
        public int iImage;
        public IntPtr hwndChild;
        public int cxMinChild;
        public int cyMinChild;
        public int cx;
        public IntPtr hbmBack;
        public int wID;
        public int cyChild;
        public int cyMaxChild;
        public int cyIntegral;
        public int cxIdeal;
        public int lParam;
        public int cxHeader;
    }
    #endregion

    #region
    /// <summary>
    /// The MOUSEHOOKSTRUCT structure contains information about a mouse event
    /// passed to a WH_MOUSE hook procedure, MouseProc.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEHOOKSTRUCT
    {
        public POINT pt;
        public IntPtr hwnd;
        public int wHitTestCode;
        public IntPtr dwExtraInfo;
    }
    #endregion

    #region
    /// <summary>
    /// Contains information used to process toolbar notification messages.
    /// This structure supersedes the TBNOTIFY structure.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct NMTOOLBAR
    {
        public NMHDR hdr;
        public int iItem;
        public TBBUTTON tbButton;
        public int cchText;
        public IntPtr pszText;
        public RECT rcButton;
    }
    #endregion

    #region
    /// <summary>
    /// Contains information used in handling the RBN_CHEVRONPUSHED.
    /// notification message.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct NMREBARCHEVRON
    {
        public NMHDR hdr;
        public int uBand;
        public int wID;
        public int lParam;
        public RECT rc;
        public int lParamNM;
    }
    #endregion

    #region BITMAP
    /// <summary>
    /// The Bitmap struct.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAP
    {
        public long bmType;
        public long bmWidth;
        public long bmHeight;
        public long bmWidthBytes;
        public short bmPlanes;
        public short bmBitsPixel;
        public IntPtr bmBits;
    }
    #endregion

    #region BITMAPINFO_FLAT
    /// <summary>
    /// The BITMAPINFO_FLAT struct.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1310:Field should not contain an underscore",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFO_FLAT
    {
        public int bmiHeader_biSize;
        public int bmiHeader_biWidth;
        public int bmiHeader_biHeight;
        public short bmiHeader_biPlanes;
        public short bmiHeader_biBitCount;
        public int bmiHeader_biCompression;
        public int bmiHeader_biSizeImage;
        public int bmiHeader_biXPelsPerMeter;
        public int bmiHeader_biYPelsPerMeter;
        public int bmiHeader_biClrUsed;
        public int bmiHeader_biClrImportant;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] bmiColors;
    }
    #endregion

    #region RGBQUAD
    /// <summary>
    /// The RGBQUAD struct.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    public struct RGBQUAD
    {
        public byte rgbBlue;
        public byte rgbGreen;
        public byte rgbRed;
        public byte rgbReserved;
    }
    #endregion

    #region
    /// <summary>
    /// The BITMAPINFOHEADER struct.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1401:Field should be private",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1402:File may only contain a single type",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public class BITMAPINFOHEADER
    {
        public int biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
        public int biWidth;
        public int biHeight;
        public short biPlanes;
        public short biBitCount;
        public int biCompression;
        public int biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public int biClrUsed;
        public int biClrImportant;
    }
    #endregion

    // BITMAPINFO
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1401:Field should be private",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1402:File may only contain a single type",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public class BITMAPINFO
    {
        public BITMAPINFOHEADER bmiHeader = new BITMAPINFOHEADER();
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] bmiColors;
    }
    #endregion

    // PALETTEENTRY
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct PALETTEENTRY
    {
        public byte peRed;
        public byte peGreen;
        public byte peBlue;
        public byte peFlags;
    }
    #endregion

    // MSG
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1310:Field should not contain an underscore",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public IntPtr hwnd;
        public int message;
        public IntPtr wParam;
        public IntPtr lParam;
        public int time;
        public int pt_x;
        public int pt_y;
    }
    #endregion

    // CALLBACK WINDOW RETURN
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct CWPRETSTRUCT
    {
        public IntPtr lResult;
        public IntPtr lParam;
        public IntPtr wParam;
        public uint message;
        public IntPtr hwnd;
    }
    #endregion

    // HD_HITTESTINFO
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct HD_HITTESTINFO
    {
        public POINT pt;
        public uint flags;
        public int iItem;
    }
    #endregion

    // DLLVERSIONINFO
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DLLVERSIONINFO
    {
        public int cbSize;
        public int dwMajorVersion;
        public int dwMinorVersion;
        public int dwBuildNumber;
        public int dwPlatformID;
    }
    #endregion

    // PAINTSTRUCT
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct PAINTSTRUCT
    {
        public IntPtr hdc;
        public int fErase;
        public Rectangle rcPaint;
        public int fRestore;
        public int fIncUpdate;
        public int Reserved1;
        public int Reserved2;
        public int Reserved3;
        public int Reserved4;
        public int Reserved5;
        public int Reserved6;
        public int Reserved7;
        public int Reserved8;
    }
    #endregion

    // BLENDFUNCTION
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BLENDFUNCTION
    {
        public byte BlendOp;
        public byte BlendFlags;
        public byte SourceConstantAlpha;
        public byte AlphaFormat;
    }

    #endregion

    // TRACKMOUSEEVENTS
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct TRACKMOUSEEVENTS
    {
        public uint cbSize;
        public uint dwFlags;
        public IntPtr hWnd;
        public uint dwHoverTime;
    }
    #endregion

    // STRINGBUFFER
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct STRINGBUFFER
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szText;
    }
    #endregion

    // NMTVCUSTOMDRAW
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential)]
    public struct NMTVCUSTOMDRAW
    {
        public NMCUSTOMDRAW nmcd;
        public uint clrText;
        public uint clrTextBk;
        public int iLevel;
    }
    #endregion

    // TVITEM
    #region
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct TVITEM
    {
        public uint mask;
        public IntPtr hItem;
        public uint state;
        public uint stateMask;
        public IntPtr pszText;
        public int cchTextMax;
        public int iImage;
        public int iSelectedImage;
        public int cChildren;
        public int lParam;
    }
    #endregion

    // LVITEM
    #region
    /// <summary>
    /// Specifies or receives the attributes of a list-view item.
    /// This structure has been updated to support a new mask value (LVIF_INDENT)
    /// that enables item indenting. This structure supersedes the LV_ITEM
    /// structure.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LVITEM
    {
        public uint mask;
        public int iItem;
        public int iSubItem;
        public uint state;
        public uint stateMask;
        public IntPtr pszText;
        public int cchTextMax;
        public int iImage;
        public int lParam;
        public int iIndent;
    }
    #endregion

    #region HDITEM
    /// <summary>
    /// Contains information about an item in a header control.
    /// This structure supersedes the HD_ITEM structure.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct HDITEM
    {
        public uint mask;
        public int cxy;
        public IntPtr pszText;
        public IntPtr hbm;
        public int cchTextMax;
        public int fmt;
        public int lParam;
        public int iImage;
        public int iOrder;
    } // HDITEM
    #endregion // HDITEM

    #region SHFILEOPERATION STRUCTS
    /// <summary>
    /// Contains information that the SHFileOperation function uses
    /// to perform file operations.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
    public struct SHFILEOPSTRUCT
    {
        /// <summary>
        /// Window handle to the dialog box to display information about the status of the file operation.
        /// </summary>
        public IntPtr hWnd;

        /// <summary>
        /// Value that indicates which operation to perform. This member can be one of the following values.
        /// * FO_COPY - Copy the files specified in the pFrom member to the
        /// location specified in the pTo member.
        /// * FO_DELETE - Delete the files specified in pFrom.
        /// * FO_MOVE - Move the files specified in pFrom to the location
        /// specified in pTo.
        /// * FO_RENAME - Rename the file specified in pFrom. You cannot use this
        /// flag to rename multiple files with a single function call.
        /// Use FO_MOVE instead.
        /// </summary>
        public int wFunc;

        /// <summary>
        /// Address of a buffer to specify one or more source file names. These
        /// names must be fully qualified paths. Standard Microsoft MS-DOS wild
        /// cards, such as "*", are permitted in the file-name position.
        /// Although this member is declared as a null-terminated string, it
        /// is used as a buffer to hold multiple file names. Each file name
        /// must be terminated by a single NULL character. An additional NULL
        /// character must be appended to the end of the final name to indicate
        /// the end of pFrom.
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pFrom;

        /// <summary>
        /// Address of a buffer to contain the name of the destination file or directory.
        /// This parameter must be set to NULL if it is not used. Like pFrom, the pTo member is also
        /// a double-null terminated string and is handled in much the same way. However, pTo must meet
        /// the following specifications.
        /// <list type="">
        /// <item>Wildcard characters are not supported.</item>
        /// <item>Copy and Move operations can specify destination directories that
        /// do not exist and the system will attempt to create them. The system
        /// normally displays a dialog box to ask the user if they want to
        /// create the new directory. To suppress this dialog box and have the
        /// directories created silently, set the FOF_NOCONFIRMMKDIR flag
        /// in fFlags.</item>
        /// <item>For Copy and Move operations, the buffer can contain multiple
        /// destination file names if the fFlags member specifies
        /// FOF_MULTIDESTFILES.</item>
        /// <item>Pack multiple names into the string in the same way as for pFrom.</item>
        /// <item>Use only fully-qualified paths. Using relative paths will have
        /// unpredictable results.</item>
        /// </list>
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pTo;

        /// <summary>
        /// Flags that control the file operation.
        /// </summary>
        public short fFlags;

        /// <summary>
        /// Value that receives TRUE if the user aborted any file operations
        /// before they were completed, or FALSE otherwise.
        /// </summary>
        public int fAnyOperationsAborted;

        /// <summary>
        /// A handle to a name mapping object containing the old and new names of
        /// the renamed files. This member is used only if the fFlags member
        /// includes the FOF_WANTMAPPINGHANDLE flag. See Remarks for more
        /// details.
        /// </summary>
        public IntPtr hNameMappings;

        /// <summary>
        /// Address of a string to use as the title of a progress dialog box.
        /// This member is used only if fFlags includes the FOF_SIMPLEPROGRESS
        /// flag.
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpszProgressTitle;
    } // SHFILEOPSTRUCT
    #endregion // SHFILEOPERATION STRUCTS

    #region LOGFONT
    /// <summary>
    /// Windows API Logical Font structure to represent information
    /// about a font.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LOGFONT
    {
        /// <summary>
        /// Height of the font.
        /// </summary>
        public int lfHeight;
        public int lfWidth;
        public int lfEscapement;
        public int lfOrientation;
        public int lfWeight;
        public byte lfItalic;
        public byte lfUnderline;
        public byte lfStrikeOut;
        public byte lfCharSet;
        public byte lfOutPrecision;
        public byte lfClipPrecision;
        public byte lfQuality;
        public byte lfPitchAndFamily;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string lfFaceName;
    } // LOGFONT
    #endregion LOGFONT

    #region TEXTMETRIC
    /// <summary>
    /// Summary for TEXTMETRIC.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct TEXTMETRIC
    {
        public int tmHeight;
        public int tmAscent;
        public int tmDescent;
        public int tmInternalLeading;
        public int tmExternalLeading;
        public int tmAveCharWidth;
        public int tmMaxCharWidth;
        public int tmWeight;
        public int tmOverhang;
        public int tmDigitizedAspectX;
        public int tmDigitizedAspectY;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string tmFirstChar;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string tmLastChar;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string tmDefaultChar;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string tmBreakChar;
        public byte tmItalic;
        public byte tmUnderlined;
        public byte tmStruckOut;
        public byte tmPitchAndFamily;
        public byte tmCharSet;
    } // TEXTMETRIC

    #endregion TEXTMETRIC

    #region FONTFAMILYTYPES
    /// <summary>
    /// FontFamilyTypes.
    /// </summary>
    public enum FontFamilyTypes
    {
        /// <summary>
        /// Don't care or don't know.
        /// </summary>
        FF_DONTCARE = (0 << 4),
        /// <summary>
        /// Variable stroke width, serifed.
        /// Times Roman, Century Schoolbook, etc.
        /// </summary>
        FF_ROMAN = (1 << 4),
        /// <summary>
        /// Variable stroke width, sans-serifed.
        /// Helvetica, Swiss, etc.
        /// </summary>
        FF_SWISS = (2 << 4),
        /// <summary>
        /// Constant stroke width, serifed or sans-serifed.
        /// Pica, Elite, Courier, etc.
        /// </summary>
        FF_MODERN = (3 << 4),
        /// <summary>
        /// Cursive, etc.
        /// </summary>
        FF_SCRIPT = (4 << 4),
        /// <summary>
        /// Old English, etc.
        /// </summary>
        FF_DECORATIVE = (5 << 4),
    } // FontFamilyTypes

    /// <summary>
    /// Contains information about the file that is found by the FindFirstFile,
    /// FindFirstFileEx, or FindNextFile function.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1307:Field should begin with upper-case letter",
        Justification = "Not here because of Win32")]
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:Elements should be documented",
        Justification = "Not here!")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WIN32_FIND_DATAW
    {
        public uint dwFileAttributes;
        public long ftCreationTime;
        public long ftLastAccessTime;
        public long ftLastWriteTime;
        public uint nFileSizeHigh;
        public uint nFileSizeLow;
        public uint dwReserved0;
        public uint dwReserved1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string cFileName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternateFileName;
    } // WIN32_FIND_DATAW

    #endregion // FONTFAMILYTYPES
#pragma warning restore 1591
} // Tethys.Win32

// ========================
// Tethys: end of structs.cs
// ========================