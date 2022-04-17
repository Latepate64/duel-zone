using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class BalloonshroomQ : Creature
    {
        public BalloonshroomQ() : base("Balloonshroom Q", 4, 2000, Engine.Race.Survivor, Engine.Race.BalloonMushroom, Engine.Civilization.Nature)
        {
            AddSurvivorAbility(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}
