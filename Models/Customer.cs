using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Models
{
    public class Customer
    {
        private string _name;
        private string _email;

        public int Id { get; set; }
        
        [Required]
        [RegularExpression ("^[a-zA-Z0-9]+$", ErrorMessage = "Username can only have alphanumeric characters")]
        public string Username
        {
            get
            {
                return _name;
            }

            set
            {
                Regex pattern = new Regex("^[a-zA-Z0-9]+$");

                if (value.Length == 0)
                {
                    throw new InputInvalidException("Username cannot be empty");
                }
                else if (!pattern.IsMatch(value))
                {
                    throw new InputInvalidException("Username can only have alphanumeric characters");
                }
                else
                {
                    _name = value;
                }
            }
        }

        [Required]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9]+@[a-zA-Z]+\.[a-z]{3,}", ErrorMessage = "Invalid email")]
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                Regex pattern = new Regex(@"[a-zA-Z0-9]+@[a-zA-Z]+\.[a-z]{3,}");

                if (value.Length == 0)
                {
                    throw new InputInvalidException("Email cannot be empty");
                }
                else if (!pattern.IsMatch(value))
                {
                    throw new InputInvalidException("Invalid email");
                }
                else
                {
                    _email = value;
                }
            }
        }

        public List<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"Username: {this.Username} Email: {this.Email}";
        }
    }
}