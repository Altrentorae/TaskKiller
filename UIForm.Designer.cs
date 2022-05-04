namespace TaskKiller
{
    partial class UIForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIForm));
            this.TabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonRelaunchCmd = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.DataGridC = new System.Windows.Forms.DataGridView();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mem_Raw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonKill = new System.Windows.Forms.Button();
            this.notificationRtb = new System.Windows.Forms.RichTextBox();
            this.richTextBoxSearchbox = new System.Windows.Forms.RichTextBox();
            this.totalProcBox = new System.Windows.Forms.RichTextBox();
            this.TabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridC)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlMain
            // 
            this.TabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlMain.Controls.Add(this.tabPage1);
            this.TabControlMain.Controls.Add(this.tabPage2);
            this.TabControlMain.Location = new System.Drawing.Point(13, 12);
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.SelectedIndex = 0;
            this.TabControlMain.Size = new System.Drawing.Size(680, 567);
            this.TabControlMain.TabIndex = 0;
            this.TabControlMain.SelectedIndexChanged += new System.EventHandler(this.TabPages_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonRelaunchCmd);
            this.tabPage1.Controls.Add(this.buttonRefresh);
            this.tabPage1.Controls.Add(this.DataGridC);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(672, 541);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Processes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonRelaunchCmd
            // 
            this.buttonRelaunchCmd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRelaunchCmd.Location = new System.Drawing.Point(469, 47);
            this.buttonRelaunchCmd.Name = "buttonRelaunchCmd";
            this.buttonRelaunchCmd.Size = new System.Drawing.Size(88, 35);
            this.buttonRelaunchCmd.TabIndex = 2;
            this.buttonRelaunchCmd.TabStop = false;
            this.buttonRelaunchCmd.Text = "Restart Shell";
            this.buttonRelaunchCmd.UseVisualStyleBackColor = true;
            this.buttonRelaunchCmd.Visible = false;
            this.buttonRelaunchCmd.Click += new System.EventHandler(this.buttonRestartShell);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRefresh.Location = new System.Drawing.Point(469, 6);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(88, 35);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.TabStop = false;
            this.buttonRefresh.Text = "Refresh List";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Visible = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // DataGridC
            // 
            this.DataGridC.AllowUserToAddRows = false;
            this.DataGridC.AllowUserToDeleteRows = false;
            this.DataGridC.AllowUserToResizeRows = false;
            this.DataGridC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridC.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessName,
            this.ProcessId,
            this.ProcessStatus,
            this.Mem,
            this.Mem_Raw});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.BlueViolet;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridC.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridC.GridColor = System.Drawing.SystemColors.Control;
            this.DataGridC.Location = new System.Drawing.Point(3, 3);
            this.DataGridC.Name = "DataGridC";
            this.DataGridC.ReadOnly = true;
            this.DataGridC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridC.Size = new System.Drawing.Size(666, 535);
            this.DataGridC.TabIndex = 0;
            // 
            // ProcessName
            // 
            this.ProcessName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProcessName.HeaderText = "Name";
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.ReadOnly = true;
            // 
            // ProcessId
            // 
            this.ProcessId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProcessId.HeaderText = "Id";
            this.ProcessId.Name = "ProcessId";
            this.ProcessId.ReadOnly = true;
            // 
            // ProcessStatus
            // 
            this.ProcessStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProcessStatus.HeaderText = "Status";
            this.ProcessStatus.Name = "ProcessStatus";
            this.ProcessStatus.ReadOnly = true;
            // 
            // Mem
            // 
            this.Mem.HeaderText = "Memory";
            this.Mem.Name = "Mem";
            this.Mem.ReadOnly = true;
            // 
            // Mem_Raw
            // 
            this.Mem_Raw.HeaderText = "Mem_Raw";
            this.Mem_Raw.Name = "Mem_Raw";
            this.Mem_Raw.ReadOnly = true;
            this.Mem_Raw.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(672, 541);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(666, 535);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // buttonKill
            // 
            this.buttonKill.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonKill.Location = new System.Drawing.Point(598, 585);
            this.buttonKill.Name = "buttonKill";
            this.buttonKill.Size = new System.Drawing.Size(88, 35);
            this.buttonKill.TabIndex = 2;
            this.buttonKill.Text = "Kill Process";
            this.buttonKill.UseVisualStyleBackColor = true;
            this.buttonKill.Click += new System.EventHandler(this.buttonKill_Click);
            // 
            // notificationRtb
            // 
            this.notificationRtb.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.notificationRtb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.notificationRtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationRtb.ForeColor = System.Drawing.SystemColors.Window;
            this.notificationRtb.Location = new System.Drawing.Point(119, 585);
            this.notificationRtb.Name = "notificationRtb";
            this.notificationRtb.ReadOnly = true;
            this.notificationRtb.Size = new System.Drawing.Size(241, 35);
            this.notificationRtb.TabIndex = 3;
            this.notificationRtb.Text = "";
            this.notificationRtb.WordWrap = false;
            // 
            // richTextBoxSearchbox
            // 
            this.richTextBoxSearchbox.AcceptsTab = true;
            this.richTextBoxSearchbox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.richTextBoxSearchbox.BackColor = System.Drawing.Color.White;
            this.richTextBoxSearchbox.DetectUrls = false;
            this.richTextBoxSearchbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxSearchbox.ForeColor = System.Drawing.Color.Black;
            this.richTextBoxSearchbox.Location = new System.Drawing.Point(366, 585);
            this.richTextBoxSearchbox.Multiline = false;
            this.richTextBoxSearchbox.Name = "richTextBoxSearchbox";
            this.richTextBoxSearchbox.Size = new System.Drawing.Size(226, 35);
            this.richTextBoxSearchbox.TabIndex = 3;
            this.richTextBoxSearchbox.Text = "";
            this.richTextBoxSearchbox.WordWrap = false;
            this.richTextBoxSearchbox.TextChanged += new System.EventHandler(this.richTextBoxSearchbox_TextChanged);
            // 
            // totalProcBox
            // 
            this.totalProcBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.totalProcBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.totalProcBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalProcBox.ForeColor = System.Drawing.SystemColors.Window;
            this.totalProcBox.Location = new System.Drawing.Point(17, 585);
            this.totalProcBox.Name = "totalProcBox";
            this.totalProcBox.ReadOnly = true;
            this.totalProcBox.Size = new System.Drawing.Size(96, 35);
            this.totalProcBox.TabIndex = 4;
            this.totalProcBox.Text = "";
            this.totalProcBox.WordWrap = false;
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 632);
            this.Controls.Add(this.totalProcBox);
            this.Controls.Add(this.richTextBoxSearchbox);
            this.Controls.Add(this.notificationRtb);
            this.Controls.Add(this.buttonKill);
            this.Controls.Add(this.TabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UIForm";
            this.Text = "TaskKiller";
            this.TabControlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridC)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView DataGridC;
        private System.Windows.Forms.Button buttonKill;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonRelaunchCmd;
        private System.Windows.Forms.RichTextBox notificationRtb;
        private System.Windows.Forms.RichTextBox richTextBoxSearchbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mem_Raw;
        private System.Windows.Forms.RichTextBox totalProcBox;
    }
}

