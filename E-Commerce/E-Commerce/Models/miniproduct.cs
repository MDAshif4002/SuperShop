using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class miniproduct
    {
        [Key]
        public int id { get; set; }
        public string? mpropic { get; set; }
        public string? title { get; set; }
    }
}
