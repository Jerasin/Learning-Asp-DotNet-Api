using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.User
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(550)]
        [Required]
        public string Email { get; set; } = string.Empty;

        [StringLength(550)]
        [Required]
        public string Password { get; set; } = string.Empty;

        [StringLength(550)]
        [Required]
        public string Address { get; set; } = string.Empty;

        [StringLength(550)]
        [Required]
        public string Role { get; set; } = string.Empty;

        [StringLength(550)]
        [Required]
        public string Active { get; set; } = string.Empty;
    }
}
