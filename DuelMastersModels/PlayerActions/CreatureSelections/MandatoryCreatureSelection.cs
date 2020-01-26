using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions.CardSelections;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player must select one creature.
    /// </summary>
    public abstract class MandatoryCreatureSelection<TCreature> : MandatoryCardSelection<TCreature> where TCreature : ICreature
    {
        internal MandatoryCreatureSelection(Player player, IEnumerable<TCreature> creatures) : base(player, creatures)
        { }

        /*internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Cards.Count() == 1 ? Perform(duel, Creatures[0]) : (this);
        }

        internal void Validate(TCreature creature)
        {
            if (!Creatures.Contains(creature))
            {
                throw new Exceptions.MandatoryCreatureSelectionException(ToString());
            }
        }

        internal abstract PlayerAction Perform(Duel duel, TCreature creature);*/
    }
}