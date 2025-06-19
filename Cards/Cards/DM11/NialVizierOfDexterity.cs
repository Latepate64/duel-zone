using Abilities.Triggered;

namespace Cards.Cards.DM11
{
    class NialVizierOfDexterity : Engine.Creature
    {
        public NialVizierOfDexterity() : base("Nial, Vizier of Dexterity", 3, 2500, Engine.Race.Initiate, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()));
        }
    }
}
