namespace Internet_Explorer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开IntelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开备份位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开Systme32Ieframedll备份位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开SysWOW64备份位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开SysWOW64Ieframedll备份位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.异常功能选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重启资源管理器ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于此软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于作者ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Restore1 = new System.Windows.Forms.Button();
            this.Repair1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem,
            this.异常功能选项ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(704, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开IntelToolStripMenuItem,
            this.打开备份位置ToolStripMenuItem,
            this.打开Systme32Ieframedll备份位置ToolStripMenuItem,
            this.打开SysWOW64备份位置ToolStripMenuItem,
            this.打开SysWOW64Ieframedll备份位置ToolStripMenuItem});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.ShortcutKeyDisplayString = "M";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.菜单ToolStripMenuItem.Text = "菜单(&M)";
            // 
            // 打开IntelToolStripMenuItem
            // 
            this.打开IntelToolStripMenuItem.Name = "打开IntelToolStripMenuItem";
            this.打开IntelToolStripMenuItem.ShortcutKeyDisplayString = "Alt+M+I";
            this.打开IntelToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.打开IntelToolStripMenuItem.Text = "Internet属性(&I)";
            this.打开IntelToolStripMenuItem.Click += new System.EventHandler(this.打开IntelToolStripMenuItem_Click);
            // 
            // 打开备份位置ToolStripMenuItem
            // 
            this.打开备份位置ToolStripMenuItem.Name = "打开备份位置ToolStripMenuItem";
            this.打开备份位置ToolStripMenuItem.ShortcutKeyDisplayString = "Alt+M+E";
            this.打开备份位置ToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.打开备份位置ToolStripMenuItem.Text = "ieframe.dll 32备份位置(&E)";
            this.打开备份位置ToolStripMenuItem.Click += new System.EventHandler(this.打开备份位置ToolStripMenuItem_Click);
            // 
            // 打开Systme32Ieframedll备份位置ToolStripMenuItem
            // 
            this.打开Systme32Ieframedll备份位置ToolStripMenuItem.Name = "打开Systme32Ieframedll备份位置ToolStripMenuItem";
            this.打开Systme32Ieframedll备份位置ToolStripMenuItem.ShortcutKeyDisplayString = "Alt+M+R";
            this.打开Systme32Ieframedll备份位置ToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.打开Systme32Ieframedll备份位置ToolStripMenuItem.Text = "inetcpl.cpl 32备份位置(&R)";
            this.打开Systme32Ieframedll备份位置ToolStripMenuItem.Click += new System.EventHandler(this.打开Systme32Ieframedll备份位置ToolStripMenuItem_Click);
            // 
            // 打开SysWOW64备份位置ToolStripMenuItem
            // 
            this.打开SysWOW64备份位置ToolStripMenuItem.Name = "打开SysWOW64备份位置ToolStripMenuItem";
            this.打开SysWOW64备份位置ToolStripMenuItem.ShortcutKeyDisplayString = "Alt+M+D";
            this.打开SysWOW64备份位置ToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.打开SysWOW64备份位置ToolStripMenuItem.Text = "ieframe.dll 64备份位置(&D)";
            this.打开SysWOW64备份位置ToolStripMenuItem.Click += new System.EventHandler(this.打开SysWOW64备份位置ToolStripMenuItem_Click);
            // 
            // 打开SysWOW64Ieframedll备份位置ToolStripMenuItem
            // 
            this.打开SysWOW64Ieframedll备份位置ToolStripMenuItem.Name = "打开SysWOW64Ieframedll备份位置ToolStripMenuItem";
            this.打开SysWOW64Ieframedll备份位置ToolStripMenuItem.ShortcutKeyDisplayString = "Alt+M+F";
            this.打开SysWOW64Ieframedll备份位置ToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.打开SysWOW64Ieframedll备份位置ToolStripMenuItem.Text = "inetcpl.cpl 64备份位置(&F)";
            this.打开SysWOW64Ieframedll备份位置ToolStripMenuItem.Click += new System.EventHandler(this.打开SysWOW64Ieframedll备份位置ToolStripMenuItem_Click);
            // 
            // 异常功能选项ToolStripMenuItem
            // 
            this.异常功能选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重启资源管理器ToolStripMenuItem1});
            this.异常功能选项ToolStripMenuItem.Name = "异常功能选项ToolStripMenuItem";
            this.异常功能选项ToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F";
            this.异常功能选项ToolStripMenuItem.Size = new System.Drawing.Size(82, 21);
            this.异常功能选项ToolStripMenuItem.Text = "功能选项(&F)";
            // 
            // 重启资源管理器ToolStripMenuItem1
            // 
            this.重启资源管理器ToolStripMenuItem1.Name = "重启资源管理器ToolStripMenuItem1";
            this.重启资源管理器ToolStripMenuItem1.ShortcutKeyDisplayString = "Alt+T";
            this.重启资源管理器ToolStripMenuItem1.Size = new System.Drawing.Size(214, 22);
            this.重启资源管理器ToolStripMenuItem1.Text = "重启资源管理器(&T)";
            this.重启资源管理器ToolStripMenuItem1.Click += new System.EventHandler(this.重启资源管理器ToolStripMenuItem1_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于此软件ToolStripMenuItem,
            this.关于作者ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.ShortcutKeyDisplayString = "A";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.关于ToolStripMenuItem.Text = "关于(&A)";
            // 
            // 关于此软件ToolStripMenuItem
            // 
            this.关于此软件ToolStripMenuItem.Name = "关于此软件ToolStripMenuItem";
            this.关于此软件ToolStripMenuItem.ShortcutKeyDisplayString = "Alt+A+S";
            this.关于此软件ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.关于此软件ToolStripMenuItem.Text = "软件(&S)";
            this.关于此软件ToolStripMenuItem.Click += new System.EventHandler(this.关于此软件ToolStripMenuItem_Click);
            // 
            // 关于作者ToolStripMenuItem
            // 
            this.关于作者ToolStripMenuItem.Name = "关于作者ToolStripMenuItem";
            this.关于作者ToolStripMenuItem.ShortcutKeyDisplayString = "Alt+A+F";
            this.关于作者ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.关于作者ToolStripMenuItem.Text = "作者(&F)";
            this.关于作者ToolStripMenuItem.Click += new System.EventHandler(this.关于作者ToolStripMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(35, 176);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(213, 4);
            this.progressBar1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("黑体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(29, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 10);
            this.label4.TabIndex = 8;
            this.label4.Text = "运行状态...";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("黑体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(29, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 10);
            this.label5.TabIndex = 9;
            this.label5.Text = "当前备份状态...              ";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Internet_Explorer.Properties.Resources.IER;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(461, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 171);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Restore1
            // 
            this.Restore1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Restore1.Image = global::Internet_Explorer.Properties.Resources.BUI;
            this.Restore1.Location = new System.Drawing.Point(30, 138);
            this.Restore1.Name = "Restore1";
            this.Restore1.Size = new System.Drawing.Size(223, 47);
            this.Restore1.TabIndex = 1;
            this.Restore1.UseVisualStyleBackColor = true;
            this.Restore1.Visible = false;
            this.Restore1.Click += new System.EventHandler(this.Restore1_Click);
            // 
            // Repair1
            // 
            this.Repair1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Repair1.Image = global::Internet_Explorer.Properties.Resources.BUE;
            this.Repair1.Location = new System.Drawing.Point(30, 138);
            this.Repair1.Name = "Repair1";
            this.Repair1.Size = new System.Drawing.Size(223, 47);
            this.Repair1.TabIndex = 0;
            this.Repair1.UseVisualStyleBackColor = true;
            this.Repair1.Click += new System.EventHandler(this.Repair1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Internet_Explorer.Properties.Resources.BK;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(704, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 203);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Restore1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Repair1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(720, 242);
            this.MinimumSize = new System.Drawing.Size(720, 242);
            this.Name = "Form1";
            this.Text = "Internet Explorer For Windows11";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Repair1;
        private System.Windows.Forms.Button Restore1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开备份位置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开IntelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于此软件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于作者ToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem 打开SysWOW64备份位置ToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem 打开Systme32Ieframedll备份位置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开SysWOW64Ieframedll备份位置ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 异常功能选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重启资源管理器ToolStripMenuItem1;
        private System.Windows.Forms.Button button1;
    }
}

