#region Header
// ---------------------------------------------------------------------------
// Tethys.Forms - RecentFileListDemo
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
// <copyright file="MainForm.cs" company="Thomas Graf">
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

        #region PUBLIC PROPERTIES
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
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
            string regEntry = "Software\\Tethys\\" + Application.ProductName
              + "\\Recent File List";
            this.mtfl = new RecentFileList(regEntry, "File", 6, 30);
            this.mtfl.Click += MenuFileMruClick;
            this.mtfl.ReadList();
            this.mtfl.UpdateMenu(menuFileMru);
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
            // ReSharper disable EmptyGeneralCatchClause
            catch
            // ReSharper restore EmptyGeneralCatchClause
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

            NewMdiChild(openFileDialog.FileName);
        } // MenuFileOpenClick()

        /// <summary>
        /// Handles the Click event of the menuFileSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void MenuFileSaveClick(object sender, EventArgs e)
        {
            var child = (MdiChildForm)ActiveMdiChild;
            if (child != null)
            {
                // save the child data ...

                // add to MRU list
                this.mtfl.Add(child.Text);
                this.mtfl.UpdateMenu(menuFileMru);
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
            var child = (MdiChildForm)ActiveMdiChild;
            if (child != null)
            {
                // add to MRU list
                this.mtfl.Add(child.Text);
                this.mtfl.UpdateMenu(menuFileMru);

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
            MenuFileCloseClick(this, EventArgs.Empty);

            if (!File.Exists(tsmi.Text))
            {
                // remove from MRU list
                this.mtfl.Remove(tsmi.Text);
                this.mtfl.UpdateMenu(menuFileMru);

                // ReSharper disable LocalizableElement
                MessageBox.Show("File not found", Application.ProductName,
                    // ReSharper restore LocalizableElement
                  MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            } // if

            NewMdiChild(tsmi.Text);
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
