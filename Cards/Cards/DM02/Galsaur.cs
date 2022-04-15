using Cards.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class Galsaur : Creature
    {
        public Galsaur() : base("Galsaur", 5, 4000, Engine.Subtype.RockBeast, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new GalsaurEffect());
        }
    }
}
