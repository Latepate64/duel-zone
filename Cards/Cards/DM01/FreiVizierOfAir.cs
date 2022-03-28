using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class FreiVizierOfAir : Creature
    {
        public FreiVizierOfAir() : base("Frei, Vizier of Air", 4, 3000, Common.Subtype.Initiate, Common.Civilization.Light)
        {
            AddAtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect());
        }
    }
}
