using ContinuousEffects;

namespace Cards.DM07
{
    sealed class AstronautSkyterror : Engine.Creature
    {
        public AstronautSkyterror() : base("Astronaut Skyterror", 5, 4000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new GalsaurEffect());
        }
    }
}
