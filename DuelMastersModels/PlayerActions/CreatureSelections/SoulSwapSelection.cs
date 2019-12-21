using DuelMastersModels.Cards;
using System;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    public class SoulSwapSelection : OptionalCreatureSelection
    {
        public SoulSwapSelection(Player player, Collection<Creature> creatures) : base(player, creatures)
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
                duel.PutFromBattleZoneIntoOwnersManazone(creature);
                Player owner = duel.GetOwner(creature);
                return new ChooseANonEvolutionCreatureInThatPlayersManaZoneThatCostsTheSameAsOrLessThanTheNumberOfCardsInThatManaZoneThatPlayerPutsThatCreatureIntoTheBattleZone(Player, owner.ManaZone.NonEvolutionCreaturesThatCostTheSameAsOrLessThanTheNumberOfCardsInTheZone);
            }
        }
    }
}
