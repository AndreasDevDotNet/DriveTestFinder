using DriveTestFinderRepository.Entities;
using Microsoft.EntityFrameworkCore;

namespace DriveTestFinderRepository
{
    public class DriveTestFinderMasterContext : DbContext
    {
        private string _connectionString;

        public DriveTestFinderMasterContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DriveTestFinderMasterContext(DbContextOptions<DriveTestFinderMasterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<TestOccasion> TestOccasions { get; set; }
        public virtual DbSet<TestType> TestTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSearch> UserSearches { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<LicenseTestType> LicenseTestTypes { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<LoginRole> LoginRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");

                entity.Property(e => e.LanguageId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<License>(entity =>
            {
                entity.ToTable("License");

                entity.Property(e => e.LicenseId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<LicenseTestType>(entity =>
            {
                entity.HasKey(e => new { e.LicenseId, e.TestTypeId });

                entity.ToTable("License_TestType");

                entity.HasOne(d => d.License)
                    .WithMany(p => p.LicenseTestTypes)
                    .HasForeignKey(d => d.LicenseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_License_TestType_License");

                entity.HasOne(d => d.TestType)
                    .WithMany(p => p.LicenseTestTypes)
                    .HasForeignKey(d => d.TestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_License_TestType_TestType");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("Subscription");

                entity.Property(e => e.SubscriptionId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TestOccasion>(entity =>
            {
                entity.ToTable("TestOccasion");

                entity.Property(e => e.Cost).HasMaxLength(50);

                entity.Property(e => e.CostText).HasMaxLength(50);

                entity.Property(e => e.ExaminationDate).HasColumnType("datetime");

                entity.Property(e => e.ExaminationName).HasMaxLength(150);

                entity.Property(e => e.ExaminationTime)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.TestOccasions)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestOccasion_Language");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.TestOccasions)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestOccasion_Location");

                entity.HasOne(d => d.TestType)
                    .WithMany(p => p.TestOccasions)
                    .HasForeignKey(d => d.TestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestOccasion_TestType");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.TestOccasions)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .HasConstraintName("FK_TestOccasion_VehicleType");
            });

            modelBuilder.Entity<TestType>(entity =>
            {
                entity.ToTable("TestType");

                entity.Property(e => e.TestTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SocialSecurityNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Language");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Subscription");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Login_User");
            });

            modelBuilder.Entity<UserSearch>(entity =>
            {
                entity.ToTable("UserSearch");

                entity.Property(e => e.UserSearchId).ValueGeneratedNever();

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.License)
                    .WithMany(p => p.UserSearches)
                    .HasForeignKey(d => d.LicenseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSearch_License");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.UserSearches)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSearch_Location");

                entity.HasOne(d => d.TestType)
                    .WithMany(p => p.UserSearches)
                    .HasForeignKey(d => d.TestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSearch_TestType");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.UserSearches)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSearch_VehicleType");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.ToTable("VehicleType");

                entity.Property(e => e.VehicleTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(60);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.HasKey(e => e.LoginId);
                entity.Property(e => e.LoginId).ValueGeneratedNever();
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(50);

                entity.HasOne(x => x.Role)
                    .WithMany(x => x.Logins)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Login_LoginRole");
            });

            modelBuilder.Entity<LoginRole>(entity =>
            {
                entity.ToTable("LoginTable");

                entity.Property(e => e.LoginRoleId).ValueGeneratedNever();
                entity.Property(e => e.Description).HasMaxLength(50); ;
            });
        }

    }
}
