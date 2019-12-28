using DuelMastersModels;
using DuelMastersModels.Abilities.Static;
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
    public class AbilityTests
    {
        /*
        [Fact]
        public void ShouldReturnDeclareBlock()
        {
            DeclareAttack(out Duel duel, out DeclareAttack declareAttack);
            Assert.IsType<DeclareBlock>(duel.Progress(new DeclareAttackResponse(declareAttack.CreaturesThatCanAttack.First(), null)));
        }

        [Fact]
        public void OpponentAttackedBlockNotDeclared()
        {
            DeclareAttack(out Duel duel, out DeclareAttack declareAttack);
            DeclareBlock declareBlock = duel.Progress(new DeclareAttackResponse(declareAttack.CreaturesThatCanAttack.First(), null)) as DeclareBlock;
            duel.Progress(new CreatureSelectionResponse());
            Assert.Equal(4, duel.Player2.ShieldZone.Cards.Count);
        }

        [Fact]
        public void InvalidCreatureSelectionResponseDeclareBlock()
        {
            DeclareAttack(out Duel duel, out DeclareAttack declareAttack);
            DeclareBlock declareBlock = duel.Progress(new DeclareAttackResponse(declareAttack.CreaturesThatCanAttack.First(), null)) as DeclareBlock;
            PlayerAction playerAction = duel.Progress(new CreatureSelectionResponse(new Collection<Creature>(new List<Creature>() { duel.Player1.Hand.Creatures.First() })));
            Assert.Equal(declareBlock, playerAction);
        }

        private void DeclareAttack(out Duel duel, out DeclareAttack declareAttack)
        {
            duel = GetDuel();
            UseCard useCard = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { (duel.StartDuel() as ChargeMana).Cards.First() }))) as UseCard;
            ChargeMana chargeMana = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { useCard.Cards.First() }))) as ChargeMana;
            UseCard useCard2 = duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { chargeMana.Cards.First() }))) as UseCard;
            duel.Progress(new CardSelectionResponse(new ReadOnlyCardCollection(new List<Card>() { useCard2.Cards.First() })));
            duel.Progress(new CardSelectionResponse());
            declareAttack = duel.Progress(new CardSelectionResponse()) as DeclareAttack;
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
            const int Count = 40;
            CardCollection p1Cards = new CardCollection();
            CardCollection p2Cards = new CardCollection();
            for (int i = 0; i < Count; ++i)
            {
                p1Cards.Add(GetTestCreature(i));
                p2Cards.Add(GetTestCreature(i + Count));
            }
            duel.Player1.SetDeckBeforeDuel(new ReadOnlyCardCollection(p1Cards));
            duel.Player2.SetDeckBeforeDuel(new ReadOnlyCardCollection(p2Cards));
            duel.Player1.SetupDeck(duel);
            duel.Player2.SetupDeck(duel);
            return duel;
        }

        private Creature GetTestCreature(int gameId)
        {
            Creature creature = new Creature(name: "TestCreature", null, null, civilizations: new Collection<string>() { "Light" }, null, cost: 1, null, null, null, gameId: gameId, power: "1000", races: new Collection<string>() { "Initiate" }, null);
            //creature.StaticAbilities.Add(new Blocker());
            return creature;
        }*/
    }
}
