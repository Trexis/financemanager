namespace Trexis.Finance.Manager
{
    partial class printForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(printForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonShowHTML = new System.Windows.Forms.Button();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.webBrowserPreview = new System.Windows.Forms.WebBrowser();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.webBrowserPrintWindow = new System.Windows.Forms.WebBrowser();
            this.groupBoxPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(728, 524);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonShowHTML
            // 
            this.buttonShowHTML.Location = new System.Drawing.Point(12, 524);
            this.buttonShowHTML.Name = "buttonShowHTML";
            this.buttonShowHTML.Size = new System.Drawing.Size(75, 23);
            this.buttonShowHTML.TabIndex = 2;
            this.buttonShowHTML.Text = "Show HTML";
            this.buttonShowHTML.UseVisualStyleBackColor = true;
            this.buttonShowHTML.Click += new System.EventHandler(this.buttonShowHTML_Click);
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(12, 13);
            this.textBoxSource.Multiline = true;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSource.Size = new System.Drawing.Size(791, 489);
            this.textBoxSource.TabIndex = 3;
            this.textBoxSource.Visible = false;
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Controls.Add(this.webBrowserPrintWindow);
            this.groupBoxPreview.Controls.Add(this.webBrowserPreview);
            this.groupBoxPreview.Location = new System.Drawing.Point(12, 13);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(794, 505);
            this.groupBoxPreview.TabIndex = 4;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "Print Preview";
            // 
            // webBrowserPreview
            // 
            this.webBrowserPreview.AllowNavigation = false;
            this.webBrowserPreview.AllowWebBrowserDrop = false;
            this.webBrowserPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserPreview.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserPreview.Location = new System.Drawing.Point(3, 16);
            this.webBrowserPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPreview.Name = "webBrowserPreview";
            this.webBrowserPreview.Size = new System.Drawing.Size(788, 486);
            this.webBrowserPreview.TabIndex = 0;
            this.webBrowserPreview.Tag = "Meulenfoods";
            this.webBrowserPreview.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowserPreview.WebBrowserShortcutsEnabled = false;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(634, 524);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 5;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // webBrowserPrintWindow
            // 
            this.webBrowserPrintWindow.AllowNavigation = false;
            this.webBrowserPrintWindow.AllowWebBrowserDrop = false;
            this.webBrowserPrintWindow.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserPrintWindow.Location = new System.Drawing.Point(48, 56);
            this.webBrowserPrintWindow.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPrintWindow.Name = "webBrowserPrintWindow";
            this.webBrowserPrintWindow.Size = new System.Drawing.Size(632, 370);
            this.webBrowserPrintWindow.TabIndex = 6;
            this.webBrowserPrintWindow.Tag = "Meulenfoods";
            this.webBrowserPrintWindow.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowserPrintWindow.Visible = false;
            this.webBrowserPrintWindow.WebBrowserShortcutsEnabled = false;
            // 
            // printForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 555);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.groupBoxPreview);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.buttonShowHTML);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "printForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print [*title*]";
            this.Load += new System.EventHandler(this.printForm_Load);
            this.groupBoxPreview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonShowHTML;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.WebBrowser webBrowserPreview;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.WebBrowser webBrowserPrintWindow;

    }
}