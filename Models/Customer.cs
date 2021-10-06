using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [RegularExpression ("^[a-zA-Z0-9]+$", ErrorMessage = "Username can only have alphanumeric characters!")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9]+@[a-zA-Z]+\.[a-z]{2,}", ErrorMessage = "Invalid email!")]
        public string Email { get; set; }

        public List<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"Username: {this.Username} Email: {this.Email}";
        }
    }
}