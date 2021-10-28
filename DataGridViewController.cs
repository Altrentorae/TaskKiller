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
    public static class DataGridViewController
    {
        public static void UpdateDataGrid(this DataGridView DGV, ref List<ProcessInfo> pInfoList, ref int ProcCounter, RichTextBox totalProcsDisplay)
        {
           

            // Initialise debug stuff
            DebugConsoleController D = ((UIForm)DGV.Parent.Parent.Parent).DbgCon;
            DebugStopwatch dstop = new DebugStopwatch(D);
            DebugStopwatch totalTime = new DebugStopwatch(D);

            totalTime.Start();
            dstop.Start();

            // Processes directly from windows
            Process[] PList = Process.GetProcesses();
            foreach (Process p in PList)
            {
                // add new process to the list if not already in the list
                if (!pInfoList.Any(x => x.PID == p.Id.ToString()))
                {
                    pInfoList.Add(new ProcessInfo(
                        p, p.ProcessName, -1, null));

                    D.DebugLog($"New proc: {p.Id} - {p.ProcessName}");
                }
            }

            dstop.Elap("Proc gathering");

            // Discard any programs no longer active
            for (int i = 0; i < pInfoList.Count; i++)
            {
                //Rework all of this sometime soon
                List<ProcessInfo> tempList = new List<ProcessInfo>(pInfoList);
                if (!PList.Any(x => x.Id.ToString() == tempList[i].PID))
                {
                    if (pInfoList[i].DisplayRowID != -1)
                    {
                        try
                        {
                            foreach (DataGridViewRow d in DGV.Rows)
                            {
                                if (d.Cells[1].Value.ToString() == pInfoList[i].PID)
                                {
                                    D.DebugLog($"Proc discarded: {pInfoList[i].PID} - {pInfoList[i].Name}");
                                    DGV.Rows.Remove(d);
                                    pInfoList.Remove(pInfoList.Find(x => x.PID == tempList[i].PID));
                                }
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            D.DebugLog("Err during proc discard, continuing", System.Drawing.Color.OrangeRed);
                        }
                    }
                }
            }

            dstop.Elap("Proc discarding");

            totalProcsDisplay.Text = " " + pInfoList.Count.ToString() + " Procs";
            List<DataGridViewRow> bufferRows = new List<DataGridViewRow>();

            DebugStopwatch creationTime = new DebugStopwatch(D);
            DebugStopwatch valueUpdateTime = new DebugStopwatch(D);

            for (int i = 0; i < pInfoList.Count; i++)
            {
                //DisplayRowID is -1 if this ProcessInfo doesn't have an existing row in the DGV
                if (pInfoList[i].DisplayRowID == -1)
                {
                    creationTime.Start();
                    try
                    {
                        DataGridViewRow temp = new DataGridViewRow();
                        temp.CreateCells(DGV);
                        temp.Cells[0].Value = pInfoList[i].Name;
                        temp.Cells[1].Value = pInfoList[i].PID;
                        temp.Cells[2].Value = pInfoList[i].Status;
                        temp.Cells[3].Value = pInfoList[i].Memory;
                        temp.Cells[4].Value = pInfoList[i].Memory_Raw; //This col is hidden, used for sorting col [3]

                        bufferRows.Add(temp);
                        // Name / Id / Status / Mem //
                        //DGV.Rows.Add(Processes[i].ProcessName, Processes[i].ProcessID, Processes[i].ProcessStatus, 
                        //  Processes[i].ProcessMemory);

                        pInfoList[i].DisplayRowObj = temp;

                        pInfoList[i].SetDisplayRowID(++ProcCounter);
                    }
                    catch (Exception e)
                    {
                        if (true)
                        {
                            D.DebugLog($"Error: {pInfoList[i].Name ?? "Unkown Proc"} - {e.Message}", System.Drawing.Color.OrangeRed);
                        }
                    }
                    creationTime.Stop();
                }
                else
                {
                    valueUpdateTime.Start();

                    pInfoList[i].DisplayRowObj.Cells[2].Value = pInfoList[i].Status;
                    pInfoList[i].DisplayRowObj.Cells[3].Value = pInfoList[i].Memory;
                    pInfoList[i].DisplayRowObj.Cells[4].Value = pInfoList[i].Memory_Raw; //This col is hidden, used for sorting col [3]

                    valueUpdateTime.Stop();
                }
            }

            dstop.Elap("Row buffer");

            DateTime postBuildTime = DateTime.UtcNow;
            DGV.ColumnHeadersVisible = false;
            //DGV.SuspendLayout();
            DGV.Rows.AddRange(bufferRows.ToArray());
            //DGV.ResumeLayout();
            DGV.ColumnHeadersVisible = true;

            creationTime.ElapPrint("- Row creation");
            valueUpdateTime.ElapPrint("- Row update");

            dstop.Elap("DGV draw");
            dstop.Reset();

            totalTime.ElapStop("Total Time");
            
        }

        public static void Filter(this DataGridView DGV, string filtertext)
        {
            foreach(DataGridViewRow row in DGV.Rows)
            {
                if (filtertext.Trim() == String.Empty) { row.Visible = true; continue; }
                row.Visible = row.Cells[0].Value.ToString().ToLower().Contains(filtertext.ToLower()) || row.Cells[1].Value.ToString().ToLower().Contains(filtertext.ToLower());
            }
        }

        public static void ClearFilter(this DataGridView DGV)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                row.Visible = true;
            }
        }

        public static void InitMiscDGVSettings(this DataGridView DGV)
        {
            DGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DGV.ColumnHeaderMouseClick += DGV_HeaderClicked;
        }

        private static void DGV_HeaderClicked(object sender, EventArgs e)
        {            
            Sort((DataGridView)sender);
        }


        static bool sortDir = false;
        public static void Sort(this DataGridView dgv)
        {
            if (dgv.Rows.Count == 0 || dgv.SortedColumn == null || dgv.SortOrder == SortOrder.None) { return; }
            if(dgv.SortedColumn == dgv.Columns[3])
            {
                ListSortDirection LSD = sortDir ? ListSortDirection.Ascending : ListSortDirection.Descending;
                sortDir = !sortDir;
                dgv.Sort(dgv.Columns[4], LSD);
            }
            else
            {
                dgv.Sort(dgv.SortedColumn, dgv.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
            }
        }
    }
}
