using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class DestinationModel
    {
        public string Description { get; set; }
        [Required(ErrorMessage ="Şehir alanı zorunludur.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Fiyat alanı zorunludur.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Kapasite alanı zorunludur.")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Gün-gece alanı zorunludur.")]
        public string DayNight { get; set; }
        [Required(ErrorMessage = "Tarih alanı zorunludur.")]
        public DateTime DestinationDate { get; set; }
        public IFormFile Image { get; set; }
    }
}
