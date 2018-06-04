using System;
using System.Threading;
using System.Runtime.InteropServices;

namespace Strobe
{
    class Strobe
    {
        private int index;
        private int hornState;
        private bool IsLeftTurnOn { get; set; }
        private bool IsRightTurnOn { get; set; }
        private bool IsBothTurnOn { get; set; }

        private char noSame;
        private int noSameCount;

        private readonly Random generator;

        private void toogleLeftTurnOn() { IsLeftTurnOn ^= true; }
        private void toogleRightTurnOn() { IsRightTurnOn ^= true; }
        private void toogleBothTurnOn() { IsBothTurnOn ^= true; }


        // Initialisation
        public Strobe()
        {
            generator = new Random();
        }

        private void IndexCheck(Settings settings)
        {
            if (index >= settings.keys.Length)
            {
                index = 0;
            }
        }

        // MODIFIERS
        public void Execute(Settings settings)
        {
            if (settings.IsActive)
            {
                if (!settings.IsLfsActive) return;

                if (settings.IsRandom)
                {
                    if (settings.IsLights)
                    {
                        RandomKeyPress();
                    }
                }
                else
                {
                    if (settings.IsLights)
                    {
                        PressButton(settings.keys[index]);

                        ToogleTurningLights(settings.keys[index]);
                        PressAvailableKey();

                        settings.IsActive = true;

                        Thread.Sleep(settings.sleep[index]);

                        index++;
                        IndexCheck(settings);
                    }
                }

                if (settings.IsHorn)
                {
                    if (hornState == 0) { hornState = 1; }
                }
                else
                {
                    hornState = 0;
                }
                CheckHornStatus(settings);
            }
            else
            {
                if (hornState == 1) { hornState = 2; }
                settings.IsActive = false;
                CheckHornStatus(settings);
                Thread.Sleep(500);
            }
        }

        private void CheckHornStatus(Settings settings)
        {
            switch (hornState)
            {
                case 0:
                    break;
                case 1:
                    HoldButton(settings.HornKey);
                    PressAvailableKey();
                    break;
                case 2:
                    KeyUp(settings.HornKey);
                    TurnOffights();
                    hornState = 0;
                    break;
            }
        }

        private void ToogleTurningLights(char key)
        {
            switch (key)
            {
                case '7':
                    toogleLeftTurnOn();
                    IsBothTurnOn = false;
                    break;
                case '8':
                    toogleRightTurnOn();
                    IsBothTurnOn = false;
                    break;
                case '9':
                    IsLeftTurnOn = false;
                    IsRightTurnOn = false;
                    toogleBothTurnOn();
                    break;
                case '0':
                    IsLeftTurnOn = false;
                    IsRightTurnOn = false;
                    IsBothTurnOn = false;
                    break;
            }
        }

        private void PressAvailableKey()
        {
            if (IsLeftTurnOn)
            {
                PressButton('7');
                return;
            }

            if (IsRightTurnOn)
            {
                PressButton('8');
                return;
            }
            if (IsBothTurnOn)
            {
                PressButton('9');
                return;
            }
            PressButton('0');
        }

        private void RandomKeyPress()
        {
            int value = generator.Next(125);
            char key = '0';

            if (value < 25)
            {
                key = '3';
            }

            if (value >= 25 && value < 50)
            {
                key = '7';
                ToogleTurningLights('7');
            }

            if (value >= 50 && value < 75)
            {
                key = '8';
                ToogleTurningLights('8');
            }
            if (value >= 75 && value < 100)
            {
                key = '9';
                ToogleTurningLights('9');
            }

            if (value >= 100)
            {
                key = '0';
            }

            if (!SameKeyTooMuch(key))
            {
                PressButton(key);
                PressAvailableKey();
                Thread.Sleep(generator.Next(200, 300));
            }
            else
            {
                RandomKeyPress();
            }

}

        private bool SameKeyTooMuch(char key)
        {
            if (noSame.Equals(key))
            {
                noSameCount++;
                if (noSameCount > 3)
                {
                    noSameCount = 0;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                noSame = key;
                noSameCount = 0;
                return true;
            }
        }

        private static void TurnOffights()
        {
            PressButton('0');
            PressButton('0');
        }

        private static void PressButton(char button)
        {
            keybd_event(VkKeyScan(button), 32, 0, (UIntPtr)0);
            keybd_event(VkKeyScan(button), 32, 2, (UIntPtr)0);
            keybd_event(8, 142, 0, (UIntPtr)0);
            keybd_event(8, 142, 2, (UIntPtr)0);
        }

        private static void HoldButton(char button)
        {
            keybd_event(VkKeyScan(button), 32, 0, (UIntPtr)0);
            keybd_event(8, 142, 0, (UIntPtr)0);
            keybd_event(8, 142, 2, (UIntPtr)0);
        }

        private static void KeyUp(char button)
        {
            keybd_event(VkKeyScan(button), 32, 2, (UIntPtr)0);
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern byte VkKeyScan(char ch);
    }
}
