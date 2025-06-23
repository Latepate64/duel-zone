using ContinuousEffects;

namespace Cards.DM01
{
    sealed class FireSweeperBurningHellion : Creature
    {
        public FireSweeperBurningHellion() : base("Fire Sweeper Burning Hellion", 4, 3000, Interfaces.Race.Dragonoid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
