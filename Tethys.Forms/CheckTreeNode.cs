#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="CheckTreeNode.cs" company="Tethys">
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
    using System.Runtime.Serialization;
    using System.Windows.Forms;

    /// <summary>
    /// A tree node that has a checkbox.
    /// This class is needed for CheckTreeView.
    /// </summary>
    [Serializable]
    public class CheckTreeNode : TreeNode
    {
        /// <summary>
        /// Internal property: check value.
        /// </summary>
        private CheckValue check;

        /// <summary>
        /// Gets or sets a value indicating whether the check box is in
        /// the checked state.
        /// </summary>
        public new CheckValue Checked
        {
            get
            {
                return this.check;
            }

            set
            {
                if (this.check != value)
                {
                    this.check = value;
                    ImageIndex = (int)this.check;
                    SelectedImageIndex = (int)this.check;
                } // if
            } // set
        } // Checked

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckTreeNode"/> class.
        /// </summary>
        public CheckTreeNode()
        {
            this.check = CheckValue.Unchecked;
            ImageIndex = 0;
            SelectedImageIndex = 0;
        } // CheckTreeNode()

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckTreeNode"/> class.
        /// </summary>
        /// <param name="text">node text</param>
        public CheckTreeNode(string text)
        {
            this.check = CheckValue.Unchecked;
            ImageIndex = 0;
            SelectedImageIndex = 0;
            Text = text;
        } // CheckTreeNode()

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckTreeNode"/> class.
        /// </summary>
        /// <param name="children">array of child nodes</param>
        public CheckTreeNode(CheckTreeNode[] children)
        {
            this.check = CheckValue.Unchecked;
            ImageIndex = 0;
            SelectedImageIndex = 0;
            // ReSharper disable once CoVariantArrayConversion
            Nodes.AddRange(children);
        } // CheckTreeNode()

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckTreeNode"/> class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected CheckTreeNode(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        } // CheckTreeNode()
    } // CheckTreeView
}
