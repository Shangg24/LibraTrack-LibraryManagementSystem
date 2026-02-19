namespace LibraTrack
{
    partial class BookRequests
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
            this.dataGridViewRequests = new System.Windows.Forms.DataGridView();
            this.approve_btn = new System.Windows.Forms.Button();
            this.reject_btn = new System.Windows.Forms.Button();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRequests
            // 
            this.dataGridViewRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequests.Location = new System.Drawing.Point(22, 138);
            this.dataGridViewRequests.MultiSelect = false;
            this.dataGridViewRequests.Name = "dataGridViewRequests";
            this.dataGridViewRequests.ReadOnly = true;
            this.dataGridViewRequests.RowHeadersWidth = 51;
            this.dataGridViewRequests.RowTemplate.Height = 24;
            this.dataGridViewRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRequests.Size = new System.Drawing.Size(1137, 350);
            this.dataGridViewRequests.TabIndex = 0;
            this.dataGridViewRequests.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewRequests_CellFormatting);
            // 
            // approve_btn
            // 
            this.approve_btn.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approve_btn.Location = new System.Drawing.Point(288, 558);
            this.approve_btn.Name = "approve_btn";
            this.approve_btn.Size = new System.Drawing.Size(166, 65);
            this.approve_btn.TabIndex = 1;
            this.approve_btn.Text = "Approve";
            this.approve_btn.UseVisualStyleBackColor = true;
            this.approve_btn.Click += new System.EventHandler(this.approve_btn_Click);
            // 
            // reject_btn
            // 
            this.reject_btn.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reject_btn.Location = new System.Drawing.Point(743, 558);
            this.reject_btn.Name = "reject_btn";
            this.reject_btn.Size = new System.Drawing.Size(166, 65);
            this.reject_btn.TabIndex = 2;
            this.reject_btn.Text = "Reject";
            this.reject_btn.UseVisualStyleBackColor = true;
            this.reject_btn.Click += new System.EventHandler(this.reject_btn_Click);
            // 
            // refresh_btn
            // 
            this.refresh_btn.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh_btn.Location = new System.Drawing.Point(993, 67);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(166, 52);
            this.refresh_btn.TabIndex = 3;
            this.refresh_btn.Text = "Refresh";
            this.refresh_btn.UseVisualStyleBackColor = true;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "Requests";
            // 
            // BookRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refresh_btn);
            this.Controls.Add(this.reject_btn);
            this.Controls.Add(this.approve_btn);
            this.Controls.Add(this.dataGridViewRequests);
            this.Name = "BookRequests";
            this.Size = new System.Drawing.Size(1184, 665);
            this.Load += new System.EventHandler(this.BookRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRequests;
        private System.Windows.Forms.Button approve_btn;
        private System.Windows.Forms.Button reject_btn;
        private System.Windows.Forms.Button refresh_btn;
        private System.Windows.Forms.Label label1;
    }
}
