using GalluChat.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GalluChat.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<MutualAgreement> MutualAgreements { get; set; }

        //public DbSet<MessageStatus> MessageStatus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MutualAgreement>()
                .HasOne(ma => ma.ApplicationUserFrom)
                .WithMany()  // or specify collection if defined in ApplicationUser
                .HasForeignKey(ma => ma.User_FromId)
                .OnDelete(DeleteBehavior.NoAction);  // Disable cascade delete

            modelBuilder.Entity<MutualAgreement>()
                .HasOne(ma => ma.ApplicationUserTo)
                .WithMany()  // or specify collection if defined in ApplicationUser
                .HasForeignKey(ma => ma.User_ToId)
                .OnDelete(DeleteBehavior.NoAction);  // Disable cascade delete
        }

    }
}
