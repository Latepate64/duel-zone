using Cards.Cards.DM10;
using Engine;
using Engine.Abilities;
using Moq;
using Xunit;

namespace TestCards.Cards.DM10
{
    public class TransmogrifyEffectTests
    {
        [Fact]
        public void Apply_CreatureNotDestroyed_Pass()
        {
            var game = Mock.Of<IGame>();
            var controller = new Mock<IPlayer>();
            var ability = new Mock<IAbility>();
            ability.SetupGet(x => x.Controller).Returns(controller.Object);
            controller.Setup(x => x.DestroyCreatureOptionally(game, ability.Object)).Returns((Card)null);
            new TransmogrifyEffect { Ability = ability.Object }.Apply(game);
        }
    }
}
