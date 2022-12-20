using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class UserEditModel
    {
        [Required(ErrorMessage ="Lütfen isim alanını giriniz.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lütfen soyisim alanını giriniz.")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Eski şifrenizi giriniz.")]
        public string LastPassword { get; set; }
        [Required(ErrorMessage = "Yeni şifrenizi giriniz.")]
        public string NewPassword { get; set; }
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Gender { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
