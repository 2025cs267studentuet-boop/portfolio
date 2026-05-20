#include <iostream>
#include <iomanip>
#include <string>
#include <fstream>
using namespace std;



//**********************GLOBAL VARIABLES****************************//
const int SIZE = 100;
string name[SIZE];
string gender[SIZE];
string cnic[SIZE];
string contact[SIZE];
string pin[SIZE];
int balance[SIZE];
int totalUsers = 0;
int accountNumber[SIZE];
string accountType[SIZE];
int nextsavingAccount = 100;
int nextcurrentAccount = 300;
bool hasAccount[SIZE];
string transactionType[SIZE][100];
int transactionAmount[SIZE][100];
int transactionCount[SIZE] = {0};

//******************************ALL CUSTOMER PROFILES FUNCTION*************************//
void allcustomerProfiles()
{

    ofstream fout("All Customer Profiles.txt");
    fout << "**************************************************************************************" << endl;
    fout << "                               ATM Management System                                  " << endl;
    fout << "**************************************************************************************" << endl;
    fout << left
         << setw(20) << "Name"
         << setw(20) << "Gender"
         << setw(20) << "CNIC"
         << setw(20) << "Contact Number" << endl;
    for (int i = 0; i < totalUsers; i++)
    {
        fout << left
             << setw(20) << name[i]
             << setw(20) << gender[i]
             << setw(20) << cnic[i]
             << setw(20) << contact[i] << endl;
    }

    fout.close();
    if (totalUsers == 0)
    {
        cout << "No customer profile found." << endl;
    }
    else
    {
        cout << "Customer data processed successfully." << endl;
    }
}

//******************************ALL CUSTOMER ACCOUNTS FUNCTION*************************//
void allcustomerAccounts()
{

    ofstream fout("All Customer Accounts.txt");
    fout << "**************************************************************************************" << endl;
    fout << "                               ATM Management System                                  " << endl;
    fout << "**************************************************************************************" << endl;
    fout << left
         << setw(20) << "Name"
         << setw(20) << "CNIC"
         << setw(20) << "Account Number" << endl;
    for (int i = 0; i < totalUsers; i++)
    {
        fout << left
             << setw(20) << name[i]
             << setw(20) << cnic[i]
             << setw(20) << accountNumber[i] << endl;
    }

    fout.close();
    if (totalUsers == 0)
    {
        cout << "No customer profile found." << endl;
    }
    else
    {
        cout << "Customer data processed successfully." << endl;
    }
}

//******************************ALL CUSTOMER PROFILES WITH ACCOUNTS FUNCTION*************************//
void allcustomerprofileswithAccounts()
{

    ofstream fout("All Customer Profiles With Accounts.txt");
    fout << "**************************************************************************************" << endl;
    fout << "                               ATM Management System                                  " << endl;
    fout << "**************************************************************************************" << endl;
    fout << left
         << setw(20) << "Name"
         << setw(15) << "Gender"
         << setw(20) << "CNIC"
         << setw(20) << "Contact Number"
         << setw(20) << "Account Number" << endl;
    for (int i = 0; i < totalUsers; i++)
    {
        fout << left
             << setw(20) << name[i]
             << setw(15) << gender[i]
             << setw(20) << cnic[i]
             << setw(20) << contact[i]
             << setw(20) << accountNumber[i] << endl;
    }

    fout.close();
    if (totalUsers == 0)
    {
        cout << "No customer profile found." << endl;
    }
    else
    {
        cout << "Customer data processed successfully." << endl;
    }
}

