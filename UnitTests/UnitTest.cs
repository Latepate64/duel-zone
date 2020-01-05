using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Exceptions;
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
            ChargeMana chargeMana = duel.Start() as ChargeMana;
            UseCard useCard = duel.Progress(new CardSelectionResponse(chargeMana.Cards.First())) as UseCard; // Charge mana (player 1)
            duel.Progress(new CardSelectionResponse(useCard.Cards.First())); // Use card (player 1)
            for (int i = 0; i < 6; ++i)
            {
                duel.Progress(new CardSelectionResponse()); // Do not charge mana (player 2)
                duel.Progress(new CardSelectionResponse()); // Do not charge mana (player 1)
                var jotain = duel.Progress(new CardSelectionResponse());
                DeclareAttacker declareAttacker = jotain as DeclareAttacker; // Do not use card (player 1)
                duel.Progress(new CreatureSelectionResponse(declareAttacker.Creatures.First())); // Declare attacker (player 1)
            }
            Assert.Equal(DuelState.Over, duel.State);
        }

        [Fact]
        public void InvalidCardSelectionResponsePayCost()
        {
            Duel duel = GetDuel();
            duel.Progress(new CardSelectionResponse((duel.Start() as ChargeMana).Cards.First()));
            duel.Progress(new CardSelectionResponse());
            UseCard useCard = duel.Progress(new CardSelectionResponse((duel.Progress(new CardSelectionResponse()) as ChargeMana).Cards.First())) as UseCard;
            PayCost payCost = duel.Progress(new CardSelectionResponse(useCard.Cards.First())) as PayCost;
            Assert.Throws<MandatoryMultipleCardSelectionException>(() => duel.Progress(new CardSelectionResponse(duel.Player1.Hand.Cards.First())));
        }

        [Fact]
        public void InvalidCardSelectionResponseDeclareAttack()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse((duel.Start() as ChargeMana).Cards.First() )) as UseCard;
            duel.Progress(new CardSelectionResponse(useCard.Cards.First()));
            duel.Progress(new CardSelectionResponse());
            duel.Progress(new CardSelectionResponse());
            DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse()) as DeclareAttacker;
            Assert.Throws<OptionalCreatureSelectionException>(() => duel.Progress(new CreatureSelectionResponse(duel.Player1.ManaZone.Creatures.First())));
        }

        [Fact]
        public void InvalidCardSelectionResponseUseCard()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse((duel.Start() as ChargeMana).Cards.First())) as UseCard;
            Assert.Throws<OptionalCardSelectionException>(() => duel.Progress(new CardSelectionResponse(duel.Player1.ManaZone.Cards.First())));
        }

        [Fact]
        public void InvalidCardSelectionResponseChargeMana()
        {
            Duel duel = GetDuel();
            ChargeMana chargeMana = (duel.Start() as ChargeMana);
            Assert.Throws<OptionalCardSelectionException>(() => duel.Progress(new CardSelectionResponse(duel.Player1.ShieldZone.Cards.First())));
        }

        [Fact]
        public void Player1ShouldWin()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse((duel.Start() as ChargeMana).Cards.First())) as UseCard;
            duel.Progress(new CardSelectionResponse(useCard.Cards.First()));
            for (int i = 0; i < 6; ++i)
            {
                duel.Progress(new CardSelectionResponse());
                duel.Progress(new CardSelectionResponse());
                DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse()) as DeclareAttacker;
                duel.Progress(new CreatureSelectionResponse(declareAttacker.Creatures.First()));
            }
            Assert.Equal(duel.Player1, duel.Winner);
        }

        [Fact]
        public void Player2ShouldHave4Shields()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse((duel.Start() as ChargeMana).Cards.First())) as UseCard;
            duel.Progress(new CardSelectionResponse(useCard.Cards.First()));
            duel.Progress(new CardSelectionResponse());
            duel.Progress(new CardSelectionResponse());
            DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse()) as DeclareAttacker;
            duel.Progress(new CreatureSelectionResponse(declareAttacker.Creatures.First()));
            Assert.Equal(4, duel.Player2.ShieldZone.Cards.Count);
        }

        [Fact]
        public void ShouldReturnPayCost()
        {
            Duel duel = GetDuel();
            duel.Progress(new CardSelectionResponse((duel.Start() as ChargeMana).Cards.First()));
            duel.Progress(new CardSelectionResponse());
            UseCard useCard = duel.Progress(new CardSelectionResponse((duel.Progress(new CardSelectionResponse()) as ChargeMana).Cards.First())) as UseCard;
            PlayerAction newAction = duel.Progress(new CardSelectionResponse(useCard.Cards.First()));
            Assert.IsType<PayCost>(newAction);
        }

        [Fact]
        public void ShouldReturnDeclareAttacker()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse((duel.Start() as ChargeMana).Cards.First())) as UseCard;
            duel.Progress(new CardSelectionResponse(useCard.Cards.First()));
            duel.Progress(new CardSelectionResponse());
            duel.Progress(new CardSelectionResponse());
            Assert.IsType<DeclareAttacker>(duel.Progress(new CardSelectionResponse()));
        }

        [Fact]
        public void ShouldReturnUseCard()
        {
            Duel duel = GetDuel();
            Assert.IsType<UseCard>(duel.Progress(new CardSelectionResponse((duel.Start() as ChargeMana).Cards.First())));
        }

        [Fact]
        public void ShouldReturnChargeMana()
        {
            Assert.IsType<ChargeMana>(GetDuel().Start());
        }

        [Fact]
        public void TestDrawCardEvent()
        {
            Duel duel = GetDuel();
            duel.DuelEventOccurred += DuelEventOccurred;
            ChargeMana chargeMana = duel.Start() as ChargeMana;
            Assert.True(_duelEvents.Count(e => e is DrawCardEvent draw) == 10);
        }

        [Fact]
        public void TestCreatureAccessMofifiers()
        {
            Creature creature = GetTestCreature(0);
            CreatureSelectionResponse jotain = new CreatureSelectionResponse(creature);
        }

        [Fact]
        public void TestAccessMofifiers()
        {
            Duel duel = GetDuel();
            duel.DuelEventOccurred += DuelEventOccurred;
            ChargeMana chargeMana = duel.Start() as ChargeMana;
            Assert.Equal(10, _duelEvents.Count(e => e is DrawCardEvent draw));
        }

        private static List<DuelEvent> _duelEvents = new List<DuelEvent>();

        private void DuelEventOccurred(object sender, DuelEventArgs e)
        {
            _duelEvents.Add(e.DuelEvent);
        }

        private Duel GetDuel()
        { 
            const int DeckSize = 40;
            List<Card> p1Cards = new List<Card>();
            List<Card> p2Cards = new List<Card>();
            for (int i = 0; i < DeckSize; ++i)
            {
                p1Cards.Add(GetTestCreature(i));
                p2Cards.Add(GetTestCreature(i+DeckSize));
            }
            return new Duel(new Player("Player1", new ReadOnlyCardCollection(p1Cards)), new Player("Player2", new ReadOnlyCardCollection(p2Cards))) { StartingPlayer = StartingPlayer.Player1 };
        }

        private Creature GetTestCreature(int gameId)
        {
            string text = "When you put this creature into the battle zone, tap all your opponent's creatures in the battle zone.";
            return new Creature(name: "TestCreature", set: null, id: null, civilizations: new Collection<string>() { "Light" }, rarity: "Common", cost: 1, text: text, flavor: null, illustrator: null, power: "1000", races: new Collection<string>() { "Initiate" });
        }
    }
}