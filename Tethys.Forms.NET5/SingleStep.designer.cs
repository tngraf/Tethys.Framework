namespace Tethys.Forms
{
  partial class SingleStep
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleStep));
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.picBox = new System.Windows.Forms.PictureBox();
      this.lblStep = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
      this.SuspendLayout();
      // 
      // imageList
      // 
      this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
      this.imageList.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList.Images.SetKeyName(0, "");
      this.imageList.Images.SetKeyName(1, "Arrow right.png");
      this.imageList.Images.SetKeyName(2, "small_check.png");
      this.imageList.Images.SetKeyName(3, "Cross.png");
      this.imageList.Images.SetKeyName(4, "Unknown.png");
      this.imageList.Images.SetKeyName(5, "");
      this.imageList.Images.SetKeyName(6, "");
      this.imageList.Images.SetKeyName(7, "");
      // 
      // picBox
      // 
      this.picBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)));
      this.picBox.Location = new System.Drawing.Point(4, 2);
      this.picBox.Name = "picBox";
      this.picBox.Size = new System.Drawing.Size(20, 20);
      this.picBox.TabIndex = 5;
      this.picBox.TabStop = false;
      // 
      // lblStep
      // 
      this.lblStep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblStep.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblStep.Location = new System.Drawing.Point(32, 2);
      this.lblStep.Name = "lblStep";
      this.lblStep.Size = new System.Drawing.Size(264, 20);
      this.lblStep.TabIndex = 4;
      this.lblStep.Text = "<Label>";
      this.lblStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // SingleStep
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.picBox);
      this.Controls.Add(this.lblStep);
      this.Name = "SingleStep";
      this.Size = new System.Drawing.Size(300, 24);
      ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ImageList imageList;
    private System.Windows.Forms.PictureBox picBox;
    private System.Windows.Forms.Label lblStep;
  }
}
