using ContinuousEffects;

namespace Cards.DM02
{
    class Galsaur : Engine.Creature
    {
        public Galsaur() : base("Galsaur", 5, 4000, Interfaces.Race.RockBeast, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new GalsaurEffect());
        }
    }
}
