using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trexis.Finance.Manager
{
    public class User
    {
        private int id;
        private String username = "";
        private String password = "";
        private String name = "";
        private String surname = "";
        private String emailaddress = "";
        private String phonenumber = "";
        private Roles role = Roles.Visitor;

        private Dal dal;

        public User()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load user", ex);
            }
        }


        public User(Hashtable userresult)
        {
            try
            {
                populateUserFromResultTable(userresult);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load user", ex);
            }
        }


        public User(String username)
        {
            try
            {
                dal = new Dal();
                HashSet<Hashtable> results = dal.executeAsHashset("call getUserByUsername(\"" + username + "\");");
                populateUserFromResults(results);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load user by username " + username + ex.Message, ex);
            }
        }

        public User(int id)
        {
            try
            {
                dal = new Dal();
                HashSet<Hashtable> results = dal.executeAsHashset("call getUserById(" + id + ");");
                populateUserFromResults(results);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load user by id " + id, ex);
            }
        }

        public void Save()
        {
            try
            {
                if (this.username.Equals("")) throw new Exception("Username mandatory");

                dal = new Dal();
                HashSet<Hashtable> results = dal.executeAsHashset("call updateUser('" + this.username + "', '" + this.password + "', '" + this.name + "', '" + this.surname + "', '" + this.emailaddress + "', '" + this.phonenumber + "', " + Convert.ToInt16(this.role) + ");");
                populateUserFromResults(results);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to save user", ex);
            }
        }

        public void Delete()
        {
            try
            {
                dal = new Dal();
                dal.executeNonQuery("call deleteUser(" + this.Id + ");");
                this.id = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to delete User", ex);
            }
        }

        public Boolean ValidatePassword(String passwordAttempt){
            return this.password.Equals(passwordAttempt);
        }

        private void populateUserFromResults(HashSet<Hashtable> results)
        {
            if (results.Count > 0)
            {
                foreach (Hashtable table in results)
                {
                    populateUserFromResultTable(table);
                }
            }
            else
            {
                throw new Exception("No results found");
            }
        }

        private void populateUserFromResultTable(Hashtable table)
        {
            this.id = Convert.ToInt16(table["id"]);
            this.username = table["username"].ToString();
            this.password = table["password"].ToString();
            this.name = table["name"].ToString();
            this.surname = table["surname"].ToString();
            this.emailaddress = table["email"].ToString();
            this.phonenumber = table["phone"].ToString();
            this.role = (Roles)Convert.ToInt16(table["role"]);
        }

        /*PROPERTIES*/
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }  //need the set, because we load it in combobox as list item
        }
        public String Username{
            get { return this.username; }
            set { this.username = value; }
        }
        public String FriendlyName
        {
            get { return this.name + " " +  this.Surname; }
        }
        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public String Surname
        {
            get { return this.surname; }
            set { this.surname = value; }
        }
        public String EmailAddress
        {
            get { return this.emailaddress; }
            set { this.emailaddress = value; }
        }
        public String PhoneNumber
        {
            get { return this.phonenumber; }
            set { this.phonenumber = value; }
        }
        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public Roles Role
        {
            get { return this.role; }
            set { this.role = value; }
        }
    }
}
