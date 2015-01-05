#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="ComboBoxItem.cs" company="Tethys">
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

    /// <summary>
    /// The class ComboBoxItem implements an extended container
    /// to hold information about a specific combo box item.
    /// </summary>
    [Serializable]
    public class ComboBoxItem
    {
        #region PRIVATE PROPERTIES

        /// <summary>
        /// Data object to hold more information about the item.
        /// </summary>
        private object dataTag;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES

        /// <summary>
        /// Gets or sets the display string of the current object.
        /// </summary>
        public string ItemText { get; set; }

        // ItemText

        /// <summary>
        /// Gets or sets the data value of the current object.
        /// </summary>
        public object DataTag
        {
            get { return this.dataTag; }
            set { this.dataTag = value; }
        } // DataTag
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxItem"/> class.
        /// </summary>
        public ComboBoxItem()
        {
            this.ItemText = string.Empty;
        } // ComboBoxItem()

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxItem"/> class.
        /// </summary>
        /// <param name="itemText">item test</param>
        /// <param name="tag">object tag to add</param>
        public ComboBoxItem(string itemText, object tag)
        {
            this.ItemText = itemText;
            this.dataTag = tag;
        } // ComboBoxItem()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Returns a string representing this object instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} ({1})",
                this.ItemText, this.dataTag);
        } // ToString()
        #endregion // PUBLIC METHODS
    } // ComboBoxItem
} // Tethys.Forms

// ===================================
// Tethys.forms: end of ComboBoxItem.cs
// ===================================