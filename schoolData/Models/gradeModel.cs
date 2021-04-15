using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolData.Models
{
     public class gradeModel
    {
        public int GradeId { get; set; }
        public int StudentId { get; set; }
        public int grade { get; set; }
        public int ClassId { get; set; }
        public string Semester { get; set; }

    }
}
