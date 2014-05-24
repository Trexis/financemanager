using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trexis.Finance.Manager
{
    static class Tools
    {

        public static void ShowError(String errorMessage)
        {
            MessageBox.Show(errorMessage, Properties.Settings.Default.companyname, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfo(String infoMessage)
        {
            MessageBox.Show(infoMessage, Properties.Settings.Default.companyname, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
