using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.PlayerActions.CreatureSelections;
using DuelMastersModels.PlayerActionResponses;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class UnitTest
    {
        [Fact]
        public void BasicTest()
        {
            Duel duel = GetDuel();
            ChargeMana chargeMana = duel.StartDuel() as ChargeMana;
            UseCard useCard = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(chargeMana.Cards.First()))) as UseCard; // Charge mana (player 1)
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(useCard.Cards.First()))); // Use card (player 1)
            for (int i = 0; i < 6; ++i)
            {
                duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection())); // Do not charge mana (player 2)
                duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection())); // Do not charge mana (player 1)
                DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection())) as DeclareAttacker; // Do not use card (player 1)
                duel.Progress(new CreatureSelectionResponse(new ReadOnlyCreatureCollection(declareAttacker.Creatures.First()))); // Declare attacker (player 1)
            }
            Assert.True(duel.Ended);
        }

        [Fact]
        public void InvalidCardSelectionResponsePayCost()
        {
            Duel duel = GetDuel();
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() })));
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection()));
            UseCard useCard = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            PayCost payCost = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { useCard.Cards.First() }))) as PayCost;
            PlayerAction newAction = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { duel.Player1.Hand.Cards.First() })));
            Assert.Equal(payCost, newAction);
        }

        [Fact]
        public void InvalidCardSelectionResponseDeclareAttack()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { useCard.Cards.First() })));
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection()));
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection()));
            DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection())) as DeclareAttacker;
            PlayerAction newAction = duel.Progress(new CreatureSelectionResponse(new ReadOnlyCreatureCollection(duel.Player1.ManaZone.Creatures.First())));
            Assert.Equal(declareAttacker, newAction);
        }

        [Fact]
        public void InvalidCardSelectionResponseUseCard()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            PlayerAction newAction = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { duel.Player1.ManaZone.Cards.First() })));
            Assert.Equal(useCard, newAction);
        }

        [Fact]
        public void InvalidCardSelectionResponseChargeMana()
        {
            Duel duel = GetDuel();
            ChargeMana chargeMana = (duel.StartDuel() as ChargeMana);
            PlayerAction newAction = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { duel.Player1.ShieldZone.Cards.First() })));
            Assert.Equal(chargeMana, newAction);
        }

        [Fact]
        public void Player1ShouldWin()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { useCard.Cards.First() })));
            for (int i = 0; i < 6; ++i)
            {
                duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection()));
                duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection()));
                DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection())) as DeclareAttacker;
                duel.Progress(new CreatureSelectionResponse(new ReadOnlyCreatureCollection(declareAttacker.Creatures.First())));
            }
            Assert.Equal(duel.Player1, duel.Winner);
        }

        [Fact]
        public void Player2ShouldHave4Shields()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { useCard.Cards.First() })));
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection()));
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection()));
            DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection())) as DeclareAttacker;
            duel.Progress(new CreatureSelectionResponse(new ReadOnlyCreatureCollection(declareAttacker.Creatures.First())));
            Assert.Equal(4, duel.Player2.ShieldZone.Cards.Count);
        }

        [Fact]
        public void ShouldReturnPayCost()
        {
            Duel duel = GetDuel();
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() })));
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection()));
            UseCard useCard = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            PlayerAction newAction = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { useCard.Cards.First() })));
            Assert.IsType<PayCost>(newAction);
        }

        [Fact]
        public void ShouldReturnDeclareAttacker()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { useCard.Cards.First() })));
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection()));
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection()));
            Assert.IsType<DeclareAttacker>(duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection())));
        }

        [Fact]
        public void ShouldReturnUseCard()
        {
            Duel duel = GetDuel();
            Assert.IsType<UseCard>(duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))));
        }

        [Fact]
        public void ShouldReturnChargeMana()
        {
            Assert.IsType<ChargeMana>(GetDuel().StartDuel());
        }

        private Duel GetDuel()
        {
            Duel duel = new Duel()
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
            const int DeckSize = 40;
            CardCollection p1Cards = new CardCollection();
            CardCollection p2Cards = new CardCollection();
            for (int i = 0; i < DeckSize; ++i)
            {
                p1Cards.Add(GetTestCreature(i));
                p2Cards.Add(GetTestCreature(i+DeckSize));
            }
            duel.Player1.SetDeckBeforeDuel(p1Cards);
            duel.Player2.SetDeckBeforeDuel(p2Cards);
            duel.Player1.SetupDeck(duel);
            duel.Player2.SetupDeck(duel);
            return duel;
        }

        private Creature GetTestCreature(int gameId)
        {
            return new Creature(name: "TestCreature", null, null, civilizations: new Collection<string>() { "Light" }, rarity: "Common", cost: 1, null, null, null, gameId: gameId, power: "1000", races: new Collection<string>() { "Initiate" }, null);
        }
    }
}