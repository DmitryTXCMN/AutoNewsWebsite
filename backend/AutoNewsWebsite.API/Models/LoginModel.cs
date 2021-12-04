using System.ComponentModel.DataAnnotations;

namespace AutoNewsWebsite.API.Models
{
    public class LoginModel
    {
        [RegularExpression("^[a-zA-Z0-9]+$" , ErrorMessage = "You can not have that")]
        public string Login { get; set; }
        [RegularExpression("(?!^[0-9]*$)(?!^[a-z]*$)(?!^[A-Z]*$)^(.{8,15})$" , ErrorMessage = "You can not have that")]
        public string Password { get; set; }
    }
}