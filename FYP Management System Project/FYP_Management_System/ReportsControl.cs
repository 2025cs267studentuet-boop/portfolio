using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP_Management_System
{
    public partial class ReportsControl : UserControl
    {
        string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";

        public ReportsControl()
        {
            InitializeComponent();
            LoadFilterDefaults();
        }
        private void LoadFilterDefaults()
        {
            cmbReportType.Items.AddRange(new string[] { "Project & Advisor Allocation", "Student Marks Summary" });

            cmbYear.Items.AddRange(new string[] { "2024-2025", "2025-2026", "2026-2027" });
            cmbYear.SelectedIndex = 1;

            cmbStatus.Items.AddRange(new string[] { "All", "In Progress", "Completed", "Proposed" });
            cmbStatus.SelectedIndex = 0;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedItem == null) return;

            string reportType = cmbReportType.SelectedItem.ToString();
            dgvReports.DataSource = null;
            dgvReports.Columns.Clear();

            if (reportType.Contains("Project") && reportType.Contains("Advisor"))
            {
                lblReportTitle.Text = "PROJECT & ADVISOR ALLOCATION";
                LoadProjectAdvisorReport("All");
            }
            else if (reportType.Contains("Student") && reportType.Contains("Marks"))
            {
                lblReportTitle.Text = "STUDENT MARKS SUMMARY";
                LoadStudentMarksReport();
            }

            UpdateSummaryGrid();
        }

        private void UpdateSummaryGrid()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    string query = "SELECT Description AS 'Status', COUNT(*) AS 'Count' FROM Project GROUP BY Description";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSummary.DataSource = dt;

                    dgvSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch { }
            }
        }
        private void LoadProjectAdvisorReport(string status)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = @"SELECT g.Id AS 'Group ID', p.Title AS 'Project Title', 
                         (SELECT per.FirstName FROM Person per JOIN ProjectAdvisor pa ON per.Id = pa.AdvisorId WHERE pa.ProjectId = p.Id AND pa.AdvisorRole = 11 LIMIT 1) AS 'Main Advisor',
                         (SELECT per.FirstName FROM Person per JOIN ProjectAdvisor pa ON per.Id = pa.AdvisorId WHERE pa.ProjectId = p.Id AND pa.AdvisorRole = 12 LIMIT 1) AS 'Co-Advisor'
                         FROM `Group` g
                         JOIN GroupProject gp ON g.Id = gp.GroupId
                         JOIN Project p ON gp.ProjectId = p.Id";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvReports.DataSource = dt;
                StyleGrid();
            }
        }
        private void LoadStudentMarksReport()
        {
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    s.RegistrationNo AS 'Reg No',
                    p.FirstName AS 'Student Name',
                    proj.Title AS 'Project Title',
                    e.Name AS 'Evaluation Type',
                    ge.ObtainedMarks AS 'Marks Obtained',
                    e.TotalMarks AS 'Total Marks'
                FROM Student s
                JOIN Person p ON s.Id = p.Id
                JOIN GroupStudent gs ON s.Id = gs.StudentId
                JOIN GroupProject gp ON gs.GroupId = gp.GroupId
                JOIN Project proj ON gp.ProjectId = proj.Id
                JOIN GroupEvaluation ge ON gs.GroupId = ge.GroupId
                JOIN Evaluation e ON ge.EvaluationId = e.Id
                WHERE gs.Status = 3
                ORDER BY s.RegistrationNo ASC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvReports.DataSource = dt;
                    dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    StyleGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Student Marks Report Error: " + ex.Message);
                }
            }
        }
        private void StyleGrid()
        {
            dgvReports.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204); 
            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReports.EnableHeadersVisualStyles = false; 
            dgvReports.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReports.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        
        dgvReports.BackgroundColor = Color.White;
            dgvReports.GridColor = Color.FromArgb(231, 229, 255);
            dgvReports.BorderStyle = BorderStyle.None;

            dgvReports.EnableHeadersVisualStyles = false;
            dgvReports.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReports.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72); 
            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReports.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReports.ColumnHeadersHeight = 40;

            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReports.MultiSelect = false;
            dgvReports.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dgvReports.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvReports.RowHeadersVisible = false; 

            dgvReports.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvReports.Rows.Count == 0) return;

            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV files (*.csv)|*.csv", FileName = "FYP_Report.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var sb = new StringBuilder();
                var headers = dgvReports.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(",", headers.Select(column => column.HeaderText)));

                foreach (DataGridViewRow row in dgvReports.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();
                    sb.AppendLine(string.Join(",", cells.Select(cell => cell.Value?.ToString())));
                }
                System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
                MessageBox.Show("Export Successful!");
            }
        
    }

        private void btnPrintPDF_Click(object sender, EventArgs e)
        {
            if (dgvReports.Rows.Count == 0)
            {
                MessageBox.Show("No data to print!");
                return;
            }
            printPreviewDialog1.ShowDialog();
        
    }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            dgvReports.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReports.EnableHeadersVisualStyles = false;

            Bitmap bm = new Bitmap(this.dgvReports.Width, this.dgvReports.Height);
            dgvReports.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvReports.Width, this.dgvReports.Height));

            e.Graphics.DrawString("FYP MANAGEMENT SYSTEM - REPORT", new Font("Segoe UI", 18, FontStyle.Bold), Brushes.Black, new Point(50, 50));

            int printableWidth = e.MarginBounds.Width;
            int printableHeight = e.MarginBounds.Height;
            double ratio = (double)printableWidth / (double)bm.Width;
            int newWidth = (int)(bm.Width * ratio);
            int newHeight = (int)(bm.Height * ratio);
            e.Graphics.DrawImage(bm, e.MarginBounds.Left, 120, newWidth, newHeight);
            e.Graphics.DrawString("Generated on: " + DateTime.Now.ToString(), new Font("Segoe UI", 10), Brushes.Gray, new Point(50, e.PageBounds.Height - 50));
        }

        private void ReportsControl_Load(object sender, EventArgs e)
        {

        }
    }
}
