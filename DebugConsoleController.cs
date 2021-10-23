using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskKiller
{
    public class DebugConsoleController
    {
        public DebugConsoleController(RichTextBox textBox)
        {
            r = textBox;
        }
        private RichTextBox r;
        public void DebugLog(string s)
        {
            //TabControlMain.TabPages[1].Controls[0].Text += $"{DateTime.UtcNow}: {s}\n";
            r.Text += $"{DateTime.UtcNow}: {s}\n";
        }

        public void DebugLogNewline()
        {
            r.Text += "\n";
        }

        public void DebugLogInitAutoScroll()
        {
            Control rtb = r;
            rtb.TextChanged += (s, e) =>
            {
                RichTextBox R = (RichTextBox)rtb;
                R.SelectionStart = R.Text.Length;
                R.ScrollToCaret();
            };
        }
    }
}
