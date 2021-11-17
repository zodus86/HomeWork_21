using HomeWork_21.Data;
using HomeWork_21.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_21.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IAllPhoneBooks _allPhoneBooks;
        public HomeController(IAllPhoneBooks iallPhoneBooks)
        {
            _allPhoneBooks = iallPhoneBooks;
        }

       
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        //[Authorize]
        public IActionResult ViewAll()
        {
            ViewBag.PhoneBooks = _allPhoneBooks.phoneBooks; 
            return View();
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Edit(int id)
        {
            return View(_allPhoneBooks.GetPhoneBook(id));
        }

        [HttpGet]
        //[Authorize]
        public IActionResult AddContact()
        {
            return View(new PhoneBook());
        }

        [HttpPost]
        //[Authorize]
        public IActionResult AddContactAction(PhoneBook model)
        {
            _allPhoneBooks.Add(new PhoneBook()
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                TelephonNumber = model.TelephonNumber,
                Email = model.Email,
                Submit = model.Submit
            });
            return Redirect("~/Home/ViewAll");
        }


        [HttpGet]
        //[Authorize]
        public IActionResult Details(int id)
        {
              return View(_allPhoneBooks.GetPhoneBook(id)); 
        }

        //[Authorize]
        public IActionResult Delete(int id)
        {
            _allPhoneBooks.Delete(id);
            return Redirect("~/Home/ViewAll");
        }



        [HttpPost]
        //[Authorize]
        public IActionResult PushEdit(PhoneBook model)
        {
            _allPhoneBooks.SetPB(model);
            return Redirect("~/Home/ViewAll");
        }

    }
}
