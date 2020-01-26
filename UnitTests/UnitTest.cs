using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Exceptions;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.PlayerActions.CreatureSelections;
using DuelMastersModels.PlayerActionResponses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class UnitTest
    {
        #region Facts
        [Fact]
        public void BasicTest()
        {
            IDuel duel = GetDuel();
            ChargeMana chargeMana = duel.Start() as ChargeMana;
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>(chargeMana.Cards.First())) as UseCard; // Charge mana (player 1)
            _ = duel.Progress(new CardSelectionResponse<IHandCard>(useCard.Cards.First())); // Use card (player 1)
            for (int i = 0; i < 6; ++i)
            {
                SkipChargingMana(duel); // player 2
                SkipChargingMana(duel); // player 1                  
                DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse<IHandCard>()) as DeclareAttacker; // Do not use card (player 1)
                _ = duel.Progress(new CreatureSelectionResponse<BattleZoneCreature>(declareAttacker.Creatures.First())); // Declare attacker (player 1)
            }
            Assert.Equal(DuelState.Over, duel.State);
        }

        [Fact]
        public void InvalidCardSelectionResponsePayCost()
        {
            IDuel duel = GetDuel();
            ChargeMana chargeMana = duel.Start() as ChargeMana;
            _ = duel.Progress(new CardSelectionResponse<IHandCard>(chargeMana.Cards.First()));
            _ = duel.Progress(new CardSelectionResponse<IHandCard>());
            ChargeMana chargeMana2 = duel.Progress(new CardSelectionResponse<IHandCard>()) as ChargeMana;
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>(chargeMana2.Cards.First())) as UseCard;
            PayCost payCost = duel.Progress(new CardSelectionResponse<IHandCard>(useCard.Cards.First())) as PayCost;
            _ = Assert.Throws<MandatoryMultipleCardSelectionException>(() => duel.Progress(new CardSelectionResponse<IManaZoneCard>(duel.Player2.ManaZone.Cards.First()))); //Try to pay the cost with the other player's mana.
        }

        [Fact]
        public void InvalidCardSelectionResponseDeclareAttack()
        {
            IDuel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First() )) as UseCard;
            _ = duel.Progress(new CardSelectionResponse<IHandCard>(useCard.Cards.First()));
            _ = duel.Progress(new CardSelectionResponse<IHandCard>());
            _ = duel.Progress(new CardSelectionResponse<IHandCard>());
            DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse<IHandCard>()) as DeclareAttacker;
            _ = Assert.Throws<OptionalCreatureSelectionException>(() => duel.Progress(new CreatureSelectionResponse<IManaZoneCreature>(duel.Player1.ManaZone.Cards.OfType<IManaZoneCreature>().First())));
        }

        [Fact]
        public void InvalidCardSelectionResponseUseCard()
        {
            IDuel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First())) as UseCard;
            _ = Assert.Throws<OptionalCardSelectionException>(() => duel.Progress(new CardSelectionResponse<IManaZoneCard>(duel.Player1.ManaZone.Cards.First())));
        }

        [Fact]
        public void InvalidCardSelectionResponseChargeMana()
        {
            IDuel duel = GetDuel();
            ChargeMana chargeMana = duel.Start() as ChargeMana;
            _ = Assert.Throws<OptionalCardSelectionException>(() => duel.Progress(new CardSelectionResponse<IShieldZoneCard>(duel.Player1.ShieldZone.Cards.First())));
        }

        [Fact]
        public void Player1ShouldWin()
        {
            IDuel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First())) as UseCard;
            _ = duel.Progress(new CardSelectionResponse<IHandCard>(useCard.Cards.First()));
            for (int i = 0; i < 6; ++i)
            {
                _ = duel.Progress(new CardSelectionResponse<IHandCard>());
                _ = duel.Progress(new CardSelectionResponse<IHandCard>());
                DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse<IHandCard>()) as DeclareAttacker;
                _ = duel.Progress(new CreatureSelectionResponse<BattleZoneCreature>(declareAttacker.Creatures.First()));
            }
            Assert.Equal(duel.Player1, duel.Winner);
        }

        [Fact]
        public void Player2ShouldHave4Shields()
        {
            IDuel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First())) as UseCard;
            _ = duel.Progress(new CardSelectionResponse<IHandCard>(useCard.Cards.First()));
            _ = duel.Progress(new CardSelectionResponse<IHandCard>());
            _ = duel.Progress(new CardSelectionResponse<IHandCard>());
            DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse<IHandCard>()) as DeclareAttacker;
            _ = duel.Progress(new CreatureSelectionResponse<BattleZoneCreature>(declareAttacker.Creatures.First()));
            throw new NotImplementedException("Zones are not public information.");
            //Assert.Equal(4, duel.Player2.ShieldZone.Cards.Count);
        }

        [Fact]
        public void ShouldReturnPayCost()
        {
            IDuel duel = GetDuel();
            _ = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First()));
            _ = duel.Progress(new CardSelectionResponse<IHandCard>());
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Progress(new CardSelectionResponse<IHandCard>()) as ChargeMana).Cards.First())) as UseCard;
            IPlayerAction newAction = duel.Progress(new CardSelectionResponse<IHandCard>(useCard.Cards.First()));
            _ = Assert.IsType<PayCost>(newAction);
        }

        [Fact]
        public void ShouldReturnDeclareAttacker()
        {
            IDuel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First())) as UseCard;
            _ = duel.Progress(new CardSelectionResponse<IHandCard>(useCard.Cards.First()));
            _ = duel.Progress(new CardSelectionResponse<IHandCard>());
            _ = duel.Progress(new CardSelectionResponse<IHandCard>());
            _ = Assert.IsType<DeclareAttacker>(duel.Progress(new CardSelectionResponse<IHandCard>()));
        }

        [Fact]
        public void ShouldReturnUseCard()
        {
            IDuel duel = GetDuel();
            _ = Assert.IsType<UseCard>(duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First())));
        }

        [Fact]
        public void ShouldReturnChargeMana()
        {
            _ = Assert.IsType<ChargeMana>(GetDuel().Start());
        }

        [Fact]
        public void TestDrawCardEvent()
        {
            IDuel duel = GetDuel();
            duel.DuelEventOccurred += DuelEventOccurred;
            ChargeMana chargeMana = duel.Start() as ChargeMana;
            Assert.True(_duelEvents.Count(e => e is DrawCardEvent draw) == 10);
        }

        /*
        [Fact]
        public void TestCreatureAccessMofifiers()
        {
            Creature creature = GetTestCreature("");
            throw new NotImplementedException();
            //CreatureSelectionResponse<IHandCard> jotain = new CreatureSelectionResponse<IHandCard>(creature);
        }
        */

        [Fact]
        public void TestAccessMofifiers()
        {
            IDuel duel = GetDuel();
            duel.DuelEventOccurred += DuelEventOccurred;
            ChargeMana chargeMana = duel.Start() as ChargeMana;
            Assert.Equal(10, _duelEvents.Count(e => e is DrawCardEvent draw));
        }

        [Fact]
        public void TestSelectAbilityToResolve()
        {
            Duel duel = GetDuel("Whenever another creature is put into the battle zone, you may draw a card.");
            ChargeMana chargeMana1 = duel.Start() as ChargeMana;

            UseCard useCard1 = duel.Progress(new CardSelectionResponse<IHandCard>(chargeMana1.Cards.First())) as UseCard; // Charge mana (player 1)
            _ = duel.Progress(new CardSelectionResponse<IHandCard>(useCard1.Cards.First())) as ChargeMana; // Use card (player 1)
            _ = duel.Progress(new CardSelectionResponse<IHandCard>()) as ChargeMana; // Do not charge mana (player 2)
            _ = duel.Progress(new CardSelectionResponse<IHandCard>()) as UseCard; // Do not charge mana (player 1)

            //PlayerAction jotain = duel.Progress(new CardSelectionResponse<IHandCard>(useCard2.Cards.First())); // Use card (player 2)

            //var jotain = duel.Progress()
            //hrow new System.NotImplementedException();
            //DuelMastersModels.Abilities.NonStaticAbility
        }
        #endregion Facts

        #region Private methods
        private static readonly List<DuelEvent> _duelEvents = new List<DuelEvent>();

        private void DuelEventOccurred(object sender, DuelEventArgs e)
        {
            _duelEvents.Add(e.DuelEvent);
        }

        private IDuel GetDuel()
        {
            return GetDuel("");
        }

        private Duel GetDuel(string creatureText)
        { 
            const int DeckSize = 40;
            List<Card> p1Cards = new List<Card>();
            List<Card> p2Cards = new List<Card>();
            for (int i = 0; i < DeckSize; ++i)
            {
                p1Cards.Add(GetTestCreature(creatureText));
                p2Cards.Add(GetTestCreature(creatureText));
            }
            return new Duel(new Player("Player1", new ReadOnlyCardCollection<ICard>(p1Cards)), new Player("Player2", new ReadOnlyCardCollection<ICard>(p2Cards))) { StartingPlayer = StartingPlayer.Player1 };
        }

        private Creature GetTestCreature(string creatureText)
        {
            return new Creature(name: "TestCreature", set: null, id: null, civilizations: new Collection<string>() { "Light" }, rarity: "Common", cost: 1, text: creatureText, flavor: null, illustrator: null, power: "1000", races: new Collection<string>() { "Initiate" });
        }

        private static void SkipChargingMana(IDuel duel)
        {
            _ = duel.Progress(new CardSelectionResponse<IHandCard>());
        }
        #endregion Private methods
    }
}