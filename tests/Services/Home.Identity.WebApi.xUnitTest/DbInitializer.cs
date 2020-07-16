using Home.Framework.Data;
using Home.Framework.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Identity.WebApi.xUnitTest
{
    public static class DbInitializer
    {
        public static void Seed(this HomeDBContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            dbContext.Set<UserEntity>().AddRange(
                new UserEntity() { UniqueId = Guid.Parse("c68a3404-0591-4184-b137-a54600d43b68"), Username = "kervin@nordikkt.fo", Password = "dMX8UoF90M3yVALxb04KxA==", Token = "acf/Twq4NphhnEaAn3SH6Q==", Active = true, Deleted = false },
                new UserEntity() { UniqueId = Guid.Parse("57c62076-1c3f-42ec-858d-a54600d43b6a"), Username = "lasse@nordikkt.fo", Password = "acf/Twq4NphhnEaAn3SH6Q==", Token = "acf/Twq4NphhnEaAn3SH6Q==", Active = true, Deleted = false },
                new UserEntity() { UniqueId = Guid.Parse("50979184-6419-44ef-b5fd-a87100f3049a"), Username = "maria@nordikkt.fo", Password = "acf/Twq4NphhnEaAn3SH6Q==", Token = "acf/Twq4NphhnEaAn3SH6Q==", Active = true, Deleted = false },
                new UserEntity() { UniqueId = Guid.Parse("13e15f30-09ee-4db4-b636-aadf00e0c6c8"), Username = "admin@northjournal.net", Password = "acf/Twq4NphhnEaAn3SH6Q==", Token = "acf/Twq4NphhnEaAn3SH6Q==", Active = true, Deleted = false },
                new UserEntity() { UniqueId = Guid.Parse("9cb95e6b-6257-4289-b629-a97300971965"), Username = "test", Password = "qL3gqx35EVTwclL+6Fo7Xw==", Token = "acf/Twq4NphhnEaAn3SH6Q==", Active = true, Deleted = false }
            );

            dbContext.SaveChanges();
        }
    }
}
