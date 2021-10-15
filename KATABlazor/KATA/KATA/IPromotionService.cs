using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KATA.Pages.Items;

namespace KATA
{
    public interface IPromotionService
    {
        public decimal CalculatePromotions(Item item);
    }
}
