// ---------------------------------------------------------------------------
// <copyright file="FileString.cs" company="Tethys">
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
namespace Tethys.IO
{
    using System;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// Specification for different filename parts.
    /// </summary>
    [Flags]
    public enum FileStringOptions
    {
        /// <summary>
        /// Get fileName extend.
        /// </summary>
        Extend = 0x0001,

        /// <summary>
        /// Get filename.
        /// </summary>
        FileName = 0x0002,

        /// <summary>
        /// Get fileName path.
        /// </summary>
        FilePath = 0x0004,

        /// <summary>
        /// Get drive.
        /// </summary>
        Drive = 0x0008,

        /// <summary>
        /// Get folder.
        /// </summary>
        Folder = 0x0010,

        /// <summary>
        /// Part Mask
        /// </summary>
        PartMask = 0x001f,

        /// <summary>
        /// Use Wildcards
        /// </summary>
        Wildcards = 0x0100,

        /// <summary>
        /// Default value
        /// </summary>
        Default = 0x0200,

        /// <summary>
        /// Only Names
        /// </summary>
        OnlyName = 0x0400,

        /// <summary>
        /// New value
        /// </summary>
        New = 0x0800,

        /// <summary>
        /// True Case
        /// </summary>
        TrueCase = 0x1000,

        /// <summary>
        /// Evaluate expression
        /// </summary>
        Evaluate = 0x2000,

        /// <summary>
        /// Sub directory.
        /// </summary>
        Subdir = 0x4000,
    } // Flags

    /// <summary>
    /// The class FileString contains functions to manipulate filename
    /// strings.
    /// </summary>
    [Obsolete("FileString is obsolte, use .Net Framework 2.0 File.IO classes!")]
    public class FileString
    {
        /// <summary>
        /// Internal filename.
        /// </summary>
        private readonly string fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileString"/> class.
        /// </summary>
        public FileString()
        {
            this.fileName = string.Empty;
        } // FileString()

        /// <summary>
        /// Initializes a new instance of the <see cref="FileString"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public FileString(string fileName)
        {
            this.fileName = fileName;
        } // FileString()

        /// <summary>
        /// This function returns a part of the path string object as a zero
        /// terminated string up to end of the path name.
        /// Parameters
        /// flags  contains the specification from which the part is returned. This
        /// part begins at the first position which is specified by one of the
        /// following part specifications:
        /// Drive ... returns the complete path.
        /// FilePath  returns the directory, fileName name and extend.
        /// FileName  returns the fileName name and the extend.
        /// Extend .. returns the fileName extend.
        /// Folder .. returns the fileName folder.
        /// Comments
        /// File name separators may be specified with a backslash (\) or a slash (/).
        /// </summary>
        /// <param name="partOptions">The part options.</param>
        /// <returns>
        /// This function returns a string with the specified path.
        /// </returns>
        public string GetPart(FileStringOptions partOptions)
        {
            return GetPart(this.fileName, partOptions);
        } // GetPart()

        /// <summary>
        /// This function returns a part of the path string object as a zero
        /// terminated string up to end of the path name.
        /// Parameters
        /// flags  contains the specification from which the part is returned. This
        /// part begins at the first position which is specified by one of the
        /// following part specifications:
        /// Drive ... returns the complete path.
        /// FilePath  returns the directory, fileName name and extend.
        /// FileName  returns the fileName name and the extend.
        /// Extend .. returns the fileName extend.
        /// Folder .. returns the fileName folder.
        /// Comments
        /// File name separators may be specified with a backslash (\) or a slash (/).
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="fileStringOptions">The file string options.</param>
        /// <returns>
        /// This function returns a string with the specified path.
        /// </returns>
        public static string GetPart(string file, FileStringOptions fileStringOptions)
        {
            string strStart = file;
            string strHelp;

            // at minimum one part must be specified
            Debug.Assert((fileStringOptions & FileStringOptions.PartMask) > 0, "Invalid flags!");

            // only true part specification flags permitted
            Debug.Assert((fileStringOptions & ~FileStringOptions.PartMask) == 0, "Invalid flags!");

            if ((strStart.Length == 0) || ((fileStringOptions & FileStringOptions.Drive) > 0))
            {
                // empty string or complete path => nothing to do
                return strStart;
            } // if

            if ((fileStringOptions & FileStringOptions.FilePath) > 0)
            {
                // search end of drive
                var slash = 0;
                var pos = 0;
                while (pos < strStart.Length)
                {
                    if (strStart[pos] == ':')
                    {
                        // colon only possible at end of drive: at next position starts path
                        strHelp = strStart.Substring(pos + 1);
                        return strHelp;
                    } // if

                    if (strStart[pos] == '\\' || strStart[pos] == '/')
                    {
                        // check if this is part of an UNC drive
                        if (slash == 3 || (slash == 0 && ((pos != 0)
                          || (strStart[pos + 1] != '\\' && strStart[pos + 1] != '/'))))
                        {
                            // after UNC drive or no drive specified => begin of directory
                            strHelp = strStart.Substring(pos);
                            return strHelp;
                        } // if

                        // otherwise: one slash more read
                        slash++;
                    } // if

                    pos++;
                } // while

                if (slash == 3)
                {
                    // end of line and three slashes read => is valid UNC drive
                    strHelp = strStart.Substring(pos);
                    return strHelp;
                } // if

                // no valid drive read => path begins with directory
                return strStart;
            } // if

            if ((fileStringOptions & FileStringOptions.Folder) == 0)
            {
                // start with search position at end of string
                var posEnd = strStart.Length;
                var pos = posEnd - 1;

                // only extend is searched
                var extend = ((fileStringOptions & FileStringOptions.FileName) == 0);
                while (pos >= 0)
                {
                    // begin of extend and reading of extend => return begin
                    if ((strStart[pos] == '.') && extend)
                    {
                        strHelp = strStart.Substring(pos);
                        return strHelp;
                    } // if

                    // slash or colon => end of directory/drive
                    if ((strStart[pos] == '\\') || (strStart[pos] == '/')
                      || (strStart[pos] == ':'))
                    {
                        // this is the begin of a fileName name but not of an extend
                        if (extend)
                        {
                            strStart = string.Empty;
                            return strStart;
                        } // if

                        strHelp = strStart.Substring(pos + 1);
                        return strHelp;
                    } // if

                    // check preceeding character
                    pos--;
                } // while

                if (extend)
                {
                    // begin of string and no '.' => never an extend
                    strStart = string.Empty;
                    return strStart;
                } // if
            }
            else if ((fileStringOptions & FileStringOptions.Folder) > 0)
            {
                // start with search position at end of string
                var posEnd = strStart.Length;
                var pos = posEnd - 1;
                while (pos >= 1)
                {
                    if (strStart[pos] == '\\' || strStart[pos] == '/')
                    {
                        break;
                    } // if

                    pos--;
                } // while

                return strStart.Substring(0, pos);
            } // if

            // otherwise: return start (no drive and/or directory specified)
            return strStart;
        } // GetPart()

