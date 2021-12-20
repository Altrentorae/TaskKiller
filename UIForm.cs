﻿using System;
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


            InitializeComponent();

            {
                buttonRefresh.Visible = false;
                buttonRelaunchCmd.Visible = false;
            }

            DataGridC.InitMiscDGVSettings();
            RichTextBox DgbTextBox = (RichTextBox)TabControlMain.TabPages[1].Controls[0];
            DbgCon = new DebugConsoleController(DgbTextBox);
            notifBox = new NotificationTextboxController(notificationRtb, DbgCon);
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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DbgCon.DebugLog("-----Refreshing process list-----");
            DataGridC.UpdateDataGrid(ref Processes, ref processCount, totalProcBox);
            DbgCon.DebugLog("-----Refreshing process list complete-----\n", Color.Green);
            DataGridC.Sort();
            richTextBoxSearchbox_TextChanged(null, null);
        }
        private void buttonRestartShell(object sender, EventArgs e)
        {
            this.InitShellProc(ref cmd, false); 
        }
        private void buttonKill_Click(object sender, EventArgs e)
        {
            if(DataGridC.SelectedRows.Count < 1) { return; }
            if(cmd == null) { DbgCon.DebugLog("Failed to kill proc. No shell instance", Color.Red); return; }

            bool multi = DataGridC.SelectedRows.Count > 1;
            string msgText = multi ? "Kill Processes:\n" : "Kill Process:\n";

            foreach (DataGridViewRow row in DataGridC.SelectedRows)
            {
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
        }
    }

}
