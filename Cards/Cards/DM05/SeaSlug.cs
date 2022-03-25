using Common;

namespace Cards.Cards.DM05
{
    class SeaSlug : Creature
    {
        public SeaSlug() : base("Sea Slug", 8, 6000, Subtype.GelFish, Civilization.Water)
        {
            AddAbilities(new StaticAbilities.BlockerAbility(), new StaticAbilities.ThisCreatureCannotBeBlockedAbility());
        }
    }
}
