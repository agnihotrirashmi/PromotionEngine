using PromotionEngine.Models;
using PromotionEngine.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PromotionTestProject
{
    public class PromotionUnitTest
    {
        IPromotionService service = new PromotionService();

        [Fact]
        public void ScenarioA()
        {
            //Create cart
            //Negative test
            Cart cart = new Cart(new List<CartProduct>()
                {
                    new CartProduct("A"),new CartProduct("B"),
                    new CartProduct("C")
                });
            decimal expectedValue = 110;
            decimal cartOfferPrice = service.GetCartOfferValue(cart);
            Assert.Equal(expectedValue, cartOfferPrice);
        }

        [Fact]
        public void ScenarioB()
        {
            //Create cart
            Cart cart = new Cart(new List<CartProduct>()
                {
                    new CartProduct("A"), new CartProduct("A"),
                    new CartProduct("A"), new CartProduct("A"),
                    new CartProduct("A"), new CartProduct("B"),
                    new CartProduct("B"),new CartProduct("B"),
                    new CartProduct("B"),new CartProduct("B"),
                    new CartProduct("C")
                });
            decimal expectedValue = 370;
            decimal cartOfferPrice = service.GetCartOfferValue(cart);
            Assert.Equal(expectedValue, cartOfferPrice);
        }
    }
}
