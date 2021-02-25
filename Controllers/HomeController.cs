using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookStore.Models;
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

        public IActionResult Index(int P = 1)
        {
            return View(new BookListViewModel
            {
                Books = _repository.Books
                    .OrderBy(p => p.BookId) // order by like in SQL
                    .Skip((P - 1) * PageSize) // 0 base ID start at 0
                    .Take(PageSize)
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = P,
                    ItemsPerPage = PageSize,
                    TotalNumItems = _repository.Books.Count()
                }

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
