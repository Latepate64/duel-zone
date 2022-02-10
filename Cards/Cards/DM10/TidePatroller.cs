using Cards.StaticAbilities;

namespace Cards.Cards.DM10
{
    public class TidePatroller : Creature
    {
        public TidePatroller() : base("Tide Patroller", 4, Common.Civilization.Water, 2000, Common.Subtype.Merfolk)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
