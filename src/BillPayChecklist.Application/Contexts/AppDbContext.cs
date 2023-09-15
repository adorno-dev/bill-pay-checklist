using BillPayChecklist.Application.Entities;
using BillPayChecklist.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BillPayChecklist.Application.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Bill> Bills => Set<Bill>();
        public DbSet<Payment> Payments => Set<Payment>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(ConnectionStrings.GetFromUserSecrets<AppDbContextFactory>("DefaultConnection"));

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region +Bills

            builder.Entity<Bill>()
                   .HasKey(b => b.Id);
            
            builder.Entity<Bill>()
                   .Property(b => b.Title)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.Entity<Bill>()
                   .Property(b => b.DueDay)
                   .IsRequired();

            builder.Entity<Bill>()
                   .Property(b => b.RefMonth)
                   .IsRequired();

            builder.Entity<Bill>()
                   .Property(b => b.Recurrent)
                   .IsRequired();

            builder.Entity<Bill>()
                   .HasMany(b => b.Payments)
                   .WithOne(b => b.Bill);

            #endregion

            #region +Payments

            builder.Entity<Payment>()
                   .HasKey(p => p.Id);
            
            builder.Entity<Payment>()
                   .Property(p => p.PaymentDate)
                   .IsRequired();

            builder.Entity<Payment>()
                   .Property(p => p.RefMonth)
                   .IsRequired();

            builder.Entity<Payment>()
                   .Property(p => p.Amount)
                   .IsRequired();

            builder.Entity<Payment>()
                   .Property(p => p.Comment)
                   .HasMaxLength(256);
            
            builder.Entity<Payment>()
                   .HasOne(p => p.Bill);

            builder.Entity<Payment>()
                   .HasOne(p => p.Bill)
                   .WithMany(p => p.Payments)
                   .HasForeignKey(p => p.BillId);

            #endregion

            base.OnModelCreating(builder);
        }
    }
}