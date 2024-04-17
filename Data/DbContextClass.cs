using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Entities;

namespace Todo.Data
{
    public class DbContextClass:DbContext
    {
        public readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<ImTodo> TodoTab { get; set; }

    }
}
