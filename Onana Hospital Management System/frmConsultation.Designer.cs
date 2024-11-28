namespace Onana_Hospital_Management_System
{
    partial class frmConsultation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.chkNocharge = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiagnose = new System.Windows.Forms.TextBox();
            this.txtPatName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPatcode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTreatment = new System.Windows.Forms.TextBox();
            this.txtMedications = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFor = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.txtDocName);
            this.panel1.Controls.Add(this.chkNocharge);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 456);
            this.panel1.TabIndex = 0;
            // 
            // txtDocName
            // 
            this.txtDocName.Location = new System.Drawing.Point(99, 24);
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.ReadOnly = true;
            this.txtDocName.Size = new System.Drawing.Size(169, 20);
            this.txtDocName.TabIndex = 6;
            // 
            // chkNocharge
            // 
            this.chkNocharge.AutoSize = true;
            this.chkNocharge.Location = new System.Drawing.Point(6, 369);
            this.chkNocharge.Name = "chkNocharge";
            this.chkNocharge.Size = new System.Drawing.Size(136, 17);
            this.chkNocharge.TabIndex = 4;
            this.chkNocharge.Text = "Ignore consultation bills";
            this.chkNocharge.UseVisualStyleBackColor = true;
            this.chkNocharge.CheckedChanged += new System.EventHandler(this.chkNocharge_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Onana HMS Calendar";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(64, 111);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Medical Doctor";
            // 
            // txtDiagnose
            // 
            this.txtDiagnose.Location = new System.Drawing.Point(321, 82);
            this.txtDiagnose.MaxLength = 800;
            this.txtDiagnose.Multiline = true;
            this.txtDiagnose.Name = "txtDiagnose";
            this.txtDiagnose.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDiagnose.Size = new System.Drawing.Size(517, 73);
            this.txtDiagnose.TabIndex = 1;
            this.txtDiagnose.TextChanged += new System.EventHandler(this.txtDiagnose_TextChanged);
            this.txtDiagnose.Leave += new System.EventHandler(this.txtDiagnose_Leave);
            // 
            // txtPatName
            // 
            this.txtPatName.Location = new System.Drawing.Point(586, 28);
            this.txtPatName.Name = "txtPatName";
            this.txtPatName.ReadOnly = true;
            this.txtPatName.Size = new System.Drawing.Size(252, 20);
            this.txtPatName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(318, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patience ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(488, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Patience Name";
            // 
            // cboPatcode
            // 
            this.cboPatcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatcode.FormattingEnabled = true;
            this.cboPatcode.Location = new System.Drawing.Point(387, 25);
            this.cboPatcode.Name = "cboPatcode";
            this.cboPatcode.Size = new System.Drawing.Size(95, 21);
            this.cboPatcode.TabIndex = 4;
            this.cboPatcode.SelectedIndexChanged += new System.EventHandler(this.cboPatcode_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(318, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Diagnosis";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(318, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Treatment";
            // 
            // txtTreatment
            // 
            this.txtTreatment.Location = new System.Drawing.Point(321, 188);
            this.txtTreatment.MaxLength = 800;
            this.txtTreatment.Multiline = true;
            this.txtTreatment.Name = "txtTreatment";
            this.txtTreatment.Size = new System.Drawing.Size(517, 49);
            this.txtTreatment.TabIndex = 1;
            this.txtTreatment.TextChanged += new System.EventHandler(this.txtTreatment_TextChanged);
            this.txtTreatment.Leave += new System.EventHandler(this.txtTreatment_Leave);
            // 
            // txtMedications
            // 
            this.txtMedications.Location = new System.Drawing.Point(321, 274);
            this.txtMedications.MaxLength = 800;
            this.txtMedications.Multiline = true;
            this.txtMedications.Name = "txtMedications";
            this.txtMedications.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMedications.Size = new System.Drawing.Size(349, 145);
            this.txtMedications.TabIndex = 1;
            this.txtMedications.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            this.txtMedications.Leave += new System.EventHandler(this.txtMedications_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(676, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "For:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(321, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(251, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Medication Details(Drug name, Dosage, Qty)";
            // 
            // cboFor
            // 
            this.cboFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFor.FormattingEnabled = true;
            this.cboFor.Items.AddRange(new object[] {
            "Days",
            "Weeks",
            "Months",
            "Single Dose",
            "When i need you"});
            this.cboFor.Location = new System.Drawing.Point(679, 284);
            this.cboFor.Name = "cboFor";
            this.cboFor.Size = new System.Drawing.Size(117, 21);
            this.cboFor.TabIndex = 4;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(706, 451);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(90, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Import Lab Result";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Location = new System.Drawing.Point(321, 430);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(121, 34);
            this.btnSaveResult.TabIndex = 8;
            this.btnSaveResult.Text = "Save Result";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(549, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 34);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(679, 311);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmConsultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 472);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cboFor);
            this.Controls.Add(this.cboPatcode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPatName);
            this.Controls.Add(this.txtMedications);
            this.Controls.Add(this.txtTreatment);
            this.Controls.Add(this.txtDiagnose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConsultation";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient Consultation- Onana HMS";
            this.Load += new System.EventHandler(this.frmConsultation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiagnose;
        private System.Windows.Forms.TextBox txtPatName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPatcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTreatment;
        private System.Windows.Forms.TextBox txtMedications;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboFor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkNocharge;
        public System.Windows.Forms.TextBox txtDocName;
    }
}