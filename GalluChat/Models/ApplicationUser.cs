using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalluChat.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Mapped properties
        [Required]
        public string Name { get; set; }
        public byte[] ProfilePicture { get; set; }    // Storing image as binary data

        [MaxLength(255)]
        public string StatusMessage { get; set; } = "Hey there! I’m using Galluchat.";

        public DateTime LastSeen { get; set; }
        public bool IsOnline { get; set; }

        // Not mapped - Example of a runtime computed property
        [NotMapped]
        public string DisplayName => $"{UserName}";

        // Navigation properties
       // public virtual ICollection<Message> Messages { get; set; }   // One-to-many relationship with Message
    }
}
