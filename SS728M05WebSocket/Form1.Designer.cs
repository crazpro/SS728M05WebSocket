namespace SS728M05WebSocket
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000019 RID: 25 RVA: 0x00002190 File Offset: 0x00000390
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000021B0 File Offset: 0x000003B0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::SS728M05WebSocket.Form1));
			this.notifyIcon1 = new global::System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.显示界面ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.退出程序ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = (global::System.Drawing.Icon)resources.GetObject("notifyIcon1.Icon");
			this.notifyIcon1.Text = "神思SS728M05型读卡器服务";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			this.contextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.显示界面ToolStripMenuItem,
				this.退出程序ToolStripMenuItem
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new global::System.Drawing.Size(125, 48);
			this.显示界面ToolStripMenuItem.Name = "显示界面ToolStripMenuItem";
			this.显示界面ToolStripMenuItem.Size = new global::System.Drawing.Size(124, 22);
			this.显示界面ToolStripMenuItem.Text = "显示界面";
			this.显示界面ToolStripMenuItem.Click += new global::System.EventHandler(this.显示界面ToolStripMenuItem_Click);
			this.退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem";
			this.退出程序ToolStripMenuItem.Size = new global::System.Drawing.Size(124, 22);
			this.退出程序ToolStripMenuItem.Text = "退出程序";
			this.退出程序ToolStripMenuItem.Click += new global::System.EventHandler(this.退出程序ToolStripMenuItem_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(284, 262);
            base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form1";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "神思SS728M05型读卡器服务";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			base.Load += new global::System.EventHandler(this.Form1_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000004 RID: 4
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.NotifyIcon notifyIcon1;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.ToolStripMenuItem 退出程序ToolStripMenuItem;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.ToolStripMenuItem 显示界面ToolStripMenuItem;
	}
}
