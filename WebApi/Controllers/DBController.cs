using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBController : ControllerBase
    {
        private readonly IAllPhoneBooks _allPhoneBooks;

        public DBController(IAllPhoneBooks iallPhoneBooks)
        {
            _allPhoneBooks = iallPhoneBooks;
        }


        // GET: api/DB
        [HttpGet]
        public IEnumerable<PhoneBook> GetPhoneBooks()
        {
            return _allPhoneBooks.phoneBooks.ToList();
        }

        // GET: api/DB/5
        [HttpGet("{id}")]
        public PhoneBook GetPhoneBook(int id)
        {
            Task<PhoneBook> task = new Task<PhoneBook>(() => _allPhoneBooks.GetPhoneBook(id));
            task.Start();

            var phoneBook = task.Result;

            return phoneBook;
        }


        // POST: api/DB
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostPhoneBook([FromBody] PhoneBook value)
        {
            _allPhoneBooks.Add(value);
        }

        // DELETE: api/DB/5
        [HttpDelete("{id}")]
        public void DeletePhoneBook(int id)
        {
            _allPhoneBooks.Delete(id);
        }

    }
}
