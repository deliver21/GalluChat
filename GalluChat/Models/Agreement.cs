using GalluChat.Utilities;
using System.ComponentModel.DataAnnotations;

namespace GalluChat.Models
{
    public class Agreement
    {
        [Key]
        public int AgreementId { get; set; }
        public string AgreementStatus { get; set; } = SD.AgreePending;
    }
}
