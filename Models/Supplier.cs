using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_karolg.Connection;

namespace P1_karolg.Models
{
    internal class Supplier
    {
        #region Attributes
        private int _supplierID;
        private string _companyName;
        private string _contactName;
        private string _contactTitle;
        private string _address;
        private string _city;
        private string _country;
        private string _phone;

        #endregion

        #region Properties
        /*Setters and getters*/
        public int SupplierID { get { return _supplierID; } set { _supplierID = value; } }
        public string CompanyName { get { return _companyName; } set { _companyName = value; } }
        public string ContactName { get { return _contactName; } set { _contactName = value; } }

        public string contactTitle { get { return _contactTitle; } set { _contactTitle = value; } }

        public string Address { get { return _address; } set { _address = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public string Country { get { return _country; } set { _country = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }

        #endregion

        #region Constructors
        public Supplier()
        {
            _supplierID = 0;
            _companyName = "";
            _contactName = "";
            _contactTitle = "";
            _address = "";
            _city = "";
            _country = "";
            _phone = "";
        }

        public Supplier(int SupplierID, string CompanyName, string ContactName, string contactTitle, string Address, string City, string Country, string Phone)
        {
            _supplierID = SupplierID;
            _companyName = CompanyName;
            _contactName = ContactName;
            _contactTitle = contactTitle;
            _address = Address;
            _city = City;
            _country = Country;
            _phone = Phone;
        }

        public Supplier(int id)
        {
            //query
            string query = @"Select SupplierID, CompanyName, ContactName, ContactTitle, Address, City, Country, Phone from Suppliers Where SupplierID = @ID";

            //COMMAND
            SqlCommand command = new SqlCommand(query);
            //parameters
            command.Parameters.AddWithValue("@ID", id);
            //execute command
            DataTable table = SQLServerConnection.ExecuteQuery(command);

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];


                _supplierID = Convert.ToInt32(row["SupplierID"]);
                _companyName = Convert.ToString(row["CompanyName"]);
                _contactName = Convert.ToString(row["ContactName"]);
                _contactTitle = Convert.ToString(row["ContactTitle"]);
                _address = Convert.ToString(row["Address"]);
                _city = Convert.ToString(row["City"]);
                _country = Convert.ToString(row["Country"]);
                _phone = Convert.ToString(row["Phone"]);
            }
        }

        #endregion

        #region Methods
        public static List<Supplier> GetAll()
        {
            //list
            List<Supplier> list = new List<Supplier>();

            //query
            string query = @"Select SupplierID, CompanyName, ContactName, ContactTitle, Address, City, Country, Phone from Suppliers Order By CompanyName ";
            
            //command

            SqlCommand command = new SqlCommand(query);
            //parameter
            //command.parameters.addwithvalue();

            //datatable
            DataTable table = SQLServerConnection.ExecuteQuery(command);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    list.Add(new Supplier(

                    Convert.ToInt32(row["SupplierID"]),
                    Convert.ToString(row["CompanyName"]),
                    Convert.ToString(row["ContactName"]),
                    Convert.ToString(row["ContactTitle"]),
                    Convert.ToString(row["Address"]),
                    Convert.ToString(row["City"]),
                    Convert.ToString(row["Country"]),
                    Convert.ToString(row["Phone"])));

                }
            }
            return list;
        }
        #endregion
    }
}
