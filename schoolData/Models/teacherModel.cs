using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolData.Models
{
    public class teacherModel
    {
        public int TeacherId { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string expertise { get; set; }
        public int age { get; set; }
        public DateTime? dateOfHire { get; set; }
    }
}
