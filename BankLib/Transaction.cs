using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib
{
    public enum TransactionType { Deposit = 1, Withdraw, TransferIn, TransferOut};

    public class Transaction
    {
        public Random rand = new Random();

        protected TransactionType _transactionType;
        protected string _transactionID;
        protected DateTime _dateTime;
        
        protected decimal _amount;
        protected string _description = "";

        protected string _debitedAccountNumberID = "";
        protected string _creditedAccountNumberID = "";

        public Transaction() { }
        
        public Transaction(TransactionType transactionType, decimal amount, DateTime dateTime, string debitedAccountNumberID, string creditedAccountNumberID, string description)
        {
            _transactionType = transactionType;
            _transactionID = rand.Next(100000000, 1000000000).ToString(); System.Threading.Thread.Sleep(16);
            
            _dateTime = dateTime;
            _description = description;

            _debitedAccountNumberID = debitedAccountNumberID;
            _creditedAccountNumberID = creditedAccountNumberID;

            if (transactionType == TransactionType.Withdraw || transactionType == TransactionType.TransferOut)
                _amount = -amount;
            else
                _amount = amount;
        }

        public Transaction(TransactionType transactionType, decimal amount, DateTime dateTime, string debitedAccountNumberID, string creditedAccountNumberID)
        {
            _transactionType = transactionType;
            _transactionID = rand.Next(100000000, 1000000000).ToString(); System.Threading.Thread.Sleep(16);

            _dateTime = dateTime;

            _debitedAccountNumberID = debitedAccountNumberID;
            _creditedAccountNumberID = creditedAccountNumberID;

            if (transactionType == TransactionType.Withdraw || transactionType == TransactionType.TransferOut)
                _amount = -amount;
            else
                _amount = amount;
        }

        #region ACCESSORS

        public string TransactionID
        { get { return _transactionID; } }

        public TransactionType TypeOfTransaction
        { get { return _transactionType; } }

        public decimal Amount
        { get { return _amount; } }

        public DateTime DateTime
        { get { return _dateTime; } }

        public string Description
        { get { return _description; } }

        public string DebitedAccountNumberID
        { get { return _debitedAccountNumberID; } }

        public string CreditedAccountNumberID
        { get { return _creditedAccountNumberID; } }

        #endregion
    }
}
