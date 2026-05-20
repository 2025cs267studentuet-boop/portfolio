using System;
using ATM.BL;
using ATM.DL;
using System.Collections.Generic;

namespace ATM.UI
{
    public class MenuUI
    {
       
        private const string ATM_PIN = "2025";

        private static int GetIntInput()
        {
            int result;
            string input = Console.ReadLine();
            if (!int.TryParse(input, out result))
            {
                Console.WriteLine("INVALID INPUT —Enter the Number");
                return -1;
            }
            return result;
        }

      
        private static bool VerifyAtmPin(string inputPin)
        {
            return inputPin == ATM_PIN;
        }


        public static void ShowMainMenu()
        {
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("                               ATM Management System                                  ");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("                         Please Enter your Bank Credential!                           ");
            Console.WriteLine("**************************************************************************************");

            Console.Write("Enter 4-digit PIN: ");
            string pin = Console.ReadLine();

            if (!VerifyAtmPin(pin))
            {
                Console.WriteLine("*************************************INVALID PIN**********************************");
                return;
            }

            int k = -1;
            while (k != 0)
            {
                ShowMainMenuOptions();
                k = GetIntInput();  

                if (k == 1) ShowAdminPortal();     
                else if (k == 2) ShowCustomerPortal();  
                else if (k == 0) ShowExitMessage();
                else Console.WriteLine("************************************* INVALID INPUT **********************************");
            }
        }



        private static void ShowMainMenuOptions()
        {
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("                                        MAIN MENU                                     ");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("Please Enter '1' to use as an Administrator");
            Console.WriteLine("Please Enter '2' to use as a Customer");
            Console.WriteLine("Please Enter '0' to exit the Program");
            Console.WriteLine("**************************************************************************************");
            Console.Write("Enter the option:\t");
        }



        private static void ShowAdminPortal()
        {
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("                             WELCOME TO ADMINISTRATOR PORTAL                          ");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("Please enter '1' to see All Customer Profiles");
            Console.WriteLine("Please enter '2' to see All Customer Accounts");
            Console.WriteLine("Please enter '3' to see All Customer Profiles With Accounts");
            Console.WriteLine("Please enter '4' to search for Customer Profiles");
            Console.WriteLine("Please enter '5' to see Transaction History");
            Console.WriteLine("Please enter '0' to return to MAIN MENU");
            Console.Write("Please Enter the option:\t");

            int y = GetIntInput(); 

            if (y == 1) AccountUI.allcustomerProfiles();
            else if (y == 2) AccountUI.allcustomerAccounts();
            else if (y == 3) AccountUI.allcustomerprofileswithAccounts();
            else if (y == 4) AccountUI.searchcustomerProfile();
            else if (y == 5) TransactionUI.transactionHistory();
            else if (y == 0) Console.WriteLine("Returning to MAIN MENU");
            else Console.WriteLine("************************************* INVALID INPUT **********************************");
        }

        private static void ShowCustomerPortal()
        {
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("                             WELCOME TO ACCOUNT HOLDER PORTAL                         ");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("Please enter '1' to use Account Registration System");
            Console.WriteLine("Please enter '2' to use Customer Management System");
            Console.WriteLine("Please enter '3' to use Transaction Processing System");
            Console.WriteLine("Please enter '4' to use Authentication System");
            Console.WriteLine("Please enter '0' to return to MAIN MENU");
            Console.Write("Please Enter the option:\t");

            int z = GetIntInput();

            if (z == 1) ShowAccountRegistration();   
            else if (z == 2) ShowCustomerManagement();    
            else if (z == 3) ShowTransactionSystem();     
            else if (z == 4) ShowAuthenticationSystem(); 
            else if (z == 0) Console.WriteLine("Returning to MAIN MENU");
            else Console.WriteLine("************************************* INVALID INPUT **********************************");
        }

        private static void ShowAccountRegistration()
        {
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("                           WELCOME TO ACCOUNT REGISTRATION SYSTEM                     ");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("Please enter '1' to select Saving Account");
            Console.WriteLine("Please enter '2' to select Current Account");
            Console.WriteLine("Please enter '0' to return to MAIN MENU");
            Console.Write("Please Enter the option:\t");

            int a = GetIntInput();

            if (a == 1)
            {
                Console.WriteLine("**************************************************************************************");
                Console.WriteLine("                                 WELCOME TO SAVING ACCOUNT                            ");
                Console.WriteLine("**************************************************************************************");
                AccountUI.savingAccount();
            }
            else if (a == 2)
            {
                Console.WriteLine("**************************************************************************************");
                Console.WriteLine("                                 WELCOME TO CURRENT ACCOUNT                           ");
                Console.WriteLine("**************************************************************************************");
                AccountUI.currentAccount();
            }
            else if (a == 0)
                Console.WriteLine("Returning to MAIN MENU");
            else
                Console.WriteLine("************************************* INVALID INPUT **********************************");
        }


        private static void ShowCustomerManagement()
        {
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("                           WELCOME TO CUSTOMER MANAGEMENT SYSTEM                      ");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("Please enter '1' to select New Profile");
            Console.WriteLine("Please enter '2' to select Change Profile");
            Console.WriteLine("Please enter '3' to select Delete Profile");
            Console.WriteLine("Please enter '0' to return to MAIN MENU");
            Console.Write("Please Enter the option:\t");

            int b = GetIntInput();

            if (b == 1) AccountUI.newProfile();
            else if (b == 2) AccountUI.changeProfile();
            else if (b == 3) AccountUI.deleteProfile();
            else if (b == 0) Console.WriteLine("Returning to MAIN MENU");
            else Console.WriteLine("************************************* INVALID INPUT **********************************");
        }

        private static void ShowTransactionSystem()
        {
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("                               WELCOME TO TRANSACTION SYSTEM                          ");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("Please enter '1' to Check Your Balance");
            Console.WriteLine("Please enter '2' to Withdraw Cash");
            Console.WriteLine("Please enter '3' to Deposit Money");
            Console.WriteLine("Please enter '0' to return to MAIN MENU");
            Console.Write("Please Enter the option:\t");

            int c = GetIntInput();

            if (c == 1) TransactionUI.checkBalance();
            else if (c == 2) TransactionUI.withdrawMoney();
            else if (c == 3) TransactionUI.depositMoney();
            else if (c == 0) Console.WriteLine("Returning to MAIN MENU");
            else Console.WriteLine("************************************* INVALID INPUT **********************************");
        }

        private static void ShowAuthenticationSystem()
        {
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("                             WELCOME TO AUTHENTICATION SYSTEM                         ");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("Please enter '1' to Change PIN");
            Console.WriteLine("Please enter '2' to Reset PIN");
            Console.WriteLine("Please enter '0' to return to MAIN MENU");
            Console.Write("Please Enter the option:\t");

            int d = GetIntInput();

            if (d == 1) AccountUI.changePin();
            else if (d == 2) AccountUI.resetPin();
            else if (d == 0) Console.WriteLine("Returning to MAIN MENU");
            else Console.WriteLine("************************************* INVALID INPUT **********************************");
        }

        private static void ShowExitMessage()
        {
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("                                Thanks for using ATM                                  ");
            Console.WriteLine("**************************************************************************************");
        }
    }
}