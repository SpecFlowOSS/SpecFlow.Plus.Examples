using Microsoft.EntityFrameworkCore;

namespace DatabaseCode
{
    public class DatabaseContext
        : DbContext
    {
        private readonly int _threadId;

        public DatabaseContext(int threadId)
        {
            _threadId = threadId;
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase($"{_threadId}");
        }
    }
}
