using Microsoft.EntityFrameworkCore;
using Points.Domain.Entities;

namespace Points.Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Dot> Dots { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Dot dot1 = new Dot() { Id = 1, PositionX = 200, PositionY = 200, Radius = 25 };
            Comment comment1 = new Comment() { Id = 1, BackgroundColor = "pink", Text = "Test", DotId = dot1.Id };

            modelBuilder.Entity<Dot>().HasData(dot1);
            modelBuilder.Entity<Comment>().HasData(comment1);

            base.OnModelCreating(modelBuilder);
        }
    }
}