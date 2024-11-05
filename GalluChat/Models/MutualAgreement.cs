using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalluChat.Models
{
    public class MutualAgreement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AgreementId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(AgreementId))]        
        public Agreement Agreement { get; set; }
        public string User_FromId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(User_FromId))]
        public ApplicationUser ApplicationUserFrom { get; set; }
        public string User_ToId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(User_ToId))]
        public ApplicationUser ApplicationUserTo { get; set; }
        public DateTime AgreedAt { get; set; }
    }
}
