using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Factories;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.PlayerActionResponses;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class UnitTest
    {
        const string JsonPath = "C:\\duel-masters-json\\DuelMastersCards.json";

        [Fact]
        public void BasicTest()
        {
            var duel = GetDuel();
            var useCard = duel.Progress(new CardSelectionResponse(new Collection<Card>(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            duel.Progress(new CardSelectionResponse(new Collection<Card>(new List<Card>() { useCard.Cards.First() })));
            for (var i = 0; i < 6; ++i)
            {
                duel.Progress(new CardSelectionResponse());
                duel.Progress(new CardSelectionResponse());
                var declareAttack = duel.Progress(new CardSelectionResponse()) as DeclareAttack;
                duel.Progress(new DeclareAttackResponse(declareAttack.CreaturesThatCanAttack.First(), null));
            }
        }

        [Fact]
        public void Player1ShouldWin()
        {
            var duel = GetDuel();
            var useCard = duel.Progress(new CardSelectionResponse(new Collection<Card>(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            duel.Progress(new CardSelectionResponse(new Collection<Card>(new List<Card>() { useCard.Cards.First() })));
            for (var i = 0; i < 6; ++i)
            {
                duel.Progress(new CardSelectionResponse());
                duel.Progress(new CardSelectionResponse());
                duel.Progress(new DeclareAttackResponse((duel.Progress(new CardSelectionResponse()) as DeclareAttack).CreaturesThatCanAttack.First(), null));
            }
            Assert.Equal(duel.Player1, duel.Winner);
        }

        [Fact]
        public void Player2ShouldHave4Shields()
        {
            var duel = GetDuel();
            var useCard = duel.Progress(new CardSelectionResponse(new Collection<Card>(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            duel.Progress(new CardSelectionResponse(new Collection<Card>(new List<Card>() { useCard.Cards.First() })));
            duel.Progress(new CardSelectionResponse());
            duel.Progress(new CardSelectionResponse());
            var declareAttack = duel.Progress(new CardSelectionResponse()) as DeclareAttack;
            duel.Progress(new DeclareAttackResponse(declareAttack.CreaturesThatCanAttack.First(), null));
            Assert.Equal(4, duel.Player2.ShieldZone.Cards.Count);
        }

        [Fact]
        public void ShouldReturnDeclareAttack()
        {
            var duel = GetDuel();
            var useCard = duel.Progress(new CardSelectionResponse(new Collection<Card>(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            duel.Progress(new CardSelectionResponse(new Collection<Card>(new List<Card>() { useCard.Cards.First() })));
            duel.Progress(new CardSelectionResponse());
            duel.Progress(new CardSelectionResponse());
            Assert.IsType<DeclareAttack>(duel.Progress(new CardSelectionResponse()));
        }

        [Fact]
        public void ShouldReturnUseCard()
        {
            var duel = GetDuel();
            Assert.IsType<UseCard>(duel.Progress(new CardSelectionResponse(new Collection<Card>(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))));
        }

        [Fact]
        public void ShouldReturnChargeMana()
        {
            Assert.IsType<ChargeMana>(GetDuel().StartDuel());
        }

        [Fact]
        public void XmlTest()
        {
            var duel = GetDuel();
            var playerAction = duel.StartDuel();
            var xml = XmlUtility.SerializeToString(playerAction);
        }

        private Duel GetDuelJson()
        {
            var jsonCards = JsonCardFactory.GetJsonCards(JsonPath);
            var cards = CardFactory.GetCardsFromJsonCards(jsonCards);
            var duel = new Duel()
            {
                Player1 = new Player()
                {
                    Id = 0,
                    Name = "Player1",
                },
                Player2 = new Player()
                {
                    Id = 1,
                    Name = "Player2",
                }
            };
            const int Count = 40;
            var p1Cards = new Collection<Card>();
            var p2Cards = new Collection<Card>();
            for (var i = 0; i < Count; ++i)
            {
                var p1Card = cards.First(c => c.Name == "Immortal Baron, Vorg").DeepCopy;
                p1Card.GameId = i;
                p1Cards.Add(p1Card);
                var p2Card = cards.First(c => c.Name == "Burning Mane").DeepCopy;
                p2Card.GameId = i + Count;
                p2Cards.Add(p2Card);
            }
            duel.Player1.SetDeckBeforeDuel(p1Cards);
            duel.Player2.SetDeckBeforeDuel(p2Cards);
            duel.Player1.SetupDeck();
            duel.Player2.SetupDeck();
            return duel;
        }

        private Duel GetDuel()
        {
            var duel = new Duel()
            {
                Player1 = new Player()
                {
                    Id = 0,
                    Name = "Player1",
                },
                Player2 = new Player()
                {
                    Id = 1,
                    Name = "Player2",
                }
            };
            const int Count = 40;
            var p1Cards = new Collection<Card>();
            var p2Cards = new Collection<Card>();
            for (var i = 0; i < Count; ++i)
            {
                p1Cards.Add(GetTestCreature(i));
                p2Cards.Add(GetTestCreature(i+Count));
            }
            duel.Player1.SetDeckBeforeDuel(p1Cards);
            duel.Player2.SetDeckBeforeDuel(p2Cards);
            duel.Player1.SetupDeck();
            duel.Player2.SetupDeck();
            return duel;
        }

        private Creature GetTestCreature(int gameId)
        {
            var creature = new Creature()
            {
                Cost = 1,
                GameId = gameId,
                Name = "TestCreature",
                Power = 1000,
            };
            creature.Civilizations.Add(Civilization.Light);
            creature.Races.Add("Initiate");
            return creature;
        }
    }
}