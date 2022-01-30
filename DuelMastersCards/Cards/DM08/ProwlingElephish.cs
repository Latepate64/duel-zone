using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM08
{
    public class ProwlingElephish : Creature
    {
        public ProwlingElephish() : base("Prowling Elephish", 4, Civilization.Water, 2000, Subtype.GelFish)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
