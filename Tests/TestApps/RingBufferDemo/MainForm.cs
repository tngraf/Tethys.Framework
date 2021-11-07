// ---------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Tethys">
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

namespace RingBufferDemo
{
    using System;
    using System.Globalization;
    using System.Windows.Forms;

    using Tethys.IO;

    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private readonly System.ComponentModel.Container components = null;

        private Label label1;
        private TextBox txtSizeNew;
        private Label label2;
        private Button btnCreate;
        private Label label3;
        private TextBox txtSize;
        private Label label4;
        private Label label5;
        private TextBox txtContents;
        private Button btnUpdate;
        private Button btnReset;
        private TextBox txtPosition;
        private Label label6;
        private Button btnAddString;
        private Button btnAddCharArry;
        private TextBox txtDataAdd;
        private Label label7;
        private Button btnGetData;
        private TextBox txtDataReturn;
        private Label label8;
        private TextBox txtCharReq;
        private Label label9;
        private Button btnConsume;
        private Label label10;
        private TextBox txtConsume;
        private Button btnGetNextLine;
        private GroupBox groupCreation;
        private GroupBox groupStatus;
        private GroupBox groupOperations;
        private Button btnAddCr;
        private Button btnAddLf;
        private Button bntUnitTests;
        private RingBuffer rb;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // Required for Windows Form Designer support
            this.InitializeComponent();

