using Cards.Cards.DM10;
using Engine;
using Engine.Abilities;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace TestCards.Cards.DM10
{
    public class TransmogrifyEffectTests
    {
        [Fact]
        public void Apply_CreatureNotDestroyed_RevealNotCalled()
        {
            var ability = new Mock<IAbility>();

            var game = new Mock<IGame>();
            game.Setup(x => x.GetAbility(ability.Object.Id)).Returns(ability.Object);

            var controller = new Mock<IPlayer>();
            ability.Setup(x => x.GetController(game.Object)).Returns(controller.Object);

            new TransmogrifyEffect().Apply(game.Object);

            controller.Verify(x => x.Reveal(game.Object), Times.Never);
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
