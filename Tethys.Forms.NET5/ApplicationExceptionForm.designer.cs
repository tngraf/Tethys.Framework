namespace Tethys.Forms
{
  partial class ApplicationExceptionForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationExceptionForm));
      this.lblDescription = new System.Windows.Forms.Label();
      this.btnAbort = new System.Windows.Forms.Button();
      this.btnContinue = new System.Windows.Forms.Button();
      this.txtDetails = new System.Windows.Forms.TextBox();
      this.btnCheckDetails = new System.Windows.Forms.CheckBox();
      this.lblException = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lblDescription
      // 
      this.lblDescription.Location = new System.Drawing.Point(8, 8);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new System.Drawing.Size(420, 60);
      this.lblDescription.TabIndex = 0;
      this.lblDescription.Text = resources.GetString("lblDescription.Text");
      // 
      // btnAbort
      // 
      this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
      this.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnAbort.Location = new System.Drawing.Point(352, 96);
      this.btnAbort.Name = "btnAbort";
      this.btnAbort.Size = new System.Drawing.Size(75, 23);
      this.btnAbort.TabIndex = 1;
      this.btnAbort.Text = "Quit";
      this.btnAbort.Click += new System.EventHandler(this.BtnAbortClick);
      // 
      // btnContinue
      // 
      this.btnContinue.DialogResult = System.Windows.Forms.DialogResult.Ignore;
      this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnContinue.Location = new System.Drawing.Point(232, 96);
      this.btnContinue.Name = "btnContinue";
      this.btnContinue.Size = new System.Drawing.Size(75, 23);
      this.btnContinue.TabIndex = 2;
      this.btnContinue.Text = "Continue";
      this.btnContinue.Click += new System.EventHandler(this.BtnContinueClick);
      // 
      // txtDetails
      // 
      this.txtDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDetails.Location = new System.Drawing.Point(8, 128);
      this.txtDetails.MaxLength = 0;
      this.txtDetails.Multiline = true;
      this.txtDetails.Name = "txtDetails";
      this.txtDetails.ReadOnly = true;
      this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtDetails.Size = new System.Drawing.Size(420, 136);
      this.txtDetails.TabIndex = 4;
      this.txtDetails.WordWrap = false;
      // 
      // btnCheckDetails
      // 
      this.btnCheckDetails.Appearance = System.Windows.Forms.Appearance.Button;
      this.btnCheckDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnCheckDetails.Location = new System.Drawing.Point(8, 96);
      this.btnCheckDetails.Name = "btnCheckDetails";
      this.btnCheckDetails.Size = new System.Drawing.Size(75, 23);
      this.btnCheckDetails.TabIndex = 5;
      this.btnCheckDetails.Text = "Details";
      this.btnCheckDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.btnCheckDetails.CheckedChanged += new System.EventHandler(this.CheckDetailsCheckedChanged);
      // 
      // lblException
      // 
      this.lblException.Location = new System.Drawing.Point(8, 72);
      this.lblException.Name = "lblException";
      this.lblException.Size = new System.Drawing.Size(420, 16);
      this.lblException.TabIndex = 6;
      this.lblException.Text = "<Exception text>";
      // 
      // ApplicationExceptionForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(434, 272);
      this.Controls.Add(this.lblException);
      this.Controls.Add(this.btnCheckDetails);
      this.Controls.Add(this.txtDetails);
      this.Controls.Add(this.btnContinue);
      this.Controls.Add(this.btnAbort);
      this.Controls.Add(this.lblDescription);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ApplicationExceptionForm";
      this.Text = "Application Exception";
      this.Load += new System.EventHandler(this.ApplicationExceptionFormLoad);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnContinue;
    private System.Windows.Forms.Button btnAbort;
    private System.Windows.Forms.TextBox txtDetails;
    private System.Windows.Forms.CheckBox btnCheckDetails;
    private System.Windows.Forms.Label lblException;
    private System.Windows.Forms.Label lblDescription;
  }
}