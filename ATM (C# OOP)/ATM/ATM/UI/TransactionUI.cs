using ATM.BL;
using ATM.DL;
using System;
using System.Collections.Generic;

namespace ATM.UI
{
    public class TransactionUI
    {
        private static List<Account> accounts = new List<Account>();

        private static Account FindByAccountAndPin(int accountNumber, string pin)
        {
            foreach (Account acc in accounts)
            {
                if (acc.AccountNumber == accountNumber && acc.Profile.VerifyPin(pin))
                    return acc;
            }
            return null;
        }

        private static int FindIndexByAccountNumber(int accountNumber)
        {
            for (int i = 0; i < Account.totalUsers; i++)
            {
                if (Account.accountNumber[i] == accountNumber)
                    return i;
            }
            return -1;
        }


        //******************************TRANSACTION HISTORY*************************//

        public static void transactionHistory()
        {
            TransactionDL.DisplayTransactionHistory();
        }


        //******************************CHECK BALANCE*************************//

        public static void checkBalance()
        {
            accounts = AccountDL.LoadAllCustomers();

            Console.Write("Enter Account Number: ");
            int accountNum = int.Parse(Console.ReadLine());

            Console.Write("Enter PIN: ");
            string accountPin = Console.ReadLine();

            Account acc = FindByAccountAndPin(accountNum, accountPin);

            if (acc == null)
            {
                Console.WriteLine("Invalid Account Number or PIN");
                return;
            }

            acc.DisplayInfo();

            List<Transaction> history = TransactionDL.LoadTransactionHistory();
            Transaction latest = null;

            for (int i = history.Count - 1; i >= 0; i--)
            {
                if (history[i].AccountNumber == accountNum)
                {
                    latest = history[i];
                    break;
                }
            }

            if (latest != null)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Latest Transaction:");
                latest.DisplayTransaction();
            }
            else
            {
                Console.WriteLine("No transactions found for this account.");
            }
        }


        //******************************WITHDRAW MONEY*************************//

        public static void withdrawMoney()
        {
            accounts = AccountDL.LoadAllCustomers();

            Console.Write("Enter the Account Number: ");
            int withdrawAccountNum = int.Parse(Console.ReadLine());

            Console.Write("Enter your PIN: ");
            string accountPin = Console.ReadLine();

            Account acc = FindByAccountAndPin(withdrawAccountNum, accountPin);

            if (acc == null)
            {
                Console.WriteLine("Invalid Account Number or PIN");
                return;
            }

            Console.Write("Enter the amount: ");
            int withdraw = int.Parse(Console.ReadLine());

            if (withdraw <= 0)
            {
                Console.WriteLine("INVALID AMOUNT");
                return;
            }

            Console.WriteLine("Previous Balance:\t" + acc.Balance);

            bool success = acc.ProcessWithdraw(withdraw);

            if (!success)
                return;

            Console.WriteLine("Withdraw Successful!");
            Console.WriteLine("Remaining Balance:\t" + acc.Balance);

            int index = FindIndexByAccountNumber(withdrawAccountNum);
            if (index != -1)
                Account.balance[index] = acc.Balance;

            AccountDL.UpdateBalance(acc);

            Transaction t = Transaction.Create(acc.AccountNumber, "Withdraw", withdraw);
            acc.AddTransaction(t);
            TransactionDL.AddTransaction(t);
        }


        //******************************DEPOSIT MONEY*************************//

        public static void depositMoney()
        {
            accounts = AccountDL.LoadAllCustomers();

            Console.Write("Enter the Account Number: ");
            int depositAccountNum = int.Parse(Console.ReadLine());

            Console.Write("Enter your PIN: ");
            string accountPin = Console.ReadLine();

            Account acc = FindByAccountAndPin(depositAccountNum, accountPin);

            if (acc == null)
            {
                Console.WriteLine("Invalid Account Number or PIN");
                return;
            }

            Console.Write("Enter the amount: ");
            int deposit = int.Parse(Console.ReadLine());

            if (deposit <= 0)
            {
                Console.WriteLine("INVALID AMOUNT");
                return;
            }

            Console.WriteLine("Deposit Successful!");
            Console.WriteLine("Previous Balance:\t" + acc.Balance);

            acc.Balance += deposit;

            Console.WriteLine("Updated Balance:\t" + acc.Balance);

            int index = FindIndexByAccountNumber(depositAccountNum);
            if (index != -1)
                Account.balance[index] = acc.Balance;

            AccountDL.UpdateBalance(acc);

            Transaction t = Transaction.Create(acc.AccountNumber, "Deposit", deposit);
            acc.AddTransaction(t);
            TransactionDL.AddTransaction(t);
        }
    }
}
