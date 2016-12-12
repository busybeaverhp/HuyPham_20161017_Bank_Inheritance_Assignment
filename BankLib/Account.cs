using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib
{
    public enum AccountType { RegularAccount, SavingsAccount, CheckingAccount};

    public class Account
    {
        Random rand = new Random();

        protected AccountType _accountType;
        protected string _accountNumberID;

        protected string _bankName;
        protected string _lastName;
        protected string _firstName;

        protected decimal _currentBalance;
        protected List<Transaction> _transactionList;

        public Account() { }

        public Account(decimal currentBalance, string bankName, string lastName, string firstName)
        {
            _accountNumberID = rand.Next(100000000, 1000000000).ToString(); System.Threading.Thread.Sleep(16);
            _bankName = bankName;
            _accountType = AccountType.RegularAccount;

            _lastName = lastName;
            _firstName = firstName;

            _currentBalance = currentBalance;
            _transactionList = new List<Transaction>();

            Transaction tempTransaction = new Transaction(TransactionType.Deposit, currentBalance, DateTime.Now, "N/A", _accountNumberID, "Initialized Balance State");
            AddTransaction(tempTransaction);
        }

        #region METHODS

        public void Deposit(decimal amount)
        {
            Transaction tempTransaction = new Transaction(TransactionType.Deposit, amount, DateTime.Now, "N/A", _accountNumberID);
            AddTransaction(tempTransaction);

            _currentBalance += amount;
        }

        public void Deposit(decimal amount, string description)
        {
            Transaction tempTransaction = new Transaction(TransactionType.Deposit, amount, DateTime.Now, "N/A", _accountNumberID, description);
            AddTransaction(tempTransaction);

            _currentBalance += amount;
        }

        // Overriden in CheckingAccount
        public virtual void Withdraw(decimal amount)
        {
            Transaction tempTransaction = new Transaction(TransactionType.Withdraw, amount, DateTime.Now, _accountNumberID, "N/A");
            AddTransaction(tempTransaction);

            _currentBalance -= amount;
        }

        // Overriden in CheckingAccount
        public virtual void Withdraw(decimal amount, string description)
        {
            Transaction tempTransaction = new Transaction(TransactionType.Withdraw, amount, DateTime.Now, _accountNumberID, "N/A", description);
            AddTransaction(tempTransaction);

            _currentBalance -= amount;
        }

        public void TransferIn(string debitedAccountNumberID, decimal amount)
        {
            Transaction tempTransactionTransferOut = new Transaction(TransactionType.TransferIn, amount, DateTime.Now, debitedAccountNumberID, _accountNumberID);
            AddTransaction(tempTransactionTransferOut);

            _currentBalance += amount;
        }

        public void TransferIn(string debitedAccountNumberID, decimal amount, string description)
        {
            Transaction tempTransactionTransferOut = new Transaction(TransactionType.TransferIn, amount, DateTime.Now, debitedAccountNumberID, _accountNumberID, description);
            AddTransaction(tempTransactionTransferOut);

            _currentBalance += amount;
        }

        public void TransferTo(string creditedAccountNumberID, decimal amount)
        {
            Transaction tempTransactionTransferOut = new Transaction(TransactionType.TransferOut, amount, DateTime.Now, _accountNumberID, creditedAccountNumberID);
            AddTransaction(tempTransactionTransferOut);

            _currentBalance -= amount;
        }

        public void TransferTo(string creditedAccountNumberID, decimal amount, string description)
        {
            Transaction tempTransactionTransferOut = new Transaction(TransactionType.TransferOut, amount, DateTime.Now, _accountNumberID, creditedAccountNumberID, description);
            AddTransaction(tempTransactionTransferOut);

            _currentBalance -= amount;
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactionList.Insert(0, transaction);
        }

        #endregion

        #region SAVINGSACCOUNT METHODS

        // Overriden in SavingsAccount
        public virtual void ApplyInterest() { }

        #endregion

        #region ACCESSORS

        public string AccountNumberID
        { get { return _accountNumberID; } }

        public string BankName
        { get { return _bankName; } }

        public AccountType GetAccountType
        { get { return _accountType; } }

        public string LastName
        { get { return _lastName; } }

        public string FirstName
        { get { return _firstName; } }

        public decimal CurrentBalance
        { get { return _currentBalance; } }

        public List<Transaction> TransactionList
        { get { return _transactionList.ToList(); } }

        #endregion

        #region CHECKINGACCOUNT ACCESSORS

        // Overriden in CheckingAccount
        public virtual decimal MinBalance
        { get { return 0; } }

        // Overriden in CheckingAccount
        public virtual decimal Fees
        { get { return 0; } }

        #endregion

        #region SAVINGSACCOUNT ACCESSORS

        // Overriden in SavingsAccount
        public virtual decimal Interest
        { get { return 0; } }

        #endregion
    }
}
