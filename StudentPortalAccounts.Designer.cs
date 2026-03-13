namespace LibraTrack
{
    partial class StudentPortalAccounts
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewStudentsPortal = new System.Windows.Forms.DataGridView();
            this.spa_update_btn = new System.Windows.Forms.Button();
            this.spa_create_btn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.spa_search = new System.Windows.Forms.TextBox();
            this.spa_password = new System.Windows.Forms.TextBox();
            this.spa_userName = new System.Windows.Forms.TextBox();
            this.spa_contact = new System.Windows.Forms.TextBox();
            this.spa_email = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.spa_fullName = new System.Windows.Forms.TextBox();
            this.spa_studentID = new System.Windows.Forms.TextBox();
            this.spa_clear_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.spa_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentsPortal)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.spa_contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Students";
            // 
            // dataGridViewStudentsPortal
            // 
            this.dataGridViewStudentsPortal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStudentsPortal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudentsPortal.ContextMenuStrip = this.spa_contextMenu;
            this.dataGridViewStudentsPortal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStudentsPortal.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStudentsPortal.Name = "dataGridViewStudentsPortal";
            this.dataGridViewStudentsPortal.RowHeadersVisible = false;
            this.dataGridViewStudentsPortal.RowHeadersWidth = 51;
            this.dataGridViewStudentsPortal.RowTemplate.Height = 24;
            this.dataGridViewStudentsPortal.Size = new System.Drawing.Size(577, 526);
            this.dataGridViewStudentsPortal.TabIndex = 1;
            this.dataGridViewStudentsPortal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudentsPortal_CellClick);
            this.dataGridViewStudentsPortal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudentsPortal_CellContentClick);
            this.dataGridViewStudentsPortal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewStudentsPortal_MouseDown);
            // 
            // spa_update_btn
            // 
            this.spa_update_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spa_update_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.spa_update_btn.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spa_update_btn.ForeColor = System.Drawing.Color.White;
            this.spa_update_btn.Location = new System.Drawing.Point(204, 477);
            this.spa_update_btn.Name = "spa_update_btn";
            this.spa_update_btn.Size = new System.Drawing.Size(139, 38);
            this.spa_update_btn.TabIndex = 40;
            this.spa_update_btn.Text = "Update";
            this.spa_update_btn.UseVisualStyleBackColor = false;
            this.spa_update_btn.Click += new System.EventHandler(this.spa_update_btn_Click);
            // 
            // spa_create_btn
            // 
            this.spa_create_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spa_create_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.spa_create_btn.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spa_create_btn.ForeColor = System.Drawing.Color.White;
            this.spa_create_btn.Location = new System.Drawing.Point(25, 477);
            this.spa_create_btn.Name = "spa_create_btn";
            this.spa_create_btn.Size = new System.Drawing.Size(139, 38);
            this.spa_create_btn.TabIndex = 39;
            this.spa_create_btn.Text = "Create";
            this.spa_create_btn.UseVisualStyleBackColor = false;
            this.spa_create_btn.Click += new System.EventHandler(this.stp_create_btn_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(274, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 22);
            this.label9.TabIndex = 38;
            this.label9.Text = "Search:";
            // 
            // spa_search
            // 
            this.spa_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spa_search.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spa_search.Location = new System.Drawing.Point(348, 33);
            this.spa_search.Name = "spa_search";
            this.spa_search.Size = new System.Drawing.Size(214, 29);
            this.spa_search.TabIndex = 37;
            this.spa_search.TextChanged += new System.EventHandler(this.spa_search_TextChanged);
            // 
            // spa_password
            // 
            this.spa_password.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spa_password.Location = new System.Drawing.Point(129, 360);
            this.spa_password.Name = "spa_password";
            this.spa_password.Size = new System.Drawing.Size(214, 29);
            this.spa_password.TabIndex = 36;
            // 
            // spa_userName
            // 
            this.spa_userName.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spa_userName.Location = new System.Drawing.Point(129, 325);
            this.spa_userName.Name = "spa_userName";
            this.spa_userName.Size = new System.Drawing.Size(214, 29);
            this.spa_userName.TabIndex = 35;
            // 
            // spa_contact
            // 
            this.spa_contact.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spa_contact.Location = new System.Drawing.Point(129, 241);
            this.spa_contact.Name = "spa_contact";
            this.spa_contact.Size = new System.Drawing.Size(214, 29);
            this.spa_contact.TabIndex = 34;
            // 
            // spa_email
            // 
            this.spa_email.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spa_email.Location = new System.Drawing.Point(129, 206);
            this.spa_email.Name = "spa_email";
            this.spa_email.Size = new System.Drawing.Size(214, 29);
            this.spa_email.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 22);
            this.label8.TabIndex = 32;
            this.label8.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 22);
            this.label7.TabIndex = 31;
            this.label7.Text = "Username:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 22);
            this.label6.TabIndex = 30;
            this.label6.Text = "Contact:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(65, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 22);
            this.label5.TabIndex = 29;
            this.label5.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 22);
            this.label3.TabIndex = 27;
            this.label3.Text = "Full Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 22);
            this.label2.TabIndex = 26;
            this.label2.Text = "Student ID:";
            // 
            // spa_fullName
            // 
            this.spa_fullName.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spa_fullName.Location = new System.Drawing.Point(129, 170);
            this.spa_fullName.Name = "spa_fullName";
            this.spa_fullName.Size = new System.Drawing.Size(214, 29);
            this.spa_fullName.TabIndex = 24;
            // 
            // spa_studentID
            // 
            this.spa_studentID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spa_studentID.Location = new System.Drawing.Point(129, 135);
            this.spa_studentID.Name = "spa_studentID";
            this.spa_studentID.Size = new System.Drawing.Size(214, 29);
            this.spa_studentID.TabIndex = 23;
            // 
            // spa_clear_btn
            // 
            this.spa_clear_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spa_clear_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.spa_clear_btn.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spa_clear_btn.ForeColor = System.Drawing.Color.White;
            this.spa_clear_btn.Location = new System.Drawing.Point(111, 540);
            this.spa_clear_btn.Name = "spa_clear_btn";
            this.spa_clear_btn.Size = new System.Drawing.Size(139, 38);
            this.spa_clear_btn.TabIndex = 41;
            this.spa_clear_btn.Text = "Clear";
            this.spa_clear_btn.UseVisualStyleBackColor = false;
            this.spa_clear_btn.Click += new System.EventHandler(this.spa_clear_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.spa_clear_btn);
            this.panel1.Controls.Add(this.spa_update_btn);
            this.panel1.Controls.Add(this.spa_create_btn);
            this.panel1.Controls.Add(this.spa_password);
            this.panel1.Controls.Add(this.spa_userName);
            this.panel1.Controls.Add(this.spa_contact);
            this.panel1.Controls.Add(this.spa_email);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.spa_fullName);
            this.panel1.Controls.Add(this.spa_studentID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(367, 630);
            this.panel1.TabIndex = 43;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(367, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(597, 630);
            this.panel2.TabIndex = 44;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridViewStudentsPortal);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(10, 94);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(577, 526);
            this.panel5.TabIndex = 40;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.spa_search);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(577, 84);
            this.panel4.TabIndex = 39;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(964, 630);
            this.panel3.TabIndex = 45;
            // 
            // spa_contextMenu
            // 
            this.spa_contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.spa_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetPasswordToolStripMenuItem,
            this.deactivateAccountToolStripMenuItem});
            this.spa_contextMenu.Name = "spa_contextMenu";
            this.spa_contextMenu.Size = new System.Drawing.Size(208, 52);
            // 
            // resetPasswordToolStripMenuItem
            // 
            this.resetPasswordToolStripMenuItem.Name = "resetPasswordToolStripMenuItem";
            this.resetPasswordToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.resetPasswordToolStripMenuItem.Text = "Reset Password";
            this.resetPasswordToolStripMenuItem.Click += new System.EventHandler(this.resetPasswordToolStripMenuItem_Click);
            // 
            // deactivateAccountToolStripMenuItem
            // 
            this.deactivateAccountToolStripMenuItem.Name = "deactivateAccountToolStripMenuItem";
            this.deactivateAccountToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.deactivateAccountToolStripMenuItem.Text = "Deactivate Account";
            this.deactivateAccountToolStripMenuItem.Click += new System.EventHandler(this.deactivateAccountToolStripMenuItem_Click);
            // 
            // StudentPortalAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Name = "StudentPortalAccounts";
            this.Size = new System.Drawing.Size(964, 630);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentsPortal)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.spa_contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewStudentsPortal;
        private System.Windows.Forms.Button spa_update_btn;
        private System.Windows.Forms.Button spa_create_btn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox spa_search;
        private System.Windows.Forms.TextBox spa_password;
        private System.Windows.Forms.TextBox spa_userName;
        private System.Windows.Forms.TextBox spa_contact;
        private System.Windows.Forms.TextBox spa_email;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox spa_fullName;
        private System.Windows.Forms.TextBox spa_studentID;
        private System.Windows.Forms.Button spa_clear_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ContextMenuStrip spa_contextMenu;
        private System.Windows.Forms.ToolStripMenuItem resetPasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateAccountToolStripMenuItem;
    }
}
