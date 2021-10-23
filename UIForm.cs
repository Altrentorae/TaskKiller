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

        int processCount = 0;
        List<ProcessInfo> Processes = new List<ProcessInfo>();
        Process cmd;
        public UIForm()
        {
            string[] args = Extend.GetArgs();

            InitializeComponent();
            DataGridC.InitMiscDGVSettings();
            RichTextBox DgbTextBox = (RichTextBox)TabControlMain.TabPages[1].Controls[0];
            DbgCon = new DebugConsoleController(DgbTextBox);
            DbgCon.DebugLogInitAutoScroll();
            DbgCon.DebugLog("UI form init complete");
            this.InitShellProc(ref cmd, false);
        }
        private void T_Tick(object sender, EventArgs e)
        {
            //Live updating isnt going to work unless I can fix the horribly slow draw time on DataGridView controls
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DbgCon.DebugLog("-----Refreshing process list-----");
            DataGridC.UpdateDataGrid(ref Processes, ref processCount, labelTotalProc);
            DbgCon.DebugLog("-----Refreshing process list complete-----\n");
            DataGridC.Sort();
        }
        private void buttonRestartShell(object sender, EventArgs e)
        {
            this.InitShellProc(ref cmd, false); 
        }
        private void buttonKill_Click(object sender, EventArgs e)
        {
            if(DataGridC.SelectedRows.Count < 1) { return; }
            if(cmd == null) { DbgCon.DebugLog("Failed to kill proc. No shell instance"); return; }
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
    }

}
