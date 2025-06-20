using ContinuousEffects;

namespace Cards.Cards.DM01
{
    class DarkRavenShadowOfGrief : Engine.Creature
    {
        public DarkRavenShadowOfGrief() : base("Dark Raven, Shadow of Grief", 4, 1000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
