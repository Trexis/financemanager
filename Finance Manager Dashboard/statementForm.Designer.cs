namespace Trexis.Finance.Manager
{
    partial class statementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(statementForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.invoicenumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.invoicedate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Debit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Credit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Balance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.receiptnumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.labelClosingBalance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelOpeningBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(561, 471);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(467, 471);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 5;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.invoicenumber,
            this.invoicedate,
            this.Debit,
            this.Credit,
            this.Balance,
            this.receiptnumber});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(12, 44);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(624, 421);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // invoicenumber
            // 
            this.invoicenumber.Text = "Invoice Number";
            this.invoicenumber.Width = 98;
            // 
            // invoicedate
            // 
            this.invoicedate.Text = "Invoice Date";
            this.invoicedate.Width = 114;
            // 
            // Debit
            // 
            this.Debit.Text = "Debit";
            this.Debit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Debit.Width = 86;
            // 
            // Credit
            // 
            this.Credit.Text = "Credit";
            this.Credit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Credit.Width = 84;
            // 
            // Balance
            // 
            this.Balance.Text = "Balance";
            this.Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Balance.Width = 87;
            // 
            // receiptnumber
            // 
            this.receiptnumber.Text = "Receipt Number";
            this.receiptnumber.Width = 123;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Closing Balance:";
            // 
            // labelClosingBalance
            // 
            this.labelClosingBalance.AutoSize = true;
            this.labelClosingBalance.Location = new System.Drawing.Point(452, 9);
            this.labelClosingBalance.Name = "labelClosingBalance";
            this.labelClosingBalance.Size = new System.Drawing.Size(28, 13);
            this.labelClosingBalance.TabIndex = 8;
            this.labelClosingBalance.Text = "0.00";
            this.labelClosingBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Opening Balance:";
            // 
            // labelOpeningBalance
            // 
            this.labelOpeningBalance.AutoSize = true;
            this.labelOpeningBalance.Location = new System.Drawing.Point(225, 9);
            this.labelOpeningBalance.Name = "labelOpeningBalance";
            this.labelOpeningBalance.Size = new System.Drawing.Size(28, 13);
            this.labelOpeningBalance.TabIndex = 10;
            this.labelOpeningBalance.Text = "0.00";
            this.labelOpeningBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // statementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 501);
            this.Controls.Add(this.labelOpeningBalance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelClosingBalance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "statementForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Statement [*title*]";
            this.Load += new System.EventHandler(this.statementForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader invoicenumber;
        private System.Windows.Forms.ColumnHeader invoicedate;
        private System.Windows.Forms.ColumnHeader Debit;
        private System.Windows.Forms.ColumnHeader Credit;
        private System.Windows.Forms.ColumnHeader Balance;
        private System.Windows.Forms.ColumnHeader receiptnumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelClosingBalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelOpeningBalance;

    }
}