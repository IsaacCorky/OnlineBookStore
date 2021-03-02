using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<BookModel> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string BookCategory { get; set; }// property
    }
}
