using LibraryTechWebApp.Models;
using Microsoft.AspNetCore.Mvc;
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
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class Paginator : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;

        public Paginator(IUrlHelperFactory UrlHelperFactory)
        {
            _urlHelperFactory = UrlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PaginatorInfo PageModel { get; set; }

        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            var tagUl = new TagBuilder("ul"); // <div> </div>
            tagUl.AddCssClass("pagination");

            if (PageModel.PagesCount > 1)
            {
                for (int i = 1; i <= PageModel.PagesCount; i++)
                {
                    var tagLi = new TagBuilder("li");
                    tagLi.AddCssClass("page-item");

                    var tagA = new TagBuilder("a");
                    tagA.Attributes["href"] = urlHelper.Action(PageAction, new { page = i });
                    tagA.InnerHtml.Append(i.ToString());
                    tagA.AddCssClass("page-link");
                    if (i == PageModel.CurentPage)
                    {
                        tagLi.AddCssClass("active");
                    }

                    tagLi.InnerHtml.AppendHtml(tagA);

                    tagUl.InnerHtml.AppendHtml(tagLi);
                }
            }

            output.Content.AppendHtml(tagUl);
        }
    }
}
