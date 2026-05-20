namespace FYP_Management_System
{
    partial class ProjectAssignmentControl
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
            this.pnlStudentHeader = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpAssignmentDate = new System.Windows.Forms.DateTimePicker();
            this.rtbMemberSummary = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbIndustryAdvisor = new System.Windows.Forms.ComboBox();
            this.cmbMainAdvisor = new System.Windows.Forms.ComboBox();
            this.cmbCoAdvisor = new System.Windows.Forms.ComboBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtProjectId = new System.Windows.Forms.TextBox();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbGroups = new System.Windows.Forms.ComboBox();
            this.pnlStudentHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStudentHeader
            // 
            this.pnlStudentHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.pnlStudentHeader.Controls.Add(this.label8);
            this.pnlStudentHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStudentHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlStudentHeader.Name = "pnlStudentHeader";
            this.pnlStudentHeader.Size = new System.Drawing.Size(1011, 69);
            this.pnlStudentHeader.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(271, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(479, 38);
            this.label8.TabIndex = 1;
            this.label8.Text = "ASSIGN PROJECTS AND ADVISORS";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.dtpAssignmentDate);
            this.panel1.Controls.Add(this.rtbMemberSummary);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(631, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 599);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dtpAssignmentDate
            // 
            this.dtpAssignmentDate.CalendarFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dtpAssignmentDate.CalendarMonthBackground = System.Drawing.SystemColors.ControlLight;
            this.dtpAssignmentDate.Enabled = false;
            this.dtpAssignmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAssignmentDate.Location = new System.Drawing.Point(122, 201);
            this.dtpAssignmentDate.Name = "dtpAssignmentDate";
            this.dtpAssignmentDate.Size = new System.Drawing.Size(151, 26);
            this.dtpAssignmentDate.TabIndex = 7;
            // 
            // rtbMemberSummary
            // 
            this.rtbMemberSummary.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rtbMemberSummary.Location = new System.Drawing.Point(23, 305);
            this.rtbMemberSummary.Name = "rtbMemberSummary";
            this.rtbMemberSummary.ReadOnly = true;
            this.rtbMemberSummary.Size = new System.Drawing.Size(284, 169);
            this.rtbMemberSummary.TabIndex = 3;
            this.rtbMemberSummary.Text = "";
            this.rtbMemberSummary.TextChanged += new System.EventHandler(this.rtbMemberSummary_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(18, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(255, 28);
            this.label6.TabIndex = 2;
            this.label6.Text = "Selected Group Members:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(18, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "📅 Assignment Date";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.btnAssign);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(631, 599);
            this.panel2.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.cmbIndustryAdvisor);
            this.groupBox3.Controls.Add(this.cmbMainAdvisor);
            this.groupBox3.Controls.Add(this.cmbCoAdvisor);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(39, 319);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(550, 186);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. Assign Advisors";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Industry Advisor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Co-Advisor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Main Advisor";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(368, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(9, 8);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cmbIndustryAdvisor
            // 
            this.cmbIndustryAdvisor.FormattingEnabled = true;
            this.cmbIndustryAdvisor.Location = new System.Drawing.Point(298, 133);
            this.cmbIndustryAdvisor.Name = "cmbIndustryAdvisor";
            this.cmbIndustryAdvisor.Size = new System.Drawing.Size(175, 36);
            this.cmbIndustryAdvisor.TabIndex = 3;
            // 
            // cmbMainAdvisor
            // 
            this.cmbMainAdvisor.FormattingEnabled = true;
            this.cmbMainAdvisor.Location = new System.Drawing.Point(298, 33);
            this.cmbMainAdvisor.Name = "cmbMainAdvisor";
            this.cmbMainAdvisor.Size = new System.Drawing.Size(175, 36);
            this.cmbMainAdvisor.TabIndex = 1;
            // 
            // cmbCoAdvisor
            // 
            this.cmbCoAdvisor.FormattingEnabled = true;
            this.cmbCoAdvisor.Location = new System.Drawing.Point(298, 86);
            this.cmbCoAdvisor.Name = "cmbCoAdvisor";
            this.cmbCoAdvisor.Size = new System.Drawing.Size(175, 36);
            this.cmbCoAdvisor.TabIndex = 0;
            // 
            // btnAssign
            // 
            this.btnAssign.BackColor = System.Drawing.Color.DarkBlue;
            this.btnAssign.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAssign.ForeColor = System.Drawing.Color.White;
            this.btnAssign.Location = new System.Drawing.Point(141, 529);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(424, 58);
            this.btnAssign.TabIndex = 38;
            this.btnAssign.Tag = "";
            this.btnAssign.Text = "ASSIGN PROJECT AND ADVISORS";
            this.btnAssign.UseVisualStyleBackColor = false;
            this.btnAssign.TextChanged += new System.EventHandler(this.btnAssign_Click);
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtProjectId);
            this.groupBox2.Controls.Add(this.cmbProjects);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(39, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 143);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Select Project";
            // 
            // txtProjectId
            // 
            this.txtProjectId.Location = new System.Drawing.Point(412, 97);
            this.txtProjectId.Name = "txtProjectId";
            this.txtProjectId.ReadOnly = true;
            this.txtProjectId.Size = new System.Drawing.Size(78, 34);
            this.txtProjectId.TabIndex = 4;
            this.txtProjectId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbProjects
            // 
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(164, 46);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(162, 36);
            this.cmbProjects.TabIndex = 3;
            this.cmbProjects.SelectedIndexChanged += new System.EventHandler(this.cmbProjects_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbGroups);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(39, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 114);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Select Group";
            // 
            // cmbGroups
            // 
            this.cmbGroups.FormattingEnabled = true;
            this.cmbGroups.Location = new System.Drawing.Point(220, 33);
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.Size = new System.Drawing.Size(270, 36);
            this.cmbGroups.TabIndex = 0;
            this.cmbGroups.TextChanged += new System.EventHandler(this.cmbGroups_SelectedIndexChanged);
            // 
            // ProjectAssignmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlStudentHeader);
            this.Name = "ProjectAssignmentControl";
            this.Size = new System.Drawing.Size(1011, 668);
            this.pnlStudentHeader.ResumeLayout(false);
            this.pnlStudentHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlStudentHeader;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbMemberSummary;
        private System.Windows.Forms.DateTimePicker dtpAssignmentDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbIndustryAdvisor;
        private System.Windows.Forms.ComboBox cmbMainAdvisor;
        private System.Windows.Forms.ComboBox cmbCoAdvisor;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtProjectId;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbGroups;
    }
}
