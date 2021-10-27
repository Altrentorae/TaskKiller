using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskKiller
{
    public static class DataGridViewController
    {
        public static void UpdateDataGrid(this DataGridView DGV, ref List<ProcessInfo> pInfoList, ref int ProcCounter, Label totalProcsDisplay)
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
                if (!pInfoList.Any(x => x.ProcessID == p.Id.ToString()))
                {
                    pInfoList.Add(new ProcessInfo(
                        p, p.ProcessName, p.Id.ToString(), p.GetProcessRespondString(), Extend.PadMem8(p.PagedSystemMemorySize64), -1, null));

                    D.DebugLog($"New proc: {p.Id} - {p.ProcessName}");
                }
            }

            dstop.Elap("Proc gathering");

            // Discard any programs no longer active
            for (int i = 0; i < pInfoList.Count; i++)
            {
                //Rework all of this sometime soon
                List<ProcessInfo> tempList = new List<ProcessInfo>(pInfoList);
                if (!PList.Any(x => x.Id.ToString() == tempList[i].ProcessID))
                {
                    if (pInfoList[i].DisplayRowID != -1)
                    {
                        foreach (DataGridViewRow d in DGV.Rows)
                        {
                            if (d.Cells[1].Value.ToString() == pInfoList[i].ProcessID)
                            {
                                D.DebugLog($"Proc discarded: {pInfoList[i].ProcessID} - {pInfoList[i].ProcessName}");
                                DGV.Rows.Remove(d);
                                pInfoList.Remove(pInfoList.Find(x => x.ProcessID == tempList[i].ProcessID));
                            }
                        }
                    }
                }
            }

            dstop.Elap("Proc discarding");

            totalProcsDisplay.Text = pInfoList.Count.ToString();
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
                        temp.Cells[0].Value = pInfoList[i].ProcessName;
                        temp.Cells[1].Value = pInfoList[i].ProcessID;
                        temp.Cells[2].Value = pInfoList[i].ProcessStatus;
                        temp.Cells[3].Value = pInfoList[i].ProcessMemory;

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
                            D.DebugLog($"Error: {pInfoList[i].ProcessName ?? "Unkown Proc"} - {e.Message}", System.Drawing.Color.OrangeRed);
                        }
                    }
                    creationTime.Stop();
                }
                //If there's an associated row, find it and update it.
                //This section is the one slowing down everything
                // WHY THIS SO  S L O W  >:(
                else
                {
                    valueUpdateTime.Start();

                    pInfoList[i].DisplayRowObj.Cells[2].Value = pInfoList[i].ProcessStatus;
                    pInfoList[i].DisplayRowObj.Cells[3].Value = pInfoList[i].ProcessMemory;

                    valueUpdateTime.Stop();
                }
            }

            dstop.Elap("Row buffer");

            DateTime postBuildTime = DateTime.UtcNow;
            DGV.ColumnHeadersVisible = false;
            DGV.SuspendLayout();
            DGV.Rows.AddRange(bufferRows.ToArray());
            DGV.ResumeLayout();
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
        }
    }
}
