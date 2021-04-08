using Dapper;
using schoolData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolData
{
    public class gradeAccess
    {

        public static void CreateNew(classModel grade)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Query<classModel>("insert into ninthGrade(StudentId, ClassId, dateOfEntry, finalGrade, comments) values(@StudentId, @ClassId, @dateOfEntry, @finalGrade, @comments", grade);

            }
        }
    }
}
