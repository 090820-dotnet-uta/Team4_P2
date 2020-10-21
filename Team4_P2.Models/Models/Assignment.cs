using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team4_P2.Models
{
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AssignmentID { get; set; }
        [ForeignKey("Enrollment")]
        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }
        public int? Grade { get; set; }
        public string Title { get; set; }
    }
}
