using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Name Surname")]
        [Required(ErrorMessage ="Write Name Surname")]
        public string NameSurname { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Write Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage ="Password and confirm password are not same")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Address")]
        [Required(ErrorMessage ="Write Mail")]
        public string Mail { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Write Username")]
        public string Username { get; set; }
    }
}
