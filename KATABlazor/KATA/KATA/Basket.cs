using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KATA.Pages.Items;

namespace KATA
{
    public class Basket
    {
        private IPricingService _pricingService;
        public Basket(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }
        public List<Item> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalQty { get; set; }

        public void AddToBasket(Item item) {
            if (Items == null)
            {
                Items = new List<Item>();
            }
            var existingItem = Items.FirstOrDefault(x => x.ItemSKU == item.ItemSKU);
            if (existingItem == null)
            {
                item.Qty++;
                Items.Add(item);
            }
            else {
                existingItem.Qty++;
            }

            TotalPrice = _pricingService.CalculateTotalPrice(Items);
            TotalQty = CalculateTotalBasketQty(Items);
        }

        private int CalculateTotalBasketQty(IEnumerable<Item> items) {
            var totalQty = 0;
            foreach (var item in items)
            {
                totalQty += item.Qty;
            }

            return totalQty;
        }
    }
}
