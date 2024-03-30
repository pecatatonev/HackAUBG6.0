using HackAUBG6.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HackAUBG6.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Bill>()
                .HasOne<ApplicationUser>(a => a.ApplicationUser)
                .WithMany(a => a.Bills)
                .HasForeignKey(u => u.ApplicationUserId);

            base.OnModelCreating(builder);
        }
    }
}