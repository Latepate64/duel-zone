using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class SmashHornQ : Creature
    {
        public SmashHornQ() : base("Smash Horn Q", 3, 2000, Engine.Subtype.Survivor, Engine.Subtype.HornedBeast, Engine.Civilization.Nature)
        {
            AddSurvivorAbility(new ThisCreatureGetsPowerEffect(1000));
        }
    }
}
