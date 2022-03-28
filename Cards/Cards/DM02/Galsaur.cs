using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM02
{
    class Galsaur : Creature
    {
        public Galsaur() : base("Galsaur", 5, 4000, Subtype.RockBeast, Civilization.Fire)
        {
            AddStaticAbilities(new GalsaurEffect());
        }
    }
}
