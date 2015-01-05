#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="Extensions.cs" company="Tethys">
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
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// Extension methods and other support methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Abbreviates the specified file path.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="maxLength">Length of the max.</param>
        /// <param name="minimumName">if set to <c>true</c> at least the name
        /// is returned.</param>
        /// <returns>
        /// The abbreviated file path.
        /// </returns>
        /// <code>
        /// name = C:\MYAPP\DEBUGS\C\TESWIN.C
        /// maxLength   b   Result
        /// ---------   -   ---------
        /// 1- 7        F   (empty)
        /// 1- 7        T   TESWIN.C
        /// 8-14        x   TESWIN.C
        /// 15-16       x   C:\...\TESWIN.C
        /// 17-23       x   C:\...\C\TESWIN.C
        /// 24-25       x   C:\...\DEBUGS\C\TESWIN.C
        /// 26+         x   C:\MYAPP\DEBUGS\C\TESWIN.C
        /// </code>
        public static string AbbreviatePath(string name,
          int maxLength, bool minimumName)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            } // if

            var strBase = name;
            var fullPath = strBase.Length;

            var fileName = Path.GetFileName(name);
            if (string.IsNullOrEmpty(fileName))
            {
                return string.Empty;
            } // if
            var nameLength = fileName.Length;

            // If maxLength is more than enough to hold the full path name, 
            // we're done. This is probably a pretty common case, so we'll 
            // put it first.
            if (maxLength >= fullPath)
            {
                return strBase;
            } // if

            // If cchMax isn't enough to hold at least the basename, we're done
            if (maxLength < nameLength)
            {
                if (minimumName)
                {
                    return fileName;
                } // if

                // absolutely insufficent space
                return string.Empty;
            } // if

            // Calculate the length of the volume name.  Normally, this is two
            // characters (e.g., "C:", "D:", etc.), but for a UNC name, it 
            // could be more (e.g., "\\server\share").
            //
            // If maxLength isn't enough to hold at least 
            // <volume_name>\...\<base_name>, the result is the base filename.
            var pos = 2;
            if ((strBase[0] == '\\') && (strBase[1] == '\\'))
            {
                // UNC pathname
                // First skip to the '\' between the server name and the share name,
                while (strBase[pos] != '\\')
                {
                    Debug.Assert(pos < strBase.Length, "invalid position");
                    pos++;
                } // while
            } // if

            var volNamePos = pos;
            if (maxLength < volNamePos + 5 + nameLength)
            {
                return fileName;
            } // if

            // Now loop through the remaining directory components until something
            // of the form <volume_name>\...\<one_or_more_dirs>\<base_name> fits.
            //
            // Assert that the whole filename doesn't fit -- this should have been
            // handled earlier.
            var strCur = strBase.Substring(pos);
            Debug.Assert(volNamePos + strCur.Length > maxLength, "invalid position");
            while (volNamePos + 4 + strCur.Length > maxLength)
            {
                do
                {
                    Debug.Assert(pos < strBase.Length, "invalid position");
                    pos++;
                }
                while (strBase[pos] != '\\');
                strCur = strBase.Substring(pos);
            } // while

            // Form the resultant string and we're done.
            name = name.Substring(0, volNamePos);
            name += "\\...";
            name += strCur;

            return name;
        } // AbbreviateName()
    } // Extensions
} // Tethys.Forms
