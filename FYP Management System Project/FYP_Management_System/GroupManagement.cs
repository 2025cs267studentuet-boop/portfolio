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
    public partial class GroupManagement : UserControl
    {
        private string connStr = "server=localhost;user=root;password=amjadali14@;database=projectadb26;";
        public GroupManagement()
        {
            InitializeComponent();
        }
        private void GroupManagement_Load(object sender, EventArgs e)
        {
            LoadAvailableStudents();
            LoadExisting();
        }
        private void LoadAvailableStudents()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = @"SELECT s.Id, s.RegistrationNo, p.FirstName, p.LastName 
                                 FROM Student s 
                                 JOIN Person p ON s.Id = p.Id 
                                 WHERE s.Id NOT IN (SELECT StudentId FROM GroupStudent WHERE Status = 3)";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAvailableStudents.DataSource = dt;
            }
        }
        private void LoadExisting()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT g.Id AS `Group ID`, 
                 g.Created_On AS `Created Date`, 
                 IFNULL(GROUP_CONCAT(p.FirstName, ' ', p.LastName SEPARATOR ', '), 'No Members') AS `Members`
                 FROM `group` g
                 LEFT JOIN groupstudent gs ON g.Id = gs.GroupId
                 LEFT JOIN person p ON gs.StudentId = p.Id
                 GROUP BY g.Id";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvExistingGroups.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            if (dgvExistingGroups.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a group to delete.");
                return;
            }

            string groupId = dgvExistingGroups.SelectedRows[0].Cells[0].Value.ToString();
            DialogResult confirm = MessageBox.Show($"Delete Group {groupId}?", "Confirm", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlTransaction tr = conn.BeginTransaction();
                    try
                    {
                        string[] tables = { "groupevaluation", "GroupStudent", "GroupProject" };
                        foreach (string table in tables)
                        {
                            MySqlCommand cmd = new MySqlCommand($"DELETE FROM {table} WHERE GroupId = @id", conn, tr);
                            cmd.Parameters.AddWithValue("@id", groupId);
                            cmd.ExecuteNonQuery();
                        }

                        MySqlCommand cmdGroup = new MySqlCommand("DELETE FROM `Group` WHERE Id = @id", conn, tr);
                        cmdGroup.Parameters.AddWithValue("@id", groupId);
                        cmdGroup.ExecuteNonQuery();

                        tr.Commit();
                        MessageBox.Show("Group deleted!");
                        LoadExisting();
                        LoadAvailableStudents();
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnAddToGroup_Click(object sender, EventArgs e)
        {
            if (dgvAvailableStudents.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvAvailableStudents.SelectedRows[0];
                StudentItem item = new StudentItem
                {
                    Id = Convert.ToInt32(row.Cells["Id"].Value),
                    RegNo = row.Cells["RegistrationNo"].Value.ToString(),
                    FirstName = row.Cells["FirstName"].Value.ToString(),
                    LastName = row.Cells["LastName"].Value.ToString()
                };

                lbSelectedStudents.Items.Add(item);
                dgvAvailableStudents.Rows.RemoveAt(row.Index);
            }
        }

        private void btnRemoveFromGroup_Click(object sender, EventArgs e)
        {
            if (lbSelectedStudents.SelectedItem != null)
            {
                StudentItem item = (StudentItem)lbSelectedStudents.SelectedItem;
                DataTable dt = (DataTable)dgvAvailableStudents.DataSource;

                DataRow dr = dt.NewRow();
                dr["Id"] = item.Id;
                dr["RegistrationNo"] = item.RegNo;
                dr["FirstName"] = item.FirstName;
                dr["LastName"] = item.LastName;

                dt.Rows.Add(dr);
                lbSelectedStudents.Items.Remove(item);
            }
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            if (lbSelectedStudents.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one student to the group.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string groupQuery = "INSERT INTO `Group` (Created_On) VALUES (@date);";
                    MySqlCommand cmdGroup = new MySqlCommand(groupQuery, conn, trans);
                    cmdGroup.Parameters.AddWithValue("@date", dtpCreatedOn.Value);
                    cmdGroup.ExecuteNonQuery();

                    long newGroupId = cmdGroup.LastInsertedId;

                    foreach (StudentItem student in lbSelectedStudents.Items)
                    {
                        string studentQuery = @"INSERT INTO GroupStudent (GroupId, StudentId, Status, AssignmentDate) 
                                                VALUES (@gId, @sId, @status, @aDate)";
                        MySqlCommand cmdStudent = new MySqlCommand(studentQuery, conn, trans);
                        cmdStudent.Parameters.AddWithValue("@gId", newGroupId);
                        cmdStudent.Parameters.AddWithValue("@sId", student.Id);
                        cmdStudent.Parameters.AddWithValue("@status", 3);
                        cmdStudent.Parameters.AddWithValue("@aDate", DateTime.Now);
                        cmdStudent.ExecuteNonQuery();
                    }

                    trans.Commit();
                    txtGroupId.Text = newGroupId.ToString();
                    MessageBox.Show($"Group {newGroupId} created successfully!");

                    lbSelectedStudents.Items.Clear();
                    LoadAvailableStudents();
                    LoadExisting();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Error forming group: " + ex.Message);
                }
            }
        }

        private void dgvExistingGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtGroupId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchAvailable_TextChanged(object sender, EventArgs e)
        {
            string filterValue = txtSearchAvailable.Text.Replace("'", "''");
            if (dgvAvailableStudents.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("RegistrationNo LIKE '%{0}%' OR FirstName LIKE '%{0}%'", filterValue);
            }
        }
       
    }
    public class StudentItem
    {
        public int Id { get; set; }
        public string RegNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{RegNo} - {FirstName} {LastName}";
        }
    }
}









