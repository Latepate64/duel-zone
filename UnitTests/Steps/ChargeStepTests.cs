using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Choices;
using DuelMastersModels.Steps;
using DuelMastersModels.Zones;
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
            Choice choice = step.ChargeMana(Mock.Of<Card>());
            Assert.Null(choice);
        }

        [Fact]
        public void GetNextStep_ReturnMainStep()
        {
            ChargeStep step = new ChargeStep(Mock.Of<IPlayer>());
            Step nextStep = step.GetNextStep();
            _ = Assert.IsType<MainStep>(nextStep);
        }

        [Fact]
        public void PerformPriorityAction_ChargedCardNull_ReturnPriorityActionChoice()
        {
            Mock<IPlayer> player = new Mock<IPlayer>();
            _ = player.SetupGet(x => x.Hand).Returns(Mock.Of<Hand>());
            ChargeStep step = new ChargeStep(player.Object);

            Choice choice = step.PerformPriorityAction();

            _ = Assert.IsType<ChargeChoice>(choice);
        }

        [Fact]
        public void PerformPriorityAction_ChargedCardNotNull_ReturnNull()
        {
            ChargeStep step = new ChargeStep(Mock.Of<IPlayer>()) { ChargedCard = Mock.Of<Card>() };
            Assert.Null(step.PerformPriorityAction());
        }
    }
}
