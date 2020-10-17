using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team4_P2.Models
{
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ClassID { get; set; }
        [ForeignKey("CourseID")]
        public int CourseID { get; set; }
        [ForeignKey("TeacherID")]
        public int TeacherID { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
    