//******************************SEARCH CUSTOMER PROFILES FUNCTION*************************//
void searchcustomerProfile()
{

    string searchCnic;
    int index = -1;

    cin.ignore();
    cout << "Enter CNIC for selecting Profile ";
    getline(cin, searchCnic);
    for (int i = 0; i < totalUsers; i++)
    {
        if (cnic[i] == searchCnic)
        {
            index = i;
            break;
        }
    }
    if (index == -1)
    {
        cout << "Profile not found" << endl;
        return;
    }
    else
    {

        ofstream fout("Searched Customer Profile.txt");
        fout << "**************************************************************************************" << endl;
        fout << "                               ATM Management System                                  " << endl;
        fout << "**************************************************************************************" << endl;
        fout << left
             << setw(20) << "Name"
             << setw(15) << "Gender"
             << setw(20) << "CNIC"
             << setw(20) << "Contact Number"
             << setw(20) << "Account Number" << endl;
        fout << left
             << setw(20) << name[index]
             << setw(15) << gender[index]
             << setw(20) << cnic[index]
             << setw(20) << contact[index]
             << setw(20) << accountNumber[index] << endl;

        fout.close();
        if (totalUsers == 0)
        {
            cout << "No customer profile found." << endl;
        }
        else
        {
            cout << "Customer data processed successfully." << endl;
        }
    }
}
//******************************TRANSACTION HISTORY FUNCTION*************************//
void transactionHistory()
{
    ifstream fin("Transaction History.txt");
    string account;
    string type;
    int amount;
    while (fin >> account >> type >> amount)
    {
        cout << account << "\t" << type << "\t" << amount << endl;
    }
    fin.close();
    if (totalUsers == 0)
    {
        cout << "No customer profile found." << endl;
    }
    else
    {
        cout << "Customer data processed successfully." << endl;
    }
}

//******************************SAVING ACCOUNT FUNCTION*************************//
void savingAccount()
{
    string searchCnic;
    int index = -1;

    cin.ignore();
    cout << "Enter CNIC for selecting Account: ";
    getline(cin, searchCnic);
    for (int i = 0; i < totalUsers; i++)
    {
        if (cnic[i] == searchCnic)
        {
            index = i;
            break;
        }
    }
    if (index == -1)
    {
        cout << "Profile not found" << endl;
        return;
    }
    else
    {
        hasAccount[SIZE] = false;
        if (hasAccount[index] == true)
        {
            cout << "You already have a saving account:\t" << accountNumber[index] << endl;
        }
        else
        {

            accountNumber[index] = nextsavingAccount;
            nextsavingAccount++;

            hasAccount[index] = true;
            balance[index] = 100;
            accountType[index] = "Saving";

            cout << "Saving Account Created Successfully " << endl;
            cout << "Your Account Number is: " << accountNumber[index] << endl;
            return;
        }
    }
    ofstream fout("Customers.txt");
    fout << "**************************************************************************************" << endl;
    fout << "                               ATM Management System                                  " << endl;
    fout << "**************************************************************************************" << endl;
    fout << left
         << setw(20) << "Name"
         << setw(15) << "Gender"
         << setw(20) << "CNIC"
         << setw(20) << "Contact Number"
         << setw(20) << "Account Number"
         << setw(20) << "PIN" << endl;
    for (int i = 0; i < totalUsers; i++)
    {
        fout << left
             << setw(20) << name[i]
             << setw(15) << gender[i]
             << setw(20) << cnic[i]
             << setw(20) << contact[i]
             << setw(20) << accountNumber[i]
             << setw(20) << pin[i] << endl;
    }

    fout.close();
}

