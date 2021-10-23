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
            DebugConsoleController D = ((UIForm)DGV.Parent.Parent.Parent).DbgCon;
            DateTime udgStartTime = DateTime.UtcNow;

            Process[] PList = Process.GetProcesses();
            foreach (Process p in PList)
            {
                if (!pInfoList.Any(x => x.ProcessID == p.Id.ToString()))
                {
                    pInfoList.Add(new ProcessInfo(
                        p, p.ProcessName, p.Id.ToString(), p.GetProcessRespondString(), Extend.PadMem8(p.PagedSystemMemorySize64), -1));

                    D.DebugLog($"New proc: {p.Id} - {p.ProcessName}");
                }
            }

            for (int i = 0; i < pInfoList.Count; i++)
            {
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

            totalProcsDisplay.Text = pInfoList.Count.ToString();
            List<DataGridViewRow> bufferRows = new List<DataGridViewRow>();
            for (int i = 0; i < pInfoList.Count; i++)
            {
                if (pInfoList[i].DisplayRowID == -1)
                {
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

                        pInfoList[i].SetDisplayRowID(++ProcCounter);
                    }
                    catch (Exception) { }
                }
                else
                {
                    foreach (DataGridViewRow d in DGV.Rows)
                    {
                        if (d.Cells[1].Value.ToString() == pInfoList[i].ProcessID)
                        {
                            d.Cells[2].Value = pInfoList[i].Root.GetProcessRespondString();
                            d.Cells[3].Value = pInfoList[i].ProcessMemory;
                        }
                    }
                }
            }

            D.DebugLog($"Row data took {(DateTime.UtcNow - udgStartTime).TotalMilliseconds}");
            DGV.SuspendLayout();
            DGV.Rows.AddRange(bufferRows.ToArray());
            DGV.ResumeLayout();
            D.DebugLog($"Row construction took {(DateTime.UtcNow - udgStartTime).TotalMilliseconds}");
        }
    }
}
