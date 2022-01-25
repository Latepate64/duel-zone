using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Gigagiele : Creature
    {
        public Gigagiele() : base("Gigagiele", 5, Civilization.Darkness, 3000, Subtype.Chimera)
        {
            Abilities.Add(new SlayerAbility());
        }
    }
}
