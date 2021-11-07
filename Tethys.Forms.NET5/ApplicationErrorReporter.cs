// ---------------------------------------------------------------------------
// <copyright file="ApplicationErrorReporter.cs" company="Tethys">
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
    using System.Globalization;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// The ApplicationErrorReporter class is a helper class to handle
    /// application exception not caught somewhere else.
    /// We need a class because event handling methods can't be static.
    /// </summary>
    public class ApplicationErrorReporter
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Error text.
        /// </summary>
        private string textSevereError;
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the culture specific text for 'Severe Error'.
        /// </summary>
        public string TextSevereError
        {
            get { return this.textSevereError; }
            set { this.textSevereError = value; }
        }

        /// <summary>
        /// Gets or sets the application assembly.
        /// </summary>
        public Assembly ApplicationAssembly { get; set; }
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ApplicationErrorReporter" /> class.
        /// </summary>
        /// <param name="applicationAssembly">The application assembly.</param>
        public ApplicationErrorReporter(Assembly applicationAssembly)
        {
            this.ApplicationAssembly = applicationAssembly;
            this.textSevereError = "Severe Error";
        } // ApplicationErrorReporter()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Handle the exception event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="threadExceptionEventArgs">thread exception.</param>
        public void HandleThreadException(
            object sender,
            ThreadExceptionEventArgs threadExceptionEventArgs)
        {
            var result = DialogResult.Cancel;
            try
            {
                result = this.ShowThreadExceptionDialog(
                    threadExceptionEventArgs.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show(
                        this.textSevereError,
                        this.textSevereError,
                        MessageBoxButtons.AbortRetryIgnore,
                        MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                } // finally
            } // catch

            if (result == DialogResult.Abort)
            {
                Application.Exit();
            } // if
        } // OnThreadException()
        #endregion // PUBLIC METHODS

        //// ---------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Display a dialog indicating the exception to the user.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <returns>A dialog result.</returns>
        private DialogResult ShowThreadExceptionDialog(Exception e)
        {
            var form
              = new ApplicationExceptionForm(this.ApplicationAssembly);
            form.ExceptionText = e.Message;
            form.StackText = string.Format(
                CultureInfo.CurrentCulture,
                "Application = {0}\r\nVersion = {1}\r\nPath = {2}\r\n\r\n{3}:{4}\r\n{5}",
                Application.ProductName,
                Application.ProductVersion,
                Application.ExecutablePath,
                e.GetType(),
                e.Message,
                e.StackTrace);
            form.AddAssemblyList = true;
            return form.ShowDialog();
        } // ShowThreadExceptionDialog()
        #endregion // PRIVATE METHODS
    } // ApplicationErrorReporter
} // Tethys.Forms

// ================================================
// Tethys.forms: end of ApplicationErrorReporter.cs
// ================================================
