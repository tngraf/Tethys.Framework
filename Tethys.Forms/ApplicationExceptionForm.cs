#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="ApplicationExceptionForm.cs" company="Tethys">
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

        /// <summary>
        /// Flag "add assembly list at the end of the stack trace".
        /// </summary>
        private bool addAssemblyList;
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
        public bool AddAssemblyList
        {
            get { return this.addAssemblyList; }
            set { this.addAssemblyList = value; }
        } // AddAssemblyList

        /// <summary>
        /// Gets or sets the exception text to be displayed.
        /// </summary>
        public string ExceptionText
        {
            get { return lblException.Text; }
            set { lblException.Text = value; }
        } // ExceptionText

        /// <summary>
        /// Gets or sets the description text ('An unhandled exception...').
        /// </summary>
        public string DescriptionText
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        } // DescriptionText

        /// <summary>
        /// Gets or sets the details button text
        /// </summary>
        public string ButtonDetailsText
        {
            get { return btnCheckDetails.Text; }
            set { btnCheckDetails.Text = value; }
        } // ButtonDetailsText

        /// <summary>
        /// Gets or sets the continue button text
        /// </summary>
        public string ButtonContinueText
        {
            get { return btnContinue.Text; }
            set { btnContinue.Text = value; }
        } // ButtonContinueText

        /// <summary>
        /// Gets or sets the details button text
        /// </summary>
        public string ButtonQuitText
        {
            get { return btnAbort.Text; }
            set { btnAbort.Text = value; }
        } // ButtonQuitText

        /// <summary>
        /// Gets or sets the stack text to be displayed.
        /// </summary>
        public string StackText
        {
            get { return txtDetails.Text; }
            set { txtDetails.Text = value; }
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
            ApplicationAssembly = applicationAssembly;

            // Required for Windows Form Designer support
            InitializeComponent();

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
                lblDescription.Text = "Eine Ausnahme ist aufgetreten. Bei Auswahl von 'Weiter' wird die Anwendung " +
                  "versuchen diesen Fehler zu ignorieren und fortfahren. Bei Auswahl von 'Abbrechen' wird " +
                  "die Anwendung sofort beendet.";
                btnAbort.Text = "Abbrechen";
                btnContinue.Text = "Fortfahren";
                btnCheckDetails.Text = "Details";
            } // if

            // default: no details
            btnCheckDetails.Checked = false;
            this.CheckDetailsCheckedChanged(this, EventArgs.Empty);

            if (this.addAssemblyList)
            {
                var sb = new StringBuilder(1000);
                sb.Append(txtDetails.Text);

                var asm = this.ApplicationAssembly 
                    ?? Assembly.GetEntryAssembly();
                var axx = asm.GetReferencedAssemblies();
                sb.Append("\r\n\r\n***** Loaded Assemblies *****\r\n\r\n");
                for (int i = 0; i < axx.Length; i++)
                {
                    sb.AppendFormat(this.culture, "{0}\r\n", axx[i].Name);
                    sb.AppendFormat(this.culture, "  Assembly Version: {0}\r\n", 
                        axx[i].Version);
                    var asm2 = Assembly.Load(axx[i]);
                    sb.AppendFormat(this.culture, "  Code Base: {0}\r\n",
                        asm2.CodeBase);
                    sb.AppendFormat(this.culture, "--------------------\r\n");
                } // for

                txtDetails.Text = sb.ToString();
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
            if (btnCheckDetails.Checked)
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
            DialogResult = DialogResult.Ignore;
        } // btnContinue_Click()

        /// <summary>
        /// Handles a click on the Abort button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void BtnAbortClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        } // btnAbort_Click()
        #endregion // DIALOG MANAGEMENT
    } // ApplicationExceptionForm
} // Tethys.Forms

// ================================================
// Tethys.forms: end of ApplicationExceptionForm.cs
// ================================================
