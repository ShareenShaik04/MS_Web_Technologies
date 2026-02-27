using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;
using System.Collections.Generic;

namespace MoviesApp.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies => Set<Movie>();
    }
}