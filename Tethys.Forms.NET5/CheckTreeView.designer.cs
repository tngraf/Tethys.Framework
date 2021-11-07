namespace Tethys.Forms
{
  partial class CheckTreeView
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckTreeView));
      this.imageListCheckBoxes = new System.Windows.Forms.ImageList(this.components);
      this.SuspendLayout();
      // 
      // imageListCheckBoxes
      // 
      this.imageListCheckBoxes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCheckBoxes.ImageStream")));
      this.imageListCheckBoxes.TransparentColor = System.Drawing.Color.Transparent;
      this.imageListCheckBoxes.Images.SetKeyName(0, "checkemp.png");
      this.imageListCheckBoxes.Images.SetKeyName(1, "checkon.png");
      this.imageListCheckBoxes.Images.SetKeyName(2, "checkgre.png");
      this.ResumeLayout(false);

    }
    #endregion

    private System.Windows.Forms.ImageList imageListCheckBoxes;
  }
}
