using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class register
    {
        [Key]
        public int id { get; set; }
        public string? fname { get; set; }
        public string? lname { get; set; }
        public string? email { get; set; }
        public string? mobile { get; set; }
        public string? address { get; set; }
        public string? pincode { get; set; }
        public string? state { get; set; }
        public string? district { get; set; }
        public string? country { get; set; }
        public string? gender { get; set; }
        public string? dob { get; set; }
        public string? password { get; set; }
        public string? otp { get; set; }
    }
}