//******************************CURRENT ACCOUNT FUNCTION*************************//
void currentAccount()
{
    string searchCnic;
    int index = -1;
    cin.ignore();
    cout << "Enter CNIC for selecting Account: ";
    getline(cin, searchCnic);
    for (int i = 0; i < totalUsers; i++)
    {
        if (cnic[i] == searchCnic)
        {
            index = i;
            break;
        }
    }
    if (index == -1)
    {
        cout << "Profile not found" << endl;
        return;
    }
    else
    {
        hasAccount[SIZE] = false;
        if (hasAccount[index] == true)
        {
            cout << "You already have a current account:\t" << accountNumber[index] << endl;
        }
        else
        {

            accountNumber[index] = nextcurrentAccount;
            nextcurrentAccount++;

            hasAccount[index] = true;
            balance[index] = 100;
            accountType[index] = "Current";

            cout << "Current Account Created Successfully " << endl;
            cout << "Your Account Number is: " << accountNumber[index] << endl;
            return;
        }
    }
    ofstream fout("Customers.txt");
    fout << "**************************************************************************************" << endl;
    fout << "                               ATM Management System                                  " << endl;
    fout << "**************************************************************************************" << endl;
    fout << left
         << setw(20) << "Name"
         << setw(15) << "Gender"
         << setw(20) << "CNIC"
         << setw(20) << "Contact Number"
         << setw(20) << "Account Number"
         << setw(20) << "PIN" << endl;
    for (int i = 0; i < totalUsers; i++)
    {
        fout << left
             << setw(20) << name[i]
             << setw(15) << gender[i]
             << setw(20) << cnic[i]
             << setw(20) << contact[i]
             << setw(20) << accountNumber[i]
             << setw(20) << pin[i] << endl;
    }

    fout.close();
}

//******************************NEW PROFILE FUNCTION*************************//
void newProfile()
{
    cin.ignore();
    cout << "Enter Name: ";
    getline(cin, name[totalUsers]);

    cout << "Enter Gender (MALE/FEMALE): ";
    getline(cin, gender[totalUsers]);

    if (gender[totalUsers] == "MALE" || gender[totalUsers] == "FEMALE")
    {
        cout << "Enter CNIC (13 digits, no spaces): ";
        cin >> cnic[totalUsers];

        if (cnic[totalUsers].length() == 13)
        {
            cout << "Enter Contact Number: ";
            cin >> contact[totalUsers];

            if (contact[totalUsers].length() >= 10)
            {
                cout << "Set 4-digit PIN: ";
                cin >> pin[totalUsers];
                if (pin[totalUsers].length() == 4)
                {
                    cout << "Profile Created Successfully" << endl;
                    totalUsers++;
                }
                else
                    cout << "INVALID PIN" << endl;
            }
            else
                cout << "INVALID CONTACT" << endl;
        }
        else
            cout << "INVALID CNIC" << endl;
    }
    else
        cout << "INVALID GENDER" << endl;

    ofstream fout("Customers.txt");
    fout << "**************************************************************************************" << endl;
    fout << "                               ATM Management System                                  " << endl;
    fout << "**************************************************************************************" << endl;
    fout << left
         << setw(20) << "Name"
         << setw(15) << "Gender"
         << setw(20) << "CNIC"
         << setw(20) << "Contact Number"
         << setw(20) << "PIN" << endl;
    for (int i = 0; i < totalUsers; i++)
    {
        fout << left
             << setw(20) << name[i]
             << setw(15) << gender[i]
             << setw(20) << cnic[i]
             << setw(20) << contact[i]
             << setw(20) << pin[i] << endl;
    }

    fout.close();
}

//******************************CHANGE PROFILE FUNCTION*************************//
void changeProfile()
{
    string changeCnic;
    cout << "Enter CNIC to change profile: ";
    cin.ignore();
    getline(cin, changeCnic);

    int index = -1;

    for (int i = 0; i < totalUsers; i++)
    {
        if (cnic[i] == changeCnic)
        {
            index = i;
            break;
        }
    }

    if (index == -1)
    {
        cout << "Profile not found" << endl;
        return;
    }
    else
    {
        cout << "Enter new Name: ";
        getline(cin, name[index]);

        cout << "Enter new Contact Number: ";
        getline(cin, contact[index]);

        if (contact[index].length() < 10)
        {
            cout << "INVALID CONTACT NUMBER" << endl;
            return;
        }

        cout << "Profile Updated Successfully" << endl;
    }
    ofstream fout("Customers.txt");
    fout << "**************************************************************************************" << endl;
    fout << "                               ATM Management System                                  " << endl;
    fout << "**************************************************************************************" << endl;
    fout << left
         << setw(20) << "Name"
         << setw(15) << "Gender"
         << setw(20) << "CNIC"
         << setw(20) << "Contact Number"
         << setw(20) << "PIN" << endl;
    for (int i = 0; i < totalUsers; i++)
    {
        fout << left
             << setw(20) << name[i]
             << setw(15) << gender[i]
             << setw(20) << cnic[i]
             << setw(20) << contact[i]
             << setw(20) << pin[i] << endl;
    }
    fout.close();
}

