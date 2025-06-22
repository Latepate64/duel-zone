using ContinuousEffects;

namespace Cards.DM05
{
    sealed class BillionDegreeDragon : Engine.Creature
    {
        public BillionDegreeDragon() : base("Billion-Degree Dragon", 10, 15000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new TripleBreakerEffect());
        }
    }
}
