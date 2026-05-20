using ATM.DL;
using ATM.UI;
using ATM.BL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ATM
{
    public class Program
    {
        // --------------------------------------------------------
        // DEFAULT ATM PIN     : 2025
        // DEFAULT ATM BALANCE : 100
        // --------------------------------------------------------

        static void Main(string[] args)
        {
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("                          Initializing ATM System                                     ");
            Console.WriteLine("**************************************************************************************");

            bool loaded = LoadData();

            if (!loaded)
            {
                Console.WriteLine("System startup failed. Press any key to exit.");
                Console.ReadKey();
                return;
            }

            MenuUI.ShowMainMenu();
        }

        private static bool LoadData()
        {
            try
            {

                List<Account> accounts = AccountDL.LoadAllCustomers();

                Console.WriteLine("Data loaded successfully. Total customers: " + accounts.Count);
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("**************************************************************************************");
                Console.WriteLine("  DATABASE ERROR: Could not connect to database!");
                Console.WriteLine("  Details: " + ex.Message);
                Console.WriteLine("**************************************************************************************");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**************************************************************************************");
                Console.WriteLine("  SYSTEM ERROR: " + ex.Message);
                Console.WriteLine("**************************************************************************************");
                return false;
            }
        }
    }
}