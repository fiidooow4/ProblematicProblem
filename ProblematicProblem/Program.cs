using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        static Random rng = new Random();
        static bool cont = true;
        private static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            var userResponse = Console.ReadLine().ToLower();

            if (userResponse != "yes")
            {
                Console.WriteLine("GoodBye!");
                return;
            }
            Console.WriteLine(); 
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");

            // Correct way to parse the user's age as an integer
            int userAge;
            while (!int.TryParse(Console.ReadLine(), out userAge))
            {
                Console.Write("Invalid input. Please enter a valid age: ");
            }

            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            userResponse = Console.ReadLine().ToLower();

            if (userResponse == "sure" | userResponse == "yes")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }



            }
            {

                
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                userResponse = Console.ReadLine().ToLower();
                Console.WriteLine();

                while (userResponse != "no")
                {
                    
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);

                    

                    Console.WriteLine();
                    Console.Write("Would you like to add more? yes/no: ");
                    userResponse = Console.ReadLine().ToLower();
                }

                bool addToList = false;

                if (userResponse.ToLower() == "yes")
                {
                    addToList = true;

                    
                }
                else if (userResponse.ToLower() != "no")
                {
                    Console.WriteLine("Invalid input. Assuming 'no' for adding activities.");
                }

                Console.WriteLine();

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    userResponse = Console.ReadLine().ToLower();
                    activities.Add(userResponse);

                    Console.Write("Current activities: ");
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.Write("Would you like to add more? yes/no: ");
                    string userInput = Console.ReadLine();

                    addToList = userInput.ToLower() == "yes";
                }

            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge > 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {randomActivity}, your random activity is: {userName}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                 userResponse = Console.ReadLine().ToLower();

                if (userResponse == "redo")
                {
                    Console.WriteLine("Redoing the activity...");
                    continue;  // Skips the rest of the loop and starts over
                }
                else if (userResponse != "keep")
                {
                    cont = false;
                    Console.WriteLine("Goodbye!");
                }
            }

        }
    }
}