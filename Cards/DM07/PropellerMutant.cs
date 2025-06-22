using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM07
{
    sealed class PropellerMutant : Engine.Creature
    {
        public PropellerMutant() : base("Propeller Mutant", 2, 1000, Interfaces.Race.Hedrian, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
