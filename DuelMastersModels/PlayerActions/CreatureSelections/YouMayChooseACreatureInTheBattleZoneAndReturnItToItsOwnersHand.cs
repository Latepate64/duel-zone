using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may choose a creature in the battle zone and return it to its owner's hand.
    /// </summary>
    public class YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand : OptionalCreatureSelection
    {
        internal YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand(Player player, ReadOnlyCreatureCollection creatures) : base(player, creatures)
        { }

        internal override PlayerAction Perform(Duel duel, Creature creature)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            else if (creature == null)
            {
                return null;
            }
            else
            {
                return duel.ReturnFromBattleZoneToHand(creature);
            }
        }
    }
}
