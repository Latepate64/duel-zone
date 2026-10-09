using Abilities.Static;

namespace Cards.DM05
{
    sealed class LurkingEel : Creature
    {
        public LurkingEel() : base("Lurking Eel", 6, 4000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddAbilities(new CivilizationBlockerAbility(Interfaces.Civilization.Fire, Interfaces.Civilization.Nature));
        }
    }
}
