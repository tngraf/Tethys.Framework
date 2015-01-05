#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="SimpleAboutForm.cs" company="Tethys">
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
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;

    using Tethys.Reflection;

    /// <summary>
    /// The class SimpleAboutForm displays a form with the information
    /// what this application is about, who created it and what
    /// is the current version.
    /// </summary>
    public partial class SimpleAboutForm : Form
    {
        #region PRIVATE PROPERTIES

        /// <summary>
        /// Internal property: assembly that should be used to retrieve 
        /// information.
        /// </summary>
        private Assembly sourceAssembly;

        /// <summary>
        /// Internal property: resource path to the icon.
        /// </summary>
        private string iconPath;

        /// <summary>
        /// Internal property: extract ALL information from the assembly 
        /// attributes.
        /// </summary>
        private bool useAssemblyInfo = true;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES

        /// <summary>
        /// Gets or sets a value indicating whether to use Tethys VersionInfo for
        /// version display instead of TextProductVersion property.
        /// </summary>
        public bool UseVersionInfo { get; set; }

        /// <summary>
        /// Gets or sets the product version to be displayed.
        /// </summary>
        public string TextProductDescription
        {
            get { return labelDescription.Text; }
            set { labelDescription.Text = value; }
        } // TextProductDescription

        /// <summary>
        /// Gets or sets the product version to be displayed.
        /// </summary>
        public string TextProductVersion
        {
            get { return labelVersion.Text; }
            set { labelVersion.Text = value; }
        } // TextProductVersion

        /// <summary>
        /// Gets or sets the product version to be displayed.
        /// </summary>
        public string TextCopyright
        {
            get { return labelCopyright.Text; }
            set { labelCopyright.Text = value; }
        } // TextCopyright

        /// <summary>
        /// Gets or sets the assembly that should be used to retrieve information.
        /// </summary>
        public Assembly SourceAssembly
        {
            get { return this.sourceAssembly; }
            set { this.sourceAssembly = value; }
        } // SourceAssembly

        /// <summary>
        /// Gets or sets the resource path to the icon.
        /// </summary>
        public string IconPath
        {
            get { return this.iconPath; }
            set { this.iconPath = value; }
        } // IconPath

        /// <summary>
        /// Gets or sets a value indicating whether to extract ALL information
        /// from the assembly attributes.
        /// </summary>
        public bool UseAssemblyInfo
        {
            get { return this.useAssemblyInfo; }
            set { this.useAssemblyInfo = value; }
        } // UseAssemblyInfo
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleAboutForm"/> class.
        /// </summary>
        public SimpleAboutForm()
        {
            UseVersionInfo = true;
            InitializeComponent();
        } // SimpleAboutForm()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region UI MANAGEMENT
        /// <summary>
        /// Handler for the click event of the OK button. The dialog is closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing
        /// the event data.</param>
        private void BtnOkClick(object sender, EventArgs e)
        {
            this.Close();
        } // btnOk_Click()

        /// <summary>
        /// This function is called when the form is loaded. We resize the application
        /// icon and display the current version information.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void SimpleAboutFormLoad(object sender, EventArgs e)
        {
            // initialize icon display
            Debug.Assert(SourceAssembly != null, "Assembly must not be null!");
            Stream stream = SourceAssembly.GetManifestResourceStream(this.iconPath);

            Debug.Assert(stream != null, "Stream must not be null!");
            Icon = new Icon(stream, 32, 32);
            pictureBox.Image = Icon.ToBitmap();

            Version version = this.sourceAssembly.GetName().Version;

            if (this.useAssemblyInfo)
            {
                // window title
                if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "de")
                {
                    this.Text = "Info über " + Application.ProductName;
                }
                else
                {
                    this.Text = "Info about " + Application.ProductName;
                } // if

                // application name and description
                var description =
                  (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(this.sourceAssembly,
                  typeof(AssemblyDescriptionAttribute));
                labelDescription.Text = string.Format(CultureInfo.CurrentCulture, "{0} - {1}.",
                  Application.ProductName, description.Description);

                // version
                labelVersion.Text = "Version ";
                labelVersion.Text += VersionInfo.GetVersion(this.sourceAssembly, version,
                  Thread.CurrentThread.CurrentUICulture);
                labelVersion.Text += ".";

                // copyright
                var copyright =
                  (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(this.sourceAssembly,
                  typeof(AssemblyCopyrightAttribute));
                labelCopyright.Text = copyright.Copyright;
                labelCopyright.Text += ".";
            }
            else
            {
                if (this.UseVersionInfo)
                {
                    labelVersion.Text = "Version ";
                    labelVersion.Text += VersionInfo.GetVersion(this.sourceAssembly, version,
                      Thread.CurrentThread.CurrentCulture);
                    labelVersion.Text += ".";
                } // if
            } // if
        } // SimpleAboutForm_Load()
        #endregion // UI MANAGEMENT
    } // SimpleAboutForm
} // Tethys.Forms

// =======================================
// Tethys.Forms: end of SimpleAboutForm.cs
// =======================================
