using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RecoilController
{
    public partial class MainForm : Form
    {
        private RecoilEngine _engine = new RecoilEngine();
        private Thread _engineThread;
        private ConfigManager.SettingsData _settings;
        private List<GunConfig> _gunConfigs = new List<GunConfig>();
        private string _configFolder = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "configs"
        );

        public MainForm()
        {
            InitializeComponent();
            this.TopMost = true;
            this.KeyPreview = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.KeyDown += MainForm_KeyDown;

            _settings = ConfigManager.Load();
            ApplySettingsToUI();
            UpdateStatus();

            LoadGunConfigs();

            _engineThread = new Thread(_engine.Loop);
            _engineThread.IsBackground = true;
            _engineThread.Start();

            this.Show();
            this.Activate();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                _engine.IsActive = !_engine.IsActive;
                UpdateStatus();
                e.Handled = true;
            }
        }

        private void LoadGunConfigs()
        {
            try
            {
                if (!Directory.Exists(_configFolder))
                    Directory.CreateDirectory(_configFolder);

                var files = Directory.GetFiles(_configFolder, "*.json");
                _gunConfigs.Clear();
                foreach (var file in files)
                {
                    try
                    {
                        string json = File.ReadAllText(file);
                        var config = JsonConvert.DeserializeObject<GunConfig>(json);
                        if (config != null)
                            _gunConfigs.Add(config);
                    }
                    catch { }
                }
                UpdateGunList();
            }
            catch { }
        }

        private void UpdateGunList(string filter = "")
        {
            listGuns.Items.Clear();
            var filtered = _gunConfigs;
            if (!string.IsNullOrEmpty(filter))
            {
                filtered = _gunConfigs.Where(g => g.Name.ToLower().Contains(filter.ToLower())).ToList();
            }
            foreach (var config in filtered.OrderBy(g => g.Name))
            {
                listGuns.Items.Add(config.Name);
            }
        }

        private void TxtSearchGun_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearchGun.Text;
            if (filter == "🔍 Search...") filter = "";
            UpdateGunList(filter);
        }

        private void ListGuns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listGuns.SelectedItem == null) return;
            string name = listGuns.SelectedItem.ToString();
            var config = _gunConfigs.FirstOrDefault(g => g.Name == name);
            if (config != null)
            {
                trackVertical.Value = config.Vertical;
                trackHorizontal.Value = config.Horizontal + 15;
                trackHDelay.Value = config.HorizontalDelay;
                trackHDuration.Value = config.HorizontalDuration;

                _engine.Vertical = config.Vertical;
                _engine.Horizontal = config.Horizontal;
                _engine.HorizontalDelay = config.HorizontalDelay;
                _engine.HorizontalDuration = config.HorizontalDuration;

                UpdateLabels();
            }
        }

        private void BtnSaveGun_Click(object sender, EventArgs e)
        {
            string name = txtSearchGun.Text;
            if (string.IsNullOrEmpty(name) || name == "🔍 Search...")
            {
                MessageBox.Show("Enter an operator name first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var config = new GunConfig
            {
                Name = name,
                Vertical = _engine.Vertical,
                Horizontal = _engine.Horizontal,
                HorizontalDelay = _engine.HorizontalDelay,
                HorizontalDuration = _engine.HorizontalDuration
            };

            _gunConfigs.RemoveAll(g => g.Name == name);
            _gunConfigs.Add(config);

            string filePath = Path.Combine(_configFolder, name + ".json");
            File.WriteAllText(filePath, JsonConvert.SerializeObject(config, Formatting.Indented));

            UpdateGunList();
            lblStatus.Text = "● Saved!";
            lblStatus.ForeColor = Color.Cyan;
        }

        private void BtnDeleteGun_Click(object sender, EventArgs e)
        {
            if (listGuns.SelectedItem == null) return;
            string name = listGuns.SelectedItem.ToString();
            if (MessageBox.Show($"Delete '{name}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var config = _gunConfigs.FirstOrDefault(g => g.Name == name);
                if (config != null)
                {
                    _gunConfigs.Remove(config);
                    string filePath = Path.Combine(_configFolder, name + ".json");
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                    UpdateGunList();
                    lblStatus.Text = "● Deleted!";
                    lblStatus.ForeColor = Color.Yellow;
                }
            }
        }

        private void ApplySettingsToUI()
        {
            trackVertical.Value = _settings.Vertical;
            trackHorizontal.Value = _settings.Horizontal + 15;
            trackHDelay.Value = _settings.HorizontalDelay;
            trackHDuration.Value = _settings.HorizontalDuration;

            _engine.Vertical = _settings.Vertical;
            _engine.Horizontal = _settings.Horizontal;
            _engine.HorizontalDelay = _settings.HorizontalDelay;
            _engine.HorizontalDuration = _settings.HorizontalDuration;

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            lblVerticalValue.Text = _engine.Vertical.ToString();
            lblHorizontalValue.Text = _engine.Horizontal.ToString();
            lblHDelayValue.Text = _engine.HorizontalDelay.ToString();
            lblHDurationValue.Text = _engine.HorizontalDuration.ToString();
        }

        private void UpdateStatus()
        {
            if (_engine.IsActive)
            {
                btnToggle.Text = "ON";
                btnToggle.BackColor = Color.FromArgb(0, 150, 60);
                btnToggle.ForeColor = Color.White;
                lblStatus.Text = "● ACTIVE";
                lblStatus.ForeColor = Color.FromArgb(0, 220, 80);
            }
            else
            {
                btnToggle.Text = "OFF";
                btnToggle.BackColor = Color.FromArgb(150, 30, 30);
                btnToggle.ForeColor = Color.White;
                lblStatus.Text = "● INACTIVE";
                lblStatus.ForeColor = Color.Gray;
            }
        }

        private void BtnToggle_Click(object sender, EventArgs e)
        {
            _engine.IsActive = !_engine.IsActive;
            UpdateStatus();
        }

        private void Track_Scroll(object sender, EventArgs e)
        {
            var track = sender as TrackBar;
            if (track == trackVertical)
                _engine.Vertical = track.Value;
            else if (track == trackHorizontal)
                _engine.Horizontal = track.Value - 15;
            else if (track == trackHDelay)
                _engine.HorizontalDelay = track.Value;
            else if (track == trackHDuration)
                _engine.HorizontalDuration = track.Value;
            UpdateLabels();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _settings.Vertical = _engine.Vertical;
            _settings.Horizontal = _engine.Horizontal;
            _settings.HorizontalDelay = _engine.HorizontalDelay;
            _settings.HorizontalDuration = _engine.HorizontalDuration;
            ConfigManager.Save(_settings);
            lblStatus.Text = "● Saved!";
            lblStatus.ForeColor = Color.Cyan;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            _settings = ConfigManager.Load();
            ApplySettingsToUI();
            UpdateStatus();
            lblStatus.Text = "● Loaded!";
            lblStatus.ForeColor = Color.Yellow;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_engineThread != null && _engineThread.IsAlive)
                _engineThread.Abort();
            base.OnFormClosing(e);
        }
    }
}