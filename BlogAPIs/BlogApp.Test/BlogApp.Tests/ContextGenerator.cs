using Microsoft.EntityFrameworkCore;
using BlogCrudApp.Data;

namespace BlogApp.Tests
{
    public class ContextGenerator
    {
        public static ApiDbContext Generator()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            var context = new ApiDbContext(optionsBuilder);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }
    }
}
