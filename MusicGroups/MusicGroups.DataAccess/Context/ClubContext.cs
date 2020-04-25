using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MusicGroups.DataAccess.Entities;

namespace MusicGroups.DataAccess.Context
{
    public partial class ClubContext : DbContext
    {
        public ClubContext()
        {
        }

        public ClubContext(DbContextOptions<ClubContext> options) : base(options)
        {
        }

        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Group> Group { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>(entity =>
                {
                    entity.Property(c => c.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(c => c.Name).IsRequired();
                    entity.Property(c => c.Address).IsRequired();
                });

            modelBuilder.Entity<Group>(entity =>
                {
                    entity.Property(m => m.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(m => m.Gname).IsRequired();
                    entity.Property(m => m.Genre).IsRequired();
                    entity.Property(m => m.DateC).IsRequired();
                    entity.Property(m => m.Price).IsRequired();
                });

            modelBuilder.Entity<Reservation>(entity =>
                {
                    entity.Property(s=>s.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(s => s.Date).IsRequired();
                    entity.Property(s => s.Location).IsRequired();
                    entity.HasOne(s => s.Club)
                        .WithMany(c => c.Reservation)
                        .HasForeignKey(s => s.ClubId)
                        .HasConstraintName("FK_Reservation_Club");
                    entity.HasOne(s => s.Group)
                        .WithMany(m => m.Reservations).HasForeignKey(s=>s.GroupId)
                        .HasConstraintName("FK_Reservation_Group");
                });
            
            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}