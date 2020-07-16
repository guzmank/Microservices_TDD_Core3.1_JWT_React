using Generic.Framework.Helpers;
using Home.Framework.Data;
using Microsoft.EntityFrameworkCore;

namespace Home.WebApi.xUnitTest
{
    public static class DbContextMocker
    {
        // LOCAL
        private const string connectionString = "Connection_string_encrypted_FpsasdfasdfasUXtYl7OiKTbfdfasdfamaCPkGLn7BLY";

        public static HomeDBContext GetHomeDBContext()
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<HomeDBContext>()
                .UseInMemoryDatabase(databaseName: connectionString.Decrypt())
                .Options;

            // Create instance of DbContext
            var dbContext = new HomeDBContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
