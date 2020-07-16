using Home.Framework.Data;
using Home.Framework.Data.Entities;
using System;

namespace Home.WebApi.xUnitTest
{
    public static class DbInitializer
    {
        public static void Seed(this HomeDBContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();



            dbContext.Set<ContactsEntity>().AddRange(
                new ContactsEntity() { FirstName = "Firstname1", LastName = "Lastname1", Email = "email@email1.com", Phone = "111-0000" },
                new ContactsEntity() { FirstName = "Firstname2", LastName = "Lastname2", Email = "email@email2.com", Phone = "222-0000" },
                new ContactsEntity() { FirstName = "Firstname3", LastName = "Lastname3", Email = "email@email3.com", Phone = "333-0000" }
            );

            dbContext.Set<RatingTypeEntity>().AddRange(
                new RatingTypeEntity() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b1"), Name = "Star 1", Value = 1 },
                new RatingTypeEntity() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b2"), Name = "Star 2", Value = 2 },
                new RatingTypeEntity() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b3"), Name = "Star 3", Value = 3 },
                new RatingTypeEntity() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b4"), Name = "Star 4", Value = 4 },
                new RatingTypeEntity() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b5"), Name = "Star 5", Value = 5 }
            );

            dbContext.Set<MusicTypeEntity>().AddRange(
                new MusicTypeEntity() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3c1"), Name = "Pop" },
                new MusicTypeEntity() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3c2"), Name = "Rock and Roll" }
            );

            dbContext.Set<ArtistEntity>().AddRange(
                new ArtistEntity() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a1"), Name = "Backstreet Boys" },
                new ArtistEntity() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a2"), Name = "The Beatles" },
                new ArtistEntity() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a3"), Name = "Elvis Presley" }
            );

            dbContext.Set<AlbumPriceEntity>().AddRange(
                new AlbumPriceEntity() { UniqueId = Guid.Parse("1a178d0e-6602-4375-a088-ab8d00facaa1"), Price = (decimal)11.29 },
                new AlbumPriceEntity() { UniqueId = Guid.Parse("1a178d0e-6602-4375-a088-ab8d00facaa2"), Price = (decimal)12.29 },
                new AlbumPriceEntity() { UniqueId = Guid.Parse("1a178d0e-6602-4375-a088-ab8d00facaa3"), Price = (decimal)13.29 }
            );

            dbContext.Set<SongPriceEntity>().AddRange(
                new SongPriceEntity() { UniqueId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb1"), Price = (decimal)1.29 },
                new SongPriceEntity() { UniqueId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb2"), Price = (decimal)1.30 },
                new SongPriceEntity() { UniqueId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb3"), Price = (decimal)1.31 },
                new SongPriceEntity() { UniqueId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb4"), Price = (decimal)1.32 }
            );

            dbContext.SaveChanges();

            dbContext.Set<AlbumEntity>().Add(new AlbumEntity
            {
                UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"),
                Name = "DNA",
                Review = @"There's one question the Backsteet Boys can't seem to escape: Do they still consider themselves a boy band? The five-piece, most of whom are now over 40 and married with children, have come to embrace the term. ""At this point, 'boys' has come to mean more, like, 'friends'."" Kevin Richardson told...",
                Released = DateTime.Parse("2019-01-25"),
                CopyRightInfo = "© 2018 K-Bahn, LLC & RCA Records, a division of Sony Music Entertainment",
                CoverPath = "Uploads/Pictures/Albums/Covers/DNA.png",
                MusicTypeId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3c1"),
                ArtistId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a1"),
                AlbumPriceId = Guid.Parse("1a178d0e-6602-4375-a088-ab8d00facaa1")
            });

            dbContext.SaveChanges();

            dbContext.Set<SongEntity>().AddRange(
                new SongEntity() { UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facad1"), AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"), SongPriceId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb1"), Number = 1, Name = "Don't Go Breaking My Heart", Time = new TimeSpan(00, 03, 36), Popularity = 70 },
                new SongEntity() { UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facad2"), AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"), SongPriceId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb1"), Number = 2, Name = "Nobody Else", Time = new TimeSpan(00, 03, 38), Popularity = 20 },
                new SongEntity() { UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facad3"), AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"), SongPriceId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb1"), Number = 3, Name = "Breathe", Time = new TimeSpan(00, 03, 06), Popularity = 30 },
                new SongEntity() { UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facad4"), AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"), SongPriceId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb1"), Number = 4, Name = "New Love", Time = new TimeSpan(00, 03, 00), Popularity = 25 }
            );

            dbContext.SaveChanges();

            dbContext.Set<AlbumRatingEntity>().AddRange(
                new AlbumRatingEntity() { UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00fabbb1"), AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"), RatingTypeId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b4") },
                new AlbumRatingEntity() { UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00fabbb2"), AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"), RatingTypeId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b5") }
            );

            dbContext.SaveChanges();
        }
    }
}
