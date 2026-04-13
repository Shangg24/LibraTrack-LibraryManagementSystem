namespace LibraTrack
{
    partial class ChangePasswordForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.resetPass_Exit = new System.Windows.Forms.Label();
            this.resetPass_showPassNew = new System.Windows.Forms.CheckBox();
            this.resetPass_submitBtn = new System.Windows.Forms.Button();
            this.resetPass_confirmPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resetPass_newPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.resetPass_Exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 35);
            this.panel1.TabIndex = 11;
            // 
            // resetPass_Exit
            // 
            this.resetPass_Exit.AutoSize = true;
            this.resetPass_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetPass_Exit.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPass_Exit.ForeColor = System.Drawing.Color.White;
            this.resetPass_Exit.Location = new System.Drawing.Point(397, 7);
            this.resetPass_Exit.Name = "resetPass_Exit";
            this.resetPass_Exit.Size = new System.Drawing.Size(19, 22);
            this.resetPass_Exit.TabIndex = 0;
            this.resetPass_Exit.Text = "X";
            this.resetPass_Exit.Click += new System.EventHandler(this.resetPass_Exit_Click);
            // 
            // resetPass_showPassNew
            // 
            this.resetPass_showPassNew.AutoSize = true;
            this.resetPass_showPassNew.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPass_showPassNew.Location = new System.Drawing.Point(245, 388);
            this.resetPass_showPassNew.Name = "resetPass_showPassNew";
            this.resetPass_showPassNew.Size = new System.Drawing.Size(120, 20);
            this.resetPass_showPassNew.TabIndex = 21;
            this.resetPass_showPassNew.Text = "Show Password";
            this.resetPass_showPassNew.UseVisualStyleBackColor = true;
            this.resetPass_showPassNew.CheckedChanged += new System.EventHandler(this.resetPass_showPassNew_CheckedChanged);
            this.resetPass_showPassNew.Click += new System.EventHandler(this.resetPass_showPassNew_CheckedChanged);
            // 
            // resetPass_submitBtn
            // 
            this.resetPass_submitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.resetPass_submitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetPass_submitBtn.FlatAppearance.BorderSize = 0;
            this.resetPass_submitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.resetPass_submitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.resetPass_submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetPass_submitBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPass_submitBtn.ForeColor = System.Drawing.Color.White;
            this.resetPass_submitBtn.Location = new System.Drawing.Point(113, 458);
            this.resetPass_submitBtn.Name = "resetPass_submitBtn";
            this.resetPass_submitBtn.Size = new System.Drawing.Size(199, 40);
            this.resetPass_submitBtn.TabIndex = 18;
            this.resetPass_submitBtn.Text = "SUBMIT";
            this.resetPass_submitBtn.UseVisualStyleBackColor = false;
            this.resetPass_submitBtn.Click += new System.EventHandler(this.resetPass_submitBtn_Click);
            // 
            // resetPass_confirmPass
            // 
            this.resetPass_confirmPass.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPass_confirmPass.Location = new System.Drawing.Point(73, 352);
            this.resetPass_confirmPass.Multiline = true;
            this.resetPass_confirmPass.Name = "resetPass_confirmPass";
            this.resetPass_confirmPass.PasswordChar = '*';
            this.resetPass_confirmPass.Size = new System.Drawing.Size(292, 30);
            this.resetPass_confirmPass.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "Confirm Password:";
            // 
            // resetPass_newPass
            // 
            this.resetPass_newPass.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPass_newPass.Location = new System.Drawing.Point(73, 283);
            this.resetPass_newPass.Multiline = true;
            this.resetPass_newPass.Name = "resetPass_newPass";
            this.resetPass_newPass.PasswordChar = '*';
            this.resetPass_newPass.Size = new System.Drawing.Size(292, 30);
            this.resetPass_newPass.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "New Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 34);
            this.label2.TabIndex = 13;
            this.label2.Text = "Reset Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibraTrack.Properties.Resources.LibraTrackLogo;
            this.pictureBox1.Location = new System.Drawing.Point(167, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 525);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resetPass_showPassNew);
            this.Controls.Add(this.resetPass_submitBtn);
            this.Controls.Add(this.resetPass_confirmPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resetPass_newPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label resetPass_Exit;
        private System.Windows.Forms.Button resetPass_submitBtn;
        private System.Windows.Forms.TextBox resetPass_confirmPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox resetPass_newPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox resetPass_showPassNew;
    }
}