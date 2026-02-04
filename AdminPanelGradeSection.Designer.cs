namespace LibraTrack
{
    partial class AdminPanelGradeSection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gradeSection_updateBtn = new System.Windows.Forms.Button();
            this.gradeSection_addBtn = new System.Windows.Forms.Button();
            this.gradeSection_section = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gradeSection_gradeLevel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewGradeSection = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gradeSection_deleteBtn = new System.Windows.Forms.Button();
            this.gradeSection_department = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gradeSection_clearBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.adminPanelGradeSection_mainPanel = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGradeSection)).BeginInit();
            this.panel1.SuspendLayout();
            this.adminPanelGradeSection_mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradeSection_updateBtn
            // 
            this.gradeSection_updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradeSection_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradeSection_updateBtn.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradeSection_updateBtn.ForeColor = System.Drawing.Color.White;
            this.gradeSection_updateBtn.Location = new System.Drawing.Point(192, 456);
            this.gradeSection_updateBtn.Name = "gradeSection_updateBtn";
            this.gradeSection_updateBtn.Size = new System.Drawing.Size(134, 40);
            this.gradeSection_updateBtn.TabIndex = 4;
            this.gradeSection_updateBtn.Text = "Update";
            this.gradeSection_updateBtn.UseVisualStyleBackColor = false;
            this.gradeSection_updateBtn.Click += new System.EventHandler(this.gradeSection_updateBtn_Click);
            // 
            // gradeSection_addBtn
            // 
            this.gradeSection_addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradeSection_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradeSection_addBtn.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradeSection_addBtn.ForeColor = System.Drawing.Color.White;
            this.gradeSection_addBtn.Location = new System.Drawing.Point(42, 456);
            this.gradeSection_addBtn.Name = "gradeSection_addBtn";
            this.gradeSection_addBtn.Size = new System.Drawing.Size(134, 40);
            this.gradeSection_addBtn.TabIndex = 3;
            this.gradeSection_addBtn.Text = "Add";
            this.gradeSection_addBtn.UseVisualStyleBackColor = false;
            this.gradeSection_addBtn.Click += new System.EventHandler(this.gradeSection_addBtn_Click);
            // 
            // gradeSection_section
            // 
            this.gradeSection_section.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradeSection_section.Location = new System.Drawing.Point(157, 282);
            this.gradeSection_section.Name = "gradeSection_section";
            this.gradeSection_section.Size = new System.Drawing.Size(146, 28);
            this.gradeSection_section.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(92, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Section:";
            // 
            // gradeSection_gradeLevel
            // 
            this.gradeSection_gradeLevel.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradeSection_gradeLevel.Location = new System.Drawing.Point(157, 241);
            this.gradeSection_gradeLevel.Name = "gradeSection_gradeLevel";
            this.gradeSection_gradeLevel.Size = new System.Drawing.Size(146, 28);
            this.gradeSection_gradeLevel.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Grade Level:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dataGridViewGradeSection);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(381, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(45);
            this.panel3.Size = new System.Drawing.Size(583, 630);
            this.panel3.TabIndex = 15;
            // 
            // dataGridViewGradeSection
            // 
            this.dataGridViewGradeSection.AllowUserToAddRows = false;
            this.dataGridViewGradeSection.AllowUserToDeleteRows = false;
            this.dataGridViewGradeSection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGradeSection.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewGradeSection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewGradeSection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewGradeSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGradeSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGradeSection.EnableHeadersVisualStyles = false;
            this.dataGridViewGradeSection.Location = new System.Drawing.Point(45, 45);
            this.dataGridViewGradeSection.Name = "dataGridViewGradeSection";
            this.dataGridViewGradeSection.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewGradeSection.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewGradeSection.RowHeadersVisible = false;
            this.dataGridViewGradeSection.RowHeadersWidth = 51;
            this.dataGridViewGradeSection.RowTemplate.Height = 24;
            this.dataGridViewGradeSection.Size = new System.Drawing.Size(491, 538);
            this.dataGridViewGradeSection.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.gradeSection_deleteBtn);
            this.panel1.Controls.Add(this.gradeSection_department);
            this.panel1.Controls.Add(this.gradeSection_gradeLevel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.gradeSection_clearBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.gradeSection_section);
            this.panel1.Controls.Add(this.gradeSection_updateBtn);
            this.panel1.Controls.Add(this.gradeSection_addBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 630);
            this.panel1.TabIndex = 19;
            // 
            // gradeSection_deleteBtn
            // 
            this.gradeSection_deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradeSection_deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradeSection_deleteBtn.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradeSection_deleteBtn.ForeColor = System.Drawing.Color.White;
            this.gradeSection_deleteBtn.Location = new System.Drawing.Point(42, 515);
            this.gradeSection_deleteBtn.Name = "gradeSection_deleteBtn";
            this.gradeSection_deleteBtn.Size = new System.Drawing.Size(134, 40);
            this.gradeSection_deleteBtn.TabIndex = 19;
            this.gradeSection_deleteBtn.Text = "Delete";
            this.gradeSection_deleteBtn.UseVisualStyleBackColor = false;
            this.gradeSection_deleteBtn.Click += new System.EventHandler(this.gradeSection_deleteBtn_Click);
            // 
            // gradeSection_department
            // 
            this.gradeSection_department.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradeSection_department.FormattingEnabled = true;
            this.gradeSection_department.Location = new System.Drawing.Point(157, 198);
            this.gradeSection_department.Name = "gradeSection_department";
            this.gradeSection_department.Size = new System.Drawing.Size(146, 29);
            this.gradeSection_department.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Department:";
            // 
            // gradeSection_clearBtn
            // 
            this.gradeSection_clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradeSection_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradeSection_clearBtn.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradeSection_clearBtn.ForeColor = System.Drawing.Color.White;
            this.gradeSection_clearBtn.Location = new System.Drawing.Point(192, 515);
            this.gradeSection_clearBtn.Name = "gradeSection_clearBtn";
            this.gradeSection_clearBtn.Size = new System.Drawing.Size(134, 40);
            this.gradeSection_clearBtn.TabIndex = 16;
            this.gradeSection_clearBtn.Text = "Clear";
            this.gradeSection_clearBtn.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Grade | Section";
            // 
            // adminPanelGradeSection_mainPanel
            // 
            this.adminPanelGradeSection_mainPanel.Controls.Add(this.panel3);
            this.adminPanelGradeSection_mainPanel.Controls.Add(this.panel1);
            this.adminPanelGradeSection_mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminPanelGradeSection_mainPanel.Location = new System.Drawing.Point(0, 0);
            this.adminPanelGradeSection_mainPanel.Name = "adminPanelGradeSection_mainPanel";
            this.adminPanelGradeSection_mainPanel.Size = new System.Drawing.Size(964, 630);
            this.adminPanelGradeSection_mainPanel.TabIndex = 20;
            // 
            // AdminPanelGradeSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.adminPanelGradeSection_mainPanel);
            this.Name = "AdminPanelGradeSection";
            this.Size = new System.Drawing.Size(964, 630);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGradeSection)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.adminPanelGradeSection_mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button gradeSection_updateBtn;
        private System.Windows.Forms.Button gradeSection_addBtn;
        private System.Windows.Forms.TextBox gradeSection_section;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox gradeSection_gradeLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridViewGradeSection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button gradeSection_clearBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox gradeSection_department;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button gradeSection_deleteBtn;
        private System.Windows.Forms.Panel adminPanelGradeSection_mainPanel;
    }
}
