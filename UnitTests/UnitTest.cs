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
        [Fact]
        public void BasicTest()
        {
            Duel duel = GetDuel();
            ChargeMana chargeMana = duel.Start() as ChargeMana;
            UseCard useCard = duel.Progress<IHandCard>(new CardSelectionResponse<IHandCard>(chargeMana.Cards.First())) as UseCard; // Charge mana (player 1)
            duel.Progress<IHandCard>(new CardSelectionResponse<IHandCard>(useCard.Cards.First())); // Use card (player 1)
            for (int i = 0; i < 6; ++i)
            {
                duel.Progress<IHandCard>(new CardSelectionResponse<IHandCard>()); // Do not charge mana (player 2)
                duel.Progress<IHandCard>(new CardSelectionResponse<IHandCard>()); // Do not charge mana (player 1)
                var jotain = duel.Progress<IHandCard>(new CardSelectionResponse<IHandCard>());
                DeclareAttacker declareAttacker = jotain as DeclareAttacker; // Do not use card (player 1)
                duel.Progress<IHandCard>(new CreatureSelectionResponse<BattleZoneCreature>(declareAttacker.Creatures.First())); // Declare attacker (player 1)
            }
            Assert.Equal(DuelState.Over, duel.State);
        }
        /*
        [Fact]
        public void InvalidCardSelectionResponsePayCost()
        {
            Duel duel = GetDuel();
            duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First()));
            duel.Progress(new CardSelectionResponse<IHandCard>());
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Progress(new CardSelectionResponse<IHandCard>()) as ChargeMana).Cards.First())) as UseCard;
            PayCost payCost = duel.Progress(new CardSelectionResponse<IHandCard>(useCard.Cards.First())) as PayCost;
            throw new NotImplementedException("Zones are not public information.");
            //Assert.Throws<MandatoryMultipleCardSelectionException>(() => duel.Progress(new CardSelectionResponse<IHandCard>(duel.Player1.Hand.Cards.First())));
        }

        [Fact]
        public void InvalidCardSelectionResponseDeclareAttack()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First() )) as UseCard;
            duel.Progress(new CardSelectionResponse<IHandCard>(useCard.Cards.First()));
            duel.Progress(new CardSelectionResponse<IHandCard>());
            duel.Progress(new CardSelectionResponse<IHandCard>());
            DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse<IHandCard>()) as DeclareAttacker;
            throw new NotImplementedException("Zones are not public information.");
            //Assert.Throws<OptionalCreatureSelectionException>(() => duel.Progress(new CreatureSelectionResponse<IHandCard>(duel.Player1.ManaZone.Creatures.First())));
        }

        [Fact]
        public void InvalidCardSelectionResponseUseCard()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First())) as UseCard;
            throw new NotImplementedException("Zones are not public information.");
            //Assert.Throws<OptionalCardSelectionException>(() => duel.Progress(new CardSelectionResponse<IHandCard>(duel.Player1.ManaZone.Cards.First())));
        }

        [Fact]
        public void InvalidCardSelectionResponseChargeMana()
        {
            Duel duel = GetDuel();
            ChargeMana chargeMana = (duel.Start() as ChargeMana);
            throw new NotImplementedException("Zones are not public information.");
            //Assert.Throws<OptionalCardSelectionException>(() => duel.Progress(new CardSelectionResponse<IHandCard>(duel.Player1.ShieldZone.Cards.First())));
        }

        [Fact]
        public void Player1ShouldWin()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First())) as UseCard;
            duel.Progress(new CardSelectionResponse<IHandCard>(useCard.Cards.First()));
            for (int i = 0; i < 6; ++i)
            {
                duel.Progress(new CardSelectionResponse<IHandCard>());
                duel.Progress(new CardSelectionResponse<IHandCard>());
                DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse<IHandCard>()) as DeclareAttacker;
                duel.Progress(new CreatureSelectionResponse<BattleZoneCreature>(declareAttacker.Creatures.First()));
            }
            Assert.Equal(duel.Player1, duel.Winner);
        }

        [Fact]
        public void Player2ShouldHave4Shields()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First())) as UseCard;
            duel.Progress(new CardSelectionResponse<IHandCard>(useCard.Cards.First()));
            duel.Progress(new CardSelectionResponse<IHandCard>());
            duel.Progress(new CardSelectionResponse<IHandCard>());
            DeclareAttacker declareAttacker = duel.Progress(new CardSelectionResponse<IHandCard>()) as DeclareAttacker;
            duel.Progress(new CreatureSelectionResponse<BattleZoneCreature>(declareAttacker.Creatures.First()));
            throw new NotImplementedException("Zones are not public information.");
            //Assert.Equal(4, duel.Player2.ShieldZone.Cards.Count);
        }

        [Fact]
        public void ShouldReturnPayCost()
        {
            Duel duel = GetDuel();
            duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First()));
            duel.Progress(new CardSelectionResponse<IHandCard>());
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Progress(new CardSelectionResponse<IHandCard>()) as ChargeMana).Cards.First())) as UseCard;
            PlayerAction newAction = duel.Progress(new CardSelectionResponse<IHandCard>(useCard.Cards.First()));
            Assert.IsType<PayCost>(newAction);
        }

        [Fact]
        public void ShouldReturnDeclareAttacker()
        {
            Duel duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First())) as UseCard;
            duel.Progress(new CardSelectionResponse<IHandCard>(useCard.Cards.First()));
            duel.Progress(new CardSelectionResponse<IHandCard>());
            duel.Progress(new CardSelectionResponse<IHandCard>());
            Assert.IsType<DeclareAttacker>(duel.Progress(new CardSelectionResponse<IHandCard>()));
        }

        [Fact]
        public void ShouldReturnUseCard()
        {
            Duel duel = GetDuel();
            Assert.IsType<UseCard>(duel.Progress(new CardSelectionResponse<IHandCard>((duel.Start() as ChargeMana).Cards.First())));
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
            Creature creature = GetTestCreature("");
            throw new NotImplementedException();
            //CreatureSelectionResponse<IHandCard> jotain = new CreatureSelectionResponse<IHandCard>(creature);
        }

        [Fact]
        public void TestAccessMofifiers()
        {
            Duel duel = GetDuel();
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
            ChargeMana chargeMana2 = duel.Progress(new CardSelectionResponse<IHandCard>(useCard1.Cards.First())) as ChargeMana; // Use card (player 1)

            ChargeMana chargeMana3 = duel.Progress(new CardSelectionResponse<IHandCard>()) as ChargeMana; // Do not charge mana (player 2)
            UseCard useCard2 = duel.Progress(new CardSelectionResponse<IHandCard>()) as UseCard; // Do not charge mana (player 1)

            PlayerAction jotain = duel.Progress(new CardSelectionResponse<IHandCard>(useCard2.Cards.First())); // Use card (player 2)

            //var jotain = duel.Progress()
            //hrow new System.NotImplementedException();
            //DuelMastersModels.Abilities.NonStaticAbility
        }
        */

        private static List<DuelEvent> _duelEvents = new List<DuelEvent>();

        private void DuelEventOccurred(object sender, DuelEventArgs e)
        {
            _duelEvents.Add(e.DuelEvent);
        }

        private Duel GetDuel()
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
    }
}