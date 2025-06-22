using ContinuousEffects;

namespace Cards.DM01
{
    sealed class DarkRavenShadowOfGrief : Engine.Creature
    {
        public DarkRavenShadowOfGrief() : base("Dark Raven, Shadow of Grief", 4, 1000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
