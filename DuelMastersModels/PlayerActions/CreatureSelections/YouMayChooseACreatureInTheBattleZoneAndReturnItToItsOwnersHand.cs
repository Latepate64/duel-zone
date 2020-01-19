using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may choose a creature in the battle zone and return it to its owner's hand.
    /// </summary>
    public class YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand : OptionalCreatureSelection<IBattleZoneCreature>
    {
        internal YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand(Player player, ReadOnlyCreatureCollection<IBattleZoneCreature> creatures) : base(player, creatures)
        { }

        internal override PlayerAction Perform(Duel duel, IBattleZoneCreature creature)
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
