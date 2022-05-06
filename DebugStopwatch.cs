using System;
using System.Diagnostics;

namespace TaskKiller
{
    public class DebugStopwatch : System.Diagnostics.Stopwatch
    {
        public DebugStopwatch(DebugConsoleController _dbg = null)
        {
            dbg = _dbg;
        }

        public bool ForceDevCon { get; set; }
        public System.Drawing.Color? TextColor { get; set; }
        private readonly DebugConsoleController dbg;

        public void ElapStopDevEnv(string msg)
        {
            if (!this.IsRunning) { return; }
            Console.WriteLine(msg + " " + this.Elapsed.TotalMilliseconds.ToString());
            this.Stop();
        }

        [Conditional("DEBUG")]
        private void PushDebugString(string s)
        {
            string msg = "[DSTOP] (" + s + "): ";
            if (dbg != null || !ForceDevCon)
            {
                dbg.DebugLog(msg, TextColor ?? CONST.Colors.DefaultDSTOPColor);
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
