namespace Trexis.Finance.Manager
{
    partial class reportsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reportsForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.groupBoxTimeframe = new System.Windows.Forms.GroupBox();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.labelEnddate = new System.Windows.Forms.Label();
            this.labelStartdate = new System.Windows.Forms.Label();
            this.checkBoxTimeframe = new System.Windows.Forms.CheckBox();
            this.groupBoxTimeframe.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(561, 473);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(467, 473);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 5;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // listView
            // 
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(12, 68);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(624, 400);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // groupBoxTimeframe
            // 
            this.groupBoxTimeframe.Controls.Add(this.checkBoxTimeframe);
            this.groupBoxTimeframe.Controls.Add(this.dateTimePickerEnd);
            this.groupBoxTimeframe.Controls.Add(this.dateTimePickerStart);
            this.groupBoxTimeframe.Controls.Add(this.labelEnddate);
            this.groupBoxTimeframe.Controls.Add(this.labelStartdate);
            this.groupBoxTimeframe.Location = new System.Drawing.Point(13, 13);
            this.groupBoxTimeframe.Name = "groupBoxTimeframe";
            this.groupBoxTimeframe.Size = new System.Drawing.Size(623, 50);
            this.groupBoxTimeframe.TabIndex = 7;
            this.groupBoxTimeframe.TabStop = false;
            this.groupBoxTimeframe.Text = "Timeframe Filter";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(396, 19);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(215, 20);
            this.dateTimePickerEnd.TabIndex = 18;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(83, 19);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(215, 20);
            this.dateTimePickerStart.TabIndex = 16;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // labelEnddate
            // 
            this.labelEnddate.AutoSize = true;
            this.labelEnddate.Location = new System.Drawing.Point(335, 21);
            this.labelEnddate.Name = "labelEnddate";
            this.labelEnddate.Size = new System.Drawing.Size(55, 13);
            this.labelEnddate.TabIndex = 17;
            this.labelEnddate.Text = "End Date:";
            // 
            // labelStartdate
            // 
            this.labelStartdate.AutoSize = true;
            this.labelStartdate.Location = new System.Drawing.Point(21, 21);
            this.labelStartdate.Name = "labelStartdate";
            this.labelStartdate.Size = new System.Drawing.Size(56, 13);
            this.labelStartdate.TabIndex = 15;
            this.labelStartdate.Text = "Start date:";
            // 
            // checkBoxTimeframe
            // 
            this.checkBoxTimeframe.AutoSize = true;
            this.checkBoxTimeframe.Location = new System.Drawing.Point(6, 0);
            this.checkBoxTimeframe.Name = "checkBoxTimeframe";
            this.checkBoxTimeframe.Size = new System.Drawing.Size(100, 17);
            this.checkBoxTimeframe.TabIndex = 19;
            this.checkBoxTimeframe.Text = "Timeframe Filter";
            this.checkBoxTimeframe.UseVisualStyleBackColor = true;
            this.checkBoxTimeframe.CheckedChanged += new System.EventHandler(this.checkBoxTimeframe_CheckedChanged);
            // 
            // reportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 501);
            this.Controls.Add(this.groupBoxTimeframe);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "reportsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[*title*]";
            this.Load += new System.EventHandler(this.reportsForm_Load);
            this.groupBoxTimeframe.ResumeLayout(false);
            this.groupBoxTimeframe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.GroupBox groupBoxTimeframe;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label labelEnddate;
        private System.Windows.Forms.Label labelStartdate;
        private System.Windows.Forms.CheckBox checkBoxTimeframe;

    }
}