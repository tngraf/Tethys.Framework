// ---------------------------------------------------------------------------
// <copyright file="SimpleAboutForm.cs" company="Tethys">
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
    using System.Diagnostics;
    using System.Drawing;
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
        /// Internal property: resource path to the icon.
        /// </summary>
        private string iconPath;

        /// <summary>
        /// Internal property: extract ALL information from the assembly.
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
            get { return this.labelDescription.Text; }
            set { this.labelDescription.Text = value; }
        } // TextProductDescription

        /// <summary>
        /// Gets or sets the product version to be displayed.
        /// </summary>
        public string TextProductVersion
        {
            get { return this.labelVersion.Text; }
            set { this.labelVersion.Text = value; }
        } // TextProductVersion

        /// <summary>
        /// Gets or sets the product version to be displayed.
        /// </summary>
        public string TextCopyright
        {
            get { return this.labelCopyright.Text; }
            set { this.labelCopyright.Text = value; }
        } // TextCopyright

        /// <summary>
        /// Gets or sets the assembly that should be used to retrieve information.
        /// </summary>
        public Assembly SourceAssembly { get; set; }

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
            this.UseVersionInfo = true;
            this.InitializeComponent();
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
            Debug.Assert(this.SourceAssembly != null, "Assembly must not be null!");
            var stream = this.SourceAssembly.GetManifestResourceStream(this.iconPath);

            Debug.Assert(stream != null, "Stream must not be null!");
            this.Icon = new Icon(stream, 32, 32);
            this.pictureBox.Image = this.Icon.ToBitmap();

            var version = this.SourceAssembly.GetName().Version;

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
                var description = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(
                      this.SourceAssembly,
                      typeof(AssemblyDescriptionAttribute));
                this.labelDescription.Text = $"{Application.ProductName} - {description?.Description}.";

                // version
                this.labelVersion.Text = "Version ";
                this.labelVersion.Text += VersionInfo.GetVersion(
                    this.SourceAssembly,
                    version,
                    Thread.CurrentThread.CurrentUICulture);
                this.labelVersion.Text += ".";

                // copyright
                var copyright = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(
                      this.SourceAssembly,
                      typeof(AssemblyCopyrightAttribute));
                this.labelCopyright.Text = copyright?.Copyright;
                this.labelCopyright.Text += ".";
            }
            else
            {
                if (this.UseVersionInfo)
                {
                    this.labelVersion.Text = "Version ";
                    this.labelVersion.Text += VersionInfo.GetVersion(
                        this.SourceAssembly,
                        version,
                        Thread.CurrentThread.CurrentCulture);
                    this.labelVersion.Text += ".";
                } // if
            } // if
        } // SimpleAboutForm_Load()
        #endregion // UI MANAGEMENT
    } // SimpleAboutForm
} // Tethys.Forms

// =======================================
// Tethys.Forms: end of SimpleAboutForm.cs
// =======================================
