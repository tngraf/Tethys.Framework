namespace Tethys.Forms
{
  partial class SimpleAboutForm
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
      this.btnOk = new System.Windows.Forms.Button();
      this.labelCopyright = new System.Windows.Forms.Label();
      this.labelVersion = new System.Windows.Forms.Label();
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.labelDescription = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Location = new System.Drawing.Point(370, 7);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(72, 24);
      this.btnOk.TabIndex = 9;
      this.btnOk.Text = "OK";
      this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
      // 
      // labelCopyright
      // 
      this.labelCopyright.Location = new System.Drawing.Point(46, 83);
      this.labelCopyright.Name = "labelCopyright";
      this.labelCopyright.Size = new System.Drawing.Size(316, 32);
      this.labelCopyright.TabIndex = 8;
      this.labelCopyright.Text = "Copyright (C) 1998-2009 Thomas Graf.";
      // 
      // labelVersion
      // 
      this.labelVersion.Location = new System.Drawing.Point(46, 51);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new System.Drawing.Size(316, 24);
      this.labelVersion.TabIndex = 7;
      this.labelVersion.Text = "<Version>";
      // 
      // pictureBox
      // 
      this.pictureBox.Location = new System.Drawing.Point(6, 11);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(32, 32);
      this.pictureBox.TabIndex = 6;
      this.pictureBox.TabStop = false;
      // 
      // labelDescription
      // 
      this.labelDescription.Location = new System.Drawing.Point(46, 11);
      this.labelDescription.Name = "labelDescription";
      this.labelDescription.Size = new System.Drawing.Size(316, 32);
      this.labelDescription.TabIndex = 5;
      this.labelDescription.Text = "SuperApp - Service application for ISDN transmission devices.";
      // 
      // SimpleAboutForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(448, 122);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.labelCopyright);
      this.Controls.Add(this.labelVersion);
      this.Controls.Add(this.pictureBox);
      this.Controls.Add(this.labelDescription);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SimpleAboutForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Info About ...";
      this.Load += new System.EventHandler(this.SimpleAboutFormLoad);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Label labelCopyright;
    private System.Windows.Forms.Label labelVersion;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Label labelDescription;
  }
}