using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Controllers
{
    [Authorize]
    public class Home : Controller
    {
        private readonly STDbContext _context;

        public Home(STDbContext context)
        {
            _context = context;
        }

        public ActionResult index()
        {
            ViewBag.search = false;
            return View();
        }
        [AllowAnonymous]
        [Route("/Home/Error/{message}")]
        public ActionResult Error(string message)
        {
            ViewBag.errormessage = message;
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }

        [HttpGet("Home/Find/{search}")]
        public async Task<JsonResult> Find(string search)
        {
            //Book b1 = new Book();
            //b1.Name = "first-book";
            //b1.Description = "Test For Ajax Request";
            //b1.Price = 30;
            //Book b2 = new Book();
            //b2.Name = "second-book";
            //b2.Description = "(second)Test For Ajax Request";
            //b2.Price = 60;
            //var books = new List<Book>();
            //books.Add(b1);
            //books.Add(b2);
            var books = from m in _context.Books
                select m;
            if(!String.IsNullOrEmpty(search))
            {
                books = _context.Books.Where(m => m.Name.Contains(search));
            }
            return Json(await books.ToListAsync());
        }
    }
}
