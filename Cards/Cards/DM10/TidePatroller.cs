using Cards.StaticAbilities;

namespace Cards.Cards.DM10
{
    class TidePatroller : Creature
    {
        public TidePatroller() : base("Tide Patroller", 4, 2000, Common.Subtype.Merfolk, Common.Civilization.Water)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
