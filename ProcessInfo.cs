// ********************************************* //
// Rudimentary testing has determined that using performance counters for live updates of 
// CPU and Memory usage is simply not going to work.
// TL;DR of the situation is each process takes approximately 15ms (at best)
// A resting PC will often have around 271 processes. Grabbing 2 counter values from each of them
// results in (15ms * 2 * 271) = 8.13 seconds.
// This number needs to be consistently under the refresh time (5 seconds)
// if not it causes stacking calls to the same function, resulting in a hang as well as 
// effectively causing a perma-lock on the UI thread, causing functionality to cease.
// UPDATE: 14/10/22
// The above problem seems to be solvable with cleverly implemented background workers
// though the same limitation could apply if the background worker cannot complete the
// task within the refresh period. Also have to take extra caution to avoid race conditions
// ************************************************ //

//SnapShot version has no method to update values after init, can be used for static processes or caching

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
        public ProcessInfo(Process _r, int GridID, DataGridViewRow dgvr)
        {
            Root = _r;
            try
            {
                string n = _r.MainModule.FileVersionInfo.FileDescription;
                if (n == null) { Name = _r.ProcessName; }
                else if (n.Trim() == "") { Name = _r.ProcessName; }
                else { Name = n; }
            }
            catch { Name = _r.ProcessName; }
            PID = _r.Id.ToString();
            DisplayRowID = GridID; DisplayRowObj = dgvr;
            RefreshProc();
        }

        public void SetDisplayRowID(int newVal)
        {
            DisplayRowID = newVal;
        }

        public void RefreshProc()
        {
            Root.Refresh();
            Status = GetStatus();
            Memory = GetMemory();
            Memory_Raw = GetMemory_Raw();
            ThreadStatus = GetThreadState();            
            return;
        }

        public string GetStatus()
        {
            //return "Working";
            try { if (Root.MainWindowTitle == "") { return "Working (nw)"; } }
            catch (InvalidOperationException) { return "Discarding"; }
            return Root.GetProcessRespondString();
        }

        public string GetThreadState()
        {
            try {
                if (Root.Threads[0].ThreadState == ThreadState.Wait)
                {
                    if(Root.Threads[0].WaitReason == ThreadWaitReason.UserRequest) { return "Wait"; }
                    return Root.Threads[0].WaitReason.ToString();
                }
                return Root.Threads[0].ThreadState.ToString(); 
            }
            catch { return ThreadState.Unknown.ToString(); }
        }

        public bool GetThreadStateGood()
        {
            switch(Root.Threads[0].ThreadState)
            {
                case ThreadState.Initialized:
                case ThreadState.Ready:
                case ThreadState.Running:
                case ThreadState.Standby:
                case ThreadState.Transition:
                case ThreadState.Wait:
                    return true;
                default: 
                    return false;
            }
        }

        public string GetMemory()
        {
            try { return Extend.ToSize(Root.WorkingSet64, Extend.SizeUnits.AUTO) + "" ?? "Mem Err"; }
            catch (InvalidOperationException) { return "00 GC"; }
        }

        public string GetMemory_Raw()
        {
            try { return Extend.PadMem(Root.WorkingSet64, 16); }
            catch (InvalidOperationException) { return "0000000000000000"; }
        }

        public Process Root;
        public string Name;
        public string PID;
        public string Status { get; private set; }
        public string Memory { get; private set; }
        public string Memory_Raw { get; private set; }
        public string ThreadStatus { get; private set; }

        public int DisplayRowID;
        public DataGridViewRow DisplayRowObj; 
    }
}
