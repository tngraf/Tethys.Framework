#region Header
// ---------------------------------------------------------------------------
// Tethys.Forms
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
// <copyright file="Form1.cs" company="Thomas Graf">
// Copyright  1998 - 2013 by Thomas Graf
//            Email: tngraf@gmx.de
//            See the file "License.rtf" for information on usage and 
//            redistribution of this file and for a DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 4.00.00.00 of 13Apr14
// Project .. Tethys.Forms
// Creater .. Thomas Graf (tg)
// System ... Microsoft .Net Framework 4.5
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 03Nov22 3.00.02.00 tg: initial version
//
// ---------------------------------------------------------------------------
#endregion

namespace TgVersionInfoDemo
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;

    using Tethys.Reflection;

    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private readonly System.ComponentModel.Container components = null;

        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label labelDay;
        private Label labelMonth;
        private Label labelYear;
        private Label labelReleaseMode;
        private GroupBox groupBox2;
        private Label labelFirstYear;
        private Label label6;
        private Label labelGetDateBuild;
        private Label labelGetLevel;
        private Label labelGetVersion;
        private Label label5;
        private Label label7;
        private Label label8;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and
        /// unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            } // if

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelFirstYear = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelReleaseMode = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelMonth = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelGetVersion = new System.Windows.Forms.Label();
            this.labelGetLevel = new System.Windows.Forms.Label();
            this.labelGetDateBuild = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelFirstYear);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labelReleaseMode);
            this.groupBox1.Controls.Add(this.labelYear);
            this.groupBox1.Controls.Add(this.labelMonth);
            this.groupBox1.Controls.Add(this.labelDay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information stored in the assembly with custom attributes";
            // 
            // labelFirstYear
            // 
            this.labelFirstYear.Location = new System.Drawing.Point(156, 80);
            this.labelFirstYear.Name = "labelFirstYear";
            this.labelFirstYear.Size = new System.Drawing.Size(80, 16);
            this.labelFirstYear.TabIndex = 9;
            this.labelFirstYear.Text = "<FirstYear>";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(68, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "First year:";
            // 
            // labelReleaseMode
            // 
            this.labelReleaseMode.Location = new System.Drawing.Point(156, 100);
            this.labelReleaseMode.Name = "labelReleaseMode";
            this.labelReleaseMode.Size = new System.Drawing.Size(80, 16);
            this.labelReleaseMode.TabIndex = 7;
            this.labelReleaseMode.Text = "<ReleaseMode>";
            // 
            // labelYear
            // 
            this.labelYear.Location = new System.Drawing.Point(156, 60);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(80, 16);
            this.labelYear.TabIndex = 6;
            this.labelYear.Text = "<Year>";
            // 
            // labelMonth
            // 
            this.labelMonth.Location = new System.Drawing.Point(156, 40);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(80, 16);
            this.labelMonth.TabIndex = 5;
            this.labelMonth.Text = "<Month>";
            // 
            // labelDay
            // 
            this.labelDay.Location = new System.Drawing.Point(156, 20);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(80, 16);
            this.labelDay.TabIndex = 4;
            this.labelDay.Text = "<Day>";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(68, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "ReleaseMode:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(68, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Year:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(68, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Month:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(68, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Day:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.labelGetVersion);
            this.groupBox2.Controls.Add(this.labelGetLevel);
            this.groupBox2.Controls.Add(this.labelGetDateBuild);
            this.groupBox2.Location = new System.Drawing.Point(8, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 146);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Information returned by static functions ";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "GetVersion() =";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "GetLevel() =";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "GetDateBuild() =";
            // 
            // labelGetVersion
            // 
            this.labelGetVersion.AutoSize = true;
            this.labelGetVersion.Location = new System.Drawing.Point(108, 68);
            this.labelGetVersion.Name = "labelGetVersion";
            this.labelGetVersion.Size = new System.Drawing.Size(71, 13);
            this.labelGetVersion.TabIndex = 2;
            this.labelGetVersion.Text = "<GetVersion>";
            // 
            // labelGetLevel
            // 
            this.labelGetLevel.AutoSize = true;
            this.labelGetLevel.Location = new System.Drawing.Point(108, 48);
            this.labelGetLevel.Name = "labelGetLevel";
            this.labelGetLevel.Size = new System.Drawing.Size(62, 13);
            this.labelGetLevel.TabIndex = 1;
            this.labelGetLevel.Text = "<GetLevel>";
            // 
            // labelGetDateBuild
            // 
            this.labelGetDateBuild.AutoSize = true;
            this.labelGetDateBuild.Location = new System.Drawing.Point(108, 28);
            this.labelGetDateBuild.Name = "labelGetDateBuild";
            this.labelGetDateBuild.Size = new System.Drawing.Size(82, 13);
            this.labelGetDateBuild.TabIndex = 0;
            this.labelGetDateBuild.Text = "<GetDateBuild>";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(415, 311);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "TgVersionInfo Demo";
            this.Load += new System.EventHandler(this.Form1Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.Run(new Form1());
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        private void Form1Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;

            var dayAttribute =
              (AssemblyDayAttribute)Attribute.GetCustomAttribute(assembly,
              typeof(AssemblyDayAttribute));
            Debug.Assert(dayAttribute != null, "dayAttribute must not be empty!");
            labelDay.Text = dayAttribute.Day.ToString(culture);

            var monthAttribute =
              (AssemblyMonthAttribute)Attribute.GetCustomAttribute(assembly,
              typeof(AssemblyMonthAttribute));
            Debug.Assert(monthAttribute != null, "monthAttribute must not be empty!");
            labelMonth.Text = monthAttribute.Month.ToString(culture);

            var yearAttribute =
              (AssemblyYearAttribute)Attribute.GetCustomAttribute(assembly,
              typeof(AssemblyYearAttribute));
            Debug.Assert(yearAttribute != null, "yearAttribute must not be empty!");
            labelYear.Text = yearAttribute.Year.ToString(culture);

            var firstYearAttribute =
              (AssemblyFirstYearAttribute)Attribute.GetCustomAttribute(assembly,
              typeof(AssemblyFirstYearAttribute));
            Debug.Assert(firstYearAttribute != null, "firstYearAttribute must not be empty!");
            labelFirstYear.Text = firstYearAttribute.FirstYear.ToString(culture);

            var releaseModeAttribute =
              (AssemblyReleaseModeAttribute)Attribute.GetCustomAttribute(assembly,
              typeof(AssemblyReleaseModeAttribute));
            Debug.Assert(releaseModeAttribute != null, "releaseModeAttribute must not be empty!");
            labelReleaseMode.Text = releaseModeAttribute.ReleaseMode.ToString();

            Version version = assembly.GetName().Version;

            labelGetDateBuild.Text = VersionInfo.GetDateBuild(assembly);
            labelGetLevel.Text = VersionInfo.GetLevel(assembly, version);
            labelGetVersion.Text = VersionInfo.GetVersion(assembly, version, culture);
        }
    }
}
