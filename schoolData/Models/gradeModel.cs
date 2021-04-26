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
        public string Semester { get; set; }
        public int finalGradeForHistory { get; set; }
        public string commentsForHistory { get; set; }
        public int finalGradeForGrammar { get; set; }
        public string commentsForGrammar { get; set; }
        public int finalGradeForLiterature { get; set; }
        public string commentsForLiterature { get; set; }
        public int finalGradeForVocabulary { get; set; }
        public string commentsForVocabulary { get; set; }
        public int finalGradeForMath { get; set; }
        public string commentsForMath { get; set; }
        public int finalGradeForScience { get; set; }
        public string commentsForScience { get; set; }

    }
}
