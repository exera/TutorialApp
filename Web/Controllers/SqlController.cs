using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class SqlController : Controller
    {
        // GET: Sql
        public string Index()
        {

            var connStr = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            var conn = new SqlConnection(connStr);
            conn.Open();

            var command = new SqlCommand("select * from Employee",conn);
            var dataReader = command.ExecuteReader();
            var result = "";
            while (dataReader.Read())
            {
                var id = (int)dataReader["Id"];
                var name = (string)dataReader["Name"];
                var age = (int)dataReader["Age"];

                result += id + ", " + name + ", " + age + "<br>";
            }

            return result;
        }
    }
}