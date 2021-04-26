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
   public class ClassDataAccess
    {
        public static void CreateNew(classModel klass)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Query<classModel>("insert into Class(TeacherId, topic, grade) values(@TeacherId, @topic, @grade)", klass);

            }
        }

        public static List<classModel> SelectClass(int grade)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = cnn.Query<classModel>("select* from Class where grade=" + grade +"");
                return output.ToList();
            }

        }

        //select grade
        public static List<gradeModel> SelectGrade(int grade)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = cnn.Query<gradeModel>("select* from Grades where grade=" + grade + "");
                return output.ToList();
            }

        }

        public static void CreateNewGrade(gradeModel grade)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Query<gradeModel>("insert into Grades (StudentId, grade, Semester,finalGradeForHistory," +
                    " commentsForHistory,finalGradeForGrammar, commentsForGrammar," +
                    "finalGradeForLiterature, commentsForLiterature,finalGradeForVocabulary," +
                    " commentsForVocabulary,finalGradeForMath, commentsForMath, finalGradeForScience, " +
                    "commentsForScience) values(@StudentId, @grade, @Semester,@finalGradeForHistory," +
                    "@commentsForHistory,@finalGradeForGrammar, @commentsForGrammar," +
                    "@finalGradeForLiterature, @commentsForLiterature,@finalGradeForVocabulary, " +
                    "@commentsForVocabulary,@finalGradeForMath, @commentsForMath, @finalGradeForScience, " +
                    "@commentsForScience)", grade);
                
            }
        }

        public static List<studentModel> listUngradedStudents( int grade)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output=cnn.Query<studentModel>("SELECT StudentId, grade FROM Grades Where grade =" + grade + " " +
                    "Union " +
                    "SELECT StudentId,  grade FROM students Where grade = " + grade + " " +
                    "Except " +
                    "SELECT StudentId, grade FROM Grades Where grade =" + grade + " " +
                    "Intersect " +
                    "SELECT StudentId, grade FROM students Where grade =" + grade + " ");
                    return output.ToList();
            }
        }

    }
}
