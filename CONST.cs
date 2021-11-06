using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TaskKiller
{
    internal static class CONST
    {
        public static class Colors
        {
            // Colors aren't primitive and cant be const
            public static readonly Color DefaultSuccessColor = Color.Green;
            public static readonly Color DefaultErrColor = Color.Red;
            public static readonly Color DefaultWarnColor = Color.OrangeRed;
            public static readonly Color DefaultDSTOPColor = Color.Blue;
            public static readonly Color DefaultNOTIFColor = Color.DarkTurquoise;
            public static readonly Color DefaultPlaceholderTextColor = Color.Gray;
        }

        public static class Text
        {
            public const string searchPlaceholder = " Search Processes";
        }

        public static class Flags
        {
            public const string skipAuth = "--skipAuthCheck";
        }
    }
}
