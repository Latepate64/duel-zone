using Abilities.Static;

namespace Cards.DM05
{
    sealed class Gigakail : Creature
    {
        public Gigakail() : base("Gigakail", 5, 4000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new CivilizationSlayerAbility(Interfaces.Civilization.Nature, Interfaces.Civilization.Light));
        }
    }
}
