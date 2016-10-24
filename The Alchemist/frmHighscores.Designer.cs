namespace The_Alchemist
{
    partial class frmHighscores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHighscores));
            this.dgvHighscores = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSortName = new System.Windows.Forms.Button();
            this.btnSortDate = new System.Windows.Forms.Button();
            this.btnSortHighestLevel = new System.Windows.Forms.Button();
            this.btnMyScores = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighscores)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHighscores
            // 
            this.dgvHighscores.AllowUserToAddRows = false;
            this.dgvHighscores.AllowUserToDeleteRows = false;
            this.dgvHighscores.AllowUserToResizeRows = false;
            this.dgvHighscores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHighscores.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvHighscores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHighscores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHighscores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHighscores.ColumnHeadersHeight = 50;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHighscores.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHighscores.EnableHeadersVisualStyles = false;
            this.dgvHighscores.Location = new System.Drawing.Point(12, 115);
            this.dgvHighscores.Name = "dgvHighscores";
            this.dgvHighscores.ReadOnly = true;
            this.dgvHighscores.RowHeadersVisible = false;
            this.dgvHighscores.RowTemplate.Height = 30;
            this.dgvHighscores.ShowEditingIcon = false;
            this.dgvHighscores.Size = new System.Drawing.Size(643, 449);
            this.dgvHighscores.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnMyScores);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSortName);
            this.panel1.Controls.Add(this.btnSortDate);
            this.panel1.Controls.Add(this.btnSortHighestLevel);
            this.panel1.Controls.Add(this.dgvHighscores);
            this.panel1.Location = new System.Drawing.Point(39, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 578);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Viner Hand ITC", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(643, 78);
            this.label3.TabIndex = 7;
            this.label3.Text = "High Scores";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(680, 426);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(258, 52);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "High Scores";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(759, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Report:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(759, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sorty By:";
            // 
            // btnSortName
            // 
            this.btnSortName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSortName.Location = new System.Drawing.Point(680, 258);
            this.btnSortName.Name = "btnSortName";
            this.btnSortName.Size = new System.Drawing.Size(258, 52);
            this.btnSortName.TabIndex = 3;
            this.btnSortName.Text = "Name ▼";
            this.btnSortName.UseVisualStyleBackColor = true;
            this.btnSortName.Click += new System.EventHandler(this.btnSortName_Click);
            // 
            // btnSortDate
            // 
            this.btnSortDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSortDate.Location = new System.Drawing.Point(680, 187);
            this.btnSortDate.Name = "btnSortDate";
            this.btnSortDate.Size = new System.Drawing.Size(258, 52);
            this.btnSortDate.TabIndex = 2;
            this.btnSortDate.Text = "Date ▼";
            this.btnSortDate.UseVisualStyleBackColor = true;
            this.btnSortDate.Click += new System.EventHandler(this.btnSortDate_Click);
            // 
            // btnSortHighestLevel
            // 
            this.btnSortHighestLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSortHighestLevel.Location = new System.Drawing.Point(680, 115);
            this.btnSortHighestLevel.Name = "btnSortHighestLevel";
            this.btnSortHighestLevel.Size = new System.Drawing.Size(258, 52);
            this.btnSortHighestLevel.TabIndex = 1;
            this.btnSortHighestLevel.Text = "Highest Level ▲";
            this.btnSortHighestLevel.UseVisualStyleBackColor = true;
            this.btnSortHighestLevel.Click += new System.EventHandler(this.btnSortHighestLevel_Click);
            // 
            // btnMyScores
            // 
            this.btnMyScores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMyScores.Location = new System.Drawing.Point(680, 496);
            this.btnMyScores.Name = "btnMyScores";
            this.btnMyScores.Size = new System.Drawing.Size(258, 52);
            this.btnMyScores.TabIndex = 8;
            this.btnMyScores.Text = "My Scores";
            this.btnMyScores.UseVisualStyleBackColor = true;
            this.btnMyScores.Click += new System.EventHandler(this.btnMyScores_Click);
            // 
            // frmHighscores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::The_Alchemist.Properties.Resources.mainMenu;
            this.ClientSize = new System.Drawing.Size(1034, 651);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1050, 690);
            this.Name = "frmHighscores";
            this.Text = "High Scores";
            this.Load += new System.EventHandler(this.frmHighscores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighscores)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHighscores;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSortName;
        private System.Windows.Forms.Button btnSortDate;
        private System.Windows.Forms.Button btnSortHighestLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMyScores;
    }
}