namespace RecoilTime
{
	// Token: 0x0200000F RID: 15
	public partial class Login : global::System.Windows.Forms.Form
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x00003FB1 File Offset: 0x000021B1
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003FD0 File Offset: 0x000021D0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RecoilTime.Login));
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.guna2ControlBox1 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.guna2ControlBox2 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.User = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.Pass = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.Status = new global::System.Windows.Forms.Label();
			this.LoginPanel = new global::Guna.UI2.WinForms.Guna2Panel();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox4 = new global::System.Windows.Forms.PictureBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.goToRegister = new global::System.Windows.Forms.Label();
			this.RegisterPanel = new global::Guna.UI2.WinForms.Guna2Panel();
			this.pictureBox5 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.RgUser = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.RegisterBtn = new global::Guna.UI2.WinForms.Guna2Button();
			this.label4 = new global::System.Windows.Forms.Label();
			this.RgPass = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.goToLogin = new global::System.Windows.Forms.Label();
			this.RgKey = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.ProgressTimer = new global::System.Windows.Forms.Timer(this.components);
			this.label2 = new global::System.Windows.Forms.Label();
			this.guna2CirclePictureBox1 = new global::Guna.UI2.WinForms.Guna2CirclePictureBox();
			this.guna2CircleProgressBar1 = new global::Guna.UI2.WinForms.Guna2CircleProgressBar();
			this.guna2Panel1 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.LoginPanel.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			this.RegisterPanel.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			this.guna2CirclePictureBox1.BeginInit();
			this.guna2Panel1.SuspendLayout();
			base.SuspendLayout();
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			this.guna2BorderlessForm1.HasFormShadow = false;
			this.guna2BorderlessForm1.TransparentWhileDrag = true;
			this.guna2ControlBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.guna2ControlBox1.ControlBoxStyle = 1;
			this.guna2ControlBox1.FillColor = global::System.Drawing.Color.Black;
			this.guna2ControlBox1.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox1.Location = new global::System.Drawing.Point(337, 12);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.Size = new global::System.Drawing.Size(45, 29);
			this.guna2ControlBox1.TabIndex = 0;
			this.guna2ControlBox1.Click += new global::System.EventHandler(this.guna2ControlBox1_Click);
			this.guna2ControlBox2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.guna2ControlBox2.ControlBoxStyle = 1;
			this.guna2ControlBox2.ControlBoxType = 0;
			this.guna2ControlBox2.FillColor = global::System.Drawing.Color.Black;
			this.guna2ControlBox2.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox2.Location = new global::System.Drawing.Point(286, 12);
			this.guna2ControlBox2.Name = "guna2ControlBox2";
			this.guna2ControlBox2.Size = new global::System.Drawing.Size(45, 29);
			this.guna2ControlBox2.TabIndex = 1;
			this.User.BorderColor = global::System.Drawing.Color.Transparent;
			this.User.BorderRadius = 5;
			this.User.BorderThickness = 0;
			this.User.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.User.DefaultText = "";
			this.User.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.User.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.User.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.User.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.User.FillColor = global::System.Drawing.Color.Black;
			this.User.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.User.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.User.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.User.Location = new global::System.Drawing.Point(99, 17);
			this.User.Name = "User";
			this.User.PasswordChar = '\0';
			this.User.PlaceholderText = "                     Username";
			this.User.SelectedText = "";
			this.User.Size = new global::System.Drawing.Size(232, 36);
			this.User.TabIndex = 2;
			this.Pass.BorderColor = global::System.Drawing.Color.Transparent;
			this.Pass.BorderRadius = 5;
			this.Pass.BorderThickness = 0;
			this.Pass.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.Pass.DefaultText = "";
			this.Pass.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.Pass.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.Pass.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.Pass.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.Pass.FillColor = global::System.Drawing.Color.Black;
			this.Pass.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.Pass.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.Pass.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.Pass.Location = new global::System.Drawing.Point(99, 75);
			this.Pass.Name = "Pass";
			this.Pass.PasswordChar = '●';
			this.Pass.PlaceholderText = "                     Password";
			this.Pass.SelectedText = "";
			this.Pass.Size = new global::System.Drawing.Size(232, 36);
			this.Pass.TabIndex = 3;
			this.Pass.UseSystemPasswordChar = true;
			this.guna2Button1.AutoRoundedCorners = true;
			this.guna2Button1.BorderColor = global::System.Drawing.Color.DimGray;
			this.guna2Button1.BorderRadius = 21;
			this.guna2Button1.BorderThickness = 1;
			this.guna2Button1.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button1.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.guna2Button1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.guna2Button1.FillColor = global::System.Drawing.Color.FromArgb(17, 18, 17);
			this.guna2Button1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.Location = new global::System.Drawing.Point(106, 120);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.Size = new global::System.Drawing.Size(180, 45);
			this.guna2Button1.TabIndex = 4;
			this.guna2Button1.Text = "LOGIN";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.Status.AutoSize = true;
			this.Status.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Status.ForeColor = global::System.Drawing.Color.White;
			this.Status.Location = new global::System.Drawing.Point(1, 415);
			this.Status.Name = "Status";
			this.Status.Size = new global::System.Drawing.Size(35, 18);
			this.Status.TabIndex = 5;
			this.Status.Text = "N/A";
			this.LoginPanel.Controls.Add(this.pictureBox2);
			this.LoginPanel.Controls.Add(this.pictureBox4);
			this.LoginPanel.Controls.Add(this.panel1);
			this.LoginPanel.Controls.Add(this.panel2);
			this.LoginPanel.Controls.Add(this.User);
			this.LoginPanel.Controls.Add(this.Pass);
			this.LoginPanel.Controls.Add(this.label1);
			this.LoginPanel.Controls.Add(this.guna2Button1);
			this.LoginPanel.Controls.Add(this.goToRegister);
			this.LoginPanel.CustomBorderColor = global::System.Drawing.Color.Transparent;
			this.LoginPanel.Location = new global::System.Drawing.Point(2, 196);
			this.LoginPanel.Name = "LoginPanel";
			this.LoginPanel.Size = new global::System.Drawing.Size(392, 204);
			this.LoginPanel.TabIndex = 6;
			this.pictureBox2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new global::System.Drawing.Point(66, 72);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(32, 36);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 16;
			this.pictureBox2.TabStop = false;
			this.pictureBox4.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox4.Image");
			this.pictureBox4.Location = new global::System.Drawing.Point(66, 14);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new global::System.Drawing.Size(32, 36);
			this.pictureBox4.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox4.TabIndex = 15;
			this.pictureBox4.TabStop = false;
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.panel1.Location = new global::System.Drawing.Point(66, 110);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(265, 1);
			this.panel1.TabIndex = 14;
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.panel2.Location = new global::System.Drawing.Point(66, 52);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(265, 1);
			this.panel2.TabIndex = 13;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(-1, 176);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(139, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "I don't have an account";
			this.goToRegister.AutoSize = true;
			this.goToRegister.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 0);
			this.goToRegister.ForeColor = global::System.Drawing.Color.Gray;
			this.goToRegister.Location = new global::System.Drawing.Point(135, 176);
			this.goToRegister.Name = "goToRegister";
			this.goToRegister.Size = new global::System.Drawing.Size(55, 16);
			this.goToRegister.TabIndex = 6;
			this.goToRegister.Text = "Register";
			this.goToRegister.Click += new global::System.EventHandler(this.goToRegister_Click);
			this.RegisterPanel.Controls.Add(this.pictureBox5);
			this.RegisterPanel.Controls.Add(this.pictureBox1);
			this.RegisterPanel.Controls.Add(this.pictureBox3);
			this.RegisterPanel.Controls.Add(this.panel5);
			this.RegisterPanel.Controls.Add(this.panel4);
			this.RegisterPanel.Controls.Add(this.panel3);
			this.RegisterPanel.Controls.Add(this.RgUser);
			this.RegisterPanel.Controls.Add(this.RegisterBtn);
			this.RegisterPanel.Controls.Add(this.label4);
			this.RegisterPanel.Controls.Add(this.RgPass);
			this.RegisterPanel.Controls.Add(this.goToLogin);
			this.RegisterPanel.Controls.Add(this.RgKey);
			this.RegisterPanel.Location = new global::System.Drawing.Point(2, 196);
			this.RegisterPanel.Name = "RegisterPanel";
			this.RegisterPanel.Size = new global::System.Drawing.Size(391, 194);
			this.RegisterPanel.TabIndex = 7;
			this.pictureBox5.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox5.Image");
			this.pictureBox5.Location = new global::System.Drawing.Point(62, 82);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new global::System.Drawing.Size(32, 36);
			this.pictureBox5.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox5.TabIndex = 24;
			this.pictureBox5.TabStop = false;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(62, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(32, 36);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 23;
			this.pictureBox1.TabStop = false;
			this.pictureBox3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new global::System.Drawing.Point(62, 0);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(32, 36);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 22;
			this.pictureBox3.TabStop = false;
			this.panel5.BackColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.panel5.Location = new global::System.Drawing.Point(62, 118);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(265, 1);
			this.panel5.TabIndex = 21;
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.panel4.Location = new global::System.Drawing.Point(64, 79);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(265, 1);
			this.panel4.TabIndex = 20;
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.panel3.Location = new global::System.Drawing.Point(62, 37);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(265, 1);
			this.panel3.TabIndex = 14;
			this.RgUser.BorderRadius = 5;
			this.RgUser.BorderThickness = 0;
			this.RgUser.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.RgUser.DefaultText = "";
			this.RgUser.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.RgUser.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.RgUser.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.RgUser.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.RgUser.FillColor = global::System.Drawing.Color.Black;
			this.RgUser.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.RgUser.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.RgUser.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.RgUser.Location = new global::System.Drawing.Point(100, 3);
			this.RgUser.Name = "RgUser";
			this.RgUser.PasswordChar = '\0';
			this.RgUser.PlaceholderText = "                    Username";
			this.RgUser.SelectedText = "";
			this.RgUser.Size = new global::System.Drawing.Size(243, 32);
			this.RgUser.TabIndex = 2;
			this.RegisterBtn.AutoRoundedCorners = true;
			this.RegisterBtn.BorderColor = global::System.Drawing.Color.DimGray;
			this.RegisterBtn.BorderRadius = 17;
			this.RegisterBtn.BorderThickness = 1;
			this.RegisterBtn.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.RegisterBtn.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.RegisterBtn.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.RegisterBtn.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.RegisterBtn.FillColor = global::System.Drawing.Color.FromArgb(17, 18, 17);
			this.RegisterBtn.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.RegisterBtn.ForeColor = global::System.Drawing.Color.White;
			this.RegisterBtn.Location = new global::System.Drawing.Point(105, 131);
			this.RegisterBtn.Name = "RegisterBtn";
			this.RegisterBtn.Size = new global::System.Drawing.Size(180, 36);
			this.RegisterBtn.TabIndex = 4;
			this.RegisterBtn.Text = "Register";
			this.RegisterBtn.Click += new global::System.EventHandler(this.RegisterBtn_Click);
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.White;
			this.label4.Location = new global::System.Drawing.Point(-3, 177);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(154, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "I already have an account";
			this.RgPass.BorderRadius = 5;
			this.RgPass.BorderThickness = 0;
			this.RgPass.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.RgPass.DefaultText = "";
			this.RgPass.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.RgPass.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.RgPass.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.RgPass.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.RgPass.FillColor = global::System.Drawing.Color.Black;
			this.RgPass.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.RgPass.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.RgPass.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.RgPass.Location = new global::System.Drawing.Point(100, 46);
			this.RgPass.Name = "RgPass";
			this.RgPass.PasswordChar = '●';
			this.RgPass.PlaceholderText = "                    Password";
			this.RgPass.SelectedText = "";
			this.RgPass.Size = new global::System.Drawing.Size(243, 32);
			this.RgPass.TabIndex = 3;
			this.RgPass.UseSystemPasswordChar = true;
			this.goToLogin.AutoSize = true;
			this.goToLogin.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 0);
			this.goToLogin.ForeColor = global::System.Drawing.Color.Gray;
			this.goToLogin.Location = new global::System.Drawing.Point(150, 177);
			this.goToLogin.Name = "goToLogin";
			this.goToLogin.Size = new global::System.Drawing.Size(38, 16);
			this.goToLogin.TabIndex = 8;
			this.goToLogin.Text = "Login";
			this.goToLogin.Click += new global::System.EventHandler(this.goToLogin_Click);
			this.RgKey.BorderRadius = 5;
			this.RgKey.BorderThickness = 0;
			this.RgKey.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.RgKey.DefaultText = "";
			this.RgKey.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.RgKey.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.RgKey.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.RgKey.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.RgKey.FillColor = global::System.Drawing.Color.Black;
			this.RgKey.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.RgKey.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.RgKey.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.RgKey.Location = new global::System.Drawing.Point(100, 84);
			this.RgKey.Name = "RgKey";
			this.RgKey.PasswordChar = '\0';
			this.RgKey.PlaceholderText = "                         Key";
			this.RgKey.SelectedText = "";
			this.RgKey.Size = new global::System.Drawing.Size(243, 32);
			this.RgKey.TabIndex = 5;
			this.ProgressTimer.Tick += new global::System.EventHandler(this.ProgressTimer_Tick);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Arial Black", 18f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(111, 125);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(176, 33);
			this.label2.TabIndex = 10;
			this.label2.Text = "S-Market R6";
			this.guna2CirclePictureBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2CirclePictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("guna2CirclePictureBox1.Image");
			this.guna2CirclePictureBox1.ImageRotate = 0f;
			this.guna2CirclePictureBox1.Location = new global::System.Drawing.Point(134, 12);
			this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
			this.guna2CirclePictureBox1.ShadowDecoration.Mode = 1;
			this.guna2CirclePictureBox1.Size = new global::System.Drawing.Size(126, 119);
			this.guna2CirclePictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.guna2CirclePictureBox1.TabIndex = 11;
			this.guna2CirclePictureBox1.TabStop = false;
			this.guna2CircleProgressBar1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2CircleProgressBar1.FillColor = global::System.Drawing.Color.Black;
			this.guna2CircleProgressBar1.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.guna2CircleProgressBar1.ForeColor = global::System.Drawing.Color.White;
			this.guna2CircleProgressBar1.Location = new global::System.Drawing.Point(140, 37);
			this.guna2CircleProgressBar1.Minimum = 0;
			this.guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
			this.guna2CircleProgressBar1.ProgressColor = global::System.Drawing.Color.FromArgb(64, 0, 0);
			this.guna2CircleProgressBar1.ProgressColor2 = global::System.Drawing.Color.FromArgb(192, 0, 0);
			this.guna2CircleProgressBar1.ProgressEndCap = global::System.Drawing.Drawing2D.LineCap.Round;
			this.guna2CircleProgressBar1.ProgressStartCap = global::System.Drawing.Drawing2D.LineCap.Round;
			this.guna2CircleProgressBar1.ProgressThickness = 15;
			this.guna2CircleProgressBar1.ShadowDecoration.Mode = 1;
			this.guna2CircleProgressBar1.ShowText = true;
			this.guna2CircleProgressBar1.Size = new global::System.Drawing.Size(113, 113);
			this.guna2CircleProgressBar1.TabIndex = 12;
			this.guna2CircleProgressBar1.Text = "guna2CircleProgressBar1";
			this.guna2Panel1.Controls.Add(this.label3);
			this.guna2Panel1.Controls.Add(this.guna2CircleProgressBar1);
			this.guna2Panel1.Location = new global::System.Drawing.Point(0, 196);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new global::System.Drawing.Size(393, 207);
			this.guna2Panel1.TabIndex = 17;
			this.guna2Panel1.Visible = false;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.White;
			this.label3.Location = new global::System.Drawing.Point(145, 152);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(103, 24);
			this.label3.TabIndex = 13;
			this.label3.Text = "Loading...";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.Black;
			base.ClientSize = new global::System.Drawing.Size(394, 442);
			base.Controls.Add(this.guna2CirclePictureBox1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.Status);
			base.Controls.Add(this.guna2ControlBox2);
			base.Controls.Add(this.guna2ControlBox1);
			base.Controls.Add(this.LoginPanel);
			base.Controls.Add(this.RegisterPanel);
			base.Controls.Add(this.guna2Panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Login";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.Login_Load);
			this.LoginPanel.ResumeLayout(false);
			this.LoginPanel.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			this.RegisterPanel.ResumeLayout(false);
			this.RegisterPanel.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			this.guna2CirclePictureBox1.EndInit();
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400003F RID: 63
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000040 RID: 64
		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

		// Token: 0x04000041 RID: 65
		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;

		// Token: 0x04000042 RID: 66
		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;

		// Token: 0x04000043 RID: 67
		private global::Guna.UI2.WinForms.Guna2TextBox User;

		// Token: 0x04000044 RID: 68
		private global::Guna.UI2.WinForms.Guna2TextBox Pass;

		// Token: 0x04000045 RID: 69
		private global::System.Windows.Forms.Label Status;

		// Token: 0x04000046 RID: 70
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000047 RID: 71
		private global::Guna.UI2.WinForms.Guna2Panel LoginPanel;

		// Token: 0x04000048 RID: 72
		private global::Guna.UI2.WinForms.Guna2Panel RegisterPanel;

		// Token: 0x04000049 RID: 73
		private global::Guna.UI2.WinForms.Guna2TextBox RgKey;

		// Token: 0x0400004A RID: 74
		private global::Guna.UI2.WinForms.Guna2TextBox RgUser;

		// Token: 0x0400004B RID: 75
		private global::Guna.UI2.WinForms.Guna2TextBox RgPass;

		// Token: 0x0400004C RID: 76
		private global::Guna.UI2.WinForms.Guna2Button RegisterBtn;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.Label goToLogin;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.Label goToRegister;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Timer ProgressTimer;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000053 RID: 83
		private global::Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.PictureBox pictureBox4;

		// Token: 0x04000056 RID: 86
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000057 RID: 87
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.PictureBox pictureBox5;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x0400005E RID: 94
		private global::Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;

		// Token: 0x0400005F RID: 95
		private global::Guna.UI2.WinForms.Guna2Panel guna2Panel1;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.Label label3;
	}
}
