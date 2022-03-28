using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM07
{
    class DreamPirateShadowOfTheft : Creature
    {
        public DreamPirateShadowOfTheft() : base("Dream Pirate, Shadow of Theft", 4, 3000, Subtype.Ghost, Civilization.Darkness)
        {
            AddStaticAbilities(new GigastandEffect());
        }
    }
}
