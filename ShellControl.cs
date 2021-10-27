using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskKiller
{
    public static class ShellControl
    {
        public static bool InitShellProc(this UIForm f, ref Process cmd, bool showWindow)
        {
            DebugConsoleController D = f.DbgCon;
            try
            {

                if (cmd != null)
                {
                    D.DebugLog("Restarting cmd shell process");
                    cmd.Kill();
                    cmd.Dispose();
                    cmd = null;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                cmd = null;
            }


            try
            {

                D.DebugLog("Launching cmd shell in background");

                cmd = new Process();
                ProcessStartInfo cmdSI = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    CreateNoWindow = !showWindow,
                    WindowStyle = showWindow ? ProcessWindowStyle.Normal : ProcessWindowStyle.Minimized,
                    RedirectStandardInput = true
                };
                cmd.StartInfo = cmdSI;
                cmd.Start();

                cmd.StandardInput.WriteLine(@"title TaskKillerShell");

                D.DebugLog("cmd init complete");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static void KillProc(this Process cmd, string id)
        {
            string Arguments = @"taskkill /F /PID " + id;
            try { cmd.StandardInput.WriteLine(Arguments);}
            catch (Exception) {}
        }



        public enum ShellStatus
        {
            Null = -1,
            Working = 0,
            Hang,
            Unknown
        }
        public static ShellStatus CmdExists(this Process cmd)
        {
            if(cmd == null) { return ShellStatus.Null; }
            if (cmd.Responding) { return ShellStatus.Working; }
            if (!cmd.Responding) { return ShellStatus.Hang; }
            return ShellStatus.Unknown;
        }
    }
}
