using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MYMVCAPP.Controllers;
using MYMVCAPP.Models;
using MYMVCAPP.Repositories;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MYMVCAPP.Controllers
{
    public class BookController: Controller
    {
        //here we can create multiple action methods like: GetAllBooks, GetBook, DeleteAllBooks, AddBook, UpdateBook etc.
        private readonly BookRepository _bookRepository= null;
        public BookController()
        {
            _bookRepository=new BookRepository();//instantiation
        }

        public List<BookModel> GetAllBooks()// this action method allows to get all books
        {
            return _bookRepository.GetAllBooks();
        } 

        //here we transform our method to use view
        public ViewResult GetAllBooks()// this action method allows to get all books
        {
            var data = _bookRepository.GetAllBooks();
            
            return View();
        }
        public ViewResult GetBookById(int id)// this action method is used to get one book
        {
           // return $"A book is returned with id ={id}";
            var oneBook = _bookRepository.GetBookById(id);
           
            return View();
        }
        public BookModel GetBookById(int id)// this action method is used to get one book
        {
           // return $"A book is returned with id ={id}";
           return _bookRepository.GetBookById(id);
        } 

        public ViewResult SearchBooks(string bookName, string authorName, int id)
        {
           // return $"Book name is ={bookName} & Author is ={authorName} & Publish  in  ={publishYear} & Book Id is={id}";
            var bookFound = _bookRepository.SearchBook(bookName, authorName, id);
           
            return View();//here when we return view method, then view discovery takes place
        }
        
         public List<BookModel> SearchBooks(string bookName, string authorName, int id)
        {
            return _bookRepository.SearchBook(bookName, authorName, id);
        } 
        public BookModel DeleteBook(int id) => _bookRepository.DeleteBook(id);// this method is used to delete item by its id

         public IActionResult Index()
         {
             return View();
         } 
    }
   
}