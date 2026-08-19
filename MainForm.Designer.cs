namespace RecoilController
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label appTitle;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Label lblStatus;

        // Sidebar
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Label lblOperators;
        private System.Windows.Forms.TextBox txtSearchGun;
        private System.Windows.Forms.ListBox listGuns;
        private System.Windows.Forms.Button btnSaveGun;
        private System.Windows.Forms.Button btnDeleteGun;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;

        // Main Content
        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private System.Windows.Forms.Panel cardVertical;
        private System.Windows.Forms.Panel cardHorizontal;
        private System.Windows.Forms.Panel cardHDelay;
        private System.Windows.Forms.Panel cardHDuration;

        private System.Windows.Forms.Label lblVertical;
        private System.Windows.Forms.Label lblVerticalDesc;
        private System.Windows.Forms.TrackBar trackVertical;
        private System.Windows.Forms.Label lblVerticalValue;

        private System.Windows.Forms.Label lblHorizontal;
        private System.Windows.Forms.Label lblHorizontalDesc;
        private System.Windows.Forms.TrackBar trackHorizontal;
        private System.Windows.Forms.Label lblHorizontalValue;

        private System.Windows.Forms.Label lblHDelay;
        private System.Windows.Forms.Label lblHDelayDesc;
        private System.Windows.Forms.TrackBar trackHDelay;
        private System.Windows.Forms.Label lblHDelayValue;

        private System.Windows.Forms.Label lblHDuration;
        private System.Windows.Forms.Label lblHDurationDesc;
        private System.Windows.Forms.TrackBar trackHDuration;
        private System.Windows.Forms.Label lblHDurationValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // ===== HEADER =====
            this.headerPanel = new System.Windows.Forms.Panel();
            this.appTitle = new System.Windows.Forms.Label();
            this.btnToggle = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();

            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(20, 20, 25);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height = 55;
            this.headerPanel.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);

            this.appTitle.AutoSize = true;
            this.appTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.appTitle.ForeColor = System.Drawing.Color.FromArgb(0, 180, 255);
            this.appTitle.Location = new System.Drawing.Point(15, 15);
            this.appTitle.Text = "🎯 RECOIL CONTROLLER";

            this.btnToggle.BackColor = System.Drawing.Color.FromArgb(45, 45, 50);
            this.btnToggle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 65);
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnToggle.ForeColor = System.Drawing.Color.White;
            this.btnToggle.Location = new System.Drawing.Point(380, 10);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(90, 35);
            this.btnToggle.Text = "OFF";
            this.btnToggle.UseVisualStyleBackColor = false;
            this.btnToggle.Click += new System.EventHandler(this.BtnToggle_Click);

            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(480, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 15);
            this.lblStatus.Text = "● INACTIVE";

            this.headerPanel.Controls.Add(this.appTitle);
            this.headerPanel.Controls.Add(this.btnToggle);
            this.headerPanel.Controls.Add(this.lblStatus);

            // ===== SIDEBAR =====
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.lblOperators = new System.Windows.Forms.Label();
            this.txtSearchGun = new System.Windows.Forms.TextBox();
            this.listGuns = new System.Windows.Forms.ListBox();
            this.btnSaveGun = new System.Windows.Forms.Button();
            this.btnDeleteGun = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();

            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(18, 18, 22);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Width = 180;
            this.sidebarPanel.Padding = new System.Windows.Forms.Padding(10);

            this.lblOperators.AutoSize = true;
            this.lblOperators.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOperators.ForeColor = System.Drawing.Color.FromArgb(0, 180, 255);
            this.lblOperators.Location = new System.Drawing.Point(10, 15);
            this.lblOperators.Text = "OPERATORS";

            this.txtSearchGun.BackColor = System.Drawing.Color.FromArgb(30, 30, 35);
            this.txtSearchGun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchGun.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchGun.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchGun.Location = new System.Drawing.Point(10, 40);
            this.txtSearchGun.Name = "txtSearchGun";
            this.txtSearchGun.Size = new System.Drawing.Size(160, 23);
            this.txtSearchGun.Text = "🔍 Search...";
            this.txtSearchGun.Enter += (s, e) => { if (txtSearchGun.Text == "🔍 Search...") txtSearchGun.Text = ""; };
            this.txtSearchGun.Leave += (s, e) => { if (string.IsNullOrEmpty(txtSearchGun.Text)) txtSearchGun.Text = "🔍 Search..."; };
            this.txtSearchGun.TextChanged += new System.EventHandler(this.TxtSearchGun_TextChanged);

            this.listGuns.BackColor = System.Drawing.Color.FromArgb(22, 22, 27);
            this.listGuns.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listGuns.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listGuns.ForeColor = System.Drawing.Color.White;
            this.listGuns.Location = new System.Drawing.Point(10, 70);
            this.listGuns.Name = "listGuns";
            this.listGuns.Size = new System.Drawing.Size(160, 160);
            this.listGuns.SelectedIndexChanged += new System.EventHandler(this.ListGuns_SelectedIndexChanged);

            this.btnSaveGun.BackColor = System.Drawing.Color.FromArgb(0, 120, 200);
            this.btnSaveGun.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 100, 180);
            this.btnSaveGun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveGun.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSaveGun.ForeColor = System.Drawing.Color.White;
            this.btnSaveGun.Location = new System.Drawing.Point(10, 240);
            this.btnSaveGun.Name = "btnSaveGun";
            this.btnSaveGun.Size = new System.Drawing.Size(75, 28);
            this.btnSaveGun.Text = "Save";
            this.btnSaveGun.UseVisualStyleBackColor = false;
            this.btnSaveGun.Click += new System.EventHandler(this.BtnSaveGun_Click);

            this.btnDeleteGun.BackColor = System.Drawing.Color.FromArgb(45, 45, 50);
            this.btnDeleteGun.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 65);
            this.btnDeleteGun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteGun.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnDeleteGun.ForeColor = System.Drawing.Color.White;
            this.btnDeleteGun.Location = new System.Drawing.Point(95, 240);
            this.btnDeleteGun.Name = "btnDeleteGun";
            this.btnDeleteGun.Size = new System.Drawing.Size(75, 28);
            this.btnDeleteGun.Text = "Delete";
            this.btnDeleteGun.UseVisualStyleBackColor = false;
            this.btnDeleteGun.Click += new System.EventHandler(this.BtnDeleteGun_Click);

            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 120, 200);
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 100, 180);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(10, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 32);
            this.btnSave.Text = "💾 SAVE ALL";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(45, 45, 50);
            this.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 65);
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(10, 320);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(160, 32);
            this.btnLoad.Text = "📂 LOAD ALL";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);

            this.sidebarPanel.Controls.Add(this.lblOperators);
            this.sidebarPanel.Controls.Add(this.txtSearchGun);
            this.sidebarPanel.Controls.Add(this.listGuns);
            this.sidebarPanel.Controls.Add(this.btnSaveGun);
            this.sidebarPanel.Controls.Add(this.btnDeleteGun);
            this.sidebarPanel.Controls.Add(this.btnSave);
            this.sidebarPanel.Controls.Add(this.btnLoad);

            // ===== MAIN TABLE LAYOUT =====
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.mainTableLayout.BackColor = System.Drawing.Color.FromArgb(16, 16, 20);
            this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayout.Padding = new System.Windows.Forms.Padding(15);
            this.mainTableLayout.ColumnCount = 1;
            this.mainTableLayout.RowCount = 4;
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));

            // ===== CARDS =====
            // Card Vertical
            this.cardVertical = new System.Windows.Forms.Panel();
            this.cardVertical.BackColor = System.Drawing.Color.FromArgb(24, 24, 28);
            this.cardVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardVertical.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);

            this.lblVertical = new System.Windows.Forms.Label();
            this.lblVertical.AutoSize = true;
            this.lblVertical.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVertical.ForeColor = System.Drawing.Color.White;
            this.lblVertical.Location = new System.Drawing.Point(15, 10);
            this.lblVertical.Text = "VERTICAL";

            this.lblVerticalDesc = new System.Windows.Forms.Label();
            this.lblVerticalDesc.AutoSize = true;
            this.lblVerticalDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblVerticalDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblVerticalDesc.Location = new System.Drawing.Point(15, 28);
            this.lblVerticalDesc.Text = "Pull-down compensation";

            this.trackVertical = new System.Windows.Forms.TrackBar();
            this.trackVertical.BackColor = System.Drawing.Color.FromArgb(30, 30, 35);
            this.trackVertical.Location = new System.Drawing.Point(15, 50);
            this.trackVertical.Maximum = 200;
            this.trackVertical.Name = "trackVertical";
            this.trackVertical.Size = new System.Drawing.Size(200, 30);
            this.trackVertical.TickFrequency = 10;
            this.trackVertical.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackVertical.Scroll += new System.EventHandler(this.Track_Scroll);

            this.lblVerticalValue = new System.Windows.Forms.Label();
            this.lblVerticalValue.AutoSize = true;
            this.lblVerticalValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblVerticalValue.ForeColor = System.Drawing.Color.FromArgb(0, 180, 255);
            this.lblVerticalValue.Location = new System.Drawing.Point(230, 48);
            this.lblVerticalValue.Text = "110";

            this.cardVertical.Controls.Add(this.lblVertical);
            this.cardVertical.Controls.Add(this.lblVerticalDesc);
            this.cardVertical.Controls.Add(this.trackVertical);
            this.cardVertical.Controls.Add(this.lblVerticalValue);

            // Card Horizontal
            this.cardHorizontal = new System.Windows.Forms.Panel();
            this.cardHorizontal.BackColor = System.Drawing.Color.FromArgb(24, 24, 28);
            this.cardHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardHorizontal.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);

            this.lblHorizontal = new System.Windows.Forms.Label();
            this.lblHorizontal.AutoSize = true;
            this.lblHorizontal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHorizontal.ForeColor = System.Drawing.Color.White;
            this.lblHorizontal.Location = new System.Drawing.Point(15, 10);
            this.lblHorizontal.Text = "HORIZONTAL";

            this.lblHorizontalDesc = new System.Windows.Forms.Label();
            this.lblHorizontalDesc.AutoSize = true;
            this.lblHorizontalDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHorizontalDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblHorizontalDesc.Location = new System.Drawing.Point(15, 28);
            this.lblHorizontalDesc.Text = "Side-to-side adjustment";

            this.trackHorizontal = new System.Windows.Forms.TrackBar();
            this.trackHorizontal.BackColor = System.Drawing.Color.FromArgb(30, 30, 35);
            this.trackHorizontal.Location = new System.Drawing.Point(15, 50);
            this.trackHorizontal.Maximum = 30;
            this.trackHorizontal.Name = "trackHorizontal";
            this.trackHorizontal.Size = new System.Drawing.Size(200, 30);
            this.trackHorizontal.TickFrequency = 5;
            this.trackHorizontal.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackHorizontal.Value = 10;
            this.trackHorizontal.Scroll += new System.EventHandler(this.Track_Scroll);

            this.lblHorizontalValue = new System.Windows.Forms.Label();
            this.lblHorizontalValue.AutoSize = true;
            this.lblHorizontalValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHorizontalValue.ForeColor = System.Drawing.Color.FromArgb(0, 180, 255);
            this.lblHorizontalValue.Location = new System.Drawing.Point(230, 48);
            this.lblHorizontalValue.Text = "-5";

            this.cardHorizontal.Controls.Add(this.lblHorizontal);
            this.cardHorizontal.Controls.Add(this.lblHorizontalDesc);
            this.cardHorizontal.Controls.Add(this.trackHorizontal);
            this.cardHorizontal.Controls.Add(this.lblHorizontalValue);

            // Card HDelay
            this.cardHDelay = new System.Windows.Forms.Panel();
            this.cardHDelay.BackColor = System.Drawing.Color.FromArgb(24, 24, 28);
            this.cardHDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardHDelay.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);

            this.lblHDelay = new System.Windows.Forms.Label();
            this.lblHDelay.AutoSize = true;
            this.lblHDelay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHDelay.ForeColor = System.Drawing.Color.White;
            this.lblHDelay.Location = new System.Drawing.Point(15, 10);
            this.lblHDelay.Text = "HORIZONTAL DELAY";

            this.lblHDelayDesc = new System.Windows.Forms.Label();
            this.lblHDelayDesc.AutoSize = true;
            this.lblHDelayDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHDelayDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblHDelayDesc.Location = new System.Drawing.Point(15, 28);
            this.lblHDelayDesc.Text = "Delay before horizontal kicks in (ms)";

            this.trackHDelay = new System.Windows.Forms.TrackBar();
            this.trackHDelay.BackColor = System.Drawing.Color.FromArgb(30, 30, 35);
            this.trackHDelay.Location = new System.Drawing.Point(15, 50);
            this.trackHDelay.Maximum = 500;
            this.trackHDelay.Name = "trackHDelay";
            this.trackHDelay.Size = new System.Drawing.Size(200, 30);
            this.trackHDelay.TickFrequency = 50;
            this.trackHDelay.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackHDelay.Scroll += new System.EventHandler(this.Track_Scroll);

            this.lblHDelayValue = new System.Windows.Forms.Label();
            this.lblHDelayValue.AutoSize = true;
            this.lblHDelayValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHDelayValue.ForeColor = System.Drawing.Color.FromArgb(0, 180, 255);
            this.lblHDelayValue.Location = new System.Drawing.Point(230, 48);
            this.lblHDelayValue.Text = "62";

            this.cardHDelay.Controls.Add(this.lblHDelay);
            this.cardHDelay.Controls.Add(this.lblHDelayDesc);
            this.cardHDelay.Controls.Add(this.trackHDelay);
            this.cardHDelay.Controls.Add(this.lblHDelayValue);

            // Card HDuration
            this.cardHDuration = new System.Windows.Forms.Panel();
            this.cardHDuration.BackColor = System.Drawing.Color.FromArgb(24, 24, 28);
            this.cardHDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardHDuration.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);

            this.lblHDuration = new System.Windows.Forms.Label();
            this.lblHDuration.AutoSize = true;
            this.lblHDuration.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHDuration.ForeColor = System.Drawing.Color.White;
            this.lblHDuration.Location = new System.Drawing.Point(15, 10);
            this.lblHDuration.Text = "HORIZONTAL DURATION";

            this.lblHDurationDesc = new System.Windows.Forms.Label();
            this.lblHDurationDesc.AutoSize = true;
            this.lblHDurationDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHDurationDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblHDurationDesc.Location = new System.Drawing.Point(15, 28);
            this.lblHDurationDesc.Text = "How long horizontal lasts (ms)";

            this.trackHDuration = new System.Windows.Forms.TrackBar();
            this.trackHDuration.BackColor = System.Drawing.Color.FromArgb(30, 30, 35);
            this.trackHDuration.Location = new System.Drawing.Point(15, 50);
            this.trackHDuration.Maximum = 5000;
            this.trackHDuration.Name = "trackHDuration";
            this.trackHDuration.Size = new System.Drawing.Size(200, 30);
            this.trackHDuration.TickFrequency = 500;
            this.trackHDuration.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackHDuration.Scroll += new System.EventHandler(this.Track_Scroll);

            this.lblHDurationValue = new System.Windows.Forms.Label();
            this.lblHDurationValue.AutoSize = true;
            this.lblHDurationValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHDurationValue.ForeColor = System.Drawing.Color.FromArgb(0, 180, 255);
            this.lblHDurationValue.Location = new System.Drawing.Point(230, 48);
            this.lblHDurationValue.Text = "3398";

            this.cardHDuration.Controls.Add(this.lblHDuration);
            this.cardHDuration.Controls.Add(this.lblHDurationDesc);
            this.cardHDuration.Controls.Add(this.trackHDuration);
            this.cardHDuration.Controls.Add(this.lblHDurationValue);

            // Add cards to TableLayout
            this.mainTableLayout.Controls.Add(this.cardVertical, 0, 0);
            this.mainTableLayout.Controls.Add(this.cardHorizontal, 0, 1);
            this.mainTableLayout.Controls.Add(this.cardHDelay, 0, 2);
            this.mainTableLayout.Controls.Add(this.cardHDuration, 0, 3);

            // ===== MAIN FORM =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(16, 16, 20);
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.mainTableLayout);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recoil Controller";
            this.Load += new System.EventHandler(this.MainForm_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}