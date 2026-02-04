namespace LibraTrack
{
    partial class AdminPanel
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.logout_btn = new System.Windows.Forms.Button();
            this.GradeSection_btn = new System.Windows.Forms.Button();
            this.RegisteredAccounts_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.adminPanelAccounts1 = new LibraTrack.AdminPanelAccounts();
            this.adminPanelGradeSection1 = new LibraTrack.AdminPanelGradeSection();
            this.adminPanel_exitBtn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.adminPanel_minimizeBtn = new System.Windows.Forms.Label();
            this.adminPanel_maximizeBtn = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.logout_btn);
            this.panel2.Controls.Add(this.GradeSection_btn);
            this.panel2.Controls.Add(this.RegisteredAccounts_btn);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 625);
            this.panel2.TabIndex = 2;
            // 
            // logout_btn
            // 
            this.logout_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logout_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.logout_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.ForeColor = System.Drawing.Color.White;
            this.logout_btn.Image = global::LibraTrack.Properties.Resources.log_out;
            this.logout_btn.Location = new System.Drawing.Point(0, 580);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(266, 45);
            this.logout_btn.TabIndex = 9;
            this.logout_btn.UseVisualStyleBackColor = true;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // GradeSection_btn
            // 
            this.GradeSection_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.GradeSection_btn.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GradeSection_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.GradeSection_btn.Location = new System.Drawing.Point(44, 359);
            this.GradeSection_btn.Name = "GradeSection_btn";
            this.GradeSection_btn.Size = new System.Drawing.Size(175, 62);
            this.GradeSection_btn.TabIndex = 4;
            this.GradeSection_btn.Text = "Grade / Section";
            this.GradeSection_btn.UseVisualStyleBackColor = false;
            this.GradeSection_btn.Click += new System.EventHandler(this.GradeSection_btn_Click);
            // 
            // RegisteredAccounts_btn
            // 
            this.RegisteredAccounts_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RegisteredAccounts_btn.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisteredAccounts_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.RegisteredAccounts_btn.Location = new System.Drawing.Point(44, 278);
            this.RegisteredAccounts_btn.Name = "RegisteredAccounts_btn";
            this.RegisteredAccounts_btn.Size = new System.Drawing.Size(175, 62);
            this.RegisteredAccounts_btn.TabIndex = 3;
            this.RegisteredAccounts_btn.Text = "Registered Accounts";
            this.RegisteredAccounts_btn.UseVisualStyleBackColor = false;
            this.RegisteredAccounts_btn.Click += new System.EventHandler(this.RegisteredAccounts_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(62, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Welcome Admin!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibraTrack.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(80, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.adminPanelAccounts1);
            this.panel3.Controls.Add(this.adminPanelGradeSection1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(266, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(918, 625);
            this.panel3.TabIndex = 3;
            // 
            // adminPanelAccounts1
            // 
            this.adminPanelAccounts1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminPanelAccounts1.Location = new System.Drawing.Point(0, 0);
            this.adminPanelAccounts1.Name = "adminPanelAccounts1";
            this.adminPanelAccounts1.Size = new System.Drawing.Size(918, 625);
            this.adminPanelAccounts1.TabIndex = 1;
            // 
            // adminPanelGradeSection1
            // 
            this.adminPanelGradeSection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminPanelGradeSection1.Location = new System.Drawing.Point(0, 0);
            this.adminPanelGradeSection1.Name = "adminPanelGradeSection1";
            this.adminPanelGradeSection1.Size = new System.Drawing.Size(918, 625);
            this.adminPanelGradeSection1.TabIndex = 0;
            // 
            // adminPanel_exitBtn
            // 
            this.adminPanel_exitBtn.AutoSize = true;
            this.adminPanel_exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adminPanel_exitBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.adminPanel_exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminPanel_exitBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminPanel_exitBtn.ForeColor = System.Drawing.Color.White;
            this.adminPanel_exitBtn.Location = new System.Drawing.Point(1161, 0);
            this.adminPanel_exitBtn.Name = "adminPanel_exitBtn";
            this.adminPanel_exitBtn.Size = new System.Drawing.Size(21, 24);
            this.adminPanel_exitBtn.TabIndex = 1;
            this.adminPanel_exitBtn.Text = "X";
            this.adminPanel_exitBtn.Click += new System.EventHandler(this.adminPanel_exitBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(48, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "LibraTrack | Admin Panel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.adminPanel_minimizeBtn);
            this.panel1.Controls.Add(this.adminPanel_maximizeBtn);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.adminPanel_exitBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 40);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // adminPanel_minimizeBtn
            // 
            this.adminPanel_minimizeBtn.AutoSize = true;
            this.adminPanel_minimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adminPanel_minimizeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.adminPanel_minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminPanel_minimizeBtn.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminPanel_minimizeBtn.ForeColor = System.Drawing.Color.White;
            this.adminPanel_minimizeBtn.Location = new System.Drawing.Point(1107, 0);
            this.adminPanel_minimizeBtn.Name = "adminPanel_minimizeBtn";
            this.adminPanel_minimizeBtn.Size = new System.Drawing.Size(25, 27);
            this.adminPanel_minimizeBtn.TabIndex = 5;
            this.adminPanel_minimizeBtn.Text = "–";
            this.adminPanel_minimizeBtn.Click += new System.EventHandler(this.adminPanel_minimizeBtn_Click);
            // 
            // adminPanel_maximizeBtn
            // 
            this.adminPanel_maximizeBtn.AutoSize = true;
            this.adminPanel_maximizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adminPanel_maximizeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.adminPanel_maximizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminPanel_maximizeBtn.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminPanel_maximizeBtn.ForeColor = System.Drawing.Color.White;
            this.adminPanel_maximizeBtn.Location = new System.Drawing.Point(1132, 0);
            this.adminPanel_maximizeBtn.Name = "adminPanel_maximizeBtn";
            this.adminPanel_maximizeBtn.Size = new System.Drawing.Size(29, 27);
            this.adminPanel_maximizeBtn.TabIndex = 4;
            this.adminPanel_maximizeBtn.Text = "▢";
            this.adminPanel_maximizeBtn.Click += new System.EventHandler(this.adminPanel_maximizeBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LibraTrack.Properties.Resources.Logo;
            this.pictureBox2.Location = new System.Drawing.Point(8, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1184, 665);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPanel";
            this.Shown += new System.EventHandler(this.AdminPanel_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button GradeSection_btn;
        private System.Windows.Forms.Button RegisteredAccounts_btn;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Panel panel3;
        private AdminPanelAccounts adminPanelAccounts1;
        private AdminPanelGradeSection adminPanelGradeSection1;
        private System.Windows.Forms.Label adminPanel_exitBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label adminPanel_maximizeBtn;
        private System.Windows.Forms.Label adminPanel_minimizeBtn;
    }
}