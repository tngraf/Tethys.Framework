namespace Tethys.Forms
{
    partial class LedControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be 
        /// disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LedControl));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.imageListLeds = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // imageListLeds
            // 
            this.imageListLeds.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLeds.ImageStream")));
            this.imageListLeds.TransparentColor = System.Drawing.Color.Magenta;
            this.imageListLeds.Images.SetKeyName(0, "");
            this.imageListLeds.Images.SetKeyName(1, "");
            this.imageListLeds.Images.SetKeyName(2, "");
            this.imageListLeds.Images.SetKeyName(3, "");
            this.imageListLeds.Images.SetKeyName(4, "");
            this.imageListLeds.Images.SetKeyName(5, "");
            this.imageListLeds.Images.SetKeyName(6, "");
            this.imageListLeds.Images.SetKeyName(7, "");
            this.imageListLeds.Images.SetKeyName(8, "");
            // 
            // LedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LedControl";
            this.Size = new System.Drawing.Size(18, 18);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ImageList imageListLeds;
    }
}
