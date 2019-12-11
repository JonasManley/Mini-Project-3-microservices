using ShowReviews.ApiHelper;
using ShowReviews.Microservice;
using ShowReviews.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShowReviews
{
    class Program
    {

        static async Task Main(string[] args)
        {
            List<Review> reviews = new List<Review>();
            Apihelper.InitializeClient();
            Processor processor = new Processor();
            await processor.getReviews();
            int averageRating = 0;

            foreach (var item in processor.ReviewList)
            {
                averageRating = averageRating + item.Rating;
                Console.WriteLine($"--------------------------");
                Console.WriteLine($"Review rating {item.Rating}");
                Console.WriteLine($"Review description {item.Description}");
                Console.WriteLine($"The person who reviewed has the age {item.Age} and gender {item.Gender}");
                Console.WriteLine($"--------------------------");
                Thread.Sleep(500);
            }
            Console.WriteLine($"Average rating is {averageRating / processor.ReviewList.Count}");
            Console.ReadLine();
        }


    }
}
