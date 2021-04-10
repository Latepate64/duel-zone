using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions.CardSelections;
using System;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may choose a creature in the battle zone and return it to its owner's hand.
    /// </summary>
    public class YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand : OptionalCardSelection<IBattleZoneCreature>
    {
        internal YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand(IPlayer player, IEnumerable<IBattleZoneCreature> creatures) : base(player, creatures)
        { }

        internal override PlayerAction Perform(IDuel duel, IBattleZoneCreature creature)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            else
            {
                return creature == null ? null : duel.ReturnFromBattleZoneToHand(creature);
            }
        }
    }
}
