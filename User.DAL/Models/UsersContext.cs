using Microsoft.EntityFrameworkCore;
using Users.DAL.Models;

namespace Users.DAL.DBContext;

public partial class UsersContext : DbContext
{
    public UsersContext()
    {
    }

    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0702508EFD");

            entity.ToTable("User");

            entity.Property(e => e.EmailId)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactEmailId)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactMobileNumber)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
