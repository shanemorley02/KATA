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
        public decimal Total { get; set; }

        public void AddToBasket(Item item) {
            if (Items == null)
            {
                Items.Add(item);
            }
            var existingItem = Items.FirstOrDefault(x => x.ItemSKU == item.ItemSKU);
            if (existingItem == null)
            {
                Items.Add(item);
            }
            else {
                existingItem.Qty++;
            }

            Total = _pricingService.CalculateTotalPrice(Items);
        }
    }
}
