using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class SqlController : Controller
    {
        // GET: Sql
        public string Index(string pName, int pAge)
        {

            var connStr = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                var insertComm = conn.CreateCommand();
                insertComm.CommandText = "insert into Employee (Name,Age) values (@pName,@pAge);";
                insertComm.Parameters.Add(new SqlParameter("@pName", pName));
                insertComm.Parameters.Add(new SqlParameter("@pAge", pAge));
                insertComm.ExecuteNonQuery();

                var command = new SqlCommand("select * from Employee", conn);
                var dataReader = command.ExecuteReader();
                var result = "";
                while (dataReader.Read())
                {
                    var id = (int)dataReader["Id"];
                    var name = (string)dataReader["Name"];
                    var age = (int)dataReader["Age"];

                    result += id + ", " + name + ", " + age + "<br>";
                }
                dataReader.Close();

                var scalarComm = conn.CreateCommand();
                scalarComm.CommandText = "select count(0) from Employee where Id = 1";
                var scalarResult = scalarComm.ExecuteScalar();

                result += "<br>" + (int)scalarResult;
                conn.Dispose();

                return result;
            }
        }
    }
}