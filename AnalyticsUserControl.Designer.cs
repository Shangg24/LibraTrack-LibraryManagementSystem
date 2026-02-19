namespace LibraTrack
{
    partial class AnalyticsUserControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewPrediction = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadPrediction = new System.Windows.Forms.Button();
            this.dataGridViewMostBorrowed = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrediction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMostBorrowed)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.dataGridViewPrediction);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnLoadPrediction);
            this.panel1.Controls.Add(this.dataGridViewMostBorrowed);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(1184, 665);
            this.panel1.TabIndex = 6;
            // 
            // dataGridViewPrediction
            // 
            this.dataGridViewPrediction.AllowUserToAddRows = false;
            this.dataGridViewPrediction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPrediction.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPrediction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPrediction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrediction.EnableHeadersVisualStyles = false;
            this.dataGridViewPrediction.Location = new System.Drawing.Point(625, 226);
            this.dataGridViewPrediction.Name = "dataGridViewPrediction";
            this.dataGridViewPrediction.ReadOnly = true;
            this.dataGridViewPrediction.RowHeadersVisible = false;
            this.dataGridViewPrediction.RowHeadersWidth = 51;
            this.dataGridViewPrediction.RowTemplate.Height = 24;
            this.dataGridViewPrediction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrediction.Size = new System.Drawing.Size(505, 386);
            this.dataGridViewPrediction.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(640, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Predicted High Demand (Next Month)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Most Borrowed Books (Last 3 Months)";
            // 
            // btnLoadPrediction
            // 
            this.btnLoadPrediction.Location = new System.Drawing.Point(32, 121);
            this.btnLoadPrediction.Name = "btnLoadPrediction";
            this.btnLoadPrediction.Size = new System.Drawing.Size(160, 40);
            this.btnLoadPrediction.TabIndex = 8;
            this.btnLoadPrediction.Text = "Load Analytics";
            this.btnLoadPrediction.UseVisualStyleBackColor = true;
            this.btnLoadPrediction.Click += new System.EventHandler(this.btnLoadPrediction_Click);
            // 
            // dataGridViewMostBorrowed
            // 
            this.dataGridViewMostBorrowed.AllowUserToAddRows = false;
            this.dataGridViewMostBorrowed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMostBorrowed.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMostBorrowed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewMostBorrowed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMostBorrowed.EnableHeadersVisualStyles = false;
            this.dataGridViewMostBorrowed.Location = new System.Drawing.Point(32, 226);
            this.dataGridViewMostBorrowed.Name = "dataGridViewMostBorrowed";
            this.dataGridViewMostBorrowed.ReadOnly = true;
            this.dataGridViewMostBorrowed.RowHeadersVisible = false;
            this.dataGridViewMostBorrowed.RowHeadersWidth = 51;
            this.dataGridViewMostBorrowed.RowTemplate.Height = 24;
            this.dataGridViewMostBorrowed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMostBorrowed.Size = new System.Drawing.Size(505, 386);
            this.dataGridViewMostBorrowed.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 34);
            this.label1.TabIndex = 6;
            this.label1.Text = "LibraTrack Analytics";
            // 
            // AnalyticsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AnalyticsUserControl";
            this.Size = new System.Drawing.Size(1184, 665);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrediction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMostBorrowed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewPrediction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadPrediction;
        private System.Windows.Forms.DataGridView dataGridViewMostBorrowed;
        private System.Windows.Forms.Label label1;
    }
}