//******************************DELETE PROFILE FUNCTION*************************//
void deleteProfile()
{
    string searchCnic;
    cout << "Enter CNIC to delete profile: ";
    cin.ignore();
    getline(cin, searchCnic);

    int index = -1;

    for (int i = 0; i < totalUsers; i++)
    {
        if (cnic[i] == searchCnic)
        {
            index = i;
            break;
        }
    }

    if (index == -1)
    {
        cout << "Profile not found" << endl;
        return;
    }
    else
    {
        for (int i = index; i < totalUsers - 1; i++)
        {
            name[i] = name[i + 1];
            gender[i] = gender[i + 1];
            cnic[i] = cnic[i + 1];
            contact[i] = contact[i + 1];
            pin[i] = pin[i + 1];
        }

        totalUsers--;
    }

    ofstream fout("Customers.txt");

    fout << left
         << setw(20) << "Name"
         << setw(15) << "Gender"
         << setw(20) << "CNIC"
         << setw(20) << "Contact Number"
         << setw(20) << "PIN" << endl;

    for (int i = 0; i < totalUsers; i++)
    {
        fout << left
             << setw(20) << name[i]
             << setw(15) << gender[i]
             << setw(20) << cnic[i]
             << setw(20) << contact[i]
             << setw(20) << pin[i] << endl;
    }

    fout.close();

    cout << "Profile Deleted Successfully" << endl;
}

//******************************CHECK BALANCE FUNCTION*************************//
void checkBalance()
{
    int account;
    string accountPin;
    bool found = false;

    cout << "Enter Account Number: ";
    cin >> account;
    cin.ignore();
    cout << "Enter PIN: ";
    getline(cin, accountPin);

    for (int i = 0; i < SIZE; i++)
    {
        if (accountNumber[i] == account && pin[i] == accountPin)
        {
            cout << "Your Current Balance is: " << balance[i] << endl;
            found = true;
            break;
        }
        else
        {
            cout << "Invalid Account Number or PIN" << endl;
            break;
        }
    }
}

//******************************BALANCE WITHDRAW FUNCTION*************************//
void withdrawMoney()
{
    int withdrawAccount;
    int withdraw;
    string accountPin;
    cout << "Enter the Account Number:" << endl;
    cin >> withdrawAccount;
    cin.ignore();
    cout << "Enter your PIN\t";
    getline(cin, accountPin);

    for (int i = 0; i < SIZE; i++)
    {
        if (withdrawAccount == accountNumber[i])
        {
            if (accountPin == pin[i])
            {

                cout << "Enter the amount :" << endl;
                cin >> withdraw;
                if (withdraw >= 0 && withdraw <= balance[i])
                {
                    cout << "Withdraw Successfully" << endl;
                    cout << "Previous Balance :\t" << balance[i] << endl;
                    if (accountType[i] == "Saving")
                    {
                        balance[i] = balance[i] - withdraw - 5;
                    }
                    else
                    {
                        balance[i] = balance[i] - withdraw;
                    }

                    cout << "Remaining Balance :\t" << balance[i] << endl;
                    int index = transactionCount[i];
                    transactionType[i][index] = "Withdraw";
                    transactionAmount[i][index] = withdraw;
                    transactionCount[i]++;

                    ofstream fout("Transaction History.txt");
                    for (int u = 0; u < totalUsers; u++)
                    {
                        for (int t = 0; t < transactionCount[u]; t++)
                        {
                            fout << "**************************************************************************************" << endl;
                            fout << "                               ATM Management System                                  " << endl;
                            fout << "**************************************************************************************" << endl;
                            fout << left
                                 << setw(20) << "Account Number"
                                 << setw(15) << "Type"
                                 << setw(20) << "Amount" << endl;
                            fout << left 
                                 << setw(20) << accountNumber[u]
                                 << setw(15) << transactionType[u][t]
                                 << setw(20) << transactionAmount[u][t] << endl;
                        }
                    }
                    fout.close();
                    break;
                }
                else
                    cout << "INVALID AMOUNT" << endl;
            }
        }
    }

    ofstream fout("Customers.txt");
    fout << "**************************************************************************************" << endl;
    fout << "                               ATM Management System                                  " << endl;
    fout << "**************************************************************************************" << endl;
    fout << left
         << setw(20) << "Name"
         << setw(15) << "Gender"
         << setw(20) << "CNIC"
         << setw(20) << "Contact Number"
         << setw(20) << "Account Number"
         << setw(20) << "Balance"
         << setw(20) << "PIN" << endl;
    for (int i = 0; i < totalUsers; i++)
    {
        fout << left
             << setw(20) << name[i]
             << setw(15) << gender[i]
             << setw(20) << cnic[i]
             << setw(20) << contact[i]
             << setw(20) << accountNumber[i]
             << setw(20) << balance[i]
             << setw(20) << pin[i] << endl;
    }

    fout.close();
}

