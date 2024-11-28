namespace Server
{
    partial class Admin
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
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.imgPath = new System.Windows.Forms.TextBox();
            this.showImg = new System.Windows.Forms.Button();
            this.showPdf = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.empImg = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(77, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Data -";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(70, 69);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(409, 163);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // imgPath
            // 
            this.imgPath.Location = new System.Drawing.Point(485, 305);
            this.imgPath.Margin = new System.Windows.Forms.Padding(2);
            this.imgPath.Multiline = true;
            this.imgPath.Name = "imgPath";
            this.imgPath.Size = new System.Drawing.Size(177, 44);
            this.imgPath.TabIndex = 34;
            // 
            // showImg
            // 
            this.showImg.Location = new System.Drawing.Point(531, 246);
            this.showImg.Margin = new System.Windows.Forms.Padding(2);
            this.showImg.Name = "showImg";
            this.showImg.Size = new System.Drawing.Size(93, 41);
            this.showImg.TabIndex = 33;
            this.showImg.Text = "Import images";
            this.showImg.UseVisualStyleBackColor = true;
            this.showImg.Click += new System.EventHandler(this.showImg_Click);
            // 
            // showPdf
            // 
            this.showPdf.Location = new System.Drawing.Point(70, 305);
            this.showPdf.Margin = new System.Windows.Forms.Padding(2);
            this.showPdf.Multiline = true;
            this.showPdf.Name = "showPdf";
            this.showPdf.Size = new System.Drawing.Size(177, 44);
            this.showPdf.TabIndex = 32;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(107, 246);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(2);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(93, 41);
            this.btnDownload.TabIndex = 31;
            this.btnDownload.Text = "Import data";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(503, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 41);
            this.button2.TabIndex = 30;
            this.button2.Text = "show images";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // empImg
            // 
            this.empImg.Location = new System.Drawing.Point(503, 116);
            this.empImg.Name = "empImg";
            this.empImg.Size = new System.Drawing.Size(130, 41);
            this.empImg.TabIndex = 29;
            this.empImg.Text = "show data";
            this.empImg.UseVisualStyleBackColor = true;
            this.empImg.Click += new System.EventHandler(this.empImg_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Employee",
            "Appointment",
            "Bills"});
            this.listBox1.Location = new System.Drawing.Point(213, 40);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(96, 17);
            this.listBox1.TabIndex = 35;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 356);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.imgPath);
            this.Controls.Add(this.showImg);
            this.Controls.Add(this.showPdf);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.empImg);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Admin";
            this.Text = "Admin Data management";
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox imgPath;
        private System.Windows.Forms.Button showImg;
        private System.Windows.Forms.TextBox showPdf;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button empImg;
        private System.Windows.Forms.ListBox listBox1;
    }
}