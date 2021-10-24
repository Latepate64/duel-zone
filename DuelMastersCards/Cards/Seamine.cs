using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Seamine : Creature
    {
        public Seamine() : base("Seamine", 6, Civilization.Water, 4000, Subtype.Fish)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
