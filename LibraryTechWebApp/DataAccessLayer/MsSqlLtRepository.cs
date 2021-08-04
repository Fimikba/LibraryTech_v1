using LibraryTechWebApp.Domains;
using LibraryTechWebApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.DataAccessLayer
{
    public class MsSqlLtRepository : ILtSqlRepositoryable
    {
        private ApplicationDbContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public MsSqlLtRepository(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            _context = context;
        }
        public IQueryable<Book> BooksForStatistic => _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Categories)
            .Include(b => b.Series)
            .Include(b => b.Reviews)
            .Include(b => b.User)
            .Include(b => b.UserHowRecentlyReadBySubs);

        public IQueryable<Book> Books => _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Categories)
            .Include(b => b.Series)
            .Include(b => b.Reviews);

        public IQueryable<Book> BooksForIndex => _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Categories)
            .Include(b => b.Series)
            .Select(b => new Book
            {
                BookId=b.BookId,
                Title = b.Title,
                Authors = b.Authors,
                Description = b.Description,
                Price = b.Price,
                Categories = b.Categories,
                Series = b.Series,
                ImageUrl = b.ImageUrl,
                IsAvailableBySubs = b.IsAvailableBySubs
            });

        public IQueryable<Book> BooksForCartRecord => _context.Books
           .Select(b => new Book
           {
               BookId = b.BookId,
               Title = b.Title,
               Price = b.Price,
               ImageUrl = b.ImageUrl,
               IsAvailableBySubs = b.IsAvailableBySubs
           });

        public IQueryable<BookAuthor> Authors => _context.Authors
            .Include(a => a.Books);

        public IQueryable<BookCategory> Categories => _context.Categories
            .Include(c => c.Books)
            .Include(c => c.Series);

        public IQueryable<BookCategory> CategoriesForMenu => _context.Categories
            .Select(c => new BookCategory
            {
                Name = c.Name,
                NumberOfRequestst=c.NumberOfRequestst
            });


        public IQueryable<BookSeries> Series => _context.Series
            .Include(s => s.Books)
            .Include(s => s.Categories);

        public IQueryable<BookSeries> SeriesForMenu => _context.Series
            .Include(s => s.Categories)
            .Select(s => new BookSeries
            {
                Name = s.Name,
                NumberOfRequestst = s.NumberOfRequestst,
                Categories=s.Categories
            });

        public IQueryable<Review> Reviews => _context.Reviews
            .Include(r => r.Book)
            .Include(r => r.User);

        public IQueryable<AppUserModel> Users => _context.Users
            .Include(u => u.Books);

        public IQueryable<AppUserModel> UsersWithBookReadingBySubs => _context.Users
            .Include(u => u.Books)
            .Include(u => u.ReadRecentlyBySubs)
            .Include(u => u.BookUserBySubs);

        public async Task AddBook(BookAddModel book)
        {
            var newBook = new Book
            {
                Title = book.Title,
                Language = book.Language,
                Genre = book.Genre,
                Description = book.Description,
                AgeLimit = book.AgeLimit,
                ReleasedPerLibraryTech = DateTime.Now,
                DateOfWriting = book.DateOfWriting,
                BookVolume = book.BookVolume,
                ISBN10 = book.ISBN10,
                ISBN13 = book.ISBN13,
                Publisher = book.Publisher,
                Price = book.Price,
                IsAvailableBySubs = book.IsAvailableBySubs
            };

            if (book.Authors != null)
            {
                //добавляем авторов 
                string[] authors = book.Authors.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var author in authors)
                {
                    var thisAuthorInDb = this.Authors.FirstOrDefault(a => a.Name == author);
                    if (thisAuthorInDb != null)
                    {
                        newBook.Authors.Add(thisAuthorInDb);
                    }
                    else
                    {
                        newBook.Authors.Add(new BookAuthor
                        {
                            Name = author
                        });
                    }
                }
            }

            if (book.Categories != null)
            {
                //добавляем категории
                string[] categories = book.Categories.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var category in categories)
                {
                    var thisCategoryInDb = this.Categories.FirstOrDefault(c => c.Name == category);
                    if (thisCategoryInDb != null)
                    {
                        newBook.Categories.Add(thisCategoryInDb);
                    }
                    else
                    {
                        newBook.Categories.Add(new BookCategory
                        {
                            Name = category
                        });
                    }
                }
            }

            if (book.Series != null)
            {
                //Добавляем серии
                string[] series = book.Series.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var ser in series)
                {
                    var SeriesForNewBook = this.Series.FirstOrDefault(s => s.Name == ser);
                    if (SeriesForNewBook == null)
                        SeriesForNewBook = new BookSeries
                        {
                            Name = ser
                        };

                    foreach (var categotyInNewBook in newBook.Categories)
                    {
                        if (SeriesForNewBook.Categories.FirstOrDefault(c => c == categotyInNewBook) == null)
                            SeriesForNewBook.Categories.Add(categotyInNewBook);
                    }

                    newBook.Series.Add(SeriesForNewBook);
                }
            }

            if (book.Cover != null)
            {
                // сохраняем обложку в каталоге wwwroot
                string pathCov = _appEnvironment.WebRootPath + "/Books/Covers/" + book.Cover.FileName;
                using (var fileStream = new FileStream(pathCov, FileMode.Create))
                {
                    await book.Cover.CopyToAsync(fileStream);
                }
                newBook.ImageUrl = book.Cover.FileName;
            }

            if (book.FullBookFile != null)
            {
                // сохраняем полную версию книги в /Files/Books/Full version
                string pathBook = Path.Combine(_appEnvironment.ContentRootPath, "Files/Books/Full version/", book.FullBookFile.FileName);
                using (var fileStream = new FileStream(pathBook, FileMode.Create))
                {
                    await book.FullBookFile.CopyToAsync(fileStream);
                }
                newBook.BookUrl = book.FullBookFile.FileName;
            }

            if (book.DemoBookFile != null)
            {
                // сохраняем демо-версию книги в /Files/Books/Demo
                string pathDemo = Path.Combine(_appEnvironment.ContentRootPath, "Files/Books/Demo/", book.DemoBookFile.FileName);
                using (var fileStream = new FileStream(pathDemo, FileMode.Create))
                {
                    await book.DemoBookFile.CopyToAsync(fileStream);
                }
                newBook.DemoUrl = book.DemoBookFile.FileName;
            }

            _context.Books.AddRange(newBook);
            _context.SaveChanges();
        }

        public void AddAuthor(BookAuthor author)
        {
            _context.Authors.AddRange(author);
            _context.SaveChanges();
        }

        public void AddCategory(BookCategory category)
        {
            _context.Categories.AddRange(category);
            _context.SaveChanges();
        }

        public void AddReview(Review review)
        {
            _context.Reviews.AddRange(review);
            _context.SaveChanges();
        }

        public void AddSeries(BookSeries series)
        {
            _context.Series.AddRange(series);
            _context.SaveChanges();
        }

        public void DelAuthor(BookAuthor author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public void DelBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void DelCategory(BookCategory category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void DelReview(Review review)
        {
            _context.Reviews.Remove(review);
            _context.SaveChanges();
        }

        public void DelSeries(BookSeries series)
        {
            _context.Series.Remove(series);
            _context.SaveChanges();
        }
    }
}
