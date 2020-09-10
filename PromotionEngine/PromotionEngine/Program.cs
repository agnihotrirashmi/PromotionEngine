using PromotionEngine.Models;
using PromotionEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            IPromotionService service = new PromotionService();

            IEnumerable<Cart> cart = service.GetCart();

            foreach (var item in cart)
            {
                var productCount = item.CartProducts.GroupBy(x => x.ProductSKU)
                             .Select(y => new { ProductSKU = y.Key, Count = y.Count() });
                Console.WriteLine("Shopping cart contains below product :");
                Console.WriteLine("Product" + "\t" + "Count");
                foreach (var product in productCount)
                {
                    Console.WriteLine(product.ProductSKU + "\t" + product.Count);
                }
                decimal totalCartPrice = item.CartProducts.Sum(x => x.Price);

                decimal cartOfferPrice = service.GetCartOfferValue(item);

                Console.WriteLine("\nCart Original Price :" + totalCartPrice);
                Console.WriteLine("\nCart Offer Price :" + cartOfferPrice);
            }
            Console.ReadLine();
        }
    }
}
