using DuelMastersModels.Abilities.Trigger;
using DuelMastersModels.Cards;
using System.Linq;

namespace DuelMastersModels.Zones
{
    public class BattleZone : Zone
    {
        public override bool Public { get; } = true;
        public override bool Ordered { get; } = false;
        
        public BattleZone(Player owner) : base(owner) { }

        public override void Add(Card card, Duel duel)
        {
            if (card is Creature creature)
            {
                creature.SummoningSickness = true;
            }
            Cards.Add(card);
            card.KnownToOwner = true;
            card.KnownToOpponent = true;
            foreach (TriggerAbility ability in card.TriggerAbilities.Where(ability => ability.TriggerCondition is WhenYouPutThisCreatureIntoTheBattleZone))
            {
                duel.TriggerTriggerAbility(ability, Owner);
            }
        }

        public override void Remove(Card card, Duel duel)
        {
            Cards.Remove(card);
            card.Tapped = false;
            if (card is Creature creature)
            {
                creature.SummoningSickness = true;
            }
        }
    }
}