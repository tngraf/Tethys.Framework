// ---------------------------------------------------------------------------
// <copyright file="TableLayoutPanelSizable.cs" company="Tethys">
//   Copyright (C) 1998-2024 T. Graf
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

////#define DEBUG_OUTPUT

// ReSharper disable once CheckNamespace
namespace Tethys.Forms
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Resize modes.
    /// </summary>
    internal enum ResizeMode
    {
        /// <summary>
        /// Horizontal resize.
        /// </summary>
        Horizontal,

        /// <summary>
        /// Vertical resize.
        /// </summary>
        Vertical,
    } // ResizeMode

    /// <summary>
    /// This class implements an enhanced TableLayoutPanel. The cells sizes
    /// of this table can be resized dynamically during runtime.
    /// </summary>
    [ToolboxBitmap(typeof(TableLayoutPanel))]
    public class TableLayoutPanelSizable : TableLayoutPanel
    {
        /// <summary>
        /// Information about resize positions.
        /// </summary>
        internal class PositionItem
        {
            #region PRIVATE PROPERTIES
            /// <summary>
            /// Item id.
            /// </summary>
            private readonly int item;

            /// <summary>
            /// Position 1.
            /// </summary>
            private readonly float p1;

            /// <summary>
            /// Position 2.
            /// </summary>
            private readonly float p2;
            #endregion // PRIVATE PROPERTIES

            //// --------------------------------------------------------------

            #region PUBLIC PROPERTIES
            /// <summary>
            /// Gets the item or cell that belongs to the coordinates.
            /// </summary>
            public int Item
            {
                get { return this.item; }
            }

            /// <summary>
            /// Gets the coordinate P1.
            /// </summary>
            public float P1
            {
                get { return this.p1; }
            }

            /// <summary>
            /// Gets the coordinate P2.
            /// </summary>
            public float P2
            {
                get { return this.p2; }
            }
            #endregion // PUBLIC PROPERTIES

            //// --------------------------------------------------------------

            #region CONSTRUCTION
            /// <summary>
            /// Initializes a new instance of the <see cref="PositionItem"/> class.
            /// </summary>
            /// <param name="item">Item or cell that belongs to the coordinates.</param>
            /// <param name="p1">Coordinate P1.</param>
            /// <param name="p2">Coordinate P2.</param>
            public PositionItem(int item, float p1, float p2)
            {
                this.item = item;
                this.p1 = p1;
                this.p2 = p2;
            } // PositionItem()
            #endregion // CONSTRUCTION
        } // PositionItem

        #region PRIVATE PROPERTIES
        /// <summary>
        /// The track size.
        /// </summary>
        private const int TrackSize = 3;

        /// <summary>
        /// We're tracking.
        /// </summary>
        private bool tracking;

        /// <summary>
        /// Currently resizing.
        /// </summary>
        private bool resizing;

        /// <summary>
        /// The resize mode.
        /// </summary>
        private ResizeMode resizeMode;

        /// <summary>
        /// Resize starting point.
        /// </summary>
        private Point resizeStart;

        /// <summary>
        /// The first column.
        /// </summary>
        private int firstColumn;

        /// <summary>
        /// The first row.
        /// </summary>
        private int firstRow;

        /// <summary>
        /// Resize factor base value.
        /// </summary>
        private float baseValue;

        /// <summary>
        /// Flag that we're initialized.
        /// </summary>
        private bool pmapsInitialized;

        /// <summary>
        /// Horizontal positions.
        /// </summary>
        private PositionItem[] pmapHorz;

        /// <summary>
        /// Vertical positions.
        /// </summary>
        private PositionItem[] pmapVert;

        /// <summary>
        /// The cell table.
        /// </summary>
        private Rectangle[,] cellTable;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the number of columns in the table.
        /// </summary>
        [Description("The number of columns in the table")]
        [Category("Layout")]
        public new int ColumnCount
        {
            get
            {
                return base.ColumnCount;
            }

            set
            {
                base.ColumnCount = value;
                this.CreateCellTable();
            }
        }

        /// <summary>
        /// Gets or sets the number of rows in the table.
        /// </summary>
        [Description("The number of rows in the table")]
        [Category("Layout")]
        public new int RowCount
        {
            get
            {
                return base.RowCount;
            }

            set
            {
                base.RowCount = value;
                this.CreateCellTable();
            }
        }
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="TableLayoutPanelSizable"/> class.
        /// </summary>
        public TableLayoutPanelSizable()
        {
            this.firstColumn = -1;
            this.firstRow = -1;
        } // TableLayoutPanelSizable()

        // Dispose()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region UI MANAGEMENT
        /// <summary>
        /// Occurs when a control should reposition its child controls.
        /// </summary>
        /// <param name="levent">A <see cref="T:System.Windows.Forms.LayoutEventArgs" />
        /// that contains the event data.</param>
        protected override void OnLayout(LayoutEventArgs levent)
        {
            if (!IsDesignMode(this))
            {
                this.BuildPositionMaps();
            } // if

            base.OnLayout(levent);
        } // OnLayout()

        /// <summary>
        /// Occurs when the control is clicked by the mouse.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" />
        /// that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!IsDesignMode(this))
            {
                this.BuildPositionMaps();
            } // if

            base.OnMouseClick(e);
        } // OnMouseClick()

        /// <summary>
        /// Occurs when the mouse pointer is over the control and
        /// a mouse button is pressed.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" />
        /// that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.tracking)
            {
                this.resizing = true;
                if (this.resizeMode == ResizeMode.Vertical)
                {
                    this.baseValue = this.ColumnStyles[this.firstColumn].Width;
                }
                else
                {
                    this.baseValue = this.RowStyles[this.firstRow].Height;
                } // if
            } // if

            base.OnMouseDown(e);
        } // OnMouseDown()

        /// <summary>
        /// If we are tracking, check for the current mouse position
        /// whether we need to display either a vertical or horizontal
        /// resize cursor.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" />
        /// that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!IsDesignMode(this))
            {
                if (!this.pmapsInitialized)
                {
                    this.BuildPositionMaps();
                } // if

                if (this.resizing)
                {
                    this.ResizeCells(e);
                }
                else
                {
                    this.CheckForResizePosition(e);
                } // if
            } // if

            base.OnMouseMove(e);
        } // OnMouseMove()

        /// <summary>
        /// Occurs when the mouse pointer is over the control and
        /// a mouse button is released.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" />
        /// that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.resizing = false;
            base.OnMouseUp(e);
        } // OnMouseUp()

        /// <summary>
        /// Occurs when the mouse pointer leaves the control.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" />
        /// that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.firstColumn = -1;
            this.firstRow = -1;
            this.resizing = false;
            this.tracking = false;
            base.OnMouseLeave(e);
        } // OnMouseLeave()

        /// <summary>
        /// IS called when a cells needs to be repainted.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.TableLayoutCellPaintEventArgs" />
        /// that provides data for the event.</param>
        protected override void OnCellPaint(TableLayoutCellPaintEventArgs e)
        {
            base.OnCellPaint(e);

            if (!IsDesignMode(this))
            {
                this.UpdateCellList(e);
            } // if
        } // OnCellPaint()
        #endregion // UI MANAGEMENT

        //// ------------------------------------------------------------------

        #region CORE METHODS
        /// <summary>
        /// Create the cell table array.
        /// </summary>
        private void CreateCellTable()
        {
#if DEBUG_OUTPUT
      Debug.WriteLine("CreateCellTable()");
#endif
            this.cellTable = new Rectangle[base.ColumnCount, base.RowCount];
        } // CreateCellTable()

        /// <summary>
        /// Update the location of the distinct cells.
        /// </summary>
        /// <param name="e">The <see cref="TableLayoutCellPaintEventArgs"/>
        /// instance containing the event data.</param>
        private void UpdateCellList(TableLayoutCellPaintEventArgs e)
        {
#if DEBUG_OUTPUT
      Debug.WriteLine(string.Format("Col={0}, Row={1}, {2}",
        e.Column, e.Row, e.CellBounds));
#endif
            if (this.cellTable == null)
            {
                this.CreateCellTable();
            } // if

            if (this.cellTable == null)
            {
                return;
            } // if

            this.cellTable[e.Column, e.Row] = e.CellBounds;

            this.BuildPositionMaps();
        } // UpdateCellList()

        /// <summary>
        /// (re)build a map of all position where a resize handle
        /// might be used.
        /// </summary>
        private void BuildPositionMaps()
        {
            // throw new NotSupportedException("SizeType.AutoSize is not yet supported!");
#if DEBUG_OUTPUT
      Debug.WriteLine("BuildPositionMaps()");
#endif

            if (this.cellTable == null)
            {
                return;
            } // if

            int i;
            float value;
            float offset = 0;
            this.pmapVert = new PositionItem[this.ColumnCount - 1];
            for (i = 0; i < this.ColumnCount - 1; i++)
            {
                value = this.cellTable[i, 0].Width;
                this.pmapVert[i] = new PositionItem(
                    i,
                    value + offset - TrackSize,
                    value + offset + TrackSize);
                offset += value;
            } // for

            offset = 0;
            this.pmapHorz = new PositionItem[this.RowCount - 1];
            for (i = 0; i < this.RowCount - 1; i++)
            {
                value = this.cellTable[0, i].Height;
                this.pmapHorz[i] = new PositionItem(
                    i,
                    value + offset - TrackSize,
                    value + offset + TrackSize);
                offset += value;
            } // for

            this.pmapsInitialized = true;
        } // BuildPositionMaps()

        /// <summary>
        /// Resize cells while moving mouse.
        /// Called by OnMouseMove().
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance
        /// containing the event data.</param>
        private void ResizeCells(MouseEventArgs e)
        {
            int d;
            float value;
            if (this.resizeMode == ResizeMode.Vertical)
            {
                d = e.Location.X - this.resizeStart.X;
                if (this.ColumnStyles[this.firstColumn].SizeType == SizeType.Absolute)
                {
                    value = this.baseValue + d;
                    if (value >= 0)
                    {
                        this.ColumnStyles[this.firstColumn].Width = value;
                    }
                    else
                    {
                        this.ColumnStyles[this.firstColumn].Width = 0;
                    } // if
                }
                else
                {
                    // SizeType.Percent
                    value = this.baseValue + (((float)d / this.Width) * 100);
                    if (value >= 0)
                    {
                        this.ColumnStyles[this.firstColumn].Width = value;
                    }
                    else
                    {
                        this.ColumnStyles[this.firstColumn].Width = 0;
                    } // if
                } // if
            }
            else
            {
                d = e.Location.Y - this.resizeStart.Y;
                if (this.RowStyles[this.firstRow].SizeType == SizeType.Absolute)
                {
                    value = this.baseValue + d;
                    if (value >= 0)
                    {
                        this.RowStyles[this.firstRow].Height = value;
                    }
                    else
                    {
                        this.RowStyles[this.firstRow].Height = 0;
                    } // if
                }
                else
                {
                    // SizeType.Percent
                    value = this.baseValue + (((float)d / this.Height) * 100);
#if DEBUG_OUTPUT
          Debug.WriteLine("d = " + d + ";" + value);
#endif
                    if (value >= 0)
                    {
                        this.RowStyles[this.firstRow].Height = value;
                    }
                    else
                    {
                        this.RowStyles[this.firstRow].Height = 0;
                    } // if
                } // if
            } // if
        } // ResizeCells()

        /// <summary>
        /// Check whether the cursor is on a horizontal border.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        /// <returns>
        ///   <c>true</c> if [is on horizontal border] [the specified e]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsOnHorizontalBorder(MouseEventArgs e)
        {
            this.firstRow = -1;
            for (var i = 0; i < this.RowCount - 1; i++)
            {
                if ((e.Location.Y >= this.pmapHorz[i].P1)
                  && (e.Location.Y <= this.pmapHorz[i].P2))
                {
                    this.firstRow = this.pmapHorz[i].Item;
#if DEBUG_OUTPUT
          Debug.WriteLine("Row = " + i);
#endif
                } // if
            } // for

            return (this.firstRow > -1);
        } // IsOnHorizontalBorder()

        /// <summary>
        /// Check whether the cursor is on a vertical border.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        /// <returns>
        ///   <c>true</c> if [is on vertical border] [the specified e]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsOnVerticalBorder(MouseEventArgs e)
        {
#if DEBUG_OUTPUT
      Debug.WriteLine(e.Location.ToString());
#endif

            this.firstColumn = -1;
            for (var i = 0; i < this.ColumnCount - 1; i++)
            {
                if ((e.Location.X >= this.pmapVert[i].P1)
                  && (e.Location.X <= this.pmapVert[i].P2))
                {
                    this.firstColumn = this.pmapVert[i].Item;
#if DEBUG_OUTPUT
          Debug.WriteLine("Col = " + i);
#endif
                } // if
            } // for

            return (this.firstColumn > -1);
        } // IsOnVerticalBorder()

        /// <summary>
        /// Checks if the mouse is currently over a cell border
        /// and a resize operation is possible.
        /// Called by OnMouseMove().
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance
        /// containing the event data.</param>
        private void CheckForResizePosition(MouseEventArgs e)
        {
            if (this.IsOnVerticalBorder(e))
            {
                this.Cursor = Cursors.VSplit;
                this.tracking = true;
                this.resizeMode = ResizeMode.Vertical;
                this.resizeStart = e.Location;
            }
            else if (this.IsOnHorizontalBorder(e))
            {
                this.Cursor = Cursors.HSplit;
                this.tracking = true;
                this.resizeMode = ResizeMode.Horizontal;
                this.resizeStart = e.Location;
            }
            else
            {
                this.Cursor = Cursors.Default;
                this.tracking = false;
                this.resizing = false;
            } // if
        } // CheckForResizePosition()

        /// <summary>
        /// This function helps to circumvent some .DesignMode problems in .Net.
        /// The property .DesignMode of a control that implements the ISite
        /// interface returns a value to indicated whether the control in in
        /// design mode.
        /// As soon as the control is embedded into another control in the designer,
        /// it always return false - even though we are still working in the designer.
        /// </summary>
        /// <param name="control">Control, which shall be check for design mode.</param>
        /// <returns>True if the control is in design mode.</returns>
        public static bool IsDesignMode(Control control)
        {
            // while there is still a control
            while (control != null)
            {
                // read site property
                var siteProperty = control.GetType().GetProperty("Site");
                if (siteProperty != null)
                {
                    var site = siteProperty.GetGetMethod().Invoke(control, new object[0]) as ISite;
                    if (site != null)
                    {
                        if (site.DesignMode)
                        {
                            return true;
                        } // if
                    } // if
                } // if

                // check parent
                control = control.Parent;
            } // while

            return false;
        } // IsDesignMode()
        #endregion // CORE METHODS
    } // TableLayoutPanelSizable
} // Tethys.Forms

// ===============================================
// Tethys.Forms: end of TableLayoutPanelSizable.cs
// ===============================================
