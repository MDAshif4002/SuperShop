using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class womenproduct
    {
        [Key]
        public int id { get; set; }
        public string? productname { get; set; }
        public string? productimg { get; set; }
        public string? description { get; set; }
        public string? price { get; set; }
        public string? discount { get; set; }
    }
}
