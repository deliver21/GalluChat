using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GalluChat.Models
{
    public class MessageStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MessageId { get; set; }

        [ForeignKey("MessageId")]
        public Message Message { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser User { get; set; }

        [Required]
        public bool IsRead { get; set; }

        public DateTime? ReadAt { get; set; }
    }


}
