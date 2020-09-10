using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class CartProduct
    {
        public string ProductSKU { get; set; }
        public decimal Price { get; set; }

        public CartProduct(string SKU)
        {
            this.ProductSKU = SKU;
            //Assigning price to product according to SKU
            switch (SKU)
            {
                case "A":
                    this.Price = 50;
                    break;
                case "B":
                    this.Price = 30;
                    break;
                case "C":
                    this.Price = 20;
                    break;
                case "D":
                    this.Price = 15;
                    break;

                default:
                    this.Price = 0;
                    break;
            }
        }
    }

    public class Cart
    {
        //Cart will contain multiple card product
        public List<CartProduct> CartProducts { get; set; }
        public Cart(List<CartProduct> cartProducts)
        {
            this.CartProducts = cartProducts;
        }
    }
}
