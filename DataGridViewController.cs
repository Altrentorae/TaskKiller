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
        public static void UpdateDataGrid(this DataGridView DGV, ref List<ProcessInfo> pInfoList, ref int ProcCounter)
        {
            // Initialise debug stuff
            DebugConsoleController D = ((UIForm)DGV.Parent.Parent).DbgCon;
            DebugStopwatch dstop = new DebugStopwatch(D);
            DebugStopwatch colTime = new DebugStopwatch(D);
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
                    try
                    {
                        D.DebugLog($"New proc: {p.Id} - {p.ProcessName}");
                    }
                    catch { }
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
                                    D.DebugLog($"Proc discarded: {pInfoList[i].PID} - {pInfoList[i].Name}", System.Drawing.Color.Orange);
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

            
            List<DataGridViewRow> bufferRows = new List<DataGridViewRow>();

            DebugStopwatch creationTime = new DebugStopwatch(D);
            DebugStopwatch valueUpdateTime = new DebugStopwatch(D);
            DebugStopwatch VUStatus = new DebugStopwatch(D);
            DebugStopwatch VUMem = new DebugStopwatch(D);
            DebugStopwatch VURMem = new DebugStopwatch(D);

            for (int i = 0; i < pInfoList.Count; i++)
            {
                //DisplayRowID is -1 if this ProcessInfo doesn't have an existing row in the DGV
                if (pInfoList[i].DisplayRowID == -1)
                {
                    creationTime.Start();
                    //try
                    //{
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
                    //}
                    //catch (Exception e)
                    //{
                        //D.DebugLog($"Error: {pInfoList[i].Name ?? "Unkown Proc"} - {e.Message}", System.Drawing.Color.OrangeRed);  
                    //}
                    creationTime.Stop();
                }
                else
                {
                    valueUpdateTime.Start();

                    //Refreshing / updating values
                    
                    
                    VUStatus.Start();
                    pInfoList[i].DisplayRowObj.Cells[2].Value = pInfoList[i].Status;
                    VUStatus.Stop();

                    VUMem.Start();
                    pInfoList[i].DisplayRowObj.Cells[3].Value = pInfoList[i].Memory;
                    VUMem.Stop();

                    VURMem.Start();
                    pInfoList[i].DisplayRowObj.Cells[4].Value = pInfoList[i].Memory_Raw; //This col is hidden, used for sorting col [3]
                    VURMem.Stop();

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
            
            if(DGV.SelectedRows.Count < 1){ DGV.ClearSelection(); }

            creationTime.ElapPrint("- Row creation");
            valueUpdateTime.ElapPrint("- Row update");
            VUStatus.ElapPrint("--Status");
            VUMem.ElapPrint("--Mem");
            VURMem.ElapPrint("--RawMem");

            colTime.Start();
            ColourRows(DGV);
            colTime.ElapStop("- Row Col");

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
            if (DGV.SelectedRows.Count < 1) { DGV.ClearSelection(); }
            ColourRows(DGV);
        }

        public static void ColourRows(this DataGridView DGV)
        {

            List<DataGridViewRow> viewRows = new List<DataGridViewRow>();
            foreach(DataGridViewRow row in DGV.Rows)
            {
                if (row.Visible) { viewRows.Add(row); }
            }
            if(viewRows.Count == 0) { return; }
            for(int i = 0; i < viewRows.Count; i++)
            {
                DataGridViewRow row = viewRows[i];
                if(row.Cells[2].Value == null) { continue; }
                if (i % 2 == 0)
                {
                    if (row.Cells[2].Value.ToString() != "Working" && row.Cells[2].Value.ToString() != "Working (nw)")
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 200, 30, 30); 
                    }
                    else 
                    { 
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 64, 64, 64);
                        row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.BlueViolet;
                    }
                }
                else
                {
                    if (row.Cells[2].Value.ToString() != "Working" && row.Cells[2].Value.ToString() != "Working (nw)") 
                    { 
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 160, 30, 30); 
                    }
                    else 
                    { 
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 94, 94, 94);
                        row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.BlueViolet.adjustBrightness(0.9f);
                    }
                }
            }
        }

        public static void ClearFilter(this DataGridView DGV)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                row.Visible = true;
            }
            if (DGV.SelectedRows.Count < 1) { DGV.ClearSelection(); }
            ColourRows(DGV);
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
            if (dgv.SelectedRows.Count < 1) { dgv.ClearSelection(); }
            ColourRows(dgv);
        }
    }
}
