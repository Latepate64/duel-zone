using Abilities.Static;

namespace Cards.DM01
{
    sealed class KingCoral : Creature
    {
        public KingCoral() : base("King Coral", 3, 1000, Interfaces.Race.Leviathan, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
        }
    }
}
