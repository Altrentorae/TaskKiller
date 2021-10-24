using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskKiller
{
    internal class AdvTimer : Timer
    {
        public AdvTimer() : base()
        {
            subTimer.Tick += SubTick;
        }
        public AdvTimer(int interval) : base()
        {
            Interval = interval;
            subTimer.Tick += SubTick;
        }
        public AdvTimer(int interval, int subInterval) : base()
        {
            Interval = interval;
            SubInterval = subInterval;
            subTimer.Tick += (s, e) => SubTick?.Invoke(this, new EventArgs());
        }

        public int SubInterval 
        { 
            get { return subIvl; } 
            set 
            {
                if(
                    value >= Interval 
                    || value <= 0
                   ) { throw new ArgumentOutOfRangeException("value", "value must be positive and less than this.Interval"); }
                else if (Interval % value != 0) { throw new ArgumentOutOfRangeException("value", "subInterval must be divisble by interval"); }
                else { subIvl = value; }
            } 
        }
        private int subIvl;

        private Timer subTimer = new Timer();
        public event EventHandler SubTick;

        public void StartAll()
        {
            if(subIvl != 0)
            {
                subTimer.Interval = subIvl;
                this.Start();
                subTimer.Start();
            }
            else
            {
                throw new ArgumentOutOfRangeException("value", "Unable to start SubTimer (SubInterval not set)");
            }
        }

        public void StopAll()
        {
            this.Stop();
            subTimer.Stop();
        }

    }
}
