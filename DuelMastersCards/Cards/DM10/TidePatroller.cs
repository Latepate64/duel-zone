using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM10
{
    public class TidePatroller : Creature
    {
        public TidePatroller() : base("Tide Patroller", 4, Civilization.Water, 2000, Subtype.Merfolk)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
