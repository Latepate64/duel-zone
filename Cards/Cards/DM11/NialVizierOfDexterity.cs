using Common;

namespace Cards.Cards.DM11
{
    class NialVizierOfDexterity : Creature
    {
        public NialVizierOfDexterity() : base("Nial, Vizier of Dexterity", 3, 2500, Engine.Subtype.Initiate, Civilization.Light)
        {
            AddAtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect());
        }
    }
}
