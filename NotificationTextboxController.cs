using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskKiller
{
    public class NotificationTextboxController
    {
        public NotificationTextboxController(RichTextBox _rtb, DebugConsoleController _dbg)
        {
            rtb = _rtb;
            debugConsole = _dbg;
        }

        private RichTextBox rtb;
        private DebugConsoleController debugConsole;

        public void PushNew(string s, Color c, bool pushToDebug = true)
        {
            rtb.ForeColor = c;
            rtb.Text = s;
            if (pushToDebug) { debugConsole.DebugLog(s); }
        }

        public void Clear() { rtb.Text = ""; }
    }
}
