using Abilities.Static;
using CardFilters;
using Interfaces;

namespace Cards.DM05;

sealed class WispHowlerShadowOfTears : Creature
{
    public WispHowlerShadowOfTears() : base("Wisp Howler, Shadow of Tears", 3,
        2000, Race.Ghost, Civilization.Darkness)
    {
        AddAbilities(new SlayerAbility(new CivilizationCreatureFilter(
            Civilization.Nature, Civilization.Light)));
    }
}