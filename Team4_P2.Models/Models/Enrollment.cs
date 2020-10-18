using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team4_P2.Models
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentID { get; set; }
        [ForeignKey("ClassID")]
        public int ClassID { get; set; }
        [ForeignKey("StudentID")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
