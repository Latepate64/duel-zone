using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may choose a creature in the battle zone and put it into its owner's mana zone. If they do, they choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.
    /// </summary>
    public class SoulSwapSelection : OptionalCreatureSelection
    {
        internal SoulSwapSelection(Player player, ReadOnlyCreatureCollection creatures) : base(player, creatures)
        { }

        internal override PlayerAction Perform(Duel duel, Creature creature)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
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
