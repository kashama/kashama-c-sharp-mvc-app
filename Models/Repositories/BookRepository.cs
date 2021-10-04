using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MYMVCAPP.Models;
using MYMVCAPP.Repositories;
using MYMVCAPP.Controllers;

namespace MYMVCAPP.Repositories
{
    public class BookRepository

    {

        public List<BookModel> GetAllBooks() // this action method is used to get all the books from databse
        {
            return DataSource();
        }
        public BookModel GetBookById(int id) // this method is used to get a particular book from a database
        {
            return DataSource().Where(x=> x.Id==id).FirstOrDefault();// to get a particular item id
        }
        public List<BookModel> SearchBook(string title, string author, int id)// to search a book by its title, author or id
        {
            return DataSource().Where(x=> x.Title.Contains(title) && x.Author==author || x.Id==id).ToList();
        }
        private List<BookModel> DataSource()// method to get access to database
        {
            return new List<BookModel>()//books list
            {
                new BookModel(){Id=1, Title="Think and grow rich.", Author="Napoleon Hill"},
                new BookModel(){Id=2, Title="How to make friends and influence people.", Author="Dale Carnague"},
                new BookModel(){Id=3, Title="Rich Dad, Poor Dad", Author="Robert Kiyosaki"},
                new BookModel(){Id=4, Title="The power of present moment", Author="Eckarte Tolé"},
                new BookModel(){Id=5, Title="The power of your subconscious mind", Author="Joseph Maurphy"},
                new BookModel(){Id=6, Title="101 facons de transformer sa vie", Author="Wayne Dier"},
                new BookModel(){Id=7, Title="Le virage", Author="Wayne Dier"},
                new BookModel(){Id=8, Title="Atteindre la serenité", Author="Eckart Tolé"},
                new BookModel(){Id=9, Title="La maitrise de l'amour", Author="Don Miguel Ruiz"},
                new BookModel(){Id=10, Title="Les quatres accords tolteques", Author="Don Miguel Ruiz"},
                new BookModel(){Id=11, Title="les 7 cles de la vie", Author="Wayne Dier"},
                new BookModel(){Id=12, Title="L'effect cumilé", Author="Hardi"}
                
                
            };
        }

        internal BookModel DeleteBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}