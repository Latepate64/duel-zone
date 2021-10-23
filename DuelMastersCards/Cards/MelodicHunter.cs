using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class MelodicHunter : Creature
    {
        public MelodicHunter() : base("Melodic Hunter", 5, Civilization.Water, 3000, Subtype.Merfolk)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
