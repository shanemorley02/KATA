using KATA;
using Moq;

namespace KATAXUnitTests
{
    public class KATATestFixture
    {
        public Mock<IPricingService> PricingService { get; private set; }
        public Mock<IPromotionService> PromotionService { get; private set; }
        public KATATestFixture()
        {
            PricingService = new Mock<IPricingService>(MockBehavior.Strict);
            PromotionService = new Mock<IPromotionService>(MockBehavior.Strict);
        }
    }
}
