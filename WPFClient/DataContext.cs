using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient
{
    class DataContext
    {
        private HttpClient httpClient { get; set; }

        public DataContext()
        {
            httpClient = new HttpClient();
        }



        public IEnumerable<PhoneBook> GetPhoneBooks()
        {
            string url = @"https://localhost:44323/api/DB";

            string json = httpClient.GetStringAsync(url).Result;
            Console.WriteLine(json);
            return JsonConvert.DeserializeObject<IEnumerable<PhoneBook>>(json);

        }



        public void Add(PhoneBook phoneBook)
        {
           //   curl - X POST "https://localhost:44323/api/DB" - H  "accept: */*" - H  "Content-Type: application/json" - d
           //   "{\"id\":0,\"lastName\":\"string\",\"firstName\":\"string\",\"middleName\":\"string\",
           //   \"telephonNumber\":0,\"email\":\"string\",\"submit\":\"string\"}"
           
            string url = @"https://localhost:44323/api/DB";

            var result = httpClient.PostAsync(
                url,
                new StringContent(JsonConvert.SerializeObject(phoneBook), Encoding.UTF8,
                "application/json")
                ).Result;

        }

    }
}
