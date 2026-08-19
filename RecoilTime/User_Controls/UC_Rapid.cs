using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RecoilTime.User_Controls
{
	// Token: 0x0200001C RID: 28
	public class UC_Rapid : UserControl
	{
		// Token: 0x0600015B RID: 347 RVA: 0x00012415 File Offset: 0x00010615
		public UC_Rapid()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00012423 File Offset: 0x00010623
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00012444 File Offset: 0x00010644
		private void InitializeComponent()
		{
			this.label1 = new Label();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new Point(190, 109);
			this.label1.Name = "label1";
			this.label1.Size = new Size(30, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "rapid";
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.label1);
			base.Location = new Point(12, 82);
			base.Margin = new Padding(0);
			base.Name = "UC_Rapid";
			base.Size = new Size(362, 380);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400013C RID: 316
		private IContainer components;

		// Token: 0x0400013D RID: 317
		private Label label1;
	}
}
