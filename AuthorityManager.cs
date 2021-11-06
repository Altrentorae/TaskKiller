using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskKiller
{
    internal static class AuthorityManager
    {
        public static bool IsAdmin()
        {
            #if !DEBUGNOADMIN
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            #else
                return true;
            #endif
        }

        public static void RelaunchAsAdmin(string[] args)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = Application.ExecutablePath;
            proc.Verb = "runas";
            proc.Arguments = string.Join(" ", args);
               
            try
            {
                Process.Start(proc);
            }
            catch
            {
                return;
            }
            Application.Exit();
        }
    }
}
