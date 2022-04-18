using Cards.Cards.DM10;
using Engine;
using Engine.Abilities;
using Engine.Zones;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace TestCards.Cards.DM10
{
    public class TransmogrifyEffectTests
    {
        [Fact]
        public void Apply_CreatureChosen_CreatureDestroyed()
        {
            var toDestroy = Mock.Of<ICard>();

            var controller = new Mock<IPlayer>();
            controller.Setup(x => x.ChooseCardOptionally(It.IsAny<IEnumerable<ICard>>(), It.IsAny<string>())).Returns(toDestroy);
            controller.SetupGet(x => x.DeckCards).Returns(new List<ICard>());

            var ability = new Mock<IAbility>();
            var battleZone = new Mock<IBattleZone>();

            var game = new Mock<IGame>();
            game.Setup(x => x.BattleZone).Returns(battleZone.Object);
            game.Setup(x => x.GetOwner(toDestroy)).Returns(controller.Object);

            battleZone.Setup(x => x.GetChoosableCreaturesControlledByAnyone(game.Object, controller.Object.Id));
            ability.Setup(x => x.GetController(game.Object)).Returns(controller.Object);

            new TransmogrifyEffect().Apply(game.Object, ability.Object);

            game.Verify(x => x.Destroy(ability.Object, toDestroy), Times.Once);
        }

        [Fact]
        public void ApplyAfterDestroy_NothingInDeck_PutsNothingIntoBattleZone()
        {
            var player = new Mock<IPlayer>();
            player.SetupGet(x => x.DeckCards).Returns(new List<ICard>());

            var game = new Mock<IGame>();

            TransmogrifyEffect.ApplyAfterDestroy(game.Object, new Mock<IAbility>().Object, player.Object);

            game.Verify(x => x.Move(It.IsAny<IAbility>(), ZoneType.Deck, ZoneType.BattleZone, It.IsAny<ICard>()), Times.Never);
        }

        [Fact]
        public void ApplyAfterDestroy_NonEvolutionCreatureInDeck_PutsCreatureIntoBattleZone()
        {
            var creature = new Mock<ICard>();
            creature.SetupGet(x => x.IsNonEvolutionCreature).Returns(true);

            var player = new Mock<IPlayer>();
            player.SetupGet(x => x.DeckCards).Returns(new List<ICard> { creature.Object });

            var game = new Mock<IGame>();
            var ability = new Mock<IAbility>();

            TransmogrifyEffect.ApplyAfterDestroy(game.Object, ability.Object, player.Object);

            game.Verify(x => x.Move(ability.Object, ZoneType.Deck, ZoneType.BattleZone, creature.Object), Times.Once);
        }

        [Fact]
        public void ApplyAfterDestroy_OtherThanNonEvolutionCreatureInDeck_PutsIntoGraveyard()
        {
            var other = new Mock<ICard>();
            other.SetupGet(x => x.IsNonEvolutionCreature).Returns(false);

            var player = new Mock<IPlayer>();
            player.SetupGet(x => x.DeckCards).Returns(new List<ICard> { other.Object });

            var game = new Mock<IGame>();
            var ability = new Mock<IAbility>();

            TransmogrifyEffect.ApplyAfterDestroy(game.Object, ability.Object, player.Object);

            game.Verify(x => x.Move(ability.Object, ZoneType.Deck, ZoneType.Graveyard, other.Object), Times.Once);
        }
    }
}
