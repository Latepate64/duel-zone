using ContinuousEffects;

namespace Cards.DM07
{
    class AstronautSkyterror : Engine.Creature
    {
        public AstronautSkyterror() : base("Astronaut Skyterror", 5, 4000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new GalsaurEffect());
        }
    }
}
