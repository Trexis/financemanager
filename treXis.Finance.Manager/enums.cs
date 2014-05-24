using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trexis.Finance.Manager
{
    public enum Roles
    {
        Admin=1,
        Manager=2,
        User=3,
        Rep=4,
        Visitor=5
    }

    public enum PaymentType
    {
        COD=0,
        SevenDays=1,
        FourteenDays=2,
        ThirtyDays=3
    }

    public enum EntryType
    {
        Invoice = 0,
        Payment = 1
    }

    public enum ReportType
    {
        ProductSales = 0,
        IncomeExpenses = 1
    }

}
