using Microsoft.EntityFrameworkCore;

namespace Static.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }
    }
}