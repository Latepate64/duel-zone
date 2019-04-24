using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Zones
{
    public class BattleZone : Zone
    {
        public override bool Public { get; } = true;
        public override bool Ordered { get; } = false;
        
        public override void Add(Card card)
        {
            Cards.Add(card);
        }

        public override void Remove(Card card)
        {
            Cards.Remove(card);
        }

        public Collection<Creature> GetCreaturesThatCanBlock(Creature attackingCreature)
        {
            return UntappedBlockers;
            //TODO: consider situations where abilities of attacking creature matter etc.
        }
    }
}