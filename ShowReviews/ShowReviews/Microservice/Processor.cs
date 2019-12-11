using Newtonsoft.Json;
using ShowReviews.ApiHelper;
using ShowReviews.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShowReviews.Microservice
{
    public class Processor
    {
        private static List<Review> reviewList = new List<Review>();
        public async Task getReviews()
        {
            using (HttpResponseMessage responseMessage
                = await Apihelper.ApiClient.GetAsync("https://sirestreview20191212123916.azurewebsites.net/api/values"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJSON = await responseMessage.Content.ReadAsStringAsync();
                    reviewList = JsonConvert.DeserializeObject<List<Review>>(responseJSON);
                }
            }
        }

        public List<Review> ReviewList
        {
            get { return reviewList; }
            set { reviewList = value; }
        }

    }
}
