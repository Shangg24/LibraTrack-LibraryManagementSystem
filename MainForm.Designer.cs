namespace LibraTrack
{
    partial class MainForm
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
            this.returnBooks_btn = new System.Windows.Forms.Button();
            this.issueBooks_btn = new System.Windows.Forms.Button();
            this.addBooks_btn = new System.Windows.Forms.Button();
            this.dashboard_btn = new System.Windows.Forms.Button();
            this.greet_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.mainForm_exitBtn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainForm_minimizeBtn = new System.Windows.Forms.Label();
            this.mainForm_maximizeBtn = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.logout_btn);
            this.panel2.Controls.Add(this.returnBooks_btn);
            this.panel2.Controls.Add(this.issueBooks_btn);
            this.panel2.Controls.Add(this.addBooks_btn);
            this.panel2.Controls.Add(this.dashboard_btn);
            this.panel2.Controls.Add(this.greet_label);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 660);
            this.panel2.TabIndex = 1;
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
            this.logout_btn.Location = new System.Drawing.Point(0, 608);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(218, 50);
            this.logout_btn.TabIndex = 8;
            this.logout_btn.UseVisualStyleBackColor = true;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // returnBooks_btn
            // 
            this.returnBooks_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.returnBooks_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.returnBooks_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.returnBooks_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnBooks_btn.ForeColor = System.Drawing.Color.White;
            this.returnBooks_btn.Image = global::LibraTrack.Properties.Resources.issue_book;
            this.returnBooks_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.returnBooks_btn.Location = new System.Drawing.Point(9, 417);
            this.returnBooks_btn.Name = "returnBooks_btn";
            this.returnBooks_btn.Size = new System.Drawing.Size(200, 50);
            this.returnBooks_btn.TabIndex = 7;
            this.returnBooks_btn.Text = "RETURN BOOKS";
            this.returnBooks_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.returnBooks_btn.UseVisualStyleBackColor = false;
            this.returnBooks_btn.Click += new System.EventHandler(this.returnBooks_btn_Click);
            // 
            // issueBooks_btn
            // 
            this.issueBooks_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.issueBooks_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.issueBooks_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.issueBooks_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.issueBooks_btn.ForeColor = System.Drawing.Color.White;
            this.issueBooks_btn.Image = global::LibraTrack.Properties.Resources.return_book;
            this.issueBooks_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.issueBooks_btn.Location = new System.Drawing.Point(9, 352);
            this.issueBooks_btn.Name = "issueBooks_btn";
            this.issueBooks_btn.Size = new System.Drawing.Size(200, 50);
            this.issueBooks_btn.TabIndex = 6;
            this.issueBooks_btn.Text = "ISSUE BOOKS";
            this.issueBooks_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.issueBooks_btn.UseVisualStyleBackColor = false;
            this.issueBooks_btn.Click += new System.EventHandler(this.issueBooks_btn_Click);
            // 
            // addBooks_btn
            // 
            this.addBooks_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBooks_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.addBooks_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.addBooks_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBooks_btn.ForeColor = System.Drawing.Color.White;
            this.addBooks_btn.Image = global::LibraTrack.Properties.Resources.add_book;
            this.addBooks_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBooks_btn.Location = new System.Drawing.Point(9, 287);
            this.addBooks_btn.Name = "addBooks_btn";
            this.addBooks_btn.Size = new System.Drawing.Size(200, 50);
            this.addBooks_btn.TabIndex = 5;
            this.addBooks_btn.Text = "ADD BOOKS";
            this.addBooks_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.addBooks_btn.UseVisualStyleBackColor = false;
            this.addBooks_btn.Click += new System.EventHandler(this.addBooks_btn_Click);
            // 
            // dashboard_btn
            // 
            this.dashboard_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboard_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.dashboard_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.dashboard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboard_btn.ForeColor = System.Drawing.Color.White;
            this.dashboard_btn.Image = global::LibraTrack.Properties.Resources.Dash_board;
            this.dashboard_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dashboard_btn.Location = new System.Drawing.Point(9, 221);
            this.dashboard_btn.Name = "dashboard_btn";
            this.dashboard_btn.Size = new System.Drawing.Size(200, 50);
            this.dashboard_btn.TabIndex = 4;
            this.dashboard_btn.Text = "DASHBOARD";
            this.dashboard_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.dashboard_btn.UseVisualStyleBackColor = false;
            this.dashboard_btn.Click += new System.EventHandler(this.dashboard_btn_Click);
            // 
            // greet_label
            // 
            this.greet_label.AutoSize = true;
            this.greet_label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greet_label.ForeColor = System.Drawing.Color.White;
            this.greet_label.Location = new System.Drawing.Point(56, 130);
            this.greet_label.Name = "greet_label";
            this.greet_label.Size = new System.Drawing.Size(99, 24);
            this.greet_label.TabIndex = 3;
            this.greet_label.Text = "Welcome!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibraTrack.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(55, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // mainForm_exitBtn
            // 
            this.mainForm_exitBtn.AutoSize = true;
            this.mainForm_exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainForm_exitBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.mainForm_exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainForm_exitBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainForm_exitBtn.ForeColor = System.Drawing.Color.White;
            this.mainForm_exitBtn.Location = new System.Drawing.Point(1377, 0);
            this.mainForm_exitBtn.Name = "mainForm_exitBtn";
            this.mainForm_exitBtn.Size = new System.Drawing.Size(21, 24);
            this.mainForm_exitBtn.TabIndex = 1;
            this.mainForm_exitBtn.Text = "X";
            this.mainForm_exitBtn.Click += new System.EventHandler(this.mainForm_exitBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(48, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "LibraTrack | Main Form";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.mainForm_minimizeBtn);
            this.panel1.Controls.Add(this.mainForm_maximizeBtn);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.mainForm_exitBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 40);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // mainForm_minimizeBtn
            // 
            this.mainForm_minimizeBtn.AutoSize = true;
            this.mainForm_minimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainForm_minimizeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.mainForm_minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainForm_minimizeBtn.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainForm_minimizeBtn.ForeColor = System.Drawing.Color.White;
            this.mainForm_minimizeBtn.Location = new System.Drawing.Point(1323, 0);
            this.mainForm_minimizeBtn.Name = "mainForm_minimizeBtn";
            this.mainForm_minimizeBtn.Size = new System.Drawing.Size(25, 27);
            this.mainForm_minimizeBtn.TabIndex = 4;
            this.mainForm_minimizeBtn.Text = "–";
            this.mainForm_minimizeBtn.Click += new System.EventHandler(this.mainForm_minimizeBtn_Click);
            // 
            // mainForm_maximizeBtn
            // 
            this.mainForm_maximizeBtn.AutoSize = true;
            this.mainForm_maximizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainForm_maximizeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.mainForm_maximizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainForm_maximizeBtn.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainForm_maximizeBtn.ForeColor = System.Drawing.Color.White;
            this.mainForm_maximizeBtn.Location = new System.Drawing.Point(1348, 0);
            this.mainForm_maximizeBtn.Name = "mainForm_maximizeBtn";
            this.mainForm_maximizeBtn.Size = new System.Drawing.Size(29, 27);
            this.mainForm_maximizeBtn.TabIndex = 3;
            this.mainForm_maximizeBtn.Text = "▢";
            this.mainForm_maximizeBtn.Click += new System.EventHandler(this.mainForm_maximizeBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LibraTrack.Properties.Resources.Logo;
            this.pictureBox2.Location = new System.Drawing.Point(8, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(220, 40);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1180, 660);
            this.panelMain.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label greet_label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button returnBooks_btn;
        private System.Windows.Forms.Button issueBooks_btn;
        private System.Windows.Forms.Button addBooks_btn;
        private System.Windows.Forms.Button dashboard_btn;
        private System.Windows.Forms.Button logout_btn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label mainForm_exitBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label mainForm_maximizeBtn;
        private System.Windows.Forms.Label mainForm_minimizeBtn;
        private System.Windows.Forms.Panel panelMain;
    }
}