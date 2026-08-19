using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RecoilTime.User_Controls
{
	// Token: 0x0200001B RID: 27
	public class UC_Home : UserControl
	{
		// Token: 0x06000158 RID: 344 RVA: 0x00012305 File Offset: 0x00010505
		public UC_Home()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00012313 File Offset: 0x00010513
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00012334 File Offset: 0x00010534
		private void InitializeComponent()
		{
			this.label1 = new Label();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new Point(161, 98);
			this.label1.Name = "label1";
			this.label1.Size = new Size(32, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "recoil";
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.label1);
			base.Location = new Point(12, 82);
			base.Margin = new Padding(0);
			base.Name = "UC_Home";
			base.Size = new Size(362, 380);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400013A RID: 314
		private IContainer components;

		// Token: 0x0400013B RID: 315
		private Label label1;
	}
}
