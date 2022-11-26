using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Kulanıcı adı alanı boş geçilemez.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")]
        public string Password { get; set; }
    }
}
