// ---------------------------------------------------------------------------
// <copyright file="ApplicationExceptionForm.cs" company="Tethys">
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
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// ApplicationExceptionForm implements a form to be shown to the user
    /// in case of an exception. This is more polite than the default exception
    /// handling.
    /// </summary>
    public partial class ApplicationExceptionForm : Form
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Internal property: culture info to be used for all output operations.
        /// </summary>
        private CultureInfo culture;

        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the culture to be used.
        /// </summary>
        public CultureInfo CultureInfo
        {
            get { return this.culture; }
            set { this.culture = value; }
        } // CultureInfo

        /// <summary>
        /// Gets or sets a value indicating whether to add assembly list at the
        /// end of the stack trace.
        /// </summary>
        public bool AddAssemblyList { get; set; }

        /// <summary>
        /// Gets or sets the exception text to be displayed.
        /// </summary>
        public string ExceptionText
        {
            get { return this.lblException.Text; }
            set { this.lblException.Text = value; }
        } // ExceptionText

        /// <summary>
        /// Gets or sets the description text ('An unhandled exception...').
        /// </summary>
        public string DescriptionText
        {
            get { return this.lblDescription.Text; }
            set { this.lblDescription.Text = value; }
        } // DescriptionText

        /// <summary>
        /// Gets or sets the details button text.
        /// </summary>
        public string ButtonDetailsText
        {
            get { return this.btnCheckDetails.Text; }
            set { this.btnCheckDetails.Text = value; }
        } // ButtonDetailsText

        /// <summary>
        /// Gets or sets the continue button text.
        /// </summary>
        public string ButtonContinueText
        {
            get { return this.btnContinue.Text; }
            set { this.btnContinue.Text = value; }
        } // ButtonContinueText

        /// <summary>
        /// Gets or sets the details button text.
        /// </summary>
        public string ButtonQuitText
        {
            get { return this.btnAbort.Text; }
            set { this.btnAbort.Text = value; }
        } // ButtonQuitText

        /// <summary>
        /// Gets or sets the stack text to be displayed.
        /// </summary>
        public string StackText
        {
            get { return this.txtDetails.Text; }
            set { this.txtDetails.Text = value; }
        } // ExceptionText

        /// <summary>
        /// Gets or sets the application assembly.
        /// </summary>
        public Assembly ApplicationAssembly { get; set; }
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ApplicationExceptionForm" /> class.
        /// </summary>
        /// <param name="applicationAssembly">The application assembly.</param>
        public ApplicationExceptionForm(Assembly applicationAssembly)
        {
            this.ApplicationAssembly = applicationAssembly;

            // Required for Windows Form Designer support
            this.InitializeComponent();

            // set default values
            this.culture = new CultureInfo("En-us");
        } // ApplicationExceptionForm()
        #endregion CONSTRUCTION

        //// ------------------------------------------------------------------

        #region DIALOG MANAGEMENT
        /// <summary>
        /// Is called when the form is loaded.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void ApplicationExceptionFormLoad(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;

            if ((this.culture.LCID & 0xff) == 0x07)
            {
                // de 0x0007 German
                // -> set german control texts
                this.lblDescription.Text = "Eine Ausnahme ist aufgetreten. Bei Auswahl von 'Weiter' wird die Anwendung " +
                                           "versuchen diesen Fehler zu ignorieren und fortfahren. Bei Auswahl von 'Abbrechen' wird " +
                                           "die Anwendung sofort beendet.";
                this.btnAbort.Text = "Abbrechen";
                this.btnContinue.Text = "Fortfahren";
                this.btnCheckDetails.Text = "Details";
            } // if

            // default: no details
            this.btnCheckDetails.Checked = false;
            this.CheckDetailsCheckedChanged(this, EventArgs.Empty);

            if (this.AddAssemblyList)
            {
                var sb = new StringBuilder(1000);
                sb.Append(this.txtDetails.Text);

                var asm = this.ApplicationAssembly ?? Assembly.GetEntryAssembly();
                var axx = asm.GetReferencedAssemblies();
                sb.Append("\r\n\r\n***** Loaded Assemblies *****\r\n\r\n");
                foreach (var t in axx)
                {
                    sb.AppendFormat(this.culture, "{0}\r\n", t.Name);
                    sb.AppendFormat(this.culture, "  Assembly Version: {0}\r\n", t.Version);
                    var asm2 = Assembly.Load(t);
                    sb.AppendFormat(this.culture, "  Code Base: {0}\r\n", asm2.Location);
                    sb.AppendFormat(this.culture, "--------------------\r\n");
                } // foeach

                this.txtDetails.Text = sb.ToString();
            } // if
        } // ApplicationExceptionForm_Load()

        /// <summary>
        /// Handles a change of the 'Show Details' checkbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance
        /// containing the event data.</param>
        private void CheckDetailsCheckedChanged(object sender, EventArgs e)
        {
            if (this.btnCheckDetails.Checked)
            {
                // enlarge form to show details
                this.ClientSize = new System.Drawing.Size(434, 272);
            }
            else
            {
                // shrink form to hide details
                this.ClientSize = new System.Drawing.Size(434, 128);
            } // if
        } // checkDetails_CheckedChanged()

        /// <summary>
        /// Handles a click on the Continue button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void BtnContinueClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
        } // btnContinue_Click()

        /// <summary>
        /// Handles a click on the Abort button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void BtnAbortClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        } // btnAbort_Click()
        #endregion // DIALOG MANAGEMENT
    } // ApplicationExceptionForm
} // Tethys.Forms

// ================================================
// Tethys.forms: end of ApplicationExceptionForm.cs
// ================================================