//******************************DEPOSOT MONEY FUNCTION*************************//
void depositMoney()
{
    int depositAccount;
    int deposit;
    string accountPin;
    cout << "Enter the Account Number:" << endl;
    cin >> depositAccount;
    cin.ignore();
    cout << "Enter your PIN\t";
    getline(cin, accountPin);

    for (int i = 0; i < SIZE; i++)
    {
        if (depositAccount == accountNumber[i])
        {
            if (accountPin == pin[i])
            {
                cout << "Enter the amount :" << endl;
                cin >> deposit;
                if (deposit >= 0)
                {

                    cout << "Deposit Successfully" << endl;
                    cout << "Previous Balance :\t" << balance[i] << endl;
                    balance[i] = balance[i] + deposit;
                    cout << "Updated Balance :\t" << balance[i] << endl;
                    int index = transactionCount[i];
                    transactionType[i][index] = "deposit";
                    transactionAmount[i][index] = deposit;
                    transactionCount[i]++;

                    ofstream fout("Transaction History.txt");
                    for (int u = 0; u < totalUsers; u++)
                    {
                        for (int t = 0; t < transactionCount[u]; t++)
                        {
                         fout << "**************************************************************************************" << endl;
                            fout << "                               ATM Management System                                  " << endl;
                            fout << "**************************************************************************************" << endl;
                            fout << left
                                 << setw(20) << "Account Number"
                                 << setw(15) << "Type"
                                 << setw(20) << "Amount" << endl;
                            fout << left 
                                 << setw(20) << accountNumber[u]
                                 << setw(15) << transactionType[u][t]
                                 << setw(20) << transactionAmount[u][t] << endl;
                        }
                    }
                    fout.close();
                    break;
                }
                else
                    cout << "INVALID AMOUNT" << endl;
            }
        }
    }
    ofstream fout("Customers.txt");
    fout << "**************************************************************************************" << endl;
    fout << "                               ATM Management System                                  " << endl;
    fout << "**************************************************************************************" << endl;
    fout << left
         << setw(20) << "Name"
         << setw(15) << "Gender"
         << setw(20) << "CNIC"
         << setw(20) << "Contact Number"
         << setw(20) << "Account Number"
         << setw(20) << "Balance"
         << setw(20) << "PIN" << endl;
    for (int i = 0; i < totalUsers; i++)
    {
        fout << left
             << setw(20) << name[i]
             << setw(15) << gender[i]
             << setw(20) << cnic[i]
             << setw(20) << contact[i]
             << setw(20) << accountNumber[i]
             << setw(20) << balance[i]
             << setw(20) << pin[i] << endl;
    }

    fout.close();
}

