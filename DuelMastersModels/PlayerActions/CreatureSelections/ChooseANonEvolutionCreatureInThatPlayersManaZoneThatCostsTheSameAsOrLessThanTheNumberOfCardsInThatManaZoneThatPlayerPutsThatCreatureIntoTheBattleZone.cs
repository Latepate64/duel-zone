using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions.CardSelections;
using System;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player chooses a non-evolution creature in a player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.
    /// </summary>
    public class ChooseANonEvolutionCreatureInThatPlayersManaZoneThatCostsTheSameAsOrLessThanTheNumberOfCardsInThatManaZoneThatPlayerPutsThatCreatureIntoTheBattleZone : MandatoryCardSelection<IManaZoneCreature>
    {
        internal ChooseANonEvolutionCreatureInThatPlayersManaZoneThatCostsTheSameAsOrLessThanTheNumberOfCardsInThatManaZoneThatPlayerPutsThatCreatureIntoTheBattleZone(Player player, ReadOnlyCreatureCollection<IManaZoneCreature> creatures) : base(player, creatures)
        { }

        internal override PlayerAction Perform(Duel duel, IManaZoneCreature creature)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            else
            {
                return duel.PutFromManaZoneIntoTheBattleZone(creature);
            }
        }
    }
}
