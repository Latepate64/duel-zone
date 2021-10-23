using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class TidePatroller : Creature
    {
        public TidePatroller() : base("TidePatroller", 4, Civilization.Water, 2000, Subtype.Merfolk)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
