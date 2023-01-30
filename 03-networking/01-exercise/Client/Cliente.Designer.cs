namespace Client
{
    partial class Cliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.date = new System.Windows.Forms.Button();
            this.all = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.pwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.time = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(93, 27);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(75, 23);
            this.date.TabIndex = 2;
            this.date.Text = "Date";
            this.date.UseVisualStyleBackColor = true;
            this.date.Click += new System.EventHandler(this.date_Click);
            // 
            // all
            // 
            this.all.Location = new System.Drawing.Point(174, 27);
            this.all.Name = "all";
            this.all.Size = new System.Drawing.Size(75, 23);
            this.all.TabIndex = 3;
            this.all.Text = "All";
            this.all.UseVisualStyleBackColor = true;
            this.all.Click += new System.EventHandler(this.all_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(258, 27);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 4;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(179, 347);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(155, 20);
            this.pwd.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Password:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(12, 56);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.Size = new System.Drawing.Size(321, 282);
            this.txtResults.TabIndex = 7;
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(12, 27);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(75, 23);
            this.time.TabIndex = 8;
            this.time.Text = "Time";
            this.time.UseVisualStyleBackColor = true;
            this.time.Click += new System.EventHandler(this.time_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(346, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iPToolStripMenuItem,
            this.portToolStripMenuItem});
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.changeToolStripMenuItem.Text = "Change";
            // 
            // iPToolStripMenuItem
            // 
            this.iPToolStripMenuItem.Name = "iPToolStripMenuItem";
            this.iPToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iPToolStripMenuItem.Text = "IP";
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.portToolStripMenuItem.Text = "Port";
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(346, 376);
            this.Controls.Add(this.time);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.close);
            this.Controls.Add(this.all);
            this.Controls.Add(this.date);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Cliente";
            this.Text = "Client";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button date;
        private System.Windows.Forms.Button all;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Button time;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
    }
}

