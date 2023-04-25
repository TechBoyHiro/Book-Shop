using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Models;
using Project1.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Project1.Controllers
{
    public class BookController : Controller
    {
        private readonly STDbContext _context;

        public BookController(STDbContext context)
        {
            _context = context;
        }
        public void CreateBooks()
        {
            Book b1 = new Book();
            b1.Description = "This is b1 Description";
            b1.Name = "B1";
            b1.Price = 25;
            _context.Books.Add(b1);
            _context.SaveChanges();
            Book b2 = new Book();
            b2.Description = "This is b2 Description";
            b2.Name = "B2";
            b2.Price = 25;
            _context.Books.Add(b2);
            _context.SaveChanges();
            Book b3 = new Book();
            b3.Description = "This is b3 Description";
            b3.Name = "B3";
            b3.Price = 25;
            _context.Books.Add(b3);
            _context.SaveChanges();
            Book b4 = new Book();
            b4.Description = "This is b4 Description";
            b4.Name = "B4";
            b4.Price = 25;
            _context.Books.Add(b4);
            _context.SaveChanges();
            Book b5 = new Book();
            b5.Description = "This is b5 Description";
            b5.Name = "B5";
            b5.Price = 25;
            _context.Books.Add(b5);
            _context.SaveChanges();
            Book b6 = new Book();
            b6.Description = "This is b6 Description";
            b6.Name = "B6";
            b6.Price = 25;
            _context.Books.Add(b6);
            _context.SaveChanges();
        }
        [BOSSAllowedFilter]
        public void Entrance()
        {

        }
        public ActionResult Books()
        {
            //CreateBooks();
            ViewBag.books = _context.Books;
            return View();
        }

        public ActionResult SearchBooks(string search)
        {
            var Books = from b in _context.Books
                        select b;
            if(!String.IsNullOrEmpty(search))
            {
                Books = _context.Books.Where(m => m.Name.Contains(search));
            }
            if(Books.ToList().ToArray().Length != 0)
            {
                ViewBag.searchR = true;
            }
            else
            {
                ViewBag.searchR = false;
            }

            return View(Books.ToList());
        }
    }
}
