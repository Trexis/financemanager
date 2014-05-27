using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trexis.Finance.Manager
{
    static class Security
    {
        public static Boolean allowUsersList(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }
        public static Boolean allowUserManagement(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }

        public static Boolean allowCustomersList(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }
        public static Boolean allowCustomerManagement(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }

        public static Boolean allowStatementsList(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager) || user.Role.Equals(Roles.Rep));
        }

        public static Boolean allowReportsProducts(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }
        public static Boolean allowReportsIncomeExpenses(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }

        public static Boolean allowInvoicesList(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager) || user.Role.Equals(Roles.Rep));
        }
        public static Boolean allowInvoiceManagement(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }
        public static Boolean allowInvoiceCreate(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager) || user.Role.Equals(Roles.Rep) || user.Role.Equals(Roles.User));
        }

        public static Boolean allowProductsList(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }
        public static Boolean allowProductManagement(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }

        public static Boolean allowPayments(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }
        public static Boolean allowCredits(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }
        public static Boolean allowFinalize(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }

        public static Boolean allowImport(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }

        public static Boolean allowEmail(User user)
        {
            return (user.Role.Equals(Roles.Admin) || user.Role.Equals(Roles.Manager));
        }

    }
}
