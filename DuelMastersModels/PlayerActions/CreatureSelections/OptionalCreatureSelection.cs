﻿using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may select up to one creature.
    /// </summary>
    public abstract class OptionalCreatureSelection<TCreature> : CreatureSelection<TCreature> where TCreature : class, ICreature
    {
        internal OptionalCreatureSelection(Player player, ReadOnlyCreatureCollection<TCreature> creatures) : base(player, creatures)
        { }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Creatures.Count == 0 ? Perform(duel, null) : (this);
        }

        internal void Validate(TCreature creature)
        {
            if (!(creature == null || Creatures.Contains(creature)))
            {
                throw new Exceptions.OptionalCreatureSelectionException(ToString());
            }
        }

        internal abstract PlayerAction Perform(Duel duel, TCreature creature);
    }
}
