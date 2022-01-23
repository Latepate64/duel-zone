using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    class FireSweeperBurningHellion : Creature
    {
        public FireSweeperBurningHellion() : base("Fire Sweeper Burning Hellion", 4, Civilization.Fire, 3000, Subtype.Dragonoid)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}
