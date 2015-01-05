#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="TethysCustomExceptionHandler.cs" company="Tethys">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// The Error Handler class
    /// We need a class because event handling methods can't be static.
    /// </summary>
    /// <remarks>
    /// This file contains the implementation of the class TethysCustomExceptionHandler
    /// which supplies a new general exception handler for .Net applications. 
    /// If this exception handler is installed in an application by adding the 
    /// following lines of code to Main():
    /// <code>
    /// TethysCustomExceptionHandler eh = new TethysCustomExceptionHandler();
    /// Application.ThreadException +=
    /// new ThreadExceptionEventHandler(eh.OnThreadException);
    /// </code>
    /// you will get your own final exception handler instead of a crashed
    /// application.
    /// </remarks>
    public class TethysCustomExceptionHandler
    {
        /// <summary>
        /// Handle the exception event
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="ThreadExceptionEventArgs"/> instance
        /// containing the event data.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions",
          Justification = "Suppression is ok - we will never have RTL languages here.")]
        [SuppressMessage("Microsoft.Design",
          "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Ok here.")]
        public void OnThreadException(object sender, ThreadExceptionEventArgs eventArgs)
        {
            var result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog(eventArgs.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Schwerwiegender Fehler", "Schwerwiegender Fehler",
                      MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            } // catch

            if (result == DialogResult.Abort)
            {
                Application.Exit();
            } // if
        } // OnThreadException()

        /// <summary>
        /// Display a dialog indicating the exception to the user.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns>
        /// The dialog result.
        /// </returns>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions",
          Justification = "Suppression is ok - we will never have RTL languages here.")]
        private static DialogResult ShowThreadExceptionDialog(Exception e)
        {
            string errorMsg = "Fehler. Wenden Sie sich mit folgenden Informationen an den Administrator:\n\n";
            errorMsg = errorMsg + e.Message + "\n\nStapelberwachung:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, "Anwendungsfehler",
              MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
        } // ShowThreadExceptionDialog()
    } // TethysCustomExceptionHandler
} // Tethys

// ==============================================
// Tethys: end of TethysCustomExceptionHandler.cs
// ==============================================