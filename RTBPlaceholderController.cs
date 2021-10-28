using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskKiller
{
    public static class RTBPlaceholderController
    {
        public static void InitEvents(this RichTextBox rtb, string placeholderText)
        {
            rtb.Enter += (s, e) =>
            {
                if (rtb.Text == placeholderText) { rtb.Text = ""; rtb.ForeColor = System.Drawing.Color.Black; }
            };

            rtb.Leave += (s, e) =>
            {
                if (rtb.Text.Trim() == string.Empty) { rtb.Text = placeholderText; rtb.ForeColor = System.Drawing.Color.Gray; }
            };

            rtb.Text = placeholderText; rtb.ForeColor = System.Drawing.Color.Gray;
        }
    }
}
