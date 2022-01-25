using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM10
{
    public class TidePatroller : Creature
    {
        public TidePatroller() : base("Tide Patroller", 4, Civilization.Water, 2000, Subtype.Merfolk)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
