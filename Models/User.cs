using System;
using System.Text.RegularExpressions;

namespace Models {

    public class User {
        private string _name;

        public string UserName {
            get {
                return _name;
            }

            set {
                Regex pattern = new Regex("^[a-zA-Z0-9]+$");

                if (value.Length == 0) {
                    throw new InputInvalidException("Username cannot be empty!");
                }
                else if (!pattern.IsMatch(value)) {
                    throw new InputInvalidException("Username can only have alphanumeric characters!");
                }
                else {
                    _name = value;
                }
            }
        }
        public string Password { get; set; }
    }  
}