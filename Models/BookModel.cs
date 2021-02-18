using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class BookModel
    {

        [Key]
        [Required]
        public int BookId { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string BookAuthorFirstName { get; set; } // AuthorFirstName
        [Required]
        public string BookAuthorMiddleName { get; set; } // AuthorMiddleInitial 
        [Required]
        public string BookAuthorLastName { get; set; } // AuthorLastName 
        [Required]
        public string BookPublisher { get; set; }
        [Required]
        [RegularExpression(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$", ErrorMessage = "ISBN format is invalid.")] // Get regex for ###-##########
        public string BookISBN { get; set; }
        [Required]
        public string BookCategory { get; set; } // atomic
        [Required]
        public string BookClassification { get; set; } //atomic
        [Required]
        public double BookPrice { get; set; }

    }
}

/*IS 413 –HiltonAssignment #5Jeff Bezoswas 30 years old when he quit his job and founded Amazon in 1994, selling books online out of his garage.  
 * His parents provided the seed money of $250,000.  Amazon launched their website in 1995, where revenue totaled $511,000 in their first five months. 
 * After receiving an additional $8 million in funding in 1996, total revenue that year jumped up to $15.7 million.  The company went public in 1997, 
 * just shy of three years after the company was founded, and Bezos made an approximate $54 million in that IPO.  By 1999, five years after starting Amazon, 
 * Bezos made his first appearance on the Billionaires list.  He has said:“A brand for a company is like a reputation for a person. You earn reputation 
 * by trying to do hard things well.”It took a full year to develop, test, and debug the Amazon website.  We are going to build something similar in just 
 * a few weeks using ASP.NET Core MVCover the course of the next few assignments.This assignment focuses on creatingthe databaseportion of the web app.
 * Create a web app for an online bookstore.  For each book, we want to store the following information:•Title•Author•Publisher•ISBN•Classification/Category
 * •PriceAll fields are required.  Use the “Model First” approach described in the videos to set up and create the database that we will use for the app.  
 * The ISBN needs to be entered in a valid format.  Include a “BookId” field that can be used as a primary key.Use good normalization principles 
 * (i.e. no non-atomic fields, no repeating groups).Seed the database using some of Prof. Hilton’s favorite books he’s read over the last few years 
 * (found in the table on the next page).Once the database has been created, list out all the books from the database on the Indexview.  Be sure to style 
 * your page using Bootstrap (#notcovered in the videos, but there is a section at the end of Chapter 7 in the Freeman textbook that goes over somestyling
 * techniques.)Submit a link to the GitHub repository containing your assignment via Learning Suite.(NOTE:  If you cannot submit via GitHub, you can submit 
 * a link to a .zip file, but you will lose 5 points.)
*/

// 7.22 Remove migrations
// 7.20 Run migrations