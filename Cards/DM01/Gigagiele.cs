using Abilities.Static;

namespace Cards.DM01
{
    sealed class Gigagiele : Creature
    {
        public Gigagiele() : base("Gigagiele", 5, 3000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new SlayerAbility());
        }
    }
}
