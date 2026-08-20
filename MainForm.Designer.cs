namespace RecoilTime
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Borders
            this.sepTop = new System.Windows.Forms.Panel();
            this.sepBottom = new System.Windows.Forms.Panel();
            this.sepLeft = new System.Windows.Forms.Panel();
            this.sepRight = new System.Windows.Forms.Panel();

            // Title & Tabs
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnTabRecoil = new System.Windows.Forms.Button();
            this.btnTabSettings = new System.Windows.Forms.Button();

            // Window controls
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            // Panels
            this.panelRecoil = new System.Windows.Forms.Panel();
            this.panelSettings = new System.Windows.Forms.Panel();

            // Recoil Card
            this.cardRecoil = new System.Windows.Forms.Panel();
            this.lblRecoilTitle = new System.Windows.Forms.Label();
            this.sepRecoilTitle = new System.Windows.Forms.Panel();
            this.lblStrength = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblTooltip = new System.Windows.Forms.Label();
            this.lblSleep = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.bindbutton = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();

            // Quick Save Card
            this.cardQuickSave = new System.Windows.Forms.Panel();
            this.lblQuickSaveTitle = new System.Windows.Forms.Label();
            this.sepQuickSave = new System.Windows.Forms.Panel();
            this.txtQuickSave = new System.Windows.Forms.TextBox();
            this.btnSaveCurrent = new System.Windows.Forms.Button();

            // Settings - Configs Card
            this.cardConfigs = new System.Windows.Forms.Panel();
            this.lblConfigsTitle = new System.Windows.Forms.Label();
            this.sepConfigsTitle = new System.Windows.Forms.Panel();
            this.comboBoxConfigs = new System.Windows.Forms.ComboBox();
            this.guna2TextBox2 = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            // Settings - Program Card
            this.cardProgram = new System.Windows.Forms.Panel();
            this.lblProgramTitle = new System.Windows.Forms.Label();
            this.sepProgramTitle = new System.Windows.Forms.Panel();
            this.checkBoxHideTaskbar = new System.Windows.Forms.CheckBox();
            this.lblHideTaskbar = new System.Windows.Forms.Label();

            // Hidden toggle
            this.guna2Button1 = new System.Windows.Forms.Button();

            // Tooltip
            this.panel7 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();

            // Timers
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.binding3 = new System.Windows.Forms.Timer(this.components);

            // Suspend
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panelRecoil.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.cardRecoil.SuspendLayout();
            this.cardQuickSave.SuspendLayout();
            this.cardConfigs.SuspendLayout();
            this.cardProgram.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();

            // === BORDERS ===
            this.sepTop.BackColor = System.Drawing.Color.FromArgb(138, 29, 39);
            this.sepTop.Location = new System.Drawing.Point(0, 0);
            this.sepTop.Name = "sepTop";
            this.sepTop.Size = new System.Drawing.Size(420, 2);

            this.sepBottom.BackColor = System.Drawing.Color.FromArgb(138, 29, 39);
            this.sepBottom.Location = new System.Drawing.Point(0, 538);
            this.sepBottom.Name = "sepBottom";
            this.sepBottom.Size = new System.Drawing.Size(420, 2);

            this.sepLeft.BackColor = System.Drawing.Color.FromArgb(138, 29, 39);
            this.sepLeft.Location = new System.Drawing.Point(0, 0);
            this.sepLeft.Name = "sepLeft";
            this.sepLeft.Size = new System.Drawing.Size(2, 540);

            this.sepRight.BackColor = System.Drawing.Color.FromArgb(138, 29, 39);
            this.sepRight.Location = new System.Drawing.Point(418, 0);
            this.sepRight.Name = "sepRight";
            this.sepRight.Size = new System.Drawing.Size(2, 540);

            // === TITLE ===
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(87, 21);
            this.lblTitle.Text = "RecoilTime";

            // === TAB BUTTONS ===
            this.btnTabRecoil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabRecoil.FlatAppearance.BorderSize = 0;
            this.btnTabRecoil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTabRecoil.Location = new System.Drawing.Point(200, 6);
            this.btnTabRecoil.Name = "btnTabRecoil";
            this.btnTabRecoil.Size = new System.Drawing.Size(80, 26);
            this.btnTabRecoil.Text = "Recoil";
            this.btnTabRecoil.UseVisualStyleBackColor = false;
            this.btnTabRecoil.Click += new System.EventHandler(this.btnTabRecoil_Click);

            this.btnTabSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabSettings.FlatAppearance.BorderSize = 0;
            this.btnTabSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTabSettings.Location = new System.Drawing.Point(285, 6);
            this.btnTabSettings.Name = "btnTabSettings";
            this.btnTabSettings.Size = new System.Drawing.Size(80, 26);
            this.btnTabSettings.Text = "Settings";
            this.btnTabSettings.UseVisualStyleBackColor = false;
            this.btnTabSettings.Click += new System.EventHandler(this.btnTabSettings_Click);

            // === WINDOW CONTROLS ===
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(370, 5);
            this.btnMinimize.Size = new System.Drawing.Size(22, 22);
            this.btnMinimize.Text = "_";
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);

            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(395, 5);
            this.btnClose.Size = new System.Drawing.Size(22, 22);
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // === PANEL RECOIL ===
            this.panelRecoil.BackColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.panelRecoil.Controls.Add(this.cardQuickSave);
            this.panelRecoil.Controls.Add(this.cardRecoil);
            this.panelRecoil.Location = new System.Drawing.Point(10, 40);
            this.panelRecoil.Name = "panelRecoil";
            this.panelRecoil.Size = new System.Drawing.Size(400, 460);
            this.panelRecoil.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panelRecoil.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.panelRecoil.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);

            // === CARD RECOIL ===
            this.cardRecoil.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            this.cardRecoil.Controls.Add(this.label6);
            this.cardRecoil.Controls.Add(this.lblStatus);
            this.cardRecoil.Controls.Add(this.bindbutton);
            this.cardRecoil.Controls.Add(this.numericUpDown2);
            this.cardRecoil.Controls.Add(this.lblSleep);
            this.cardRecoil.Controls.Add(this.lblTooltip);
            this.cardRecoil.Controls.Add(this.numericUpDown1);
            this.cardRecoil.Controls.Add(this.lblStrength);
            this.cardRecoil.Controls.Add(this.sepRecoilTitle);
            this.cardRecoil.Controls.Add(this.lblRecoilTitle);
            this.cardRecoil.Location = new System.Drawing.Point(10, 10);
            this.cardRecoil.Name = "cardRecoil";
            this.cardRecoil.Size = new System.Drawing.Size(380, 260);

            this.lblRecoilTitle.AutoSize = true;
            this.lblRecoilTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecoilTitle.ForeColor = System.Drawing.Color.White;
            this.lblRecoilTitle.Location = new System.Drawing.Point(15, 12);
            this.lblRecoilTitle.Text = "Recoil Settings";

            this.sepRecoilTitle.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.sepRecoilTitle.Location = new System.Drawing.Point(15, 35);
            this.sepRecoilTitle.Size = new System.Drawing.Size(350, 1);

            this.lblStrength.AutoSize = true;
            this.lblStrength.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStrength.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.lblStrength.Location = new System.Drawing.Point(15, 50);
            this.lblStrength.Text = "Strength:";

            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.ForeColor = System.Drawing.Color.White;
            this.numericUpDown1.Location = new System.Drawing.Point(200, 48);
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);

            this.lblTooltip.AutoSize = true;
            this.lblTooltip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTooltip.ForeColor = System.Drawing.Color.FromArgb(130, 26, 39);
            this.lblTooltip.Location = new System.Drawing.Point(15, 85);
            this.lblTooltip.Text = "(?)";
            this.lblTooltip.MouseEnter += new System.EventHandler(this.label9_MouseEnter);
            this.lblTooltip.MouseLeave += new System.EventHandler(this.label9_MouseLeave);

            this.lblSleep.AutoSize = true;
            this.lblSleep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSleep.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.lblSleep.Location = new System.Drawing.Point(42, 85);
            this.lblSleep.Text = "Sleep:";

            this.numericUpDown2.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.numericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown2.ForeColor = System.Drawing.Color.White;
            this.numericUpDown2.Location = new System.Drawing.Point(200, 83);
            this.numericUpDown2.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });

            this.bindbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bindbutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.bindbutton.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.bindbutton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindbutton.ForeColor = System.Drawing.Color.White;
            this.bindbutton.Location = new System.Drawing.Point(110, 125);
            this.bindbutton.Size = new System.Drawing.Size(160, 32);
            this.bindbutton.Text = "bind";
            this.bindbutton.Click += new System.EventHandler(this.bindbutton_Click);
            this.bindbutton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bindbutton_KeyDown);
            this.bindbutton.TextChanged += new System.EventHandler(this.bindbutton_TextChanged);

            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(15, 200);
            this.lblStatus.Text = "Status:";

            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(70, 200);
            this.label6.Text = "Disabled";

            // === CARD QUICK SAVE ===
            this.cardQuickSave.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            this.cardQuickSave.Controls.Add(this.btnSaveCurrent);
            this.cardQuickSave.Controls.Add(this.txtQuickSave);
            this.cardQuickSave.Controls.Add(this.sepQuickSave);
            this.cardQuickSave.Controls.Add(this.lblQuickSaveTitle);
            this.cardQuickSave.Location = new System.Drawing.Point(10, 285);
            this.cardQuickSave.Name = "cardQuickSave";
            this.cardQuickSave.Size = new System.Drawing.Size(380, 110);

            this.lblQuickSaveTitle.AutoSize = true;
            this.lblQuickSaveTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblQuickSaveTitle.ForeColor = System.Drawing.Color.White;
            this.lblQuickSaveTitle.Location = new System.Drawing.Point(15, 12);
            this.lblQuickSaveTitle.Text = "Quick Save";

            this.sepQuickSave.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.sepQuickSave.Location = new System.Drawing.Point(15, 35);
            this.sepQuickSave.Size = new System.Drawing.Size(350, 1);

            this.txtQuickSave.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.txtQuickSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuickSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtQuickSave.ForeColor = System.Drawing.Color.White;
            this.txtQuickSave.Location = new System.Drawing.Point(15, 50);
            this.txtQuickSave.Size = new System.Drawing.Size(200, 23);
            this.txtQuickSave.Text = "Name";

            this.btnSaveCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCurrent.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.btnSaveCurrent.BackColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.btnSaveCurrent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveCurrent.ForeColor = System.Drawing.Color.White;
            this.btnSaveCurrent.Location = new System.Drawing.Point(230, 50);
            this.btnSaveCurrent.Size = new System.Drawing.Size(80, 25);
            this.btnSaveCurrent.Text = "Save";
            this.btnSaveCurrent.Click += new System.EventHandler(this.btnSaveCurrent_Click);

            // === PANEL SETTINGS ===
            this.panelSettings.BackColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.panelSettings.Controls.Add(this.cardProgram);
            this.panelSettings.Controls.Add(this.cardConfigs);
            this.panelSettings.Location = new System.Drawing.Point(10, 40);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(400, 460);
            this.panelSettings.Visible = false;
            this.panelSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panelSettings.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.panelSettings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);

            // === CARD CONFIGS ===
            this.cardConfigs.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            this.cardConfigs.Controls.Add(this.btnDelete);
            this.cardConfigs.Controls.Add(this.btnSaveSettings);
            this.cardConfigs.Controls.Add(this.btnLoad);
            this.cardConfigs.Controls.Add(this.guna2TextBox2);
            this.cardConfigs.Controls.Add(this.comboBoxConfigs);
            this.cardConfigs.Controls.Add(this.sepConfigsTitle);
            this.cardConfigs.Controls.Add(this.lblConfigsTitle);
            this.cardConfigs.Location = new System.Drawing.Point(10, 10);
            this.cardConfigs.Name = "cardConfigs";
            this.cardConfigs.Size = new System.Drawing.Size(380, 220);

            this.lblConfigsTitle.AutoSize = true;
            this.lblConfigsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblConfigsTitle.ForeColor = System.Drawing.Color.White;
            this.lblConfigsTitle.Location = new System.Drawing.Point(15, 12);
            this.lblConfigsTitle.Text = "Saved Configs";

            this.sepConfigsTitle.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.sepConfigsTitle.Location = new System.Drawing.Point(15, 35);
            this.sepConfigsTitle.Size = new System.Drawing.Size(350, 1);

            this.comboBoxConfigs.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.comboBoxConfigs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConfigs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxConfigs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxConfigs.ForeColor = System.Drawing.Color.White;
            this.comboBoxConfigs.Location = new System.Drawing.Point(15, 50);
            this.comboBoxConfigs.Size = new System.Drawing.Size(170, 23);
            this.comboBoxConfigs.SelectedIndexChanged += new System.EventHandler(this.comboBoxConfigs_SelectedIndexChanged);

            this.guna2TextBox2.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.guna2TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guna2TextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox2.ForeColor = System.Drawing.Color.White;
            this.guna2TextBox2.Location = new System.Drawing.Point(195, 50);
            this.guna2TextBox2.Size = new System.Drawing.Size(170, 23);
            this.guna2TextBox2.Text = "Search";
            this.guna2TextBox2.TextChanged += new System.EventHandler(this.guna2TextBox2_TextChanged);

            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(15, 95);
            this.btnLoad.Size = new System.Drawing.Size(80, 26);
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.guna2Button21_Click);

            this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.btnSaveSettings.BackColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.btnSaveSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveSettings.ForeColor = System.Drawing.Color.White;
            this.btnSaveSettings.Location = new System.Drawing.Point(105, 95);
            this.btnSaveSettings.Size = new System.Drawing.Size(80, 26);
            this.btnSaveSettings.Text = "Save";

            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(195, 95);
            this.btnDelete.Size = new System.Drawing.Size(80, 26);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.guna2Button22_Click);

            // === CARD PROGRAM ===
            this.cardProgram.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            this.cardProgram.Controls.Add(this.lblHideTaskbar);
            this.cardProgram.Controls.Add(this.checkBoxHideTaskbar);
            this.cardProgram.Controls.Add(this.sepProgramTitle);
            this.cardProgram.Controls.Add(this.lblProgramTitle);
            this.cardProgram.Location = new System.Drawing.Point(10, 245);
            this.cardProgram.Name = "cardProgram";
            this.cardProgram.Size = new System.Drawing.Size(380, 100);

            this.lblProgramTitle.AutoSize = true;
            this.lblProgramTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProgramTitle.ForeColor = System.Drawing.Color.White;
            this.lblProgramTitle.Location = new System.Drawing.Point(15, 12);
            this.lblProgramTitle.Text = "Program Settings";

            this.sepProgramTitle.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.sepProgramTitle.Location = new System.Drawing.Point(15, 35);
            this.sepProgramTitle.Size = new System.Drawing.Size(350, 1);

            this.checkBoxHideTaskbar.AutoSize = true;
            this.checkBoxHideTaskbar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            this.checkBoxHideTaskbar.ForeColor = System.Drawing.Color.White;
            this.checkBoxHideTaskbar.Location = new System.Drawing.Point(15, 55);
            this.checkBoxHideTaskbar.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHideTaskbar.UseVisualStyleBackColor = false;
            this.checkBoxHideTaskbar.CheckedChanged += new System.EventHandler(this.checkBoxHideTaskbar_CheckedChanged);

            this.lblHideTaskbar.AutoSize = true;
            this.lblHideTaskbar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHideTaskbar.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.lblHideTaskbar.Location = new System.Drawing.Point(35, 55);
            this.lblHideTaskbar.Text = "Hide from taskbar";

            // === HIDDEN TOGGLE ===
            this.guna2Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guna2Button1.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1000, 500);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(19, 23);
            this.guna2Button1.Text = "enable";
            this.guna2Button1.Visible = false;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
            this.guna2Button1.TextChanged += new System.EventHandler(this.guna2Button1_TextChanged);

            // === TOOLTIP ===
            this.panel7.Controls.Add(this.label19);
            this.panel7.Location = new System.Drawing.Point(500, 300);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(220, 35);
            this.panel7.Visible = false;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);

            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(5, 10);
            this.label19.Text = "Smoothness Sleep 6 recommended";

            // === TIMERS ===
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);

            this.binding3.Enabled = true;
            this.binding3.Tick += new System.EventHandler(this.binding3_Tick);

            // === FORM ===
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.ClientSize = new System.Drawing.Size(420, 540);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelRecoil);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnTabSettings);
            this.Controls.Add(this.btnTabRecoil);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.sepRight);
            this.Controls.Add(this.sepLeft);
            this.Controls.Add(this.sepBottom);
            this.Controls.Add(this.sepTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecoilTime";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);

            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panelRecoil.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.cardRecoil.ResumeLayout(false);
            this.cardRecoil.PerformLayout();
            this.cardQuickSave.ResumeLayout(false);
            this.cardQuickSave.PerformLayout();
            this.cardConfigs.ResumeLayout(false);
            this.cardConfigs.PerformLayout();
            this.cardProgram.ResumeLayout(false);
            this.cardProgram.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel sepTop;
        private System.Windows.Forms.Panel sepBottom;
        private System.Windows.Forms.Panel sepLeft;
        private System.Windows.Forms.Panel sepRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnTabRecoil;
        private System.Windows.Forms.Button btnTabSettings;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelRecoil;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Panel cardRecoil;
        private System.Windows.Forms.Label lblRecoilTitle;
        private System.Windows.Forms.Panel sepRecoilTitle;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblTooltip;
        private System.Windows.Forms.Label lblSleep;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button bindbutton;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel cardQuickSave;
        private System.Windows.Forms.Label lblQuickSaveTitle;
        private System.Windows.Forms.Panel sepQuickSave;
        private System.Windows.Forms.TextBox txtQuickSave;
        private System.Windows.Forms.Button btnSaveCurrent;
        private System.Windows.Forms.Panel cardConfigs;
        private System.Windows.Forms.Label lblConfigsTitle;
        private System.Windows.Forms.Panel sepConfigsTitle;
        private System.Windows.Forms.ComboBox comboBoxConfigs;
        private System.Windows.Forms.TextBox guna2TextBox2;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel cardProgram;
        private System.Windows.Forms.Label lblProgramTitle;
        private System.Windows.Forms.Panel sepProgramTitle;
        private System.Windows.Forms.CheckBox checkBoxHideTaskbar;
        private System.Windows.Forms.Label lblHideTaskbar;
        private System.Windows.Forms.Button guna2Button1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer binding3;
    }
}
