using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class slider
    {
        [Key]
        public int id { get; set; }
        public string? image { get; set; }
    }
}
