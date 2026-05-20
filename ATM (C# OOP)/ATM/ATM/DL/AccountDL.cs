using ATM.BL;
using ATM.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ATM.DL
{
    public class AccountDL
    {
        private static string connectionString = "server=localhost;database=atm;user=root;password=amjadali14@;";


        //******************************ADD NEW CUSTOMER************************

        public static void AddCustomer(Account acc)
        {
            if (acc == null)
                throw new Exception("Account object must not be Null!");

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Customers (Name, Gender, CNIC, Contact, PIN) " +
                               "VALUES (@Name, @Gender, @CNIC, @Contact, @PIN)";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name",    acc.Profile.Name);
                    cmd.Parameters.AddWithValue("@Gender",  acc.Profile.Gender);
                    cmd.Parameters.AddWithValue("@CNIC",    acc.Profile.CNIC);
                    cmd.Parameters.AddWithValue("@Contact", acc.Profile.Contact);
                    cmd.Parameters.AddWithValue("@PIN",     acc.Profile.Pin);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddCustomer(string name, string gender, string cnic, string contact, string pin)
        {
            Account acc = AccountFactory.Create("Saving", name, gender, cnic, contact, pin);
            AddCustomer(acc);
        }


        //******************************LOAD ALL CUSTOMERS************************

        public static List<Account> LoadAllCustomers()
        {
            List<Account> accounts = new List<Account>();
            Account.totalUsers = 0;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Customers";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read() && Account.totalUsers < Account.SIZE)
                    {
                        int i = Account.totalUsers;

                        Account.name[i]          = reader["Name"].ToString();
                        Account.gender[i]         = reader["Gender"].ToString();
                        Account.cnic[i]           = reader["CNIC"].ToString();
                        Account.contact[i]        = reader["Contact"].ToString();
                        Account.pin[i]            = reader["PIN"].ToString();
                        Account.accountType[i]    = reader["AccountType"].ToString();
                        Account.balance[i]        = reader["Balance"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Balance"]);
                        Account.accountNumber[i]  = reader["AccountNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["AccountNumber"]);
                        Account.hasAccount[i]     = reader["HasAccount"] == DBNull.Value ? false : Convert.ToBoolean(reader["HasAccount"]);
                        Account.totalUsers++;

                        string accType = reader["AccountType"].ToString();
                        int    bal     = reader["Balance"] == DBNull.Value ? 100 : Convert.ToInt32(reader["Balance"]);

                        Account acc = AccountFactory.Create(
                            string.IsNullOrWhiteSpace(accType) ? "Saving" : accType,
                            reader["Name"].ToString(),
                            reader["Gender"].ToString(),
                            reader["CNIC"].ToString(),
                            reader["Contact"].ToString(),
                            reader["PIN"].ToString(),
                            bal
                        );

                        if (reader["AccountNumber"] != DBNull.Value)
                            acc.AccountNumber = Convert.ToInt32(reader["AccountNumber"]);

                        acc.HasAccount = reader["HasAccount"] == DBNull.Value
                            ? false
                            : Convert.ToBoolean(reader["HasAccount"]);

                        accounts.Add(acc);
                    }
                }
            }

            return accounts;
        }


        //******************************UPDATE CUSTOMER PROFILE************************

        public static void UpdateCustomer(Account acc)
        {
            if (acc == null)
                throw new Exception("Account object must not be Null!");

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Customers SET Name=@Name, Contact=@Contact WHERE CNIC=@CNIC";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name",    acc.Profile.Name);
                    cmd.Parameters.AddWithValue("@Contact", acc.Profile.Contact);
                    cmd.Parameters.AddWithValue("@CNIC",    acc.Profile.CNIC);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCustomer(string cnic, string newName, string newContact)
        {
            Account acc = AccountFactory.Create("Saving", newName, "MALE", cnic, newContact, "0000");
            UpdateCustomer(acc);
        }


        //******************************DELETE CUSTOMER************************

        public static void DeleteCustomer(string cnic)
        {
            if (string.IsNullOrWhiteSpace(cnic))
                throw new Exception("CNIC must not be empty!");

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                string delTrans = "DELETE FROM Transactions WHERE AccountNumber = " +
                                  "(SELECT AccountNumber FROM Customers WHERE CNIC=@CNIC)";
                using (MySqlCommand cmd = new MySqlCommand(delTrans, con))
                {
                    cmd.Parameters.AddWithValue("@CNIC", cnic);
                    cmd.ExecuteNonQuery();
                }

                string delCust = "DELETE FROM Customers WHERE CNIC=@CNIC";
                using (MySqlCommand cmd = new MySqlCommand(delCust, con))
                {
                    cmd.Parameters.AddWithValue("@CNIC", cnic);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //******************************UPDATE ACCOUNT (SAVING/CURRENT)************************

        public static void UpdateAccount(Account acc)
        {
            if (acc == null)
                throw new Exception("Account object must not be Null!");

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Customers SET AccountNumber=@AccNum, AccountType=@AccType, " +
                               "Balance=@Balance, HasAccount=1 WHERE CNIC=@CNIC";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AccNum",  acc.AccountNumber);
                    cmd.Parameters.AddWithValue("@AccType", acc.AccountType);   
                    cmd.Parameters.AddWithValue("@Balance", acc.Balance);
                    cmd.Parameters.AddWithValue("@CNIC",    acc.Profile.CNIC);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateAccount(string cnic, int accountNumber, string accountType, int balance)
        {
            Account acc = AccountFactory.Create(accountType, "temp", "MALE", cnic, "0000000000", "0000", balance);
            acc.AccountNumber = accountNumber;
            UpdateAccount(acc);
        }


        //******************************UPDATE BALANCE************************

        public static void UpdateBalance(Account acc)
        {
            if (acc == null)
                throw new Exception("Account object must not be Null!");

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Customers SET Balance=@Balance WHERE AccountNumber=@AccNum";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Balance", acc.Balance);
                    cmd.Parameters.AddWithValue("@AccNum",  acc.AccountNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateBalance(int accountNumber, int newBalance)
        {
            Account acc = AccountFactory.Create("Saving", "temp", "MALE", "0000000000000", "0000000000", "0000", newBalance);
            acc.AccountNumber = accountNumber;
            UpdateBalance(acc);
        }


        //******************************UPDATE PIN************************

        public static void UpdatePin(Account acc)
        {
            if (acc == null)
                throw new Exception("Account object must not be Null!");

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Customers SET PIN=@PIN WHERE CNIC=@CNIC";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PIN",  acc.Profile.Pin);
                    cmd.Parameters.AddWithValue("@CNIC", acc.Profile.CNIC);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdatePin(string cnic, string newPin)
        {
            Account acc = AccountFactory.Create("Saving", "temp", "MALE", cnic, "0000000000", newPin);
            UpdatePin(acc);
        }
    }
}
