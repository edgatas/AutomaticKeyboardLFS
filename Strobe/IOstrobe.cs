using System;
using System.Windows.Forms;

using System.IO;
using System.Xml;

namespace Strobe
{
    class IOstrobe
    {
        public bool IsGood { get; private set; }

        public IOstrobe()
        {
            IsGood = true;
        }

        public void SaveData(Settings settings, string filePath)
        {
            StreamWriter file = new StreamWriter(filePath);
            bool random = settings.IsRandom;
            bool horn = settings.IsHorn;
            bool lights = settings.IsLights;
            bool onlyLFS = settings.IsOnlyLFS;
            bool onStateOn = settings.IsOnStateOn;
            char hornKey = settings.HornKey;
            Keys lockKey = settings.LockKey;
            char[] keys = settings.keys;
            int[] timeOuts = settings.sleep;

            int lenght = keys.Length;
            file.WriteLine(lenght);

            for (int index = 0; index < lenght; index++)
            {
                file.WriteLine(keys[index]);
                file.WriteLine(timeOuts[index]);
            }
            file.WriteLine(random);
            file.WriteLine(horn);
            file.WriteLine(lights);
            file.WriteLine(onlyLFS);
            file.WriteLine(onStateOn);
            file.WriteLine(hornKey);
            file.WriteLine(lockKey);
            file.Close();
            file.Dispose();
        }

        private static char Read(StreamReader file)
        {
            string line = file.ReadLine();
            if (line == null) { return char.MinValue; }
            return line[0];
        }

        public void LoadData(Settings settings, string filePath)
        {
            try
            {
                StreamReader file = new StreamReader(filePath);
                int lenght = Convert.ToInt32(file.ReadLine());
                char[] keys = new char[lenght];
                int[] timeOut = new int[lenght];

                for (int index = 0; index < lenght; index++)
                {
                    keys[index] = Read(file);
                    int.TryParse(file.ReadLine(), out timeOut[index]);
                }

                bool random = Read(file).Equals('T');
                bool horn = Read(file).Equals('T');
                bool lights = Read(file).Equals('T');
                bool onlyLFS = Read(file).Equals('T');
                bool onStateOn = Read(file).Equals('T');
                char hornkey = Read(file);
                string lockKey = file.ReadLine();

                settings.keys = keys;
                settings.sleep = timeOut;

                settings.IsRandom = random;
                settings.IsHorn = horn;
                settings.IsLights = lights;
                settings.IsOnlyLFS = onlyLFS;
                settings.IsOnStateOn = onStateOn;
                settings.HornKey = hornkey;
                settings.SetLockKey(lockKey);

                file.Close();
                file.Dispose();
                IsGood = true;
            }
            catch (FileNotFoundException)
            {
                string caption = @"File error";
                string message = $@"File settings.txt not found, using default settings
                                {Environment.NewLine}File settings.txt should be located in the same folder as Strobe launcher";
                const MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                IsGood = false;
            }
            catch (Exception)
            {
                string caption = @"File error";
                string message = @"Bad file format. Using default settings";
                const MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                IsGood = false;
            }

        }
    }
}
