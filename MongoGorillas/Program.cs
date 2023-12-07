using System;
using System.Collections.Generic;
using MongoGorillas.Managers;
using MongoGorillas.Types;

namespace MongoGorillas
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyword = "";

            // Initialize our database provider.
            Setup.Initialize();

            while (true)
            {
                // Search for Gorillas.
                List<Gorilla> Gorillas = GorillaManager.Find(keyword);

                // Display the Gorillas.
                DisplayGorillas(Gorillas);

                // Get input from the user.
                Console.Write("Enter text to search by or Q to quit:>");
                keyword = Console.ReadLine();

                // Check the input.
                if (keyword.ToUpper() == "Q")
                    break;
            }

            Setup.Close();
        }

        #region Helpers

        private static List<Gorilla> DisplayGorillas(List<Gorilla> Gorillas)
        {
            Console.WriteLine(String.Format("{0,3} | {1,-17} | {2,3} | {3,4} | {4,3} | {5,10} | {6,8} | {7,5}", "Id", "Name", "Age", "Gold", "HP", "Breath", "Born", "Realm"));
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

            int count = 0;
            foreach (Gorilla Gorilla in Gorillas)
            {
                Console.WriteLine(String.Format("{0, 3} | {1}", ++count, Gorilla));
            }

            return Gorillas;
        }

        #endregion
    }
}