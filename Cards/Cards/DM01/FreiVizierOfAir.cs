using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class FreiVizierOfAir : Creature
    {
        public FreiVizierOfAir() : base("Frei, Vizier of Air", 4, 3000, Engine.Subtype.Initiate, Engine.Civilization.Light)
        {
            AddAtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect());
        }
    }
}
