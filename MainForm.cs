using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace RecoilTime
{
    public partial class MainForm : Form
    {
        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // Colors
        private readonly Color colorBg = Color.FromArgb(13, 13, 13);
        private readonly Color colorCard = Color.FromArgb(26, 26, 26);
        private readonly Color colorAccent = Color.FromArgb(139, 92, 246);
        private readonly Color colorBtnDefault = Color.FromArgb(45, 45, 45);
        private readonly Color colorBtnSecondary = Color.FromArgb(59, 130, 246);
        private readonly Color colorBtnConfirm = Color.FromArgb(229, 57, 53);
        private readonly Color colorText = Color.White;
        private readonly Color colorTextSecondary = Color.FromArgb(180, 180, 180);
        private readonly Color colorBorder = Color.FromArgb(45, 45, 45);
        private readonly Color colorRed = Color.FromArgb(130, 26, 39);

        public MainForm()
        {
            InitializeComponent();
            TopMost = true;
            LoadConfigurations();
            ShowRecoilTab();
        }

        // ===== TAB SWITCHING =====
        private void ShowRecoilTab()
        {
            panelRecoil.Visible = true;
            panelRecoil.BringToFront();
            panelSettings.Visible = false;
            btnTabRecoil.BackColor = colorAccent;
            btnTabRecoil.ForeColor = colorText;
            btnTabSettings.BackColor = colorCard;
            btnTabSettings.ForeColor = colorTextSecondary;
        }

        private void ShowSettingsTab()
        {
            panelRecoil.Visible = false;
            panelSettings.Visible = true;
            panelSettings.BringToFront();
            btnTabSettings.BackColor = colorAccent;
            btnTabSettings.ForeColor = colorText;
            btnTabRecoil.BackColor = colorCard;
            btnTabRecoil.ForeColor = colorTextSecondary;
        }

        private void btnTabRecoil_Click(object sender, EventArgs e)
        {
            ShowRecoilTab();
        }

        private void btnTabSettings_Click(object sender, EventArgs e)
        {
            ShowSettingsTab();
        }

        // ===== FORM EVENTS =====
        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            t = new Thread(new ThreadStart(Recoil.Loop));
            t.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // ===== DRAG =====
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = Location;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        // ===== RECOIL TOGGLE =====
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (guna2Button1.Text.Contains("enable"))
            {
                guna2Button1.ForeColor = Color.FromArgb(80, 80, 80);
                guna2Button1.BackColor = Color.Salmon;
                guna2Button1.Text = "disable";
                return;
            }
            if (guna2Button1.Text.Contains("disable"))
            {
                guna2Button1.ForeColor = Color.Salmon;
                guna2Button1.BackColor = Color.FromArgb(80, 80, 80);
                guna2Button1.Text = "enable";
            }
        }

        private void guna2Button1_TextChanged(object sender, EventArgs e)
        {
            Recoil.Enabled = guna2Button1.Text.Contains("disable");
        }

        // ===== BIND BUTTON =====
        private void bindbutton_Click(object sender, EventArgs e)
        {
            bindbutton.Text = "...";
        }

        private void binding3_Tick(object sender, EventArgs e)
        {
            if (bindbutton.Text != "bind" && bindbutton.Text != "...")
            {
                Keys vKey = (Keys)Key.ConvertFromString(bindbutton.Text.Replace("...", ""));
                if (GetAsyncKeyState(vKey) < 0)
                {
                    if (guna2Button1.Text.Contains("disable"))
                        guna2Button1.Text = "enable";
                    else if (guna2Button1.Text.Contains("enable"))
                        guna2Button1.Text = "disable";
                    while (GetAsyncKeyState(vKey) < 0)
                        Thread.Sleep(20);
                }
            }
        }

        private void bindbutton_KeyDown(object sender, KeyEventArgs e)
        {
            string text = e.KeyData.ToString();
            if (!text.Contains("Alt"))
            {
                if (GetAsyncKeyState(Keys.Escape) < 0)
                    bindbutton.Text = "bind";
                else
                    bindbutton.Text = text;
            }
        }

        private void bindbutton_TextChanged(object sender, EventArgs e)
        {
            if (bindbutton.Text == "bind" || bindbutton.Text == "...")
            {
                bindbutton.BackColor = colorBtnDefault;
                return;
            }
            bindbutton.BackColor = colorRed;
        }

        // ===== TIMER =====
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Recoil.Enabled)
            {
                label6.Text = "Enabled";
                label6.ForeColor = Color.Green;
                EnableRecoil();
                return;
            }
            label6.Text = "Disabled";
            label6.ForeColor = Color.Red;
            DisableRecoil();
        }

        private void EnableRecoil()
        {
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            Recoil.sleeptime = (int)numericUpDown2.Value;
            Recoil.strength = (int)numericUpDown1.Value;
        }

        private void DisableRecoil()
        {
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }

        // ===== TOOLTIP =====
        private void label9_MouseEnter(object sender, EventArgs e)
        {
            panel7.Location = new Point(lblTooltip.Location.X + panelRecoil.Location.X + 10, lblTooltip.Location.Y + lblTooltip.Height + panelRecoil.Location.Y + 40);
            panel7.Visible = true;
            panel7.BringToFront();
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            panel7.Visible = false;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel7.ClientRectangle, colorRed, 1, ButtonBorderStyle.Solid, colorRed, 1, ButtonBorderStyle.Solid, colorRed, 1, ButtonBorderStyle.Solid, colorRed, 1, ButtonBorderStyle.Solid);
        }

        // ===== SAVE CURRENT CONFIG (Recoil Tab) =====
        private void btnSaveCurrent_Click(object sender, EventArgs e)
        {
            string name = txtQuickSave.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Enter a config name first.", "Error", MessageBoxButtons.OK);
                return;
            }
            string val = numericUpDown1.Value.ToString();
            string entry = name + ":" + val;
            if (comboBoxConfigs.Items.Contains(name))
            {
                MessageBox.Show("Name already exists.", "Error", MessageBoxButtons.OK);
                return;
            }
            comboBoxConfigs.Items.Add(name);
            File.AppendAllText("userLMcnf.txt", entry + Environment.NewLine);
            txtQuickSave.Text = "";
            MessageBox.Show("Config saved!", "Success", MessageBoxButtons.OK);
        }

        // ===== SETTINGS TAB: CONFIG MANAGEMENT =====
        private void guna2Button21_Click(object sender, EventArgs e)
        {
            if (comboBoxConfigs.SelectedItem == null)
            {
                MessageBox.Show("Please select a config.", "Error", MessageBoxButtons.OK);
                return;
            }
            string name = comboBoxConfigs.SelectedItem.ToString();
            foreach (string line in File.ReadAllLines("userLMcnf.txt"))
            {
                if (line.StartsWith(name + ":"))
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2 && decimal.TryParse(parts[1].Trim(), out decimal value))
                    {
                        numericUpDown1.Value = value;
                        MessageBox.Show("Config loaded!", "Success", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            if (comboBoxConfigs.SelectedItem == null)
            {
                MessageBox.Show("Please select a config to delete.", "Error", MessageBoxButtons.OK);
                return;
            }
            string name = comboBoxConfigs.SelectedItem.ToString();
            comboBoxConfigs.Items.Remove(name);
            UpdateConfigFile();
            MessageBox.Show("Config deleted!", "Success", MessageBoxButtons.OK);
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            string search = guna2TextBox2.Text.ToLower();
            comboBoxConfigs.Items.Clear();
            if (!File.Exists("userLMcnf.txt")) return;
            foreach (string name in from line in File.ReadAllLines("userLMcnf.txt")
                                     let n = line.Split(':')[0]
                                     where n.ToLower().Contains(search)
                                     select n)
            {
                comboBoxConfigs.Items.Add(name);
            }
        }

        private void comboBoxConfigs_SelectedIndexChanged(object sender, EventArgs e) { }

        // ===== PROGRAM SETTINGS =====
        private void checkBoxHideTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            ShowInTaskbar = !checkBoxHideTaskbar.Checked;
        }

        // ===== HELPERS =====
        private void LoadConfigurations()
        {
            if (!File.Exists("userLMcnf.txt")) return;
            comboBoxConfigs.Items.Clear();
            foreach (string line in File.ReadAllLines("userLMcnf.txt"))
            {
                string[] parts = line.Split(':');
                if (parts.Length > 0 && !string.IsNullOrWhiteSpace(parts[0]))
                    comboBoxConfigs.Items.Add(parts[0]);
            }
        }

        private void UpdateConfigFile()
        {
            List<string> list = new List<string>();
            foreach (object obj in comboBoxConfigs.Items)
            {
                string name = obj.ToString();
                foreach (string line in File.ReadAllLines("userLMcnf.txt"))
                {
                    if (line.StartsWith(name + ":"))
                        list.Add(line);
                }
            }
            File.WriteAllLines("userLMcnf.txt", list);
        }

        private Thread t;
        private KeysConverter Key = new KeysConverter();
    }
}
