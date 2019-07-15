using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.CardFilters
{
    public class TargetCreatureFilter : CreatureFilter
    {
        public Creature Creature { get; private set; }

        public TargetCreatureFilter(Creature creature)
        {
            Creature = creature;
        }

        public override Collection<Creature> FilteredSpells
        {
            get { return new Collection<Creature>() { Creature }; }
        } 
    }
}
