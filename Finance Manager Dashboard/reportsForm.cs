using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trexis.Finance.Manager
{
    public partial class reportsForm : Form
    {
        private Context context;
        private Report report;

        public reportsForm(Context context, ReportType reporttype)
        {
            this.context = context;

            InitializeComponent();

            this.report = new Report(reporttype);
            populateFields();
        }


        private void populateFields()
        {
            dateTimePickerStart.Value = DateTime.Now.AddMonths(-1);
            enableTimeframe(checkBoxTimeframe.Checked);
            loadList();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void reportsForm_Load(object sender, EventArgs e)
        {
            
            this.Text = this.Text.Replace("[*title*]", this.report.Title);
        }

        private void enableTimeframe(Boolean enabled)
        {
            labelStartdate.Enabled = enabled;
            labelEnddate.Enabled = enabled;
            dateTimePickerStart.Enabled = enabled;
            dateTimePickerEnd.Enabled = enabled;
        }

        private void loadList()
        {

            try
            {
                listView.Columns.Clear();
                listView.Items.Clear();

                HashSet<String[]> listentries = this.report.Entries;
                int counter = 0;
                foreach (String[] listentry in listentries)
                {
                    //first entry is column headers
                    if (counter == 0)
                    {
                        for (int i = 0; i < listentry.Length; i++)
                        {
                            ColumnHeader header = new ColumnHeader();
                            header.Text = listentry[i];
                            header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                            listView.Columns.Add(header);
                        }
                    }
                    else
                    {
                        ListViewItem listitem = new ListViewItem();
                        listitem.Text = listentry[0];
                        if (listView.Columns[0].Text.Length < listentry[0].Length) listView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        if ((counter == 1) && isDouble(listentry[0])) listView.Columns[0].TextAlign = HorizontalAlignment.Right; 
                        for (int i = 1; i < listentry.Length; i++)
                        {
                            if (listView.Columns[i].Text.Length < listentry[i].Length) listView.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                            listitem.SubItems.Add(listentry[i]);
                            if ((counter == 1) && isDouble(listentry[i])) listView.Columns[i].TextAlign = HorizontalAlignment.Right;
                        }
                        listView.Items.Add(listitem);
                    }
                    counter++;
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load report list\n" + ex.Message);
            }
        }

        private Boolean isDouble(String value)
        {
            double n;
            return double.TryParse(value, out n);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            performPrint();
        }

        private void performPrint()
        {
            Printer printer = new Printer(this.context, this);
            //printer.Print(this.report.HTML);
            printer.PrintForm(this.report.HTML);
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxTimeframe.Checked)
            {
                this.report.updateEntries(dateTimePickerStart.Value, dateTimePickerEnd.Value);
                loadList();
            }
        }

        private void checkBoxTimeframe_CheckedChanged(object sender, EventArgs e)
        {
            enableTimeframe(checkBoxTimeframe.Checked);
            if (checkBoxTimeframe.Checked)
            {
                this.report.updateEntries(dateTimePickerStart.Value, dateTimePickerEnd.Value);
            }
            else
            {
                this.report.updateEntries();
            }
            loadList();
        }

    }
}
