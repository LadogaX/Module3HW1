using System;
using Module3HW1.Models;

namespace Module3HW1.Helpers
{
    public class CustomListHelpers
    {
        public static void Display(CustomList<Product> customList, string caption = "")
        {
            Console.WriteLine(caption);
            foreach (Product item in customList)
            {
                if (item != null)
                {
                    Console.WriteLine($"id {item.Id}  {item.Name}");
                }
            }

            Console.WriteLine();
        }
    }
}