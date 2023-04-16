using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiSample.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Password), IsUnique = true)]
    public class User : Base
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(550)]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
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

        public bool Active { get; set; } = true;


    }
}
