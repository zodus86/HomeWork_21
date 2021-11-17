using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeWork_21.Models
{
    public class PhoneBook
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required, DataType(DataType.PhoneNumber)]
        public decimal TelephonNumber { get; set; }

        public string Email { get; set; }
        public string Submit { get; set; }
    }
}
