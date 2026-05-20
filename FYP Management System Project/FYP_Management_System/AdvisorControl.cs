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
    public partial class AdvisorControl : UserControl
    {
        public AdvisorControl()
        {
            InitializeComponent();
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }
        private void FillComboBoxes()
        {
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Id, Value FROM lookup WHERE Category = 'DESIGNATION'";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbDesignation.DataSource = dt;
                    cmbDesignation.DisplayMember = "Value";
                    cmbDesignation.ValueMember = "Id";

                    if (cmbGender.Items.Count == 0)
                    {
                        cmbGender.Items.Add("Male");
                        cmbGender.Items.Add("Female");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading designations: " + ex.Message);
                }
            }
        }


        public void DisplayData()
        {
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    string query = @"SELECT p.Id, p.FirstName, p.LastName, p.Contact, p.Email, 
                             l.Value as Designation, a.Salary, p.DateOfBirth, 
                             (SELECT Value FROM lookup WHERE Id = p.Gender) as Gender
                             FROM person p
                             JOIN advisor a ON p.Id = a.Id
                             JOIN lookup l ON a.Designation = l.Id";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAdvisors.DataSource = dt;

                    if (dgvAdvisors.Columns["Id"] != null) dgvAdvisors.Columns["Id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error displaying data: " + ex.Message);
                }
            }

        }

        private void dgvAdvisors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAdvisors.Rows[e.RowIndex];


                txtFirstName.Tag = row.Cells["Id"].Value;

                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtContact.Text = row.Cells["Contact"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSalary.Text = row.Cells["Salary"].Value.ToString();

                cmbDesignation.Text = row.Cells["Designation"].Value.ToString();
                cmbGender.Text = row.Cells["Gender"].Value.ToString();
                dtpDOB.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtSalary.Text))
                {
                    MessageBox.Show("Please fill in the required fields (First Name and Salary).");
                    return;
                }

                string connectionString = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        MySqlTransaction trans = conn.BeginTransaction();

                        try
                        {
                 
                            string personQuery = @"INSERT INTO Person (FirstName, LastName, Contact, Email, DateOfBirth, Gender) 
                                       VALUES (@fn, @ln, @co, @em, @dob, @ge);
                                       SELECT LAST_INSERT_ID();";

                            MySqlCommand cmdPerson = new MySqlCommand(personQuery, conn, trans);
                            cmdPerson.Parameters.AddWithValue("@fn", txtFirstName.Text);
                            cmdPerson.Parameters.AddWithValue("@ln", txtLastName.Text);
                            cmdPerson.Parameters.AddWithValue("@co", txtContact.Text);
                            cmdPerson.Parameters.AddWithValue("@em", txtEmail.Text);
                            cmdPerson.Parameters.AddWithValue("@dob", dtpDOB.Value);

                            cmdPerson.Parameters.AddWithValue("@ge", (cmbGender.Text == "Male" ? 1 : 2));

                            int newId = Convert.ToInt32(cmdPerson.ExecuteScalar());

                            string advisorQuery = "INSERT INTO Advisor (Id, Designation, Salary) VALUES (@id, @desig, @sal)";
                            MySqlCommand cmdAdvisor = new MySqlCommand(advisorQuery, conn, trans);

                            cmdAdvisor.Parameters.AddWithValue("@id", newId);
                            cmdAdvisor.Parameters.AddWithValue("@desig", cmbDesignation.SelectedValue);
                            cmdAdvisor.Parameters.AddWithValue("@sal", decimal.Parse(txtSalary.Text));

                            cmdAdvisor.ExecuteNonQuery();

                            trans.Commit();
                            MessageBox.Show("Advisor added successfully!");
                            DisplayData();
                            btnClear_Click(sender, e);
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("Transaction Failed: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection Error: " + ex.Message);
                    }
                }


            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
           
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtSalary.Text = "";

            txtSearch.Text = "Search";

            cmbGender.SelectedIndex = -1;   
            cmbDesignation.SelectedIndex = -1; 

            dtpDOB.Value = DateTime.Now;

            txtFirstName.Tag = null;

            txtFirstName.Focus();
        
        }

        private void FillDesignationCombo()
        {
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id, Value FROM lookup WHERE Category = 'DESIGNATION'";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbDesignation.DataSource = dt;
                    cmbDesignation.DisplayMember = "Value";
                    cmbDesignation.ValueMember = "Id";      

                    cmbDesignation.SelectedIndex = -1; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void AdvisorControl_Load(object sender, EventArgs e)
        {
         
            FillDesignationCombo(); 
            DisplayData();          
        
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
         
            if (txtFirstName.Tag == null)
            {
                MessageBox.Show("Please select an advisor from the list first.");
                return;
            }

            int advisorId = Convert.ToInt32(txtFirstName.Tag);
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    MySqlTransaction trans = conn.BeginTransaction();

                    try
                    {
                        
                        string updatePerson = @"UPDATE Person SET FirstName=@fn, LastName=@ln, 
                                        Contact=@co, Email=@em, DateOfBirth=@dob, Gender=@ge 
                                        WHERE Id=@id";
                        MySqlCommand cmd1 = new MySqlCommand(updatePerson, conn, trans);
                        cmd1.Parameters.AddWithValue("@fn", txtFirstName.Text);
                        cmd1.Parameters.AddWithValue("@ln", txtLastName.Text);
                        cmd1.Parameters.AddWithValue("@co", txtContact.Text);
                        cmd1.Parameters.AddWithValue("@em", txtEmail.Text);
                        cmd1.Parameters.AddWithValue("@dob", dtpDOB.Value);
                        cmd1.Parameters.AddWithValue("@ge", (cmbGender.Text == "Male" ? 1 : 2));
                        cmd1.Parameters.AddWithValue("@id", advisorId);
                        cmd1.ExecuteNonQuery();

                       
                        string updateAdvisor = "UPDATE Advisor SET Designation=@desig, Salary=@sal WHERE Id=@id";
                        MySqlCommand cmd2 = new MySqlCommand(updateAdvisor, conn, trans);
                        cmd2.Parameters.AddWithValue("@desig", cmbDesignation.SelectedValue);
                        cmd2.Parameters.AddWithValue("@sal", txtSalary.Text);
                        cmd2.Parameters.AddWithValue("@id", advisorId);
                        cmd2.ExecuteNonQuery();

                        trans.Commit();
                        MessageBox.Show("Advisor updated successfully!");
                        DisplayData();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Update Failed: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Error: " + ex.Message);
                }
            }
        
    }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          
            if (txtFirstName.Tag == null) return;

            int advisorId = Convert.ToInt32(txtFirstName.Tag);
            string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";

            if (MessageBox.Show("Are you sure you want to delete this advisor?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        MySqlTransaction trans = conn.BeginTransaction();
                        try
                        {
                            
                            string delAdvisor = "DELETE FROM Advisor WHERE Id=@id";
                            MySqlCommand cmd1 = new MySqlCommand(delAdvisor, conn, trans);
                            cmd1.Parameters.AddWithValue("@id", advisorId);
                            cmd1.ExecuteNonQuery();

                           
                            string delPerson = "DELETE FROM Person WHERE Id=@id";
                            MySqlCommand cmd2 = new MySqlCommand(delPerson, conn, trans);
                            cmd2.Parameters.AddWithValue("@id", advisorId);
                            cmd2.ExecuteNonQuery();

                            trans.Commit();
                            MessageBox.Show("Advisor deleted successfully!");
                            DisplayData();
                            
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("Delete Failed: " + ex.Message);
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
