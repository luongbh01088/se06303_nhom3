using System.ComponentModel.DataAnnotations;

namespace WEB_Student.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; } // ('Admin'), ('Faculty'), ('Student');

        // Mối quan hệ với bảng User
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
