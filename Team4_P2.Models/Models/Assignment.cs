using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team4_P2.Models
{
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AssignmentId { get; set; }
        [ForeignKey("Enrollment")]
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
        public int? Grade { get; set; }
        public string Title { get; set; }
    }
}
