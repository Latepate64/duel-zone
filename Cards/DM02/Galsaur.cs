using ContinuousEffects;

namespace Cards.DM02
{
    class Galsaur : Engine.Creature
    {
        public Galsaur() : base("Galsaur", 5, 4000, Engine.Race.RockBeast, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new GalsaurEffect());
        }
    }
}
