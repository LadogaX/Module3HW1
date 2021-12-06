using System;
using System.Collections;
using Module3HW1.Models;
using Module3HW1.Services.Comparers;
using Module3HW1.Helpers;

namespace Module3HW1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customList = new CustomList<int>();
            var customList2 = new CustomList<Product>();

            customList2.Add(new Product { Id = 1, Name = "Potato" });
            customList2.Add(new Product { Id = 2, Name = "Tomato" });

            customList2.AddRange(new Product[]
            {
                new Product { Id = 3, Name = "Carrot" },
                new Product { Id = 4, Name = "Garlic" }
            });

            customList2.AddRange(customList2);
            CustomListHelpers.Display(customList2, "Adding in collection");

            customList2.Sort(new ProductComparer());
            CustomListHelpers.Display(customList2, "Sorting:");

            var result = customList2.RemoveAt(3);

            result = customList2.Remove(p => p.Name.CompareTo("Tomato") == 0);
            customList2.Trim();

            CustomListHelpers.Display(customList2, "State after remove:");
        }
}
}
