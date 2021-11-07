// ---------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Tethys">
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

    using Tethys.Forms;

    /// <summary>
    /// Application main form.
    /// </summary>
    public partial class MainForm : Form
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// The most recent file list class.
        /// </summary>
        private RecentFileList mtfl;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
        } // MainForm()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region UI HANDLING
        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the
        /// event data.</param>
        private void MainFormLoad(object sender, EventArgs e)
        {
            var regEntry = "Software\\Tethys\\" + Application.ProductName
                                                + "\\Recent File List";
            this.mtfl = new RecentFileList(regEntry, "File", 6, 30);
            this.mtfl.Click += this.MenuFileMruClick;
            this.mtfl.ReadList();
            this.mtfl.UpdateMenu(this.menuFileMru);
        } // MainFormLoad()

        /// <summary>
        /// Handles the FormClosing event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance
        /// containing the event data.</param>
        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // write MRU file list
                this.mtfl.WriteList();
            }
            catch
            {
                // Log.Error("Error storing application configuration", ex);
            } // catch
        }

        /// <summary>
        /// Handles the Click event of the menuFileOpen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void MenuFileOpenClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.InitialDirectory = ".";
            // ReSharper disable LocalizableElement
            openFileDialog.Filter = "All Files (*.*)|*.*";
            // ReSharper restore LocalizableElement
            openFileDialog.FilterIndex = 1;

            var result = openFileDialog.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                // aborted by user
                return;
            } // if

            this.NewMdiChild(openFileDialog.FileName);
        } // MenuFileOpenClick()

        /// <summary>
        /// Handles the Click event of the menuFileSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void MenuFileSaveClick(object sender, EventArgs e)
        {
            var child = (MdiChildForm)this.ActiveMdiChild;
            if (child != null)
            {
                // save the child data ...

                // add to MRU list
                this.mtfl.Add(child.Text);
                this.mtfl.UpdateMenu(this.menuFileMru);
            } // if
        } // MenuFileSaveClick()

        /// <summary>
        /// Handles the Click event of the menuFileClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void MenuFileCloseClick(object sender, EventArgs e)
        {
            var child = (MdiChildForm)this.ActiveMdiChild;
            if (child != null)
            {
                // add to MRU list
                this.mtfl.Add(child.Text);
                this.mtfl.UpdateMenu(this.menuFileMru);

                child.Close();
            } // if
        } // MenuFileCloseClick()

        /// <summary>
        /// Handles the Click event of the menuFileExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void MenuFileExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        } // MenuFileExitClick()

        /// <summary>
        /// The function is the handler for the most recently used (MRU) menu
        /// entries.
        /// </summary>
        /// <param name="sender">Originator of this event.</param>
        /// <param name="e">The EventArgs that contains the event data.</param>
        private void MenuFileMruClick(object sender, EventArgs e)
        {
            var tsmi = sender as ToolStripMenuItem;
            if (tsmi == null)
            {
                return;
            } // if

            // save and close any open documents
            this.MenuFileCloseClick(this, EventArgs.Empty);

            if (!File.Exists(tsmi.Text))
            {
                // remove from MRU list
                this.mtfl.Remove(tsmi.Text);
                this.mtfl.UpdateMenu(this.menuFileMru);

                // ReSharper disable LocalizableElement
                MessageBox.Show(
                    "File not found",
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            } // if

            this.NewMdiChild(tsmi.Text);
        } // MenuFileMruClick()
        #endregion // UI HANDLING

        //// ------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Creates a new MDI child.
        /// </summary>
        /// <param name="filename">The filename.</param>
        private void NewMdiChild(string filename)
        {
            var newChild = new MdiChildForm(filename);

            // Set the Parent Form of the Child window.
            newChild.MdiParent = this;
            newChild.WindowState = FormWindowState.Maximized;

            // display the new form.
            newChild.Show();
        } // NewMdiChild()
        #endregion // PRIVATE METHODS
    } // MainForm
} // RecentFileListDemo
