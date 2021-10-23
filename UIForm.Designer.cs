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
            this.TabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DataGridC = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelTotalProc = new System.Windows.Forms.Label();
            this.buttonKill = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonRelaunchCmd = new System.Windows.Forms.Button();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessMem = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.TabControlMain.Size = new System.Drawing.Size(863, 567);
            this.TabControlMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DataGridC);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(855, 541);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Processes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DataGridC
            // 
            this.DataGridC.AllowUserToAddRows = false;
            this.DataGridC.AllowUserToDeleteRows = false;
            this.DataGridC.AllowUserToResizeRows = false;
            this.DataGridC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessName,
            this.ProcessId,
            this.ProcessStatus,
            this.ProcessMem});
            this.DataGridC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridC.Location = new System.Drawing.Point(3, 3);
            this.DataGridC.MultiSelect = false;
            this.DataGridC.Name = "DataGridC";
            this.DataGridC.ReadOnly = true;
            this.DataGridC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridC.Size = new System.Drawing.Size(849, 535);
            this.DataGridC.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(855, 541);
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
            this.richTextBox1.Size = new System.Drawing.Size(849, 535);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // labelTotalProc
            // 
            this.labelTotalProc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalProc.AutoSize = true;
            this.labelTotalProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalProc.Location = new System.Drawing.Point(16, 582);
            this.labelTotalProc.Name = "labelTotalProc";
            this.labelTotalProc.Size = new System.Drawing.Size(91, 20);
            this.labelTotalProc.TabIndex = 1;
            this.labelTotalProc.Text = "Processes: ";
            // 
            // buttonKill
            // 
            this.buttonKill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonKill.Location = new System.Drawing.Point(781, 585);
            this.buttonKill.Name = "buttonKill";
            this.buttonKill.Size = new System.Drawing.Size(88, 35);
            this.buttonKill.TabIndex = 2;
            this.buttonKill.Text = "Kill Process";
            this.buttonKill.UseVisualStyleBackColor = true;
            this.buttonKill.Click += new System.EventHandler(this.buttonKill_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Location = new System.Drawing.Point(687, 585);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(88, 35);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Refresh List";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonRelaunchCmd
            // 
            this.buttonRelaunchCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRelaunchCmd.Location = new System.Drawing.Point(593, 585);
            this.buttonRelaunchCmd.Name = "buttonRelaunchCmd";
            this.buttonRelaunchCmd.Size = new System.Drawing.Size(88, 35);
            this.buttonRelaunchCmd.TabIndex = 2;
            this.buttonRelaunchCmd.Text = "Restart Shell";
            this.buttonRelaunchCmd.UseVisualStyleBackColor = true;
            this.buttonRelaunchCmd.Click += new System.EventHandler(this.buttonRestartShell);
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
            // ProcessMem
            // 
            this.ProcessMem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProcessMem.HeaderText = "Memory";
            this.ProcessMem.Name = "ProcessMem";
            this.ProcessMem.ReadOnly = true;
            this.ProcessMem.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 632);
            this.Controls.Add(this.buttonRelaunchCmd);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonKill);
            this.Controls.Add(this.labelTotalProc);
            this.Controls.Add(this.TabControlMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TabControlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridC)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView DataGridC;
        private System.Windows.Forms.Label labelTotalProc;
        private System.Windows.Forms.Button buttonKill;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonRelaunchCmd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessMem;
    }
}

