namespace FYP_Management_System
{
    partial class frmMain
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnEvaluation = new System.Windows.Forms.Button();
            this.btnProjectAssignment = new System.Windows.Forms.Button();
            this.btnManageProjects = new System.Windows.Forms.Button();
            this.btnManageGroups = new System.Windows.Forms.Button();
            this.btnManageAdvisors = new System.Windows.Forms.Button();
            this.btnManageStudents = new System.Windows.Forms.Button();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 79);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "FYP MANAGEMENT SYSTEM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnReports);
            this.panel2.Controls.Add(this.btnEvaluation);
            this.panel2.Controls.Add(this.btnProjectAssignment);
            this.panel2.Controls.Add(this.btnManageProjects);
            this.panel2.Controls.Add(this.btnManageGroups);
            this.panel2.Controls.Add(this.btnManageAdvisors);
            this.panel2.Controls.Add(this.btnManageStudents);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 508);
            this.panel2.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(0, 317);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(200, 44);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReports
            // 
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(0, 273);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(200, 44);
            this.btnReports.TabIndex = 6;
            this.btnReports.Text = "Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnEvaluation
            // 
            this.btnEvaluation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEvaluation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvaluation.ForeColor = System.Drawing.Color.White;
            this.btnEvaluation.Location = new System.Drawing.Point(0, 230);
            this.btnEvaluation.Name = "btnEvaluation";
            this.btnEvaluation.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnEvaluation.Size = new System.Drawing.Size(200, 43);
            this.btnEvaluation.TabIndex = 5;
            this.btnEvaluation.Text = "Evaluation";
            this.btnEvaluation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEvaluation.UseVisualStyleBackColor = true;
            this.btnEvaluation.Click += new System.EventHandler(this.btnEvaluation_Click);
            // 
            // btnProjectAssignment
            // 
            this.btnProjectAssignment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProjectAssignment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjectAssignment.ForeColor = System.Drawing.Color.White;
            this.btnProjectAssignment.Location = new System.Drawing.Point(0, 183);
            this.btnProjectAssignment.Name = "btnProjectAssignment";
            this.btnProjectAssignment.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnProjectAssignment.Size = new System.Drawing.Size(200, 47);
            this.btnProjectAssignment.TabIndex = 4;
            this.btnProjectAssignment.Text = "Project Assignment";
            this.btnProjectAssignment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProjectAssignment.UseVisualStyleBackColor = true;
            this.btnProjectAssignment.Click += new System.EventHandler(this.btnProjectAssignment_Click);
            // 
            // btnManageProjects
            // 
            this.btnManageProjects.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageProjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageProjects.ForeColor = System.Drawing.Color.White;
            this.btnManageProjects.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageProjects.Location = new System.Drawing.Point(0, 136);
            this.btnManageProjects.Name = "btnManageProjects";
            this.btnManageProjects.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnManageProjects.Size = new System.Drawing.Size(200, 47);
            this.btnManageProjects.TabIndex = 2;
            this.btnManageProjects.Text = "Manage Projects";
            this.btnManageProjects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageProjects.UseVisualStyleBackColor = true;
            this.btnManageProjects.Click += new System.EventHandler(this.btnManageProjects_Click_1);
            // 
            // btnManageGroups
            // 
            this.btnManageGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageGroups.ForeColor = System.Drawing.Color.White;
            this.btnManageGroups.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageGroups.Location = new System.Drawing.Point(0, 91);
            this.btnManageGroups.Name = "btnManageGroups";
            this.btnManageGroups.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnManageGroups.Size = new System.Drawing.Size(200, 45);
            this.btnManageGroups.TabIndex = 9;
            this.btnManageGroups.Text = "Manage Groups";
            this.btnManageGroups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageGroups.UseVisualStyleBackColor = true;
            this.btnManageGroups.Click += new System.EventHandler(this.btnManageGroups_Click);
            // 
            // btnManageAdvisors
            // 
            this.btnManageAdvisors.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageAdvisors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageAdvisors.ForeColor = System.Drawing.Color.White;
            this.btnManageAdvisors.Location = new System.Drawing.Point(0, 46);
            this.btnManageAdvisors.Name = "btnManageAdvisors";
            this.btnManageAdvisors.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnManageAdvisors.Size = new System.Drawing.Size(200, 45);
            this.btnManageAdvisors.TabIndex = 1;
            this.btnManageAdvisors.Text = "Manage Advisors";
            this.btnManageAdvisors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageAdvisors.UseVisualStyleBackColor = true;
            this.btnManageAdvisors.Click += new System.EventHandler(this.btnManageAdvisors_Click);
            // 
            // btnManageStudents
            // 
            this.btnManageStudents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageStudents.ForeColor = System.Drawing.Color.White;
            this.btnManageStudents.Location = new System.Drawing.Point(0, 0);
            this.btnManageStudents.Name = "btnManageStudents";
            this.btnManageStudents.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnManageStudents.Size = new System.Drawing.Size(200, 46);
            this.btnManageStudents.TabIndex = 0;
            this.btnManageStudents.Text = "Manage Students";
            this.btnManageStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageStudents.UseVisualStyleBackColor = true;
            this.btnManageStudents.Click += new System.EventHandler(this.btnManageStudents_Click);
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(200, 79);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(785, 508);
            this.pnlMainContent.TabIndex = 3;
            this.pnlMainContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainContent_Paint);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 587);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnManageAdvisors;
        private System.Windows.Forms.Button btnManageStudents;
        private System.Windows.Forms.Button btnEvaluation;
        private System.Windows.Forms.Button btnProjectAssignment;
        private System.Windows.Forms.Button btnManageProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnManageGroups;
    }
}

