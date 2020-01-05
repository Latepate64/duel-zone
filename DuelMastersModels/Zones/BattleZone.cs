using DuelMastersModels.Cards;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
    /// </summary>
    public class BattleZone : Zone
    {
        internal override bool Public { get; } = true;
        internal override bool Ordered { get; } = false;

        internal override void Add(Card card, Duel duel)
        {
            _cards.Add(card);
            card.KnownToOwner = true;
            card.KnownToOpponent = true;
            if (card is Creature creature)
            {
                creature.SummoningSickness = true;
                duel.TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(creature);
                duel.TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(creature);
            }
        }

        internal override void Remove(Card card, Duel duel)
        {
            _cards.Remove(card);
            card.Tapped = false;
            if (card is Creature creature)
            {
                creature.SummoningSickness = true;
            }
        }
    }
}