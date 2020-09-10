namespace PromotionEngine.Services
{
    /// <summary>
    /// Active Promotions
    /// </summary>
    public class ActivePromotions
    {
        public int PromotionId { get; set; }
        //Type of promotion
        public string PromotionCategory { get; set; }

        //PromotionProduct will contain SKU and number of Item
        public string PromotionProductSKU { get; set; }
        public int NumberOfPromotionProductSKU { get; set; }
        //Decided prmotion price
        public decimal PromotionPrice { get; set; }
        public ActivePromotions(int id, string category, string promoProductSKU, int numberOfPromotionProductSKU, decimal price)
        {
            PromotionId = id;
            PromotionCategory = category;
            PromotionProductSKU = promoProductSKU;
            NumberOfPromotionProductSKU = numberOfPromotionProductSKU;
            PromotionPrice = price;
        }
    }
}
