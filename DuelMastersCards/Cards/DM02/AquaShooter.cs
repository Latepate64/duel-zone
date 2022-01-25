using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM02
{
    public class AquaShooter : Creature
    {
        public AquaShooter() : base("Aqua Shooter", 4, Civilization.Water, 2000, Subtype.LiquidPeople)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
