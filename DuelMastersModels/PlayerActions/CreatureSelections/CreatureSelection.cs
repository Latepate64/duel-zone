/*
using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions.CardSelections;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player selects creatures.
    /// </summary>
    public abstract class CreatureSelection<TCreature> : CardSelection<TCreature> where TCreature : ICreature //PlayerAction
    {
        /// <summary>
        /// Creatures player can select from.
        /// </summary>
        public IEnumerable<TCreature> Creatures { get; private set; }

        internal CreatureSelection(Player player, IEnumerable<TCreature> creatures) : base(player,)
        {
            Creatures = creatures;
        }
    }
}
*/