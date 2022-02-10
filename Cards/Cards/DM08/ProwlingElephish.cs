using Cards.StaticAbilities;

namespace Cards.Cards.DM08
{
    public class ProwlingElephish : Creature
    {
        public ProwlingElephish() : base("Prowling Elephish", 4, Common.Civilization.Water, 2000, Common.Subtype.GelFish)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
