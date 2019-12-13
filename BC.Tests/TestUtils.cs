using BC.Data;
using Microsoft.EntityFrameworkCore;

namespace BC.Tests
{
    public static class TestUtils
    {
        public static DbContextOptions<BettingContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<BettingContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }
    }
}