            this.rb = null;
        } // MainForm()

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and
        /// unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.components?.Dispose();
            } // if

            base.Dispose(disposing);
        } // Dispose()

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupCreation = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSizeNew = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupStatus = new System.Windows.Forms.GroupBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContents = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupOperations = new System.Windows.Forms.GroupBox();
            this.btnAddLf = new System.Windows.Forms.Button();
            this.btnAddCr = new System.Windows.Forms.Button();
            this.btnGetNextLine = new System.Windows.Forms.Button();
            this.btnConsume = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtConsume = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataReturn = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnAddCharArry = new System.Windows.Forms.Button();
            this.btnAddString = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataAdd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCharReq = new System.Windows.Forms.TextBox();
            this.bntUnitTests = new System.Windows.Forms.Button();
            this.groupCreation.SuspendLayout();
            this.groupStatus.SuspendLayout();
            this.groupOperations.SuspendLayout();
            this.SuspendLayout();
            // ---
            // groupCreation
            // ---
            this.groupCreation.Controls.Add(this.btnCreate);
            this.groupCreation.Controls.Add(this.label2);
            this.groupCreation.Controls.Add(this.txtSizeNew);
            this.groupCreation.Controls.Add(this.label1);
            this.groupCreation.Location = new System.Drawing.Point(8, 8);
            this.groupCreation.Name = "groupCreation";
            this.groupCreation.Size = new System.Drawing.Size(272, 52);
            this.groupCreation.TabIndex = 0;
            this.groupCreation.TabStop = false;
            this.groupCreation.Text = " RingBuffer Creation ";
            // ---
            // btnCreate
            // ---
            this.btnCreate.Location = new System.Drawing.Point(184, 20);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.BtnCreateClick);
            // ---
            // label2
            // ---
            this.label2.Location = new System.Drawing.Point(112, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "characters";
            // ---
            // txtSizeNew
            // ---
            this.txtSizeNew.Location = new System.Drawing.Point(52, 20);
            this.txtSizeNew.Name = "txtSizeNew";
            this.txtSizeNew.Size = new System.Drawing.Size(56, 20);
            this.txtSizeNew.TabIndex = 1;
            this.txtSizeNew.Text = string.Empty;
            // ---
            // label1
            // ---
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Size:";
            // ---
            // groupStatus
            // ---
            this.groupStatus.Controls.Add(this.txtPosition);
            this.groupStatus.Controls.Add(this.label6);
            this.groupStatus.Controls.Add(this.txtContents);
            this.groupStatus.Controls.Add(this.label5);
            this.groupStatus.Controls.Add(this.label3);
            this.groupStatus.Controls.Add(this.txtSize);
            this.groupStatus.Controls.Add(this.label4);
            this.groupStatus.Controls.Add(this.btnUpdate);
            this.groupStatus.Location = new System.Drawing.Point(8, 68);
            this.groupStatus.Name = "groupStatus";
            this.groupStatus.Size = new System.Drawing.Size(272, 280);
            this.groupStatus.TabIndex = 1;
            this.groupStatus.TabStop = false;
            this.groupStatus.Text = " RingBuffer Status";
            // ---
            // txtPosition
            // ---
            this.txtPosition.Location = new System.Drawing.Point(68, 48);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.ReadOnly = true;
            this.txtPosition.Size = new System.Drawing.Size(56, 20);
            this.txtPosition.TabIndex = 9;
            this.txtPosition.Text = string.Empty;
            // ---
            // label6
            // ---
            this.label6.Location = new System.Drawing.Point(12, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Position:";
            // ---
            // txtContents
            // ---
            this.txtContents.Location = new System.Drawing.Point(12, 100);
            this.txtContents.Multiline = true;
            this.txtContents.Name = "txtContents";
            this.txtContents.ReadOnly = true;
            this.txtContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContents.Size = new System.Drawing.Size(252, 176);
            this.txtContents.TabIndex = 7;
            this.txtContents.Text = string.Empty;
            // ---
            // label5
            // ---
            this.label5.Location = new System.Drawing.Point(12, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "RingBuffer Contents:";
            // ---
            // label3
            // ---
            this.label3.Location = new System.Drawing.Point(112, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "characters";
            // ---
            // txtSize
            // ---
            this.txtSize.Location = new System.Drawing.Point(52, 20);
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Size = new System.Drawing.Size(56, 20);
            this.txtSize.TabIndex = 4;
            this.txtSize.Text = string.Empty;
            // ---
            // label4
            // ---
            this.label4.Location = new System.Drawing.Point(12, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Size:";
            // ---
            // btnUpdate
            // ---
            this.btnUpdate.Location = new System.Drawing.Point(184, 20);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdateClick);
            // ---
            // groupOperations
            // ---
            this.groupOperations.Controls.Add(this.btnAddLf);
            this.groupOperations.Controls.Add(this.btnAddCr);
            this.groupOperations.Controls.Add(this.btnGetNextLine);
            this.groupOperations.Controls.Add(this.btnConsume);
            this.groupOperations.Controls.Add(this.label10);
            this.groupOperations.Controls.Add(this.txtConsume);
            this.groupOperations.Controls.Add(this.label9);
            this.groupOperations.Controls.Add(this.txtDataReturn);
            this.groupOperations.Controls.Add(this.btnGetData);
            this.groupOperations.Controls.Add(this.btnAddCharArry);
            this.groupOperations.Controls.Add(this.btnAddString);
            this.groupOperations.Controls.Add(this.btnReset);
            this.groupOperations.Controls.Add(this.label7);
            this.groupOperations.Controls.Add(this.txtDataAdd);
            this.groupOperations.Controls.Add(this.label8);
            this.groupOperations.Controls.Add(this.txtCharReq);
            this.groupOperations.Location = new System.Drawing.Point(288, 8);
            this.groupOperations.Name = "groupOperations";
            this.groupOperations.Size = new System.Drawing.Size(276, 340);
            this.groupOperations.TabIndex = 2;
            this.groupOperations.TabStop = false;
            this.groupOperations.Text = " Operations ";
            // ---
            // btnAddLf
            // ---
            this.btnAddLf.Location = new System.Drawing.Point(112, 128);
            this.btnAddLf.Name = "btnAddLf";
            this.btnAddLf.Size = new System.Drawing.Size(92, 23);
            this.btnAddLf.TabIndex = 20;
            this.btnAddLf.Text = "Add LF (\\n)";
            this.btnAddLf.Click += new System.EventHandler(this.BtnAddLfClick);
            // ---
            // btnAddCr
            // ---
            this.btnAddCr.Location = new System.Drawing.Point(12, 128);
            this.btnAddCr.Name = "btnAddCr";
            this.btnAddCr.Size = new System.Drawing.Size(92, 23);
            this.btnAddCr.TabIndex = 19;
            this.btnAddCr.Text = "Add CR (\\r)";
            this.btnAddCr.Click += new System.EventHandler(this.BtnAddCrClick);
            // ---
            // btnGetNextLine
            // ---
            this.btnGetNextLine.Location = new System.Drawing.Point(12, 296);
            this.btnGetNextLine.Name = "btnGetNextLine";
            this.btnGetNextLine.Size = new System.Drawing.Size(112, 23);
            this.btnGetNextLine.TabIndex = 18;
            this.btnGetNextLine.Text = "Get Next Line";
            this.btnGetNextLine.Click += new System.EventHandler(this.BtnGetNextLineClick);
            // ---
            // btnConsume
            // ---
            this.btnConsume.Location = new System.Drawing.Point(12, 264);
            this.btnConsume.Name = "btnConsume";
            this.btnConsume.Size = new System.Drawing.Size(112, 23);
            this.btnConsume.TabIndex = 17;
            this.btnConsume.Text = "Consume Data";
            this.btnConsume.Click += new System.EventHandler(this.BtnConsumeClick);
            // ---
            // label10
            // ---
            this.label10.Location = new System.Drawing.Point(136, 268);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "characters";
            // ---
            // txtConsume
            // ---
            this.txtConsume.Location = new System.Drawing.Point(200, 264);
            this.txtConsume.Name = "txtConsume";
            this.txtConsume.Size = new System.Drawing.Size(64, 20);
            this.txtConsume.TabIndex = 15;
            this.txtConsume.Text = string.Empty;
            // ---
            // label9
            // ---
            this.label9.Location = new System.Drawing.Point(12, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Return of Get Data or Get Next Line:";
            // ---
            // txtDataReturn
            // ---
            this.txtDataReturn.Location = new System.Drawing.Point(12, 204);
            this.txtDataReturn.Multiline = true;
            this.txtDataReturn.Name = "txtDataReturn";
            this.txtDataReturn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDataReturn.Size = new System.Drawing.Size(252, 52);
            this.txtDataReturn.TabIndex = 13;
            this.txtDataReturn.Text = string.Empty;
            // ---
            // btnGetData
            // ---
            this.btnGetData.Location = new System.Drawing.Point(12, 160);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(112, 23);
            this.btnGetData.TabIndex = 12;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.Click += new System.EventHandler(this.BtnGetDataClick);
            // ---
            // btnAddCharArry
            // ---
            this.btnAddCharArry.Location = new System.Drawing.Point(132, 96);
            this.btnAddCharArry.Name = "btnAddCharArry";
            this.btnAddCharArry.Size = new System.Drawing.Size(132, 23);
            this.btnAddCharArry.TabIndex = 6;
            this.btnAddCharArry.Text = "Add Data as Char Array";
            this.btnAddCharArry.Click += new System.EventHandler(this.BtnAddCharArryClick);
            // ---
            // btnAddString
            // ---
            this.btnAddString.Location = new System.Drawing.Point(12, 96);
            this.btnAddString.Name = "btnAddString";
            this.btnAddString.Size = new System.Drawing.Size(112, 23);
            this.btnAddString.TabIndex = 5;
            this.btnAddString.Text = "Add Data as String";
            this.btnAddString.Click += new System.EventHandler(this.BtnAddStringClick);
            // ---
            // btnReset
            // ---
            this.btnReset.Location = new System.Drawing.Point(132, 296);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(68, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
            // ---
            // label7
            // ---
            this.label7.Location = new System.Drawing.Point(12, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Data to be added:";
            // ---
            // txtDataAdd
            // ---
            this.txtDataAdd.Location = new System.Drawing.Point(12, 36);
            this.txtDataAdd.Multiline = true;
            this.txtDataAdd.Name = "txtDataAdd";
            this.txtDataAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDataAdd.Size = new System.Drawing.Size(252, 52);
            this.txtDataAdd.TabIndex = 11;
            this.txtDataAdd.Text = string.Empty;
            // ---
            // label8
            // ---
            this.label8.Location = new System.Drawing.Point(136, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "characters";
            // ---
            // txtCharReq
            // ---
            this.txtCharReq.Location = new System.Drawing.Point(200, 160);
            this.txtCharReq.Name = "txtCharReq";
            this.txtCharReq.Size = new System.Drawing.Size(64, 20);
            this.txtCharReq.TabIndex = 4;
            this.txtCharReq.Text = string.Empty;
            // ---
            // bntUnitTests
            // ---
            this.bntUnitTests.Location = new System.Drawing.Point(448, 356);
            this.bntUnitTests.Name = "bntUnitTests";
            this.bntUnitTests.Size = new System.Drawing.Size(116, 23);
            this.bntUnitTests.TabIndex = 5;
            this.bntUnitTests.Text = "Unit Tests";
            // ---
            // MainForm
            // ---
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(568, 386);
            this.Controls.Add(this.bntUnitTests);
            this.Controls.Add(this.groupOperations);
            this.Controls.Add(this.groupStatus);
            this.Controls.Add(this.groupCreation);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Ringbuffer Demo";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.groupCreation.ResumeLayout(false);
            this.groupStatus.ResumeLayout(false);
            this.groupOperations.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.Run(new MainForm());
        } // Main()

        /// <summary>
        /// Handles the Click event of the <c>btnCreate</c> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void BtnCreateClick(object sender, EventArgs e)
        {
            if (this.txtSizeNew.Text.Length > 0)
            {
                var n = int.Parse(this.txtSizeNew.Text);
                if (n > 0)
                {
                    this.rb = new RingBuffer(n);
                } // if

                this.UpdateStatus();
            } // if
        } // btnCreate_Click()

        /// <summary>
        /// Updates the status.
        /// </summary>
        private void UpdateStatus()
        {
            if (this.rb == null)
            {
                this.txtSize.Text = "-";
                this.txtPosition.Text = "-";
                this.txtContents.Text = string.Empty;
            }
            else
            {
                this.txtSize.Text = this.rb.Size.ToString(CultureInfo.InvariantCulture);
                this.txtPosition.Text = this.rb.Position.ToString(CultureInfo.InvariantCulture);
                this.txtContents.Text = this.rb.GetData();
            } // if
        } // UpdateStatus()

        /// <summary>
        /// Handles the Click event of the <c>btnUpdate</c> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void BtnUpdateClick(object sender, EventArgs e)
        {
            this.UpdateStatus();
        } // btnUpdate_Click()

        /// <summary>
        /// Handles the Click event of the <c>btnAddString</c> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void BtnAddStringClick(object sender, EventArgs e)
        {
            if (this.txtDataAdd.Text.Length > 0)
            {
                this.rb.AddData(this.txtDataAdd.Text);

                this.UpdateStatus();
            } // if
        } // btnAddString_Click()

        /// <summary>
        /// Handles the Click event of the <c>btnAddCharArry</c> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void BtnAddCharArryClick(object sender, EventArgs e)
        {
            if (this.txtDataAdd.Text.Length > 0)
            {
                var ca = this.txtDataAdd.Text.ToCharArray();
                this.rb.AddData(ca, ca.Length);

                this.UpdateStatus();
            } // if
        } // btnAddCharArry_Click()

        /// <summary>
        /// Handles the Click event of the <c>btnGetData</c> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void BtnGetDataClick(object sender, EventArgs e)
        {
            if (this.txtCharReq.Text.Length > 0)
            {
                var n = int.Parse(this.txtCharReq.Text);
                if (n > 0)
                {
                    this.txtDataReturn.Text = this.rb.GetData(n);
                } // if
            }
            else
            {
                this.txtDataReturn.Text = this.rb.GetData();
            } // if

            this.UpdateStatus();
        } // btnGetData_Click()

        /// <summary>
        /// Handles the Click event of the <c>btnConsume</c> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void BtnConsumeClick(object sender, EventArgs e)
        {
            if (this.txtConsume.Text.Length > 0)
            {
                int n = int.Parse(this.txtConsume.Text);
                if (n > 0)
                {
                    this.rb.Consume(n);

                    this.UpdateStatus();
                } // if
            } // if
        } // btnConsume_Click()

        /// <summary>
        /// Handles the Click event of the <c>btnGetNextLine</c> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void BtnGetNextLineClick(object sender, EventArgs e)
        {
            this.txtDataReturn.Text = this.rb.GetNextLine();

            this.UpdateStatus();
        } // btnGetNextLine_Click()

        /// <summary>
        /// Handles the Click event of the <c>btnReset</c> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void BtnResetClick(object sender, EventArgs e)
        {
            this.rb.Reset();

            this.UpdateStatus();
        } // btnReset_Click()

        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void MainFormLoad(object sender, EventArgs e)
        {
            this.UpdateStatus();
        }

        /// <summary>
        /// Handles the Click event of the <c>btnAddCr</c> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void BtnAddCrClick(object sender, EventArgs e)
        {
            this.rb.AddData("\r");
        }

        /// <summary>
        /// Handles the Click event of the <c>btnAddLf</c> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void BtnAddLfClick(object sender, EventArgs e)
        {
            this.rb.AddData("\n");
        } // MainForm_Load()
    }
}
