using HomeWork_21.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_21.Data
{
    public interface IAllPhoneBooks
    {
        IEnumerable<PhoneBook> phoneBooks { get; }

        PhoneBook GetPhoneBook(int phoneBookID);

        void Add(PhoneBook phoneBook);

        void Delete(int index);

        void SetPB(PhoneBook phoneBook);
    }
}
