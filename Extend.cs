using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskKiller
{
    public static class Extend
    {
        public static void InitMiscDGVSettings(this DataGridView DGV)
        {
            DGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        public static Process[] GetAllProcesses()
        {
            return Process.GetProcesses();
        }

        public static string GetProcessRespondString(this Process p)
        {
            return p.Responding ? "Working" : "Hanging";
        }

        public static void Sort(this DataGridView dgv)
        {
            if (dgv.Rows.Count == 0 || dgv.SortedColumn == null || dgv.SortOrder == SortOrder.None) { return; }
            dgv.Sort(dgv.SortedColumn, dgv.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
        }

        public static string PadMem8(this long mem)
        {
            return mem.ToString().PadLeft(8, '0');
            //return mem > 1000000 ? ((float)(mem / 1000000f)).ToString() + "MB" : ((float)(mem / 1000f)).ToString() + "KB";
        }

        public static string[] GetArgs()
        {
            List<string> args = Environment.GetCommandLineArgs().ToList();
            args.RemoveAt(0);
            return args.ToArray();
        }
    }
}
