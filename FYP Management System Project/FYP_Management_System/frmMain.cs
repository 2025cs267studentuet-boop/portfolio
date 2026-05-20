using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FYP_Management_System
{
    public partial class frmMain : Form
    {
        MySqlConnection conn = new MySqlConnection(
        "server=localhost;user=root;password=amjadali14@;database=projectadb26;");
        public frmMain()
        {
            InitializeComponent();
            btnManageStudents_Click(this, new EventArgs());

        }
        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnManageStudents);
            pnlMainContent.Controls.Clear();
            StudentControl myStudentPage = new StudentControl(); 
            myStudentPage.Dock = DockStyle.Fill;
            myStudentPage.BorderStyle = BorderStyle.None;  
            pnlMainContent.Controls.Add(myStudentPage);
        }

        private void btnManageAdvisors_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnManageAdvisors);
            pnlMainContent.Controls.Clear();
            AdvisorControl ac = new AdvisorControl();
            ac.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(ac);
        }
        private void btnManageGroups_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnManageGroups);
            pnlMainContent.Controls.Clear();
            GroupManagement ac = new GroupManagement();
            ac.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(ac);
        }

        private void btnManageProjects_Click_1(object sender, EventArgs e)
        {
            SetActiveButton(btnManageProjects);
            pnlMainContent.Controls.Clear();
            ProjectControl pc = new ProjectControl();
            pc.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(pc);
            pc.BringToFront();
        }

        private void btnProjectAssignment_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnProjectAssignment);
            pnlMainContent.Controls.Clear();
            ProjectAssignmentControl pac = new ProjectAssignmentControl();
            pac.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(pac);
        }

        private void btnEvaluation_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnEvaluation);
            pnlMainContent.Controls.Clear();
            EvaluationControl ec = new EvaluationControl();
            ec.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(ec);
        }
        private void btnReports_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnReports);
            pnlMainContent.Controls.Clear();
            ReportsControl rc = new ReportsControl();
            rc.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(rc);

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnExit);
            DialogResult result = MessageBox.Show("Are you sure you want to exit the system?",
                                                "Exit Confirmation",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
         

        }
        private void SetActiveButton(Button activeBtn)
        {
            Color standardColor = Color.FromArgb(31, 41, 55);
            Color activeColor = Color.FromArgb(45, 45, 45);
            List<Button> navButtons = new List<Button> {
        btnManageStudents, btnManageAdvisors, btnManageProjects,
         btnManageGroups,btnProjectAssignment, btnEvaluation, btnReports, btnExit
    };

            foreach (var btn in navButtons)
            {
                btn.BackColor = standardColor;
            }
            activeBtn.BackColor = activeColor;
        }

        private void pnlMainContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
