using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team4_P2.P2_Models
{
    public class Assignment
    {
        [ForeignKey("Enrollment")]
        public int EnrollmentID { get; set; }
        public int? Grade { get; set; }
        public string Title { get; set; }
    }
}
