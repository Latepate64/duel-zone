using Abilities.Static;
using CardFilters;
using Interfaces;

namespace Cards.DM05;

sealed class Gigakail : Creature
{
    public Gigakail() : base("Gigakail", 5, 4000, Race.Chimera,
        Civilization.Darkness)
    {
        AddAbilities(new SlayerAbility(new CivilizationCreatureFilter(
            Civilization.Nature, Civilization.Light)));
    }
}