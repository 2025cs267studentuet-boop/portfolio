using System;
using MySql.Data.MySqlClient;
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
    public partial class ProjectAssignmentControl : UserControl
    {
        public ProjectAssignmentControl()
        {
            InitializeComponent();
            LoadProjects();
            LoadAdvisors();
            LoadGroups();
        }
        private void LoadProjects()
        {
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    string query = "SELECT Id, Title FROM Project";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbProjects.DataSource = dt;
                    cmbProjects.DisplayMember = "Title"; 
                    cmbProjects.ValueMember = "Id"; 
                }
                catch (Exception ex) { MessageBox.Show("Project Load Error: " + ex.Message); }
            }
        }

        private void LoadAdvisors()
        {
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    string query = "SELECT a.Id, CONCAT(p.FirstName, ' ', p.LastName) as Name FROM Advisor a JOIN Person p ON a.Id = p.Id";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataTable dt1 = dt.Copy();
                    DataTable dt2 = dt.Copy();
                    DataTable dt3 = dt.Copy();

                    cmbMainAdvisor.DataSource = dt1;
                    cmbMainAdvisor.DisplayMember = "Name";
                    cmbMainAdvisor.ValueMember = "Id";

                    cmbCoAdvisor.DataSource = dt2;
                    cmbCoAdvisor.DisplayMember = "Name";
                    cmbCoAdvisor.ValueMember = "Id";

                    cmbIndustryAdvisor.DataSource = dt3;
                    cmbIndustryAdvisor.DisplayMember = "Name";
                    cmbIndustryAdvisor.ValueMember = "Id";
                }
                catch (Exception ex) { MessageBox.Show("Advisor Load Error: " + ex.Message); }
            }

        }
        private void cmbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
          if (cmbProjects.SelectedValue != null)
            {
                if (cmbProjects.SelectedValue is DataRowView drv)
                {
        
                    txtProjectId.Text = drv["Id"].ToString();
                }
                else
                {                    txtProjectId.Text = cmbProjects.SelectedValue.ToString();
                }
            }
        
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (cmbGroups.SelectedIndex == -1 || cmbProjects.SelectedIndex == -1 || cmbMainAdvisor.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Group, Project, and at least a Main Advisor!");
                return;
            }

            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    MySqlTransaction trans = conn.BeginTransaction();

                    try
                    {
                        string q1 = "INSERT INTO GroupProject (ProjectId, GroupId, AssignmentDate) VALUES (@pId, @gId, @date)";
                        MySqlCommand cmd1 = new MySqlCommand(q1, conn, trans);
                        cmd1.Parameters.AddWithValue("@pId", cmbProjects.SelectedValue);
                        cmd1.Parameters.AddWithValue("@gId", cmbGroups.SelectedValue);
                        cmd1.Parameters.AddWithValue("@date", dtpAssignmentDate.Value);
                        cmd1.ExecuteNonQuery();

                        string q2 = "INSERT INTO ProjectAdvisor (AdvisorId, ProjectId, AdvisorRole, AssignmentDate) VALUES (@aId, @pId, 11, @date)";
                        MySqlCommand cmd2 = new MySqlCommand(q2, conn, trans);
                        cmd2.Parameters.AddWithValue("@aId", cmbMainAdvisor.SelectedValue);
                        cmd2.Parameters.AddWithValue("@pId", cmbProjects.SelectedValue);
                        cmd2.Parameters.AddWithValue("@date", dtpAssignmentDate.Value);
                        cmd2.ExecuteNonQuery();

                        if (cmbCoAdvisor.SelectedValue != null)
                        {
                            MySqlCommand cmd3 = new MySqlCommand(q2, conn, trans); 
                            cmd3.Parameters.AddWithValue("@aId", cmbCoAdvisor.SelectedValue);
                            cmd3.Parameters.AddWithValue("@pId", cmbProjects.SelectedValue);
                            cmd3.Parameters.AddWithValue("@date", dtpAssignmentDate.Value);
                            cmd3.Parameters["@aId"].Value = cmbCoAdvisor.SelectedValue; 
                                                                                        
                            cmd3.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show("Project and Advisors assigned successfully!");
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Database Error: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Error: " + ex.Message);
                }
            }
        
        }
        private void LoadGroups()
        {
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id FROM `Group` ORDER BY Id ASC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbGroups.DataSource = dt;
                    cmbGroups.DisplayMember = "Id"; 
                    cmbGroups.ValueMember = "Id";   

                    cmbGroups.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading groups: " + ex.Message);
                }
            }
        }

        
        
  

        private void rtbMemberSummary_TextChanged(object sender, EventArgs e)
        {

        }
        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGroups.SelectedValue != null && cmbGroups.SelectedIndex != -1)
            {
                string id = cmbGroups.SelectedValue.ToString();

                if (cmbGroups.SelectedValue is DataRowView drv)
                {
                    id = drv["Id"].ToString();
                }

                ShowGroupMembers(id);
            }
        
        }
        private void ShowGroupMembers(string groupId)
        {
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT p.FirstName, p.LastName 
                             FROM GroupStudent gs 
                             JOIN Person p ON gs.StudentId = p.Id 
                             WHERE gs.GroupId = @gId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@gId", groupId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    rtbMemberSummary.Clear(); 

                    if (!reader.HasRows)
                    {
                        rtbMemberSummary.Text = "No members found.";
                    }

                    while (reader.Read())
                    {
                        string name = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                        rtbMemberSummary.AppendText("• " + name + Environment.NewLine);
                    }
                }
                catch (Exception ex)
                {
                    rtbMemberSummary.Text = "Error: " + ex.Message;
                }
            }
        
    }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
