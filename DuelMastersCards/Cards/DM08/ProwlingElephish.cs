using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class ProwlingElephish : Creature
    {
        public ProwlingElephish() : base("Prowling Elephish", 4, Civilization.Water, 2000, Subtype.GelFish)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
