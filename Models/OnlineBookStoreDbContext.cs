using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class OnlineBookStoreDbContext : DbContext // inherit from DbContext & using Microsoft.EntityFrameworkCore; above
    {
        public OnlineBookStoreDbContext (DbContextOptions<OnlineBookStoreDbContext> options) : base (options)
        {// Constructor recieves DbContextOptions of type OnlineBookStoreDbContext called options that inherits from base of DbContext

        }
            
        public DbSet<BookModel> BookModels { get; set; } // used to query and save instances of BookModel
    }
}
