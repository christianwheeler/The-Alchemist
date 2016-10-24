namespace The_Alchemist
{
    partial class frmStartGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStartGame));
            this.btnRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHighScores = new System.Windows.Forms.Button();
            this.lblDed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(237, 97);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(165, 44);
            this.btnRegister.TabIndex = 19;
            this.btnRegister.Text = "Begin Quest";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Viner Hand ITC", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 103);
            this.label1.TabIndex = 18;
            this.label1.Text = "The Alchemist";
            // 
            // btnHighScores
            // 
            this.btnHighScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighScores.Location = new System.Drawing.Point(237, 147);
            this.btnHighScores.Name = "btnHighScores";
            this.btnHighScores.Size = new System.Drawing.Size(165, 44);
            this.btnHighScores.TabIndex = 20;
            this.btnHighScores.Text = "View High Scores";
            this.btnHighScores.UseVisualStyleBackColor = true;
            this.btnHighScores.Click += new System.EventHandler(this.btnHighScores_Click);
            // 
            // lblDed
            // 
            this.lblDed.AutoSize = true;
            this.lblDed.BackColor = System.Drawing.Color.Transparent;
            this.lblDed.Font = new System.Drawing.Font("Viner Hand ITC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDed.Location = new System.Drawing.Point(252, 207);
            this.lblDed.Name = "lblDed";
            this.lblDed.Size = new System.Drawing.Size(130, 34);
            this.lblDed.TabIndex = 21;
            this.lblDed.Text = "You died!!!";
            this.lblDed.Visible = false;
            // 
            // frmStartGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::The_Alchemist.Properties.Resources.mainMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(590, 263);
            this.Controls.Add(this.lblDed);
            this.Controls.Add(this.btnHighScores);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStartGame";
            this.Text = "The Alchemist";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStartGame_FormClosing);
            this.Load += new System.EventHandler(this.frmStartGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHighScores;
        private System.Windows.Forms.Label lblDed;
    }
}