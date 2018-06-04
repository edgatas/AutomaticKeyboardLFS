using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Strobe
{
    class Settings
    {
        public char HornKey { get; set; }
        public Keys LockKey { get; set; }

        public bool IsActive { get; set; }
        public bool IsRandom { get; set; }
        public bool IsOnlyLFS { get; set; }
        public bool IsHorn { get; set; }
        public bool IsLights { get; set; }
        public bool IsLfsActive { get; set; }
        public bool IsOnStateOn { get; set; }

        public char[] keys { get; set; }
        public int[] sleep { get; set; }

        public void SetLockKey(Keys key) { LockKey = key; }
        public void SetLockKey(string key) { SetLockKey((Keys)Enum.Parse(typeof(Keys), key)); }

        public Settings(IOstrobe io)
        {
            io.LoadData(this, "settings.txt");
            if (!io.IsGood)
            {
                IsOnlyLFS = true;
                IsHorn = true;
                IsLights = true;
                IsOnStateOn = true;

                HornKey = 'B';

                const int t = 200;
                keys = new[] { '3', '8', '3', '0', '3', '7', '3', '0' };
                sleep = new[] { t, t, t, t, t, t, t, t };
            }
            else
            {
                io.LoadData(this, "settings.txt");
            }
        }
        public void SetKeys(char[] newKeys)
        {
            keys = new char[newKeys.Length];
            keys = newKeys;
        }


        public void SetSleep(int[] newSleeps)
        {
            sleep = new int[newSleeps.Length];
            sleep = newSleeps;
        }
    }
}
