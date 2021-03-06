﻿using System.Collections.Generic;
using Basket;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasketTest
{
    [TestClass]
    public class BasketOperation_CalculateBasketAmoutShould
    {
        public class BasketTest
        {
            public List<BasketLineArticle> BasketLineArticles { get; set; }
            public int ExpectedPrice { get; set; }
        }
        private static IEnumerable<object[]> Baskets
        {
            get
            {
                return new[]
                { new object[] {
                        new BasketOperation_CalculateBasketAmoutShould.BasketTest(){ BasketLineArticles = new List<BasketLineArticle>
                            {
                                new BasketLineArticle {Id = "1", Number = 12, Label = "Banana"},
                                new BasketLineArticle {Id = "2", Number = 1, Label = "Fridge electrolux"},
                                new BasketLineArticle {Id = "3", Number = 4, Label = "Chair"}
                            },
                            ExpectedPrice = 84868}
                        },
                        new object[] {
                            new BasketOperation_CalculateBasketAmoutShould.BasketTest(){ BasketLineArticles = new List<BasketLineArticle>
                                {
                                    new BasketLineArticle {Id = "1", Number = 20, Label = "Banana"},
                                    new BasketLineArticle {Id = "3", Number = 6, Label = "Chair"}
                                },
                                ExpectedPrice = 37520}
                        },
                    };
                }
            }
        [TestMethod]
        [DynamicData("Baskets")]
        public void ReturnCorrectAmoutGivenBasket(BasketOperation_CalculateBasketAmoutShould.BasketTest basketTest)
        {
            var amountTotal = ImperativeProgramming.CalculateBasketAmountTotal(basketTest.BasketLineArticles);
            Assert.AreEqual(amountTotal, basketTest.ExpectedPrice);
        }
    }
}