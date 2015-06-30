namespace project_soft.PL
{
    partial class Transcript
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
            this.combYear = new System.Windows.Forms.ComboBox();
            this.comYear = new System.Windows.Forms.ComboBox();
            this.combD = new System.Windows.Forms.ComboBox();
            this.combmon = new System.Windows.Forms.ComboBox();
            this.combday = new System.Windows.Forms.ComboBox();
            this.combMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // combYear
            // 
            this.combYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combYear.FormattingEnabled = true;
            this.combYear.Location = new System.Drawing.Point(265, 83);
            this.combYear.Name = "combYear";
            this.combYear.Size = new System.Drawing.Size(64, 21);
            this.combYear.TabIndex = 0;
            this.combYear.SelectedIndexChanged += new System.EventHandler(this.combYear_SelectedIndexChanged);
            // 
            // comYear
            // 
            this.comYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comYear.FormattingEnabled = true;
            this.comYear.Location = new System.Drawing.Point(265, 40);
            this.comYear.Name = "comYear";
            this.comYear.Size = new System.Drawing.Size(64, 21);
            this.comYear.TabIndex = 1;
            this.comYear.SelectedIndexChanged += new System.EventHandler(this.comYear_SelectedIndexChanged);
            // 
            // combD
            // 
            this.combD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combD.FormattingEnabled = true;
            this.combD.Location = new System.Drawing.Point(82, 83);
            this.combD.Name = "combD";
            this.combD.Size = new System.Drawing.Size(64, 21);
            this.combD.TabIndex = 3;
            this.combD.SelectedIndexChanged += new System.EventHandler(this.combD_SelectedIndexChanged);
            // 
            // combmon
            // 
            this.combmon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combmon.FormattingEnabled = true;
            this.combmon.Location = new System.Drawing.Point(176, 86);
            this.combmon.Name = "combmon";
            this.combmon.Size = new System.Drawing.Size(64, 21);
            this.combmon.TabIndex = 4;
            this.combmon.SelectedIndexChanged += new System.EventHandler(this.combmon_SelectedIndexChanged);
            // 
            // combday
            // 
            this.combday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combday.FormattingEnabled = true;
            this.combday.Location = new System.Drawing.Point(82, 40);
            this.combday.Name = "combday";
            this.combday.Size = new System.Drawing.Size(64, 21);
            this.combday.TabIndex = 6;
            this.combday.SelectedIndexChanged += new System.EventHandler(this.combday_SelectedIndexChanged);
            // 
            // combMonth
            // 
            this.combMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combMonth.FormattingEnabled = true;
            this.combMonth.Location = new System.Drawing.Point(176, 40);
            this.combMonth.Name = "combMonth";
            this.combMonth.Size = new System.Drawing.Size(64, 21);
            this.combMonth.TabIndex = 7;
            this.combMonth.SelectedIndexChanged += new System.EventHandler(this.combMonth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "سنه";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "يوم";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "شهر";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "الى:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "من:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(-1, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 352);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "احصائيات";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(830, 330);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(472, 468);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 55);
            this.button1.TabIndex = 15;
            this.button1.Text = "عرض الا حصا ئيات";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::project_soft.Properties.Resources.Login_out_icon;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(641, 468);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 55);
            this.button2.TabIndex = 16;
            this.button2.Text = "رجوع";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Transcript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(835, 523);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combMonth);
            this.Controls.Add(this.combday);
            this.Controls.Add(this.combmon);
            this.Controls.Add(this.combD);
            this.Controls.Add(this.comYear);
            this.Controls.Add(this.combYear);
            this.MaximizeBox = false;
            this.Name = "Transcript";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "احصا ئيات";
            this.Load += new System.EventHandler(this.Transcript_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combYear;
        private System.Windows.Forms.ComboBox comYear;
        private System.Windows.Forms.ComboBox combD;
        private System.Windows.Forms.ComboBox combmon;
        private System.Windows.Forms.ComboBox combday;
        private System.Windows.Forms.ComboBox combMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}