using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Services
{
    public class ActivePromotions
    {
        public int PromotionId { get; set; }
        //Type of promotion
        public string PromotionCategory { get; set; }

        //PromotionProduct will contain SKU and number of Item
        public Dictionary<string, int> PromotionProduct { get; set; }
        //Decided prmotion price
        public decimal PromotionPrice { get; set; }
        public ActivePromotions(int id, string category, Dictionary<string, int> promoProduct, decimal price)
        {
            this.PromotionId = id;
            this.PromotionCategory = category;
            this.PromotionProduct = promoProduct;
            this.PromotionPrice = price;
        }
    }
}
