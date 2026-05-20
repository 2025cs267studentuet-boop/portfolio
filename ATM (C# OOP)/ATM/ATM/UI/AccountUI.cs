using ATM.BL;
using ATM.DL;
using System;
using System.Collections.Generic;

namespace ATM.UI
{
    public class AccountUI
    {
        private static List<Account> accounts = new List<Account>();

        private static Account FindByCnic(string cnic)
        {
            foreach (Account acc in accounts)
            {
                if (acc.Profile.CNIC == cnic)
                    return acc;
            }
            return null;
        }

        private static int FindIndexByCnic(string cnic)
        {
            for (int i = 0; i < Account.totalUsers; i++)
            {
                if (Account.cnic[i] == cnic)
                    return i;
            }
            return -1;
        }


        //******************************ALL CUSTOMER PROFILES FUNCTION*************************//

        public static void allcustomerProfiles()
        {
            accounts = AccountDL.LoadAllCustomers();

            if (accounts.Count == 0)
            {
                Console.WriteLine("No customer profiles found.");
                return;
            }

            Console.WriteLine("************************************************************************************");
            Console.WriteLine("                          ALL CUSTOMER PROFILES                                     ");
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("{0,-20}{1,-15}{2,-20}{3,-20}", "Name", "Gender", "CNIC", "Contact Number");
            Console.WriteLine("------------------------------------------------------------------------------------");

            foreach (Account acc in accounts)
            {
                Console.WriteLine("{0,-20}{1,-15}{2,-20}{3,-20}",
                    acc.Profile.Name,
                    acc.Profile.Gender,
                    acc.Profile.CNIC,
                    acc.Profile.Contact);
            }

            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Total Profiles: " + accounts.Count);
        }


        //******************************ALL CUSTOMER ACCOUNTS FUNCTION*************************//

        public static void allcustomerAccounts()
        {
            accounts = AccountDL.LoadAllCustomers();

            if (accounts.Count == 0)
            {
                Console.WriteLine("No customer accounts found.");
                return;
            }

            Console.WriteLine("************************************************************************************");
            Console.WriteLine("                          ALL CUSTOMER ACCOUNTS                                     ");
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-15}{4,-15}", "Name", "CNIC", "Account Number", "Type", "Balance");
            Console.WriteLine("------------------------------------------------------------------------------------");

            foreach (Account acc in accounts)
            {
                string accNum  = acc.HasAccount ? acc.AccountNumber.ToString() : "No Account";
                string accType = acc.HasAccount ? acc.AccountType : "N/A";     
                string bal     = acc.HasAccount ? acc.Balance.ToString() : "N/A";

                Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-15}{4,-15}",
                    acc.Profile.Name,
                    acc.Profile.CNIC,
                    accNum,
                    accType,
                    bal);
            }

            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Total Accounts: " + accounts.Count);
        }


        //******************************ALL CUSTOMER PROFILES WITH ACCOUNTS*************************//

        public static void allcustomerprofileswithAccounts()
        {
            accounts = AccountDL.LoadAllCustomers();

            if (accounts.Count == 0)
            {
                Console.WriteLine("No customer profiles found.");
                return;
            }

            Console.WriteLine("************************************************************************************");
            Console.WriteLine("                     ALL CUSTOMER PROFILES WITH ACCOUNTS                            ");
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("{0,-20}{1,-10}{2,-15}{3,-18}{4,-15}{5,-10}{6,-10}",
                "Name", "Gender", "CNIC", "Contact", "Account No", "Type", "Balance");
            Console.WriteLine("------------------------------------------------------------------------------------");

            foreach (Account acc in accounts)
            {
                string accNum  = acc.HasAccount ? acc.AccountNumber.ToString() : "None";
                string accType = acc.HasAccount ? acc.AccountType : "N/A";
                string bal     = acc.HasAccount ? acc.Balance.ToString() : "N/A";

                Console.WriteLine("{0,-20}{1,-10}{2,-15}{3,-18}{4,-15}{5,-10}{6,-10}",
                    acc.Profile.Name,
                    acc.Profile.Gender,
                    acc.Profile.CNIC,
                    acc.Profile.Contact,
                    accNum,
                    accType,
                    bal);
            }

            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Total: " + accounts.Count);
        }


        //******************************SEARCH CUSTOMER PROFILE FUNCTION*************************//

        public static void searchcustomerProfile()
        {
            accounts = AccountDL.LoadAllCustomers();

            Console.Write("Enter CNIC to search: ");
            string searchCnic = Console.ReadLine();

            Account acc = null;
            for (int i = accounts.Count - 1; i >= 0; i--)
            {
                if (accounts[i].Profile.CNIC == searchCnic)
                {
                    acc = accounts[i];
                    break;
                }
            }

            if (acc == null)
            {
                Console.WriteLine("Profile not found.");
                return;
            }

            Console.WriteLine("************************************************************************************");
            Console.WriteLine("                          CUSTOMER PROFILE FOUND                                    ");
            Console.WriteLine("************************************************************************************");

            acc.DisplayInfo();

            Console.WriteLine("************************************************************************************");
        }


        //******************************SAVING ACCOUNT FUNCTION*************************//

        public static void savingAccount()
        {
            accounts = AccountDL.LoadAllCustomers();

            Console.Write("Enter CNIC for selecting Account: ");
            string searchCnic = Console.ReadLine();

            Account acc   = FindByCnic(searchCnic);
            int     index = FindIndexByCnic(searchCnic);

            if (acc == null)
            {
                Console.WriteLine("Profile not found");
                return;
            }

            if (acc.HasAccount)
            {
                Console.WriteLine("You already have an account:\t" + acc.AccountNumber);
                return;
            }

            SavingAccount savingAcc = new SavingAccount(
                acc.Profile.Name,
                acc.Profile.Gender,
                acc.Profile.CNIC,
                acc.Profile.Contact,
                acc.Profile.Pin,
                100
            );
            savingAcc.AccountNumber = Account.nextsavingAccount++;
            savingAcc.HasAccount    = true;

            if (index != -1)
            {
                Account.accountNumber[index] = savingAcc.AccountNumber;
                Account.hasAccount[index]    = true;
                Account.balance[index]       = 100;
                Account.accountType[index]   = "Saving";
            }

            Console.WriteLine("Saving Account Created Successfully");
            Console.WriteLine("Your Account Number is: " + savingAcc.AccountNumber);

            AccountDL.UpdateAccount(savingAcc);
        }


        //******************************CURRENT ACCOUNT FUNCTION*************************//

        public static void currentAccount()
        {
            accounts = AccountDL.LoadAllCustomers();

            Console.Write("Enter CNIC for selecting Account: ");
            string searchCnic = Console.ReadLine();

            Account acc   = FindByCnic(searchCnic);
            int     index = FindIndexByCnic(searchCnic);

            if (acc == null)
            {
                Console.WriteLine("Profile not found");
                return;
            }

            if (acc.HasAccount)
            {
                Console.WriteLine("You already have an account:\t" + acc.AccountNumber);
                return;
            }

            CurrentAccount currentAcc = new CurrentAccount(
                acc.Profile.Name,
                acc.Profile.Gender,
                acc.Profile.CNIC,
                acc.Profile.Contact,
                acc.Profile.Pin,
                100
            );
            currentAcc.AccountNumber = Account.nextcurrentAccount++;
            currentAcc.HasAccount    = true;

            if (index != -1)
            {
                Account.accountNumber[index] = currentAcc.AccountNumber;
                Account.hasAccount[index]    = true;
                Account.balance[index]       = 100;
                Account.accountType[index]   = "Current";
            }

            Console.WriteLine("Current Account Created Successfully");
            Console.WriteLine("Your Account Number is: " + currentAcc.AccountNumber);

            AccountDL.UpdateAccount(currentAcc);
        }


        //******************************NEW PROFILE FUNCTION*************************//

        public static void newProfile()
        {
            if (Account.totalUsers >= Account.SIZE)
            {
                Console.WriteLine("Maximum users limit reached.");
                return;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Gender (MALE/FEMALE): ");
            string gender = Console.ReadLine();

            if (gender != "MALE" && gender != "FEMALE")
            {
                Console.WriteLine("INVALID GENDER");
                return;
            }

            Console.Write("Enter CNIC (13 digits, no spaces): ");
            string cnic = Console.ReadLine();

            if (cnic.Length != 13)
            {
                Console.WriteLine("INVALID CNIC");
                return;
            }

            Console.Write("Enter Contact Number: ");
            string contact = Console.ReadLine();

            if (contact.Length < 10)
            {
                Console.WriteLine("INVALID CONTACT");
                return;
            }

            Console.Write("Set 4-digit PIN: ");
            string pin = Console.ReadLine();

            if (pin.Length != 4)
            {
                Console.WriteLine("INVALID PIN");
                return;
            }

            Account acc = AccountFactory.Create("Saving", name, gender, cnic, contact, pin);

            int i = Account.totalUsers;
            Account.name[i]    = name;
            Account.gender[i]  = gender;
            Account.cnic[i]    = cnic;
            Account.contact[i] = contact;
            Account.pin[i]     = pin;
            Account.totalUsers++;

            Console.WriteLine("Profile Created Successfully");

            AccountDL.AddCustomer(acc);
        }


        //******************************CHANGE PROFILE FUNCTION*************************//

        public static void changeProfile()
        {
            accounts = AccountDL.LoadAllCustomers();

            Console.Write("Enter CNIC to change profile: ");
            string changeCnic = Console.ReadLine();

            Account acc   = FindByCnic(changeCnic);
            int     index = FindIndexByCnic(changeCnic);

            if (acc == null)
            {
                Console.WriteLine("Profile not found");
                return;
            }

            Console.Write("Enter new Name: ");
            string newName = Console.ReadLine();

            Console.Write("Enter new Contact Number: ");
            string newContact = Console.ReadLine();

            if (newContact.Length < 10)
            {
                Console.WriteLine("INVALID CONTACT NUMBER");
                return;
            }

            acc.Profile.Name    = newName;
            acc.Profile.Contact = newContact;

            if (index != -1)
            {
                Account.name[index]    = newName;
                Account.contact[index] = newContact;
            }

            Console.WriteLine("Profile Updated Successfully");

            AccountDL.UpdateCustomer(acc);
        }


        //******************************DELETE PROFILE FUNCTION*************************//

        public static void deleteProfile()
        {
            accounts = AccountDL.LoadAllCustomers();

            Console.Write("Enter CNIC to delete profile: ");
            string searchCnic = Console.ReadLine();

            Account acc   = FindByCnic(searchCnic);
            int     index = FindIndexByCnic(searchCnic);

            if (acc == null)
            {
                Console.WriteLine("Profile not found");
                return;
            }

            if (index != -1)
            {
                for (int i = index; i < Account.totalUsers - 1; i++)
                {
                    Account.name[i]          = Account.name[i + 1];
                    Account.gender[i]        = Account.gender[i + 1];
                    Account.cnic[i]          = Account.cnic[i + 1];
                    Account.contact[i]       = Account.contact[i + 1];
                    Account.pin[i]           = Account.pin[i + 1];
                    Account.balance[i]       = Account.balance[i + 1];
                    Account.accountNumber[i] = Account.accountNumber[i + 1];
                    Account.accountType[i]   = Account.accountType[i + 1];
                    Account.hasAccount[i]    = Account.hasAccount[i + 1];
                    Transaction.transactionCount[i] = Transaction.transactionCount[i + 1];
                }
                Account.totalUsers--;
            }

            accounts.Remove(acc);

            AccountDL.DeleteCustomer(searchCnic);
            Console.WriteLine("Profile Deleted Successfully");
        }


        //******************************CHANGE PIN FUNCTION*************************//

        public static void changePin()
        {
            accounts = AccountDL.LoadAllCustomers();

            Console.Write("Enter CNIC to change PIN: ");
            string changeCnic = Console.ReadLine();

            Account acc   = FindByCnic(changeCnic);
            int     index = FindIndexByCnic(changeCnic);

            if (acc == null)
            {
                Console.WriteLine("Profile not found");
                return;
            }

            Console.Write("Enter Old PIN: ");
            string oldPin = Console.ReadLine();

            if (!acc.Profile.VerifyPin(oldPin))
            {
                Console.WriteLine("Incorrect old PIN");
                return;
            }

            Console.Write("Enter 4-digit PIN: ");
            string newPin = Console.ReadLine();

            if (newPin.Length != 4)
            {
                Console.WriteLine("PIN must be 4 digits");
                return;
            }

            acc.Profile.Pin = newPin;

            if (index != -1)
                Account.pin[index] = newPin;

            AccountDL.UpdatePin(acc);
            Console.WriteLine("PIN changed Successfully");
        }


        //******************************RESET PIN FUNCTION*************************//

        public static void resetPin()
        {
            accounts = AccountDL.LoadAllCustomers();

            Console.Write("Enter CNIC to reset PIN: ");
            string searchCnic = Console.ReadLine();

            Account acc   = FindByCnic(searchCnic);
            int     index = FindIndexByCnic(searchCnic);

            if (acc == null)
            {
                Console.WriteLine("Profile not found");
                return;
            }

            acc.Profile.Pin = "2025";

            if (index != -1)
                Account.pin[index] = "2025";

            AccountDL.UpdatePin(acc);
            Console.WriteLine("PIN Reset Successfully");
        }
    }
}
