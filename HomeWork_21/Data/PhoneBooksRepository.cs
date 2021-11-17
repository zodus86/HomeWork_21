using HomeWork_21.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_21.Data
{
    public class PhoneBooksRepository : IAllPhoneBooks
    {

        private readonly DataContext dataContext;

        public PhoneBooksRepository(DataContext dataContext)
        {
                this.dataContext = dataContext;
        }

        public void Add(PhoneBook phoneBook)
        {
            dataContext.PhoneBooks.Add(phoneBook);
            dataContext.SaveChangesAsync();
        }

        public void Delete (int index)
        {
            var vp = dataContext.PhoneBooks.Where(el => el.Id == index);
            dataContext.PhoneBooks.RemoveRange(vp);
            dataContext.SaveChangesAsync();
        }
        public IEnumerable<PhoneBook> phoneBooks => dataContext.PhoneBooks; //.Include(c => c.FirstName);

       public PhoneBook GetPhoneBook(int phoneBookID) => dataContext.PhoneBooks.FirstOrDefault(p => p.Id == phoneBookID);


        public void SetPB(PhoneBook phoneBook)
        {

            dataContext.PhoneBooks.Update(phoneBook);
            dataContext.SaveChangesAsync();
        }
       
    }
}


