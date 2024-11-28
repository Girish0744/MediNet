namespace Onana_Hospital_Management_System
{
    partial class frmNurseTest
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNurseTest));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPatName = new System.Windows.Forms.TextBox();
            this.txtPatID = new System.Windows.Forms.TextBox();
            this.txtPatHeight = new System.Windows.Forms.TextBox();
            this.txtPatWeight = new System.Windows.Forms.TextBox();
            this.txtpatBMI = new System.Windows.Forms.TextBox();
            this.txtpatPressure = new System.Windows.Forms.TextBox();
            this.txtPatTemperature = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictImage = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Patient Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Height(inches)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Weight(pounds)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "BMI";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Pressure(mmHG)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 270);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Temperature(oC)";
            // 
            // txtPatName
            // 
            this.txtPatName.Location = new System.Drawing.Point(137, 62);
            this.txtPatName.Name = "txtPatName";
            this.txtPatName.ReadOnly = true;
            this.txtPatName.Size = new System.Drawing.Size(237, 20);
            this.txtPatName.TabIndex = 1;
            this.txtPatName.TextChanged += new System.EventHandler(this.txtPatName_TextChanged);
            // 
            // txtPatID
            // 
            this.txtPatID.Location = new System.Drawing.Point(137, 19);
            this.txtPatID.Name = "txtPatID";
            this.txtPatID.Size = new System.Drawing.Size(162, 20);
            this.txtPatID.TabIndex = 0;
            this.txtPatID.TextChanged += new System.EventHandler(this.txtPatID_TextChanged);
            // 
            // txtPatHeight
            // 
            this.txtPatHeight.Location = new System.Drawing.Point(137, 105);
            this.txtPatHeight.Name = "txtPatHeight";
            this.txtPatHeight.ReadOnly = true;
            this.txtPatHeight.Size = new System.Drawing.Size(237, 20);
            this.txtPatHeight.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtPatHeight, "To edit field highlight to change value");
            this.txtPatHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatHeight_KeyPress);
            // 
            // txtPatWeight
            // 
            this.txtPatWeight.Location = new System.Drawing.Point(137, 152);
            this.txtPatWeight.Name = "txtPatWeight";
            this.txtPatWeight.ReadOnly = true;
            this.txtPatWeight.Size = new System.Drawing.Size(237, 20);
            this.txtPatWeight.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtPatWeight, "To edit field highlight to change value\r\n");
            this.txtPatWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatWeight_KeyPress);
            // 
            // txtpatBMI
            // 
            this.txtpatBMI.Location = new System.Drawing.Point(137, 189);
            this.txtpatBMI.Name = "txtpatBMI";
            this.txtpatBMI.ReadOnly = true;
            this.txtpatBMI.Size = new System.Drawing.Size(141, 20);
            this.txtpatBMI.TabIndex = 4;
            this.txtpatBMI.TextChanged += new System.EventHandler(this.txtpatBMI_TextChanged);
            // 
            // txtpatPressure
            // 
            this.txtpatPressure.Location = new System.Drawing.Point(137, 229);
            this.txtpatPressure.Name = "txtpatPressure";
            this.txtpatPressure.ReadOnly = true;
            this.txtpatPressure.Size = new System.Drawing.Size(237, 20);
            this.txtpatPressure.TabIndex = 5;
            this.txtpatPressure.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpatPressure_KeyPress);
            // 
            // txtPatTemperature
            // 
            this.txtPatTemperature.Location = new System.Drawing.Point(137, 265);
            this.txtPatTemperature.Name = "txtPatTemperature";
            this.txtPatTemperature.ReadOnly = true;
            this.txtPatTemperature.Size = new System.Drawing.Size(237, 20);
            this.txtPatTemperature.TabIndex = 6;
            this.txtPatTemperature.TextChanged += new System.EventHandler(this.txtPatTemperature_TextChanged);
            this.txtPatTemperature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatTemperature_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictImage);
            this.groupBox1.Location = new System.Drawing.Point(420, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 187);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patient Image";
            // 
            // pictImage
            // 
            this.pictImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictImage.Image = global::Onana_Hospital_Management_System.Properties.Resources.index;
            this.pictImage.Location = new System.Drawing.Point(13, 19);
            this.pictImage.Name = "pictImage";
            this.pictImage.Size = new System.Drawing.Size(158, 156);
            this.pictImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictImage.TabIndex = 0;
            this.pictImage.TabStop = false;
            this.toolTip1.SetToolTip(this.pictImage, "Patient Image");
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(58, 315);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 47);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(284, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 47);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(284, 192);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Compute BMI";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmNurseTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 374);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPatTemperature);
            this.Controls.Add(this.txtpatPressure);
            this.Controls.Add(this.txtpatBMI);
            this.Controls.Add(this.txtPatWeight);
            this.Controls.Add(this.txtPatHeight);
            this.Controls.Add(this.txtPatID);
            this.Controls.Add(this.txtPatName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNurseTest";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nurse Test";
            this.Load += new System.EventHandler(this.frmDiagnose_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPatName;
        private System.Windows.Forms.TextBox txtPatID;
        private System.Windows.Forms.TextBox txtPatHeight;
        private System.Windows.Forms.TextBox txtPatWeight;
        private System.Windows.Forms.TextBox txtpatBMI;
        private System.Windows.Forms.TextBox txtpatPressure;
        private System.Windows.Forms.TextBox txtPatTemperature;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}