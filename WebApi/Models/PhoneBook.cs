using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PhoneBook : IPhoneBook
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public decimal TelephonNumber { get; set; }
        public string Email { get; set; }
        public string Submit { get; set; }
    }

    public interface IPhoneBook
    {
         int Id { get; set; }
         string LastName { get; set; }
         string FirstName { get; set; }
         string MiddleName { get; set; }
         decimal TelephonNumber { get; set; }
         string Email { get; set; }
         string Submit { get; set; }
    }
    public class NullPhoneBook : IPhoneBook
    {
        private NullPhoneBook()
        {
            Id = 0;
            LastName = "пусто";
            FirstName = "пусто";
            MiddleName = "пусто";
            TelephonNumber = 0;
            Email = "пусто";
            Submit = "пусто";
        }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public decimal TelephonNumber { get; set; }
        public string Email { get; set; }
        public string Submit { get; set; }

        static public NullPhoneBook Create()
        {
            return new NullPhoneBook();
        }
    }
}
