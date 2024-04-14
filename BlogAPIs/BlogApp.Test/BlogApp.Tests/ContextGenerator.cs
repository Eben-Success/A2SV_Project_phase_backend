using BlogCrudApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Tests
{
    public class ContextGenerator
    {
        public static ApiDbContext Generator()
        {
            var options = new DbContextOptionsBuilder<ApiDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

            return new ApiDbContext(options);
        }
    }
}