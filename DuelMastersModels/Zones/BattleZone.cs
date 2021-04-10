using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
    /// </summary>
    public class BattleZone : Zone<IBattleZoneCard>, IBattleZone
    {
        internal override bool Public { get; } = true;
        internal override bool Ordered { get; } = false;

        public IEnumerable<IBattleZoneCreature> Creatures => new ReadOnlyCollection<IBattleZoneCreature>(Cards.OfType<IBattleZoneCreature>().ToList());
        public IEnumerable<IBattleZoneCreature> TappedCreatures => new ReadOnlyCollection<IBattleZoneCreature>(Creatures.Where(creature => creature.Tapped).ToList());
        public IEnumerable<IBattleZoneCreature> UntappedCreatures => new ReadOnlyCollection<IBattleZoneCreature>(Creatures.Where(creature => !creature.Tapped).ToList());

        public IDuel Duel { get; set; }

        public void UntapCards()
        {
            foreach (BattleZoneCreature creature in TappedCreatures)
            {
                creature.Tapped = false;
            }
        }

        public override void Add(IBattleZoneCard card)
        {
            _cards.Add(card);
            if (card is IBattleZoneCreature creature)
            {
                Duel.TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(creature);
                Duel.TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(creature);
            }
        }

        public override void Remove(IBattleZoneCard card)
        {
            _ = _cards.Remove(card);
        }
    }
}