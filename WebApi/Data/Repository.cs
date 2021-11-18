using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class Repository
    {
        static List<IPhoneBook> data;

        static Repository()
        {
            data = new List<IPhoneBook>()
            {
                new PhoneBook(){Id= 0, FirstName = "Qw", LastName = "Qe", MiddleName = "Qr", Email="Em@mail1.ru" , TelephonNumber = 8800001, Submit = "q"},
                new PhoneBook(){Id= 1, FirstName = "Ww", LastName = "We", MiddleName = "Wr", Email="Em@mail2.ru" , TelephonNumber = 8800002, Submit = "w"},
                new PhoneBook(){Id= 2, FirstName = "Ew", LastName = "Ee", MiddleName = "Er", Email="Em@mail3.ru" , TelephonNumber = 8800003, Submit = "e"},
                new PhoneBook(){Id= 3, FirstName = "Rw", LastName = "Re", MiddleName = "Rr", Email="Em@mail4.ru" , TelephonNumber = 8800004, Submit = "r"}
            };
        }

        public static void Add(IPhoneBook phoneBook)
        {
            data.Add(phoneBook);
        }

        public static IEnumerable<IPhoneBook> GetPhoneBooks() => data;

        public static IPhoneBook GetPhoneBookById(int id) => id >= 0 && id < data.Count ? data[id] : NullPhoneBook.Create();

        public static IEnumerable<IPhoneBook> GetPhoneBooksRange(int index, int count) => data.Where(x => x.Id >= index && x.Id < index + count);
    }

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

        public void Delete(int index)
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
