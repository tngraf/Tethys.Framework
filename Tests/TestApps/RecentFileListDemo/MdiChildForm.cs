#region Header
// ---------------------------------------------------------------------------
// Tethys.Forms - RecentFileListDemo
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
// <copyright file="MdiChildForm.cs" company="Thomas Graf">
// Copyright  1998 - 2013 by Thomas Graf
//            Email: tngraf@gmx.de
//            See the file "License.rtf" for information on usage and 
//            redistribution of this file and for a DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 4.00.00.00 of 13Apr14
// Project .. Tethys.Forms
// Creater .. Thomas Graf (tg)
// System ... Microsoft .Net Framework 4.5
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 03Nov22 3.00.02.00 tg: initial version
//
// ---------------------------------------------------------------------------
#endregion

namespace RecentFileListDemo
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// MDI child form.
    /// </summary>
    public partial class MdiChildForm : Form
    {
        /// <summary>
        /// Name of the file to display.
        /// </summary>
        private readonly string filename;

        /// <summary>
        /// Initializes a new instance of the <see cref="MdiChildForm"/> class.
        /// </summary>
        public MdiChildForm()
        {
            InitializeComponent();
        } // MdiChildForm()

        /// <summary>
        /// Initializes a new instance of the <see cref="MdiChildForm" /> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public MdiChildForm(string filename)
        {
            this.filename = filename;

            InitializeComponent();
        } // MdiChildForm()

        /// <summary>
        /// MDIs the child form load.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void MdiChildFormLoad(object sender, EventArgs e)
        {
            this.Text = this.filename;

            using (var reader = new StreamReader(this.filename))
            {
                this.txtBox.Text = reader.ReadToEnd();
            } // using
        } // MdiChildFormLoad()
    } // MdiChildForm
} // RecentFileListDemo
