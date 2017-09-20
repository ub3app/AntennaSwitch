namespace AntennaSwitchGUI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.comPort = new System.IO.Ports.SerialPort(this.components);
            this.ntfyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.itemLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemAntenna1 = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAntenna2 = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAntenna3 = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAntenna4 = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAntenna5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.chckBox1 = new System.Windows.Forms.CheckBox();
            this.chckBox2 = new System.Windows.Forms.CheckBox();
            this.chckBox3 = new System.Windows.Forms.CheckBox();
            this.chckBox4 = new System.Windows.Forms.CheckBox();
            this.chckBox5 = new System.Windows.Forms.CheckBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtAntName1 = new System.Windows.Forms.TextBox();
            this.txtAntName2 = new System.Windows.Forms.TextBox();
            this.txtAntName3 = new System.Windows.Forms.TextBox();
            this.txtAntName4 = new System.Windows.Forms.TextBox();
            this.txtAntName5 = new System.Windows.Forms.TextBox();
            this.lblShow = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(33, 20);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(100, 21);
            this.cboPort.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(139, 18);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // comPort
            // 
            this.comPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.comPort_DataReceived);
            // 
            // ntfyIcon
            // 
            this.ntfyIcon.ContextMenuStrip = this.ctxMenu;
            this.ntfyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfyIcon.Icon")));
            this.ntfyIcon.Text = "Antenna Switch";
            this.ntfyIcon.Visible = true;
            this.ntfyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ntfyIcon_MouseClick);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemSettings,
            this.itemLog,
            this.toolStripMenuItem1,
            this.itemAntenna1,
            this.itemAntenna2,
            this.itemAntenna3,
            this.itemAntenna4,
            this.itemAntenna5,
            this.toolStripMenuItem2,
            this.itemExit});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(129, 192);
            this.ctxMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ctxMenu_MouseUp);
            // 
            // itemSettings
            // 
            this.itemSettings.Name = "itemSettings";
            this.itemSettings.Size = new System.Drawing.Size(128, 22);
            this.itemSettings.Text = "Settings";
            this.itemSettings.Click += new System.EventHandler(this.itemSettings_Click);
            // 
            // itemLog
            // 
            this.itemLog.Name = "itemLog";
            this.itemLog.Size = new System.Drawing.Size(128, 22);
            this.itemLog.Text = "Log";
            this.itemLog.Click += new System.EventHandler(this.itemLog_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(125, 6);
            // 
            // itemAntenna1
            // 
            this.itemAntenna1.Name = "itemAntenna1";
            this.itemAntenna1.Size = new System.Drawing.Size(128, 22);
            this.itemAntenna1.Text = "Antenna 1";
            this.itemAntenna1.Click += new System.EventHandler(this.itemAntenna1_Click);
            // 
            // itemAntenna2
            // 
            this.itemAntenna2.Name = "itemAntenna2";
            this.itemAntenna2.Size = new System.Drawing.Size(128, 22);
            this.itemAntenna2.Text = "Antenna 2";
            this.itemAntenna2.Click += new System.EventHandler(this.itemAntenna2_Click);
            // 
            // itemAntenna3
            // 
            this.itemAntenna3.Name = "itemAntenna3";
            this.itemAntenna3.Size = new System.Drawing.Size(128, 22);
            this.itemAntenna3.Text = "Antenna 3";
            this.itemAntenna3.Click += new System.EventHandler(this.itemAntenna3_Click);
            // 
            // itemAntenna4
            // 
            this.itemAntenna4.Name = "itemAntenna4";
            this.itemAntenna4.Size = new System.Drawing.Size(128, 22);
            this.itemAntenna4.Text = "Antenna 4";
            this.itemAntenna4.Click += new System.EventHandler(this.itemAntenna4_Click);
            // 
            // itemAntenna5
            // 
            this.itemAntenna5.Name = "itemAntenna5";
            this.itemAntenna5.Size = new System.Drawing.Size(128, 22);
            this.itemAntenna5.Text = "Antenna 5";
            this.itemAntenna5.Click += new System.EventHandler(this.itemAntenna5_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(125, 6);
            // 
            // itemExit
            // 
            this.itemExit.Name = "itemExit";
            this.itemExit.Size = new System.Drawing.Size(128, 22);
            this.itemExit.Text = "Exit";
            this.itemExit.Click += new System.EventHandler(this.itemExit_Click);
            // 
            // chckBox1
            // 
            this.chckBox1.AutoSize = true;
            this.chckBox1.Location = new System.Drawing.Point(12, 71);
            this.chckBox1.Name = "chckBox1";
            this.chckBox1.Size = new System.Drawing.Size(15, 14);
            this.chckBox1.TabIndex = 2;
            this.chckBox1.UseVisualStyleBackColor = true;
            // 
            // chckBox2
            // 
            this.chckBox2.AutoSize = true;
            this.chckBox2.Location = new System.Drawing.Point(12, 94);
            this.chckBox2.Name = "chckBox2";
            this.chckBox2.Size = new System.Drawing.Size(15, 14);
            this.chckBox2.TabIndex = 3;
            this.chckBox2.UseVisualStyleBackColor = true;
            // 
            // chckBox3
            // 
            this.chckBox3.AutoSize = true;
            this.chckBox3.Location = new System.Drawing.Point(12, 117);
            this.chckBox3.Name = "chckBox3";
            this.chckBox3.Size = new System.Drawing.Size(15, 14);
            this.chckBox3.TabIndex = 4;
            this.chckBox3.UseVisualStyleBackColor = true;
            // 
            // chckBox4
            // 
            this.chckBox4.AutoSize = true;
            this.chckBox4.Location = new System.Drawing.Point(12, 140);
            this.chckBox4.Name = "chckBox4";
            this.chckBox4.Size = new System.Drawing.Size(15, 14);
            this.chckBox4.TabIndex = 5;
            this.chckBox4.UseVisualStyleBackColor = true;
            // 
            // chckBox5
            // 
            this.chckBox5.AutoSize = true;
            this.chckBox5.Location = new System.Drawing.Point(12, 163);
            this.chckBox5.Name = "chckBox5";
            this.chckBox5.Size = new System.Drawing.Size(15, 14);
            this.chckBox5.TabIndex = 6;
            this.chckBox5.UseVisualStyleBackColor = true;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(9, 4);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(58, 13);
            this.lblPort.TabIndex = 7;
            this.lblPort.Text = "Serial Port:";
            // 
            // txtAntName1
            // 
            this.txtAntName1.Location = new System.Drawing.Point(33, 65);
            this.txtAntName1.Name = "txtAntName1";
            this.txtAntName1.Size = new System.Drawing.Size(181, 20);
            this.txtAntName1.TabIndex = 8;
            // 
            // txtAntName2
            // 
            this.txtAntName2.Location = new System.Drawing.Point(33, 88);
            this.txtAntName2.Name = "txtAntName2";
            this.txtAntName2.Size = new System.Drawing.Size(181, 20);
            this.txtAntName2.TabIndex = 9;
            // 
            // txtAntName3
            // 
            this.txtAntName3.Location = new System.Drawing.Point(33, 111);
            this.txtAntName3.Name = "txtAntName3";
            this.txtAntName3.Size = new System.Drawing.Size(181, 20);
            this.txtAntName3.TabIndex = 10;
            // 
            // txtAntName4
            // 
            this.txtAntName4.Location = new System.Drawing.Point(33, 134);
            this.txtAntName4.Name = "txtAntName4";
            this.txtAntName4.Size = new System.Drawing.Size(181, 20);
            this.txtAntName4.TabIndex = 11;
            // 
            // txtAntName5
            // 
            this.txtAntName5.Location = new System.Drawing.Point(33, 157);
            this.txtAntName5.Name = "txtAntName5";
            this.txtAntName5.Size = new System.Drawing.Size(181, 20);
            this.txtAntName5.TabIndex = 12;
            // 
            // lblShow
            // 
            this.lblShow.AutoSize = true;
            this.lblShow.Location = new System.Drawing.Point(9, 49);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(77, 13);
            this.lblShow.TabIndex = 13;
            this.lblShow.Text = "Show in menu:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(140, 49);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(79, 13);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "Antenna name:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(41, 183);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(122, 183);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 212);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.txtAntName5);
            this.Controls.Add(this.txtAntName4);
            this.Controls.Add(this.txtAntName3);
            this.Controls.Add(this.txtAntName2);
            this.Controls.Add(this.txtAntName1);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.chckBox5);
            this.Controls.Add(this.chckBox4);
            this.Controls.Add(this.chckBox3);
            this.Controls.Add(this.chckBox2);
            this.Controls.Add(this.chckBox1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.cboPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Button btnOpen;
        public System.IO.Ports.SerialPort comPort;
        private System.Windows.Forms.NotifyIcon ntfyIcon;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem itemSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem itemAntenna1;
        private System.Windows.Forms.ToolStripMenuItem itemAntenna2;
        private System.Windows.Forms.ToolStripMenuItem itemAntenna3;
        private System.Windows.Forms.ToolStripMenuItem itemAntenna4;
        private System.Windows.Forms.ToolStripMenuItem itemAntenna5;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem itemExit;
        private System.Windows.Forms.ToolStripMenuItem itemLog;
        private System.Windows.Forms.CheckBox chckBox1;
        private System.Windows.Forms.CheckBox chckBox2;
        private System.Windows.Forms.CheckBox chckBox3;
        private System.Windows.Forms.CheckBox chckBox4;
        private System.Windows.Forms.CheckBox chckBox5;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtAntName1;
        private System.Windows.Forms.TextBox txtAntName2;
        private System.Windows.Forms.TextBox txtAntName3;
        private System.Windows.Forms.TextBox txtAntName4;
        private System.Windows.Forms.TextBox txtAntName5;
        private System.Windows.Forms.Label lblShow;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}

