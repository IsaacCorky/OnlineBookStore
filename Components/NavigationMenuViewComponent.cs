using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookStore.Components;
using OnlineBookStore.Models;

namespace OnlineBookStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
      private IOnlineBookStoreRepository repository;

      public NavigationMenuViewComponent (IOnlineBookStoreRepository r)
        {
            repository = r;
        }

      public IViewComponentResult Invoke() // data type is a view 
        {
            ViewBag.Selected = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.BookCategory)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
