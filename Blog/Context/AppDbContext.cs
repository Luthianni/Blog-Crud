using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<BlogM> Blogs { get; set; }

        public DbSet<BlogCurtida> BlogCurtidas{ get; set; }

        public DbSet<BlogImagem> BlogImagems {get; set; }
    }


}

