namespace GalluChat.Models.ViewModel
{
    public class ChatVM
    {
        public ApplicationUser UserFound { get; set; }
        public Chat Chat { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}
