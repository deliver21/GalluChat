using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalluChat.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        //[Required]
        //public int ChatId { get; set; }

        //[ForeignKey("ChatId")]
        //public Chat Chat { get; set; }

        //[Required]
        //public string SenderId { get; set; }

        //[ForeignKey("SenderId")]
        //public ApplicationUser Sender { get; set; }
        public bool IsAvailableForAuthor { get; set; }
        public bool IsAvailableForReceiver { get; set; }

        [Required]
        public string Text { get; set; }

        public string FileUrl { get; set; } // Optional

        [Required]
        public DateTime SentAt { get; set; }
    }


}
