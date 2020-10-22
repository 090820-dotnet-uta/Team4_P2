using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team4_P2.Models.Models;

namespace Team4_P2.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
    