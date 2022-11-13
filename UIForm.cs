using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



#pragma warning disable IDE1006    // IDE naming rules

namespace TaskKiller
{
    public partial class UIForm : Form
    {
        public DebugConsoleController DbgCon;
        public NotificationTextboxController notifBox;

        int processCount = 0;
        List<ProcessInfo> Processes = new List<ProcessInfo>();
        Process cmd;
        static AdvTimer t;
        readonly string placeHolderText = CONST.Text.searchPlaceholder;
        public UIForm()
        {
            string[] args = Extend.GetArgs();
            bool authValid = AuthorityManager.IsAdmin();

            if(!authValid && !args.Contains(CONST.Flags.skipAuth))
            {
                AuthorityManager.RelaunchAsAdmin(args);
                Application.Exit();
                this.Close();
                return;
            }

            this.Text = "TaskKiller"; //This is purely for title/desc read elsewhere. Actual window text is windowTitleLabel.Text

            InitializeComponent();
            InitTAC();

            {
                buttonRefresh.Visible = false;
                buttonRelaunchCmd.Visible = false;
            }

            DataGridC.InitMiscDGVSettings();
            DataGridC.Columns[0].Width = 280;

            RichTextBox DgbTextBox = dbgConsoleTxtbox;
            DbgCon = new DebugConsoleController(DgbTextBox);
            //notifBox = new NotificationTextboxController(notificationRtb, DbgCon);
            DbgCon.DebugLogInitAutoScroll();
            DbgCon.DebugLog("UI form init complete");
            this.InitShellProc(ref cmd, false);

            if (authValid) { DbgCon.DebugLog("Admin perms valid", CONST.Colors.DefaultSuccessColor); }
            else { DbgCon.DebugLog("Admin perms invalid!!", CONST.Colors.DefaultErrColor); }
            
            t = new AdvTimer(5000, 1000);
            t.Tick += (s, e) => T_Tick(s, e);
            t.SubTick += (s, e) => T_SubTick(s, e);

            //refreshCountdownInit = (t.Interval/1000);
            //refreshCountdown = (t.Interval/1000);

            t.StartAll();

            buttonRefresh_Click(null, null);

            
            richTextBoxSearchbox.InitEvents(placeHolderText);
            this.Shown += (s, e) => { DataGridC.ClearSelection(); };
            buttonQuit.FlatAppearance.BorderSize = 0;
            buttonMinimise.FlatAppearance.BorderSize = 0;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            buttonRefresh_Click(null, null);

            while (true)
            {
                ShellControl.ShellStatus status = ShellControl.CmdExists(cmd);
                if(status == ShellControl.ShellStatus.Working) { break; }
                if(status == ShellControl.ShellStatus.Null) { DbgCon.DebugLog("Shell instance not found", Color.Red); }
                if(status == ShellControl.ShellStatus.Hang) { DbgCon.DebugLog("Shell instance not responding", Color.Red); }
                this.InitShellProc(ref cmd, false);
            }

        }
        private void T_SubTick(object sender, EventArgs e) {}

        private BackgroundWorker refreshWorker;
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DbgCon.DebugLog("-----Refreshing process list-----");

            if(refreshWorker == null)
            {
                refreshWorker = new BackgroundWorker();
                refreshWorker.DoWork += (s, ev) =>
                {
                    for (int i = 0; i < Processes.Count; i++)
                    {
                        ProcessInfo p = Processes[i];
                        p.RefreshProc();
                    }
                };
            }
            else 
            {
                if (!refreshWorker.IsBusy)
                {
                    refreshWorker.RunWorkerAsync();
                }
            }

            DataGridC.UpdateDataGrid(ref Processes, ref processCount);
            DbgCon.DebugLog("-----Refreshing process list complete-----\n", Color.Green);
            DataGridC.Sort();
            richTextBoxSearchbox_TextChanged(null, null);
            UpdateProcCountBox();
            
        }

        string LTri = "◀";
        string RTri = "▶";
        int origSize = 1072; //Placeholder
        int consoleSize = 469; //Placeholer
        bool consoleState = true;

        private void InitTAC()
        {
            origSize = this.Size.Width;
            consoleSize = dbgConsoleTxtbox.Width;
        }
        private void ToggleActivityConsole(object sender, EventArgs e)
        {
            consoleState = !consoleState;

            consoleToggleButton.Text = consoleState ? LTri : RTri;
            Size = consoleState ? new Size(origSize, Height) : new Size(origSize - consoleSize, Height);
            panel1.Size = consoleState ? new Size(origSize, panel1.Height) : new Size(origSize - consoleSize, panel1.Height);
            DragPanel.Size = consoleState ? new Size(origSize, DragPanel.Height) : new Size(origSize - consoleSize, DragPanel.Height);
            //dbgConsoleTxtbox.Size = consoleState ? new Size(consoleSize, dbgConsoleTxtbox.Height) : new Size(0, dbgConsoleTxtbox.Height);
            (consoleState ? (Action)dbgConsoleTxtbox.Show : dbgConsoleTxtbox.Hide)();


        }

