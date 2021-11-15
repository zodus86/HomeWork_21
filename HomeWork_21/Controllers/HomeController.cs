using HomeWork_21.Data;
using HomeWork_21.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_21.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewAll()
        {
            ViewBag.PhoneBooks = new DataContext().PhoneBooks;
            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GetDataFromViewField(string firstName, string lastName, string middleName, decimal telephonNumber, string email, string submit)
        {
            using (var db = new DataContext())
            {
                db.PhoneBooks.Add(
                    new PhoneBook()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        MiddleName = middleName,
                        TelephonNumber = telephonNumber,
                        Email = email,
                        Submit = submit
                    });

                db.SaveChanges();
            }
            return Redirect("~/Home/ViewAll");
        }
        
        [HttpGet]
        public IActionResult Details(int id)
        {
            
            using (var db = new DataContext())
            {
                return View(db.PhoneBooks.Find(id));
            }
                
        }

        //[HttpDelete]
        public IActionResult Delete (int id)
        {
            using (var db = new DataContext())
            {
                var vp = db.PhoneBooks.Where(el => el.Id == id);
                db.PhoneBooks.RemoveRange(vp);
                db.SaveChanges();
            }


            return Redirect("~/Home/ViewAll");
        }
    }
}
