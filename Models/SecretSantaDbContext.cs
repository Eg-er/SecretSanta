using Microsoft.EntityFrameworkCore;

namespace SecretSanta.Models
{
    public class SecretSantaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public SecretSantaDbContext(DbContextOptions<SecretSantaDbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasOne(a => a.Receiver).WithOne()
                .HasForeignKey<User>(a => a.ReceiverId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}