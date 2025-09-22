using Microsoft.EntityFrameworkCore;

namespace Unit_1_Project.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Genre> Genres { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    bookID = 1,
                    title = "this is a title",
                    year = 1999,
                    rating = 5,
                    GenreID = "A"
                },

                new Book
                {
                    bookID = 2,
                    title = "this is also a title",
                    year = 1998,
                    rating = 1,
                    GenreID = "H"
                },

                new Book
                {
                    bookID = 3,
                    title = "title 3",
                    year = 2017,
                    rating = 4,
                    GenreID = "D"
                }
             );

            modelBuilder.Entity<Genre>().HasData(
            new Genre { GenreID = "A", genre = "Action" },
            new Genre { GenreID = "C", genre = "Comedy" },
            new Genre { GenreID = "D", genre = "Drama" },
            new Genre { GenreID = "H", genre = "Horror" }
            );

               
        }

    }
}
