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
        public static int caseVariable;

        static void Main(string[] args)
        {
            while (true)
            {
                OptionsCreateOrFeedback();
                Console.WriteLine("---------------------------------------------------------------------------------");
                if (caseVariable == 1)
                {
                    Rating();
                    Console.WriteLine("---------------------------------------------------------------------------------");
                    Location();
                    Console.WriteLine("---------------------------------------------------------------------------------");
                    Description();
                    Console.WriteLine("---------------------------------------------------------------------------------");
                    Gender();
                    Console.WriteLine("---------------------------------------------------------------------------------");
                    Age();
                    Console.WriteLine("---------------------------------------------------------------------------------");

                    //Console.WriteLine("Hit enter to close session");
                    //Console.ReadLine();
                    //Client.Close();
                }
                else if (caseVariable == 2)
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
                    Console.WriteLine("---------------------------------------------------------------------------------");

                    //Console.WriteLine("Hit enter to close session");
                    //Console.ReadLine();
                    //Client.Close();
                }
                else
                {
                    Console.WriteLine("ERROR, contact +42 5125123952");
                }
                //Client.Close();
            }
            //Console.WriteLine("Hit enter to close session");
            //Console.ReadLine();
            //Client.Close();
        }

        /// <summary>
        /// Gets all the available cars based on type and car typed in CW.
        /// </summary>
        private static void OptionsCreateOrFeedback()
        {
            Console.WriteLine("Car Rental");
            Console.WriteLine("You have two choice:");
            Console.WriteLine("Type R to give review");
            Console.WriteLine("Type C to create a new booking");
            var inputCar = Console.ReadLine();
            Console.WriteLine($" [x] your choice were: {inputCar}");
            var responseOption = Client.Call(inputCar);

            if (responseOption == "R")
            {
                caseVariable = 1;
                Console.WriteLine("Create review flow");
            }
            else
            {
                caseVariable = 2;
                Console.WriteLine("Create booking flow");
            }
        }

        private static void Rating()
        {
            Console.WriteLine("Du skal nu til lave et review");
            Console.WriteLine("Hvor man sjerner vil du give servicen? 1-5 :");
            var inputRating = "R" + " " + Console.ReadLine(); 
            Console.WriteLine($" [x] your choice to give: {inputRating} stars");
            var responseRating = Client.Call(inputRating);

            Console.WriteLine($" [.] response: '{responseRating}'");
        }

        private static void Location()
        {
            Console.WriteLine("You now have you type your location e.g. kildevej 19. ");
            var inputLocation = Console.ReadLine();
            Console.WriteLine($" [x] your location is: {inputLocation}");
            var responseLocation = Client.Call("R" + " " + inputLocation);

            Console.WriteLine($" [.] Got: '{responseLocation}'");
        }

        private static void Description()
        {
            Console.WriteLine("Please enter a description, and press enter when you're done");
            var inputDescription = Console.ReadLine();
            Console.WriteLine($" [x] your description is: {inputDescription}");
            var responseDescription = Client.Call("R" + " " + inputDescription);

            Console.WriteLine($" [.] Got: '{responseDescription}'");
        }

        private static void Gender()
        {
            Console.WriteLine("Please enter your gender");
            var inputGender = Console.ReadLine();
            Console.WriteLine($" [x] your gender is: {inputGender}");
            var responseGender = Client.Call("R" + " " + inputGender);

            Console.WriteLine($" [.] Got: '{inputGender}'");
        }

        private static void Age()
        {
            Console.WriteLine("Please enter your age");
            var inputAge = Console.ReadLine();
            Console.WriteLine($" [x] your age is: {inputAge}");
            var responseAge = Client.Call("R" + " " + inputAge);

            Console.WriteLine($" [.] Got: '{responseAge}'");
        }

        /// <summary>
        /// Gets all the available cars based on type and car typed in CW.
        /// </summary>
        private static void AvailableCars()
        {
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
