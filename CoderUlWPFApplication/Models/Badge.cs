using System.ComponentModel.DataAnnotations;

namespace CoderUlWPFApplication.Models
{
    public class Badge
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(655)]
        public string ImagePath { get; set; }
    }
}