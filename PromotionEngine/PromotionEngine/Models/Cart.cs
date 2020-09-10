using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class CartProduct
    {
        public string ProductSKU { get; set; }
        public decimal Price { get; set; }

        public CartProduct(string SKU)
        {
            ProductSKU = SKU;
            //Assigning price to product according to SKU
            switch (SKU)
            {
                case "A":
                    Price = 50;
                    break;
                case "B":
                    Price = 30;
                    break;
                case "C":
                    Price = 20;
                    break;
                case "D":
                    Price = 15;
                    break;

                default:
                    Price = 0;
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
            CartProducts = cartProducts;
        }
    }
}
