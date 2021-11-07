// ---------------------------------------------------------------------------
// <copyright file="SingleStep.cs" company="Tethys">
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
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Step result codes.
    /// </summary>
    public enum StepResult
    {
        /// <summary>
        /// Step not yet started.
        /// </summary>
        NotStarted = 0,

        /// <summary>
        /// Step skipped.
        /// </summary>
        Skip,

        /// <summary>
        /// Current step.
        /// </summary>
        Working,

        /// <summary>
        /// Step successfully completed.
        /// </summary>
        Success,

        /// <summary>
        /// Step finished with failures.
        /// </summary>
        Failure,

        /// <summary>
        /// Step finish with unknown result.
        /// </summary>
        Unknown,
    } // StepResult

    /// <summary>
    /// SingleStep implements a single step of the step control.
    /// </summary>
    [Description("SingleStep control")]
    [ToolboxBitmap(typeof(SingleStep), "SingleStepToolboxBitmap")]
    public partial class SingleStep : UserControl
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Step result.
        /// </summary>
        private StepResult stepResult;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the step caption.
        /// </summary>
        public string Caption
        {
            get { return this.lblStep.Text; }
            set { this.lblStep.Text = value; }
        } // Caption

        /// <summary>
        /// Gets or sets the step result code.
        /// </summary>
        public StepResult Result
        {
            get
            {
                return this.stepResult;
            }

            set
            {
                this.stepResult = value;
                this.UpdateIcon();
            }
        } // Result
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleStep"/> class.
        /// </summary>
        public SingleStep()
        {
            this.InitializeComponent();

            this.lblStep.Text = string.Empty;
            this.stepResult = StepResult.NotStarted;

            this.UpdateIcon();
        } // SingleStep()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Updates the icon display.
        /// </summary>
        private void UpdateIcon()
        {
            switch (this.stepResult)
            {
                case StepResult.NotStarted:
                case StepResult.Skip:
                    this.picBox.Image = this.imageList.Images[0];
                    break;
                case StepResult.Working:
                    this.picBox.Image = this.imageList.Images[1];
                    break;
                case StepResult.Success:
                    this.picBox.Image = this.imageList.Images[2];
                    break;
                case StepResult.Failure:
                    this.picBox.Image = this.imageList.Images[3];
                    break;
                case StepResult.Unknown:
                    this.picBox.Image = this.imageList.Images[4];
                    break;
            } // switch
        } // UpdateIcon()
        #endregion // PRIVATE METHODS
    } // SingleStep
} // Tethys.Forms

// ==================================
// Tethys.forms: end of SingleStep.cs
// ==================================
