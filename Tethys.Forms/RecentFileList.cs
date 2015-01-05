#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="RecentFileList.cs" company="Tethys">
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
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;

    using Microsoft.Win32;

    /// <summary>
    /// The class RecentFileList which implements the support for
    /// a "most recently used files" list in C# projects.
    /// </summary>
    public class RecentFileList
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Placeholder character.
        /// </summary>
        private const string PlaceHolder = "-";

        /// <summary>
        /// Size of the MRU list
        /// </summary>
        private readonly int listSize;

        /// <summary>
        /// contents of the MRU list.
        /// </summary>
        private readonly string[] mruItemText;

        /// <summary>
        /// menu items of the MRU list.
        /// </summary>
        private readonly MenuItem[] menuItems;

        /// <summary>
        /// menu items of the MRU list.
        /// </summary>
        private readonly ToolStripMenuItem[] toolstripItems;

        /// <summary>
        /// section name where to store the list in the registry.
        /// </summary>
        private readonly string sectionName;

        /// <summary>
        /// Format string to be used for the names of the entries
        /// stored in the registry.
        /// </summary>
        private readonly string entryFormat;

        /// <summary>
        /// Maximum length, in characters, available for the menu display
        /// of a filename in the MRU file list.
        /// </summary>
        private readonly int maxDisplayLength;

        /// <summary>
        /// Flag "menu items added"
        /// </summary>
        private bool initDone;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Click event.
        /// </summary>
        public event EventHandler Click;

        /// <summary>
        /// Gets the current size (number of entries) of the MRU list.
        /// </summary>
        public int Size
        {
            get { return this.listSize; }
        } // Size

        /// <summary>
        /// Indexer for recent file list items.
        /// </summary>
        /// <value>
        /// The <see cref="System.String"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>The item with the specified index.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// index;index out of range
        /// or
        /// index;index out of range
        /// </exception>
        public string this[int index]
        {
            get
            {
                if ((index < 0) || (index > this.listSize))
                {
                    throw new ArgumentOutOfRangeException("index",
                        // ReSharper disable LocalizableElement
                      "index out of range");
                    // ReSharper restore LocalizableElement
                } // if
                return this.mruItemText[index];
            }

            set
            {
                if ((index < 0) || (index > this.listSize))
                {
                    throw new ArgumentOutOfRangeException("index",
                        // ReSharper disable LocalizableElement
                      "index out of range");
                    // ReSharper restore LocalizableElement
                } // if
                this.mruItemText[index] = value;
            }
        } // this[]
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="RecentFileList"/> class.
        /// </summary>
        /// <param name="section">Points to the name of the section of the
        /// registry or the application's INI file where the MRU file list is
        /// read and/or written.</param>
        /// <param name="entryFormat">Points to a format string to be used for
        /// the names of the entries stored in the registry or the application's
        /// INI file.</param>
        /// <param name="maxSize">Maximum number of files in the MRU file list.
        /// </param>
        /// <param name="maxDisplayLength">Maximum length, in characters,
        /// available for the menu display of a filename in the MRU file list.
        /// </param>
        /// <remarks>
        /// The format string pointed to by entryFormat should contain "{0}",
        /// which will be used for substituting the index of each MRU item.
        /// For example, if the format string is "file%d" then the entries will
        /// be named file0, file1, and so on.
        /// </remarks>
        public RecentFileList(string section,
          string entryFormat, int maxSize, int maxDisplayLength)
        {
            Debug.Assert(maxSize > 0, "Invalid size!");
            this.mruItemText = new string[maxSize];
            this.menuItems = new MenuItem[maxSize];
            this.toolstripItems = new ToolStripMenuItem[maxSize];
            this.sectionName = section;
            this.entryFormat = entryFormat;
            this.listSize = maxSize;
            this.maxDisplayLength = maxDisplayLength;
        } // RecentFileList()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Adds the file whose path is given in file to the most recently used
        /// (MRU) file list.
        /// </summary>
        /// <param name="file">Pathname to be added to the list. </param>
        /// <remarks>
        /// The file name will be added to the top of the MRU list. If the file
        /// name already exists in the MRU list, it will be moved to the top.
        /// </remarks>
        public void Add(string file)
        {
            // fully qualify the path name
            string temp = file;

            // update the MRU list, if an existing MRU string matches file name
            int mru;
            for (mru = 0; mru < this.listSize - 1; mru++)
            {
                if (this.mruItemText[mru] == temp)
                {
                    // iMRU will point to matching entry
                    break;
                } // if
            } // for

            // move MRU strings before this one down
            for (; mru > 0; mru--)
            {
                Debug.Assert(mru > 0, "invalid mru!");
                Debug.Assert(mru < this.listSize, "invalid mru!");
                this.mruItemText[mru] = this.mruItemText[mru - 1];
            } // for
            // place this one at the beginning
            this.mruItemText[0] = temp;
        } // Add()

        /// <summary>
        /// Obtains a display name for a file in the MRU file list, for use in
        /// the menu display of the MRU list.
        /// </summary>
        /// <param name="name">Full path of the file whose name is to be
        /// displayed in the menu list of MRU files.</param>
        /// <param name="index">The index.</param>
        /// <param name="curDirectory">String holding the current directory.</param>
        /// <returns>
        /// Full path of the file whose name is to be
        /// displayed in the menu list of MRU files or an abbreviated path.
        /// </returns>
        /// <remarks>
        /// If the file is in the current directory, the function leaves the
        /// directory off the display. If the filename is too long, the directory
        /// and extension are stripped. If the filename is still too long, the
        /// display name is set to an empty string unless bAtLeastName is nonzero.
        /// </remarks>
        public string GetDisplayName(string name, int index,
          string curDirectory)
        {
            Debug.Assert(index < this.listSize, "invalid index!");
            if (this.mruItemText[index].Length == 0)
            {
                // no filename available
                name = string.Empty;
                return name;
            } // if

            string strDir = Path.GetDirectoryName(this.mruItemText[index]);
            if (strDir == curDirectory)
            {
                name = Path.GetFileName(this.mruItemText[index]);
            }
            else if (this.maxDisplayLength > 0)
            {
                name = Extensions.AbbreviatePath(name, this.maxDisplayLength,
                    true);
            } // if
            return name;
        } // GetDisplayName()

        /// <summary>
        /// Reads the most recently used (MRU) file list from the registry. 
        /// </summary>
        public void ReadList()
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(
                this.sectionName);
            if (regkey == null)
            {
                // list does not exist
                // -> empty
                return;
            } // if

            for (int mru = 0; mru < this.listSize; mru++)
            {
                string strEntry = this.entryFormat + (mru + 1);
                this.mruItemText[mru] = (string)regkey.GetValue(strEntry, 
                    string.Empty);
            } // for
        } // ReadList()

        /// <summary>
        /// Removes a file from the MRU file list.
        /// </summary>
        /// <param name="index">Zero-based index of the file to be removed from
        /// the most recently used (MRU) file list.</param>
        public void Remove(int index)
        {
            Debug.Assert(index >= 0, "invalid index!");
            Debug.Assert(index < this.listSize, "invalid index!");

            this.mruItemText[index] = string.Empty;
            int mru;
            for (mru = index; mru < this.listSize - 1; mru++)
            {
                this.mruItemText[mru] = this.mruItemText[mru + 1];
            } // for

            Debug.Assert(mru < this.listSize, "invalid mru!");
            this.mruItemText[mru] = string.Empty;
        } // Remove()

        /// <summary>
        /// Removes a file from the MRU file list.
        /// </summary>
        /// <param name="file">Full path of the file to be removed</param>
        public void Remove(string file)
        {
            for (int mru = 0; mru < this.listSize - 1; mru++)
            {
                if (this.mruItemText[mru] == file)
                {
                    this.Remove(mru);
                    break;
                } // if
            } // for
        } // Remove()

        /// <summary>
        /// Updates the menu display of the MRU file list.
        /// </summary>
        /// <param name="menuItemStart">The menu item start.</param>
        public void UpdateMenu(MenuItem menuItemStart)
        {
            // get main menu
            MainMenu menuMain = menuItemStart.GetMainMenu();
            Debug.Assert(menuMain != null, "no main menu found!");

            // get parent
            var parent = (MenuItem)menuItemStart.Parent;
            Debug.Assert(parent != null, "no parent found!");

            // determine position within parent.items
            int indexStart = parent.MenuItems.IndexOf(menuItemStart);

            if (!this.initDone)
            {
                this.initDone = true;
                for (int mru = 0; mru < this.listSize; mru++)
                {
                    this.menuItems[mru] = menuItemStart.CloneMenu();
                    var ci = new CultureInfo("de-DE");
                    this.menuItems[mru].Text = mru.ToString(ci);
                    parent.MenuItems.Add(indexStart++, this.menuItems[mru]);
                    this.menuItems[mru].Visible = false;
                } // for
            } // if

            if ((this.mruItemText[0] != null) 
                && (this.mruItemText[0].Length != 0))
            {
                for (int mru = 0; mru < this.listSize; mru++)
                {
                    if ((this.mruItemText[mru] != null) 
                        && (this.mruItemText[mru].Length > 0))
                    {
                        this.menuItems[mru].Text = this.mruItemText[mru];
                        this.menuItems[mru].Visible = true;
                    }
                    else
                    {
                        this.menuItems[mru].Visible = false;
                    } // if
                } // for
                // hide placeholder
                menuItemStart.Visible = false;

                // show separator following to placeholder (if any)
                if (parent.MenuItems[indexStart + 1].Text == PlaceHolder)
                {
                    parent.MenuItems[indexStart + 1].Visible = true;
                } // if
            }
            else
            {
                // special case: this MRU list is empty
                // hide placeholder
                menuItemStart.Visible = false;

                // hide separator following to placeholder (if any)
                if (parent.MenuItems[indexStart + 1].Text == PlaceHolder)
                {
                    parent.MenuItems[indexStart + 1].Visible = false;
                } // if
            } // if
        } // UpdateMenu()

        /// <summary>
        /// Updates the menu display of the MRU file list.
        /// </summary>
        /// <param name="menuItemStart">The menu item start.</param>
        public void UpdateMenu(ToolStripMenuItem menuItemStart)
        {
            // get parent
            var parent = (ToolStripMenuItem)menuItemStart.OwnerItem;
            Debug.Assert(parent != null, "no parent found!");

            // determine position within parent.items
            int indexStart = parent.DropDownItems.IndexOf(menuItemStart);

            int index = indexStart + 1;

            if (!this.initDone)
            {
                this.initDone = true;
                for (int mru = 0; mru < this.listSize; mru++)
                {
                    this.toolstripItems[mru] = new ToolStripMenuItem(
                      menuItemStart.Text, menuItemStart.Image);

                    // how to assign the event handler?
                    this.toolstripItems[mru].Click += this.OnItemClick;

                    this.toolstripItems[mru].Text = mru.ToString(
                      CultureInfo.CurrentCulture);
                    parent.DropDownItems.Insert(index++,
                      this.toolstripItems[mru]);
                    this.toolstripItems[mru].Visible = false;
                } // for
            } // if

            if (!string.IsNullOrEmpty(this.mruItemText[0]))
            {
                for (int mru = 0; mru < this.listSize; mru++)
                {
                    if (!string.IsNullOrEmpty(this.mruItemText[mru]))
                    {
                        this.toolstripItems[mru].Text = this.mruItemText[mru];
                        this.toolstripItems[mru].Visible = true;
                    }
                    else
                    {
                        this.toolstripItems[mru].Visible = false;
                    } // if
                } // for

                // hide placeholder
                menuItemStart.Visible = false;

                // show separator following to placeholder (if any)
                index = indexStart + this.listSize + 1;
                if (parent.DropDownItems[index] is ToolStripSeparator)
                {
                    parent.DropDownItems[index].Visible = true;
                } // if
            }
            else
            {
                // special case: this MRU list is empty
                // hide placeholder
                menuItemStart.Visible = false;
                index = indexStart + this.listSize + 1;

                // hide separator following to placeholder (if any)
                if (parent.DropDownItems[index] is ToolStripSeparator)
                {
                    parent.DropDownItems[index].Visible = false;
                } // if
            } // if
        } // UpdateMenu()

        /// <summary>
        /// Writes the most recently used (MRU) file list into the registry.
        /// </summary>
        public void WriteList()
        {
            RegistryKey regkey = Registry.CurrentUser.CreateSubKey(
                this.sectionName);
            if (regkey == null)
            {
                return;
            } // if

            for (int mru = 0; mru < this.listSize; mru++)
            {
                string strEntry = this.entryFormat + (mru + 1);
                if (!string.IsNullOrEmpty(this.mruItemText[mru]))
                {
                    regkey.SetValue(strEntry, this.mruItemText[mru]);
                }
                else
                {
                    regkey.DeleteValue(strEntry, false);
                } // if
            } // for
        } // WriteList()
        #endregion // PUBLIC METHODS

        //// ------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Is called when the user has clicked on one of the
        /// ToolBarMenuItems created by this object.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the
        /// event data.</param>
        private void OnItemClick(object sender, EventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(sender, e);
            } // if
        } // OnItemClick()
        #endregion // PRIVATE METHODS
    } // RecentFileList
} // Tethys.Forms

// ======================================
// Tethys.Forms: end of RecentFileList.cs
// ======================================