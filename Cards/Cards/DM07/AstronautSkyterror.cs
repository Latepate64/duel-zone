using Common;

namespace Cards.Cards.DM07
{
    class AstronautSkyterror : Creature
    {
        public AstronautSkyterror() : base("Astronaut Skyterror", 5, 4000, Subtype.ArmoredWyvern, Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.GalsaurAbility());
        }
    }
}
