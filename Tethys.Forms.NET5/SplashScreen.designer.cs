namespace Tethys.Forms
{
  partial class SplashScreen
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
      this.components = new System.ComponentModel.Container();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.pictureBox = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // timer
      // 
      this.timer.Interval = 5000;
      this.timer.Tick += new System.EventHandler(this.TimerTick);
      // 
      // pictureBox
      // 
      this.pictureBox.Location = new System.Drawing.Point(0, 0);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(378, 268);
      this.pictureBox.TabIndex = 1;
      this.pictureBox.TabStop = false;
      this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HideWindowOnMouseEvent);
      this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintHandler);
      // 
      // SplashScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(378, 268);
      this.ControlBox = false;
      this.Controls.Add(this.pictureBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SplashScreen";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "SplashScreen";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.SplashScreenLoad);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HideWindowOnMouseEvent);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HideWindowOnKeyEvent);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.PictureBox pictureBox;
  }
}