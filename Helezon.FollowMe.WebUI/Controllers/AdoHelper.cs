using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Controllers
{
    public class AdoHelper
    {
        private static string _staticConnectionString;

        public static string StaticConnectionString
        {
            set { _staticConnectionString = value; }
            get
            {
                if (!string.IsNullOrEmpty(_staticConnectionString))
                    return _staticConnectionString;

                _staticConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GLCEmasEntities"].ConnectionString;

                return _staticConnectionString;               
            }
        }
        public static DataTable FillDataTable(string selectCommandText)
        {
            using (SqlConnection c = new SqlConnection(StaticConnectionString))
            {
                c.Open();
                using (SqlDataAdapter a = new SqlDataAdapter(selectCommandText, c))
                {
                    DataTable table = new DataTable();
                    a.Fill(table);
                    return table;
                }
            }
        }
    }
}