        /// <summary>
        /// This function checks whether this fileName really exists.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is real file]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsRealFile()
        {
            return IsRealFile(this.fileName);
        } // IsRealFile()

        /// <summary>
        /// This function checks whether the specified fileName really exists.
        /// </summary>
        /// <param name="file">File to be checked</param>
        /// <returns>
        ///   <c>true</c> if [is real file] [the specified file]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsRealFile(string file)
        {
            return File.Exists(file);
        } // IsRealFile()

        /// <summary>
        /// Abbreviates the given filename.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="maxLength">Length of the max.</param>
        /// <param name="atLeastName">if set to <c>true</c> [at least name].</param>
        /// <returns>The abbreviated name.</returns>
        /// <code>
        /// lpszCanon = C:\MYAPP\DEBUGS\C\TESWIN.C
        /// cchMax   b   Result
        /// ------   -   ---------
        /// 1- 7    F   (empty)
        /// 1- 7    T   TESWIN.C
        /// 8-14    x   TESWIN.C
        /// 15-16    x   C:\...\TESWIN.C
        /// 17-23    x   C:\...\C\TESWIN.C
        /// 24-25    x   C:\...\DEBUGS\C\TESWIN.C
        /// 26+      x   C:\MYAPP\DEBUGS\C\TESWIN.C
        /// </code>
        public static string AbbreviateName(string name, int maxLength, bool atLeastName)
        {
            Debug.Assert(name != null, "Name must not be null");

            var strBase = name;
            var fullPath = strBase.Length;

            var strFileName = GetPart(name, FileStringOptions.FileName);
            var fileName = strFileName.Length;

            // If maxLength is more than enough to hold the full path name, we're done.
            // This is probably a pretty common case, so we'll put it first.
            if (maxLength >= fullPath)
            {
                return strBase;
            } // if

            // If cchMax isn't enough to hold at least the basename, we're done
            if (maxLength < fileName)
            {
                if (atLeastName)
                {
                    return strFileName;
                }

                // absolutely insufficient space
                return string.Empty;
            } // if

            // Calculate the length of the volume name.  Normally, this is two characters
            // (e.g., "C:", "D:", etc.), but for a UNC name, it could be more (e.g.,
            // "\\server\share").
            //
            // If maxLength isn't enough to hold at least <volume_name>\...\<base_name>, the
            // result is the base filename.
            var pos = 2;
            if ((strBase[0] == '\\') && (strBase[1] == '\\'))
            {
                // UNC pathname
                // First skip to the '\' between the server name and the share name,
                while (strBase[pos] != '\\')
                {
                    Debug.Assert(pos < strBase.Length, "Invalid position");
                    pos++;
                } // while
            } // if

            var volName = pos;
            if (maxLength < volName + 5 + fileName)
            {
                return strFileName;
            } // if

            // Now loop through the remaining directory components until something
            // of the form <volume_name>\...\<one_or_more_dirs>\<base_name> fits.
            //
            // Assert that the whole filename doesn't fit -- this should have been
            // handled earlier.
            var strCur = strBase.Substring(pos);
            Debug.Assert(volName + strCur.Length > maxLength, "Invalid length!");
            while (volName + 4 + strCur.Length > maxLength)
            {
                do
                {
                    Debug.Assert(pos < strBase.Length, "Invalid position!");
                    pos++;
                }
                while (strBase[pos] != '\\');
                strCur = strBase.Substring(pos);
            } // while

            // Form the resultant string and we're done.
            name = name.Substring(0, volName);
            name += "\\...";
            name += strCur;

            return name;
        } // AbbreviateName()
    } // FileString
} // Tethys.IO

// ============================
// Tethys: end of filestring.cs
// ============================