﻿namespace RecentFileListDemo
{
  partial class MdiChildForm
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
      this.txtBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // txtBox
      // 
      this.txtBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtBox.Location = new System.Drawing.Point(0, 0);
      this.txtBox.Multiline = true;
      this.txtBox.Name = "txtBox";
      this.txtBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtBox.Size = new System.Drawing.Size(481, 262);
      this.txtBox.TabIndex = 0;
      // 
      // MdiChildForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(481, 262);
      this.ControlBox = false;
      this.Controls.Add(this.txtBox);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MdiChildForm";
      this.ShowIcon = false;
      this.Text = "MdiChildForm";
      this.Load += new System.EventHandler(this.MdiChildFormLoad);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtBox;
  }
}