using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class FreiVizierOfAir : Creature
    {
        public FreiVizierOfAir() : base("Frei, Vizier of Air", 4, 3000, Engine.Race.Initiate, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect()));
        }
    }
}
