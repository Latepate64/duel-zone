using DuelMastersModels.Cards;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
    /// </summary>
    internal class BattleZone : Zone<IBattleZoneCard>, ITappableZone//TappableZone<IBattleZoneCard>
    {
        internal override bool Public { get; } = true;
        internal override bool Ordered { get; } = false;

        internal ReadOnlyCreatureCollection<BattleZoneCreature> Creatures => new ReadOnlyCreatureCollection<BattleZoneCreature>(Cards.OfType<BattleZoneCreature>());
        internal ReadOnlyCreatureCollection<IBattleZoneCreature> TappedCreatures => new ReadOnlyCreatureCollection<IBattleZoneCreature>(Creatures.Where(creature => creature.Tapped));
        internal ReadOnlyCreatureCollection<BattleZoneCreature> UntappedCreatures => new ReadOnlyCreatureCollection<BattleZoneCreature>(Creatures.Where(creature => !creature.Tapped));

        public void UntapCards()
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
            _cards.Remove(card);
            if (card is BattleZoneCreature creature)
            {
                creature.SummoningSickness = true;
            }
        }
    }
}