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
            timer.Tick += Timer_Tick;
        }

        private readonly RichTextBox rtb;
        private readonly DebugConsoleController debugConsole;
        private readonly Timer timer = new Timer();

        public void PushNew(string s, Color c, bool pushToDebug = true)
        {
            rtb.ForeColor = c;
            rtb.Text = s;
            if (pushToDebug) { debugConsole.DebugLog("[NOTIF]: " + s, CONST.Colors.DefaultNOTIFColor); }
        }

        // To avoid potential overlapping timers this should always be called from a singular object
        // Any references should point to notifBox on UIForm
        public void PushNewTimed(string s, Color c, float time, bool pushToDebug = true)
        {
            timer.Interval = Convert.ToInt32(time*1000);
            PushNew(s, c, pushToDebug);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Clear();
            timer.Stop();
        }

        public void Clear() { rtb.Text = ""; }
    }
}
