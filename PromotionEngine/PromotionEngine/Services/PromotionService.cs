using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PromotionEngine.Services
{
    /// <summary>
    /// Promotion Service
    /// </summary>
    public class PromotionService : IPromotionService
    {
        /// <summary>
        /// Cart Value
        /// </summary>
        public decimal CartValue { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cartValue"></param>
        public PromotionService(decimal cartValue = 0)
        {
            CartValue = cartValue;
        }

        /// <summary>
        /// Create a cart having multiple items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cart> GetCart()
        {
            List<Cart> cartList = new List<Cart>
            { 
                //TODO take it from user
                //Scenario C
                new Cart(new List<CartProduct>()
                {
                    new CartProduct("A"), new CartProduct("A"),
                    new CartProduct("A"), new CartProduct("B"),
                    new CartProduct("B"),new CartProduct("B"),
                    new CartProduct("B"),new CartProduct("B"),
                    new CartProduct("C"), new CartProduct("D")
                })
            };
            return cartList;
        }

        /// <summary>
        /// Get cart price after adding promotion
        /// Case : only one promotion at a time 
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public decimal GetCartOfferValue(Cart cart)
        {
            try
            {
                IEnumerable<ActivePromotions> PromotionList = GetActivePromotions();
                List<decimal> cartOfferPrice = new List<decimal>();
                if (PromotionList != null && PromotionList.Count() > 0)
                {
                    foreach (var item in PromotionList)
                    {
                        decimal cartPrice = CalculatePrmotionNProductOfSKU(cart, item);
                        cartOfferPrice.Add(cartPrice);
                    }
                }
                else
                    throw new Exception("Empty PromotionList");

                if (cartOfferPrice.Count() < 0)
                    this.CartValue = cartOfferPrice.Sum();
                else
                    this.CartValue = cartOfferPrice.Sum();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString(CultureInfo.InvariantCulture));
                throw;
            }

            return this.CartValue;
        }

        /// <summary>
        /// Calculate Prmotion Product Of SKU
        /// </summary>
        /// <param name="cart">The cart</param>
        /// <param name="activePromotions">The Promotions</param>
        /// <returns></returns>
        private decimal CalculatePrmotionNProductOfSKU(Cart cart, ActivePromotions activePromotions)
        {
            decimal offerPrice = 0;

            switch (activePromotions.PromotionCategory)
            {
                case PromotionCatgories.NProductOfSKU:
                    string sku = activePromotions.PromotionProductSKU;
                    int numberOfItem = activePromotions.NumberOfPromotionProductSKU;
                    int productCount = cart.CartProducts.Where(x => x.ProductSKU == sku).Count();
                    //get price of product
                    offerPrice = productCount / numberOfItem * activePromotions.PromotionPrice + (productCount % numberOfItem * GetProductPrice(sku));
                    break;

                case PromotionCatgories.ComboProduct:
                    string skuOne, skuTwo;
                    skuOne = activePromotions.PromotionProductSKU.Split(',')[0];
                    skuTwo = activePromotions.PromotionProductSKU.Split(',')[1];
                    int skuOneCount = cart.CartProducts.Where(x => x.ProductSKU == skuOne).Count();
                    int skuTwoCount = cart.CartProducts.Where(x => x.ProductSKU == skuOne).Count();
                    if (skuOneCount >= activePromotions.NumberOfPromotionProductSKU && skuTwoCount >= activePromotions.NumberOfPromotionProductSKU)
                    {
                        if (skuOneCount >= skuTwoCount)
                        {
                            offerPrice = activePromotions.PromotionPrice * skuTwoCount + ((skuOneCount - skuTwoCount) * GetProductPrice(skuOne));
                        }
                        else
                        {
                            offerPrice = activePromotions.PromotionPrice * skuOneCount + ((skuTwoCount - skuOneCount) * GetProductPrice(skuTwo));
                        }
                    }
                    else
                    {
                        offerPrice = cart.CartProducts.Where(x => x.ProductSKU == skuOne).Count() * GetProductPrice(skuOne) +
                            cart.CartProducts.Where(x => x.ProductSKU == skuTwo).Count() * GetProductPrice(skuTwo);
                    }
                    break;
            }

            return offerPrice;
        }

        /// <summary>
        /// Get promotions that are active in the system, as per provided
        /// </summary>
        /// <returns></returns>
        private static List<ActivePromotions> GetActivePromotions()
        {
            //TODO take it from user
            List<ActivePromotions> promotions = new List<ActivePromotions>()
            {
                new ActivePromotions(1,PromotionCatgories.NProductOfSKU, ProductSKU.A,3, 130),
                new ActivePromotions(2,PromotionCatgories.NProductOfSKU, ProductSKU.B,2, 45),
                new ActivePromotions(3,PromotionCatgories.ComboProduct, ProductSKU.CD,1, 30)
            };
            return promotions;
        }

        private static decimal GetProductPrice(string sku)
        {
            CartProduct product = new CartProduct(sku);
            return product.Price;
        }
    }
}
