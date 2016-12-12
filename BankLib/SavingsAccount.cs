using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib
{
    public class SavingsAccount : Account
    {
        Random rand = new Random();

        protected decimal _interest = 0.02m;

        public SavingsAccount() { }

        public SavingsAccount(decimal currentBalance, string bankName, string lastName, string firstName)
        {
            _accountType = AccountType.SavingsAccount;
            _accountNumberID = rand.Next(100000000, 1000000000).ToString(); System.Threading.Thread.Sleep(16);

            _bankName = bankName;
            
            _lastName = lastName;
            _firstName = firstName;

            _currentBalance = currentBalance;
            _transactionList = new List<Transaction>();

            Transaction tempTransaction = new Transaction(TransactionType.Deposit, currentBalance, DateTime.Now, "N/A", _accountNumberID, "Initialized Balance State");
            AddTransaction(tempTransaction);
        }

        public override void ApplyInterest()
        {
            _currentBalance *= (1 + _interest);
        }

        public override decimal Interest
        { get { return _interest; } }
    }
}