//******************************CHANGE PIN FUNCTION*************************//
void changePin()
{
    string changeCnic;
    string oldPin;
    string newPin;

    cin.ignore();
    cout << "Enter CNIC to change PIN:\t";
    getline(cin, changeCnic);

    int index = -1;
    for (int i = 0; i < totalUsers; i++)
    {
        if (cnic[i] == changeCnic)
        {
            index = i;
            break;
        }
    }

    if (index == -1)
    {
        cout << "Profile not found" << endl;
        return;
    }
    else
    {
        cout << "Enter Old PIN: ";
        getline(cin, oldPin);

        if (pin[index] != oldPin)
        {
            cout << "Incorrect old PIN" << endl;
            return;
        }

        cout << "Enter 4-digit PIN: ";
        getline(cin, newPin);

        if (newPin.length() != 4)
        {
            cout << "PIN must be 4 digits" << endl;
            return;
        }

        pin[index] = newPin;
        ofstream fout("Customers.txt");

        fout << left
             << setw(20) << "Name"
             << setw(15) << "Gender"
             << setw(20) << "CNIC"
             << setw(20) << "Contact Number"
             << setw(20) << "PIN" << endl;

        for (int i = 0; i < totalUsers; i++)
        {
            fout << left
                 << setw(20) << name[i]
                 << setw(15) << gender[i]
                 << setw(20) << cnic[i]
                 << setw(20) << contact[i]
                 << setw(20) << pin[i] << endl;
        }

        fout.close();
        cout << "PIN changed Successfully" << endl;
    }
}

//******************************RESET PIN FUNCTION*************************//
void resetPin()
{
    string searchCnic;
    cout << "Enter CNIC to delete profile:\t";
    cin.ignore();
    getline(cin, searchCnic);

    int index = -1;

    for (int i = 0; i < totalUsers; i++)
    {
        if (cnic[i] == searchCnic)
        {
            index = i;
            break;
        }
    }

    if (index == -1)
    {
        cout << "Profile not found" << endl;
        return;
    }
    else
    {
        pin[index] = "2025";
        cout << "PIN Updated Successfully" << endl;
        ofstream fout("Customers.txt");
        fout << "**************************************************************************************" << endl;
        fout << "                               ATM Management System                                  " << endl;
        fout << "**************************************************************************************" << endl;
        fout << left
             << setw(20) << "Name"
             << setw(15) << "Gender"
             << setw(20) << "CNIC"
             << setw(20) << "Contact Number"
             << setw(20) << "PIN" << endl;
        for (int i = 0; i < totalUsers; i++)
        {
            fout << left
                 << setw(20) << name[i]
                 << setw(15) << gender[i]
                 << setw(20) << cnic[i]
                 << setw(20) << contact[i]
                 << setw(20) << pin[i] << endl;
        }
        fout.close();
    }
}

