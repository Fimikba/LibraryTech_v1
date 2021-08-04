using LibraryTechWebApp.BusinessLogic;
using LibraryTechWebApp.DataAccessLayer;
using LibraryTechWebApp.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Helpers
{
    [HtmlTargetElement("a", Attributes = "book-id")]
    public class BuyBottonTagHelper : TagHelper
    {
        private Cart _cart;
        private IUrlHelperFactory _urlHelperFactory;
        private IActionContextAccessor _actionAccessor;
        private UserManager<AppUserModel> _userManager;
        private ILtSqlRepositoryable _repository;

        public BuyBottonTagHelper(Cart cartService, IUrlHelperFactory UrlHelperFactory, IActionContextAccessor actionAccessor, UserManager<AppUserModel> userManager, ILtSqlRepositoryable repository)
        {
            _cart = cartService;
            _urlHelperFactory = UrlHelperFactory;
            _actionAccessor = actionAccessor;
            _userManager = userManager;
            _repository = repository;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public int BookId { get; set; }
        public string ReturnUrl { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = _actionAccessor.ActionContext.HttpContext.User;
            AppUserModel currentUserFull = _repository.Users.FirstOrDefault(u => u.Id == _userManager.GetUserId(currentUser));

            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            var tagA = new TagBuilder("a");

            if (currentUserFull != null)
            {
                if (currentUserFull.Books.FirstOrDefault(b => b.BookId == BookId) != null)
                {
                    tagA.AddCssClass("btn btn-info disabled");
                    //tagA.Attributes["href"] = urlHelper.Action("AddToCart", "Cart", new { bookId = BookId, returnUrl=ReturnUrl });
                    tagA.InnerHtml.Append("Bought");

                    output.Content.SetHtmlContent(tagA);
                    return;
                }
            }

            if(_cart.Records.FirstOrDefault(r=>r.BookId==BookId) != null)
            {
                tagA.AddCssClass("btn btn-success");
                tagA.Attributes["href"] = urlHelper.Action("RemoveFromCart", "Cart", new { bookId = BookId, returnUrl=ReturnUrl });
                tagA.InnerHtml.Append("In cart");

                output.Content.SetHtmlContent(tagA);
                return;
            }

            else
            {
                tagA.AddCssClass("btn btn-outline-light");
                tagA.Attributes["href"] = urlHelper.Action("AddToCart", "Cart", new { bookId = BookId, returnUrl=ReturnUrl });
                tagA.InnerHtml.Append("Buy");

                output.Content.SetHtmlContent(tagA);
            }
        }
    }
}
