namespace Server
{
    partial class Doctor
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.imgPath = new System.Windows.Forms.TextBox();
            this.showImg = new System.Windows.Forms.Button();
            this.showPdf = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.empImg = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "Appointment",
            "Patient"});
            this.listBox1.Location = new System.Drawing.Point(235, 45);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(142, 24);
            this.listBox1.TabIndex = 53;
            // 
            // imgPath
            // 
            this.imgPath.Location = new System.Drawing.Point(654, 441);
            this.imgPath.Multiline = true;
            this.imgPath.Name = "imgPath";
            this.imgPath.Size = new System.Drawing.Size(264, 66);
            this.imgPath.TabIndex = 52;
            // 
            // showImg
            // 
            this.showImg.Location = new System.Drawing.Point(722, 350);
            this.showImg.Name = "showImg";
            this.showImg.Size = new System.Drawing.Size(140, 63);
            this.showImg.TabIndex = 51;
            this.showImg.Text = "Import images";
            this.showImg.UseVisualStyleBackColor = true;
            this.showImg.Click += new System.EventHandler(this.showImg_Click_1);
            // 
            // showPdf
            // 
            this.showPdf.Location = new System.Drawing.Point(31, 441);
            this.showPdf.Multiline = true;
            this.showPdf.Name = "showPdf";
            this.showPdf.Size = new System.Drawing.Size(264, 66);
            this.showPdf.TabIndex = 50;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(86, 350);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(140, 63);
            this.btnDownload.TabIndex = 49;
            this.btnDownload.Text = "Import data";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(680, 78);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 63);
            this.button2.TabIndex = 48;
            this.button2.Text = "show images";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // empImg
            // 
            this.empImg.Location = new System.Drawing.Point(680, 150);
            this.empImg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.empImg.Name = "empImg";
            this.empImg.Size = new System.Drawing.Size(195, 63);
            this.empImg.TabIndex = 47;
            this.empImg.Text = "show data";
            this.empImg.UseVisualStyleBackColor = true;
            this.empImg.Click += new System.EventHandler(this.empImg_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(614, 251);
            this.dataGridView1.TabIndex = 46;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(42, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 36);
            this.label2.TabIndex = 45;
            this.label2.Text = "Select Data -";
            // 
            // Doctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 540);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.imgPath);
            this.Controls.Add(this.showImg);
            this.Controls.Add(this.showPdf);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.empImg);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Name = "Doctor";
            this.Text = "Doctor";
            this.Load += new System.EventHandler(this.Doctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox imgPath;
        private System.Windows.Forms.Button showImg;
        private System.Windows.Forms.TextBox showPdf;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button empImg;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
    }
}