using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class BalloonshroomQ : Creature
    {
        public BalloonshroomQ() : base("Balloonshroom Q", 4, 2000, [Engine.Race.Survivor, Engine.Race.BalloonMushroom], Engine.Civilization.Nature)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(
                new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect())));
        }
    }
}
