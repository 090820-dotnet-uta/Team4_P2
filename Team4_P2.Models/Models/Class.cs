using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team4_P2.Models
{
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public string Location { get; set; }
        public List<Enrollment> Enrollments { get; set; }

    }
}
    