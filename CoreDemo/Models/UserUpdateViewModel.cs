using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserUpdateViewModel
    {
        [Required(ErrorMessage ="This field is not empty")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "This field is not empty")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is not empty")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "This field is not empty")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "This field is not empty")]
        public string Password { get; set; }

    }
}
