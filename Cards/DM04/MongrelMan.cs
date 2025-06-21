using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM04
{
    class MongrelMan : Engine.Creature
    {
        public MongrelMan() : base("Mongrel Man", 5, 2000, Interfaces.Race.Hedrian, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverAnotherCreatureIsDestroyedAbility(new YouMayDrawCardEffect()));
        }
    }
}
