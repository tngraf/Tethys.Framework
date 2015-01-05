#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="StepControl.cs" company="Tethys">
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
    using System.Collections;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Step control implements a control to show single
    /// step of an operation consisting of an icon and a text.
    /// </summary>
    public partial class StepControl : Form
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// The steps.
        /// </summary>
        private readonly ArrayList steps;

        /// <summary>
        /// The current step.
        /// </summary>
        private int currentStep;

        /// <summary>
        /// Parent to center above.
        /// </summary>
        private Form centerParent;

        /// <summary>
        /// The next step.
        /// </summary>
        private int nextStep;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Delegate for the 'user has pressed the cancel button' event.
        /// </summary>
        public event EventHandler UserCancelEvent;

        /// <summary>
        /// Gets or sets a value indicating whether to always stay on top.
        /// </summary>
        public bool AlwaysOnTop { get; set; }

        /// <summary>
        /// Gets the current step.
        /// </summary>
        public int CurrentStep
        {
            get { return this.currentStep; }
        } // CurrentStep

        /// <summary>
        /// Gets or sets the progress bar value.
        /// </summary>
        public int PercentComplete
        {
            get
            {
                return progressBar.Value;
            }

            set
            {
                progressBar.Value = value;
                this.progressBar.Visible = (progressBar.Value > 0);
                Application.DoEvents();
            }
        } // PercentComplete

        /// <summary>
        /// Gets the step count.
        /// </summary>
        public int StepCount
        {
            get { return this.steps.Count; }
        } // StepCount

        /// <summary>
        /// Gets or sets the parent where the Message Form should center above.
        /// </summary>
        public Form CenterParent
        {
            get { return this.centerParent; }
            set { this.centerParent = value; }
        } // CenterParent

        /// <summary>
        /// Gets or sets the abort button text.
        /// </summary>
        public string AbortButtonText
        {
            get
            {
                return btnAbort.Text;
            }

            set
            {
                btnAbort.Text = value;
                Application.DoEvents();
            }
        } // AbortButtonText
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="StepControl"/> class.
        /// </summary>
        public StepControl()
        {
            InitializeComponent();

            progressBar.Value = 0;

            this.steps = new ArrayList();
            this.nextStep = 10;
        } // StepControl()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Adds a new step to the step control.
        /// </summary>
        /// <param name="caption">The caption.</param>
        public void AddStep(string caption)
        {
            var step = new SingleStep();
            step.Caption = caption;
            step.Result = StepResult.NotStarted;
            step.Size = new Size(332, 20);
            step.Name = "singleStep";
            step.Location = new Point(20, this.nextStep);
            Controls.Add(step);

            this.steps.Add(step);

            this.nextStep += 25;

            // resize control
            ClientSize = new Size(ClientSize.Width, ClientSize.Height + 25);
        } // AddStep()

        /// <summary>
        /// Ends the step display.
        /// </summary>
        public void EndSteps()
        {
            Hide();
            Application.DoEvents();
        } // EndSteps()

        /// <summary>
        /// Finishes the current step.
        /// </summary>
        /// <param name="result">The result.</param>
        public void FinishStep(StepResult result)
        {
            ((SingleStep)this.steps[this.currentStep]).Result = result;
            if (this.currentStep < this.Controls.Count - 3)
            {
                this.currentStep++;
                ((SingleStep)this.steps[this.currentStep]).Result = StepResult.Working;
            } // if
            Application.DoEvents();
        } // FinishStep()

        /// <summary>
        /// Starts (and shows) the step control on top of the specified form.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public void StartSteps(Form parent)
        {
            this.currentStep = 0;
            ((SingleStep)this.steps[this.currentStep]).Result = StepResult.Working;
            this.centerParent = parent;
            CenterOverWindow(parent);
            Show();

            Application.DoEvents();
        } // StartSteps()
        #endregion // PUBLIC METHODS

        //// ------------------------------------------------------------------

        #region DIALOG MANAGEMENT
        /// <summary>
        /// This function is called when the form is loaded.
        /// We display the network icon.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void StepControlLoad(object sender, EventArgs e)
        {
            if (this.centerParent != null)
            {
                CenterOverWindow(this.centerParent);
            } // if
            Application.DoEvents();
        } // StepControl_Load()

        /// <summary>
        /// This function is called when the user has clicked the Cancel button.
        /// We raise the UserCancelEvent event to notify the caller.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void BtnCancelClick(object sender, EventArgs e)
        {
            // raise UserCancelEvent event
            if (UserCancelEvent != null)
            {
                var ea = new EventArgs();
                UserCancelEvent(this, ea);
            } // if
            // hide form
            this.Hide();
            Application.DoEvents();
        } // btnCancel_Click()

        /// <summary>
        /// This function centers the form over the given window.
        /// </summary>
        /// <param name="form">The form.</param>
        private void CenterOverWindow(Form form)
        {
            // get parent bounds
            var rectangle = form.DesktopBounds;

            // calculate center point
            var center = new Point(rectangle.X + (rectangle.Width / 2),
              rectangle.Y + (rectangle.Height / 2));

            var pt = new Point(center.X - (DesktopBounds.Width / 2),
              center.Y - (DesktopBounds.Height / 2));
            if (pt.X < 0)
            {
                pt.X = 0;
            } // if
            if (pt.Y < 0)
            {
                pt.Y = 0;
            } // if

            var rc = new Rectangle(pt, new Size(DesktopBounds.Width,
              DesktopBounds.Height));
            DesktopBounds = rc;
        } // CenterOverWindow()

        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public void Show(Form parent)
        {
            this.centerParent = parent;
            CenterOverWindow(parent);
            this.Show();
            Application.DoEvents();
        } // Show();

        /// <summary>
        /// Hides the form, enables the parent window again.
        /// </summary>
        public new void Hide()
        {
            this.Visible = false;
            Application.DoEvents();
        } // Hide();
        #endregion // DIALOG MANAGEMENT
    } // StepControl
} // Tethys.Forms

// ===================================
// Tethys.forms: end of StepControl.cs
// ===================================
