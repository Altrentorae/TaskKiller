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
        public UIForm()
        {
            string[] args = Extend.GetArgs();

            InitializeComponent();
            DataGridC.InitMiscDGVSettings();
            RichTextBox DgbTextBox = (RichTextBox)TabControlMain.TabPages[1].Controls[0];
            DbgCon = new DebugConsoleController(DgbTextBox);
            notifBox = new NotificationTextboxController(notificationRtb, DbgCon);
            DbgCon.DebugLogInitAutoScroll();
            DbgCon.DebugLog("UI form init complete");
            this.InitShellProc(ref cmd, false);

            

            t = new AdvTimer(5000, 1000);
            t.Tick += (s, e) => T_Tick(s, e);
            t.SubTick += (s, e) => T_SubTick(s, e);

            refreshCountdownInit = (t.Interval/1000);
            refreshCountdown = (t.Interval/1000);

            t.StartAll();

            buttonRefresh_Click(null, null);
        }

        int refreshCountdownInit;
        int refreshCountdown;
        private void T_Tick(object sender, EventArgs e)
        {
            buttonRefresh_Click(null, null);
            refreshCountdown = refreshCountdownInit;

            while (true)
            {
                ShellControl.ShellStatus status = ShellControl.CmdExists(cmd);
                if(status == ShellControl.ShellStatus.Working) { break; }
                if (status == ShellControl.ShellStatus.Null){ DbgCon.DebugLog("Shell instance not found", Color.Red); }
                if(status == ShellControl.ShellStatus.Hang) { DbgCon.DebugLog("Shell instance not responding", Color.Red); }
                this.InitShellProc(ref cmd, false);
            }

        }
        private void T_SubTick(object sender, EventArgs e)
        {
            refreshCountdown--;
            notifBox.PushNew("Refresh in: " + refreshCountdown, Color.White, false);
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DbgCon.DebugLog("-----Refreshing process list-----");
            DataGridC.UpdateDataGrid(ref Processes, ref processCount, labelTotalProc);
            DbgCon.DebugLog("-----Refreshing process list complete-----\n", Color.Green);
            DataGridC.Sort();
        }
        private void buttonRestartShell(object sender, EventArgs e)
        {
            this.InitShellProc(ref cmd, false); 
        }
        private void buttonKill_Click(object sender, EventArgs e)
        {
            if(DataGridC.SelectedRows.Count < 1) { return; }
            if(cmd == null) { DbgCon.DebugLog("Failed to kill proc. No shell instance", Color.Red); return; }
            foreach (DataGridViewRow row in DataGridC.SelectedRows)
            {
                if(MessageBox.Show($"Kill Process {row.Cells[1].Value} - {row.Cells[0].Value} ", "Confirm Command", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        private void richTextBoxSearchbox_TextChanged(object sender, EventArgs e) { DataGridC.Filter(richTextBoxSearchbox.Text); }
    }

}
