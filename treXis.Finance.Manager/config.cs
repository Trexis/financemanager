using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trexis.Finance.Manager
{
    class Config
    {
        Dictionary<String, String> settings = new Dictionary<string, string>();
        public Config()
        {
            String settingsfilelocation = Utilities.Directory + "settings.ini";
            foreach (var row in File.ReadAllLines(settingsfilelocation))
                settings.Add(row.Split('=')[0], row.Split('=')[1]);
        }

        public String GetSetting(String settingName)
        {
            return settings[settingName];
        }

    }
}
