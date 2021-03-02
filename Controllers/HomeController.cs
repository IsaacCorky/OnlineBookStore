using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookStore.Models.ViewModels;

namespace OnlineBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IOnlineBookStoreRepository _repository;

        public int PageSize = 5; // here is the number of items to display per page

        public HomeController(ILogger<HomeController> logger, IOnlineBookStoreRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int P = 1)
        {
            return View(new BookListViewModel
            {   // 1st property of the BookListViewModel
                Books = _repository.Books
                    .Where(b => category == null || b.BookCategory == category)
                    .OrderBy(b => b.BookId) // order by like in SQL
                    .Skip((P - 1) * PageSize) // 0 base ID start at 0
                    .Take(PageSize)
                ,
                // 2nd property of the BookListViewModel
                PagingInfo = new PagingInfo
                {
                    CurrentPage = P,
                    ItemsPerPage = PageSize,
                    // number of pages is dynamic
                    TotalNumItems = category == null ? _repository.Books.Count() :
                                                       _repository.Books.Where(x => x.BookCategory == category).Count()
                },
                // 3rd property of the BookListViewModel
                BookCategory = category

            }); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
