// ---------------------------------------------------------------------------
// <copyright file="MdiChildForm.cs" company="Tethys">
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
            this.InitializeComponent();
        } // MdiChildForm()

        /// <summary>
        /// Initializes a new instance of the <see cref="MdiChildForm" /> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public MdiChildForm(string filename)
        {
            this.filename = filename;

            this.InitializeComponent();
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
