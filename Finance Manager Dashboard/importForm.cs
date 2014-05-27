using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Trexis.Finance.Manager
{
    public partial class importForm : Form
    {
        private Context context;
        private Boolean cancelclicked = false;

        private importItem[] importitems = new importItem[0];
        private int importitemscount = 0;
        private int importitemscounter = 0;

        public importForm(Context context)
        {
            this.context = context;

            InitializeComponent();
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            timerImport.Stop();
            cancelclicked = true;
            buttonImport.Visible = true;
            buttonCancel.Visible = false;
            buttonClose.Enabled = true;
            addStatusItem("Import cancelled", "", 2);
        }

        private void importForm_Load(object sender, EventArgs e)
        {
            this.Height = 165;
        }


        private void buttonImport_Click(object sender, EventArgs e)
        {
            MaximizeForm();
            buttonImport.Visible = false;
            buttonCancel.Visible = true;
            buttonClose.Enabled = false;

            String[] files = Directory.GetFiles(textBoxFolderLocation.Text, "*.xlsx");

            importitems = new importItem[files.Length];
            importitemscount = 0;
            importitemscounter = 0;
            foreach (String file in files)
            {
                importItem importitem = new importItem(file);
                importitems[importitemscount] = importitem;
                importitemscount++;
            }

            cancelclicked = false;
            listViewStatus.Items.Clear();
            addStatusItem("Import started...", "", 1);
            
            timerImport.Start();
        }

        private void MaximizeForm()
        {
            int maxheight = 410;
            int currentheight = this.Height;
            int buttonstop = buttonImport.Top;
            int heightincrease = maxheight - currentheight;
            if (this.Height != maxheight)
            {
                this.Height = maxheight;
                buttonImport.Top += heightincrease;
                buttonCancel.Top += heightincrease;
                buttonClose.Top += heightincrease;
                groupBoxStatus.Top = buttonstop;
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);
            textBoxFolderLocation.Text = folderBrowserDialog1.SelectedPath;
        }

        private void timerImport_Tick(object sender, EventArgs e)
        {
            timerImport.Stop();
            if (!cancelclicked)
            {
                importItem importitem = importitems[importitemscounter];
                if (!importitem.Processed)
                {
                    if (importitem.Import())
                    {
                        if (importitem.Imported)
                        {
                            addStatusItem("Imported " + importitem.File, importitem.InvoiceNumber.ToString(), 1);
                        }
                        else
                        {
                            addStatusItem("Failed to import " + importitem.File, importitem.ErrorMessage, 3);

                        }
                    }
                }

                importitemscounter++;

                if (this.importitemscounter < this.importitemscount)
                {
                    timerImport.Start();
                }
                else
                {
                    buttonImport.Visible = true;
                    buttonCancel.Visible = false;
                    buttonClose.Enabled = true;
                    addStatusItem("Import completed", "", 1);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void addStatusItem(String text, String statusText, int status)
        {
            ListViewItem item = new ListViewItem();
            item.Text = text;
            item.SubItems.Add(statusText);
            //1=success, 2=warning, 3=error
            if (status == 2) item.ForeColor = System.Drawing.Color.Orange;
            if (status == 3) item.ForeColor = System.Drawing.Color.Red;
            listViewStatus.Items.Add(item);
        }

    }

    internal class importItem
    {
        private String file = "";
        private Boolean imported = false;
        private Boolean processed = false;
        private int invoicenumber = 0;
        private String errormessage = "";

        internal importItem(String file)
        {
            this.imported = false;
            this.processed = false;
            this.file = file;
        }

        internal Boolean Imported
        {
            get { return this.imported;}
        }
        internal Boolean Processed
        {
            get { return this.processed; }
        }
        internal String File
        {
            get { return this.file; }
        }
        internal int InvoiceNumber
        {
            get { return this.invoicenumber; }
        }
        internal String ErrorMessage
        {
            get { return this.errormessage; }
        }

        internal Boolean Import()
        {
            this.imported = true;
            this.processed = true;

            return this.imported;
        }
    }
    
}
