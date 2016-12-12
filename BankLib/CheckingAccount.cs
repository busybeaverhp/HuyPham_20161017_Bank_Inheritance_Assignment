using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib
{
    public class CheckingAccount : Account
    {
        Random rand = new Random();

        protected decimal _minBalance = 500;
        protected decimal _fees = 10;

        public CheckingAccount() { }

        public CheckingAccount(decimal currentBalance, string bankName, string lastName, string firstName)
        {
            _accountType = AccountType.CheckingAccount;
            _accountNumberID = rand.Next(100000000, 1000000000).ToString(); System.Threading.Thread.Sleep(16);
            
            _bankName = bankName;
            _lastName = lastName;
            _firstName = firstName;

            _currentBalance = currentBalance;
            _transactionList = new List<Transaction>();

            Transaction tempTransaction = new Transaction(TransactionType.Deposit, currentBalance, DateTime.Now, "N/A", _accountNumberID, "Initialized Balance State");
            AddTransaction(tempTransaction);
        }

        public override void Withdraw(decimal amount)
        {
            if ((_currentBalance - amount) < _minBalance)
            {
                string penaltyMessage = "Withdrawing " + amount.ToString("c") + " changes current balance to below the minimum balance threshold " + "(" + _minBalance.ToString("c") + "), " + _fees.ToString("c") + " fine charged in the following transaction.";

                Transaction tempTransaction = new Transaction(TransactionType.Withdraw, amount, DateTime.Now, _accountNumberID, "N/A", penaltyMessage);
                AddTransaction(tempTransaction);
                _currentBalance -= (amount);

                string penaltyMessage2 = "Penalty fee of " + _fees.ToString("c") + " incurred upon decreasing current balance below minimum threshold of " + _minBalance.ToString("c");

                Transaction tempTransaction2 = new Transaction(TransactionType.Withdraw, _fees, DateTime.Now, _accountNumberID, "N/A", penaltyMessage2);
                AddTransaction(tempTransaction2);
                _currentBalance -= (_fees);
            }
            
            else
            {
                Transaction tempTransaction = new Transaction(TransactionType.Withdraw, amount, DateTime.Now, _accountNumberID, "N/A");
                AddTransaction(tempTransaction);
                _currentBalance -= amount;
            }    
        }

        public override void Withdraw(decimal amount, string description)
        {
            if ((_currentBalance - amount) < _minBalance)
            {
                string penaltyMessage = "Withdrawing " + amount.ToString("c") + " changes current balance to below the minimum balance threshold " + "(" + _minBalance.ToString("c") + "), " + _fees.ToString("c") + " fine charged in the following transaction.";

                Transaction tempTransaction = new Transaction(TransactionType.Withdraw, amount, DateTime.Now, _accountNumberID, "N/A", penaltyMessage);
                AddTransaction(tempTransaction);
                _currentBalance -= (amount);

                string penaltyMessage2 = "Penalty fee of " + _fees.ToString("c") + " incurred upon decreasing current balance below minimum threshold of " + _minBalance.ToString("c");

                Transaction tempTransaction2 = new Transaction(TransactionType.Withdraw, _fees, DateTime.Now, _accountNumberID, "N/A", penaltyMessage2);
                AddTransaction(tempTransaction2);
                _currentBalance -= (_fees);
            }
                
            else
            {
                Transaction tempTransaction = new Transaction(TransactionType.Withdraw, amount, DateTime.Now, _accountNumberID, "N/A", description);
                AddTransaction(tempTransaction);
                _currentBalance -= amount;
            }
        }

        #region ACCESSORS

        public override decimal MinBalance
        { get { return _minBalance; } }

        public override decimal Fees
        { get { return _fees; } }

        #endregion
    }
}
