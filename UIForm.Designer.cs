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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIForm));
            this.DataGridC = new System.Windows.Forms.DataGridView();
            this.dbgConsoleTxtbox = new System.Windows.Forms.RichTextBox();
            this.buttonRelaunchCmd = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonKill = new System.Windows.Forms.Button();
            this.richTextBoxSearchbox = new System.Windows.Forms.RichTextBox();
            this.totalProcBox = new System.Windows.Forms.RichTextBox();
            this.DragPanel = new System.Windows.Forms.Panel();
            this.windowTitleLabel = new System.Windows.Forms.Label();
            this.buttonMinimise = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.consoleToggleButton = new System.Windows.Forms.Button();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mem_Raw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridC)).BeginInit();
            this.DragPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridC
            // 
            this.DataGridC.AllowUserToAddRows = false;
            this.DataGridC.AllowUserToDeleteRows = false;
            this.DataGridC.AllowUserToResizeColumns = false;
            this.DataGridC.AllowUserToResizeRows = false;
            this.DataGridC.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.DataGridC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridC.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridC.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessName,
            this.ProcessId,
            this.ProcessStatus,
            this.SubStatus,
            this.Mem,
            this.Mem_Raw});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.BlueViolet;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridC.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridC.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataGridC.EnableHeadersVisualStyles = false;
            this.DataGridC.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DataGridC.Location = new System.Drawing.Point(-1, 27);
            this.DataGridC.Name = "DataGridC";
            this.DataGridC.ReadOnly = true;
            this.DataGridC.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.BlueViolet;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridC.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridC.RowHeadersVisible = false;
            this.DataGridC.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataGridC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridC.Size = new System.Drawing.Size(737, 597);
            this.DataGridC.TabIndex = 0;
            this.DataGridC.TabStop = false;
            this.DataGridC.SelectionChanged += new System.EventHandler(this.DataGridC_SelectionChanged);
            this.DataGridC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridC_MouseDown);
            // 
            // dbgConsoleTxtbox
            // 
            this.dbgConsoleTxtbox.BackColor = System.Drawing.Color.Black;
            this.dbgConsoleTxtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dbgConsoleTxtbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbgConsoleTxtbox.ForeColor = System.Drawing.Color.LightGray;
            this.dbgConsoleTxtbox.Location = new System.Drawing.Point(736, 27);
            this.dbgConsoleTxtbox.Name = "dbgConsoleTxtbox";
            this.dbgConsoleTxtbox.ReadOnly = true;
            this.dbgConsoleTxtbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.dbgConsoleTxtbox.Size = new System.Drawing.Size(469, 650);
            this.dbgConsoleTxtbox.TabIndex = 0;
            this.dbgConsoleTxtbox.TabStop = false;
            this.dbgConsoleTxtbox.Text = "";
            this.dbgConsoleTxtbox.WordWrap = false;
            // 
            // buttonRelaunchCmd
            // 
            this.buttonRelaunchCmd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRelaunchCmd.Location = new System.Drawing.Point(439, 35);
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
            this.buttonRefresh.Location = new System.Drawing.Point(589, 53);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(88, 35);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.TabStop = false;
            this.buttonRefresh.Text = "Refresh List";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Visible = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonKill
            // 
            this.buttonKill.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonKill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKill.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKill.Location = new System.Drawing.Point(509, 630);
            this.buttonKill.Name = "buttonKill";
            this.buttonKill.Size = new System.Drawing.Size(88, 39);
            this.buttonKill.TabIndex = 2;
            this.buttonKill.Text = "KILL";
            this.buttonKill.UseVisualStyleBackColor = false;
            this.buttonKill.Click += new System.EventHandler(this.buttonKill_Click);
            // 
            // richTextBoxSearchbox
            // 
            this.richTextBoxSearchbox.AcceptsTab = true;
            this.richTextBoxSearchbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.richTextBoxSearchbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBoxSearchbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxSearchbox.DetectUrls = false;
            this.richTextBoxSearchbox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxSearchbox.ForeColor = System.Drawing.Color.Black;
            this.richTextBoxSearchbox.Location = new System.Drawing.Point(196, 630);
            this.richTextBoxSearchbox.Multiline = false;
            this.richTextBoxSearchbox.Name = "richTextBoxSearchbox";
            this.richTextBoxSearchbox.Size = new System.Drawing.Size(213, 39);
            this.richTextBoxSearchbox.TabIndex = 3;
            this.richTextBoxSearchbox.Text = "";
            this.richTextBoxSearchbox.WordWrap = false;
            this.richTextBoxSearchbox.TextChanged += new System.EventHandler(this.richTextBoxSearchbox_TextChanged);
            // 
            // totalProcBox
            // 
            this.totalProcBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.totalProcBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.totalProcBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalProcBox.DetectUrls = false;
            this.totalProcBox.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalProcBox.ForeColor = System.Drawing.SystemColors.Window;
            this.totalProcBox.Location = new System.Drawing.Point(5, 630);
            this.totalProcBox.Name = "totalProcBox";
            this.totalProcBox.ReadOnly = true;
            this.totalProcBox.Size = new System.Drawing.Size(185, 39);
            this.totalProcBox.TabIndex = 4;
            this.totalProcBox.Text = "PLACEHOLDER";
            this.totalProcBox.WordWrap = false;
            // 
            // DragPanel
            // 
            this.DragPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DragPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.DragPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DragPanel.Controls.Add(this.windowTitleLabel);
            this.DragPanel.Controls.Add(this.consoleToggleButton);
            this.DragPanel.Controls.Add(this.buttonMinimise);
            this.DragPanel.Controls.Add(this.buttonQuit);
            this.DragPanel.Location = new System.Drawing.Point(0, 2);
            this.DragPanel.Name = "DragPanel";
            this.DragPanel.Size = new System.Drawing.Size(1206, 30);
            this.DragPanel.TabIndex = 5;
            this.DragPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseDown);
            this.DragPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseUp);
            // 
            // windowTitleLabel
            // 
            this.windowTitleLabel.AutoSize = true;
            this.windowTitleLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowTitleLabel.ForeColor = System.Drawing.Color.White;
            this.windowTitleLabel.Location = new System.Drawing.Point(1, 3);
            this.windowTitleLabel.Name = "windowTitleLabel";
            this.windowTitleLabel.Size = new System.Drawing.Size(99, 19);
            this.windowTitleLabel.TabIndex = 0;
            this.windowTitleLabel.Text = "TaskKiller";
            // 
            // buttonMinimise
            // 
            this.buttonMinimise.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonMinimise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.buttonMinimise.FlatAppearance.BorderSize = 0;
            this.buttonMinimise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimise.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinimise.ForeColor = System.Drawing.Color.White;
            this.buttonMinimise.Location = new System.Drawing.Point(1149, -4);
            this.buttonMinimise.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonMinimise.Name = "buttonMinimise";
            this.buttonMinimise.Size = new System.Drawing.Size(27, 33);
            this.buttonMinimise.TabIndex = 2;
            this.buttonMinimise.Text = "-";
            this.buttonMinimise.UseVisualStyleBackColor = false;
            this.buttonMinimise.Click += new System.EventHandler(this.buttonMin_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.buttonQuit.FlatAppearance.BorderSize = 0;
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuit.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuit.ForeColor = System.Drawing.Color.White;
            this.buttonQuit.Location = new System.Drawing.Point(1176, -4);
            this.buttonQuit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(27, 33);
            this.buttonQuit.TabIndex = 2;
            this.buttonQuit.Text = "X";
            this.buttonQuit.UseVisualStyleBackColor = false;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.DataGridC);
            this.panel1.Controls.Add(this.richTextBoxSearchbox);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Controls.Add(this.buttonKill);
            this.panel1.Controls.Add(this.dbgConsoleTxtbox);
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Controls.Add(this.totalProcBox);
            this.panel1.Controls.Add(this.buttonRelaunchCmd);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1206, 678);
            this.panel1.TabIndex = 6;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.ForeColor = System.Drawing.Color.Silver;
            this.buttonClear.Location = new System.Drawing.Point(415, 630);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(88, 39);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "CLEAR";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // consoleToggleButton
            // 
            this.consoleToggleButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.consoleToggleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.consoleToggleButton.FlatAppearance.BorderSize = 0;
            this.consoleToggleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.consoleToggleButton.Font = new System.Drawing.Font("Consolas", 18F);
            this.consoleToggleButton.ForeColor = System.Drawing.Color.White;
            this.consoleToggleButton.Location = new System.Drawing.Point(1124, -4);
            this.consoleToggleButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.consoleToggleButton.Name = "consoleToggleButton";
            this.consoleToggleButton.Size = new System.Drawing.Size(27, 33);
            this.consoleToggleButton.TabIndex = 2;
            this.consoleToggleButton.Text = "◀";
            this.consoleToggleButton.UseVisualStyleBackColor = false;
            this.consoleToggleButton.Click += new System.EventHandler(this.ToggleActivityConsole);
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
            // SubStatus
            // 
            this.SubStatus.HeaderText = "State";
            this.SubStatus.Name = "SubStatus";
            this.SubStatus.ReadOnly = true;
            this.SubStatus.Width = 140;
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
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(12)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1206, 680);
            this.Controls.Add(this.DragPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UIForm";
            this.Text = "TaskKiller";
            this.Activated += new System.EventHandler(this.UIForm_Activated);
            this.Deactivate += new System.EventHandler(this.UIForm_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridC)).EndInit();
            this.DragPanel.ResumeLayout(false);
            this.DragPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox dbgConsoleTxtbox;
        private System.Windows.Forms.DataGridView DataGridC;
        private System.Windows.Forms.Button buttonKill;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonRelaunchCmd;
        private System.Windows.Forms.RichTextBox richTextBoxSearchbox;
        private System.Windows.Forms.RichTextBox totalProcBox;
        private System.Windows.Forms.Panel DragPanel;
        private System.Windows.Forms.Label windowTitleLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonMinimise;
        private System.Windows.Forms.Button consoleToggleButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mem_Raw;
    }
}

