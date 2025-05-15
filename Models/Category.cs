using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_karolg.Connection;

namespace P1_karolg.Models
{
    internal class Category
    {
        #region Attributes
        private int _categoryId;
        private string _categoryName;
        private string _description;
        #endregion

        #region Properties
            /*Setters and getters*/
        public int CategoryId { get { return _categoryId; } set { _categoryId = value; } }
        public string CategoryName { get { return _categoryName; } set { _categoryName = value; } }
        public string Description { get { return _description; } set { _description = value; } }

        #endregion

        #region Constructors
        public Category() { 
            _categoryId = 0;
            _categoryName = "";
            _description = "";
        }

        public Category(int categoryId, string categoryName, string description)
        {
            _categoryId = categoryId;
            _categoryName =categoryName;
            _description = description;
        }

        public Category(int id)
        {
            //query
            string query = @"Select CategoryID, CategoryName, Description From Categories Where CategoryID = @ID";
            //COMMAND
            SqlCommand command = new SqlCommand(query);
            //parameters
            command.Parameters.AddWithValue("@ID", id);
            //execute command
            DataTable table  = SQLServerConnection.ExecuteQuery(command);

            if(table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];

                _categoryId = Convert.ToInt32(row["CategoryID"]);
                _categoryName = Convert.ToString(row["CategoryName"]);
                _description = Convert.ToString(row["Description"]);
            }
        }

        #endregion

        #region Methods
        public static List<Category> GetAll()
        {
            //list
            List<Category> list = new List<Category>();

            //query
            string query = @"Select CategoryID, CategoryName, Description From Categories Order By CategoryName";
            //comand
           
            SqlCommand command = new SqlCommand(query);
            //parameter
            //command.parameters.addwithvalue();

            //datatable
            DataTable table = SQLServerConnection.ExecuteQuery(command);

            if(table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    list.Add(new Category(
                        Convert.ToInt32(row["CategoryID"]),
                        Convert.ToString(row["CategoryName"]),
                        Convert.ToString(row["Description"])));
             
                }
           }
            return list;
        }
        #endregion

    }
}
