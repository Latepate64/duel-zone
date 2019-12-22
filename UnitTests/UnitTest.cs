using DuelMastersModels;
using DuelMastersModels.Cards;
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
        [Fact]
        public void BasicTest()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { useCard.Cards.First() })));
            for (int i = 0; i < 6; ++i)
            {
                duel.Progress(new CardSelectionResponse());
                duel.Progress(new CardSelectionResponse());
                /*DeclareAttack declareAttack = duel.Progress(new CardSelectionResponse()) as DeclareAttack;
                duel.Progress(new DeclareAttackResponse(declareAttack.CreaturesThatCanAttack.First(), null));*/
            }
        }

        [Fact]
        public void InvalidCardSelectionResponsePayCost()
        {
            Duel duel = GetDuel();
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() })));
            duel.Progress(new CardSelectionResponse());
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
            duel.Progress(new CardSelectionResponse());
            duel.Progress(new CardSelectionResponse());
            /*
            DeclareAttack declareAttack = duel.Progress(new CardSelectionResponse()) as DeclareAttack;
            PlayerAction newAction = duel.Progress(new DeclareAttackResponse(duel.Player1.ManaZone.Creatures.First(), null));
            Assert.Equal(declareAttack, newAction);
            */
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
                duel.Progress(new CardSelectionResponse());
                duel.Progress(new CardSelectionResponse());
                //duel.Progress(new DeclareAttackResponse((duel.Progress(new CardSelectionResponse()) as DeclareAttack).CreaturesThatCanAttack.First(), null));
            }
            Assert.Equal(duel.Player1, duel.Winner);
        }

        [Fact]
        public void Player2ShouldHave4Shields()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { useCard.Cards.First() })));
            duel.Progress(new CardSelectionResponse());
            duel.Progress(new CardSelectionResponse());
            /*DeclareAttack declareAttack = duel.Progress(new CardSelectionResponse()) as DeclareAttack;
            duel.Progress(new DeclareAttackResponse(declareAttack.CreaturesThatCanAttack.First(), null));
            Assert.Equal(4, duel.Player2.ShieldZone.Cards.Count);*/
        }

        [Fact]
        public void ShouldReturnPayCost()
        {
            Duel duel = GetDuel();
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() })));
            duel.Progress(new CardSelectionResponse());
            UseCard useCard = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            PlayerAction newAction = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { useCard.Cards.First() })));
            Assert.IsType<PayCost>(newAction);
        }

        [Fact]
        public void ShouldReturnDeclareAttack()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { useCard.Cards.First() })));
            duel.Progress(new CardSelectionResponse());
            duel.Progress(new CardSelectionResponse());
            //Assert.IsType<DeclareAttack>(duel.Progress(new CardSelectionResponse()));
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

        [Fact]
        public void XmlTest()
        {
            Duel duel = GetDuel();
            PlayerAction playerAction = duel.StartDuel();
            string xml = XmlUtility.SerializeToString(playerAction);
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
            Creature creature = new Creature()
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