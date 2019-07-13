using DuelMastersModels.Abilities.Trigger;
using DuelMastersModels.Cards;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Zones
{
    public class BattleZone : Zone
    {
        public override bool Public { get; } = true;
        public override bool Ordered { get; } = false;
        
        public BattleZone(Player owner) : base(owner) { }

        public override void Add(Card card)
        {
            Cards.Add(card);
            foreach (TriggerAbility ability in card.TriggerAbilities.Where(ability => ability.TriggerCondition is WhenYouPutThisCreatureIntoTheBattleZone))
            {
                Owner.TriggerAbilities.Add(ability.DeepCopy());
            }
        }

        public override void Remove(Card card)
        {
            Cards.Remove(card);
        }

        /*
        public Collection<Creature> GetCreaturesThatCanBlock(Creature attackingCreature)
        {
            return UntappedBlockers;
            //TODO: consider situations where abilities of attacking creature matter etc.
        }*/
    }
}