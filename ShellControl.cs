﻿using System;
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
                ProcessStartInfo cmdSI = new ProcessStartInfo();
                cmdSI.FileName = "cmd.exe";
                cmdSI.Verb = "runas";
                cmdSI.UseShellExecute = false;
                cmdSI.CreateNoWindow = !showWindow;
                cmdSI.WindowStyle = showWindow ? ProcessWindowStyle.Normal : ProcessWindowStyle.Minimized;
                cmdSI.RedirectStandardInput = true;
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
    }
}
