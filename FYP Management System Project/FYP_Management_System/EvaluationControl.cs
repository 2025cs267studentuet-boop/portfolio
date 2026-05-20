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
    public partial class EvaluationControl : UserControl
    {
        public EvaluationControl()
        {
            InitializeComponent();
            SeedEvaluationTable();
            LoadGroups();
            LoadEvaluationTypes();
        }
        private void LoadGroups()
        {
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT DISTINCT GroupId FROM GroupProject";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbGroups.DataSource = dt;
                    cmbGroups.DisplayMember = "GroupId";
                    cmbGroups.ValueMember = "GroupId";

                    cmbGroups.SelectedIndex = -1;
                }
                catch (Exception ex) { MessageBox.Show("Error loading groups: " + ex.Message); }
            }
        }
       
        private void LoadProjectDetails(string groupId)
        {
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT p.Id, p.Title FROM Project p 
                             JOIN GroupProject gp ON p.Id = gp.ProjectId 
                             WHERE gp.GroupId = @gId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@gId", groupId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtProjectId.Text = reader["Id"].ToString();
                        txtProjectTitle.Text = reader["Title"].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Project Info Error: " + ex.Message); }
            }
        }
        private void LoadEvaluationTypes()
        {
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id, Name, TotalMarks FROM Evaluation";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbEvalType.DataSource = null;
                    cmbEvalType.DisplayMember = "Name";
                    cmbEvalType.ValueMember = "Id";
                    cmbEvalType.DataSource = dt;

                    cmbEvalType.SelectedIndex = -1;
                    txtTotalMarks.Clear();
                }
                catch (Exception ex) { MessageBox.Show("Eval Load Error: " + ex.Message); }
            }
        }

        private void cmbEvalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEvalType.SelectedIndex != -1 && cmbEvalType.SelectedItem is DataRowView drv)
            {
                txtTotalMarks.Text = drv["TotalMarks"].ToString();
            }
            else
            {
                txtTotalMarks.Clear();
            }
        }

        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGroups.SelectedIndex != -1 && cmbGroups.SelectedValue != null)
            {
                string groupId = cmbGroups.SelectedValue.ToString();

                if (cmbGroups.SelectedValue is DataRowView drv)
                    groupId = drv["GroupId"].ToString();

                LoadProjectDetails(groupId);
                LoadStudents(groupId);
            }
        }
        private void LoadStudents(string groupId)
        {
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT p.Id, CONCAT(p.FirstName, ' ', p.LastName) as FullName 
                             FROM Person p 
                             JOIN GroupStudent gs ON p.Id = gs.StudentId 
                             WHERE gs.GroupId = @gId";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@gId", groupId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbStudents.DataSource = dt;
                    cmbStudents.DisplayMember = "FullName";
                    cmbStudents.ValueMember = "Id";

                    cmbStudents.SelectedIndex = -1;
                }
                catch (Exception ex) { MessageBox.Show("Student Load Error: " + ex.Message); }
            }
        }

       

        private void chkGroupMark_CheckedChanged(object sender, EventArgs e)
        {
            cmbStudents.Enabled = !chkGroupMark.Checked;

            if (chkGroupMark.Checked)
            {
                cmbStudents.SelectedIndex = -1;
            }
        
    }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbGroups.SelectedIndex == -1 || cmbEvalType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both a Group and an Evaluation Type!");
                return;
            }
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO groupevaluation (GroupId, EvaluationId, ObtainedMarks, EvaluationDate) " +
                                   "VALUES (@gId, @eId, @marks, @date)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@gId", cmbGroups.SelectedValue);
                    cmd.Parameters.AddWithValue("@eId", cmbEvalType.SelectedValue);
                    cmd.Parameters.AddWithValue("@marks", numObtainedMarks.Value);
                    cmd.Parameters.AddWithValue("@date", dtpEvalDate.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Evaluation Saved Successfully to Group Evaluation!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save Error: " + ex.Message);
                }
            }
        
        
        }
        private void SeedEvaluationTable()
        {
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Evaluation";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        string insertQuery = @"INSERT INTO Evaluation (Name, TotalMarks, TotalWeightage) VALUES 
                                     ('Midterm Presentation', 25, 10),
                                     ('Final Report', 50, 20),
                                     ('Final Viva', 100, 70)";
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                        insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }
            }
        }

        private void EvaluationControl_Load(object sender, EventArgs e)
        {

        }
    }
}
