using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class product
    {
        [Key]
        public int id { get; set; }
        public string? productname { get; set; }
        public string? productimage { get; set; }
        public string? description { get; set; }
        public string? price { get; set; }
        public string? discountprice { get; set; }
    }
}
