using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace Strobe
{

    public partial class mainForm : Form
    {
        private const string version = "1.3.2";

        private readonly Settings _settings;
        private readonly Strobe _strobe;

        public mainForm()
        {
            //AllocConsole();

            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;

            IOstrobe loading = new IOstrobe();
            _settings = new Settings(loading);
            _strobe = new Strobe();
            UpdateUI();
        }


        public bool CheckSettings()
        {
            bool allGood = true;
            string message = "All Good";

            if (hornCharBox.Text.Length != 1)
            {
                message = "Key for horn doesn't have or have too many characters";
                allGood = false;
            }

            if (allGood == false) { CreateDialog("Error Detected in settings", message); }

            return allGood;
        }

        public void Run()
        {
            SetUpDataGridView();

            if (CheckSettings())
            {
                _settings.HornKey = hornCharBox.Text[0];
            }

            while (true)
            {
                _settings.IsRandom = randomCheckBox.Checked;
                _settings.IsOnlyLFS = onlyLFSCheckBox.Checked;
                _settings.IsHorn = hornCheckBox.Checked;
                _settings.IsLights = lightCheckBox.Checked;
                _settings.IsOnStateOn = reverseLockBox.Checked;
                _settings.IsLfsActive = GetActiveProcessFileName().Equals("LFS");

                Keys activateKey = Keys.F1;
                string lockText = "";

                // Cheching which key is set up to activate _strobe
                if (numLockRadio.Checked)
                {
                    activateKey = Keys.NumLock;
                    lockText = "NumLock";
                }
                if (capsLockRadio.Checked)
                {
                    activateKey = Keys.CapsLock;
                    lockText = "CapsLock";
                }
                if (scrollLockRadio.Checked)
                {
                    activateKey = Keys.Scroll;
                    lockText = "ScrollLock";
                }
                _settings.SetLockKey(activateKey);

                bool keyStatus = IsKeyLocked(activateKey);
                if (!_settings.IsOnStateOn)
                {
                    keyStatus = !keyStatus;
                }

                if(keyStatus)
                {
                    if (_settings.IsOnlyLFS)
                    {
                        if (_settings.IsLfsActive)
                        {
                            _settings.IsActive = true;
                            outputText.Text = @"Running.";
                        }
                        else
                        {
                            _settings.IsActive = false;
                            outputText.Text = @"Stopped. Not in game";
                        }
                    }
                    else
                    {
                        _settings.IsActive = true;
                        outputText.Text = @"Running.";
                    }
                }
                else
                {
                    _settings.IsActive = false;
                    outputText.Text = $@"Stopped. Press {lockText} to activate";
                }
                _strobe.Execute(_settings);
            }
        }

        private static string GetActiveProcessFileName()
        {
            IntPtr hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);
            return p.ProcessName;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://lfs-ttl.lt");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string localPath = System.IO.Directory.GetCurrentDirectory();
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog
            {
                FileName = "settings",
                Filter = (@"Text Files (*.txt)|*.txt"),
                DefaultExt = "txt",
                AddExtension = true,
                InitialDirectory = localPath
            };

            DialogResult result = SaveFileDialog1.ShowDialog(); 
            if (result == DialogResult.OK)
            {
                string filePath = SaveFileDialog1.FileName;
                IOstrobe output = new IOstrobe();
                output.SaveData(_settings, filePath);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            string localPath = System.IO.Directory.GetCurrentDirectory();
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = (@"Text Files (*.txt)|*.txt"),
                InitialDirectory = localPath
            };

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                IOstrobe input = new IOstrobe();
                input.LoadData(_settings, filePath);
                UpdateUI();
            }
        }

        private void hornCharBox_TextChanged(object sender, EventArgs e)
        {
            if (hornCharBox.Text.Length == 1)
            {
                hornCharBox.BackColor = Color.FromArgb(255, 255, 255);
                _settings.HornKey = hornCharBox.Text[0];
            }
            else
            {
                hornCharBox.BackColor = Color.FromArgb(255, 100, 100);
            }
        }

        private void UpdateUI()
        {
            randomCheckBox.Checked = _settings.IsRandom;
            lightCheckBox.Checked = _settings.IsLights;
            hornCheckBox.Checked = _settings.IsHorn;
            onlyLFSCheckBox.Checked = _settings.IsOnlyLFS;

            hornCharBox.Text = _settings.HornKey.ToString();

            switch(_settings.LockKey)
            {
                case Keys.NumLock:
                    numLockRadio.Checked = true;
                    break;
                case Keys.CapsLock:
                    capsLockRadio.Checked = true;
                    break;
                case Keys.Scroll:
                    scrollLockRadio.Checked = true;
                    break;
                default:
                    numLockRadio.Checked = true;
                    break;
            }
        }

        private void SetUpDataGridView()
        {
            dataTable.ColumnCount = 2;
            dataTable.Columns[0].Name = "Button";
            ((DataGridViewTextBoxColumn)dataTable.Columns[0]).MaxInputLength = 1;
            dataTable.Columns[0].Width = 120;
            dataTable.Columns[1].Name = "Sleep (in ms)";
            ((DataGridViewTextBoxColumn)dataTable.Columns[1]).MaxInputLength = 4;

            char[] keys = _settings.keys;
            int[] timeOuts = _settings.sleep;

            int length = keys.Length;
            for (int index = 0; index < length; index++)
            {
                object[] row = { keys[index], timeOuts[index] };
                dataTable.Rows.Add(row);
            }

            dataTable.ScrollBars = ScrollBars.None;
        }

        private void UpdateKeys()
        {
            int length = dataTable.Rows.Count - 1;

            char[] keys = new char[length];
            int[] sleeps = new int[length];

            // Adding + 1 to skip the last row in data grid, which is empty
            for (int index = 0; index < length; index++)
            {
                try
                {
                    keys[index] = dataTable.Rows[index].Cells[0].Value.ToString()[0];

                    int sleep;
                    if (!int.TryParse(dataTable.Rows[index].Cells[1].Value.ToString(), out sleep))
                    {
                        CreateDialog("Converting Error", "Cannot convert sleep value");
                    }
                    else
                    {
                        sleeps[index] = sleep;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
            _settings.SetKeys(keys);
            _settings.SetSleep(sleeps);
        }

        private void CreateDialog(string caption, string message)
        {
            const MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.Yes) { Close() ;}
        }

        private void dataTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateKeys();
        }


        //// The lovely console
        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //private static extern bool AllocConsole();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        private void infoCaller_Click(object sender, EventArgs e)
        {
            CreateDialog("Information", $"Version {version}\nCreated for lfs-ttl.lt\nAuthor: Edgaras Čelkys aka edgatas");
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Run();
            }).Start();
        }

        private void dataTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int length = dataTable.Rows.Count - 1;
            for (int index = 0; index < length; index++)
            {
                if (dataTable.Rows[index].Cells[0].Value != null)
                {
                    dataTable.Rows[index].Cells[0].Value = dataTable.Rows[index].Cells[0].Value.ToString().ToUpper();
                }
            }
        }

        private void reverseLockBox_CheckedChanged(object sender, EventArgs e)
        {
            reverseLockBox.Text = reverseLockBox.Checked ? @"State should be 'ON' to start" : @"State should be 'OFF' to start";
        }

        private void reverseLockBox_VisibleChanged(object sender, EventArgs e)
        {
            reverseLockBox.Text = @"State should be 'ON' to start";
        }
    }
}
