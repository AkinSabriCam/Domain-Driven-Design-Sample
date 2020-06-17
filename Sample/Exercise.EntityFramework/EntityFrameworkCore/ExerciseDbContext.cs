using Exercise.Domain.Buses;
using Exercise.Domain.Companies;
using Exercise.Domain.Shared.Buses;
using Exercise.Domain.Shared.Companies;
using Exercise.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.EntityFrameworkCore
{
    public class ExerciseDbContext : IdentityDbContext<User, Role, Guid>, IDbContext
    {
        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options)
            : base(options)
        {

        }
        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<Bus> Buses { get; set; }

        public DbSet<BusDetail> BusDetails { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Role>(b =>
            {
                b.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Bus>(b =>
            {
                b.HasKey(x => x.Id);

                b.Property(x => x.Mark).IsRequired().HasMaxLength(BusConsts.MarkMaxLength);
                b.Property(x => x.Route).IsRequired().HasMaxLength(BusConsts.RouteMaxLength);
                b.Property(x => x.ExpeditionNumber).IsRequired().HasMaxLength(BusConsts.ExpeditionNumberMaxLength);
                b.Property(x => x.SeatCount).IsRequired();

                b.HasOne(x => x.Company)
                .WithMany(x => x.Busses).HasForeignKey(x => x.CompanyId)
                .IsRequired();

            });

            modelBuilder.Entity<BusDetail>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasKey(x => x.BusId);


                b.Property(x => x.Color).IsRequired().HasMaxLength(BusDetailConsts.ColorMaxLength);
                b.Property(x => x.Plate).IsRequired().HasMaxLength(BusDetailConsts.PlateMaxLength);
                b.Property(x => x.ProductionDate).IsRequired();

                b.HasOne(x => x.Bus)
               .WithOne(x => x.BusDetail).HasForeignKey<BusDetail>(bd => bd.BusId);
            });

            modelBuilder.Entity<Company>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.HeadQuarters).IsRequired().HasMaxLength(CompanyConsts.HeadQuartersMaxLength);
                b.Property(x => x.CompanyName).IsRequired().HasMaxLength(CompanyConsts.CompanyNameMaxLength);
            });

            base.OnModelCreating(modelBuilder);
        }


        public async Task<bool> EnsureChangesAsync()
        {
            if (await SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }

        public DbSet<TEntity> SetDbTable<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

    }
}
