using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
    /// </summary>
    public class BattleZone : Zone<IBattleZoneCard>
    {
        internal override bool Public { get; } = true;
        internal override bool Ordered { get; } = false;

        public IEnumerable<IBattleZoneCreature> Creatures => new ReadOnlyCollection<IBattleZoneCreature>(Cards.OfType<IBattleZoneCreature>().ToList());

        public IEnumerable<IBattleZoneCreature> GetTappedCreatures()
        {
            return new ReadOnlyCollection<IBattleZoneCreature>(Creatures.Where(creature => creature.Tapped).ToList());
        }

        public IEnumerable<IBattleZoneCreature> GetUntappedCreatures()
        {
            return new ReadOnlyCollection<IBattleZoneCreature>(Creatures.Where(creature => !creature.Tapped).ToList());
        }

        public IEnumerable<ITappable> TappedCards => new ReadOnlyCollection<ITappable>(Cards.OfType<ITappable>().Where(c => c.Tapped).ToList());

        public Duel Duel { get; set; }

        public void UntapCards()
        {
            foreach (BattleZoneCreature creature in GetTappedCreatures())
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

        public IEnumerable<IBattleZoneCreature> GetUntappedCreatures(IPlayer player)
        {
            return GetUntappedCreatures().Where(c => c.Owner == player);
        }

        public IEnumerable<IBattleZoneCreature> GetTappedCreatures(IPlayer player)
        {
            return GetTappedCreatures().Where(c => c.Owner == player);
        }
    }
}