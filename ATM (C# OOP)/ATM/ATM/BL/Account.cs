using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.DL;
using ATM.UI;


namespace ATM.BL
{
   
    public interface IAccount
    {
        int    AccountNumber { get; set; }
        string AccountType   { get; }
        int    Balance       { get; set; }
        bool   HasAccount    { get; set; }

        CustomerProfile    Profile      { get; }
        List<Transaction>  Transactions { get; }

        bool VerifyPin(string inputPin);
        void AddTransaction(Transaction t);
        void DisplayInfo();

        int  CalculateWithdrawFee(int amount);
        bool ProcessWithdraw(int amount);
    }

    public class CustomerProfile
    {
        private string name;
        private string gender;
        private string cnic;
        private string contact;
        private string pin;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Name cannot be empty!");
                name = value;
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                if (value != "MALE" && value != "FEMALE")
                    throw new Exception("Gender must be MALE or FEMALE!");
                gender = value;
            }
        }

        public string CNIC
        {
            get { return cnic; }
            set
            {
                if (value.Length != 13)
                    throw new Exception("CNIC must be 13 digits!");
                cnic = value;
            }
        }

        public string Contact
        {
            get { return contact; }
            set
            {
                if (value.Length < 10)
                    throw new Exception("Contact number must be at least 10 digits!");
                contact = value;
            }
        }

        public string Pin
        {
            get { return pin; }
            set
            {
                if (value.Length != 4)
                    throw new Exception("PIN must be 4 digits!");
                pin = value;
            }
        }

        public bool VerifyPin(string inputPin)
        {
            return pin == inputPin;
        }

        public CustomerProfile(string name, string gender, string cnic, string contact, string pin)
        {
            Name    = name;
            Gender  = gender;
            CNIC    = cnic;
            Contact = contact;
            Pin     = pin;
        }
    }

    public abstract class Account : IAccount
    {
        public const int SIZE = 100;
        public static int TotalUsers      = 0;
        public static int NextSavingAcc   = 100;
        public static int NextCurrentAcc  = 300;

        public static string[] name          = new string[SIZE];
        public static string[] gender        = new string[SIZE];
        public static string[] cnic          = new string[SIZE];
        public static string[] contact       = new string[SIZE];
        public static string[] pin           = new string[SIZE];
        public static int[]    balance       = new int[SIZE];
        public static int[]    accountNumber = new int[SIZE];
        public static string[] accountType   = new string[SIZE];
        public static bool[]   hasAccount    = new bool[SIZE];
        public static int      totalUsers         = 0;
        public static int      nextsavingAccount  = 100;
        public static int      nextcurrentAccount = 300;

        private int               _accountNumber;
        private int               _balance;
        private bool              _hasAccount;
        private CustomerProfile   _profile;
        private List<Transaction> _transactions;

        public int AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                if (value < 0)
                    throw new Exception("Account number cannot be negative!");
                _accountNumber = value;
            }
        }

        public abstract string AccountType { get; }

        public int Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0)
                    throw new Exception("Balance cannot be negative!");
                _balance = value;
            }
        }

        public bool HasAccount
        {
            get { return _hasAccount; }
            set { _hasAccount = value; }
        }

        public CustomerProfile    Profile      { get { return _profile; } }
        public List<Transaction>  Transactions { get { return _transactions; } }

        protected Account(string name, string gender, string cnic,
                          string contact, string pin, int balance = 100)
        {
            _profile      = new CustomerProfile(name, gender, cnic, contact, pin);
            _transactions = new List<Transaction>();
            Balance       = balance;
            HasAccount    = false;
        }

        public void AddTransaction(Transaction t) { _transactions.Add(t); }
        public bool VerifyPin(string inputPin)     { return _profile.VerifyPin(inputPin); }

        public virtual void DisplayInfo()
        {
            Console.WriteLine("Name        : " + _profile.Name);
            Console.WriteLine("CNIC        : " + _profile.CNIC);
            Console.WriteLine("Contact     : " + _profile.Contact);
            Console.WriteLine("Account No  : " + _accountNumber);
            Console.WriteLine("Account Type: " + AccountType);
            Console.WriteLine("Balance     : " + _balance);
        }

        public abstract int  CalculateWithdrawFee(int amount);
        public abstract bool ProcessWithdraw(int amount);
    }

    public class SavingAccount : Account
    {
        private const int WITHDRAW_FEE = 5;

        public override string AccountType { get { return "Saving"; } }

        public SavingAccount(string name, string gender, string cnic,
                             string contact, string pin, int balance = 100)
            : base(name, gender, cnic, contact, pin, balance) { }

        public override int CalculateWithdrawFee(int amount)
        {
            return WITHDRAW_FEE;
        }

        public override bool ProcessWithdraw(int amount)
        {
            int fee   = CalculateWithdrawFee(amount);
            int total = amount + fee;

            if (total > Balance)
            {
                Console.WriteLine("Insufficient balance! (includes Rs." + fee + " withdrawal fee for Saving Account)");
                return false;
            }

            Balance -= total;
            Console.WriteLine("Withdrawal fee applied: Rs." + fee + " (Saving Account)");
            return true;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("=== Saving Account ===");
            base.DisplayInfo();
            Console.WriteLine("Withdrawal Fee  : Rs." + WITHDRAW_FEE + " per transaction");
        }
    }


    public class CurrentAccount : Account
    {
        public override string AccountType { get { return "Current"; } }

        public CurrentAccount(string name, string gender, string cnic,
                              string contact, string pin, int balance = 100)
            : base(name, gender, cnic, contact, pin, balance) { }

        public override int CalculateWithdrawFee(int amount)
        {
            return 0;
        }

        public override bool ProcessWithdraw(int amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient balance!");
                return false;
            }

            Balance -= amount;
            return true;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("=== Current Account ===");
            base.DisplayInfo();
            Console.WriteLine("Withdrawal Fee  : None");
        }
    }

    
    public static class AccountFactory
    {
        public static Account Create(string accountType,
                                     string name, string gender,
                                     string cnic,  string contact,
                                     string pin,   int balance = 100)
        {
            if (accountType == "Saving")
                return new SavingAccount(name, gender, cnic, contact, pin, balance);

            if (accountType == "Current")
                return new CurrentAccount(name, gender, cnic, contact, pin, balance);

            return new SavingAccount(name, gender, cnic, contact, pin, balance);
        }
    }
}
