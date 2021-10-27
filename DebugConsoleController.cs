using System;
using System.Collections.Generic;
using System.Drawing;
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
        public void DebugLog(string s, Color? c = null)
        {
            //TabControlMain.TabPages[1].Controls[0].Text += $"{DateTime.UtcNow}: {s}\n";

            Color innerC = c ?? r.ForeColor;
            r.AppendText($"{DateTime.UtcNow}: {s}\n", innerC);
        }

        public void DebugLogNewline()
        {
            r.AppendText("\n");
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

    public static class DCCExt
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
