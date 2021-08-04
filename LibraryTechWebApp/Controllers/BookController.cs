using LibraryTechWebApp.BusinessLogic;
using LibraryTechWebApp.DataAccessLayer;
using LibraryTechWebApp.Domains;
using LibraryTechWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryTechWebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private ILtSqlRepositoryable _repository;
        private StatisticAnalizer _statisticAnalizer;
        private Cart _cart;
        private int _pageSize = 6;

        public BookController(IWebHostEnvironment appEnvironment, ILtSqlRepositoryable repository, Cart cartService, StatisticAnalizer statisticAnalizer)
        {
            _appEnvironment = appEnvironment;
            _repository = repository;
            _cart = cartService;
            _statisticAnalizer = statisticAnalizer;
        }

        public IActionResult Index(string category, string series, string author, int page = 1)
        {
            var booksFromDb = _repository.BooksForIndex
                .Where(b => category == null || b.Categories.FirstOrDefault(c=>c.Name==category) != null)
                .Where(b => series == null || b.Series.FirstOrDefault(s => s.Name == series) != null)
                .Where(b => author == null || b.Authors.FirstOrDefault(a => a.Name == author) != null)
                .Skip((page - 1) * _pageSize)
                .Take(_pageSize);

            var books = new List<BookModel>();
            foreach (var book in booksFromDb)
            {
                var authorsInList = new List<string>();
                foreach (var authorFromDb in book.Authors)
                {
                    authorsInList.Add(authorFromDb.Name);
                }
                string nameAuthorInString = string.Join(", ", authorsInList);

                string description = "";
                if (book.Description != null)
                    if (book.Description.Length <= 110)
                        description = book.Description;
                else
                        description = book.Description.Substring(0, 107) + "...";

                string title = "";
                if (book.Title != null)
                    if (book.Title.Length <= 50)
                        title = book.Title;
                    else
                        title = book.Title.Substring(0, 47) + "...";

                BookAsCartRecord BookInCart = _cart.Records.FirstOrDefault(r => r.BookId == book.BookId);
                bool BookIsInCart;
                if (BookInCart == null)
                    BookIsInCart = false;
                else
                    BookIsInCart = true;

                books.Add(new BookModel
                {
                    BookId=book.BookId,
                    Title = title,
                    ImageUrl = book.ImageUrl,
                    Authors = nameAuthorInString,
                    Description = description,
                    Price=book.Price,
                    IsAvailableBySubs=book.IsAvailableBySubs,
                    IsInCart=BookIsInCart
                });
            }

            var info = new PaginatorInfo()
            {
                PageSize = _pageSize,
                CurentPage = page,
                TotalItem = _repository
                    .BooksForIndex
                    .Where(b => category == null || b.Categories.FirstOrDefault(c => c.Name == category) != null)
                    .Where(b => series == null || b.Series.FirstOrDefault(s => s.Name == series) != null)
                    .Where(b => author == null || b.Authors.FirstOrDefault(a => a.Name == author) != null)
                    .Count()
            };

            var model = new BooksPageModel()
            {
                Books = books,
                Info = info,
                Category = category,
                Series= series,
                Author = author
            }; 
            return View(model);
        }

        public IActionResult ShowBookInformation(int bookId)
        {
            var book = _repository.Books.FirstOrDefault(b => b.BookId == bookId);

            BookAsCartRecord BookInCart = _cart.Records.FirstOrDefault(r => r.BookId == book.BookId);
            bool BookIsInCart;
            if (BookInCart == null)
                BookIsInCart = false;
            else
                BookIsInCart = true;

            var model = new ShowBookModel
            {
                Book = book,
                IsInCart = BookIsInCart
            };

            return View(model);
        }

        [Authorize(Roles = "Admins")]
        public IActionResult AddBook()
        {
            return View();
        }
        [Authorize(Roles = "Admins")]
        [HttpPost]
        public async Task<IActionResult> AddBook(BookAddModel book)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddBook(book);
                
               return RedirectToAction("Index", "Admin");
            }

            return View(book);
        }

        [Authorize(Roles = "Users")]
        public IActionResult GetBook(int BookId)
        {
            var user = _repository.Users.FirstOrDefault(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            var book = _repository.Books.FirstOrDefault(b => b.BookId == BookId);

            if (user.Books.FirstOrDefault(b => b.BookId == book.BookId) != null && book.BookUrl!=null)
            {
                string filePath = Path.Combine(_appEnvironment.ContentRootPath,
               string.Concat("Files/Books/Full version/", book.BookUrl));

                string fileType = "application/epub";

                var authors = new List<string>();
                foreach (var author in book.Authors)
                {
                    authors.Add(author.Name);
                }

                string fileName = string.Concat(
                    book.Title,
                    " — ",
                    string.Join<string>(',', authors),
                    ".epub");

                return PhysicalFile(filePath, fileType, fileName);
            }

            return RedirectToAction("Error", "Home");
        }
        public IActionResult GetDemo(int BookId)
        {
            var book = _repository.Books.FirstOrDefault(b => b.BookId == BookId);

            if (book!=null && book.DemoUrl!=null)
            {
                string filePath = Path.Combine(_appEnvironment.ContentRootPath,
               string.Concat("Files/Books/Demo/", book.DemoUrl));

                string fileType = "application/pdf";

                var authors = new List<string>();
                foreach (var author in book.Authors)
                {
                    authors.Add(author.Name);
                }

                string fileName = string.Concat(
                    book.Title,
                    " — ",
                    string.Join<string>(',', authors),
                    ".pdf");

                return PhysicalFile(filePath, fileType, fileName);
            }

            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Users")]
        public IActionResult GetBookBySubs(int BookId)
        {
            var user = _repository.Users.FirstOrDefault(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            var book = _repository.Books.FirstOrDefault(b => b.BookId == BookId);

            if (user.IsSubscription==true && book.BookUrl != null)
            {
                string filePath = Path.Combine(_appEnvironment.ContentRootPath,
               string.Concat("Files/Books/Full version/", book.BookUrl));

                string fileType = "application/epub";

                var authors = new List<string>();
                foreach (var author in book.Authors)
                {
                    authors.Add(author.Name);
                }

                string fileName = string.Concat(
                    book.Title,
                    " — ",
                    string.Join<string>(',', authors),
                    ".epub");

                return PhysicalFile(filePath, fileType, fileName);
            }

            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Admins")]
        public IActionResult TopSellingStatistics(int page = 1)
        {
            var book = _statisticAnalizer.GetTopSellingStatistics();
            var info = new PaginatorInfo()
            {
                PageSize = _pageSize,
                CurentPage = page,
                TotalItem = book.Count()
            };

            var model = new StatisticModel
            {
                Books = book.Skip((page - 1) * _pageSize).Take(_pageSize),
                Info = info
            };

            return View(model);
        }

        [Authorize(Roles = "Admins")]
        public IActionResult TopReadBySubsStatistics(int page = 1)
        {
            var book = _statisticAnalizer.GetTopReadBySubsStatistics();
            var info = new PaginatorInfo()
            {
                PageSize = _pageSize,
                CurentPage = page,
                TotalItem = book.Count()
            };

            var model = new StatisticModel
            {
                Books = book.Skip((page - 1) * _pageSize).Take(_pageSize),
                Info = info
            };

            return View(model);
        }
    }
}
