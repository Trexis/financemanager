using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trexis.Finance.Manager
{
    public class Printer
    {
        WebBrowser webbrowser;
        Context context;
        Form parent;
        public Printer(Context context, Form parent)
        {
            this.context = context;
            this.parent = parent;
            webbrowser = new WebBrowser();
            webbrowser.Parent = this.parent;
            SetBrowserPrintSettings();
        }

        public void PrintPreviewForm(String HTML)
        {
            PrintPreviewForm(HTML, HTML);
        }
        public void PrintPreviewForm(String previewHTML, String printHTML)
        {
            printForm printform = new printForm(this.context, previewHTML, printHTML, false);
            printform.ShowDialog(this.parent);
        }
        public void PrintPreview(String HTML)
        {
            webbrowser.DocumentText = HTML;
            webbrowser.DocumentCompleted += webbrowser_DocumentCompletedPreview;
        }

        public void PrintForm(String HTML)
        {
            PrintForm(HTML, HTML);
        }
        public void PrintForm(String previewHTML, String printHTML)
        {
            printForm printform = new printForm(this.context, previewHTML, printHTML, true);
            printform.ShowDialog(this.parent);
        }
        public void Print(String HTML)
        {
            webbrowser.DocumentText = HTML;
            webbrowser.DocumentCompleted += webbrowser_DocumentCompletedPrint;
        }

        void webbrowser_DocumentCompletedPreview(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            webbrowser.ShowPrintPreviewDialog();
        }
        void webbrowser_DocumentCompletedPrint(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            webbrowser.Print();
        }

        private void SetBrowserPrintSettings()
        {
            string path = "Software\\\\Microsoft\\\\Internet Explorer\\\\PageSetup";
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(path, true);
            if (key == null)
            {
                key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(path, true);
            }
            //String prevheader = key.GetValue("header").ToString();
            //String prevfooter = key.GetValue("header").ToString();
            key.SetValue("header", "");
            key.SetValue("footer", "");
            key.SetValue("margin_left", "0.5");
            key.SetValue("margin_right", "0.5");
            key.SetValue("Shrink_To_Fit", "false");
            key.Close();
        }
    }
}
