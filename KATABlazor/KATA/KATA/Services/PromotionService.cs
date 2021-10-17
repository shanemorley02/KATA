using static KATA.Pages.Items;

namespace KATA
{
    //this service could be anywhere, in its own project or even an api.
    //we pass in each item which qualifies for a promotion and check to see which promotion to use.
    public class PromotionService : IPromotionService
    {
        public decimal CalculatePromotions(Item item)
        {
            //call the factory to bring back the correct object.
            var promotion = new PromotionFactory().GetPromotion(item.ItemSKU);

            //use polymorphism implemented by an interface to call the method.
            return promotion.Calculate(item);
        }
    }
}