int main()
// DEFAULT ATM PIN:2025
// DEFAULT ATM BALANCE:100
{
    string PIN;
    int i;
    int j = -1;
    int k = -1; // k is used for MAIN MENU
    int y = -1; // y is used for ADMINISTRATOR PORTAL
    int z = -1; // z is used for ACCOUNT HOLDER PORTAL
    int a = -1; // a is used in ACCOUNT HOLDER PORTAL for ACCOUNT REGISTRATION SYSTEM
    int b = -1; // b is used in ACCOUNT HOLDER PORTAL for CUSTOMER MANAGEMENT SYSTEM
    int c = -1; // c is used in ACCOUNT HOLDER PORTAL for TRANSACTION SYSTEM
    int d = -1; // d is used in ACCOUNT HOLDER PORTAL for AUTHENTICATION SYSTEM
    cout << "**************************************************************************************" << endl;
    cout << "                               ATM Management System                                  " << endl;
    cout << "**************************************************************************************" << endl;
    cout << "                         Please Enter your Bank Credential!                           " << endl;
    cout << "**************************************************************************************" << endl;

    cout << "Enter 4-digit PIN:" << right << setw(5) << PIN << endl;
    cin >> PIN;
    if (PIN != "2025")
    {
        cout << "*************************************INVALID PIN**********************************" << endl;
        return 0;
    }
    while (k != 0)
    {

        cout << "**************************************************************************************" << endl;
        cout << "                                        MAIN MENU                                     " << endl;
        cout << "**************************************************************************************" << endl;
        cout << "Please Enter The Type " << endl;
        cout << "Please Enter '1' to use as an Administrator" << endl;
        cout << "Please Enter '2' to use as a Customer" << endl;
        cout << "Please Enter '0' to exit the Program" << endl;
        cout << "**************************************************************************************" << endl;
        cout << "Enter the option:\t";
        cin >> k;
        if (k == 1)
        {
            cout << "**************************************************************************************" << endl;
            cout << "                             WELCOME TO ADMINISTRATOR PORTAL                          " << endl;
            cout << "**************************************************************************************" << endl;
            cout << "Please enter '1' to see All Customer Profiles" << endl;
            cout << "Please enter '2' to see All Customer Accounts" << endl;
            cout << "Please enter '3' to see All Customer Profiles With Accounts" << endl;
            cout << "Please enter '4' to search for Customer Profiles" << endl;
            cout << "Please enter '5' to see Transaction History" << endl;
            cout << "Please enter '0' to return to MAIN MENU" << endl;
            cout << "Please Enter the option\t";
            cin >> y;
            cout << endl;
            if (y == 1)
            {
                cout << "You selected the option " << ":" << y << endl;
                allcustomerProfiles();
            }
            else if (y == 2)
            {
                cout << "You selected the option " << ":" << y << endl;
                allcustomerAccounts();
            }
            else if (y == 3)
            {
                cout << "You selected the option " << ":" << y << endl;
                allcustomerprofileswithAccounts();
            }
            else if (y == 4)
            {
                cout << "You selected the option " << ":" << y << endl;
                searchcustomerProfile();
            }
            else if (y == 5)
            {
                cout << "You selected the option " << ":" << y << endl;
                transactionHistory();
            }
            else if (y == 0)
            {
                cout << "Returning to MAIN MENU" << endl;
            }

            else
                cout << "************************************* INVALID INPUT **********************************" << endl;
        }
        else if (k == 2)
        {
            cout << "**************************************************************************************" << endl;
            cout << "                             WELCOME TO ACCOUNT HOLDER PORTAL                         " << endl;
            cout << "**************************************************************************************" << endl;
            cout << "Please enter '1' to use Account Registration System" << endl;
            cout << "Please enter '2' to use Customer Management System" << endl;
            cout << "Please enter '3' to use Transaction Processing System" << endl;
            cout << "Please enter '4' to use Authentication System" << endl;
            cout << "Please enter '0' to return to MAIN MENU" << endl;
            cout << "Please Enter the option\t";
            cin >> z;
            if (z == 1)
            {
                cout << "**************************************************************************************" << endl;
                cout << "                           WELCOME TO ACCOUNT REGISTRATION SYSTEM                     " << endl;
                cout << "**************************************************************************************" << endl;
                cout << "Please enter '1' to select Saving Account" << endl;
                cout << "Please enter '2' to select Current Account" << endl;
                cout << "Please enter '0' to return to MAIN MENU" << endl;
                cout << "Please Enter the option\t";
                cin >> a;
                if (a == 1)
                {
                    cout << "You selected the option :" << a << endl;
                    cout << "**************************************************************************************" << endl;
                    cout << "                                 WELCOME TO SAVING ACCOUNT                            " << endl;
                    cout << "**************************************************************************************" << endl;
                    savingAccount();
                }
                else if (a == 2)
                {
                    cout << "You selected the option :" << a << endl;
                    cout << "**************************************************************************************" << endl;
                    cout << "                                 WELCOME TO CURRENT ACCOUNT                           " << endl;
                    cout << "**************************************************************************************" << endl;
                    currentAccount();
                }
            }
            else if (z == 2)
            {
                cout << "**************************************************************************************" << endl;
                cout << "                           WELCOME TO CUSTOMER MANAGEMENT SYSTEM                      " << endl;
                cout << "**************************************************************************************" << endl;
                cout << "Please enter '1' to select New Profile" << endl;
                cout << "Please enter '2' to select Change Profile" << endl;
                cout << "Please enter '3' to select Delete Profile" << endl;
                cout << "Please enter '0' to return to MAIN MENU" << endl;
                cout << "Please Enter the option\t";
                cin >> b;
                if (b == 1)
                {
                    cout << "You selected the option :" << b << endl;
                    newProfile();
                }
                else if (b == 2)
                {
                    cout << "You selected the option :" << b << endl;
                    changeProfile();
                }
                else if (b == 3)
                {
                    cout << "You selected the option :" << b << endl;
                    deleteProfile();
                }
            }
            else if (z == 3)
            {
                cout << "**************************************************************************************" << endl;
                cout << "                               WELCOME TO TRANSACTION SYSTEM                          " << endl;
                cout << "**************************************************************************************" << endl;
                cout << "Please enter '1' to Check Your Balance" << endl;
                cout << "Please enter '2' to Withdraw Cash" << endl;
                cout << "Please enter '3' to Deposit Money" << endl;
                cout << "Please enter '0' to return to MAIN MENU" << endl;
                cout << "Please Enter the option\t";
                cin >> c;
                if (c == 1)
                {
                    cout << "**************************************************************************************" << endl;
                    cout << "                             WELCOME TO MONEY CHECKING SECTION                        " << endl;
                    cout << "**************************************************************************************" << endl;
                    checkBalance();
                }
                else if (c == 2)
                {
                    cout << "**************************************************************************************" << endl;
                    cout << "                             WELCOME TO MONEY WITHDRAW SECTION                        " << endl;
                    cout << "**************************************************************************************" << endl;
                    withdrawMoney();
                }
                else if (c == 3)
                {

                    cout << "**************************************************************************************" << endl;
                    cout << "                            WELCOME TO MONEY DEPOSITING SECTION                       " << endl;
                    cout << "**************************************************************************************" << endl;
                    depositMoney();
                }
            }
            else if (z == 4)
            {
                cout << "**************************************************************************************" << endl;
                cout << "                             WELCOME TO AUTHENTICATION SYSTEM                         " << endl;
                cout << "**************************************************************************************" << endl;
                cout << "Please enter '1' to Change PIN" << endl;
                cout << "Please enter '2' to Reset PIN" << endl;
                cout << "Please enter '0' to return to MAIN MENU" << endl;
                cout << "Please Enter the option\t";
                cin >> d;
                if (d == 1)
                {
                    cout << "**************************************************************************************" << endl;
                    cout << "                              WELCOME TO PIN CHANGING SECTION                         " << endl;
                    cout << "**************************************************************************************" << endl;
                    changePin();
                }
                else if (d == 2)
                {
                    cout << "**************************************************************************************" << endl;
                    cout << "                             WELCOME TO PIN RESETTING SECTION                         " << endl;
                    cout << "**************************************************************************************" << endl;
                    resetPin();
                }
                else
                    cout << "************************************* INVALID INPUT **********************************" << endl;
            }
            else if (z == 0)
            {
                cout << "Returning to MAIN MENU" << endl;
            }
            else
                cout << "************************************* INVALID INPUT **********************************" << endl;
        }
        else if (k == 0)
        {
            cout << "**************************************************************************************" << endl;
            cout << "                                Thanks for using ATM                                  " << endl;
            cout << "**************************************************************************************" << endl;
        }
        else
            cout << "*************************************INVALID INPUT**********************************" << endl;
    }

    return 0;
}
