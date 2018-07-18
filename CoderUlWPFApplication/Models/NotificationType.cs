using System.ComponentModel.DataAnnotations;

namespace CoderUlWPFApplication.Models
{
    public class NotificationType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(655)]
        public string ImagePath { get; set; }
    }
}