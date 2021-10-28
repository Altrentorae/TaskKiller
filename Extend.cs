using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskKiller
{
    public static class Extend
    {
        public static Process[] GetAllProcesses()
        {
            return Process.GetProcesses();
        }

        public static string GetProcessRespondString(this Process p)
        {
            return p.Responding ? "Working" : "Hanging";
        }

        public static string PadMem(this object mem, short padLen)
        {
            return mem.ToString().PadLeft(padLen, '0');
        }

        public enum SizeUnits
        {
            Byte, KB, MB, GB, TB, PB, EB, ZB, YB, AUTO
        }

        public static SizeUnits GetUnit(string val)
        {
            foreach(SizeUnits units in Enum.GetValues(typeof(SizeUnits)))
            {
                if (val.Contains(units.ToString())) { return units; }
            }
            return 0;
        }

        public static string ToSize(this Int64 value, SizeUnits unit)
        {
            if(unit == SizeUnits.AUTO)
            {
                System.Collections.IList list = Enum.GetValues(typeof(SizeUnits));
                for (int i = list.Count-2; i > 0; i--)
                {
                    SizeUnits IUnit = (SizeUnits)list[i];
                    float result = float.Parse(ToSize(value, IUnit));
                    if(result >= 1) { return result.ToString("0.00") + " " + IUnit.ToString(); }
                }
                return value.ToString() + "TS_Err";
            }
            return (value / (double)Math.Pow(1024, (Int64)unit)).ToString("0.00");
        }

        public static float RemoveSizeUnit(string str)
        {
            for(int i = 65; i < 90; i++)
            {
                str = str.Replace(((char)i).ToString(), "");
            }
            for(int i = 97; i < 122; i++)
            {
                str = str.Replace(((char)i).ToString(), "");
            }
            return float.Parse(str);
        }

        public static string[] GetArgs()
        {
            List<string> args = Environment.GetCommandLineArgs().ToList();
            args.RemoveAt(0);
            return args.ToArray();
        }
    }
}
