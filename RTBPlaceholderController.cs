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
        public static System.Drawing.Color defColor1;
        public static System.Drawing.Color placeColor1;
        public static void InitEvents(this RichTextBox rtb, string placeholderText)
        {
            defColor1 = rtb.ForeColor;

            rtb.Enter += (s, e) =>
            {
                if (rtb.Text == placeholderText) { rtb.Text = ""; rtb.ForeColor = defColor1; }
            };

            rtb.Leave += (s, e) =>
            {
                if (rtb.Text.Trim() == string.Empty) { rtb.Text = placeholderText; rtb.ForeColor = CONST.Colors.DefaultPlaceholderTextColor; }
            };

            rtb.Text = placeholderText; rtb.ForeColor = CONST.Colors.DefaultPlaceholderTextColor;
        }

        public static void ClearAll(this RichTextBox rtb, string placeholderText)
        {
            rtb.Text = placeholderText; rtb.ForeColor = CONST.Colors.DefaultPlaceholderTextColor;
        }
    }
}
