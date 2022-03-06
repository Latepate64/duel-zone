using Cards.StaticAbilities;

namespace Cards.Cards.DM08
{
    class ProwlingElephish : Creature
    {
        public ProwlingElephish() : base("Prowling Elephish", 4, 2000, Common.Subtype.GelFish, Common.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
        }
    }
}
