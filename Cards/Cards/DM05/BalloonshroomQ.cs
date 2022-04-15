using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class BalloonshroomQ : Creature
    {
        public BalloonshroomQ() : base("Balloonshroom Q", 4, 2000, Engine.Subtype.Survivor, Engine.Subtype.BalloonMushroom, Civilization.Nature)
        {
            AddSurvivorAbility(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}
