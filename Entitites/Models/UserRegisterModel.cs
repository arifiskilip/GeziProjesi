using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage ="Adınızı giriniz.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyadınızı giriniz.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email alanını giriniz.")]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanını giriniz.")]
        [MinLength(3,ErrorMessage = "Şifre alanınız 6 karakter olmalıdır.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Tekrar şifre alanını giriniz.")]
        [Compare("Password", ErrorMessage = "Şifreniz uyumlu değil.")]
        public string ConfirmPassword { get; set; }
    }
}
