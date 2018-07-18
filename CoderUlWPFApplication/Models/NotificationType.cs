using System.Collections.Generic;
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
        public string ImageName { get; set; }

        public string ImagePath
        {
            get
            {
                return ImageName != null ? "/Assets/Icons/Alert_type/" + ImageName : "";
            }
        }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}