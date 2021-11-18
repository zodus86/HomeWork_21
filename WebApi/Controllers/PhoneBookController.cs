using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<IPhoneBook> Get()
        {
            return Repository.GetPhoneBooks();
        }

        [HttpGet]
        [Route("GetPhoneBookByID/{id}")]
        public IPhoneBook GetPhoneBookByID (int id)
        {
            return Repository.GetPhoneBookById(id);
        }

        [HttpGet]
        [Route("GetRange/{index}/count/{count}")]
        public IEnumerable<IPhoneBook> Get(int index, int count)
        {
            return Repository.GetPhoneBooksRange(index, count);
        }
       
        [HttpPost]
        public void Post([FromBody] PhoneBook value)
        {
            Repository.Add(value);
        }
    }
}
