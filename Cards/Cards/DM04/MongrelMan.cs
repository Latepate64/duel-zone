using TriggeredAbilities;
using OneShotEffects;

namespace Cards.Cards.DM04
{
    class MongrelMan : Engine.Creature
    {
        public MongrelMan() : base("Mongrel Man", 5, 2000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverAnotherCreatureIsDestroyedAbility(new YouMayDrawCardEffect()));
        }
    }
}
