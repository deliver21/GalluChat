using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalluChat.Models
{
    [PrimaryKey(nameof(UserId), nameof(MessageId))]
    public class Chat
    {
       // [PrimaryKey(nameof(UserId))]
        //public int ChatId { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        ApplicationUser ApplicationUser { get; set; }
        [Required]
        public int MessageId { get; set; }
        [ForeignKey(nameof(MessageId))]
        public Message Message { get; set; }
        [Required]
        public bool IsAuthor { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        // One-to-many relationship with Messages
        //public ICollection<Message> Messages { get; set; }
        //[NotMapped]
        //ApplicationUser User1 { get; set; }
        //[NotMapped]
        //ApplicationUser User2 { get; set; } 
    }


}
