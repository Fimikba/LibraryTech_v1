using LibraryTechWebApp.Domains;
using LibraryTechWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.DataAccessLayer
{
    public interface ILtSqlRepositoryable
    {
        public IQueryable<Book> Books { get; }
        public IQueryable<Book> BooksForStatistic { get; }
        public IQueryable<Book> BooksForIndex { get; }
        public IQueryable<Book> BooksForCartRecord { get; }
        public IQueryable<BookAuthor> Authors { get; }
        public IQueryable<BookCategory> Categories { get; }
        public IQueryable<BookCategory> CategoriesForMenu { get; }
        public IQueryable<BookSeries> Series { get; }
        public IQueryable<BookSeries> SeriesForMenu { get; }
        public IQueryable<Review> Reviews { get; }
        public IQueryable<AppUserModel> Users { get; }
        public IQueryable<AppUserModel> UsersWithBookReadingBySubs { get; }
        public Task AddBook(BookAddModel book);
        public void DelBook(Book book);
        public void AddAuthor(BookAuthor author);
        public void DelAuthor(BookAuthor author);
        public void AddCategory(BookCategory category);
        public void DelCategory(BookCategory category);
        public void AddSeries(BookSeries series);
        public void DelSeries(BookSeries series);
        public void AddReview(Review review);
        public void DelReview(Review review);
    }
}
