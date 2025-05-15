using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_karolg.Connection
{
    internal class SQLServerConnection
    {
        #region Attributes
        //sql connection

        private static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public static SqlConnection connection = new SqlConnection(connectionString);

        #endregion

        #region
        public static bool Open()
        {
            //connected
            bool connected = true; //connected by default
            //checl if the connection is already opened
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connected = false;
                }
            }
            else
            {
                connected = false;
            }
            return connected;
        }

        public static DataTable ExecuteQuery(SqlCommand command)
        {
            //result table
            DataTable dt = new DataTable();

            if (Open())
            {
                command.Connection = connection; //Asign connection to command
                SqlDataAdapter adapter = new SqlDataAdapter(command); //Adapter
                try
                {
                    adapter.Fill(dt);//Ececute query and fill result table
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //close connection
                connection.Close();
            }
            //return table
            return dt;
        }

        public static bool ExecuteNoQuery(SqlCommand command)
        {
            bool executed = false;
            if (Open())
            {
                command.Connection = connection;
                try
                {

                    int affectedRows = command.ExecuteNonQuery();
                    if (affectedRows > 0) executed = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    executed = false;
                }
            }
            return executed;
        }
        #endregion


    }
}