using EntityFramework.Model;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Assignee> Assignees { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
    }
}
 