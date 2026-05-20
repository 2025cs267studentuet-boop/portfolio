namespace FYP_Management_System
{
    partial class EvaluationControl
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpEvalDate = new System.Windows.Forms.DateTimePicker();
            this.txtTotalMarks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProjectId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGroups = new System.Windows.Forms.ComboBox();
            this.txtProjectTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlStudentHeader = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cmbEvalType = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkGroupMark = new System.Windows.Forms.CheckBox();
            this.numObtainedMarks = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStudents = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlStudentHeader.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numObtainedMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dtpEvalDate);
            this.groupBox2.Controls.Add(this.txtTotalMarks);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(699, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 212);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Evaluation Details";
            // 
            // dtpEvalDate
            // 
            this.dtpEvalDate.Location = new System.Drawing.Point(188, 115);
            this.dtpEvalDate.Margin = new System.Windows.Forms.Padding(1);
            this.dtpEvalDate.Name = "dtpEvalDate";
            this.dtpEvalDate.Size = new System.Drawing.Size(261, 34);
            this.dtpEvalDate.TabIndex = 3;
            // 
            // txtTotalMarks
            // 
            this.txtTotalMarks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalMarks.Location = new System.Drawing.Point(188, 51);
            this.txtTotalMarks.Name = "txtTotalMarks";
            this.txtTotalMarks.ReadOnly = true;
            this.txtTotalMarks.Size = new System.Drawing.Size(261, 34);
            this.txtTotalMarks.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "Total Marks:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 28);
            this.label9.TabIndex = 2;
            this.label9.Text = "DatePicker:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Group ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtProjectId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbGroups);
            this.groupBox1.Controls.Add(this.txtProjectTitle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(103, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 222);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Select Group for Evaluation";
            // 
            // txtProjectId
            // 
            this.txtProjectId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectId.Location = new System.Drawing.Point(315, 158);
            this.txtProjectId.Name = "txtProjectId";
            this.txtProjectId.ReadOnly = true;
            this.txtProjectId.Size = new System.Drawing.Size(68, 34);
            this.txtProjectId.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(274, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 28);
            this.label5.TabIndex = 5;
            this.label5.Text = "ID:";
            // 
            // cmbGroups
            // 
            this.cmbGroups.FormattingEnabled = true;
            this.cmbGroups.Location = new System.Drawing.Point(164, 49);
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.Size = new System.Drawing.Size(219, 36);
            this.cmbGroups.TabIndex = 4;
            this.cmbGroups.SelectedIndexChanged += new System.EventHandler(this.cmbGroups_SelectedIndexChanged);
            // 
            // txtProjectTitle
            // 
            this.txtProjectTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectTitle.Location = new System.Drawing.Point(164, 100);
            this.txtProjectTitle.Name = "txtProjectTitle";
            this.txtProjectTitle.ReadOnly = true;
            this.txtProjectTitle.Size = new System.Drawing.Size(180, 34);
            this.txtProjectTitle.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "Project Title:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(366, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(521, 38);
            this.label8.TabIndex = 1;
            this.label8.Text = "PROJECT EVALUATION AND GRADING";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlStudentHeader
            // 
            this.pnlStudentHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.pnlStudentHeader.Controls.Add(this.label8);
            this.pnlStudentHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStudentHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlStudentHeader.Name = "pnlStudentHeader";
            this.pnlStudentHeader.Size = new System.Drawing.Size(1255, 69);
            this.pnlStudentHeader.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnSubmit);
            this.groupBox3.Controls.Add(this.cmbEvalType);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(103, 344);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(437, 225);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "2. Select Evaluation Type";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(36, 143);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(365, 67);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "SUBMIT EVALUATION AND GRADE";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cmbEvalType
            // 
            this.cmbEvalType.FormattingEnabled = true;
            this.cmbEvalType.Location = new System.Drawing.Point(58, 67);
            this.cmbEvalType.Name = "cmbEvalType";
            this.cmbEvalType.Size = new System.Drawing.Size(302, 36);
            this.cmbEvalType.TabIndex = 2;
            this.cmbEvalType.SelectedIndexChanged += new System.EventHandler(this.cmbEvalType_SelectedIndexChanged);
            this.cmbEvalType.TextChanged += new System.EventHandler(this.cmbEvalType_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.chkGroupMark);
            this.groupBox4.Controls.Add(this.numObtainedMarks);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.cmbStudents);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(699, 344);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(478, 225);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "3. Individual Student Grading";
            // 
            // chkGroupMark
            // 
            this.chkGroupMark.AutoSize = true;
            this.chkGroupMark.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.chkGroupMark.Location = new System.Drawing.Point(96, 154);
            this.chkGroupMark.Name = "chkGroupMark";
            this.chkGroupMark.Size = new System.Drawing.Size(376, 25);
            this.chkGroupMark.TabIndex = 5;
            this.chkGroupMark.Text = "Use as Group Mark? (Applies to all members)";
            this.chkGroupMark.UseVisualStyleBackColor = true;
            this.chkGroupMark.CheckedChanged += new System.EventHandler(this.chkGroupMark_CheckedChanged);
            // 
            // numObtainedMarks
            // 
            this.numObtainedMarks.Location = new System.Drawing.Point(244, 105);
            this.numObtainedMarks.Name = "numObtainedMarks";
            this.numObtainedMarks.Size = new System.Drawing.Size(205, 34);
            this.numObtainedMarks.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(32, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Obtained Marks:";
            // 
            // cmbStudents
            // 
            this.cmbStudents.FormattingEnabled = true;
            this.cmbStudents.Location = new System.Drawing.Point(244, 45);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new System.Drawing.Size(205, 36);
            this.cmbStudents.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Student Name:";
            // 
            // EvaluationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlStudentHeader);
            this.Name = "EvaluationControl";
            this.Size = new System.Drawing.Size(1255, 630);
            this.Load += new System.EventHandler(this.EvaluationControl_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlStudentHeader.ResumeLayout(false);
            this.pnlStudentHeader.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numObtainedMarks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTotalMarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlStudentHeader;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProjectId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGroups;
        private System.Windows.Forms.TextBox txtProjectTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cmbEvalType;
        public System.Windows.Forms.DateTimePicker dtpEvalDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStudents;
        private System.Windows.Forms.NumericUpDown numObtainedMarks;
        private System.Windows.Forms.CheckBox chkGroupMark;
    }
}
