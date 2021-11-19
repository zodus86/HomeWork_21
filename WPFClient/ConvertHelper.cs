using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient
{
    public static class ConvertHelper
    {
        public static ObservableCollection<PhoneBook> ToObservableCollection(this IEnumerable<PhoneBook> phonesBooks)
        {
            ObservableCollection<PhoneBook> newColletcion = new ObservableCollection<PhoneBook>();

            foreach (var item in phonesBooks)
            {
                newColletcion.Add(item);
            }
            return newColletcion;
        } 
    }
}
