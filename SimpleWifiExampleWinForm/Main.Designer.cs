
namespace SimpleWifiExampleWinForm
{
    partial class MainWin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.lvAccessPoint = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStripView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WifiInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnEnableWlan = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnAirplane = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStripView.SuspendLayout();
            this.contextMenuStripNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvAccessPoint
            // 
            this.lvAccessPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAccessPoint.BackgroundImageTiled = true;
            this.lvAccessPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvAccessPoint.FullRowSelect = true;
            this.lvAccessPoint.GridLines = true;
            this.lvAccessPoint.HideSelection = false;
            this.lvAccessPoint.Location = new System.Drawing.Point(12, 59);
            this.lvAccessPoint.MultiSelect = false;
            this.lvAccessPoint.Name = "lvAccessPoint";
            this.lvAccessPoint.ShowGroups = false;
            this.lvAccessPoint.Size = new System.Drawing.Size(374, 598);
            this.lvAccessPoint.TabIndex = 0;
            this.lvAccessPoint.UseCompatibleStateImageBehavior = false;
            this.lvAccessPoint.View = System.Windows.Forms.View.List;
            this.lvAccessPoint.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvAccessPoint_ColumnClick);
            this.lvAccessPoint.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvAccessPoint_MouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 672);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(398, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl
            // 
            this.tssl.Name = "tssl";
            this.tssl.Size = new System.Drawing.Size(0, 15);
            // 
            // contextMenuStripView
            // 
            this.contextMenuStripView.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshToolStripMenuItem,
            this.WifiInfoToolStripMenuItem});
            this.contextMenuStripView.Name = "contextMenuStripView";
            this.contextMenuStripView.Size = new System.Drawing.Size(243, 97);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Image = global::SimpleWifiExampleWinForm.Properties.Resources.刷新;
            this.RefreshToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(242, 30);
            this.RefreshToolStripMenuItem.Text = "Rfresh";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // WifiInfoToolStripMenuItem
            // 
            this.WifiInfoToolStripMenuItem.Image = global::SimpleWifiExampleWinForm.Properties.Resources.密码;
            this.WifiInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.WifiInfoToolStripMenuItem.Name = "WifiInfoToolStripMenuItem";
            this.WifiInfoToolStripMenuItem.Size = new System.Drawing.Size(242, 30);
            this.WifiInfoToolStripMenuItem.Text = "WifiInfo";
            this.WifiInfoToolStripMenuItem.Click += new System.EventHandler(this.WifiInfoToolStripMenuItem_Click_1);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.contextMenuStripNotify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "SimpleWifi";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // contextMenuStripNotify
            // 
            this.contextMenuStripNotify.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.contextMenuStripNotify.Name = "contextMenuStripNotify";
            this.contextMenuStripNotify.Size = new System.Drawing.Size(112, 34);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Image = global::SimpleWifiExampleWinForm.Properties.Resources.退出;
            this.ExitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(111, 30);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // BtnEnableWlan
            // 
            this.BtnEnableWlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEnableWlan.Location = new System.Drawing.Point(267, 12);
            this.BtnEnableWlan.Name = "BtnEnableWlan";
            this.BtnEnableWlan.Size = new System.Drawing.Size(119, 41);
            this.BtnEnableWlan.TabIndex = 2;
            this.BtnEnableWlan.Text = "WLAN";
            this.BtnEnableWlan.UseVisualStyleBackColor = true;
            this.BtnEnableWlan.Click += new System.EventHandler(this.BtnEnableWlan_Click);
            // 
            // btnSet
            // 
            this.btnSet.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.Location = new System.Drawing.Point(142, 12);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(119, 41);
            this.btnSet.TabIndex = 2;
            this.btnSet.Text = "WlanSet";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.BtnSet_Click);
            // 
            // btnAirplane
            // 
            this.btnAirplane.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnAirplane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAirplane.Location = new System.Drawing.Point(12, 12);
            this.btnAirplane.Name = "btnAirplane";
            this.btnAirplane.Size = new System.Drawing.Size(119, 41);
            this.btnAirplane.TabIndex = 2;
            this.btnAirplane.Text = "Airplane";
            this.btnAirplane.UseVisualStyleBackColor = true;
            this.btnAirplane.Click += new System.EventHandler(this.BtnAirplane_Click);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 694);
            this.Controls.Add(this.btnAirplane);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.BtnEnableWlan);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvAccessPoint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(410, 750);
            this.Name = "MainWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimpleWifi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
            this.SizeChanged += new System.EventHandler(this.MainWin_SizeChanged);
            this.Resize += new System.EventHandler(this.MainWin_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStripView.ResumeLayout(false);
            this.contextMenuStripNotify.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvAccessPoint;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripView;
        private System.Windows.Forms.ToolStripMenuItem WifiInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotify;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.Button BtnEnableWlan;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnAirplane;
    }
}

