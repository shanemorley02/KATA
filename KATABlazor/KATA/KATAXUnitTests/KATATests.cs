using KATA;
using System.Collections.Generic;
using Xunit;
using static KATA.Pages.Items;

namespace KATAXUnitTests
{
    //Started using Moq to unit test my interfaces using a fixture class and seperate methods/classes but ran out of time.
    //Below are just basic unit tests which tests the adding to basket with different scenarios.
    public class KATATests
    {
        public readonly IPricingService _pricingService;
        public readonly IPromotionService _promotionService;

        public KATATests()
        {
            _promotionService = new PromotionService();
            _pricingService = new PricingService(_promotionService);
        }

        [Fact]
        public void TestAdding1NonPromotionToBasket()
        {
            var item = new Item
            {
                ItemSKU = "A",
                Qty = 0,
                UnitPrice = 10,
                Promotion = false
            };

           var basket = new Basket(_pricingService);

            basket.AddToBasket(item);

            Assert.Equal(10, basket.TotalPrice);
        }

        [Fact]
        public void TestAdding1NonPromotionToBasketIncrementingQty()
        {
            var item = new Item
            {
                ItemSKU = "A",
                Qty = 1,
                UnitPrice = 10,
                Promotion = false
            };

            var basket = new Basket(_pricingService);

            basket.AddToBasket(item);

            Assert.Equal(20, basket.TotalPrice);
        }

        [Fact]
        public void TestAddingDiffNonPromotionToBasketIncrementingQty()
        {
            var itemList = new List<Item>
            {
                new Item
                {
                    ItemSKU = "A",
                    Qty = 0,
                    UnitPrice = 10,
                    Promotion = false
                },
                new Item
                {
                    ItemSKU = "C",
                    Qty = 0,
                    UnitPrice = 40,
                    Promotion = false
                }
            };

            var basket = new Basket(_pricingService);

            foreach (var item in itemList)
            {
                basket.AddToBasket(item);
            }

            Assert.Equal(50, basket.TotalPrice);
        }

        [Fact]
        public void TestAdding1Promotion3For40ToBasketIncrementingQty()
        {
            var item = new Item
            {
                ItemSKU = "B",
                Qty = 2,
                UnitPrice = 15,
                Promotion = true
            };

            var basket = new Basket(_pricingService);

            basket.AddToBasket(item);

            Assert.Equal(40, basket.TotalPrice);
        }

        [Fact]
        public void TestAdding1Promotion25of2ToBasketIncrementingQty()
        {
            var item = new Item
            {
                ItemSKU = "D",
                Qty = 1,
                UnitPrice = 55,
                Promotion = true
            };

            var basket = new Basket(_pricingService);

            basket.AddToBasket(item);

            Assert.Equal(82.5m, basket.TotalPrice);
        }
    }
}
