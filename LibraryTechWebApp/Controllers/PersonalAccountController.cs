using LibraryTechWebApp.BusinessLogic;
using LibraryTechWebApp.DataAccessLayer;
using LibraryTechWebApp.Domains;
using LibraryTechWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Controllers
{
    [Authorize(Roles = "Users")]
    public class PersonalAccountController : Controller
    {
        private ILtSqlRepositoryable _repository;
        private ApplicationDbContext _context;
        private Cart _cart;
        private int _pageSize = 6;
        private UserManager<AppUserModel> _userManager;

        public PersonalAccountController(ILtSqlRepositoryable repository, ApplicationDbContext context, Cart cartService, UserManager<AppUserModel> userManager)
        {
            _repository = repository;
            _context = context;
            _cart = cartService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _repository.UsersWithBookReadingBySubs.FirstOrDefault(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<Book> threeBooksLastReadBySub;
            threeBooksLastReadBySub = user.BookUserBySubs
                .OrderByDescending(b => b.DateLastRead)
                .Select(b => b.Book).Take(3);

            List <Book> threeBooksLastReadBySubFull = new List<Book>();
            if (threeBooksLastReadBySub != null)
            {
                foreach (var book in threeBooksLastReadBySub)
                {
                    threeBooksLastReadBySubFull.Add(_repository.BooksForIndex.FirstOrDefault(b => b.BookId == book.BookId));
                }
            }

            var books = new List<BookModel>();
            foreach (var book in threeBooksLastReadBySubFull)
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
                    BookId = book.BookId,
                    Title = title,
                    ImageUrl = book.ImageUrl,
                    Authors = nameAuthorInString,
                    Description = description,
                    Price = book.Price,
                    IsAvailableBySubs = book.IsAvailableBySubs,
                    IsInCart = BookIsInCart
                });
            }

            return View(books);
        }

        public IActionResult ShowBoughtBooks(int page = 1)
        {
            var user = _repository.UsersWithBookReadingBySubs.FirstOrDefault(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            List<Book> booksBoughtAll = new List<Book>();
            if (user.Books != null)
            {
                foreach (var book in user.Books)
                {
                    booksBoughtAll.Add(_repository.BooksForIndex.FirstOrDefault(b => b.BookId == book.BookId));
                }
            }
            var booksBought = booksBoughtAll
                .Skip((page - 1) * _pageSize)
                .Take(_pageSize);

            var books = new List<BookModel>();
            foreach (var book in booksBought)
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
                    BookId = book.BookId,
                    Title = title,
                    ImageUrl = book.ImageUrl,
                    Authors = nameAuthorInString,
                    Description = description,
                    Price = book.Price,
                    IsAvailableBySubs = book.IsAvailableBySubs,
                    IsInCart = BookIsInCart
                });
            }

            var info = new PaginatorInfo()
            {
                PageSize = _pageSize,
                CurentPage = page,
                TotalItem = booksBoughtAll.Count
            };

            var model = new BooksPageModel()
            {
                Books = books,
                Info = info,
            };

            return View(model);
        }
        public IActionResult ShowSubReadingBooks(int page = 1)
        {
            var user = _repository.UsersWithBookReadingBySubs.FirstOrDefault(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            List<Book> booksLastReadBySubAll = new List<Book>();
            if (user.ReadRecentlyBySubs != null)
            {
                foreach (var book in user.ReadRecentlyBySubs)
                {
                    booksLastReadBySubAll.Add(_repository.BooksForIndex.FirstOrDefault(b => b.BookId == book.BookId));
                }
            }
            var booksLastReadBySub = booksLastReadBySubAll
                .Skip((page - 1) * _pageSize)
                .Take(_pageSize);

            var books = new List<BookModel>();
            foreach (var book in booksLastReadBySub)
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
                    BookId = book.BookId,
                    Title = title,
                    ImageUrl = book.ImageUrl,
                    Authors = nameAuthorInString,
                    Description = description,
                    Price = book.Price,
                    IsAvailableBySubs = book.IsAvailableBySubs,
                    IsInCart = BookIsInCart
                });
            }

            var info = new PaginatorInfo()
            {
                PageSize = _pageSize,
                CurentPage = page,
                TotalItem = booksLastReadBySubAll.Count
            };

            var model = new BooksPageModel()
            {
                Books = books,
                Info = info,
            };

            return View(model);
        }

        public async Task<IActionResult> Setting()
        {
            AppUserModel user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(user);
        }

        [HttpPost]
        public IActionResult BuyBooks(int[] records, int paymentSystem)
        {
            //Далее временный код, который сразу добавляет книгу в список купленных книг пользователя
            //В следующем релизе код будет заменен на предоставляемый API раличных платежных систем
            var user = _repository.Users.FirstOrDefault(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (records != null)
            {
                List<Book> books = new List<Book>();
                foreach (var record in records)
                {
                    var book = _repository.Books.FirstOrDefault(b => b.BookId == record);
                    if (book != null) books.Add(book);
                }

                if (books.Count != 0)
                {
                    foreach (var book in books)
                    {
                        if(user.Books.FirstOrDefault(b => b.BookId == book.BookId)!=null) return View("Error", "Home");

                        user.Books.Add(book);
                    }

                    _context.SaveChanges();
                    _cart.Clear();

                    return View();
                }
            }

            return RedirectToAction("Error", "Home");
        }

        public IActionResult ReadBookBySubscription(int bookId)
        {
            var book = _repository.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                var user = _repository.UsersWithBookReadingBySubs.FirstOrDefault(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (user.IsSubscription == false) 
                    return View("NoSubscription");

                if (user.ReadRecentlyBySubs.FirstOrDefault(b => b.BookId == book.BookId) == null) 
                {
                    user.BookUserBySubs.Add(new BookUserBySubs { Book = book, DateLastRead = DateTime.Now });
                    _context.SaveChanges();
                }
                user.BookUserBySubs.FirstOrDefault(b => b.BookId == book.BookId).DateLastRead = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("GetBookBySubs", "Book", new { BookId = bookId });
            }

            return RedirectToAction("Error", "Home");
        }

        public IActionResult Subscribing(int tariffPlan)
        {
            var user = _repository.Users.FirstOrDefault(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user.IsSubscription == false)
            {
                if (tariffPlan == 0)
                {
                    return View("SelectTariffPlan");
                }

                //Далее временный код, который сразу добавляет подписку
                //В следующем релизе код будет заменен на предоставляемый API раличных платежных систем
                user.IsSubscription = true;
                user.SubsTariff = tariffPlan;
                _context.SaveChanges();

                return View("SubsSuccess");
            }

            return RedirectToAction("Error", "Home");
        }
    }
}
