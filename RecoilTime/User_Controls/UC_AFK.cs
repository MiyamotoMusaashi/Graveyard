using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RecoilTime.User_Controls
{
	// Token: 0x0200001A RID: 26
	public class UC_AFK : UserControl
	{
		// Token: 0x06000155 RID: 341 RVA: 0x000121F7 File Offset: 0x000103F7
		public UC_AFK()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00012205 File Offset: 0x00010405
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00012224 File Offset: 0x00010424
		private void InitializeComponent()
		{
			this.label1 = new Label();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new Point(198, 123);
			this.label1.Name = "label1";
			this.label1.Size = new Size(13, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "h";
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.label1);
			base.Location = new Point(12, 82);
			base.Margin = new Padding(0);
			base.Name = "UC_AFK";
			base.Size = new Size(362, 380);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000138 RID: 312
		private IContainer components;

		// Token: 0x04000139 RID: 313
		private Label label1;
	}
}
