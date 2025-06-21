using ContinuousEffects;

namespace Cards.DM05
{
    class BolgashDragon : Engine.Creature
    {
        public BolgashDragon() : base("Bolgash Dragon", 8, 4000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(8000));
            AddStaticAbilities(new TripleBreakerEffect());
        }
    }
}
