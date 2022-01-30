using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class KingCoral : Creature
    {
        public KingCoral() : base("King Coral", 3, Civilization.Water, 1000, Subtype.Leviathan)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
