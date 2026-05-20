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
    public partial class StudentControl : UserControl
    {
        public StudentControl()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
          
            string connectionString = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    
                    string query = @"SELECT p.Id, s.RegistrationNo, p.FirstName, p.LastName, p.Contact, p.Email, 
                             p.DateOfBirth, l.Value as Gender
                             FROM student s
                             JOIN person p ON s.Id = p.Id
                             JOIN lookup l ON p.Gender = l.Id
                             WHERE l.Category = 'GENDER' 
                             AND (s.RegistrationNo LIKE @search OR p.FirstName LIKE @search)";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dgvStudents.DataSource = dt;
                }
                catch (Exception ex)
                {
   
                    Console.WriteLine(ex.Message);
                }
            }
        }
        
        public void DisplayData()
        {
            string connectionString = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT p.Id, s.RegistrationNo, p.FirstName, p.LastName, p.Contact, p.Email, 
                             p.DateOfBirth, l.Value as Gender
                             FROM student s
                             JOIN person p ON s.Id = p.Id
                             JOIN lookup l ON p.Gender = l.Id
                             WHERE l.Category = 'GENDER'";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);

                    dgvStudents.DataSource = dt;

                    if (dgvStudents.Columns["Id"] != null)
                    {
                        dgvStudents.Columns["Id"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error displaying data: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    int genderLookupId = (cmbGender.Text == "Male") ? 1 : 2;

                    string personQuery = @"INSERT INTO person (FirstName, LastName, Contact, Email, DateOfBirth, Gender) 
                                 VALUES (@fname, @lname, @contact, @email, @dob, @gender);
                                 SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdPerson = new MySqlCommand(personQuery, conn);
                    cmdPerson.Parameters.AddWithValue("@fname", txtFirstName.Text);
                    cmdPerson.Parameters.AddWithValue("@lname", txtLastName.Text);
                    cmdPerson.Parameters.AddWithValue("@contact", txtContact.Text);
                    cmdPerson.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmdPerson.Parameters.AddWithValue("@dob", dtpDOB.Value.ToString("yyyy-MM-dd"));
                    cmdPerson.Parameters.AddWithValue("@gender", genderLookupId);

                    int newPersonId = Convert.ToInt32(cmdPerson.ExecuteScalar());

                    string studentQuery = "INSERT INTO student (Id, RegistrationNo) VALUES (@id, @reg);";
                    MySqlCommand cmdStudent = new MySqlCommand(studentQuery, conn);
                    cmdStudent.Parameters.AddWithValue("@id", newPersonId);
                    cmdStudent.Parameters.AddWithValue("@reg", txtRegNo.Text);

                    cmdStudent.ExecuteNonQuery();

                    MessageBox.Show("Student registered successfully!");
                    btnClear_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                DisplayData();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRegNo.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtContact.Clear();
            txtEmail.Clear();

            txtRegNo.Tag = null;
            cmbGender.SelectedIndex = -1;
            dtpDOB.Value = DateTime.Now;
        }

        private void pnlGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtRegNo.Tag == null || txtRegNo.Tag.ToString() == "")
            {
                MessageBox.Show("Error: No Student ID found. Please click a row in the grid again.");
                return;
            }

            string connectionString = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlTransaction trans = conn.BeginTransaction();

                    int personId = Convert.ToInt32(txtRegNo.Tag);
                    int genderId = (cmbGender.Text == "Male") ? 1 : 2;

                    try
                    {
                        string updatePerson = @"UPDATE person SET 
                                        FirstName=@fn, LastName=@ln, Contact=@co, 
                                        Email=@em, DateOfBirth=@dob, Gender=@ge 
                                        WHERE Id=@id";

                        MySqlCommand cmd1 = new MySqlCommand(updatePerson, conn, trans);
                        cmd1.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim());
                        cmd1.Parameters.AddWithValue("@ln", txtLastName.Text.Trim());
                        cmd1.Parameters.AddWithValue("@co", txtContact.Text.Trim());
                        cmd1.Parameters.AddWithValue("@em", txtEmail.Text.Trim());
                        cmd1.Parameters.AddWithValue("@dob", dtpDOB.Value.ToString("yyyy-MM-dd"));
                        cmd1.Parameters.AddWithValue("@ge", genderId);
                        cmd1.Parameters.AddWithValue("@id", personId);
                        cmd1.ExecuteNonQuery();

                        string updateStudent = "UPDATE student SET RegistrationNo=@reg WHERE Id=@id";
                        MySqlCommand cmd2 = new MySqlCommand(updateStudent, conn, trans);
                        cmd2.Parameters.AddWithValue("@reg", txtRegNo.Text.Trim());
                        cmd2.Parameters.AddWithValue("@id", personId);
                        cmd2.ExecuteNonQuery();

                        trans.Commit();

                        MessageBox.Show("Student Record Updated Successfully!");

                        DisplayData(); 
                        btnClear_Click(sender, e); 
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Transaction failed: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Error: " + ex.Message);
                }
            }
        }

        private void StudentControl_Load_1(object sender, EventArgs e)
        {
            DisplayData();

            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvStudents.ColumnHeadersHeight = 35;        
            dgvStudents.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.Columns["RegistrationNo"].MinimumWidth = 100;
            dgvStudents.Columns["FirstName"].FillWeight = 120; 

            dgvStudents.RowTemplate.Height = 30;

            dgvStudents.EnableHeadersVisualStyles = false;
            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 33, 61); 
            dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

                txtRegNo.Text = row.Cells["RegistrationNo"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtContact.Text = row.Cells["Contact"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                cmbGender.Text = row.Cells["Gender"].Value.ToString();

                txtRegNo.Tag = row.Cells["Id"].Value;
                
                dtpDOB.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
                txtRegNo.Tag = row.Cells["Id"].Value;
            }
        
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          
            if (txtRegNo.Tag == null)
            {
                MessageBox.Show("Please select a student from the grid first!");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this student? This cannot be undone.",
                                                 "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string connectionString = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        int personId = Convert.ToInt32(txtRegNo.Tag);

                        MySqlTransaction trans = conn.BeginTransaction();

                        try
                        {
                         
                            string deleteStudent = "DELETE FROM student WHERE Id = @id";
                            MySqlCommand cmd1 = new MySqlCommand(deleteStudent, conn, trans);
                            cmd1.Parameters.AddWithValue("@id", personId);
                            cmd1.ExecuteNonQuery();

                           
                            string deletePerson = "DELETE FROM person WHERE Id = @id";
                            MySqlCommand cmd2 = new MySqlCommand(deletePerson, conn, trans);
                            cmd2.Parameters.AddWithValue("@id", personId);
                            cmd2.ExecuteNonQuery();

                            trans.Commit();
                            MessageBox.Show("Student deleted successfully!");

                            
                            DisplayData();
                            btnClear_Click(sender, e);
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("Delete failed: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection Error: " + ex.Message);
                    }
                }
            }
        }
    }
    
}
    

