using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiSample.Models
{
    [Index(nameof(Active))]
    public class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(550)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }

        public string? img { get; set; }

        public bool Active { get; set; } = true;

        public string CreatedAt { get; set; } = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ");

        public virtual WareHouse WareHouse { get; set; } = null!;
    }
}
