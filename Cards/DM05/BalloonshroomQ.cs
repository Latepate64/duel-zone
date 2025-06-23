using ContinuousEffects;
using Engine.Abilities;

namespace Cards.DM05
{
    sealed class BalloonshroomQ : Creature
    {
        public BalloonshroomQ() : base("Balloonshroom Q", 4, 2000, [Interfaces.Race.Survivor, Interfaces.Race.BalloonMushroom], Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(
                new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect())));
        }
    }
}
