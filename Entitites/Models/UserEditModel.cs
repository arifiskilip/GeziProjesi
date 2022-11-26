using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class UserEditModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage ="Eski şifrenizi giriniz.")]
        public string LastPassword { get; set; }
        [Required(ErrorMessage = "Yeni şifrenizi giriniz.")]
        public string NewPassword { get; set; }
        public string Email { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
