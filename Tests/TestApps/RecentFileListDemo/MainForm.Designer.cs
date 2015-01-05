namespace RecentFileListDemo
{
  partial class MainForm
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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
      this.menuFileClose = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.menuFileMru = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.menuStrip1.SuspendLayout();
      this.statusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(556, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileClose,
            this.toolStripSeparator1,
            this.menuFileMru,
            this.toolStripSeparator2,
            this.menuFileExit});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // menuFileOpen
      // 
      this.menuFileOpen.Name = "menuFileOpen";
      this.menuFileOpen.Size = new System.Drawing.Size(152, 22);
      this.menuFileOpen.Text = "&Open...";
      this.menuFileOpen.Click += new System.EventHandler(this.MenuFileOpenClick);
      // 
      // menuFileSave
      // 
      this.menuFileSave.Name = "menuFileSave";
      this.menuFileSave.Size = new System.Drawing.Size(152, 22);
      this.menuFileSave.Text = "&Save";
      this.menuFileSave.Click += new System.EventHandler(this.MenuFileSaveClick);
      // 
      // menuFileClose
      // 
      this.menuFileClose.Name = "menuFileClose";
      this.menuFileClose.Size = new System.Drawing.Size(152, 22);
      this.menuFileClose.Text = "Close";
      this.menuFileClose.Click += new System.EventHandler(this.MenuFileCloseClick);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
      // 
      // menuFileMru
      // 
      this.menuFileMru.Name = "menuFileMru";
      this.menuFileMru.Size = new System.Drawing.Size(152, 22);
      this.menuFileMru.Click += new System.EventHandler(this.MenuFileMruClick);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
      // 
      // menuFileExit
      // 
      this.menuFileExit.Name = "menuFileExit";
      this.menuFileExit.Size = new System.Drawing.Size(152, 22);
      this.menuFileExit.Text = "E&xit";
      this.menuFileExit.Click += new System.EventHandler(this.MenuFileExitClick);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
      this.statusStrip.Location = new System.Drawing.Point(0, 333);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(556, 22);
      this.statusStrip.TabIndex = 1;
      this.statusStrip.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 17);
      this.toolStripStatusLabel1.Text = "<Status>";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(556, 355);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.menuStrip1);
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.Text = "RecentFileList Demo";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
      this.Load += new System.EventHandler(this.MainFormLoad);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
    private System.Windows.Forms.ToolStripMenuItem menuFileSave;
    private System.Windows.Forms.ToolStripMenuItem menuFileClose;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem menuFileMru;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem menuFileExit;
  }
}

