using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class BillionDegreeDragon : Creature
    {
        public BillionDegreeDragon() : base("Billion-Degree Dragon", 10, 15000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new TripleBreakerEffect());
        }
    }
}
