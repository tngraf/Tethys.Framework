namespace Tethys.Forms
{
  partial class StepControl
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
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.btnAbort = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // progressBar
      // 
      this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.progressBar.Location = new System.Drawing.Point(14, 19);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(348, 12);
      this.progressBar.Step = 1;
      this.progressBar.TabIndex = 5;
      this.progressBar.Visible = false;
      // 
      // btnAbort
      // 
      this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
      this.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnAbort.Location = new System.Drawing.Point(146, 39);
      this.btnAbort.Name = "btnAbort";
      this.btnAbort.Size = new System.Drawing.Size(75, 23);
      this.btnAbort.TabIndex = 4;
      this.btnAbort.Text = "Abort";
      this.btnAbort.Click += new System.EventHandler(this.BtnCancelClick);
      // 
      // StepControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(376, 80);
      this.ControlBox = false;
      this.Controls.Add(this.progressBar);
      this.Controls.Add(this.btnAbort);
      this.Name = "StepControl";
      this.Load += new System.EventHandler(this.StepControlLoad);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Button btnAbort;
  }
}