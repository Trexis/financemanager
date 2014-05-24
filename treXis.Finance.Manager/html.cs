using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Trexis.Finance.Manager
{
    public class HTML
    {
        private string templatehtml = "";
        private string mergedhtml = "";
        private string title = "";
        private string templatelocation = "";

        public HTML(String templateName, String title)
        {
            this.title = title;
            loadTemplate(templateName);
            performMerging(null);
        }

        public HTML(String templateName, String title, Hashtable mergeFields)
        {
            this.title = title;
            loadTemplate(templateName);
            performMerging(mergeFields);
        }

        private void loadTemplate(String templateName)
        {
            try
            {
                Config config = new Config();
                this.templatelocation = config.GetSetting("templatesfolder");
                if (!this.templatelocation.EndsWith(@"\")) this.templatelocation += @"\";
                using (StreamReader sr = new StreamReader(this.templatelocation + templateName + ".html"))
                {
                    this.templatehtml = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unable to load print template", e);
            }
        }

        private void performMerging(Hashtable mergeFields)
        {
            this.mergedhtml = this.templatehtml;
            this.mergedhtml = this.mergedhtml.Replace("[*title*]", this.title);
            this.mergedhtml = this.mergedhtml.Replace("[*templatelocation*]", this.templatelocation);

            if (mergeFields != null)
            {
                foreach (String key in mergeFields.Keys)
                {
                    this.mergedhtml = this.mergedhtml.Replace("[*" + key + "*]", mergeFields[key].ToString());
                }
            }
        }

        public void AddHTML(String placeholder, String HTML)
        {
            this.mergedhtml = this.mergedhtml.Replace("[*" + placeholder + "*]", HTML);
        }

        public String CreateHTMLTableRows(HashSet<String[]> tablerows, Boolean firstRowIsHeader)
        {
            String htmltablerows = "";

            int counter = 0;
            int colcounter = 0;
            foreach (String[] rows in tablerows)
            {
                if (firstRowIsHeader && counter == 0)
                {
                    htmltablerows += "<tr class=\"tableheader\">";
                }
                else
                {
                    String cssclass = "tablerow";
                    if (counter == 0) cssclass += " first";
                    htmltablerows += "<tr class=\"" + cssclass + "\">";
                }
                colcounter = 0;
                foreach (String value in rows)
                {
                    htmltablerows += "<td class=\"col_" + colcounter + "\">" + value + "</td>";
                    colcounter++;
                }
                if (firstRowIsHeader && counter == 0)
                {
                    htmltablerows += "</tr>";
                }
                else
                {
                    htmltablerows += "</tr>";
                }
                counter++;
            }

            htmltablerows += "<tr><td colspan=\"" + colcounter + "\"/></tr>";

            return htmltablerows;
        }

        public String ToString()
        {
            return this.mergedhtml;
        }
    }
}
