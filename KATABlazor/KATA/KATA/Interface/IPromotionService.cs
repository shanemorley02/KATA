using static KATA.Pages.Items;

namespace KATA
{
    public interface IPromotionService
    {
        public decimal CalculatePromotions(Item item);
    }
}
