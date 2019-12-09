using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject2Client
{

    class Program
    {
        public static Client Client = new Client();

        static void Main(string[] args)
        {
            AvailableCars();     
            Console.WriteLine("---------------------------------------------------------------------------------");
            
            var responseColor = Client.Call(" ");
            Console.WriteLine($" [.] Colors available: {responseColor}");

            Console.WriteLine("---------------------------------------------------------------------------------");
            ColoredCars();
            Console.WriteLine("---------------------------------------------------------------------------------");
            RentCar();
            Console.WriteLine("---------------------------------------------------------------------------------");

            Console.WriteLine("Please provide us with your full name and driverlicens");
            var inputNameAndLicense = Console.ReadLine();
            Console.WriteLine($" [.] informations: {inputNameAndLicense}");
            var responseNameAndLicense = Client.Call(inputNameAndLicense);
            Console.WriteLine("Agregation: " + responseNameAndLicense);




            Client.Close();
            Console.ReadLine();
        }


        /// <summary>
        /// Gets all the available cars based on type and car typed in CW.
        /// </summary>
        private static void AvailableCars()
        {
            Console.WriteLine("Car Rental");
            Console.WriteLine("Type what car you want and a date to see availability, like: Audi 22/01/1996");
            var inputCar = Console.ReadLine();
            Console.WriteLine($" [x] searching for: {inputCar}");
            var responseAvailable = Client.Call(inputCar);

            if (responseAvailable == "bil blev ikke fundet")
            {
                Console.WriteLine($" [.] Got: '{responseAvailable}'");
                AvailableCars();
            }
            Console.WriteLine($" [.] Got: '{responseAvailable}'");
        }

        /// <summary>
        /// Based on the color typed in the CW, it can then give you all the cars matching that color. 
        /// </summary>
        /// <param name="inputColor">The choosen car color e.g. "black" "red"</param>
        private static void ColoredCars()
        {
            Console.WriteLine("Write the name of the color you want:");
            var inputColor = Console.ReadLine();
            Console.WriteLine($" [x] Collection the car(s) with the color: {inputColor}");
            var responeCarColor = Client.Call(inputColor);  
            if(responeCarColor == "Please type a color to preceed")
            {
                Console.WriteLine($" [.] Got: {responeCarColor}");
                ColoredCars();
            }
            else if (responeCarColor == "Spelling ERORR, please try agian")
            {
                Console.WriteLine($" [.] Got: {responeCarColor}");
                ColoredCars();
            }
            else
            {
                string[] cars = responeCarColor.Split('-');
                Array.Resize(ref cars, cars.Length-1);
                int counter = 1;
                foreach (var car in cars)
                {
                    Console.WriteLine($"{counter}. {car}");
                    counter++;
                }
            }
        }

        /// <summary>
        /// Based on the number the client types, selecting that specific car.
        /// </summary>
        private static void RentCar()
        {
            Console.WriteLine("Write the number for the car you want to rent");
            string inputRentCar = Console.ReadLine();
            Console.WriteLine($" [x] Car you want to rent is : {inputRentCar}");
            var responeRentCar = Client.Call(inputRentCar);

            if (responeRentCar == "The number is not valid, try with a differnt one")
            {
                Console.WriteLine(responeRentCar);
                RentCar();
            }
            else
            {
                Console.WriteLine(responeRentCar);
            }

        }
    }
}
