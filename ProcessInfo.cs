using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskKiller
{
    public class ProcessInfo
    {
        public ProcessInfo(Process _r, string name, string id, string status, string mem, int GridID, DataGridViewRow dgvr)
        {
            Root = _r; ProcessName = name; ProcessID = id; ProcessStatus = status; ProcessMemory = mem; DisplayRowID = GridID; DisplayRowObj = dgvr;
        }

        public void SetDisplayRowID(int newVal)
        {
            DisplayRowID = newVal;
        }

        public Process Root;
        public string ProcessName;
        public string ProcessID;
        public string ProcessStatus;
        public string ProcessMemory;
        public int DisplayRowID;
        public DataGridViewRow DisplayRowObj;
    }
}
