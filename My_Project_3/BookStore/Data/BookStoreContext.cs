using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using MyRepository.PostgreSQL;

namespace BookStore.Data{
    public class BookStoreContext : DbContext{
        public virtual Repository<Author> Authors {get; set;}
        public virtual Repository<Book> Books {get; set;}

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options){
            Authors = new Repository<Author>(this);
            Books = new Repository<Book>(this);

            Authors.Rows = Set<Author>();
            Books.Rows = Set<Book>();
        }

        //more info: https://www.youtube.com/watch?v=aVADvEqkP0U
        //pogledaj desc za ef database to code and vice verse-a
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .HasMany<Book>(b => b.Books)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Author>().HasKey(a => a.Id);
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
        }
    }
}