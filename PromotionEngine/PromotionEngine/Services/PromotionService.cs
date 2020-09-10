using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Services
{
    public class PromotionService
    {
        //Methods to get Orde, promotions and cart price

        /// <summary>
        /// Get promotions that are active in the system, as per provided
        /// </summary>
        /// <returns></returns>
        public List<ActivePromotions> GetActivePromotions()
        {
            Dictionary<string, int> SKUA = new Dictionary<string, int>
            {
                { "A", 3 }
            };
            Dictionary<string, int> SKUB = new Dictionary<string, int>
            {
                { "B", 2 }
            };
            Dictionary<string, int> SKUCD = new Dictionary<string, int>
            {
                { "C", 1 },
                { "D", 1 }
            };

            List<ActivePromotions> promotions = new List<ActivePromotions>()
            {
                new ActivePromotions(1,PromotionCatgories.NProductOfSKU, SKUA, 130),
                new ActivePromotions(2,PromotionCatgories.NProductOfSKU, SKUB, 45),
                new ActivePromotions(3,PromotionCatgories.ComboProduct, SKUCD, 30)
            };
            return promotions;
        }

        /// <summary>
        /// Create a cart having multiple items
        /// </summary>
        /// <returns></returns>
        public Cart GetCart()
        {
            Cart cart = new Cart(new List<CartProduct>() { new CartProduct("A"), new CartProduct("A"), new CartProduct("B"), new CartProduct("C"), new CartProduct("D") });
            return cart;
        }

        /// <summary>
        /// Get cart price after adding promotion
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public decimal GetCartValue(Cart cart)
        {
            decimal cartValue = 0;
            List<ActivePromotions> PromotionList = GetActivePromotions();
            return cartValue;
        }
    }
}
