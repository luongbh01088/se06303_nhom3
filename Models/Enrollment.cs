using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB_Student.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        // Mối quan hệ với bảng User
        [ForeignKey("UserId")]
        public User User { get; set; }

        // Mối quan hệ với bảng Course
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}

