using LibraryTechWebApp.BusinessLogic;
using LibraryTechWebApp.Domains;
using LibraryTechWebApp.Helpers;
using LibraryTechWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Services
{
    public class ServiceCart : Cart
    {
        private ISession _session;

        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()
                .HttpContext.Session;
            ServiceCart serviceCart = session.GetSubject<ServiceCart>("Cart") ?? new ServiceCart();

            serviceCart._session = session;

            return serviceCart;
        }

        public override void Add(BookAsCartRecord book)
        {
            base.Add(book);
            _session.SetSubject("Cart", this);
        }

        public override void Remove(BookAsCartRecord book)
        {
            base.Remove(book);
            _session.SetSubject("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            _session.SetSubject("Cart", this);
        }
    }
}
