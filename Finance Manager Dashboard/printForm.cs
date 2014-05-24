using Microsoft.Win32;
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
    public partial class printForm : Form
    {
        public printForm(Context context, String PreviewHTML, String PrintHTML, bool printOnLoad)
        {
            InitializeComponent();
            webBrowserPreview.DocumentText = PreviewHTML;
            webBrowserPrintWindow.Url = new Uri("http://www.meulenfoods.co.za");
            webBrowserPrintWindow.DocumentText = PrintHTML;
            textBoxSource.Text = PrintHTML;
            buttonShowHTML.Visible = context.User.Role.Equals(Roles.Admin);
            if (printOnLoad)
            {
                webBrowserPrintWindow.DocumentCompleted += webBrowserPrintWindow_DocumentCompleted_printonload;
            }
        }

        void webBrowserPrintWindow_DocumentCompleted_printonload(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            performPrint();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonShowHTML_Click(object sender, EventArgs e)
        {
            groupBoxPreview.Visible = false;
            textBoxSource.Visible = true;
        }

        private void printForm_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[*title*]", webBrowserPreview.DocumentTitle);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            performPrint();
        }

        private void performPrint()
        {
            webBrowserPrintWindow.Print();
        }
    }
}
