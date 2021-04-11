using System;
using System.Collections.Generic;


namespace collection_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Three Basic Arrays
            // int[] numArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            String[] names = { "Tim", "Martin", "Nikki", "Sara" };
            // Boolean[] trueFalse = { true, false, true, false, true, false, true, false, true, false };

            //List of Flavors
            List<string> flavors = new List<string>();
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Butter Pecan");
            flavors.Add("Moose Tracks");
            flavors.Add("Mint Chocolate Chip");
            flavors.Add("Neopolitan");
            flavors.Add("Birthday Cake");
            flavors.Add("Rocky Road");
            // flavors.Remove("Butter Pecan");
            // Console.WriteLine($"We currently have {flavors.Count} flavors of ice cream!");
            // Console.WriteLine(flavors[2]);
            // Console.WriteLine($"We currently have {flavors.Count} flavors of ice cream!");
            for (int i = 0; i < flavors.Count; i++)
            {
                Console.WriteLine($"I have {flavors[i]}");
            }

            // User Info Dictionary
            Dictionary<string, string> user = new Dictionary<string, string>();
            {
                for (int i = 0; i < 4; i++)
                {
                    user.Add(names[i], flavors[i]);
                }
                foreach (var entry in user)
                {
                    Console.WriteLine(entry.Key + " " + entry.Value);
                }
            }
        }
    }
}
