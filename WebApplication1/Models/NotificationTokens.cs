using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NetRestaurantAPI.Models
{    
    public class NotificationTokens
    {
        [Key]
        public Guid UsuarioId { get; set; }        
        public string ExpoToken { get; set; }
        public string DeviceOS { get; set; } 
    }
}
