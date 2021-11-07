// ---------------------------------------------------------------------------
// <copyright file="SHFileOperation.cs" company="Tethys">
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
    using System.Windows.Forms;

    using Tethys.Win32;

    /// <summary>
    /// SHFileOperation is the wrapper class for the Win32 Shell API function
    /// SHFileOperation().
    /// </summary>
    // ReSharper disable InconsistentNaming
    public static class SHFileOperation
    // ReSharper restore InconsistentNaming
    {
        /// <summary>
        /// Copies an existing file to a new file.
        /// </summary>
        /// <param name="sourceFile">fully qualified path of the file to be
        /// copied</param>
        /// <param name="destinationFile">fully qualified path of the
        /// destination</param>
        /// <returns>True if the operation succeeded and otherwise False.
        /// </returns>
        public static bool Copy(string sourceFile, string destinationFile)
        {
            var sfos = new SHFILEOPSTRUCT
            {
                wFunc = Win32Api.FO_COPY,
                fFlags = Win32Api.FOF_ALLOWUNDO,
                pFrom = sourceFile + "\0\0",
                pTo = destinationFile + "\0\0",
                lpszProgressTitle = Application.ProductName,
                hWnd = IntPtr.Zero,
                fAnyOperationsAborted = 0,
            };

            // set parameters
            var ret = Win32Api.SHFileOperation(ref sfos);

            return ((ret == 0) & (sfos.fAnyOperationsAborted != 1));
        } // Copy()

        /// <summary>
        /// Copies an existing file to a new file.
        /// </summary>
        /// <param name="sourceFile">fully qualified path of the file to be
        /// copied</param>
        /// <param name="destinationFile">fully qualified path of the
        /// destination</param>
        /// <param name="options"><c>ShFileOperation</c> options.</param>
        /// <returns>True if the operation succeeded and otherwise False.
        /// </returns>
        public static bool Copy(string sourceFile, string destinationFile, short options)
        {
            var sfos = new SHFILEOPSTRUCT
            {
                wFunc = Win32Api.FO_COPY,
                fFlags = options,
                pFrom = sourceFile + "\0\0",
                pTo = destinationFile + "\0\0",
                lpszProgressTitle = Application.ProductName,
                hWnd = IntPtr.Zero,
                fAnyOperationsAborted = 0,
            };

            // set parameters
            var ret = Win32Api.SHFileOperation(ref sfos);

            return ((ret == 0) & (sfos.fAnyOperationsAborted != 1));
        } // Copy()

        /// <summary>
        /// Renames the specified file.
        /// </summary>
        /// <param name="sourceFile">fully qualified path of the file to be
        /// renamed</param>
        /// <param name="destinationFile">new name/path</param>
        /// <returns>True if the operation succeeded and otherwise False.
        /// </returns>
        public static bool Rename(string sourceFile, string destinationFile)
        {
            var sfos = new SHFILEOPSTRUCT
            {
                wFunc = Win32Api.FO_RENAME,
                fFlags = Win32Api.FOF_ALLOWUNDO,
                pFrom = sourceFile + "\0\0",
                pTo = destinationFile + "\0\0",
                lpszProgressTitle = Application.ProductName,
                hWnd = IntPtr.Zero,
                fAnyOperationsAborted = 0,
            };

            // set parameters
            var ret = Win32Api.SHFileOperation(ref sfos);

            return ((ret != 0) & (sfos.fAnyOperationsAborted != 1));
        } // Rename()

        /// <summary>
        /// Renames the specified file.
        /// </summary>
        /// <param name="sourceFile">fully qualified path of the file to be
        /// renamed</param>
        /// <param name="destinationFile">new name/path</param>
        /// <param name="options"><c>ShFileOperation</c> options</param>
        /// <returns>True if the operation succeeded and otherwise False.
        /// </returns>
        public static bool Rename(string sourceFile, string destinationFile, short options)
        {
            var sfos = new SHFILEOPSTRUCT
            {
                wFunc = Win32Api.FO_RENAME,
                fFlags = options,
                pFrom = sourceFile + "\0\0",
                pTo = destinationFile + "\0\0",
                lpszProgressTitle = Application.ProductName,
                hWnd = IntPtr.Zero,
                fAnyOperationsAborted = 0,
            };

            // set parameters
            var ret = Win32Api.SHFileOperation(ref sfos);

            return ((ret == 0) & (sfos.fAnyOperationsAborted != 1));
        } // Rename()

        /// <summary>
        /// Moves a specified file to a new location, providing the option
        /// to specify a new file name.
        /// </summary>
        /// <param name="sourceFile">fully qualified path of the file to be
        /// moved</param>
        /// <param name="destinationFile">fully qualified path of the
        /// destination</param>
        /// <returns>True if the operation succeeded and otherwise False.
        /// </returns>
        public static bool Move(string sourceFile, string destinationFile)
        {
            var sfos = new SHFILEOPSTRUCT
            {
                wFunc = Win32Api.FO_MOVE,
                fFlags = Win32Api.FOF_ALLOWUNDO,
                pFrom = sourceFile + "\0\0",
                pTo = destinationFile + "\0\0",
                lpszProgressTitle = Application.ProductName,
                hWnd = IntPtr.Zero,
                fAnyOperationsAborted = 0,
            };

            // set parameters
            var ret = Win32Api.SHFileOperation(ref sfos);

            return ((ret == 0) & (sfos.fAnyOperationsAborted != 1));
        } // Move()

        /// <summary>
        /// Moves a specified file to a new location, providing the option
        /// to specify a new file name.
        /// </summary>
        /// <param name="sourceFile">fully qualified path of the file to be
        /// moved</param>
        /// <param name="destinationFile">fully qualified path of the
        /// destination</param>
        /// <param name="options"><c>ShFileOperation</c> options</param>
        /// <returns>True if the operation succeeded and otherwise False.
        /// </returns>
        public static bool Move(string sourceFile, string destinationFile, short options)
        {
            var sfos = new SHFILEOPSTRUCT
            {
                wFunc = Win32Api.FO_MOVE,
                fFlags = options,
                pFrom = sourceFile + "\0\0",
                pTo = destinationFile + "\0\0",
                lpszProgressTitle = Application.ProductName,
                hWnd = IntPtr.Zero,
                fAnyOperationsAborted = 0,
            };

            // set parameters
            var ret = Win32Api.SHFileOperation(ref sfos);

            return ((ret == 0) & (sfos.fAnyOperationsAborted != 1));
        } // Move()

        /// <summary>
        /// Deletes the file specified by the fully qualified path.
        /// An exception is not thrown if the specified file does not exist.
        /// </summary>
        /// <param name="path">fully qualified path of the file to be deleted
        /// </param>
        /// <returns>True if the operation succeeded and otherwise False.
        /// </returns>
        public static bool Delete(string path)
        {
            var sfos = new SHFILEOPSTRUCT
            {
                wFunc = Win32Api.FO_DELETE,
                fFlags = Win32Api.FOF_ALLOWUNDO,
                pFrom = path + "\0\0",
                pTo = "\0\0",
                lpszProgressTitle = Application.ProductName,
                hWnd = IntPtr.Zero,
                fAnyOperationsAborted = 0,
            };

            // set parameters
            var ret = Win32Api.SHFileOperation(ref sfos);

            return ((ret == 0) & (sfos.fAnyOperationsAborted != 1));
        } // Delete()

        /// <summary>
        /// Deletes the file specified by the fully qualified path.
        /// An exception is not thrown if the specified file does not exist.
        /// </summary>
        /// <param name="path">fully qualified path of the file to be deleted
        /// </param>
        /// <param name="options"><c>ShFileOperation</c> options</param>
        /// <returns>True if the operation succeeded and otherwise False.
        /// </returns>
        public static bool Delete(string path, short options)
        {
            var sfos = new SHFILEOPSTRUCT
            {
                wFunc = Win32Api.FO_DELETE,
                fFlags = options,
                pFrom = path + "\0\0",
                pTo = "\0\0",
                lpszProgressTitle = Application.ProductName,
                hWnd = IntPtr.Zero,
                fAnyOperationsAborted = 0,
            };

            // set parameters
            var ret = Win32Api.SHFileOperation(ref sfos);

            return ((ret == 0) & (sfos.fAnyOperationsAborted != 1));
        } // Delete()
    } // SHFileOperation()
} // Tethys.IO
