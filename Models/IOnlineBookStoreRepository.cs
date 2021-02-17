using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public interface IOnlineBookStoreRepository //interface is used for inheritance unlike a class - defines structure
    {
        IQueryable<BookModel> Books { get; }
    }
}
// we will now use this in the implementation class