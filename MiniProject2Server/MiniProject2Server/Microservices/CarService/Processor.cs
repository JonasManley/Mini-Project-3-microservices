using MiniProject2Server.ApiHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject2Server.Microservices.CarService
{
    public class Processor
    {
        private static List<Car> carList = carList = new List<Car>();

        private static string _test;

        public async Task getBookings()
        {
            using (HttpResponseMessage responseMessage
                = await Apihelper.ApiClient.GetAsync("https://sirestreview20191211094544.azurewebsites.net/api/values"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJSON = await responseMessage.Content.ReadAsStringAsync();
                    carList = JsonConvert.DeserializeObject<List<Car>>(responseJSON);
                }
            }
        }

        public List<Car> CarList
        {
            get { return carList; }
            set { carList = value; }
        }

        public string Test
        {
            get { return _test; }
            set { _test = value; }
        }

    }
}
