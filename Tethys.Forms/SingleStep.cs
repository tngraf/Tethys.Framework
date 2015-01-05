#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="SingleStep.cs" company="Tethys">
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
        Unknown
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
            get { return lblStep.Text; }
            set { lblStep.Text = value; }
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
                UpdateIcon();
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
            InitializeComponent();

            lblStep.Text = string.Empty;
            this.stepResult = StepResult.NotStarted;

            UpdateIcon();
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
                    picBox.Image = imageList.Images[0];
                    break;
                case StepResult.Working:
                    picBox.Image = imageList.Images[1];
                    break;
                case StepResult.Success:
                    picBox.Image = imageList.Images[2];
                    break;
                case StepResult.Failure:
                    picBox.Image = imageList.Images[3];
                    break;
                case StepResult.Unknown:
                    picBox.Image = imageList.Images[4];
                    break;
            } // switch
        } // UpdateIcon()
        #endregion // PRIVATE METHODS
    } // SingleStep
} // Tethys.Forms

// ==================================
// Tethys.forms: end of SingleStep.cs
// ==================================
