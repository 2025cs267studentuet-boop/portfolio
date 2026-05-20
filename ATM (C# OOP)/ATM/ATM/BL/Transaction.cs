using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.DL;
using ATM.UI;


namespace ATM.BL
{

    public abstract class Transaction
    {
        public static string[,] transactionType   = new string[Account.SIZE, 100];
        public static int[,]    transactionAmount = new int[Account.SIZE, 100];
        public static int[]     transactionCount  = new int[Account.SIZE];

        private int _accountNumber;
        private int _amount;
        private DateTime _date;

        public int  AccountNumber { get { return _accountNumber; } }
        public int  Amount  { get { return _amount; } }
        public DateTime Date   { get { return _date; } }

        public abstract string Type { get; }

        protected Transaction(int accountNumber, int amount)
        {
            if (accountNumber <= 0)
                throw new Exception("Account Number Not Valid!");
            if (amount <= 0)
                throw new Exception("Amount must be greater than zero!");

            _accountNumber = accountNumber;
            _amount        = amount;
            _date          = DateTime.Now;
        }

        public virtual void DisplayTransaction()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Account Number : " + _accountNumber);
            Console.WriteLine("Type           : " + Type);
            Console.WriteLine("Amount         : " + _amount);
            Console.WriteLine("Date           : " + _date.ToString("dd-MM-yyyy HH:mm"));
            Console.WriteLine("--------------------------------------------------");
        }

        public static Transaction Create(int accountNumber, string type, int amount)
        {
            if (type == "Deposit")
                return new DepositTransaction(accountNumber, amount);
            if (type == "Withdraw")
                return new WithdrawTransaction(accountNumber, amount);
            throw new Exception("Type must be Deposit or Withdraw!");
        }
    }

    public class DepositTransaction : Transaction
    {
        public override string Type { get { return "Deposit"; } }

        public DepositTransaction(int accountNumber, int amount)
            : base(accountNumber, amount) { }
    }

    public class WithdrawTransaction : Transaction
    {
        public override string Type { get { return "Withdraw"; } }

        public WithdrawTransaction(int accountNumber, int amount)
            : base(accountNumber, amount) { }

        public override void DisplayTransaction()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Account Number : " + AccountNumber);
            Console.WriteLine("Type           : " + Type);
            Console.WriteLine("Amount         : " + Amount);
            Console.WriteLine("Date           : " + Date.ToString("dd-MM-yyyy HH:mm"));
            Console.WriteLine("[Note: Saving accounts incur Rs.5 withdrawal fee]");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
