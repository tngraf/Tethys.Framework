// ---------------------------------------------------------------------------
// <copyright file="CheckTreeView.cs" company="Tethys">
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
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;

    using Tethys.Win32;

    /// <summary>
    /// Possible tree checkbox states (for CheckTreeView).
    /// </summary>
    public enum CheckValue
    {
        /// <summary>
        /// Item unchecked.
        /// </summary>
        Unchecked = 0,

        /// <summary>
        /// Item checked.
        /// </summary>
        Checked = 1,

        /// <summary>
        /// Item undefined.
        /// </summary>
        TriState = 2,
    } // CheckValue

    /// <summary>
    /// Tree view with a checkbox for each node.
    /// The check of a parent node always reflects the state of the
    /// child nodes.
    /// </summary>
    [ToolboxBitmap(typeof(TreeView))]
    public partial class CheckTreeView : TreeView
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Hide public ImageIndex.
        /// </summary>
        // ReSharper disable InconsistentNaming
        [SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1306:FieldNamesMustBeginWithLowerCaseLetter",
            Justification = "Reviewed. Suppression is OK here.")]
        private new readonly int ImageIndex;
        // ReSharper restore InconsistentNaming

        /// <summary>
        /// Hide public SelectedImageIndex.
        /// </summary>
        [SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1306:FieldNamesMustBeginWithLowerCaseLetter",
            Justification = "Reviewed. Suppression is OK here.")]
        // ReSharper disable InconsistentNaming
        private new readonly int SelectedImageIndex;
        // ReSharper restore InconsistentNaming

        /// <summary>
        /// Style: normal checkboxes or tristate checkboxes.
        /// </summary>
        private bool triStateStyle;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC EVENTS
        /// <summary>
        /// Occurs after the tree node check box is checked.
        /// </summary>
        public new event TreeViewEventHandler AfterCheck;

        /// <summary>
        /// Occurs before the tree node is selected.
        /// </summary>
        public new event TreeViewCancelEventHandler BeforeCheck;
        #endregion // PUBLIC EVENTS

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets a value indicating whether check boxes are displayed next to
        /// the tree nodes in the tree view control.
        /// </summary>
        [Category("Appearance")]
        [Description("Display checkboxes or not")]
        public static new bool CheckBoxes
        {
            get { return true; }
        } // CheckBoxes

        /// <summary>
        /// Gets or sets a value indicating whether to use normal checkboxes or
        /// tristate checkboxes.
        /// </summary>
        [Category("Appearance")]
        [Description("Checkbox style: normal checkboxes or tristate checkboxes")]
        public bool TriStateStyle
        {
            get { return this.triStateStyle; }
            set { this.triStateStyle = value; }
        } // TriStateStyle
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckTreeView"/> class.
        /// </summary>
        public CheckTreeView()
        {
            if (this.ImageIndex == this.SelectedImageIndex)
            {
                // this is only to ge rid of the warning that
                // ImageIndex and SelectedImageIndex are never
                // used ==> this is intended!
                this.ImageIndex = 1;
                this.SelectedImageIndex = 1;
            } // if
        } // CheckTreeView()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Sets the checkbox of the specified node to the specified value.
        /// </summary>
        /// <param name="node">tree node.</param>
        /// <param name="newValue">new value for the checkbox.</param>
        public void SetCheck(CheckTreeNode node, CheckValue newValue)
        {
            if (this.BeforeCheck != null)
            {
                // raise event
                var ea = new TreeViewCancelEventArgs(this.SelectedNode, false, TreeViewAction.Unknown);
                this.BeforeCheck(this, ea);
                if (ea.Cancel)
                {
                    // callback has set cancel flag
                    return;
                } // if
            } // if

            node.Checked = newValue;

            // loop through all parent nodes
            var parent = (CheckTreeNode)node.Parent;
            while (parent != null)
            {
                var valChildren = GetCheckChildren(parent);
                this.SetCheck(parent, valChildren);
                parent = (CheckTreeNode)parent.Parent;
            } // if

            if (this.AfterCheck != null)
            {
                // raise event
                var ea = new TreeViewEventArgs(node, TreeViewAction.Unknown);
                this.AfterCheck(this, ea);
            } // if
        } // SetCheck()

        /// <summary>
        /// Sets the checkbox of the specified node and all child nodes
        /// to the specified value.
        /// </summary>
        /// <param name="node">tree node.</param>
        /// <param name="newValue">new value for the checkbox.</param>
        public void SetCheckValue(CheckTreeNode node, CheckValue newValue)
        {
            // check node
            this.SetCheck(node, newValue);

            // check all children
            for (var i = 0; i < node.Nodes.Count; i++)
            {
                this.SetCheckValue((CheckTreeNode)node.Nodes[i], newValue);
            } // for
        } // SetCheckEx()

        /// <summary>
        /// This function returns the check state of the checkbox of the
        /// specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The check value.</returns>
        public static CheckValue GetCheck(CheckTreeNode node)
        {
            return node.Checked;
        } // GetCheck()

        /// <summary>
        /// This function retrieves the summarized check state of the
        /// checkboxes of all children of the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>
        /// The check value.
        /// </returns>
        public static CheckValue GetCheckChildren(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                // node has no children
                return CheckValue.Unchecked;
            } // if

            var ret = ((CheckTreeNode)node.Nodes[0]).Checked;
            for (var i = 0; i < node.Nodes.Count; i++)
            {
                var tristate = (ret != ((CheckTreeNode)node.Nodes[i]).Checked);
                if (tristate)
                {
                    return CheckValue.TriState;
                } // if
            } // for

            return ret;
        } // GetCheckChildren()

        /// <summary>
        /// Initializes the image list with the checkbox bitmaps.
        /// </summary>
        public void InitializeCheckBoxes()
        {
            this.InitializeComponent();
            this.ImageList = this.imageListCheckBoxes;
        } // InitializeCheckboxes()
        #endregion // PUBLIC METHODS

        //// ------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Handles a click on the tree view control.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that
        /// contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            var pt = this.PointToClient(Cursor.Position);
            var node = (CheckTreeNode)this.GetNodeAt(pt);
            if (this.IsHitCheckBox(node, pt))
            {
                this.HandleStateChange(node);
            } // if
        } // OnClick()

        /// <summary>
        /// Returns the next CheckValue value in the order<br />
        /// Unchecked -&gt; Checked -&gt; [-&gt; TriState] -&gt; Unchecked.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns>The check value.</returns>
        private static CheckValue GetNextCheckValue(CheckValue val)
        {
            if (val == CheckValue.TriState)
            {
                return CheckValue.Unchecked;
            } // if

            if (val == CheckValue.Unchecked)
            {
                return CheckValue.Checked;
            } // if

            return CheckValue.Unchecked;
        } // GetNextCheckValue

        /// <summary>
        /// Handles a state change of the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        private void HandleStateChange(CheckTreeNode node)
        {
            // get current check state
            var val = GetCheck(node);
            val = GetNextCheckValue(val);
            if (this.triStateStyle)
            {
                this.SetCheckValue(node, val);
            }
            else
            {
                // simply toggle the checkbox state
                this.SetCheck(node, val);
            } // if
        } // HandleStateChange()

        /// <summary>
        /// Handles the key down event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" />
        /// that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Space)
            {
                this.HandleStateChange((CheckTreeNode)this.SelectedNode);
            } // if
        } // OnKeyDown()

        /// <summary>
        /// Determines whether at the specified location the checkbox is.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="pt">The point.</param>
        /// <returns>
        /// <c>true</c> if [is hit check box] [the specified node];
        /// otherwise, <c>false</c>.
        /// </returns>
        protected bool IsHitCheckBox(TreeNode node, Point pt)
        {
            const int Msg = (int)TreeViewMessages.TVM_GETITEMRECT;

            // Win32 code: *(HTREEITEM*)lpRect = hItem;
            var rc = new RECT { left = (int)node.Handle };
            var ok = Win32Api.SendMessage(this.Handle, Msg, 1, ref rc);
            if (ok != IntPtr.Zero)
            {
                if (pt.X > rc.left)
                {
                    // not within checkbox area
                    return false;
                } // if

                // allow 4 pixel border around current checkbox size
                if (pt.X < rc.left - this.ImageList.ImageSize.Width - 4)
                {
                    // not within checkbox area
                    return false;
                } // if

                return true;
            } // if

            return false;
        } // IsHitCheckBox()
        #endregion // PRIVATE METHODS
    } // CheckTreeView
} // Tethys.Forms

// ===============================
// Tethys: end of CheckTreeView.cs
// ===============================
