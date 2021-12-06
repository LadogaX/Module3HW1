using System;
using System.Collections;
using System.Collections.Generic;
using Module3HW1.Models;

namespace Module3HW1.Services.Comparers
{
   public class ProductComparer : IComparer<Product>
    {
        public int Compare(Product product1, Product product2)
        {
            if (product1 == null || product2 == null)
            {
                return 1;
            }

            return string.Compare(product1.Name, product2.Name);
        }
    }
}