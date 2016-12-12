namespace HuyPham_20161017_BankAssignment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTransfer = new System.Windows.Forms.Button();
            this.listViewAccounts = new System.Windows.Forms.ListView();
            this.accountID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bankName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.firstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewTransactions = new System.Windows.Forms.ListView();
            this.transactID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.transactionType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.debitedID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.creditedID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboDestinationAccount = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radWithdraw = new System.Windows.Forms.RadioButton();
            this.radDeposit = new System.Windows.Forms.RadioButton();
            this.mskDepositWithdraw = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDepositWithdraw = new System.Windows.Forms.Button();
            this.grpTransfer = new System.Windows.Forms.GroupBox();
            this.mskTransfer = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountInfo = new System.Windows.Forms.RichTextBox();
            this.txtTransactionInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.grpTransfer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(6, 128);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(145, 23);
            this.btnTransfer.TabIndex = 0;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // listViewAccounts
            // 
            this.listViewAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.accountID,
            this.bankName,
            this.lastName,
            this.firstName});
            this.listViewAccounts.FullRowSelect = true;
            this.listViewAccounts.HideSelection = false;
            this.listViewAccounts.Location = new System.Drawing.Point(12, 12);
            this.listViewAccounts.MultiSelect = false;
            this.listViewAccounts.Name = "listViewAccounts";
            this.listViewAccounts.Size = new System.Drawing.Size(300, 480);
            this.listViewAccounts.TabIndex = 1;
            this.listViewAccounts.UseCompatibleStateImageBehavior = false;
            this.listViewAccounts.View = System.Windows.Forms.View.Details;
            this.listViewAccounts.SelectedIndexChanged += new System.EventHandler(this.listViewAccounts_SelectedIndexChanged);
            // 
            // accountID
            // 
            this.accountID.Text = "AccountID";
            this.accountID.Width = 72;
            // 
            // bankName
            // 
            this.bankName.Text = "Bank";
            this.bankName.Width = 67;
            // 
            // lastName
            // 
            this.lastName.Text = "LName";
            // 
            // firstName
            // 
            this.firstName.Text = "FName";
            // 
            // listViewTransactions
            // 
            this.listViewTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.transactID,
            this.transactionType,
            this.debitedID,
            this.creditedID,
            this.time,
            this.amount});
            this.listViewTransactions.FullRowSelect = true;
            this.listViewTransactions.HideSelection = false;
            this.listViewTransactions.Location = new System.Drawing.Point(318, 305);
            this.listViewTransactions.MultiSelect = false;
            this.listViewTransactions.Name = "listViewTransactions";
            this.listViewTransactions.Size = new System.Drawing.Size(556, 187);
            this.listViewTransactions.TabIndex = 2;
            this.listViewTransactions.UseCompatibleStateImageBehavior = false;
            this.listViewTransactions.View = System.Windows.Forms.View.Details;
            this.listViewTransactions.SelectedIndexChanged += new System.EventHandler(this.listViewTransactions_SelectedIndexChanged);
            // 
            // transactID
            // 
            this.transactID.Text = "TXID";
            this.transactID.Width = 72;
            // 
            // transactionType
            // 
            this.transactionType.Text = "TXType";
            this.transactionType.Width = 68;
            // 
            // debitedID
            // 
            this.debitedID.Text = "DebitedID";
            this.debitedID.Width = 72;
            // 
            // creditedID
            // 
            this.creditedID.Text = "CreditedID";
            this.creditedID.Width = 72;
            // 
            // time
            // 
            this.time.Text = "Time of Transaction";
            this.time.Width = 139;
            // 
            // amount
            // 
            this.amount.Text = "Amount";
            this.amount.Width = 81;
            // 
            // cboDestinationAccount
            // 
            this.cboDestinationAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestinationAccount.FormattingEnabled = true;
            this.cboDestinationAccount.Location = new System.Drawing.Point(6, 66);
            this.cboDestinationAccount.MaxDropDownItems = 99;
            this.cboDestinationAccount.Name = "cboDestinationAccount";
            this.cboDestinationAccount.Size = new System.Drawing.Size(145, 21);
            this.cboDestinationAccount.TabIndex = 4;
            this.cboDestinationAccount.SelectedIndexChanged += new System.EventHandler(this.cboAccounts_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radWithdraw);
            this.groupBox1.Controls.Add(this.radDeposit);
            this.groupBox1.Controls.Add(this.mskDepositWithdraw);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnDepositWithdraw);
            this.groupBox1.Location = new System.Drawing.Point(318, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 114);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deposit or Withdraw";
            // 
            // radWithdraw
            // 
            this.radWithdraw.AutoSize = true;
            this.radWithdraw.Location = new System.Drawing.Point(79, 26);
            this.radWithdraw.Name = "radWithdraw";
            this.radWithdraw.Size = new System.Drawing.Size(70, 17);
            this.radWithdraw.TabIndex = 4;
            this.radWithdraw.TabStop = true;
            this.radWithdraw.Text = "Withdraw";
            this.radWithdraw.UseVisualStyleBackColor = true;
            this.radWithdraw.CheckedChanged += new System.EventHandler(this.radWithdraw_CheckedChanged);
            // 
            // radDeposit
            // 
            this.radDeposit.AutoSize = true;
            this.radDeposit.Checked = true;
            this.radDeposit.Location = new System.Drawing.Point(12, 26);
            this.radDeposit.Name = "radDeposit";
            this.radDeposit.Size = new System.Drawing.Size(61, 17);
            this.radDeposit.TabIndex = 3;
            this.radDeposit.TabStop = true;
            this.radDeposit.Text = "Deposit";
            this.radDeposit.UseVisualStyleBackColor = true;
            this.radDeposit.CheckedChanged += new System.EventHandler(this.radDeposit_CheckedChanged);
            // 
            // mskDepositWithdraw
            // 
            this.mskDepositWithdraw.Location = new System.Drawing.Point(92, 59);
            this.mskDepositWithdraw.Mask = "$99,999.00";
            this.mskDepositWithdraw.Name = "mskDepositWithdraw";
            this.mskDepositWithdraw.Size = new System.Drawing.Size(59, 20);
            this.mskDepositWithdraw.TabIndex = 2;
            this.mskDepositWithdraw.Text = "0000100";
            this.mskDepositWithdraw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mskDepositWithdraw.TextChanged += new System.EventHandler(this.mskDepositWithdraw_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Amount (USD)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDepositWithdraw
            // 
            this.btnDepositWithdraw.Location = new System.Drawing.Point(6, 85);
            this.btnDepositWithdraw.Name = "btnDepositWithdraw";
            this.btnDepositWithdraw.Size = new System.Drawing.Size(145, 23);
            this.btnDepositWithdraw.TabIndex = 0;
            this.btnDepositWithdraw.Text = "Deposit/Withdraw";
            this.btnDepositWithdraw.UseVisualStyleBackColor = true;
            this.btnDepositWithdraw.Click += new System.EventHandler(this.btnDepositWithdraw_Click);
            // 
            // grpTransfer
            // 
            this.grpTransfer.Controls.Add(this.mskTransfer);
            this.grpTransfer.Controls.Add(this.label2);
            this.grpTransfer.Controls.Add(this.label1);
            this.grpTransfer.Controls.Add(this.cboDestinationAccount);
            this.grpTransfer.Controls.Add(this.btnTransfer);
            this.grpTransfer.Location = new System.Drawing.Point(318, 12);
            this.grpTransfer.Name = "grpTransfer";
            this.grpTransfer.Size = new System.Drawing.Size(157, 158);
            this.grpTransfer.TabIndex = 7;
            this.grpTransfer.TabStop = false;
            this.grpTransfer.Text = "Transfer from Selected Account To Destination Account";
            // 
            // mskTransfer
            // 
            this.mskTransfer.Location = new System.Drawing.Point(92, 102);
            this.mskTransfer.Mask = "$99,999.00";
            this.mskTransfer.Name = "mskTransfer";
            this.mskTransfer.Size = new System.Drawing.Size(59, 20);
            this.mskTransfer.TabIndex = 3;
            this.mskTransfer.Text = "0000100";
            this.mskTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mskTransfer.TextChanged += new System.EventHandler(this.mskTransfer_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Amount (USD)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Destination Account";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAccountInfo
            // 
            this.txtAccountInfo.Location = new System.Drawing.Point(481, 12);
            this.txtAccountInfo.Name = "txtAccountInfo";
            this.txtAccountInfo.ReadOnly = true;
            this.txtAccountInfo.Size = new System.Drawing.Size(393, 122);
            this.txtAccountInfo.TabIndex = 3;
            this.txtAccountInfo.Text = "";
            // 
            // txtTransactionInfo
            // 
            this.txtTransactionInfo.Location = new System.Drawing.Point(481, 140);
            this.txtTransactionInfo.Name = "txtTransactionInfo";
            this.txtTransactionInfo.ReadOnly = true;
            this.txtTransactionInfo.Size = new System.Drawing.Size(393, 159);
            this.txtTransactionInfo.TabIndex = 4;
            this.txtTransactionInfo.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 504);
            this.Controls.Add(this.txtAccountInfo);
            this.Controls.Add(this.txtTransactionInfo);
            this.Controls.Add(this.grpTransfer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewTransactions);
            this.Controls.Add(this.listViewAccounts);
            this.Name = "Form1";
            this.Text = "HuyPham_20161017_LabAssignment_BankAccountInheritance";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpTransfer.ResumeLayout(false);
            this.grpTransfer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.ListView listViewAccounts;
        private System.Windows.Forms.ListView listViewTransactions;
        private System.Windows.Forms.ComboBox cboDestinationAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpTransfer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDepositWithdraw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskDepositWithdraw;
        private System.Windows.Forms.MaskedTextBox mskTransfer;
        private System.Windows.Forms.RadioButton radWithdraw;
        private System.Windows.Forms.RadioButton radDeposit;
        private System.Windows.Forms.ColumnHeader accountID;
        private System.Windows.Forms.ColumnHeader bankName;
        private System.Windows.Forms.ColumnHeader lastName;
        private System.Windows.Forms.ColumnHeader firstName;
        private System.Windows.Forms.ColumnHeader transactID;
        private System.Windows.Forms.ColumnHeader transactionType;
        private System.Windows.Forms.ColumnHeader debitedID;
        private System.Windows.Forms.ColumnHeader creditedID;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.RichTextBox txtAccountInfo;
        private System.Windows.Forms.RichTextBox txtTransactionInfo;
    }
}

