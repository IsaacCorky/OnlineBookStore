using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class EFOnlineBookStoreRepository : IOnlineBookStoreRepository // here is where we implement (use the template) 
    {
        private OnlineBookStoreDbContext _context; // private OnlineBookStoreDbContext type called context _ means private

        public EFOnlineBookStoreRepository (OnlineBookStoreDbContext context) // Constructor
        {
            _context = context;
        }
        public IQueryable<BookModel> Books => _context.BookModels;
    }
}
// huh?