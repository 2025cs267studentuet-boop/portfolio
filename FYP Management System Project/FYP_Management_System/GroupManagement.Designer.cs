namespace FYP_Management_System
{
    partial class GroupManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupManagement));
            this.pnlGroupHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbSelectedStudents = new System.Windows.Forms.ListBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpCreatedOn = new System.Windows.Forms.DateTimePicker();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.btnRemoveFromGroup = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddToGroup = new System.Windows.Forms.Button();
            this.txtGroupId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAvailableStudents = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchAvailable = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvExistingGroups = new System.Windows.Forms.DataGridView();
            this.pnlGroupHeader.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableStudents)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistingGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGroupHeader
            // 
            this.pnlGroupHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.pnlGroupHeader.Controls.Add(this.lblTitle);
            this.pnlGroupHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGroupHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlGroupHeader.Name = "pnlGroupHeader";
            this.pnlGroupHeader.Size = new System.Drawing.Size(1153, 69);
            this.pnlGroupHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(395, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(325, 38);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "GROUP MANAGEMENT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 75);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1150, 374);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbSelectedStudents);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Location = new System.Drawing.Point(769, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(378, 368);
            this.panel3.TabIndex = 3;
            // 
            // lbSelectedStudents
            // 
            this.lbSelectedStudents.FormattingEnabled = true;
            this.lbSelectedStudents.ItemHeight = 20;
            this.lbSelectedStudents.Location = new System.Drawing.Point(3, 75);
            this.lbSelectedStudents.Name = "lbSelectedStudents";
            this.lbSelectedStudents.Size = new System.Drawing.Size(372, 284);
            this.lbSelectedStudents.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(378, 69);
            this.panel7.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(77, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "SELECTED STUDENTS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(395, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(325, 38);
            this.label5.TabIndex = 1;
            this.label5.Text = "GROUP MANAGEMENT";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.dtpCreatedOn);
            this.panel5.Controls.Add(this.btnDeleteGroup);
            this.panel5.Controls.Add(this.btnCreateGroup);
            this.panel5.Controls.Add(this.btnRemoveFromGroup);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.btnAddToGroup);
            this.panel5.Controls.Add(this.txtGroupId);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(386, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(377, 368);
            this.panel5.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "Created On:";
            // 
            // dtpCreatedOn
            // 
            this.dtpCreatedOn.Location = new System.Drawing.Point(131, 113);
            this.dtpCreatedOn.Name = "dtpCreatedOn";
            this.dtpCreatedOn.Size = new System.Drawing.Size(200, 26);
            this.dtpCreatedOn.TabIndex = 16;
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.btnDeleteGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteGroup.ForeColor = System.Drawing.Color.White;
            this.btnDeleteGroup.Location = new System.Drawing.Point(118, 310);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(154, 44);
            this.btnDeleteGroup.TabIndex = 15;
            this.btnDeleteGroup.Text = "DELETE";
            this.btnDeleteGroup.UseVisualStyleBackColor = false;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.btnCreateGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateGroup.ForeColor = System.Drawing.Color.White;
            this.btnCreateGroup.Location = new System.Drawing.Point(118, 247);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(154, 44);
            this.btnCreateGroup.TabIndex = 14;
            this.btnCreateGroup.Text = "CREATE";
            this.btnCreateGroup.UseVisualStyleBackColor = false;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // btnRemoveFromGroup
            // 
            this.btnRemoveFromGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.btnRemoveFromGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFromGroup.ForeColor = System.Drawing.Color.White;
            this.btnRemoveFromGroup.Location = new System.Drawing.Point(240, 179);
            this.btnRemoveFromGroup.Name = "btnRemoveFromGroup";
            this.btnRemoveFromGroup.Size = new System.Drawing.Size(75, 44);
            this.btnRemoveFromGroup.TabIndex = 13;
            this.btnRemoveFromGroup.Text = "<";
            this.btnRemoveFromGroup.UseVisualStyleBackColor = false;
            this.btnRemoveFromGroup.Click += new System.EventHandler(this.btnRemoveFromGroup_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(236, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "REMOVE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "ADD";
            // 
            // btnAddToGroup
            // 
            this.btnAddToGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.btnAddToGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToGroup.ForeColor = System.Drawing.Color.White;
            this.btnAddToGroup.Location = new System.Drawing.Point(85, 184);
            this.btnAddToGroup.Name = "btnAddToGroup";
            this.btnAddToGroup.Size = new System.Drawing.Size(75, 44);
            this.btnAddToGroup.TabIndex = 7;
            this.btnAddToGroup.Text = ">";
            this.btnAddToGroup.UseVisualStyleBackColor = false;
            this.btnAddToGroup.Click += new System.EventHandler(this.btnAddToGroup_Click);
            // 
            // txtGroupId
            // 
            this.txtGroupId.Location = new System.Drawing.Point(156, 78);
            this.txtGroupId.Name = "txtGroupId";
            this.txtGroupId.ReadOnly = true;
            this.txtGroupId.Size = new System.Drawing.Size(116, 26);
            this.txtGroupId.TabIndex = 6;
            this.txtGroupId.Click += new System.EventHandler(this.txtGroupId_TextChanged);
            this.txtGroupId.TextChanged += new System.EventHandler(this.txtGroupId_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Group ID:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(377, 69);
            this.panel6.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(77, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(217, 28);
            this.label9.TabIndex = 3;
            this.label9.Text = "NEW GROUP DETAILS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(395, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(325, 38);
            this.label10.TabIndex = 1;
            this.label10.Text = "GROUP MANAGEMENT";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvAvailableStudents);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearchAvailable);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 368);
            this.panel1.TabIndex = 0;
            // 
            // dgvAvailableStudents
            // 
            this.dgvAvailableStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableStudents.Location = new System.Drawing.Point(3, 137);
            this.dgvAvailableStudents.Name = "dgvAvailableStudents";
            this.dgvAvailableStudents.RowHeadersWidth = 62;
            this.dgvAvailableStudents.RowTemplate.Height = 28;
            this.dgvAvailableStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableStudents.Size = new System.Drawing.Size(374, 234);
            this.dgvAvailableStudents.TabIndex = 23;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(282, 75);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 24);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchAvailable
            // 
            this.txtSearchAvailable.Location = new System.Drawing.Point(54, 75);
            this.txtSearchAvailable.Name = "txtSearchAvailable";
            this.txtSearchAvailable.Size = new System.Drawing.Size(222, 26);
            this.txtSearchAvailable.TabIndex = 21;
            this.txtSearchAvailable.Text = "Search";
            this.txtSearchAvailable.Click += new System.EventHandler(this.txtSearchAvailable_TextChanged);
            this.txtSearchAvailable.TextChanged += new System.EventHandler(this.txtSearchAvailable_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 69);
            this.panel2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(84, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "AVAILABLE STUDENTS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(395, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "GROUP MANAGEMENT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvExistingGroups
            // 
            this.dgvExistingGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExistingGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExistingGroups.Location = new System.Drawing.Point(9, 506);
            this.dgvExistingGroups.Name = "dgvExistingGroups";
            this.dgvExistingGroups.RowHeadersWidth = 62;
            this.dgvExistingGroups.RowTemplate.Height = 28;
            this.dgvExistingGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExistingGroups.Size = new System.Drawing.Size(1141, 156);
            this.dgvExistingGroups.TabIndex = 3;
            this.dgvExistingGroups.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExistingGroups_CellContentClick);
            // 
            // GroupManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvExistingGroups);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnlGroupHeader);
            this.Name = "GroupManagement";
            this.Size = new System.Drawing.Size(1153, 665);
            this.Load += new System.EventHandler(this.GroupManagement_Load);
            this.pnlGroupHeader.ResumeLayout(false);
            this.pnlGroupHeader.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableStudents)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistingGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGroupHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchAvailable;
        private System.Windows.Forms.DataGridView dgvAvailableStudents;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddToGroup;
        private System.Windows.Forms.TextBox txtGroupId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.Button btnRemoveFromGroup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpCreatedOn;
        private System.Windows.Forms.ListBox lbSelectedStudents;
        private System.Windows.Forms.DataGridView dgvExistingGroups;
    }
}
