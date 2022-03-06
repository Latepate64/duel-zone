using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class KingCoral : Creature
    {
        public KingCoral() : base("King Coral", 3, Common.Civilization.Water, 1000, Common.Subtype.Leviathan)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
