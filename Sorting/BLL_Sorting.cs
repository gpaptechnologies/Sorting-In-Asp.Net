using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Sorting
{
    public class BLL_Sorting
    {
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataAdapter sqlda = null;
        DataTable dtEmployeeData = null;

        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnectionstring"].ToString());

        public DataTable GetEmployeeData()
        {
            using (connection = connString)
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_GetEmployees";
                sqlda = new SqlDataAdapter(command);
                dtEmployeeData = new DataTable();
                sqlda.Fill(dtEmployeeData);
            }
            return dtEmployeeData;
        }

    }
}