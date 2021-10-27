using System;
using System.Diagnostics;

namespace TaskKiller
{
    public class DebugStopwatch : System.Diagnostics.Stopwatch
    {
        public DebugStopwatch(DebugConsoleController _dbg)
        {
            dbg = _dbg;
        }

        public bool ForceDevCon { get; set; }
        public System.Drawing.Color? textColor { get; set; }
        private DebugConsoleController dbg;

        [Conditional("DEBUG")]
        private void PushDebugString(string s)
        {
            string msg = "[DSTOP] (" + s + "): ";
            if (dbg != null || !ForceDevCon)
            {
                dbg.DebugLog(msg, textColor ?? System.Drawing.Color.Blue);
            }
            else
            {
                Console.WriteLine(msg);
            }
        }

        [Conditional("DEBUG")]
        public void Elap(string msg = "")
        {
            if (!this.IsRunning) { return; }
            PushDebugString(msg + " " + this.Elapsed.TotalMilliseconds.ToString());
            this.Restart();
        }

        [Conditional("DEBUG")]
        public void ElapStop(string msg = "")
        {
            if (!this.IsRunning) { return; }
            PushDebugString(msg + " " + this.Elapsed.TotalMilliseconds.ToString());
            this.Stop();
        }

        [Conditional("DEBUG")]
        public void ElapPrint(string msg = "")
        {
            PushDebugString(msg + " " + this.Elapsed.TotalMilliseconds.ToString());
        }
    }
}
