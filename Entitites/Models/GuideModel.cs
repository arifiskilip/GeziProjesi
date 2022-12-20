using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class GuideModel
    {
        [Required(ErrorMessage ="İsim alanı boş geçilemez.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email alanı boş geçilemez.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Yaş alanı boş geçilemez.")]
        public string Age { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        [Required(ErrorMessage = "Açıklama alanı boş geçilemez.")]
        public string Description { get; set; }
    }
}
