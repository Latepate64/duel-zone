using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Choices;
using DuelMastersModels.Steps;
using Moq;
using Xunit;

namespace UnitTests.Steps
{
    public class ChargeStepTests
    {
        [Fact]
        public void ChargeMana_ManaNotChargedBefore_ReturnNull()
        {
            ChargeStep step = new ChargeStep(Mock.Of<IPlayer>());
            IChoice choice = step.ChargeMana(Mock.Of<IHandCard>());
            Assert.Null(choice);
        }
    }
}
