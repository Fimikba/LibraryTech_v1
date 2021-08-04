using LibraryTechWebApp.BusinessLogic;
using LibraryTechWebApp.DataAccessLayer;
using LibraryTechWebApp.Domains;
using LibraryTechWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ILtSqlRepositoryable _repository;
        private Cart _cart;

        public CartController(ILtSqlRepositoryable repository, Cart cartService)
        {
            _repository = repository;
            _cart = cartService;
        }

        public IActionResult Index()
        {
            var user = _repository.Users.FirstOrDefault(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            decimal PriceWithDiscount = 0;
            if (user != null && user.IsSubscription == true && user.SubsTariff != 1)
            {
                if (user.SubsTariff == 2) PriceWithDiscount = _cart.TotalCoast / 100 * 90;
                if (user.SubsTariff == 3) PriceWithDiscount = _cart.TotalCoast / 100 * 80;
            }

            var model = new ShowCartModel
            {
                Cart = _cart,
                TotalCoastWithDiscount = PriceWithDiscount
            };

            return View(model);
        }

        public RedirectResult AddToCart(int bookId, string returnUrl)
        {
            Book book = _repository.BooksForCartRecord
                .FirstOrDefault(b => b.BookId == bookId);
            if (book == null)
                return Redirect("Home/Error");

            var bookRecord = new BookAsCartRecord
            {
                BookId = book.BookId,
                Title = book.Title,
                Price = book.Price,
                ImageUrl = book.ImageUrl,
                IsAvailableBySubs = book.IsAvailableBySubs
            };

            _cart.Add(bookRecord);

            return Redirect(returnUrl);
        }

        public RedirectResult RemoveFromCart(int bookId, string returnUrl)
        {
            Book book = _repository.BooksForCartRecord
                .FirstOrDefault(b => b.BookId == bookId);
            if (book == null)
                return Redirect("Home/Error");

            var bookRecord = new BookAsCartRecord
            {
                BookId = book.BookId,
                Title = book.Title,
                Price = book.Price,
                ImageUrl = book.ImageUrl,
                IsAvailableBySubs = book.IsAvailableBySubs
            };

            _cart.Remove(bookRecord);

            return Redirect(returnUrl);
        }
    }
}
