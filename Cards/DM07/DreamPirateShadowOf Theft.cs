using ContinuousEffects;

namespace Cards.DM07
{
    class DreamPirateShadowOfTheft : Engine.Creature
    {
        public DreamPirateShadowOfTheft() : base("Dream Pirate, Shadow of Theft", 4, 3000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new GigastandEffect());
        }
    }
}
