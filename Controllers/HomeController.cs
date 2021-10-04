using Microsoft.AspNetCore.Mvc;
using System;
using MYMVCAPP.Controllers;


namespace MYMVCAPP.Controllers
{
    public class HomeController: Controller
    {
        //view methods creation
        public ViewResult  Index()//first view
        {
            var obj = new {id =1, Name ="Kashama"};
            return View(obj);
        }
        public ViewResult AboutUs()//second view
        {
           
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
        public ViewResult Innovations()
        {
            return View();
            
        }
    }
}