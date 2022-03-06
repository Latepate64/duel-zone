using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class KingCoral : Creature
    {
        public KingCoral() : base("King Coral", 3, 1000, Common.Subtype.Leviathan, Common.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
        }
    }
}
