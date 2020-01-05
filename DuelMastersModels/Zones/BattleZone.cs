using DuelMastersModels.Abilities.TriggerAbilities;
using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

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
                duel.TriggerTriggerAbilities<WhenYouPutThisCreatureIntoTheBattleZone>(creature);
                duel.TriggerTriggerAbilities<WheneverAnotherCreatureIsPutIntoTheBattleZone>(new System.Collections.ObjectModel.ReadOnlyCollection<Creature>(duel.CreaturesInTheBattleZone.Except(new List<Creature>() { creature }).ToList()));
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