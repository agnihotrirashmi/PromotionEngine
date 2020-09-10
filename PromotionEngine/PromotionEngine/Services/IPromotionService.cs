using PromotionEngine.Models;
using System.Collections.Generic;

namespace PromotionEngine.Services
{
    public interface IPromotionService
    {
        /// <summary>
        /// Create a cart having multiple items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cart> GetCart();

        /// <summary>
        /// Get cart price after adding promotion
        /// Case : only one promotion at a time 
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public decimal GetCartOfferValue(Cart cart);
    }
}