using Home.Framework.Data.Entities;
using Home.Framework.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Home.Framework.Data
{
    public class HomeDBContext : DbContext
    {
        public HomeDBContext(DbContextOptions<HomeDBContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AlbumEntityConfiguration
                .Configure(modelBuilder.Entity<AlbumEntity>());

            AlbumPriceEntityConfiguration
                .Configure(modelBuilder.Entity<AlbumPriceEntity>());

            AlbumRatingEntityConfiguration
                .Configure(modelBuilder.Entity<AlbumRatingEntity>());

            ArtistEntityConfiguration
                .Configure(modelBuilder.Entity<ArtistEntity>());

            CompanyEntityConfiguration
                .Configure(modelBuilder.Entity<CompanyEntity>());

            ContactsEntityConfiguration
                .Configure(modelBuilder.Entity<ContactsEntity>());

            DepartmentEmployeeEntityConfiguration
                .Configure(modelBuilder.Entity<DepartmentEmployeeEntity>());

            DepartmentEntityConfiguration
                .Configure(modelBuilder.Entity<DepartmentEntity>());

            EmployeeEntityConfiguration
                .Configure(modelBuilder.Entity<EmployeeEntity>());

            GenderEntityConfiguration
                .Configure(modelBuilder.Entity<GenderEntity>());

            LanguageEntityConfiguration
                .Configure(modelBuilder.Entity<LanguageEntity>());

            MusicTypeEntityConfiguration
                .Configure(modelBuilder.Entity<MusicTypeEntity>());

            RatingTypeEntityConfiguration
                .Configure(modelBuilder.Entity<RatingTypeEntity>());

            RoleEntityConfiguration
                .Configure(modelBuilder.Entity<RoleEntity>());

            SiteStyleTypeEntityConfiguration
                .Configure(modelBuilder.Entity<SiteStyleTypeEntity>());

            SongEntityConfiguration
                .Configure(modelBuilder.Entity<SongEntity>());

            SongPriceEntityConfiguration
                .Configure(modelBuilder.Entity<SongPriceEntity>());

            SystemTypeEntityConfiguration
                .Configure(modelBuilder.Entity<SystemTypeEntity>());

            UserEntityConfiguration
                .Configure(modelBuilder.Entity<UserEntity>());

            UserRoleEntityConfiguration
                .Configure(modelBuilder.Entity<UserRoleEntity>());

            VersionHistoryEntityConfiguration
                .Configure(modelBuilder.Entity<VersionHistoryEntity>());

            base.OnModelCreating(modelBuilder);
        }

    }
}
