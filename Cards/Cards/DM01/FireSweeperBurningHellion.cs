using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class FireSweeperBurningHellion : Creature
    {
        public FireSweeperBurningHellion() : base("Fire Sweeper Burning Hellion", 4, Common.Civilization.Fire, 3000, Common.Subtype.Dragonoid)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}
