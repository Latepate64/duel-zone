using Abilities.Static;
using CardFilters;
using Interfaces;

namespace Cards.DM05
{
    sealed class LurkingEel : Creature
    {
        public LurkingEel() : base("Lurking Eel", 6, 4000, Race.GelFish, Civilization.Water)
        {
            AddAbilities(new BlockerAbility(new CivilizationCreatureFilter(Civilization.Fire, Civilization.Nature)));
        }
    }
}
