using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using WindowsInput;
using WindowsInput.Native;

namespace RecoilTime
{
	// Token: 0x02000010 RID: 16
	public partial class MainForm : Form
	{
		// Token: 0x060000A3 RID: 163
		[DllImport("User32.Dll", EntryPoint = "PostMessageA")]
		private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

		// Token: 0x060000A4 RID: 164
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr GetForegroundWindow();

		// Token: 0x060000A5 RID: 165
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		// Token: 0x060000A6 RID: 166
		[DllImport("User32.dll")]
		private static extern short GetAsyncKeyState(Keys vKey);

		// Token: 0x060000A7 RID: 167
		[DllImport("user32.dll")]
		public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

		// Token: 0x060000A8 RID: 168 RVA: 0x00005D50 File Offset: 0x00003F50
		public MainForm()
		{
			this.InitializeComponent();
			base.TopMost = true;
			this.LoadConfigurations();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00005DCE File Offset: 0x00003FCE
		private void ChangeEnabled(bool enabled)
		{
			this.numericUpDown1.Enabled = enabled;
			this.numericUpDown2.Enabled = enabled;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00005DE8 File Offset: 0x00003FE8
		private void MainForm_Load(object sender, EventArgs e)
		{
			this.label20.Text = "User: " + Login.KeyAuthApp.user_data.username;
			this.label23.Text = "Time Left: " + this.expirydaysleft();
			this.label26.Text = string.Format("Expires: {0}", this.UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.subscriptions[0].expiry)));
			this.guna2NumericUpDown1.Value = 80m;
			this.guna2NumericUpDown2.Value = 80m;
			this.guna2NumericUpDown1.Minimum = 1m;
			this.guna2NumericUpDown2.Minimum = 1m;
			this.guna2NumericUpDown4.Value = 80m;
			this.timer1.Start();
			this.t = new Thread(new ThreadStart(Recoil.Loop));
			this.t.Start();
			this.guna2ComboBox2.Items.AddRange(new object[]
			{
				65,
				66,
				67,
				68,
				69,
				70,
				71,
				72,
				73,
				74,
				75,
				76,
				77,
				78,
				79,
				80,
				81,
				82,
				83,
				84,
				85,
				86,
				87,
				88,
				89,
				90,
				48,
				49,
				50,
				51,
				52,
				53,
				54,
				55,
				56,
				57,
				112,
				113,
				114,
				115,
				116,
				117,
				118,
				119,
				120,
				121
			});
			this.guna2ComboBox3.Items.AddRange(new object[]
			{
				65,
				66,
				67,
				68,
				69,
				70,
				71,
				72,
				73,
				74,
				75,
				76,
				77,
				78,
				79,
				80,
				81,
				82,
				83,
				84,
				85,
				86,
				87,
				88,
				89,
				90,
				48,
				49,
				50,
				51,
				52,
				53,
				54,
				55,
				56,
				57,
				112,
				113,
				114,
				115,
				116,
				117,
				118,
				119,
				120,
				121,
				20,
				17,
				18,
				16,
				9,
				32
			});
			this.guna2ComboBox1.Items.AddRange(new object[]
			{
				65,
				66,
				67,
				68,
				69,
				70,
				71,
				72,
				73,
				74,
				75,
				76,
				77,
				78,
				79,
				80,
				81,
				82,
				83,
				84,
				85,
				86,
				87,
				88,
				89,
				90,
				48,
				49,
				50,
				51,
				52,
				53,
				54,
				55,
				56,
				57,
				112,
				113,
				114,
				115,
				116,
				117,
				118,
				119,
				120,
				121
			});
			this.comboBoxKeys.Items.AddRange(new object[]
			{
				65,
				66,
				67,
				68,
				69,
				70,
				71,
				72,
				73,
				74,
				75,
				76,
				77,
				78,
				79,
				80,
				81,
				82,
				83,
				84,
				85,
				86,
				87,
				88,
				89,
				90,
				48,
				49,
				50,
				51,
				52,
				53,
				54,
				55,
				56,
				57,
				112,
				113,
				114,
				115,
				116,
				117,
				118,
				119,
				120,
				121
			});
			this.guna2ComboBox2.SelectedItem = 84;
			this.comboBoxKeys.SelectedItem = 69;
			this.guna2ComboBox1.SelectedItem = 81;
			this.guna2ComboBox3.SelectedItem = 32;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000067A0 File Offset: 0x000049A0
		public string expirydaysleft()
		{
			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			d = d.AddSeconds((double)long.Parse(Login.KeyAuthApp.user_data.subscriptions[0].expiry)).ToLocalTime();
			TimeSpan timeSpan = d - DateTime.Now;
			return Convert.ToString(timeSpan.Days.ToString() + " Days " + timeSpan.Hours.ToString() + " Hours Left");
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00006830 File Offset: 0x00004A30
		public DateTime UnixTimeToDateTime(long unixtime)
		{
			DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			try
			{
				result = result.AddSeconds((double)unixtime).ToLocalTime();
			}
			catch
			{
				result = DateTime.MaxValue;
			}
			return result;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00006880 File Offset: 0x00004A80
		private void Enable()
		{
			this.ChangeEnabled(false);
			int sleeptime = (int)this.numericUpDown2.Value;
			int strength = (int)this.numericUpDown1.Value;
			Recoil.sleeptime = sleeptime;
			Recoil.strength = strength;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000068C0 File Offset: 0x00004AC0
		private void Disable()
		{
			this.ChangeEnabled(true);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000068CC File Offset: 0x00004ACC
		private void Timer1_Tick(object sender, EventArgs e)
		{
			if (Recoil.Enabled)
			{
				this.label6.Text = "Enabled";
				this.label6.ForeColor = Color.Green;
				this.Enable();
				return;
			}
			this.label6.Text = "Disabled";
			this.label6.ForeColor = Color.Red;
			this.Disable();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000692D File Offset: 0x00004B2D
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.t.Abort();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003E7C File Offset: 0x0000207C
		private void guna2ControlBox1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000693C File Offset: 0x00004B3C
		private void CPSTrackbar_Scroll(object sender, ScrollEventArgs e)
		{
			this.CPSValue.Text = this.CPSTrackbar.Value.ToString() + "CPS";
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00006974 File Offset: 0x00004B74
		private void btnToggle_Click(object sender, EventArgs e)
		{
			if (this.btnToggle.Text.Contains("enable"))
			{
				this.btnToggle.Text = "disable";
				return;
			}
			if (this.btnToggle.Text.Contains("disable"))
			{
				this.btnToggle.Text = "enable";
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000069D0 File Offset: 0x00004BD0
		private void btnToggle_TextChanged(object sender, EventArgs e)
		{
			if (this.guna2CustomCheckBox4.Checked)
			{
				if (this.btnToggle.Text.Contains("disable"))
				{
					this.Autoclicker.Start();
				}
				else
				{
					this.Autoclicker.Stop();
				}
				if (this.btnToggle.Text.Contains("disable"))
				{
					this.btnToggle.ForeColor = Color.White;
					this.btnToggle.FillColor = Color.FromArgb(130, 26, 39);
					return;
				}
				if (this.btnToggle.Text.Contains("enable"))
				{
					this.btnToggle.ForeColor = Color.White;
					this.btnToggle.FillColor = Color.FromArgb(80, 80, 80);
				}
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00006A9C File Offset: 0x00004C9C
		public string getActiveWindowName()
		{
			try
			{
				IntPtr foregroundWindow = MainForm.GetForegroundWindow();
				foreach (Process process in Process.GetProcesses())
				{
					if (foregroundWindow == process.MainWindowHandle)
					{
						return process.ProcessName;
					}
				}
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00006AF8 File Offset: 0x00004CF8
		private void Random_Tick(object sender, EventArgs e)
		{
			if (this.btnToggle.Text.Contains("disable"))
			{
				this.min = this.CPSTrackbar.Value - 6;
				this.max = this.CPSTrackbar.Value + 6;
				Random random = new Random();
				this.RandomTB.Value = random.Next(this.min, this.max);
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00006B68 File Offset: 0x00004D68
		private void Autoclicker_Tick(object sender, EventArgs e)
		{
			MainForm.<Autoclicker_Tick>d__27 <Autoclicker_Tick>d__;
			<Autoclicker_Tick>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Autoclicker_Tick>d__.<>4__this = this;
			<Autoclicker_Tick>d__.<>1__state = -1;
			<Autoclicker_Tick>d__.<>t__builder.Start<MainForm.<Autoclicker_Tick>d__27>(ref <Autoclicker_Tick>d__);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00006B9F File Offset: 0x00004D9F
		private void bindBtn_Click(object sender, EventArgs e)
		{
			this.bindBtn.Text = "...";
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00006BB4 File Offset: 0x00004DB4
		private void binding_Tick(object sender, EventArgs e)
		{
			if (this.bindBtn.Text != "bind" && this.bindBtn.Text != "...")
			{
				Keys vKey = (Keys)this.Key.ConvertFromString(this.bindBtn.Text.Replace("...", ""));
				if (MainForm.GetAsyncKeyState(vKey) < 0)
				{
					if (this.btnToggle.Text.Contains("disable"))
					{
						this.btnToggle.Text = "enable";
					}
					else if (this.btnToggle.Text.Contains("enable"))
					{
						this.btnToggle.Text = "disable";
					}
					while (MainForm.GetAsyncKeyState(vKey) < 0)
					{
						Thread.Sleep(20);
					}
					return;
				}
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00006C8C File Offset: 0x00004E8C
		private void bindBtn_KeyDown(object sender, KeyEventArgs e)
		{
			string text = e.KeyData.ToString();
			if (!text.Contains("Alt"))
			{
				if (MainForm.GetAsyncKeyState(Keys.Escape) < 0)
				{
					this.bindBtn.Text = "bind";
				}
				else
				{
					this.bindBtn.Text = text;
				}
			}
			new KeysConverter();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00006CEC File Offset: 0x00004EEC
		private void btnToggle2_Click(object sender, EventArgs e)
		{
			if (this.btnToggle2.Text.Contains("enable"))
			{
				this.btnToggle2.ForeColor = Color.White;
				this.btnToggle2.FillColor = Color.FromArgb(130, 26, 39);
				this.btnToggle2.Text = "disable";
				return;
			}
			if (this.btnToggle2.Text.Contains("disable"))
			{
				this.btnToggle2.ForeColor = Color.White;
				this.btnToggle2.FillColor = Color.FromArgb(68, 71, 75);
				this.btnToggle2.Text = "enable";
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00006D98 File Offset: 0x00004F98
		private void btnToggle2_TextChanged(object sender, EventArgs e)
		{
			if (this.guna2CustomCheckBox5.Checked)
			{
				if (this.btnToggle2.Text.Contains("disable"))
				{
					this.btnToggle2.ForeColor = Color.White;
					this.btnToggle2.FillColor = Color.FromArgb(130, 26, 39);
					this.Autoclicker2.Start();
				}
				else
				{
					this.btnToggle2.ForeColor = Color.White;
					this.btnToggle2.FillColor = Color.FromArgb(68, 71, 75);
					this.Autoclicker2.Stop();
				}
				if (this.btnToggle2.Text.Contains("disable"))
				{
					this.btnToggle2.ForeColor = Color.White;
					this.btnToggle2.FillColor = Color.FromArgb(130, 26, 39);
					return;
				}
				if (this.btnToggle2.Text.Contains("enable"))
				{
					this.btnToggle2.ForeColor = Color.White;
					this.btnToggle2.FillColor = Color.FromArgb(68, 71, 75);
				}
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00006EB4 File Offset: 0x000050B4
		private void Random2_Tick(object sender, EventArgs e)
		{
			if (this.btnToggle2.Text.Contains("disable"))
			{
				this.min = this.CPSTrackbar2.Value - 6;
				this.max = this.CPSTrackbar2.Value + 6;
				Random random = new Random();
				this.randomTB2.Value = random.Next(this.min, this.max);
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00006F24 File Offset: 0x00005124
		private void Autoclicker2_Tick(object sender, EventArgs e)
		{
			MainForm.<Autoclicker2_Tick>d__35 <Autoclicker2_Tick>d__;
			<Autoclicker2_Tick>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Autoclicker2_Tick>d__.<>4__this = this;
			<Autoclicker2_Tick>d__.<>1__state = -1;
			<Autoclicker2_Tick>d__.<>t__builder.Start<MainForm.<Autoclicker2_Tick>d__35>(ref <Autoclicker2_Tick>d__);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00006F5B File Offset: 0x0000515B
		private void bindBtn2_Click(object sender, EventArgs e)
		{
			this.bindBtn2.Text = "...";
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00006F70 File Offset: 0x00005170
		private void binding2_Tick(object sender, EventArgs e)
		{
			if (this.bindBtn2.Text != "bind" && this.bindBtn2.Text != "...")
			{
				Keys vKey = (Keys)this.Key.ConvertFromString(this.bindBtn2.Text.Replace("...", ""));
				if (MainForm.GetAsyncKeyState(vKey) < 0)
				{
					if (this.btnToggle2.Text.Contains("disable"))
					{
						this.btnToggle2.Text = "enable";
					}
					else if (this.btnToggle2.Text.Contains("enable"))
					{
						this.btnToggle2.Text = "disable";
					}
					while (MainForm.GetAsyncKeyState(vKey) < 0)
					{
						Thread.Sleep(20);
					}
					return;
				}
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00007048 File Offset: 0x00005248
		private void bindBtn2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.E || e.KeyCode == Keys.Q)
			{
				e.SuppressKeyPress = true;
				return;
			}
			string text = e.KeyData.ToString();
			if (!text.Contains("Alt"))
			{
				if (MainForm.GetAsyncKeyState(Keys.Escape) < 0)
				{
					this.bindBtn2.Text = "bind";
					return;
				}
				this.bindBtn2.Text = text;
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2Button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000070BA File Offset: 0x000052BA
		private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.guna2CustomCheckBox1.Checked)
			{
				base.ShowInTaskbar = false;
				return;
			}
			base.ShowInTaskbar = true;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000070D8 File Offset: 0x000052D8
		private void guna2Button1_Click_1(object sender, EventArgs e)
		{
			if (this.guna2Button1.Text.Contains("enable"))
			{
				this.guna2Button1.ForeColor = Color.FromArgb(80, 80, 80);
				this.guna2Button1.FillColor = Color.Salmon;
				this.guna2Button1.Text = "disable";
				return;
			}
			if (this.guna2Button1.Text.Contains("disable"))
			{
				this.guna2Button1.ForeColor = Color.Salmon;
				this.guna2Button1.FillColor = Color.FromArgb(80, 80, 80);
				this.guna2Button1.Text = "enable";
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00007180 File Offset: 0x00005380
		private void guna2Button1_TextChanged(object sender, EventArgs e)
		{
			if (this.guna2Button1.Text.Contains("disable"))
			{
				Recoil.Enabled = true;
				return;
			}
			Recoil.Enabled = false;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000071A6 File Offset: 0x000053A6
		private void bindbutton_Click(object sender, EventArgs e)
		{
			this.bindbutton.Text = "...";
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000071B8 File Offset: 0x000053B8
		private void binding3_Tick(object sender, EventArgs e)
		{
			if (this.bindbutton.Text != "bind" && this.bindbutton.Text != "...")
			{
				Keys vKey = (Keys)this.Key.ConvertFromString(this.bindbutton.Text.Replace("...", ""));
				if (MainForm.GetAsyncKeyState(vKey) < 0)
				{
					if (this.guna2Button1.Text.Contains("disable"))
					{
						this.guna2Button1.Text = "enable";
					}
					else if (this.guna2Button1.Text.Contains("enable"))
					{
						this.guna2Button1.Text = "disable";
					}
					while (MainForm.GetAsyncKeyState(vKey) < 0)
					{
						Thread.Sleep(20);
					}
					return;
				}
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00007290 File Offset: 0x00005490
		private void bindbutton_KeyDown(object sender, KeyEventArgs e)
		{
			string text = e.KeyData.ToString();
			if (!text.Contains("Alt"))
			{
				if (MainForm.GetAsyncKeyState(Keys.Escape) < 0)
				{
					this.bindbutton.Text = "bind";
				}
				else
				{
					this.bindbutton.Text = text;
				}
			}
			new KeysConverter();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000072ED File Offset: 0x000054ED
		private void cmdstart_Click(object sender, EventArgs e)
		{
			if (this.guna2CustomCheckBox2.Checked)
			{
				this.timer2.Enabled = true;
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00007308 File Offset: 0x00005508
		private void cmdstop_Click(object sender, EventArgs e)
		{
			this.timer2.Enabled = false;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00007318 File Offset: 0x00005518
		private void timer2_Tick(object sender, EventArgs e)
		{
			InputSimulator inputSimulator = new InputSimulator();
			VirtualKeyCode virtualKeyCode = (VirtualKeyCode)this.guna2ComboBox2.SelectedItem;
			inputSimulator.Keyboard.KeyPress(virtualKeyCode);
			SendKeys.Send(this.guna2TextBox1.Text);
			inputSimulator.Keyboard.KeyPress(13);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00007368 File Offset: 0x00005568
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			if (this.guna2Button2.Text.Contains("enable"))
			{
				this.guna2Button2.Text = "disable";
				return;
			}
			if (this.guna2Button2.Text.Contains("disable"))
			{
				this.guna2Button2.Text = "enable";
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000073C4 File Offset: 0x000055C4
		private void guna2Button2_TextChanged(object sender, EventArgs e)
		{
			if (this.guna2Button2.Text.Contains("disable") && this.guna2CustomCheckBox2.Checked)
			{
				this.guna2Button2.ForeColor = Color.White;
				this.guna2Button2.FillColor = Color.FromArgb(130, 26, 39);
				this.timer2.Interval = (int)this.guna2NumericUpDown3.Value;
				this.timer2.Enabled = true;
				return;
			}
			this.guna2Button2.ForeColor = Color.White;
			this.guna2Button2.FillColor = Color.FromArgb(68, 71, 75);
			this.timer2.Enabled = false;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00007478 File Offset: 0x00005678
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			this.guna2Button3.Text = "...";
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000748C File Offset: 0x0000568C
		private void timer3_Tick(object sender, EventArgs e)
		{
			if (this.guna2Button3.Text != "bind" && this.guna2Button3.Text != "...")
			{
				Keys vKey = (Keys)this.Key.ConvertFromString(this.guna2Button3.Text.Replace("...", ""));
				if (MainForm.GetAsyncKeyState(vKey) < 0)
				{
					if (this.guna2Button2.Text.Contains("disable"))
					{
						this.guna2Button2.Text = "enable";
					}
					else if (this.guna2Button2.Text.Contains("enable"))
					{
						this.guna2Button2.Text = "disable";
					}
					while (MainForm.GetAsyncKeyState(vKey) < 0)
					{
						Thread.Sleep(20);
					}
					return;
				}
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00007564 File Offset: 0x00005764
		private void guna2Button3_KeyDown(object sender, KeyEventArgs e)
		{
			string text = e.KeyData.ToString();
			if (!text.Contains("Alt"))
			{
				if (MainForm.GetAsyncKeyState(Keys.Escape) < 0)
				{
					this.guna2Button3.Text = "bind";
				}
				else
				{
					this.guna2Button3.Text = text;
				}
			}
			new KeysConverter();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00003FAF File Offset: 0x000021AF
		private void CPSTrackbar2_Scroll(object sender, ScrollEventArgs e)
		{
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00003FAF File Offset: 0x000021AF
		private void tabPage4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000075C4 File Offset: 0x000057C4
		private void timer4_Tick(object sender, EventArgs e)
		{
			InputSimulator inputSimulator = new InputSimulator();
			object selectedItem = this.guna2ComboBox3.SelectedItem;
			if (selectedItem is VirtualKeyCode)
			{
				VirtualKeyCode virtualKeyCode = (VirtualKeyCode)selectedItem;
				inputSimulator.Keyboard.KeyPress(virtualKeyCode);
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00007600 File Offset: 0x00005800
		private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
		{
			if (this.guna2ToggleSwitch2.Checked)
			{
				this.timer4.Interval = (int)this.guna2NumericUpDown4.Value;
				this.timer4.Start();
				return;
			}
			this.timer4.Stop();
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00003FAF File Offset: 0x000021AF
		private void pictureBox7_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000764C File Offset: 0x0000584C
		private void guna2Button4_Click(object sender, EventArgs e)
		{
			if (this.guna2Button4.Text.Contains("enable"))
			{
				this.guna2Button4.Text = "disable";
				return;
			}
			if (this.guna2Button4.Text.Contains("disable"))
			{
				this.guna2Button4.Text = "enable";
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000076A8 File Offset: 0x000058A8
		private void guna2Button4_TextChanged(object sender, EventArgs e)
		{
			if (this.guna2Button4.Text.Contains("disable"))
			{
				this.guna2Button4.ForeColor = Color.White;
				this.guna2Button4.FillColor = Color.FromArgb(130, 26, 39);
				if (this.guna2CustomCheckBox3.Checked)
				{
					this.guna2ToggleSwitch2.Checked = true;
					return;
				}
			}
			else
			{
				this.guna2Button4.ForeColor = Color.White;
				this.guna2Button4.FillColor = Color.FromArgb(68, 71, 75);
				this.guna2ToggleSwitch2.Checked = false;
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00007741 File Offset: 0x00005941
		private void guna2Button5_Click(object sender, EventArgs e)
		{
			this.guna2Button5.Text = "...";
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00007754 File Offset: 0x00005954
		private void timer5_Tick(object sender, EventArgs e)
		{
			if (this.guna2Button5.Text != "bind" && this.guna2Button5.Text != "...")
			{
				Keys vKey = (Keys)this.Key.ConvertFromString(this.guna2Button5.Text.Replace("...", ""));
				if (MainForm.GetAsyncKeyState(vKey) < 0)
				{
					while (MainForm.GetAsyncKeyState(vKey) < 0)
					{
						Thread.Sleep(20);
					}
					if (this.guna2Button4.Text.Contains("enable"))
					{
						this.guna2Button4.Text = "disable";
						return;
					}
					if (this.guna2Button4.Text.Contains("disable"))
					{
						this.guna2Button4.Text = "enable";
					}
					return;
				}
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000782C File Offset: 0x00005A2C
		private void guna2Button5_KeyDown(object sender, KeyEventArgs e)
		{
			string text = e.KeyData.ToString();
			if (!text.Contains("Alt"))
			{
				if (MainForm.GetAsyncKeyState(Keys.Escape) < 0)
				{
					this.guna2Button5.Text = "bind";
				}
				else
				{
					this.guna2Button5.Text = text;
				}
			}
			new KeysConverter();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2Button5_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000788C File Offset: 0x00005A8C
		private void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
		{
			if (this.guna2ToggleSwitch4.Checked)
			{
				InputSimulator inputSimulator = new InputSimulator();
				VirtualKeyCode virtualKeyCode = (VirtualKeyCode)this.guna2ComboBox1.SelectedItem;
				if (this.guna2ToggleSwitch3.Checked)
				{
					inputSimulator.Keyboard.KeyPress(virtualKeyCode);
				}
				else
				{
					inputSimulator.Keyboard.KeyPress(virtualKeyCode);
				}
				this.timer6.Interval = (int)this.guna2NumericUpDown2.Value;
				this.timer6.Start();
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000790C File Offset: 0x00005B0C
		private void timer6_Tick(object sender, EventArgs e)
		{
			InputSimulator inputSimulator = new InputSimulator();
			VirtualKeyCode virtualKeyCode = (VirtualKeyCode)this.guna2ComboBox1.SelectedItem;
			inputSimulator.Keyboard.KeyPress(virtualKeyCode);
			this.timer6.Stop();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00007948 File Offset: 0x00005B48
		private void guna2Button6_Click(object sender, EventArgs e)
		{
			if (this.guna2Button6.Text.Contains("enable"))
			{
				this.guna2Button6.Text = "disable";
				return;
			}
			if (this.guna2Button6.Text.Contains("disable"))
			{
				this.guna2Button6.Text = "enable";
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000079A4 File Offset: 0x00005BA4
		private void guna2Button6_TextChanged(object sender, EventArgs e)
		{
			if (!this.guna2ToggleSwitch4.Checked)
			{
				this.guna2ToggleSwitch3.Checked = false;
				return;
			}
			if (this.guna2Button6.Text.Contains("disable"))
			{
				this.guna2ToggleSwitch3.Checked = true;
				return;
			}
			this.guna2ToggleSwitch3.Checked = false;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000079FB File Offset: 0x00005BFB
		private void guna2Button7_Click(object sender, EventArgs e)
		{
			this.guna2Button7.Text = "...";
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00007A10 File Offset: 0x00005C10
		private void timer7_Tick(object sender, EventArgs e)
		{
			if (this.guna2Button7.Text != "bind" && this.guna2Button7.Text != "...")
			{
				Keys vKey = (Keys)this.Key.ConvertFromString(this.guna2Button7.Text.Replace("...", ""));
				if (MainForm.GetAsyncKeyState(vKey) < 0)
				{
					if (this.guna2Button6.Text.Contains("disable"))
					{
						this.guna2Button6.Text = "enable";
					}
					else if (this.guna2Button6.Text.Contains("enable"))
					{
						this.guna2Button6.Text = "disable";
					}
					while (MainForm.GetAsyncKeyState(vKey) < 0)
					{
						Thread.Sleep(20);
					}
					return;
				}
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00007AE8 File Offset: 0x00005CE8
		private void guna2Button7_KeyDown(object sender, KeyEventArgs e)
		{
			string text = e.KeyData.ToString();
			if (!text.Contains("Alt"))
			{
				if (MainForm.GetAsyncKeyState(Keys.Escape) < 0)
				{
					this.guna2Button7.Text = "bind";
					return;
				}
				this.guna2Button7.Text = text;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00003FAF File Offset: 0x000021AF
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2ToggleSwitch4_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00007B40 File Offset: 0x00005D40
		private void guna2ToggleSwitch5_CheckedChanged(object sender, EventArgs e)
		{
			if (this.guna2ToggleSwitch4.Checked)
			{
				InputSimulator inputSimulator = new InputSimulator();
				VirtualKeyCode virtualKeyCode = (VirtualKeyCode)this.comboBoxKeys.SelectedItem;
				if (this.guna2ToggleSwitch5.Checked)
				{
					inputSimulator.Keyboard.KeyPress(virtualKeyCode);
				}
				else
				{
					inputSimulator.Keyboard.KeyPress(virtualKeyCode);
				}
				this.timer8.Interval = (int)this.guna2NumericUpDown1.Value;
				this.timer8.Start();
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00007BC0 File Offset: 0x00005DC0
		private void timer8_Tick(object sender, EventArgs e)
		{
			InputSimulator inputSimulator = new InputSimulator();
			VirtualKeyCode virtualKeyCode = (VirtualKeyCode)this.comboBoxKeys.SelectedItem;
			inputSimulator.Keyboard.KeyPress(virtualKeyCode);
			this.timer8.Stop();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00007BFC File Offset: 0x00005DFC
		private void guna2Button9_Click(object sender, EventArgs e)
		{
			if (this.guna2Button9.Text.Contains("enable"))
			{
				this.guna2Button9.Text = "disable";
				return;
			}
			if (this.guna2Button9.Text.Contains("disable"))
			{
				this.guna2Button9.Text = "enable";
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00007C58 File Offset: 0x00005E58
		private void guna2Button9_TextChanged(object sender, EventArgs e)
		{
			if (!this.guna2ToggleSwitch4.Checked)
			{
				this.guna2ToggleSwitch5.Checked = false;
				return;
			}
			if (this.guna2Button9.Text.Contains("disable"))
			{
				this.guna2ToggleSwitch5.Checked = true;
				return;
			}
			this.guna2ToggleSwitch5.Checked = false;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00007CAF File Offset: 0x00005EAF
		private void guna2Button10_Click(object sender, EventArgs e)
		{
			this.guna2Button10.Text = "...";
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00007CC4 File Offset: 0x00005EC4
		private void timer9_Tick(object sender, EventArgs e)
		{
			if (this.guna2Button10.Text != "bind" && this.guna2Button10.Text != "...")
			{
				Keys vKey = (Keys)this.Key.ConvertFromString(this.guna2Button10.Text.Replace("...", ""));
				if (MainForm.GetAsyncKeyState(vKey) < 0)
				{
					if (this.guna2Button9.Text.Contains("disable"))
					{
						this.guna2Button9.Text = "enable";
					}
					else if (this.guna2Button9.Text.Contains("enable"))
					{
						this.guna2Button9.Text = "disable";
					}
					while (MainForm.GetAsyncKeyState(vKey) < 0)
					{
						Thread.Sleep(20);
					}
					return;
				}
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00007D9C File Offset: 0x00005F9C
		private void guna2Button10_KeyDown(object sender, KeyEventArgs e)
		{
			string text = e.KeyData.ToString();
			if (!text.Contains("Alt"))
			{
				if (MainForm.GetAsyncKeyState(Keys.Escape) < 0)
				{
					this.guna2Button10.Text = "bind";
					return;
				}
				this.guna2Button10.Text = text;
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2Button8_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2Button2_KeyDown(object sender, KeyEventArgs e)
		{
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2TabControl1_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2Button2_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00003FAF File Offset: 0x000021AF
		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2Button3_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2Button7_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00003FAF File Offset: 0x000021AF
		private void toolTip1_Popup(object sender, PopupEventArgs e)
		{
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00003FAF File Offset: 0x000021AF
		private void label9_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00003FAF File Offset: 0x000021AF
		private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
		{
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00007DF4 File Offset: 0x00005FF4
		private void label9_MouseEnter(object sender, EventArgs e)
		{
			this.panel7.Location = new Point(this.label9.Location.X, this.label9.Location.Y + this.label9.Height);
			this.panel7.Visible = true;
			this.panel7.BringToFront();
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00003FAF File Offset: 0x000021AF
		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2Separator4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00007E5A File Offset: 0x0000605A
		private void guna2Button13_Click(object sender, EventArgs e)
		{
			this.panel13.BringToFront();
			this.SetButtonColor(this.guna2Button13);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00007E73 File Offset: 0x00006073
		private void guna2Button11_Click(object sender, EventArgs e)
		{
			this.panel3.BringToFront();
			this.SetButtonColor(this.guna2Button11);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00007E8C File Offset: 0x0000608C
		private void guna2Button12_Click(object sender, EventArgs e)
		{
			this.panel4.BringToFront();
			this.SetButtonColor(this.guna2Button12);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00003FAF File Offset: 0x000021AF
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00007EA5 File Offset: 0x000060A5
		private void guna2Button14_Click(object sender, EventArgs e)
		{
			this.panel5.BringToFront();
			this.SetButtonColor(this.guna2Button14);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00007EC0 File Offset: 0x000060C0
		private void SetButtonColor(Guna2Button clickedButton)
		{
			clickedButton.FillColor = Color.FromArgb(34, 32, 32);
			clickedButton.BorderColor = Color.FromArgb(34, 32, 32);
			foreach (Guna2Button guna2Button in new Guna2Button[]
			{
				this.guna2Button13,
				this.guna2Button11,
				this.guna2Button12,
				this.guna2Button14,
				this.guna2Button16,
				this.guna2Button17,
				this.guna2Button18
			})
			{
				if (guna2Button != clickedButton)
				{
					guna2Button.FillColor = Color.FromArgb(14, 14, 14);
					guna2Button.BorderColor = Color.FromArgb(14, 14, 14);
				}
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00007F70 File Offset: 0x00006170
		private void bindBtn_TextChanged(object sender, EventArgs e)
		{
			if (this.bindBtn.Text == "bind" || this.bindBtn.Text == "...")
			{
				this.bindBtn.FillColor = Color.FromArgb(68, 71, 75);
				return;
			}
			this.bindBtn.FillColor = Color.FromArgb(130, 26, 39);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2CustomCheckBox1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00007FDC File Offset: 0x000061DC
		private void bindbutton_TextChanged(object sender, EventArgs e)
		{
			if (this.bindbutton.Text == "bind" || this.bindbutton.Text == "...")
			{
				this.bindbutton.FillColor = Color.FromArgb(68, 71, 75);
				return;
			}
			this.bindbutton.FillColor = Color.FromArgb(130, 26, 39);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00008048 File Offset: 0x00006248
		private void bindBtn2_TextChanged(object sender, EventArgs e)
		{
			if (this.bindBtn2.Text == "bind" || this.bindBtn2.Text == "...")
			{
				this.bindBtn2.FillColor = Color.FromArgb(68, 71, 75);
				return;
			}
			this.bindBtn2.FillColor = Color.FromArgb(130, 26, 39);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000080B4 File Offset: 0x000062B4
		private void guna2Button5_TextChanged(object sender, EventArgs e)
		{
			if (this.guna2Button5.Text == "bind" || this.guna2Button5.Text == "...")
			{
				this.guna2Button5.FillColor = Color.FromArgb(68, 71, 75);
				return;
			}
			this.guna2Button5.FillColor = Color.FromArgb(130, 26, 39);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00008120 File Offset: 0x00006320
		private void guna2Button3_TextChanged(object sender, EventArgs e)
		{
			if (this.guna2Button3.Text == "bind" || this.guna2Button3.Text == "...")
			{
				this.guna2Button3.FillColor = Color.FromArgb(68, 71, 75);
				return;
			}
			this.guna2Button3.FillColor = Color.FromArgb(130, 26, 39);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000818C File Offset: 0x0000638C
		private void guna2Button7_TextChanged(object sender, EventArgs e)
		{
			if (this.guna2Button7.Text == "bind" || this.guna2Button7.Text == "...")
			{
				this.guna2Button7.FillColor = Color.FromArgb(68, 71, 75);
				return;
			}
			this.guna2Button7.FillColor = Color.FromArgb(130, 26, 39);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000081F8 File Offset: 0x000063F8
		private void guna2Button10_TextChanged(object sender, EventArgs e)
		{
			if (this.guna2Button10.Text == "bind" || this.guna2Button10.Text == "...")
			{
				this.guna2Button10.FillColor = Color.FromArgb(68, 71, 75);
				return;
			}
			this.guna2Button10.FillColor = Color.FromArgb(130, 26, 39);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2Button17_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2Button15_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00008263 File Offset: 0x00006463
		private void guna2Button16_Click(object sender, EventArgs e)
		{
			this.panel8.BringToFront();
			this.SetButtonColor(this.guna2Button16);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000827C File Offset: 0x0000647C
		private void guna2Button17_Click_1(object sender, EventArgs e)
		{
			this.panel9.BringToFront();
			this.SetButtonColor(this.guna2Button17);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00008295 File Offset: 0x00006495
		private void guna2Button18_Click(object sender, EventArgs e)
		{
			this.panel12.BringToFront();
			this.SetButtonColor(this.guna2Button18);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000082B0 File Offset: 0x000064B0
		private void label12_MouseEnter(object sender, EventArgs e)
		{
			this.panel10.Location = new Point(this.label12.Location.X, this.label12.Location.Y + this.label12.Height);
			this.panel10.Size = new Size(231, 35);
			this.panel10.Visible = true;
			this.panel10.BringToFront();
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000832D File Offset: 0x0000652D
		private void label12_MouseLeave(object sender, EventArgs e)
		{
			this.panel10.Visible = false;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00003FAF File Offset: 0x000021AF
		private void label12_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000833C File Offset: 0x0000653C
		private void panel10_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, this.panel10.ClientRectangle, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2ToggleSwitch4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000070BA File Offset: 0x000052BA
		private void guna2CustomCheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.guna2CustomCheckBox1.Checked)
			{
				base.ShowInTaskbar = false;
				return;
			}
			base.ShowInTaskbar = true;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000083A0 File Offset: 0x000065A0
		private void guna2Button19_Click(object sender, EventArgs e)
		{
			if (this.guna2Button19.Text.Contains("enable"))
			{
				this.guna2Button19.Text = "disable";
				return;
			}
			if (this.guna2Button19.Text.Contains("disable"))
			{
				this.guna2Button19.Text = "enable";
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000083FC File Offset: 0x000065FC
		private void guna2Button19_TextChanged(object sender, EventArgs e)
		{
			if (this.guna2Button19.Text.Contains("disable"))
			{
				base.WindowState = FormWindowState.Minimized;
				return;
			}
			base.WindowState = FormWindowState.Normal;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2ControlBox2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00008424 File Offset: 0x00006624
		private void guna2Button15_Click_1(object sender, EventArgs e)
		{
			this.guna2Button15.Text = "...";
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00008438 File Offset: 0x00006638
		private void timer10_Tick(object sender, EventArgs e)
		{
			if (this.guna2Button15.Text != "bind" && this.guna2Button15.Text != "...")
			{
				Keys vKey = (Keys)this.Key.ConvertFromString(this.guna2Button15.Text.Replace("...", ""));
				if (MainForm.GetAsyncKeyState(vKey) < 0)
				{
					while (MainForm.GetAsyncKeyState(vKey) < 0)
					{
						Thread.Sleep(20);
					}
					if (this.guna2Button19.Text.Contains("enable"))
					{
						this.guna2Button19.Text = "disable";
						return;
					}
					if (this.guna2Button19.Text.Contains("disable"))
					{
						this.guna2Button19.Text = "enable";
					}
					return;
				}
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00008510 File Offset: 0x00006710
		private void guna2Button15_KeyDown(object sender, KeyEventArgs e)
		{
			string text = e.KeyData.ToString();
			if (!text.Contains("Alt"))
			{
				if (MainForm.GetAsyncKeyState(Keys.Escape) < 0)
				{
					this.guna2Button15.Text = "bind";
				}
				else
				{
					this.guna2Button15.Text = text;
				}
			}
			new KeysConverter();
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00008570 File Offset: 0x00006770
		private void guna2Button15_TextChanged(object sender, EventArgs e)
		{
			if (this.guna2Button15.Text == "bind" || this.guna2Button15.Text == "...")
			{
				this.guna2Button15.FillColor = Color.FromArgb(68, 71, 75);
				return;
			}
			this.guna2Button15.FillColor = Color.FromArgb(130, 26, 39);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000085DC File Offset: 0x000067DC
		private void guna2Button20_Click(object sender, EventArgs e)
		{
			string text = this.txtConfigName.Text;
			string str = this.numericUpDown1.Value.ToString();
			string str2 = text + ":" + str;
			if (this.comboBoxConfigs.Items.Contains(text))
			{
				MessageBox.Show("Name already exists.", "Error", MessageBoxButtons.OK);
				return;
			}
			this.comboBoxConfigs.Items.Add(text);
			File.AppendAllText("userLMcnf.txt", str2 + Environment.NewLine);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00008664 File Offset: 0x00006864
		private void guna2Button21_Click(object sender, EventArgs e)
		{
			if (this.comboBoxConfigs.SelectedItem != null)
			{
				string str = this.comboBoxConfigs.SelectedItem.ToString();
				foreach (string text in File.ReadAllLines("userLMcnf.txt"))
				{
					if (text.StartsWith(str + ":"))
					{
						string[] array2 = text.Split(new char[]
						{
							':'
						});
						decimal value;
						if (array2.Length == 2 && decimal.TryParse(array2[1].Trim(), out value))
						{
							this.numericUpDown1.Value = value;
							return;
						}
					}
				}
				return;
			}
			MessageBox.Show("Please select an entry from the Box.");
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00008708 File Offset: 0x00006908
		private void guna2Button22_Click(object sender, EventArgs e)
		{
			if (this.comboBoxConfigs.SelectedItem != null)
			{
				string text = this.comboBoxConfigs.SelectedItem.ToString();
				this.comboBoxConfigs.Items.Remove(text);
				MessageBox.Show("Entry '" + text + "' deleted.");
				this.UpdateConfigFile();
				return;
			}
			MessageBox.Show("Please select an entry from the Box to delete it.");
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000876C File Offset: 0x0000696C
		private void LoadConfigurations()
		{
			if (File.Exists("userLMcnf.txt"))
			{
				string[] array = File.ReadAllLines("userLMcnf.txt");
				this.comboBoxConfigs.Items.Clear();
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string[] array3 = array2[i].Split(new char[]
					{
						':'
					});
					if (array3.Length != 0)
					{
						this.comboBoxConfigs.Items.Add(array3[0]);
					}
				}
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000087DC File Offset: 0x000069DC
		private void UpdateConfigFile()
		{
			List<string> list = new List<string>();
			foreach (object obj in this.comboBoxConfigs.Items)
			{
				string str = obj.ToString();
				foreach (string text in File.ReadAllLines("userLMcnf.txt"))
				{
					if (text.StartsWith(str + ":"))
					{
						list.Add(text);
					}
				}
			}
			File.WriteAllLines("userLMcnf.txt", list);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00008888 File Offset: 0x00006A88
		private void label9_MouseLeave(object sender, EventArgs e)
		{
			this.panel7.Visible = false;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00008898 File Offset: 0x00006A98
		private void panel7_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, this.panel7.ClientRectangle, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000088FC File Offset: 0x00006AFC
		private void guna2TextBox2_TextChanged(object sender, EventArgs e)
		{
			string searchText = this.guna2TextBox2.Text.ToLower();
			this.comboBoxConfigs.Items.Clear();
			foreach (string item in from line in File.ReadAllLines("userLMcnf.txt")
			select line.Split(new char[]
			{
				':'
			})[0] into name
			where name.ToLower().Contains(searchText)
			select name)
			{
				this.comboBoxConfigs.Items.Add(item);
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000089BC File Offset: 0x00006BBC
		private void comboBoxConfigs_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboBoxConfigs.BorderColor = Color.Black;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000089CE File Offset: 0x00006BCE
		private void guna2GradientButton1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000089CE File Offset: 0x00006BCE
		private void guna2GradientButton1_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000089CE File Offset: 0x00006BCE
		private void label10_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000089D6 File Offset: 0x00006BD6
		private void guna2Button23_Click(object sender, EventArgs e)
		{
			Application.Exit();
			Environment.Exit(0);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00003FAF File Offset: 0x000021AF
		private void comboBoxKeys_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00003FAF File Offset: 0x000021AF
		private void guna2NumericUpDown2_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000089E4 File Offset: 0x00006BE4
		private void panel14_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, this.panel14.ClientRectangle, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00008A48 File Offset: 0x00006C48
		private void label39_MouseEnter(object sender, EventArgs e)
		{
			this.panel14.Location = new Point(this.label39.Location.X, this.label39.Location.Y + this.label39.Height);
			this.panel14.Visible = true;
			this.panel14.BringToFront();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00008AAE File Offset: 0x00006CAE
		private void label39_MouseLeave(object sender, EventArgs e)
		{
			this.panel14.Visible = false;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00008ABC File Offset: 0x00006CBC
		private void panel15_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, this.panel15.ClientRectangle, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00008B20 File Offset: 0x00006D20
		private void label40_MouseEnter(object sender, EventArgs e)
		{
			this.panel15.Location = new Point(this.label40.Location.X, this.label40.Location.Y + this.label40.Height);
			this.panel15.Visible = true;
			this.panel15.BringToFront();
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00008B86 File Offset: 0x00006D86
		private void label40_MouseLeave(object sender, EventArgs e)
		{
			this.panel15.Visible = false;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00008B94 File Offset: 0x00006D94
		private void label42_MouseEnter(object sender, EventArgs e)
		{
			this.panel14.Location = new Point(this.label42.Location.X, this.label42.Location.Y + this.label42.Height);
			this.panel14.Visible = true;
			this.panel14.BringToFront();
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00008AAE File Offset: 0x00006CAE
		private void label42_MouseLeave(object sender, EventArgs e)
		{
			this.panel14.Visible = false;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00008BFC File Offset: 0x00006DFC
		private void panel16_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, this.panel16.ClientRectangle, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00008C60 File Offset: 0x00006E60
		private void label41_MouseEnter(object sender, EventArgs e)
		{
			this.panel16.Location = new Point(this.label41.Location.X, this.label41.Location.Y + this.label41.Height);
			this.panel16.Visible = true;
			this.panel16.BringToFront();
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00008CC6 File Offset: 0x00006EC6
		private void label41_MouseLeave(object sender, EventArgs e)
		{
			this.panel16.Visible = false;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00008CD4 File Offset: 0x00006ED4
		private void label43_MouseEnter(object sender, EventArgs e)
		{
			this.panel14.Location = new Point(this.label43.Location.X, this.label43.Location.Y + this.label43.Height);
			this.panel14.Visible = true;
			this.panel14.BringToFront();
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00008AAE File Offset: 0x00006CAE
		private void label43_MouseLeave(object sender, EventArgs e)
		{
			this.panel14.Visible = false;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00008D3C File Offset: 0x00006F3C
		private void panel17_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, this.panel17.ClientRectangle, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid, Color.FromArgb(130, 26, 39), 1, ButtonBorderStyle.Solid);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00008DA0 File Offset: 0x00006FA0
		private void label44_MouseEnter(object sender, EventArgs e)
		{
			this.panel17.Location = new Point(this.label44.Location.X, this.label44.Location.Y + this.label44.Height);
			this.panel17.Visible = true;
			this.panel17.BringToFront();
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00008E06 File Offset: 0x00007006
		private void label44_MouseLeave(object sender, EventArgs e)
		{
			this.panel17.Visible = false;
		}

		// Token: 0x04000061 RID: 97
		private const string configFilePath = "userLMcnf.txt";

		// Token: 0x04000062 RID: 98
		private Thread t;

		// Token: 0x04000063 RID: 99
		private int min;

		// Token: 0x04000064 RID: 100
		private int max;

		// Token: 0x04000065 RID: 101
		private IntPtr hWnd;

		// Token: 0x04000066 RID: 102
		private const uint MOUSEEVENTF_LEFTDOWN = 2U;

		// Token: 0x04000067 RID: 103
		private const uint MOUSEEVENTF_LEFTUP = 4U;

		// Token: 0x04000068 RID: 104
		private KeysConverter Key = new KeysConverter();

		// Token: 0x04000069 RID: 105
		private KeysConverter Key1 = new KeysConverter();

		// Token: 0x0400006A RID: 106
		private KeysConverter Key2 = new KeysConverter();

		// Token: 0x0400006B RID: 107
		private KeysConverter Key3 = new KeysConverter();

		// Token: 0x0400006C RID: 108
		private KeysConverter Key4 = new KeysConverter();

		// Token: 0x0400006D RID: 109
		private KeysConverter Key5 = new KeysConverter();

		// Token: 0x0400006E RID: 110
		private KeysConverter Key6 = new KeysConverter();

		// Token: 0x0400006F RID: 111
		private object panelcontainer;

		// Token: 0x04000070 RID: 112
		private KeysConverter Key7 = new KeysConverter();
	}
}
