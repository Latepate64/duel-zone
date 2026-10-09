using Abilities.Static;
using TriggeredAbilities;

namespace Cards.DM01
{
    sealed class UrthPurifyingElemental : Creature
    {
        public UrthPurifyingElemental() : base("Urth, Purifying Elemental", 6, 6000, Interfaces.Race.AngelCommand, Interfaces.Civilization.Light)
        {
            AddAbilities(new DoubleBreakerAbility());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()));
        }
    }
}
