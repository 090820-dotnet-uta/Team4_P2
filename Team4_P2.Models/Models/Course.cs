using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team4_P2.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Title { get; set; }
    }
}
    