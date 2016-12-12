using BankLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuyPham_20161017_BankAssignment
{
    public partial class Form1 : Form
    {
        Random rand = new Random();

        List<Account> accountList = new List<Account>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region ACCOUNT CONSTRUCTORS

            Account tempAccount;
            CheckingAccount tempCheckingAccount;
            SavingsAccount tempSavingsAccount;

            tempAccount = new Account(rand.Next(100, 1000), "Chase", "Pham", "Huy");
            accountList.Add(tempAccount);

            tempCheckingAccount = new CheckingAccount(rand.Next(200, 2000), "Chase", "Tillman", "Torin");
            accountList.Add(tempCheckingAccount);

            tempSavingsAccount = new SavingsAccount(rand.Next(300, 3000), "Chase", "Harmon", "Gabi");
            accountList.Add(tempSavingsAccount);

            tempAccount = new Account(rand.Next(400, 4000), "BECU", "Upega", "Naisha");
            accountList.Add(tempAccount);

            tempCheckingAccount = new CheckingAccount(rand.Next(500, 5000), "BECU", "Lopez", "Arnoldo");
            accountList.Add(tempCheckingAccount);

            tempSavingsAccount = new SavingsAccount(rand.Next(600, 6000), "BECU", "Rivera", "Mershelle");
            accountList.Add(tempSavingsAccount);

            tempAccount = new Account(rand.Next(700, 7000), "BOFA", "Domobroski", "James");
            accountList.Add(tempAccount);

            tempCheckingAccount = new CheckingAccount(rand.Next(800, 8000), "BOFA", "Icantspellhislastname", "Fedor");
            accountList.Add(tempCheckingAccount);

            tempSavingsAccount = new SavingsAccount(rand.Next(900, 9000), "BOFA", "Gilbert", "Yoshua");
            accountList.Add(tempSavingsAccount);

            tempAccount = new Account(rand.Next(1000, 10000), "Wells Fargo", "Jones", "Eric");
            accountList.Add(tempAccount);

            tempCheckingAccount = new CheckingAccount(rand.Next(1100, 11000), "Wells Fargo", "Thomas", "Kevin");
            accountList.Add(tempCheckingAccount);

            tempSavingsAccount = new SavingsAccount(rand.Next(1200, 12000), "Wells Fargo", "Nye", "Candice");
            accountList.Add(tempSavingsAccount);

            tempAccount = new Account(rand.Next(1300, 13000), "Citigroup", "Paul", "Jeffrey");
            accountList.Add(tempAccount);

            tempCheckingAccount = new CheckingAccount(rand.Next(1400, 14000), "Citigroup", "Wargot", "Polina");
            accountList.Add(tempCheckingAccount);

            tempSavingsAccount = new SavingsAccount(rand.Next(1500, 15000), "Citigroup", "Joseph", "Sonya");
            accountList.Add(tempSavingsAccount);

            TestWithdraw();
            TestDeposit();
            TestWithdraw();
            TestDeposit();
            TestWithdraw();
            TestTransferIn();

            #endregion

            InitializeCboAccounts();
            RefreshCboAccounts();

            RefreshListViewAccounts();
            listViewAccounts.Items[0].Selected = true;
            listViewAccounts.Items[0].Focused = true;

            RefreshListViewTransactions();
            TransferValidityCheck();

            ChangeDepositWithdrawButtonText();
        }

        #region INDEX TRIGGERS

        private void listViewAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeselectListViewTransactions();
            RefreshListViewTransactions();

            DeselectCboAccounts();
            RefreshCboAccounts();

            RefreshTxtAccountInfo();
            RefreshTxtTransactionInfo();

            TransferValidityCheck();
            DepositWithdrawValidityCheck();
        }

        private void listViewTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTxtTransactionInfo();
        }

        private void cboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            TransferValidityCheck();
        }

        private void mskTransfer_TextChanged(object sender, EventArgs e)
        {
            TransferValidityCheck();
        }

        private void radDeposit_CheckedChanged(object sender, EventArgs e)
        {
            DepositWithdrawValidityCheck();
            ChangeDepositWithdrawButtonText();
        }

        private void radWithdraw_CheckedChanged(object sender, EventArgs e)
        {
            ChangeDepositWithdrawButtonText();
        }

        private void mskDepositWithdraw_TextChanged(object sender, EventArgs e)
        {
            DepositWithdrawValidityCheck();
        }

        #endregion

        #region BUTTONS

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            bool isExecutionSuccessful = false;

            // Checks the state of transfer validity before executing.
            if (IsATransferPossible())
            {
                TransferMoney();
                isExecutionSuccessful = true;
            }
            else
                btnTransfer.Enabled = false;

            RefreshTxtAccountInfo();
            RefreshListViewTransactions();
            DeselectListViewTransactions();

            listViewTransactions.Items[0].Selected = true;
            listViewTransactions.Items[0].Focused = true;

            // Checks the state of tranfer validity after execution occurs... if it did occur.
            if (isExecutionSuccessful)
            {
                if (IsATransferPossible() == false)
                    btnTransfer.Enabled = false;
            } 
        }

        private void btnDepositWithdraw_Click(object sender, EventArgs e)
        {
            bool isExecutionSuccessful = false;

            // Checks the state of deposit/withdraw validity before executing.
            if (radDeposit.Checked && IsADepositPossible())
            {
                DepositMoney();
                isExecutionSuccessful = true; 
            }    
            else if (radWithdraw.Checked && IsAWithdrawPossible())
            {
                WithdrawMoney();
                isExecutionSuccessful = true;
            }
            else
                btnDepositWithdraw.Enabled = false;

            // Checks the state of deposit/withdraw validity after execution occurs... if it did occur.
            if (isExecutionSuccessful)
            {
                if (radDeposit.Checked && IsADepositPossible() == false)
                    btnDepositWithdraw.Enabled = false;
                else if (radWithdraw.Checked && IsAWithdrawPossible() == false)
                    btnDepositWithdraw.Enabled = false;
                else
                    btnDepositWithdraw.Enabled = true;
            }
            
            RefreshTxtAccountInfo();
            RefreshListViewTransactions();

            listViewTransactions.Items[0].Selected = true;
            listViewTransactions.Items[0].Focused = true;
        }

        #endregion

        #region METHODS

        #region TRANSFER-RELATED METHODS

        private void InitializeCboAccounts()
        {
            cboDestinationAccount.DropDownWidth = 250;
        }

        private void RefreshCboAccounts()
        {
            cboDestinationAccount.Items.Clear();

            string accountInfo;

            foreach (Account account in accountList)
                if (account.AccountNumberID != GetSelectedAccountId())
                {
                    accountInfo = account.AccountNumberID + "    " + account.BankName + " - " + account.LastName + ", " + account.FirstName;
                    cboDestinationAccount.Items.Add(accountInfo);
                }
        }

        private void DeselectCboAccounts()
        {
            cboDestinationAccount.SelectedIndex = -1;
        }

        private void TransferValidityCheck()
        {
            btnTransfer.Enabled = false;

            if (listViewAccounts.SelectedIndices.Count > 0)
                if (cboDestinationAccount.SelectedIndex >= 0)
                {
                    string selectedAccountId = GetSelectedAccountId();
                    string selectedTransferDestinationId = GetSelectedTransferDestinationId();

                    if (selectedAccountId != selectedTransferDestinationId)
                        if (IsItAValidNonZeroDecimal(mskTransfer.Text))
                        {
                            if (ParseStringToDecimal(mskTransfer.Text) <= GetSelectedAccountBalance())
                                btnTransfer.Enabled = true;
                            else
                            {
                                MessageBox.Show("You cannot request transfer USD amount greater than current balance. Please try again.");
                                mskTransfer.ResetText();
                            }       
                        }
                }
        }

        private bool IsATransferPossible()
        {
            bool isATransferPossible = false;

            if (listViewAccounts.SelectedIndices.Count > 0)
                if (cboDestinationAccount.SelectedIndex >= 0)
                {
                    string selectedAccountId = GetSelectedAccountId();
                    string selectedTransferDestinationId = GetSelectedTransferDestinationId();

                    if (selectedAccountId != selectedTransferDestinationId)
                        if (IsItAValidNonZeroDecimal(mskTransfer.Text))
                            if (ParseStringToDecimal(mskTransfer.Text) <= GetSelectedAccountBalance())
                                isATransferPossible = true; 
                }

            return isATransferPossible;
        }

        private void TransferMoney()
        {
            string withdrawId = GetSelectedAccountId();
            string depositId = GetSelectedTransferDestinationId();
            
            decimal amountLocal = ParseStringToDecimal(mskTransfer.Text);

            // Let's try LINQ. HQP 20161103.
            Account accountDebited = accountList.First(x => x.AccountNumberID == withdrawId);
            accountDebited.TransferTo(depositId, amountLocal);

            // Let's try LINQ. HQP 20161103.
            Account accountCredited = accountList.First(x => x.AccountNumberID == depositId);
            accountCredited.TransferIn(withdrawId, amountLocal);
        }

        #endregion

        #region DEPOSIT-WITHDRAW-RELATED METHODS

        private void ChangeDepositWithdrawButtonText()
        {
            if (radDeposit.Checked)
                btnDepositWithdraw.Text = "Deposit";
            else if (radWithdraw.Checked)
                btnDepositWithdraw.Text = "Withdraw";
        }

        private void DepositWithdrawValidityCheck()
        {
            btnDepositWithdraw.Enabled = false;

            if (radDeposit.Checked)
            {
                if (listViewAccounts.SelectedIndices.Count > 0)
                    if (IsItAValidNonZeroDecimal(mskDepositWithdraw.Text))
                    {
                        string selectedAccountId = GetSelectedAccountId();

                        foreach (Account account in accountList)

                            if (account.AccountNumberID == selectedAccountId)
                            {
                                if (account.CurrentBalance < 250000)
                                    btnDepositWithdraw.Enabled = true;
                                else
                                    MessageBox.Show("You cannot deposit into this account currently, we can't insure balances over $250,000.00.");
                            }
                    }
                    else
                        btnDepositWithdraw.Enabled = false;
            }
                
            else if (radWithdraw.Checked)
            {
                if (listViewAccounts.SelectedIndices.Count > 0)
                    if (IsItAValidNonZeroDecimal(mskDepositWithdraw.Text))
                    {
                        string selectedAccountId = GetSelectedAccountId();

                        foreach (Account account in accountList)

                            if (account.AccountNumberID == selectedAccountId)
                            {
                                if (account.CurrentBalance > -1000)
                                    btnDepositWithdraw.Enabled = true;
                                else
                                    MessageBox.Show("You cannot withdraw from this account currently, you are at least " + account.CurrentBalance.ToString("c") + " in debt!");
                            }
                    }
                    else
                        btnDepositWithdraw.Enabled = false;
            }
        }

        private bool IsADepositPossible()
        {
            bool isADepositPossible = false;

            if (listViewAccounts.SelectedIndices.Count > 0)
                if (IsItAValidNonZeroDecimal(mskDepositWithdraw.Text))
                {
                    string selectedAccountId = GetSelectedAccountId();

                    foreach (Account account in accountList)
                        if (account.AccountNumberID == selectedAccountId)
                            if (account.CurrentBalance < 250000)
                                isADepositPossible = true;
                }

            return isADepositPossible;
        }

        private bool IsAWithdrawPossible()
        {
            bool isAWithdrawPossible = false;

            if (listViewAccounts.SelectedIndices.Count > 0)
                if (IsItAValidNonZeroDecimal(mskDepositWithdraw.Text))
                {
                    string selectedAccountId = GetSelectedAccountId();

                    foreach (Account account in accountList)
                        if (account.AccountNumberID == selectedAccountId)       
                            if (account.CurrentBalance > -10)
                                isAWithdrawPossible = true;                      
                }

            return isAWithdrawPossible;
        }

        private void DepositMoney()
        {
            string depositId = GetSelectedAccountId();
            decimal amountLocal = ParseStringToDecimal(mskDepositWithdraw.Text);

            foreach (Account account in accountList)
                if (account.AccountNumberID == depositId)
                {
                    account.Deposit(amountLocal);
                    break;
                }
        }

        private void WithdrawMoney()
        {
            string withdrawId = GetSelectedAccountId();
            decimal amountLocal = ParseStringToDecimal(mskDepositWithdraw.Text);

            foreach (Account account in accountList)
                if (account.AccountNumberID == withdrawId)
                {
                    if (account is SavingsAccount)
                    {
                        SavingsAccount tempSavingsAccount = (SavingsAccount)account;
                        tempSavingsAccount.Withdraw(amountLocal);
                        break;
                    }
                    else if (account is CheckingAccount)
                    {
                        CheckingAccount tempCheckingAccount = (CheckingAccount)account;
                        tempCheckingAccount.Withdraw(amountLocal);
                        break;
                    }
                    else
                    {
                        account.Withdraw(amountLocal);
                        break;
                    } 
                }
        }

        #endregion

        #region RETURN METHODS

        private string GetSelectedTransactionId()
        {
            string transactionId = "";

            if (listViewTransactions.SelectedIndices.Count > 0)
            {
                ListViewItem selectedItem = listViewTransactions.SelectedItems[0];
                transactionId = selectedItem.SubItems[0].Text;
                return transactionId;
            }
            else
                return transactionId;
        }

        private string GetSelectedAccountId()
        {
            string accountIdLocal = "";

            if (listViewAccounts.SelectedIndices.Count > 0)
            {
                ListViewItem selectedItem = listViewAccounts.SelectedItems[0];
                accountIdLocal = selectedItem.SubItems[0].Text;
                return accountIdLocal;
            }
            return accountIdLocal;
        }

        private decimal GetSelectedAccountBalance()
        {
            string selectedAccountId;
            decimal accountBalance = 0;

            if (listViewAccounts.SelectedIndices.Count > 0)
            {
                ListViewItem selectedItem = listViewAccounts.SelectedItems[0];
                selectedAccountId = selectedItem.SubItems[0].Text;

                // Let's try LINQ. HQP 20161103.
                Account account = accountList.First(x => x.AccountNumberID == selectedAccountId);
                accountBalance = account.CurrentBalance;

                // The old loop way. HQP 20161103.
                //
                //  foreach (Account account in accountList)
                //      if (account.AccountNumberID == selectedAccountID)
                //          accountBalance = account.CurrentBalance;
            }

            return accountBalance;
        }

        private string GetSelectedTransferDestinationId()
        {
            string transferDestinationId = "";

            if (cboDestinationAccount.SelectedIndex > -1)
                transferDestinationId = cboDestinationAccount.Text.Substring(0, 9);

            return transferDestinationId;
        }

        private string DisplayNameFromAccountId(string accountNumberId)
        {
            string accountInfo = "N/A";

            foreach (Account account in accountList)
                if (account.AccountNumberID == accountNumberId)
                {
                    accountInfo = account.BankName + " - " + account.LastName + ", " + account.FirstName + " (" + accountNumberId + ") ";
                    break;
                }

            return accountInfo;
        }

        private decimal ParseStringToDecimal(string input)
        {
            string modifiedInput = input.Replace(" ", "");
            modifiedInput = modifiedInput.Replace(",", "");
            modifiedInput = modifiedInput.Replace("$", "");

            bool isItAValidNonZeroDecimal = IsItAValidNonZeroDecimal(modifiedInput);

            if (isItAValidNonZeroDecimal)
            {
                decimal amountLocal = Decimal.Parse(modifiedInput);
                return amountLocal;
            }
            else
            {
                decimal amount = 0;
                return amount;
            }
        }

        private bool IsItAValidNonZeroDecimal(string input)
        {
            input = input.Replace(" ", "");
            input = input.Replace(",", "");
            input = input.Replace("$", "");

            decimal validDecimalValue;
            bool isItAValidDecimal = Decimal.TryParse(input, out validDecimalValue);

            bool validNonZeroDecimal = false;
            if (isItAValidDecimal && validDecimalValue > 0)
                validNonZeroDecimal = true;

            return validNonZeroDecimal;
        }

        #endregion

        #region REFRESH METHODS

        private void RefreshListViewAccounts()
        {
            listViewAccounts.Items.Clear();

            string[] tempString = new string[6];
            ListViewItem tempListviewItem;

            foreach (Account account in accountList)
            {
                tempString[0] = account.AccountNumberID;
                tempString[1] = account.BankName;
                tempString[2] = account.LastName;
                tempString[3] = account.FirstName;

                tempListviewItem = new ListViewItem(tempString);
                listViewAccounts.Items.Add(tempListviewItem);
            }

            DeselectListViewTransactions();
        }

        private void RefreshListViewTransactions()
        {
            listViewTransactions.Items.Clear();

            if (listViewAccounts.SelectedIndices.Count > 0)
            {
                string selectedAccountId = GetSelectedAccountId();

                foreach (Account account in accountList)
                    if (account.AccountNumberID == selectedAccountId)
                    {
                        string[] tempString = new string[6];
                        ListViewItem tempListviewItem;

                        foreach (Transaction transaction in account.TransactionList)
                        {
                            tempString[0] = transaction.TransactionID;
                            tempString[1] = transaction.TypeOfTransaction.ToString();
                            tempString[2] = transaction.DebitedAccountNumberID;
                            tempString[3] = transaction.CreditedAccountNumberID;
                            tempString[4] = transaction.DateTime.ToString(CultureInfo.InvariantCulture);
                            tempString[5] = transaction.Amount.ToString("c");

                            tempListviewItem = new ListViewItem(tempString);
                            listViewTransactions.Items.Add(tempListviewItem);
                        }

                        listViewTransactions.Items[0].Selected = true;
                        listViewTransactions.Items[0].Focused = true;

                        break;
                    }
            } 
        }

        private void RefreshTxtAccountInfo()
        {
            txtAccountInfo.Clear();

            if (listViewAccounts.SelectedIndices.Count > 0)
            {
                string selectedAccountId = GetSelectedAccountId();

                foreach (Account account in accountList)
                    if (account.AccountNumberID == selectedAccountId)
                    {
                        txtAccountInfo.Text += "Account ID: " + "\t\t" + account.AccountNumberID + "\n";
                        txtAccountInfo.Text += "Account Bank: " + "\t\t" + account.BankName + "\n";
                        txtAccountInfo.Text += "Account Type: " + "\t\t" + account.GetAccountType + "\n\n";

                        txtAccountInfo.Text += "Account Owner Last Name: " + "\t" + account.LastName + "\n";
                        txtAccountInfo.Text += "Account Owner First Name: " + "\t" + account.FirstName + "\n\n";

                        txtAccountInfo.Text += "Account Current Balance: " + "\t" + account.CurrentBalance.ToString("c") + "\n";
                    }
            }
        }

        private void RefreshTxtTransactionInfo()
        {
            txtTransactionInfo.Clear();

            if (listViewTransactions.SelectedIndices.Count > 0 && listViewAccounts.SelectedIndices.Count > 0)
            {
                string selectedAccountId = GetSelectedAccountId();
                string selectedTransactionId = GetSelectedTransactionId();

                foreach (Account account in accountList)
                    if (account.AccountNumberID == selectedAccountId)
                        foreach (Transaction transaction in account.TransactionList)
                            if (transaction.TransactionID == selectedTransactionId)
                            {
                                txtTransactionInfo.Text += "Transaction ID: " + "\t\t" + transaction.TransactionID + "\n";
                                txtTransactionInfo.Text += "Transaction Type: " + "\t\t" + transaction.TypeOfTransaction + "\n";
                                txtTransactionInfo.Text += "Time of Transaction: " + "\t" + transaction.DateTime + "\n\n";

                                if (transaction.TypeOfTransaction == TransactionType.TransferOut)
                                    txtTransactionInfo.Text += transaction.TypeOfTransaction + " amount: " + "\t" + transaction.Amount.ToString("c") + "\n\n";
                                else
                                    txtTransactionInfo.Text += transaction.TypeOfTransaction + " amount: " + "\t\t" + transaction.Amount.ToString("c") + "\n\n";

                                txtTransactionInfo.Text += "Transaction Withdrawn From: " + "\t" + DisplayNameFromAccountId(transaction.DebitedAccountNumberID) + " " + "\n";
                                txtTransactionInfo.Text += "Transaction Deposited To: " + "\t" + DisplayNameFromAccountId(transaction.CreditedAccountNumberID) + "\n\n";

                                txtTransactionInfo.Text += "Description: " + "\t\t" + transaction.Description;

                                break;
                            }
            }
        }

        #endregion

        #region OTHER METHODS

        private void DeselectListViewTransactions()
        {
            foreach (ListViewItem item in listViewTransactions.SelectedItems)
                item.Selected = false;
        }

        #endregion

        #region TEST TRANSACTION MODULE

        private void TestDeposit()
        {
            foreach (Account account in accountList)
            {
                decimal randomDepositAmount = rand.Next((int)(account.CurrentBalance % 2147483647)); System.Threading.Thread.Sleep(16);
                account.Deposit(randomDepositAmount, "Test Random Deposit");
            }
        }

        private void TestWithdraw()
        {
            foreach (Account account in accountList)
            {
                decimal randomWithdrawAmount = rand.Next((int)((account.CurrentBalance / 2m) % 2147483647)); System.Threading.Thread.Sleep(16);
                account.Withdraw(randomWithdrawAmount, "Test Random Withdraw");
            }
        }

        private void TestTransferIn()
        {
            List<string> accountNumberIdList = GetListOfAccountNumberId();
            List<string> scrambledAccountNumberIdList = ScrambleListOfAccountNumberIdOrder(accountNumberIdList);

            int iterations = scrambledAccountNumberIdList.Count;

            for (int i = 0; i < iterations; i++)
            {
                if (i < (iterations - 1))
                    CreateTransferTransactionPair(scrambledAccountNumberIdList[i+1], scrambledAccountNumberIdList[i]);
                else
                    CreateTransferTransactionPair(scrambledAccountNumberIdList[0], scrambledAccountNumberIdList[i]);  
            }
        }

        private void TestTransferOut()
        {
            List<string> accountNumberIdList = GetListOfAccountNumberId();
            List<string> scrambledAccountNumberIdList = ScrambleListOfAccountNumberIdOrder(accountNumberIdList);

            int iterations = scrambledAccountNumberIdList.Count;

            for (int i = 0; i < iterations; i++)
            {
                if (i < (iterations - 1))
                    CreateTransferTransactionPair(scrambledAccountNumberIdList[i], scrambledAccountNumberIdList[i+1]);
                else
                    CreateTransferTransactionPair(scrambledAccountNumberIdList[i], scrambledAccountNumberIdList[0]);
            }
        }

        private List<string> GetListOfAccountNumberId()
        {
            List<string> accountNumberIdList = new List<string>();

            foreach (Account account in accountList)
                accountNumberIdList.Add(account.AccountNumberID);

            return accountNumberIdList;
        }

        private List<string> ScrambleListOfAccountNumberIdOrder(List<string> listOfAccountNumberId)
        {
            List<string> tempList = listOfAccountNumberId.ToList();
            List<string> scrambledList = new List<string>();

            for (int i = 0; i < listOfAccountNumberId.Count; i++)
            {
                int randomNumber = rand.Next(tempList.Count); System.Threading.Thread.Sleep(16);
                string tempString = tempList[randomNumber];

                scrambledList.Add(tempString);
                tempList.RemoveAt(randomNumber);
            }

            return scrambledList;
        }

        private void CreateTransferTransactionPair(string transferOutAccountId, string transferInAccountId)
        {
            List<decimal> balanceList = new List<decimal>();

            foreach (Account account in accountList)
                if (account.AccountNumberID == transferOutAccountId || account.AccountNumberID == transferInAccountId)
                    balanceList.Add(account.CurrentBalance);

            decimal amountLocal = rand.Next((int)((balanceList.Min() / 2m) % 2147483647)); System.Threading.Thread.Sleep(16);

            foreach (Account account in accountList)
            {
                if (account.AccountNumberID == transferOutAccountId)
                    account.TransferTo(transferInAccountId, amountLocal, "Test Random Transfer In/Out");
                else if (account.AccountNumberID == transferInAccountId)
                    account.TransferIn(transferOutAccountId, amountLocal, "Test Random Transfer In/Out");
            }
        }

        #endregion

        #endregion
    }
}
