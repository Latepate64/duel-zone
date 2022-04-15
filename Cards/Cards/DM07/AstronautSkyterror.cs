using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM07
{
    class AstronautSkyterror : Creature
    {
        public AstronautSkyterror() : base("Astronaut Skyterror", 5, 4000, Engine.Subtype.ArmoredWyvern, Civilization.Fire)
        {
            AddStaticAbilities(new GalsaurEffect());
        }
    }
}
