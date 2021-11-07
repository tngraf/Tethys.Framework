// ---------------------------------------------------------------------------
// <copyright file="ListViewSorter.cs" company="Tethys">
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
        Numeric = 1,
    } // ListViewItemType

    /// <summary>
    /// ListViewSorter is a helper class to sort a list view
    /// depending on the contents of selected columns.
    /// </summary>
    public class ListViewSorter : IComparer
    {
        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the column to be used for sorting.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        public SortOrder Sorting { get; set; }

        /// <summary>
        /// Gets or sets the item type.
        /// </summary>
        public ListViewItemType ItemType { get; set; }
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewSorter"/> class.
        /// </summary>
        public ListViewSorter()
        {
            this.Sorting = SortOrder.None;
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
            switch (this.Sorting)
            {
                case SortOrder.Ascending:
                    if (this.ItemType == ListViewItemType.Text)
                    {
                        return string.Compare(
                            xx.SubItems[this.Column].ToString(),
                            yy.SubItems[this.Column].ToString(),
                            System.StringComparison.Ordinal);
                    } // if

                    lx = long.Parse(xx.SubItems[this.Column].Text, CultureInfo.CurrentCulture);
                    ly = long.Parse(yy.SubItems[this.Column].Text, CultureInfo.CurrentCulture);
                    return lx.CompareTo(ly);
                case SortOrder.Descending:
                    if (this.ItemType == ListViewItemType.Text)
                    {
                        return -string.Compare(
                            xx.SubItems[this.Column].ToString(),
                            yy.SubItems[this.Column].ToString(),
                            System.StringComparison.Ordinal);
                    } // if

                    lx = long.Parse(xx.SubItems[this.Column].Text, CultureInfo.CurrentCulture);
                    ly = long.Parse(yy.SubItems[this.Column].Text, CultureInfo.CurrentCulture);
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
