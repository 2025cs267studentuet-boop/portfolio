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
    public partial class ProjectControl : UserControl
    {
        string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";

        public ProjectControl()
        {
            InitializeComponent();
        }

        public void DisplayData()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    string query = "SELECT Id, Title, Description FROM Project";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProjects.DataSource = dt;

                    if (dgvProjects.Columns["Id"] != null) dgvProjects.Columns["Id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error displaying projects: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a Project Title.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Project (Title, Description) VALUES (@title, @desc)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Project added successfully!");
                    DisplayData();
                    btnClear_Click(sender, e); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding project: " + ex.Message);
                }
            }
        }

        private void dgvProjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProjects.Rows[e.RowIndex];

                txtTitle.Tag = row.Cells["Id"].Value;
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTitle.Tag == null)
            {
                MessageBox.Show("Please select a project from the list first.");
                return;
            }

            int projectId = Convert.ToInt32(txtTitle.Tag);

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Project SET Title=@title, Description=@desc WHERE Id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@id", projectId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Project updated successfully!");
                    DisplayData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update Failed: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a project from the grid to delete.");
                return;
            }

            string projectId = dgvProjects.SelectedRows[0].Cells["Id"].Value.ToString();

            DialogResult confirm = MessageBox.Show("Deleting this project will remove all its assignments to Groups and Advisors. Proceed?",
                "Permanent Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlTransaction tr = conn.BeginTransaction();
                    try
                    {
                        MySqlCommand cmd1 = new MySqlCommand("DELETE FROM projectadvisor WHERE ProjectId = @pid", conn, tr);
                        cmd1.Parameters.AddWithValue("@pid", projectId);
                        cmd1.ExecuteNonQuery();
                        MySqlCommand cmd2 = new MySqlCommand("DELETE FROM GroupProject WHERE ProjectId = @pid", conn, tr);
                        cmd2.Parameters.AddWithValue("@pid", projectId);
                        cmd2.ExecuteNonQuery();
                        MySqlCommand cmd3 = new MySqlCommand("DELETE FROM Project WHERE Id = @pid", conn, tr);
                        cmd3.Parameters.AddWithValue("@pid", projectId);
                        cmd3.ExecuteNonQuery();

                        tr.Commit();
                        MessageBox.Show("Project and all its links were successfully cleared!");
                        DisplayData(); 
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        MessageBox.Show("Database Error: " + ex.Message);
                    }
                }
            }
        
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtTitle.Tag = null;
            txtSearch.Text = "Search";
            txtTitle.Focus();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search") return;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT Id, Title, Description FROM Project WHERE Title LIKE @search";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProjects.DataSource = dt;
            }
        }

        private void ProjectControl_Load(object sender, EventArgs e)
        {

        }
    }
}