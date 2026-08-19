using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using KeyAuth;

namespace RecoilTime
{
	// Token: 0x0200000F RID: 15
	public partial class Login : Form
	{
		// Token: 0x06000094 RID: 148 RVA: 0x00003DD2 File Offset: 0x00001FD2
		public Login()
		{
			this.InitializeComponent();
			Login.KeyAuthApp.init();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003DEC File Offset: 0x00001FEC
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.login(this.User.Text, this.Pass.Text);
			if (Login.KeyAuthApp.response.success)
			{
				this.ProgressTimer.Start();
				this.Status.Text = Login.KeyAuthApp.response.message;
				return;
			}
			this.Status.Text = Login.KeyAuthApp.response.message;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003E6A File Offset: 0x0000206A
		private void Loginsuccess()
		{
			base.Hide();
			new MainForm().Show();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003E7C File Offset: 0x0000207C
		private void guna2ControlBox1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003E83 File Offset: 0x00002083
		private void goToLogin_Click(object sender, EventArgs e)
		{
			this.LoginPanel.BringToFront();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003E90 File Offset: 0x00002090
		private void goToRegister_Click(object sender, EventArgs e)
		{
			this.RegisterPanel.BringToFront();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003EA0 File Offset: 0x000020A0
		private void RegisterBtn_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.register(this.RgUser.Text, this.RgPass.Text, this.RgKey.Text, "");
			if (Login.KeyAuthApp.response.success)
			{
				this.RegisterSuccess();
				this.Status.Text = "Register Success";
				return;
			}
			this.Status.Text = Login.KeyAuthApp.response.message;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003F1F File Offset: 0x0000211F
		private void RegisterSuccess()
		{
			this.LoginPanel.BringToFront();
			this.User.Text = this.RgUser.Text;
			this.Pass.Text = this.RgPass.Text;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003F58 File Offset: 0x00002158
		private void ProgressTimer_Tick(object sender, EventArgs e)
		{
			this.guna2Panel1.BringToFront();
			this.guna2Panel1.Visible = true;
			this.guna2CircleProgressBar1.Value += 3;
			if (this.guna2CircleProgressBar1.Value >= 100)
			{
				this.Loginsuccess();
				this.ProgressTimer.Stop();
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003FAF File Offset: 0x000021AF
		private void Login_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2ProgressBar1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0400003E RID: 62
		public static api KeyAuthApp = new api("Login Form", "WtOfeYhs14", "5f9a608dd2e0fbf659190d4a40d67a5daca64658aab859b0491ad7bf8c108ec7", "1.0", null);
	}
}
