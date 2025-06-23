using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM04
{
    sealed class MongrelMan : Creature
    {
        public MongrelMan() : base("Mongrel Man", 5, 2000, Interfaces.Race.Hedrian, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverAnotherCreatureIsDestroyedAbility(new YouMayDrawCardEffect()));
        }
    }
}
