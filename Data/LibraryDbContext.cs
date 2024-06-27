using BookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace BookManagement.Data
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Dalia", Email = "Dalia@enozom.com", Phone = "01210360420" },
                new Student { Id = 2, Name = "Mohamed", Email = "mohamed@enozom.com", Phone = "0111155000" },
                new Student { Id = 3, Name = "Ahmed", Email = "ahmed@enozom.com", Phone = "0155553311" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Clean Code" },
                new Book { Id = 2, Title = "Algorithms" }
            );

            modelBuilder.Entity<BookCopy>().HasData(
           new BookCopy { Id = 1, BookId = 1, StatusId = 1 },
           new BookCopy { Id = 2, BookId = 2, StatusId = 1 },
           new BookCopy { Id = 3, BookId = 1, StatusId = 1 }
       );
            modelBuilder.Entity<Status>().HasData(
              new Status { StatusId = 1, status = "Good" },
              new Status { StatusId = 2, status = "Damaged" },
              new Status { StatusId = 3, status = "Borrowed" }
          );
        }
    }
}

