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
    public class TransactionDL
    {
        private static string connectionString = "server=localhost;database=atm;user=root;password=amjadali14@;";


        //******************************ADD TRANSACTION************************

        public static void AddTransaction(Transaction t)
        {
            if (t == null)
                throw new Exception("Transaction object must not be Null!");

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                string query = "INSERT INTO Transactions (AccountNumber, TransactionType, Amount, TransactionDate) " +
                               "VALUES (@AccNum, @Type, @Amount, @Date)";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AccNum", t.AccountNumber);
                    cmd.Parameters.AddWithValue("@Type",   t.Type);   
                    cmd.Parameters.AddWithValue("@Amount", t.Amount);
                    cmd.Parameters.AddWithValue("@Date",   t.Date);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddTransaction(int accountNumber, string type, int amount)
        {
            Transaction t = Transaction.Create(accountNumber, type, amount);
            AddTransaction(t);
        }


        //******************************LOAD TRANSACTION HISTORY************************

        public static List<Transaction> LoadTransactionHistory()
        {
            List<Transaction> history = new List<Transaction>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT AccountNumber, TransactionType, Amount, TransactionDate " +
                               "FROM Transactions ORDER BY TransactionDate DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Transaction t = Transaction.Create(
                            Convert.ToInt32(reader["AccountNumber"]),
                            reader["TransactionType"].ToString(),
                            Convert.ToInt32(reader["Amount"])
                        );
                        history.Add(t);
                    }
                }
            }

            return history;
        }


        //******************************DISPLAY TRANSACTION HISTORY************************

        public static void DisplayTransactionHistory()
        {
            List<Transaction> history = LoadTransactionHistory();

            Console.WriteLine("************************************************************************************");
            Console.WriteLine("                          TRANSACTION HISTORY                                       ");
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("{0,-20}{1,-15}{2,-15}{3,-25}", "Account Number", "Type", "Amount", "Date");
            Console.WriteLine("------------------------------------------------------------------------------------");

            if (history.Count == 0)
            {
                Console.WriteLine("No transactions found.");
            }
            else
            {
                foreach (Transaction t in history)
                {
                    Console.WriteLine("{0,-20}{1,-15}{2,-15}{3,-25}",
                        t.AccountNumber,
                        t.Type,
                        t.Amount,
                        t.Date.ToString("dd-MM-yyyy HH:mm"));
                }
            }

            Console.WriteLine("------------------------------------------------------------------------------------");
        }
    }
}
