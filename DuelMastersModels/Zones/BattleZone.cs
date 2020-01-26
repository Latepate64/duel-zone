using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
    /// </summary>
    public class BattleZone : Zone<IBattleZoneCard>//, ITappableZone//TappableZone<IBattleZoneCard>
    {
        internal override bool Public { get; } = true;
        internal override bool Ordered { get; } = false;

        internal IEnumerable<BattleZoneCreature> Creatures => new ReadOnlyCollection<BattleZoneCreature>(Cards.OfType<BattleZoneCreature>().ToList());
        internal IEnumerable<IBattleZoneCreature> TappedCreatures => new ReadOnlyCollection<BattleZoneCreature>(Creatures.Where(creature => creature.Tapped).ToList());
        internal IEnumerable<BattleZoneCreature> UntappedCreatures => new ReadOnlyCollection<BattleZoneCreature>(Creatures.Where(creature => !creature.Tapped).ToList());

        internal void UntapCards()
        {
            foreach (BattleZoneCreature creature in TappedCreatures)
            {
                creature.Tapped = false;
            }
        }

        internal override void Add(IBattleZoneCard card, Duel duel)
        {
            _cards.Add(card);
            if (card is IBattleZoneCreature creature)
            {
                duel.TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(creature);
                duel.TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(creature);
            }
        }

        internal override void Remove(IBattleZoneCard card, Duel duel)
        {
            _ = _cards.Remove(card);
        }
    }
}