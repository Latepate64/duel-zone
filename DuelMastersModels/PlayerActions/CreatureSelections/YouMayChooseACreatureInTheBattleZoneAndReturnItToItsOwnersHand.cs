using DuelMastersModels.Cards;
using System;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    public class YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand : OptionalCreatureSelection
    {
        public YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand(Player player, Collection<Creature> creatures) : base(player, creatures)
        { }

        public override PlayerAction Perform(Duel duel, Creature creature)
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