        private void DataGridC_SelectionChanged(object sender, EventArgs e)
        {
            short rCount = (short)DataGridC.SelectedRows.Count;
            
            /*StackTrace stack = new StackTrace();
            Console.WriteLine("\n\n\n\n\n\n" + DateTime.UtcNow.ToString());
            Console.WriteLine(stack.ToString());
            */
            //if(rCount == 1) { DataGridC.ClearSelection(); }

            UpdateProcCountBox();

            UpdateClearButton();
            if (rCount < 1) 
            {
                buttonKill.ForeColor = Color.Silver;
                buttonKill.Enabled = false;
            }
            else if (rCount >= 1) 
            {
                buttonKill.ForeColor = Color.Red;
                buttonKill.Enabled = true; 
            }
        }

        private void UpdateProcCountBox()
        {
            totalProcBox.Text = DataGridC.SelectedRows.Count < 1
                ? DataGridC.Rows.Count.ToString() + " Procs" :
                  "(" + DataGridC.SelectedRows.Count + ") of " + DataGridC.Rows.Count.ToString() + " Procs";
            totalProcBox.SelectAll();
            totalProcBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void buttonRestartShell(object sender, EventArgs e)
        {
            this.InitShellProc(ref cmd, false); 
        }
        private void buttonKill_Click(object sender, EventArgs e)
        {
            if(DataGridC.SelectedRows.Count < 1) { return; }
            if(cmd == null || cmd.HasExited) { DbgCon.DebugLog("Failed to kill proc. No shell instance", Color.Red); return; }

            bool multi = DataGridC.SelectedRows.Count > 1;
            string msgText = multi ? "Kill Processes:\n" : "Kill Process:\n";

            foreach (DataGridViewRow row in DataGridC.SelectedRows)
            {
                if (!row.Visible) { row.Selected = false; continue; }

                msgText += $"PID: {row.Cells[1].Value} - NAME: {row.Cells[0].Value}\n";
            }

            MessageBoxButtons mbb = multi ? MessageBoxButtons.YesNoCancel : MessageBoxButtons.YesNo;
            MessageBoxManager.Yes = multi ? "Confirm ALL" : "Confirm";
            MessageBoxManager.No = multi ? "Manage" : "Cancel";
            MessageBoxManager.Cancel = "Cancel";
            MessageBoxManager.Register();

            DialogResult res = MessageBox.Show(msgText, "Confirm Command", mbb);
            bool skipConfirmation = false;

            MessageBoxManager.Unregister();

            if (multi)
            {
                if(res == DialogResult.Yes) { skipConfirmation = true; }
                if(res == DialogResult.No) {  }
                if(res == DialogResult.Cancel) { return; }
            }
            else
            {
                skipConfirmation = true;
                if(res == DialogResult.No) { return; }
            }

            foreach (DataGridViewRow row in DataGridC.SelectedRows)
            {
                bool innerConfirmation = true;
                if (!skipConfirmation) { 
                    innerConfirmation = MessageBox.Show($"Kill Process {row.Cells[1].Value} - {row.Cells[0].Value} ", "Confirm Command", MessageBoxButtons.YesNo) == DialogResult.Yes;
                }
                if (innerConfirmation)
                {
                    DbgCon.DebugLog($"Del Proc: {row.Cells[1].Value} - {row.Cells[0].Value}");
                    cmd.KillProc(row.Cells[1].Value.ToString());
                    DbgCon.DebugLogNewline();
                }
            }
        }

        private void TabPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            //This double refresh sounds like a stupid way to fix a bug
            //But it works :D
            this.Refresh();
            this.Refresh();
        }

        private void richTextBoxSearchbox_TextChanged(object sender, EventArgs e) 
        {
            if(richTextBoxSearchbox.Text == placeHolderText) { DataGridC.ClearFilter(); return; }
            DataGridC.Filter(richTextBoxSearchbox.Text);
            UpdateClearButton();
            DataGridC.ColourRows();
            if(DataGridC.SelectedRows.Count == 1) { DataGridC.ClearSelection(); }
        }

        bool bTimerCreated = false;
        Timer moveLoop = new Timer()
        {
            Interval = 1,
        };

        private void DragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!bTimerCreated) {
                moveLoop.Tick += MoveLoop_Tick;
            }
            if(e.Button == MouseButtons.Left)
            {
                DragOffset = new Point(MousePosition.X - Location.X, MousePosition.Y - Location.Y);
                moveLoop.Start();
            }
        }
        Point DragOffset;
        private void MoveLoop_Tick(object sender, EventArgs e)
        {
            bTimerCreated = true;
            this.Location = new Point(MousePosition.X - DragOffset.X, MousePosition.Y - DragOffset.Y) ;
        }

        private void DragPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moveLoop.Stop();
            }
        }

        private void DataGridC_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridC.ClearSelection();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            DataGridC.ClearSelection();
            RTBPlaceholderController.ClearAll(richTextBoxSearchbox, " Search Processes");
            DataGridC.Select();
            DataGridC.ColourRows();
        }

        private void UpdateClearButton()
        {
            short rCount = (short)DataGridC.SelectedRows.Count;
            if (rCount >= 1 || (richTextBoxSearchbox.Text != " Search Processes" && richTextBoxSearchbox.Text.Trim() != ""))
            {
                buttonClear.ForeColor = Color.BlueViolet;
                buttonClear.Enabled = true;
            }
            else if (rCount < 1)
            {
                buttonClear.ForeColor = Color.Silver;
                buttonClear.Enabled = false;
            }
            
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void UIForm_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) { 
                //this.TopMost = true; 
            }
            else { this.TopMost = false; }
        }

        private void UIForm_Deactivate(object sender, EventArgs e)
        {
            
        }
    }

}
