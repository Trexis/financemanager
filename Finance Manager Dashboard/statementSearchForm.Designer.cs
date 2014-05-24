namespace Trexis.Finance.Manager
{
    partial class statementSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(statementSearchForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonComplete = new System.Windows.Forms.RadioButton();
            this.radioButtonDateRange = new System.Windows.Forms.RadioButton();
            this.radioButtonLastZero = new System.Windows.Forms.RadioButton();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.labelBalance = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonComplete);
            this.groupBox2.Controls.Add(this.radioButtonDateRange);
            this.groupBox2.Controls.Add(this.radioButtonLastZero);
            this.groupBox2.Controls.Add(this.dateTimePickerEnd);
            this.groupBox2.Controls.Add(this.labelEndDate);
            this.groupBox2.Controls.Add(this.dateTimePickerStart);
            this.groupBox2.Controls.Add(this.labelBalance);
            this.groupBox2.Controls.Add(this.labelStartDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.labelCustomer);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 216);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // radioButtonComplete
            // 
            this.radioButtonComplete.AutoSize = true;
            this.radioButtonComplete.Location = new System.Drawing.Point(10, 101);
            this.radioButtonComplete.Name = "radioButtonComplete";
            this.radioButtonComplete.Size = new System.Drawing.Size(164, 17);
            this.radioButtonComplete.TabIndex = 18;
            this.radioButtonComplete.TabStop = true;
            this.radioButtonComplete.Text = "Generate complete statement";
            this.radioButtonComplete.UseVisualStyleBackColor = true;
            // 
            // radioButtonDateRange
            // 
            this.radioButtonDateRange.AutoSize = true;
            this.radioButtonDateRange.Location = new System.Drawing.Point(10, 124);
            this.radioButtonDateRange.Name = "radioButtonDateRange";
            this.radioButtonDateRange.Size = new System.Drawing.Size(190, 17);
            this.radioButtonDateRange.TabIndex = 17;
            this.radioButtonDateRange.Text = "Generate statement for date range:";
            this.radioButtonDateRange.UseVisualStyleBackColor = true;
            this.radioButtonDateRange.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButtonLastZero
            // 
            this.radioButtonLastZero.AutoSize = true;
            this.radioButtonLastZero.Checked = true;
            this.radioButtonLastZero.Location = new System.Drawing.Point(10, 77);
            this.radioButtonLastZero.Name = "radioButtonLastZero";
            this.radioButtonLastZero.Size = new System.Drawing.Size(229, 17);
            this.radioButtonLastZero.TabIndex = 16;
            this.radioButtonLastZero.TabStop = true;
            this.radioButtonLastZero.Text = "Generate statement since last zero balance";
            this.radioButtonLastZero.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(86, 180);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(233, 20);
            this.dateTimePickerEnd.TabIndex = 15;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(26, 187);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(55, 13);
            this.labelEndDate.TabIndex = 14;
            this.labelEndDate.Text = "End Date:";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(86, 154);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(233, 20);
            this.dateTimePickerStart.TabIndex = 13;
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Location = new System.Drawing.Point(74, 47);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(28, 13);
            this.labelBalance.TabIndex = 7;
            this.labelBalance.Text = "0.00";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(26, 159);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(56, 13);
            this.labelStartDate.TabIndex = 12;
            this.labelStartDate.Text = "Start date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Balance:";
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(74, 20);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(76, 13);
            this.labelCustomer.TabIndex = 4;
            this.labelCustomer.Text = "customername";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(272, 235);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(110, 235);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 11;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(191, 235);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 12;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // statementSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 264);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "statementSearchForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statement [*customername*]";
            this.Load += new System.EventHandler(this.statementForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.RadioButton radioButtonDateRange;
        private System.Windows.Forms.RadioButton radioButtonLastZero;
        private System.Windows.Forms.RadioButton radioButtonComplete;
        private System.Windows.Forms.Button buttonPrint;
    }
}