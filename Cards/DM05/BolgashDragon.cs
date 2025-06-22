using ContinuousEffects;

namespace Cards.DM05
{
    sealed class BolgashDragon : Engine.Creature
    {
        public BolgashDragon() : base("Bolgash Dragon", 8, 4000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(8000));
            AddStaticAbilities(new TripleBreakerEffect());
        }
    }
}
