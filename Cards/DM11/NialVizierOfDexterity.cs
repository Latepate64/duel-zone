using TriggeredAbilities;

namespace Cards.DM11
{
    class NialVizierOfDexterity : Engine.Creature
    {
        public NialVizierOfDexterity() : base("Nial, Vizier of Dexterity", 3, 2500, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()));
        }
    }
}
