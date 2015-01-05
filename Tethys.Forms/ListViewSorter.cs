#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="ListViewSorter.cs" company="Tethys">
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
    using System.Collections;
    using System.Globalization;
    using System.Windows.Forms;

    /// <summary>
    /// ListView item types.
    /// </summary>
    public enum ListViewItemType
    {
        /// <summary>
        /// Text items.
        /// </summary>
        Text = 0,

        /// <summary>
        /// Numeric items.
        /// </summary>
        Numeric = 1
    } // ListViewItemType

    /// <summary>
    /// ListViewSorter is a helper class to sort a list view
    /// depending on the contents of selected columns.
    /// </summary>
    public class ListViewSorter : IComparer
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// The column.
        /// </summary>
        private int column;

        /// <summary>
        /// The sort order.
        /// </summary>
        private SortOrder sorting;

        /// <summary>
        /// The item type.
        /// </summary>
        private ListViewItemType itemType;
        #endregion PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the column to be used for sorting.
        /// </summary>
        public int Column
        {
            get { return this.column; }
            set { this.column = value; }
        } // Column

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        public SortOrder Sorting
        {
            get { return this.sorting; }
            set { this.sorting = value; }
        } // SortOrder

        /// <summary>
        /// Gets or sets the item type.
        /// </summary>
        public ListViewItemType ItemType
        {
            get { return this.itemType; }
            set { this.itemType = value; }
        } // ItemType
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewSorter"/> class.
        /// </summary>
        public ListViewSorter()
        {
            this.sorting = SortOrder.None;
        } // ListViewSorter()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less
        /// than, equal to or greater than the other.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns>
        /// * Less than zero -> x is less than y.<br/>
        /// * Zero -> x equals y.<br/>
        /// * Greater than zero x is greater than y.<br/>
        /// </returns>
        public int Compare(object x, object y)
        {
            var xx = (ListViewItem)x;
            var yy = (ListViewItem)y;

            if ((xx == null) && (yy == null))
            {
                return 0;
            } // if
            if (xx == null)
            {
                return -1;
            } // if
            if (yy == null)
            {
                return 1;
            } // if

            long lx;
            long ly;
            switch (this.sorting)
            {
                case SortOrder.Ascending:
                    if (this.itemType == ListViewItemType.Text)
                    {
                        return string.Compare(xx.SubItems[this.column].ToString(),
                          yy.SubItems[this.column].ToString(), System.StringComparison.Ordinal);
                    } // if

                    lx = long.Parse(xx.SubItems[this.column].Text, CultureInfo.CurrentCulture);
                    ly = long.Parse(yy.SubItems[this.column].Text, CultureInfo.CurrentCulture);
                    return lx.CompareTo(ly);
                case SortOrder.Descending:
                    if (this.itemType == ListViewItemType.Text)
                    {
                        return -string.Compare(xx.SubItems[this.column].ToString(),
                          yy.SubItems[this.column].ToString(), System.StringComparison.Ordinal);
                    } // if

                    lx = long.Parse(xx.SubItems[this.column].Text, CultureInfo.CurrentCulture);
                    ly = long.Parse(yy.SubItems[this.column].Text, CultureInfo.CurrentCulture);
                    return -lx.CompareTo(ly);
                default: /*SortOrder.None*/
                    return 0;
            } // switch
        } // Compare()
        #endregion // PUBLIC METHODS
    } // ListViewSorter
} // ResourceReader

// ======================================
// Tethys.forms: end of ListViewSorter.cs
// ======================================
