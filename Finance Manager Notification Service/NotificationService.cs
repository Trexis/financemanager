using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Trexis.Finance.Manager
{
    public partial class NotificationService : ServiceBase
    {
        public NotificationService()
        {
            InitializeComponent();
            /*if (!System.Diagnostics.EventLog.SourceExists("Finance Manager Notification Service"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "Finance Manager Notification Service", "Finance Manager Notification Service");
            }*/
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
