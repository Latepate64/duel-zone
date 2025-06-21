using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01
{
    class FreiVizierOfAir : Engine.Creature
    {
        public FreiVizierOfAir() : base("Frei, Vizier of Air", 4, 3000, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect()));
        }
    }
}
