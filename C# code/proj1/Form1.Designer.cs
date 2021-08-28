namespace proj1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.Easyybtn = new System.Windows.Forms.Button();
            this.Resumbtn = new System.Windows.Forms.Button();
            this.mediumbtn = new System.Windows.Forms.Button();
            this.Harddbtn = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.FinalBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.incorLbl = new System.Windows.Forms.Label();
            this.corLbl = new System.Windows.Forms.Label();
            this.corCount = new System.Windows.Forms.Label();
            this.incorCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Image = global::proj1.Properties.Resources.sudoku_puzzle_1;
            this.label1.Location = new System.Drawing.Point(689, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 5;
            // 
            // Easyybtn
            // 
            this.Easyybtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Easyybtn.BackgroundImage")));
            this.Easyybtn.FlatAppearance.BorderSize = 0;
            this.Easyybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Easyybtn.Font = new System.Drawing.Font("Kristen ITC", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Easyybtn.ForeColor = System.Drawing.Color.Silver;
            this.Easyybtn.Location = new System.Drawing.Point(245, 192);
            this.Easyybtn.Name = "Easyybtn";
            this.Easyybtn.Size = new System.Drawing.Size(432, 66);
            this.Easyybtn.TabIndex = 1;
            this.Easyybtn.Text = "Easy";
            this.Easyybtn.UseVisualStyleBackColor = true;
            this.Easyybtn.Click += new System.EventHandler(this.Easyybtn_Click);
            // 
            // Resumbtn
            // 
            this.Resumbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Resumbtn.BackgroundImage")));
            this.Resumbtn.FlatAppearance.BorderSize = 0;
            this.Resumbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Resumbtn.Font = new System.Drawing.Font("Kristen ITC", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resumbtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Resumbtn.Location = new System.Drawing.Point(245, 351);
            this.Resumbtn.Name = "Resumbtn";
            this.Resumbtn.Size = new System.Drawing.Size(432, 57);
            this.Resumbtn.TabIndex = 0;
            this.Resumbtn.Text = "Resume";
            this.Resumbtn.UseVisualStyleBackColor = true;
            this.Resumbtn.Click += new System.EventHandler(this.Resumbtn_Click);
            // 
            // mediumbtn
            // 
            this.mediumbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mediumbtn.BackgroundImage")));
            this.mediumbtn.FlatAppearance.BorderSize = 0;
            this.mediumbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mediumbtn.Font = new System.Drawing.Font("Kristen ITC", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediumbtn.ForeColor = System.Drawing.Color.Silver;
            this.mediumbtn.Location = new System.Drawing.Point(245, 247);
            this.mediumbtn.Name = "mediumbtn";
            this.mediumbtn.Size = new System.Drawing.Size(432, 58);
            this.mediumbtn.TabIndex = 2;
            this.mediumbtn.Text = "Medium";
            this.mediumbtn.UseVisualStyleBackColor = true;
            this.mediumbtn.Click += new System.EventHandler(this.mediumbtn_Click);
            // 
            // Harddbtn
            // 
            this.Harddbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Harddbtn.BackgroundImage")));
            this.Harddbtn.FlatAppearance.BorderSize = 0;
            this.Harddbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Harddbtn.Font = new System.Drawing.Font("Kristen ITC", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Harddbtn.ForeColor = System.Drawing.Color.Silver;
            this.Harddbtn.Location = new System.Drawing.Point(245, 302);
            this.Harddbtn.Name = "Harddbtn";
            this.Harddbtn.Size = new System.Drawing.Size(432, 50);
            this.Harddbtn.TabIndex = 3;
            this.Harddbtn.Text = "Hard";
            this.Harddbtn.UseVisualStyleBackColor = true;
            this.Harddbtn.Click += new System.EventHandler(this.Harddbtn_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorLabel.Font = new System.Drawing.Font("Goudy Stout", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorLabel.Location = new System.Drawing.Point(39, 454);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(141, 26);
            this.errorLabel.TabIndex = 6;
            this.errorLabel.Text = "label2";
            this.errorLabel.Visible = false;
            // 
            // FinalBtn
            // 
            this.FinalBtn.BackColor = System.Drawing.Color.Bisque;
            this.FinalBtn.Location = new System.Drawing.Point(877, 43);
            this.FinalBtn.Name = "FinalBtn";
            this.FinalBtn.Size = new System.Drawing.Size(120, 52);
            this.FinalBtn.TabIndex = 7;
            this.FinalBtn.Text = "Final board";
            this.FinalBtn.UseVisualStyleBackColor = false;
            this.FinalBtn.Click += new System.EventHandler(this.FinalBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.Bisque;
            this.SaveBtn.Location = new System.Drawing.Point(730, 43);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(123, 52);
            this.SaveBtn.TabIndex = 8;
            this.SaveBtn.Text = "Save and Exit";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // incorLbl
            // 
            this.incorLbl.BackColor = System.Drawing.Color.Transparent;
            this.incorLbl.Font = new System.Drawing.Font("Goudy Stout", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.incorLbl.Location = new System.Drawing.Point(725, 269);
            this.incorLbl.Name = "incorLbl";
            this.incorLbl.Size = new System.Drawing.Size(282, 57);
            this.incorLbl.TabIndex = 9;
            this.incorLbl.Text = "#Incorrect answer";
            this.incorLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.incorLbl.Visible = false;
            // 
            // corLbl
            // 
            this.corLbl.BackColor = System.Drawing.Color.Transparent;
            this.corLbl.Font = new System.Drawing.Font("Goudy Stout", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.corLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.corLbl.Location = new System.Drawing.Point(747, 113);
            this.corLbl.Name = "corLbl";
            this.corLbl.Size = new System.Drawing.Size(250, 58);
            this.corLbl.TabIndex = 10;
            this.corLbl.Text = "#correct answer";
            this.corLbl.Visible = false;
            // 
            // corCount
            // 
            this.corCount.BackColor = System.Drawing.Color.Transparent;
            this.corCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.corCount.Font = new System.Drawing.Font("Goudy Stout", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.corCount.ForeColor = System.Drawing.Color.DarkRed;
            this.corCount.Location = new System.Drawing.Point(758, 171);
            this.corCount.Name = "corCount";
            this.corCount.Size = new System.Drawing.Size(239, 57);
            this.corCount.TabIndex = 11;
            this.corCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.corCount.Visible = false;
            // 
            // incorCount
            // 
            this.incorCount.BackColor = System.Drawing.Color.Transparent;
            this.incorCount.Font = new System.Drawing.Font("Goudy Stout", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorCount.ForeColor = System.Drawing.Color.DarkRed;
            this.incorCount.Location = new System.Drawing.Point(758, 326);
            this.incorCount.Name = "incorCount";
            this.incorCount.Size = new System.Drawing.Size(249, 57);
            this.incorCount.TabIndex = 12;
            this.incorCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.incorCount.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1009, 569);
            this.Controls.Add(this.incorCount);
            this.Controls.Add(this.corCount);
            this.Controls.Add(this.corLbl);
            this.Controls.Add(this.incorLbl);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.FinalBtn);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.Harddbtn);
            this.Controls.Add(this.mediumbtn);
            this.Controls.Add(this.Resumbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Easyybtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Easyybtn;
        private System.Windows.Forms.Button Resumbtn;
        private System.Windows.Forms.Button mediumbtn;
        private System.Windows.Forms.Button Harddbtn;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button FinalBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label incorLbl;
        private System.Windows.Forms.Label corLbl;
        private System.Windows.Forms.Label corCount;
        private System.Windows.Forms.Label incorCount;
    }
}

