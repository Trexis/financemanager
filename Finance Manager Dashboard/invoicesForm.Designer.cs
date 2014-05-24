namespace Trexis.Finance.Manager
{
    partial class invoicesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(invoicesForm));
            this.listView = new System.Windows.Forms.ListView();
            this.number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.customer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Clerk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Debit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Credit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Balance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.textBoxCustomerFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxRepFilter = new System.Windows.Forms.TextBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonPayment = new System.Windows.Forms.Button();
            this.buttonFinalize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.number,
            this.customer,
            this.date,
            this.rep,
            this.Clerk,
            this.Debit,
            this.Credit,
            this.Balance});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(11, 82);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(660, 349);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.listView.Enter += new System.EventHandler(this.listView_Enter);
            // 
            // number
            // 
            this.number.Text = "#";
            this.number.Width = 46;
            // 
            // customer
            // 
            this.customer.Text = "Customer";
            this.customer.Width = 130;
            // 
            // date
            // 
            this.date.Text = "Date";
            this.date.Width = 72;
            // 
            // rep
            // 
            this.rep.Text = "Rep";
            this.rep.Width = 110;
            // 
            // Clerk
            // 
            this.Clerk.Text = "Clerk";
            this.Clerk.Width = 83;
            // 
            // Debit
            // 
            this.Debit.Text = "Debit";
            this.Debit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Debit.Width = 62;
            // 
            // Credit
            // 
            this.Credit.Text = "Credit";
            this.Credit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Balance
            // 
            this.Balance.Text = "Balance";
            this.Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Balance.Width = 70;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(677, 337);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(113, 23);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Delete Invoice";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(677, 408);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(113, 23);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(677, 82);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(113, 23);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Edit Invoice";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // textBoxCustomerFilter
            // 
            this.textBoxCustomerFilter.Location = new System.Drawing.Point(68, 14);
            this.textBoxCustomerFilter.Name = "textBoxCustomerFilter";
            this.textBoxCustomerFilter.Size = new System.Drawing.Size(270, 20);
            this.textBoxCustomerFilter.TabIndex = 1;
            this.textBoxCustomerFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Customer:";
            // 
            // buttonNew
            // 
            this.buttonNew.Image = global::Trexis.Finance.Manager.Properties.Resources.invoice_new_16x16;
            this.buttonNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNew.Location = new System.Drawing.Point(677, 12);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(113, 23);
            this.buttonNew.TabIndex = 3;
            this.buttonNew.Text = "New Invoice";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Start date:";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(68, 44);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(270, 20);
            this.dateTimePickerStart.TabIndex = 8;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "End Date:";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(401, 44);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(270, 20);
            this.dateTimePickerEnd.TabIndex = 10;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Rep:";
            // 
            // textBoxRepFilter
            // 
            this.textBoxRepFilter.Location = new System.Drawing.Point(401, 14);
            this.textBoxRepFilter.Name = "textBoxRepFilter";
            this.textBoxRepFilter.Size = new System.Drawing.Size(270, 20);
            this.textBoxRepFilter.TabIndex = 12;
            this.textBoxRepFilter.TextChanged += new System.EventHandler(this.textBoxRepFilter_TextChanged);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(677, 158);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(113, 23);
            this.buttonPrint.TabIndex = 13;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonPayment
            // 
            this.buttonPayment.Location = new System.Drawing.Point(677, 187);
            this.buttonPayment.Name = "buttonPayment";
            this.buttonPayment.Size = new System.Drawing.Size(113, 23);
            this.buttonPayment.TabIndex = 14;
            this.buttonPayment.Text = "Payment";
            this.buttonPayment.UseVisualStyleBackColor = true;
            this.buttonPayment.Click += new System.EventHandler(this.buttonPayment_Click);
            // 
            // buttonFinalize
            // 
            this.buttonFinalize.Location = new System.Drawing.Point(677, 216);
            this.buttonFinalize.Name = "buttonFinalize";
            this.buttonFinalize.Size = new System.Drawing.Size(113, 23);
            this.buttonFinalize.TabIndex = 15;
            this.buttonFinalize.Text = "Finalize";
            this.buttonFinalize.UseVisualStyleBackColor = true;
            this.buttonFinalize.Click += new System.EventHandler(this.buttonFinalize_Click);
            // 
            // invoicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 443);
            this.Controls.Add(this.buttonFinalize);
            this.Controls.Add(this.buttonPayment);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.textBoxRepFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCustomerFilter);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "invoicesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[*companyname*] Invoices";
            this.Load += new System.EventHandler(this.invoicesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.ColumnHeader customer;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.TextBox textBoxCustomerFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader rep;
        private System.Windows.Forms.TextBox textBoxRepFilter;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonPayment;
        private System.Windows.Forms.ColumnHeader Balance;
        private System.Windows.Forms.ColumnHeader Debit;
        private System.Windows.Forms.ColumnHeader Credit;
        private System.Windows.Forms.ColumnHeader Clerk;
        private System.Windows.Forms.Button buttonFinalize;
    }
}