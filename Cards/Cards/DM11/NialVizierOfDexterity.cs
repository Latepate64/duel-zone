namespace Cards.Cards.DM11
{
    class NialVizierOfDexterity : Creature
    {
        public NialVizierOfDexterity() : base("Nial, Vizier of Dexterity", 3, 2500, Engine.Race.Initiate, Engine.Civilization.Light)
        {
            AddAtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect());
        }
    }
}
