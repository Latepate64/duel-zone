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
            ability.SetupGet(x => x.ControllerPlayer).Returns(controller.Object);
            controller.Setup(x => x.DestroyCreatureOptionally(game, ability.Object)).Returns((ICard)null);
            new TransmogrifyEffect { Ability = ability.Object }.Apply(game);
        }

        [Fact]
        public void Apply_ControllersCreatureDestroyed_OwnerRevealCards()
        {
            var game = Mock.Of<IGame>();
            var controller = new Mock<IPlayer>();
            var destroyed = new Mock<ICard>();
            destroyed.SetupGet(x => x.Owner).Returns(controller.Object);
            var ability = new Mock<IAbility>();
            ability.SetupGet(x => x.ControllerPlayer).Returns(controller.Object);
            controller.Setup(x => x.DestroyCreatureOptionally(game, ability.Object)).Returns(destroyed.Object);
            new TransmogrifyEffect { Ability = ability.Object }.Apply(game);
            controller.Verify(x => x.RevealFromTopDeckUntilNonEvolutionCreaturePutIntoBattleZoneRestIntoGraveyard(game, It.IsAny<IAbility>()), Times.Once);
        }
    }
}
