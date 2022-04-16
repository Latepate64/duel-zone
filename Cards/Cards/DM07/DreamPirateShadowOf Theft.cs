using Cards.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class DreamPirateShadowOfTheft : Creature
    {
        public DreamPirateShadowOfTheft() : base("Dream Pirate, Shadow of Theft", 4, 3000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new GigastandEffect());
        }
    }
}
