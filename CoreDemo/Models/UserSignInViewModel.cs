using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="This field must not empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This field must not empty")]
        public string Password { get; set; }
    }
}
